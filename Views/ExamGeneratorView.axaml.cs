using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Primitives;
using Avalonia.Platform.Storage;
using ExamReady.Data;
using ExamReady.Models;
using ExamReady.Utils;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ExamReady.Views
{
    public partial class ExamGeneratorView : UserControl
    {
        private readonly DbConnection _db;
        private readonly ExamAlgorithm _algorithm;
        private ObservableCollection<ExamQuestion> _selectedQuestions;

        public ExamGeneratorView()
        {
            InitializeComponent();
            _db = new DbConnection();
            _algorithm = new ExamAlgorithm();
            _selectedQuestions = new ObservableCollection<ExamQuestion>();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object? sender, RoutedEventArgs e)
        {
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            try
            {
                var subjects = _db.GetDistinctSubjects();
                CmbSubject.Items.Clear();
                foreach (var s in subjects)
                {
                    CmbSubject.Items.Add(new ComboBoxItem { Content = s });
                }
                if (CmbSubject.Items.Count > 0)
                    CmbSubject.SelectedIndex = 0;
            }
            catch (System.Exception ex)
            {
                ShowError($"Error loading subjects: {ex.Message}");
            }
        }

        private void OnGenerateClick(object? sender, RoutedEventArgs e)
        {
            try
            {
                if (CmbSubject.SelectedItem is not ComboBoxItem subjectItem)
                {
                    ShowError("Select a subject.");
                    return;
                }

                string subject = subjectItem.Content?.ToString() ?? "";
                int totalMarks = (int)(NumTotalMarks.Value ?? 50);
                double easy = (double)(NumEasy.Value ?? 30);
                double medium = (double)(NumMedium.Value ?? 40);
                double hard = (double)(NumHard.Value ?? 30);

                if (easy + medium + hard != 100)
                {
                    ShowWarning("Distribution should total 100%.");
                }

                var questions = _algorithm.GenerateExam(totalMarks, subject, easy, medium, hard);

                _selectedQuestions.Clear();
                int qNum = 1;
                foreach (var q in questions)
                {
                    _selectedQuestions.Add(new ExamQuestion
                    {
                        QuestionNumber = qNum++,
                        QuestionText = q.QuestionText,
                        QType = q.QType,
                        Difficulty = q.Difficulty,
                        Marks = q.Marks
                    });
                }

                PreviewGrid.ItemsSource = _selectedQuestions;

                int total = _selectedQuestions.Sum(q => q.Marks);
                TxtSelectedMarks.Text = total.ToString();
                TxtQuestionCount.Text = $"({_selectedQuestions.Count} questions)";

                BtnPrint.IsEnabled = _selectedQuestions.Count > 0;
                BtnExport.IsEnabled = _selectedQuestions.Count > 0;

                if (_selectedQuestions.Count == 0)
                {
                    ShowWarning("No questions generated. Check your criteria.");
                }
            }
            catch (System.Exception ex)
            {
                ShowError($"Error generating exam: {ex.Message}");
            }
        }

        private void OnPrintClick(object? sender, RoutedEventArgs e)
        {
            if (_selectedQuestions.Count == 0) return;

            string subject = (CmbSubject.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
            int totalMarks = _selectedQuestions.Sum(q => q.Marks);

            var output = $"EXAM-READY\n";
            output += $"Subject: {subject}\n";
            output += $"Date: {System.DateTime.Now:yyyy-MM-dd}\n";
            output += $"Total Marks: {totalMarks}\n";
            output += new string('-', 40) + "\n\n";

            foreach (var q in _selectedQuestions)
            {
                output += $"{q.QuestionNumber}. {q.QuestionText} ({q.Marks} marks)\n";
                output += $"   Type: {q.QType} | Difficulty: {q.Difficulty}\n\n";
            }

            var textWindow = new Window
            {
                Title = "Exam Paper Preview",
                Width = 600,
                Height = 500,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Content = new ScrollViewer
                {
                    Content = new TextBox
                    {
                        Text = output,
                        IsReadOnly = true,
                        AcceptsReturn = true,
                        FontFamily = new Avalonia.Media.FontFamily("Consolas")
                    }
                }
            };
            textWindow.ShowDialog((Window)VisualRoot);
        }

        private async void OnExportPdfClick(object? sender, RoutedEventArgs e)
        {
            if (_selectedQuestions.Count == 0)
            {
                ShowWarning("Generate an exam before exporting PDF.");
                return;
            }

            try
            {
                var topLevel = TopLevel.GetTopLevel(this);
                if (topLevel?.StorageProvider is null)
                {
                    ShowError("Cannot access file system to save the PDF.");
                    return;
                }

                string subject = (CmbSubject.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Exam";
                string safeSubject = SanitizeFileName(subject);

                var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
                {
                    Title = "Export Exam PDF",
                    SuggestedFileName = $"Exam_{safeSubject}_{System.DateTime.Now:yyyyMMdd_HHmm}.pdf",
                    DefaultExtension = "pdf",
                    ShowOverwritePrompt = true,
                    FileTypeChoices = new[]
                    {
                        new FilePickerFileType("PDF Document")
                        {
                            Patterns = new[] { "*.pdf" },
                            MimeTypes = new[] { "application/pdf" }
                        }
                    }
                });

                if (file is null)
                    return;

                await using var stream = await file.OpenWriteAsync();
                WritePdf(stream, subject);

                ShowSuccess($"PDF exported successfully to:\n{file.Path.LocalPath}");
            }
            catch (System.Exception ex)
            {
                ShowError($"Error exporting PDF: {ex.Message}");
            }
        }

        private void WritePdf(Stream output, string subject)
        {
            PdfFontResolver.EnsureConfigured();

            using var document = new PdfDocument();
            document.Info.Title = $"Exam - {subject}";
            document.Info.Subject = subject;

            var page = document.AddPage();
            page.Size = PdfSharpCore.PageSize.A4;
            var gfx = XGraphics.FromPdfPage(page);

            var titleFont = new XFont("ExamReadySans", 16, XFontStyle.Bold);
            var headingFont = new XFont("ExamReadySans", 11, XFontStyle.Bold);
            var bodyFont = new XFont("ExamReadySans", 11, XFontStyle.Regular);

            const double margin = 40;
            double y = margin;

            void NewPage()
            {
                gfx.Dispose();
                page = document.AddPage();
                page.Size = PdfSharpCore.PageSize.A4;
                gfx = XGraphics.FromPdfPage(page);
                y = margin;
            }

            void EnsureSpace(double neededHeight)
            {
                if (y + neededHeight <= page.Height - margin)
                    return;

                NewPage();
            }

            void DrawLine(string text, XFont font, double lineHeight)
            {
                EnsureSpace(lineHeight);
                gfx.DrawString(text, font, XBrushes.Black, new XRect(margin, y, page.Width - (margin * 2), lineHeight), XStringFormats.TopLeft);
                y += lineHeight;
            }

            void DrawWrapped(string text, XFont font, double lineHeight)
            {
                foreach (var line in WrapText(gfx, text, font, page.Width - (margin * 2)))
                {
                    DrawLine(line, font, lineHeight);
                }
            }

            DrawLine("Exam-Ready", titleFont, 24);
            DrawLine($"Subject: {subject}", headingFont, 18);
            DrawLine($"Date: {System.DateTime.Now:yyyy-MM-dd}", bodyFont, 16);
            DrawLine($"Total Marks: {_selectedQuestions.Sum(q => q.Marks)}", bodyFont, 16);
            DrawLine(string.Empty, bodyFont, 10);

            foreach (var q in _selectedQuestions)
            {
                DrawWrapped($"{q.QuestionNumber}. {q.QuestionText}", bodyFont, 16);
                DrawLine($"Type: {q.QType}   Difficulty: {q.Difficulty}   Marks: {q.Marks}", bodyFont, 16);
                DrawLine(string.Empty, bodyFont, 8);
            }

            document.Save(output, false);
        }

        private static List<string> WrapText(XGraphics gfx, string text, XFont font, double maxWidth)
        {
            var lines = new List<string>();
            if (string.IsNullOrWhiteSpace(text))
            {
                lines.Add(string.Empty);
                return lines;
            }

            var paragraphs = text.Replace("\r", string.Empty).Split('\n');
            foreach (var paragraph in paragraphs)
            {
                var words = paragraph.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                if (words.Length == 0)
                {
                    lines.Add(string.Empty);
                    continue;
                }

                var current = words[0];
                for (int i = 1; i < words.Length; i++)
                {
                    var candidate = $"{current} {words[i]}";
                    if (gfx.MeasureString(candidate, font).Width <= maxWidth)
                    {
                        current = candidate;
                    }
                    else
                    {
                        lines.Add(current);
                        current = words[i];
                    }
                }

                lines.Add(current);
            }

            return lines;
        }

        private static string SanitizeFileName(string value)
        {
            var invalid = Path.GetInvalidFileNameChars();
            var cleaned = new string(value.Select(c => invalid.Contains(c) ? '_' : c).ToArray()).Trim();
            return string.IsNullOrWhiteSpace(cleaned) ? "Exam" : cleaned;
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

        private void ShowWarning(string msg)
        {
            var dialog = new Window
            {
                Title = "Warning",
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
                Width = 400,
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

        private void ShowInfo(string msg)
        {
            var dialog = new Window
            {
                Title = "Info",
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

    public class ExamQuestion
    {
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; } = "";
        public string QType { get; set; } = "";
        public string Difficulty { get; set; } = "";
        public int Marks { get; set; }
    }
}
