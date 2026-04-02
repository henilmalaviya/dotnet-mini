using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Primitives;
using ExamReady.Data;
using ExamReady.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExamReady.Views
{
    public partial class QuestionView : UserControl
    {
        private readonly DbConnection _db;
        private ObservableCollection<Question> _questions;
        private int _currentId = 0;

        public QuestionView()
        {
            InitializeComponent();
            _db = new DbConnection();
            _questions = new ObservableCollection<Question>();
            
            Loaded += OnLoaded;
        }

        private void OnLoaded(object? sender, RoutedEventArgs e)
        {
            LoadSubjects();
            LoadQuestions();
        }

        private void LoadSubjects()
        {
            try
            {
                var subjects = _db.GetDistinctSubjects();
                FilterSubject.Items.Clear();
                FilterSubject.Items.Add(new ComboBoxItem { Content = "" });
                foreach (var s in subjects)
                {
                    FilterSubject.Items.Add(new ComboBoxItem { Content = s });
                }
                FilterSubject.SelectedIndex = 0;
            }
            catch (System.Exception ex)
            {
                ShowError($"Error loading subjects: {ex.Message}");
            }
        }

        private void LoadQuestions(string? subject = null)
        {
            try
            {
                var list = subject == null || string.IsNullOrEmpty(subject) 
                    ? _db.GetAllQuestions() 
                    : _db.GetQuestionsBySubject(subject);
                
                _questions.Clear();
                foreach (var q in list)
                {
                    _questions.Add(q);
                }
                QuestionsGrid.ItemsSource = _questions;
            }
            catch (System.Exception ex)
            {
                ShowError($"Error loading questions: {ex.Message}");
            }
        }

        private void OnFilterChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (FilterSubject.SelectedItem is ComboBoxItem item)
            {
                string? subject = item.Content?.ToString();
                LoadQuestions(subject);
            }
        }

        private void OnShowAllClick(object? sender, RoutedEventArgs e)
        {
            FilterSubject.SelectedIndex = 0;
            LoadQuestions();
        }

        private void OnRefreshClick(object? sender, RoutedEventArgs e)
        {
            LoadSubjects();
            LoadQuestions();
        }

        private void OnGridSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (QuestionsGrid.SelectedItem is Question q)
            {
                _currentId = q.ID;
                TxtSubject.Text = q.Subject;
                TxtQuestionText.Text = q.QuestionText;
                CmbQType.SelectedIndex = q.QType == "MCQ" ? 0 : 1;
                CmbDifficulty.SelectedIndex = q.Difficulty == "Easy" ? 0 : q.Difficulty == "Medium" ? 1 : 2;
                NumMarks.Value = q.Marks;

                if (q is MCQQuestion mcq)
                {
                    MCQPanel.IsVisible = true;
                    TxtOptionA.Text = mcq.OptionA;
                    TxtOptionB.Text = mcq.OptionB;
                    TxtOptionC.Text = mcq.OptionC;
                    TxtOptionD.Text = mcq.OptionD;
                    CmbCorrectAnswer.SelectedIndex = mcq.CorrectAnswer?.ToUpper() switch
                    {
                        "A" => 0, "B" => 1, "C" => 2, "D" => 3, _ => -1
                    };
                }
                else
                {
                    MCQPanel.IsVisible = false;
                }
            }
        }

        private void OnQTypeChanged(object? sender, SelectionChangedEventArgs e)
        {
            MCQPanel.IsVisible = CmbQType.SelectedIndex == 0;
        }

        private void OnAddClick(object? sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                string qType = (CmbQType.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Descriptive";
                Question q = QuestionFactory.CreateQuestion(qType);
                
                q.Subject = TxtSubject.Text ?? "";
                q.QuestionText = TxtQuestionText.Text ?? "";
                q.QType = qType;
                q.Difficulty = (CmbDifficulty.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Easy";
                q.Marks = (int)(NumMarks.Value ?? 1);

                if (q is MCQQuestion mcq)
                {
                    mcq.OptionA = TxtOptionA.Text ?? "";
                    mcq.OptionB = TxtOptionB.Text ?? "";
                    mcq.OptionC = TxtOptionC.Text ?? "";
                    mcq.OptionD = TxtOptionD.Text ?? "";
                    mcq.CorrectAnswer = (CmbCorrectAnswer.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
                }

                int id = _db.InsertQuestion(q);
                ShowSuccess($"Question added! ID: {id}");
                ClearForm();
                LoadQuestions();
                LoadSubjects();
            }
            catch (System.Exception ex)
            {
                ShowError($"Error adding: {ex.Message}");
            }
        }

        private void OnUpdateClick(object? sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentId == 0)
                {
                    ShowError("Select a question to update.");
                    return;
                }

                if (!ValidateInput()) return;

                string qType = (CmbQType.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Descriptive";
                Question q = QuestionFactory.CreateQuestion(qType);
                
                q.ID = _currentId;
                q.Subject = TxtSubject.Text ?? "";
                q.QuestionText = TxtQuestionText.Text ?? "";
                q.QType = qType;
                q.Difficulty = (CmbDifficulty.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Easy";
                q.Marks = (int)(NumMarks.Value ?? 1);

                if (q is MCQQuestion mcq)
                {
                    mcq.OptionA = TxtOptionA.Text ?? "";
                    mcq.OptionB = TxtOptionB.Text ?? "";
                    mcq.OptionC = TxtOptionC.Text ?? "";
                    mcq.OptionD = TxtOptionD.Text ?? "";
                    mcq.CorrectAnswer = (CmbCorrectAnswer.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
                }

                _db.UpdateQuestion(q);
                ShowSuccess("Question updated!");
                ClearForm();
                LoadQuestions();
                LoadSubjects();
            }
            catch (System.Exception ex)
            {
                ShowError($"Error updating: {ex.Message}");
            }
        }

        private void OnDeleteClick(object? sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentId == 0)
                {
                    ShowError("Select a question to delete.");
                    return;
                }

                _db.DeleteQuestion(_currentId);
                ShowSuccess("Question deleted!");
                ClearForm();
                LoadQuestions();
                LoadSubjects();
            }
            catch (System.Exception ex)
            {
                ShowError($"Error deleting: {ex.Message}");
            }
        }

        private void OnClearClick(object? sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(TxtQuestionText.Text))
            {
                ShowError("Question text is required.");
                return false;
            }

            if (CmbQType.SelectedIndex < 0)
            {
                ShowError("Select question type.");
                return false;
            }

            if (CmbDifficulty.SelectedIndex < 0)
            {
                ShowError("Select difficulty.");
                return false;
            }

            if (NumMarks.Value <= 0)
            {
                ShowError("Marks must be > 0.");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            _currentId = 0;
            TxtSubject.Text = "";
            TxtQuestionText.Text = "";
            CmbQType.SelectedIndex = -1;
            CmbDifficulty.SelectedIndex = -1;
            NumMarks.Value = 1;
            TxtOptionA.Text = "";
            TxtOptionB.Text = "";
            TxtOptionC.Text = "";
            TxtOptionD.Text = "";
            CmbCorrectAnswer.SelectedIndex = -1;
            MCQPanel.IsVisible = false;
            QuestionsGrid.SelectedItem = null;
        }

        private void ShowError(string msg)
        {
            var dialog = new Window
            {
                Title = "Error",
                Width = 350,
                Height = 120,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false,
                Content = new StackPanel
                {
                    Margin = new Avalonia.Thickness(15),
                    Children =
                    {
                        new TextBlock { Text = msg, TextWrapping = Avalonia.Media.TextWrapping.Wrap },
                        new Button { Content = "OK", HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center, Margin = new Avalonia.Thickness(0,15,0,0) }
                    }
                }
            };
            dialog.ShowDialog((Window)VisualRoot);
        }

        private void ShowSuccess(string msg)
        {
            var dialog = new Window
            {
                Title = "Success",
                Width = 350,
                Height = 120,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false,
                Content = new StackPanel
                {
                    Margin = new Avalonia.Thickness(15),
                    Children =
                    {
                        new TextBlock { Text = msg, TextWrapping = Avalonia.Media.TextWrapping.Wrap },
                        new Button { Content = "OK", HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center, Margin = new Avalonia.Thickness(0,15,0,0) }
                    }
                }
            };
            dialog.ShowDialog((Window)VisualRoot);
        }
    }
}
