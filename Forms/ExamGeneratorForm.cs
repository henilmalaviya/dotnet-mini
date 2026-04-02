using System.Data;
using System.Windows.Forms;
using ExamReady.Data;
using ExamReady.Models;
using ExamReady.Utils;
using ExamReady.Reports;

namespace ExamReady.Forms
{
    public partial class ExamGeneratorForm : Form
    {
        private readonly DbConnection _dbConnection;
        private readonly ExamAlgorithm _examAlgorithm;
        private List<Question> _selectedQuestions;

        public ExamGeneratorForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
            _examAlgorithm = new ExamAlgorithm();
            _selectedQuestions = new List<Question>();
        }

        private void ExamGeneratorForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                LoadSubjects();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubjects()
        {
            try
            {
                var subjects = _dbConnection.GetDistinctSubjects();
                cmbSubject.Items.Clear();
                foreach (var subject in subjects)
                {
                    cmbSubject.Items.Add(subject);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGenerate_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!ValidationHelper.ValidateExamGeneratorInput(numTotalMarks, cmbSubject, out string errorMessage))
                {
                    ValidationHelper.ShowError(errorMessage);
                    return;
                }

                double totalPercent = (double)(numEasy.Value + numMedium.Value + numHard.Value);
                if (totalPercent != 100)
                {
                    ValidationHelper.ShowWarning("The distribution percentages should total 100%.");
                }

                string subject = cmbSubject.SelectedItem?.ToString() ?? "";
                int totalMarks = Convert.ToInt32(numTotalMarks.Value);
                double easyPercent = (double)numEasy.Value;
                double mediumPercent = (double)numMedium.Value;
                double hardPercent = (double)numHard.Value;

                _selectedQuestions = _examAlgorithm.GenerateExam(
                    totalMarks, subject, easyPercent, mediumPercent, hardPercent);

                if (_selectedQuestions.Count == 0)
                {
                    ValidationHelper.ShowWarning("No questions available for the selected criteria.");
                    return;
                }

                DisplayQuestions();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error generating exam: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayQuestions()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Q#", typeof(int));
            table.Columns.Add("Question", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Difficulty", typeof(string));
            table.Columns.Add("Marks", typeof(int));

            int qNum = 1;
            foreach (var q in _selectedQuestions)
            {
                DataRow row = table.NewRow();
                row["Q#"] = qNum++;
                row["Question"] = q.QuestionText;
                row["Type"] = q.QType;
                row["Difficulty"] = q.Difficulty;
                row["Marks"] = q.Marks;
                table.Rows.Add(row);
            }

            dgvPreview.DataSource = table;
            
            int totalSelectedMarks = _selectedQuestions.Sum(q => q.Marks);
            lblSelectedMarksValue.Text = totalSelectedMarks.ToString();
            btnPrint.Enabled = _selectedQuestions.Count > 0;
        }

        private void BtnPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (_selectedQuestions.Count == 0)
                {
                    ValidationHelper.ShowWarning("No questions to print.");
                    return;
                }

                string subject = cmbSubject.SelectedItem?.ToString() ?? "";
                int totalMarks = Convert.ToInt32(numTotalMarks.Value);
                int actualMarks = _selectedQuestions.Sum(q => q.Marks);

                ExamReportForm reportForm = new ExamReportForm(
                    _selectedQuestions, 
                    subject, 
                    totalMarks,
                    actualMarks);
                reportForm.ShowDialog();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
