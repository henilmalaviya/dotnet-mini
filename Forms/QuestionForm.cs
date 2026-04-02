using System.Data;
using System.Windows.Forms;
using ExamReady.Data;
using ExamReady.Models;
using ExamReady.Utils;

namespace ExamReady.Forms
{
    public partial class QuestionForm : Form
    {
        private readonly DbConnection _dbConnection;
        private readonly QuestionRepository _repository;
        private DataSet _dataSet;
        private int _currentId = 0;

        public QuestionForm()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
            _repository = new QuestionRepository();
        }

        private void QuestionForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                LoadSubjects();
                LoadQuestions();
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
                cmbFilterSubject.Items.Clear();
                cmbFilterSubject.Items.Add("");
                foreach (var subject in subjects)
                {
                    cmbFilterSubject.Items.Add(subject);
                }
                cmbFilterSubject.SelectedIndex = 0;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadQuestions(string? filterSubject = null)
        {
            try
            {
                _dataSet = _repository.GetQuestionsDataSet(filterSubject);
                dgvQuestions.DataSource = _dataSet.Tables["tblQuestions"];
                
                if (dgvQuestions.Columns.Count > 0)
                {
                    dgvQuestions.Columns["ID"].HeaderText = "ID";
                    dgvQuestions.Columns["Subject"].HeaderText = "Subject";
                    dgvQuestions.Columns["QuestionText"].HeaderText = "Question";
                    dgvQuestions.Columns["QType"].HeaderText = "Type";
                    dgvQuestions.Columns["Difficulty"].HeaderText = "Difficulty";
                    dgvQuestions.Columns["Marks"].HeaderText = "Marks";
                    dgvQuestions.Columns["CreatedAt"].HeaderText = "Created";
                    
                    dgvQuestions.Columns["OptionA"].Visible = false;
                    dgvQuestions.Columns["OptionB"].Visible = false;
                    dgvQuestions.Columns["OptionC"].Visible = false;
                    dgvQuestions.Columns["OptionD"].Visible = false;
                    dgvQuestions.Columns["CorrectAnswer"].Visible = false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error loading questions: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbQType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            panelMCQ.Visible = cmbQType.SelectedItem?.ToString() == "MCQ";
        }

        private void DgvQuestions_SelectionChanged(object sender, System.EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count > 0)
            {
                var row = dgvQuestions.SelectedRows[0];
                _currentId = Convert.ToInt32(row.Cells["ID"].Value);
                txtSubject.Text = row.Cells["Subject"].Value.ToString() ?? "";
                txtQuestionText.Text = row.Cells["QuestionText"].Value.ToString() ?? "";
                cmbQType.SelectedItem = row.Cells["QType"].Value?.ToString();
                cmbDifficulty.SelectedItem = row.Cells["Difficulty"].Value?.ToString();
                numMarks.Value = Convert.ToInt32(row.Cells["Marks"].Value);

                if (row.Cells["QType"].Value?.ToString() == "MCQ")
                {
                    panelMCQ.Visible = true;
                    txtOptionA.Text = row.Cells["OptionA"].Value?.ToString() ?? "";
                    txtOptionB.Text = row.Cells["OptionB"].Value?.ToString() ?? "";
                    txtOptionC.Text = row.Cells["OptionC"].Value?.ToString() ?? "";
                    txtOptionD.Text = row.Cells["OptionD"].Value?.ToString() ?? "";
                    cmbCorrectAnswer.SelectedItem = row.Cells["CorrectAnswer"].Value?.ToString();
                }
                else
                {
                    panelMCQ.Visible = false;
                }
            }
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!ValidationHelper.ValidateQuestionInput(txtQuestionText, cmbQType, cmbDifficulty, numMarks, out string errorMessage))
                {
                    ValidationHelper.ShowError(errorMessage);
                    return;
                }

                Question question = QuestionFactory.CreateQuestion(cmbQType.SelectedItem?.ToString() ?? "");
                
                question.Subject = txtSubject.Text.Trim();
                question.QuestionText = txtQuestionText.Text.Trim();
                question.QType = cmbQType.SelectedItem?.ToString() ?? "";
                question.Difficulty = cmbDifficulty.SelectedItem?.ToString() ?? "";
                question.Marks = Convert.ToInt32(numMarks.Value);

                if (question is MCQQuestion mcq)
                {
                    mcq.OptionA = txtOptionA.Text.Trim();
                    mcq.OptionB = txtOptionB.Text.Trim();
                    mcq.OptionC = txtOptionC.Text.Trim();
                    mcq.OptionD = txtOptionD.Text.Trim();
                    mcq.CorrectAnswer = cmbCorrectAnswer.SelectedItem?.ToString() ?? "";
                }

                _dbConnection.InsertQuestion(question);
                ValidationHelper.ShowSuccess("Question added successfully!");
                ClearForm();
                LoadQuestions();
                LoadSubjects();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error adding question: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (_currentId == 0)
                {
                    ValidationHelper.ShowError("Please select a question to update.");
                    return;
                }

                if (!ValidationHelper.ValidateQuestionInput(txtQuestionText, cmbQType, cmbDifficulty, numMarks, out string errorMessage))
                {
                    ValidationHelper.ShowError(errorMessage);
                    return;
                }

                Question question = QuestionFactory.CreateQuestion(cmbQType.SelectedItem?.ToString() ?? "");
                
                question.ID = _currentId;
                question.Subject = txtSubject.Text.Trim();
                question.QuestionText = txtQuestionText.Text.Trim();
                question.QType = cmbQType.SelectedItem?.ToString() ?? "";
                question.Difficulty = cmbDifficulty.SelectedItem?.ToString() ?? "";
                question.Marks = Convert.ToInt32(numMarks.Value);

                if (question is MCQQuestion mcq)
                {
                    mcq.OptionA = txtOptionA.Text.Trim();
                    mcq.OptionB = txtOptionB.Text.Trim();
                    mcq.OptionC = txtOptionC.Text.Trim();
                    mcq.OptionD = txtOptionD.Text.Trim();
                    mcq.CorrectAnswer = cmbCorrectAnswer.SelectedItem?.ToString() ?? "";
                }

                _dbConnection.UpdateQuestion(question);
                ValidationHelper.ShowSuccess("Question updated successfully!");
                ClearForm();
                LoadQuestions();
                LoadSubjects();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error updating question: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (_currentId == 0)
                {
                    ValidationHelper.ShowError("Please select a question to delete.");
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this question?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _dbConnection.DeleteQuestion(_currentId);
                    ValidationHelper.ShowSuccess("Question deleted successfully!");
                    ClearForm();
                    LoadQuestions();
                    LoadSubjects();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error deleting question: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, System.EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _currentId = 0;
            txtSubject.Text = "";
            txtQuestionText.Text = "";
            cmbQType.SelectedIndex = -1;
            cmbDifficulty.SelectedIndex = -1;
            numMarks.Value = 1;
            txtOptionA.Text = "";
            txtOptionB.Text = "";
            txtOptionC.Text = "";
            txtOptionD.Text = "";
            cmbCorrectAnswer.SelectedIndex = -1;
            panelMCQ.Visible = false;
            dgvQuestions.ClearSelection();
        }

        private void BtnFilter_Click(object sender, System.EventArgs e)
        {
            string? subject = cmbFilterSubject.SelectedItem?.ToString();
            LoadQuestions(string.IsNullOrEmpty(subject) ? null : subject);
        }

        private void BtnShowAll_Click(object sender, System.EventArgs e)
        {
            cmbFilterSubject.SelectedIndex = 0;
            LoadQuestions();
        }
    }
}
