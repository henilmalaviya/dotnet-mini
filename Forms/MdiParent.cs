using System.Windows.Forms;
using ExamReady.Data;

namespace ExamReady.Forms
{
    public partial class MdiParent : Form
    {
        public MdiParent()
        {
            InitializeComponent();
        }

        private void MdiParent_Load(object sender, System.EventArgs e)
        {
            try
            {
                var db = new DbConnection();
                db.InitializeDatabase();
                toolStripStatusLabel1.Text = "Database connected - Ready";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Database initialization error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Database error";
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void QuestionsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is QuestionForm)
                {
                    child.Activate();
                    return;
                }
            }

            QuestionForm form = new QuestionForm();
            form.MdiParent = this;
            form.Show();
        }

        private void GenerateExamToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is ExamGeneratorForm)
                {
                    child.Activate();
                    return;
                }
            }

            ExamGeneratorForm form = new ExamGeneratorForm();
            form.MdiParent = this;
            form.Show();
        }

        private void AboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(
                "Exam-Ready v1.0\n\nQuestion Bank & Exam Generator\n\nDeveloped for Windows using C# .NET",
                "About Exam-Ready",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
