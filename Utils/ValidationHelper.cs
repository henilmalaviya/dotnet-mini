using System.Windows.Forms;

namespace ExamReady.Utils
{
    public static class ValidationHelper
    {
        public static bool ValidateQuestionInput(
            TextBox txtQuestionText,
            ComboBox cmbQType,
            ComboBox cmbDifficulty,
            NumericUpDown numMarks,
            out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(txtQuestionText.Text))
            {
                errorMessage = "Question text is required.";
                txtQuestionText.Focus();
                return false;
            }

            if (cmbQType.SelectedItem == null)
            {
                errorMessage = "Please select a question type.";
                cmbQType.Focus();
                return false;
            }

            if (cmbDifficulty.SelectedItem == null)
            {
                errorMessage = "Please select difficulty level.";
                cmbDifficulty.Focus();
                return false;
            }

            if (numMarks.Value <= 0)
            {
                errorMessage = "Marks must be greater than 0.";
                numMarks.Focus();
                return false;
            }

            return true;
        }

        public static bool ValidateExamGeneratorInput(
            NumericUpDown numTotalMarks,
            ComboBox cmbSubject,
            out string errorMessage)
        {
            errorMessage = "";

            if (numTotalMarks.Value <= 0)
            {
                errorMessage = "Total marks must be greater than 0.";
                numTotalMarks.Focus();
                return false;
            }

            if (cmbSubject.SelectedItem == null || string.IsNullOrWhiteSpace(cmbSubject.Text))
            {
                errorMessage = "Please select a subject.";
                cmbSubject.Focus();
                return false;
            }

            return true;
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
