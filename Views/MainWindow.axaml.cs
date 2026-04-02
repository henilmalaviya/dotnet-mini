using Avalonia.Controls;
using Avalonia.Interactivity;
using ExamReady.Data;

namespace ExamReady.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object? sender, RoutedEventArgs e)
        {
            try
            {
                var db = new DbConnection();
                db.InitializeDatabase();
                StatusText.Text = "Database connected - Ready";
            }
            catch (System.Exception ex)
            {
                StatusText.Text = $"Error: {ex.Message}";
            }
        }

        private void OnExitClick(object? sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnQuestionsClick(object? sender, RoutedEventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void OnGenerateExamClick(object? sender, RoutedEventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }

        private void OnAboutClick(object? sender, RoutedEventArgs e)
        {
            var dialog = new Window
            {
                Title = "About Exam-Ready",
                Width = 400,
                Height = 200,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false,
                Content = new StackPanel
                {
                    Margin = new Avalonia.Thickness(20),
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                    Children =
                    {
                        new TextBlock
                        {
                            Text = "Exam-Ready v1.0",
                            FontSize = 24,
                            FontWeight = Avalonia.Media.FontWeight.Bold,
                            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
                        },
                        new TextBlock
                        {
                            Text = "Question Bank & Exam Generator",
                            Margin = new Avalonia.Thickness(0, 10, 0, 0),
                            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
                        },
                        new TextBlock
                        {
                            Text = "Built with Avalonia UI + SQLite",
                            Margin = new Avalonia.Thickness(0, 20, 0, 0),
                            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
                        }
                    }
                }
            };
            dialog.ShowDialog(this);
        }
    }
}
