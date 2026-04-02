namespace ExamReady.Reports
{
    partial class ExamReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblTotalMarks;
        private System.Windows.Forms.Label lblQuestionCount;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblTotalMarks = new System.Windows.Forms.Label();
            this.lblQuestionCount = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblHeader.Location = new System.Drawing.Point(12, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(576, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Exam Paper Generated";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubject
            // 
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSubject.Location = new System.Drawing.Point(12, 60);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(576, 25);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "Subject: ";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalMarks
            // 
            this.lblTotalMarks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalMarks.Location = new System.Drawing.Point(12, 90);
            this.lblTotalMarks.Name = "lblTotalMarks";
            this.lblTotalMarks.Size = new System.Drawing.Size(576, 25);
            this.lblTotalMarks.TabIndex = 2;
            this.lblTotalMarks.Text = "Total Marks: ";
            this.lblTotalMarks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuestionCount
            // 
            this.lblQuestionCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQuestionCount.Location = new System.Drawing.Point(12, 120);
            this.lblQuestionCount.Name = "lblQuestionCount";
            this.lblQuestionCount.Size = new System.Drawing.Size(576, 25);
            this.lblQuestionCount.TabIndex = 3;
            this.lblQuestionCount.Text = "Questions: ";
            this.lblQuestionCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Controls.Add(this.btnExportPdf);
            this.panelButtons.Controls.Add(this.btnPrint);
            this.panelButtons.Location = new System.Drawing.Point(12, 160);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(576, 50);
            this.panelButtons.TabIndex = 4;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(0, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 30);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.Location = new System.Drawing.Point(130, 12);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(120, 30);
            this.btnExportPdf.TabIndex = 1;
            this.btnExportPdf.Text = "Export PDF";
            this.btnExportPdf.UseVisualStyleBackColor = true;
            this.btnExportPdf.Click += new System.EventHandler(this.BtnExportPdf_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(440, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ExamReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 230);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.lblQuestionCount);
            this.Controls.Add(this.lblTotalMarks);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ExamReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exam Report";
            this.Load += new System.EventHandler(this.ExamReportForm_Load);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
