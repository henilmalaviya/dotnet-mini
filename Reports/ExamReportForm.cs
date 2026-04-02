using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using ExamReady.Models;

namespace ExamReady.Reports
{
    public partial class ExamReportForm : Form
    {
        private List<Question> _questions;
        private string _subject;
        private int _requestedMarks;
        private int _actualMarks;
        private PrintDocument _printDocument;
        private int _currentPage;
        private int _questionsPerPage = 10;

        public ExamReportForm(List<Question> questions, string subject, int requestedMarks, int actualMarks)
        {
            InitializeComponent();
            _questions = questions;
            _subject = subject;
            _requestedMarks = requestedMarks;
            _actualMarks = actualMarks;
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void ExamReportForm_Load(object sender, System.EventArgs e)
        {
            lblSubject.Text = _subject;
            lblTotalMarks.Text = $"Requested: {_requestedMarks} | Actual: {_actualMarks}";
            lblQuestionCount.Text = $"Total Questions: {_questions.Count}";
        }

        private void BtnPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = _printDocument;
                
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    _currentPage = 0;
                    _printDocument.Print();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Print error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportPdf_Click(object sender, System.EventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PDF Files|*.pdf";
                saveFile.FileName = $"Exam_{_subject}_{DateTime.Now:yyyyMMdd}";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    ExportToPdf(saveFile.FileName);
                    MessageBox.Show("PDF exported successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Export error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToPdf(string filePath)
        {
            var pdfDocument = new PdfSharp.Pdf.PdfDocument();
            pdfDocument.Info.Title = $"Exam Paper - {_subject}";
            pdfDocument.Info.Author = "Exam-Ready";

            var page = pdfDocument.AddPage();
            page.Size = PdfSharp.Pdf.PdfPageSize.A4;
            
            var gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
            int yPos = 40;
            int lineHeight = 20;

            var titleFont = new PdfSharp.Drawing.XFont("Arial", 18, PdfSharp.Drawing.XFontStyle.Bold);
            var headerFont = new PdfSharp.Drawing.XFont("Arial", 12, PdfSharp.Drawing.XFontStyle.Bold);
            var normalFont = new PdfSharp.Drawing.XFont("Arial", 10, PdfSharp.Drawing.XFontStyle.Regular);

            gfx.DrawString("EXAM-READY", titleFont, PdfSharp.Drawing.XBrushes.DarkBlue, 
                new PdfSharp.Drawing.XRect(0, yPos, page.Width, 30), PdfSharp.Drawing.XStringFormats.TopCenter);
            yPos += 40;

            gfx.DrawString($"Subject: {_subject}", headerFont, PdfSharp.Drawing.XBrushes.Black, 
                new PdfSharp.Drawing.XRect(40, yPos, page.Width - 80, 20), PdfSharp.Drawing.XStringFormats.TopLeft);
            yPos += lineHeight;

            gfx.DrawString($"Date: {DateTime.Now:yyyy-MM-dd}", normalFont, PdfSharp.Drawing.XBrushes.Black, 
                new PdfSharp.Drawing.XRect(40, yPos, page.Width - 80, 20), PdfSharp.Drawing.XStringFormats.TopLeft);
            yPos += lineHeight;

            gfx.DrawString($"Total Marks: {_actualMarks}", headerFont, PdfSharp.Drawing.XBrushes.Black, 
                new PdfSharp.Drawing.XRect(40, yPos, page.Width - 80, 20), PdfSharp.Drawing.XStringFormats.TopLeft);
            yPos += 30;

            gfx.DrawString(new string('-', 60), normalFont, PdfSharp.Drawing.XBrushes.Gray, 
                new PdfSharp.Drawing.XRect(40, yPos, page.Width - 80, 20), PdfSharp.Drawing.XStringFormats.TopLeft);
            yPos += 20;

            int qNum = 1;
            foreach (var q in _questions)
            {
                if (yPos > page.Height - 50)
                {
                    page = pdfDocument.AddPage();
                    page.Size = PdfSharp.Pdf.PdfPageSize.A4;
                    gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                    yPos = 40;
                }

                string questionText = $"{qNum}. {q.QuestionText} ({q.Marks} marks)";
                gfx.DrawString(questionText, normalFont, PdfSharp.Drawing.XBrushes.Black, 
                    new PdfSharp.Drawing.XRect(40, yPos, page.Width - 80, 20), PdfSharp.Drawing.XStringFormats.TopLeft);
                yPos += lineHeight;

                if (q is MCQQuestion mcq)
                {
                    gfx.DrawString($"   A) {mcq.OptionA}", normalFont, PdfSharp.Drawing.XBrushes.Black, 
                        new PdfSharp.Drawing.XRect(50, yPos, page.Width - 90, 20), PdfSharp.Drawing.XStringFormats.TopLeft);
                    yPos += lineHeight;
                    gfx.DrawString($"   B) {mcq.OptionB}", normalFont, PdfSharp.Drawing.XBrushes.Black, 
                        new PdfSharp.Drawing.XRect(50, yPos, page.Width - 90, 20), PdfSharp.Drawing.XStringFormats.TopLeft);
                    yPos += lineHeight;
                    gfx.DrawString($"   C) {mcq.OptionC}", normalFont, PdfSharp.Drawing.XBrushes.Black, 
                        new PdfSharp.Drawing.XRect(50, yPos, page.Width - 90, 20), PdfSharp.Drawing.XStringFormats.TopLeft);
                    yPos += lineHeight;
                    gfx.DrawString($"   D) {mcq.OptionD}", normalFont, PdfSharp.Drawing.XBrushes.Black, 
                        new PdfSharp.Drawing.XRect(50, yPos, page.Width - 90, 20), PdfSharp.Drawing.XStringFormats.TopLeft);
                    yPos += lineHeight;
                }

                yPos += 10;
                qNum++;
            }

            pdfDocument.Save(filePath);
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 10, FontStyle.Regular);

            int yPos = 40;

            gfx.DrawString("EXAM-READY", titleFont, Brushes.DarkBlue, 
                new RectangleF(0, yPos, e.MarginBounds.Width, 30), new StringFormat { Alignment = StringAlignment.Center });
            yPos += 40;

            gfx.DrawString($"Subject: {_subject}", headerFont, Brushes.Black, 40, yPos);
            yPos += 20;

            gfx.DrawString($"Date: {DateTime.Now:yyyy-MM-dd}", normalFont, Brushes.Black, 40, yPos);
            yPos += 20;

            gfx.DrawString($"Total Marks: {_actualMarks}", headerFont, Brushes.Black, 40, yPos);
            yPos += 30;

            gfx.DrawLine(Pens.Gray, 40, yPos, e.MarginBounds.Width - 40, yPos);
            yPos += 20;

            int startIndex = _currentPage * _questionsPerPage;
            int endIndex = Math.Min(startIndex + _questionsPerPage, _questions.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                var q = _questions[i];
                string questionText = $"{i + 1}. {q.QuestionText} ({q.Marks} marks)";
                gfx.DrawString(questionText, normalFont, Brushes.Black, 40, yPos);
                yPos += 20;

                if (q is MCQQuestion mcq)
                {
                    gfx.DrawString($"   A) {mcq.OptionA}", normalFont, Brushes.Black, 50, yPos);
                    yPos += 15;
                    gfx.DrawString($"   B) {mcq.OptionB}", normalFont, Brushes.Black, 50, yPos);
                    yPos += 15;
                    gfx.DrawString($"   C) {mcq.OptionC}", normalFont, Brushes.Black, 50, yPos);
                    yPos += 15;
                    gfx.DrawString($"   D) {mcq.OptionD}", normalFont, Brushes.Black, 50, yPos);
                    yPos += 15;
                }

                yPos += 10;
            }

            _currentPage++;
            e.HasMorePages = _currentPage * _questionsPerPage < _questions.Count;
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
