namespace ExamReady.Forms
{
    partial class ExamGeneratorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label lblTotalMarks;
        private System.Windows.Forms.NumericUpDown numTotalMarks;
        private System.Windows.Forms.Label lblEasy;
        private System.Windows.Forms.NumericUpDown numEasy;
        private System.Windows.Forms.Label lblMedium;
        private System.Windows.Forms.NumericUpDown numMedium;
        private System.Windows.Forms.Label lblHard;
        private System.Windows.Forms.NumericUpDown numHard;
        private System.Windows.Forms.Label lblDistribution;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblSelectedMarks;
        private System.Windows.Forms.Label lblSelectedMarksValue;

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
            this.panelConfig = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblDistribution = new System.Windows.Forms.Label();
            this.numHard = new System.Windows.Forms.NumericUpDown();
            this.lblHard = new System.Windows.Forms.Label();
            this.numMedium = new System.Windows.Forms.NumericUpDown();
            this.lblMedium = new System.Windows.Forms.Label();
            this.numEasy = new System.Windows.Forms.NumericUpDown();
            this.lblEasy = new System.Windows.Forms.Label();
            this.numTotalMarks = new System.Windows.Forms.NumericUpDown();
            this.lblTotalMarks = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblSelectedMarksValue = new System.Windows.Forms.Label();
            this.lblSelectedMarks = new System.Windows.Forms.Label();
            this.panelConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMedium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEasy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalMarks)).BeginInit();
            this.panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelConfig
            // 
            this.panelConfig.BackColor = System.Drawing.Color.LightGray;
            this.panelConfig.Controls.Add(this.btnGenerate);
            this.panelConfig.Controls.Add(this.lblDistribution);
            this.panelConfig.Controls.Add(this.numHard);
            this.panelConfig.Controls.Add(this.lblHard);
            this.panelConfig.Controls.Add(this.numMedium);
            this.panelConfig.Controls.Add(this.lblMedium);
            this.panelConfig.Controls.Add(this.numEasy);
            this.panelConfig.Controls.Add(this.lblEasy);
            this.panelConfig.Controls.Add(this.numTotalMarks);
            this.panelConfig.Controls.Add(this.lblTotalMarks);
            this.panelConfig.Controls.Add(this.cmbSubject);
            this.panelConfig.Controls.Add(this.lblSubject);
            this.panelConfig.Location = new System.Drawing.Point(12, 12);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(776, 150);
            this.panelConfig.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.Location = new System.Drawing.Point(620, 105);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(140, 35);
            this.btnGenerate.TabIndex = 11;
            this.btnGenerate.Text = "Generate Exam";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // lblDistribution
            // 
            this.lblDistribution.AutoSize = true;
            this.lblDistribution.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDistribution.Location = new System.Drawing.Point(15, 75);
            this.lblDistribution.Name = "lblDistribution";
            this.lblDistribution.Size = new System.Drawing.Size(140, 15);
            this.lblDistribution.TabIndex = 10;
            this.lblDistribution.Text = "Difficulty Distribution (%):";
            // 
            // numHard
            // 
            this.numHard.Location = new System.Drawing.Point(470, 105);
            this.numHard.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numHard.Name = "numHard";
            this.numHard.Size = new System.Drawing.Size(60, 23);
            this.numHard.TabIndex = 9;
            this.numHard.Value = 30;
            // 
            // lblHard
            // 
            this.lblHard.AutoSize = true;
            this.lblHard.Location = new System.Drawing.Point(400, 108);
            this.lblHard.Name = "lblHard";
            this.lblHard.Size = new System.Drawing.Size(38, 15);
            this.lblHard.TabIndex = 8;
            this.lblHard.Text = "Hard:";
            // 
            // numMedium
            // 
            this.numMedium.Location = new System.Drawing.Point(300, 105);
            this.numMedium.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numMedium.Name = "numMedium";
            this.numMedium.Size = new System.Drawing.Size(60, 23);
            this.numMedium.TabIndex = 7;
            this.numMedium.Value = 40;
            // 
            // lblMedium
            // 
            this.lblMedium.AutoSize = true;
            this.lblMedium.Location = new System.Drawing.Point(230, 108);
            this.lblMedium.Name = "lblMedium";
            this.lblMedium.Size = new System.Drawing.Size(52, 15);
            this.lblMedium.TabIndex = 6;
            this.lblMedium.Text = "Medium:";
            // 
            // numEasy
            // 
            this.numEasy.Location = new System.Drawing.Point(130, 105);
            this.numEasy.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numEasy.Name = "numEasy";
            this.numEasy.Size = new System.Drawing.Size(60, 23);
            this.numEasy.TabIndex = 5;
            this.numEasy.Value = 30;
            // 
            // lblEasy
            // 
            this.lblEasy.AutoSize = true;
            this.lblEasy.Location = new System.Drawing.Point(60, 108);
            this.lblEasy.Name = "lblEasy";
            this.lblEasy.Size = new System.Drawing.Size(32, 15);
            this.lblEasy.TabIndex = 4;
            this.lblEasy.Text = "Easy:";
            // 
            // numTotalMarks
            // 
            this.numTotalMarks.Location = new System.Drawing.Point(130, 40);
            this.numTotalMarks.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numTotalMarks.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numTotalMarks.Name = "numTotalMarks";
            this.numTotalMarks.Size = new System.Drawing.Size(100, 23);
            this.numTotalMarks.TabIndex = 3;
            this.numTotalMarks.Value = 50;
            // 
            // lblTotalMarks
            // 
            this.lblTotalMarks.AutoSize = true;
            this.lblTotalMarks.Location = new System.Drawing.Point(15, 43);
            this.lblTotalMarks.Name = "lblTotalMarks";
            this.lblTotalMarks.Size = new System.Drawing.Size(75, 15);
            this.lblTotalMarks.TabIndex = 2;
            this.lblTotalMarks.Text = "Total Marks:";
            // 
            // cmbSubject
            // 
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(130, 10);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(250, 23);
            this.cmbSubject.TabIndex = 1;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(15, 13);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(51, 15);
            this.lblSubject.TabIndex = 0;
            this.lblSubject.Text = "Subject:";
            // 
            // panelPreview
            // 
            this.panelPreview.BackColor = System.Drawing.Color.White;
            this.panelPreview.Controls.Add(this.dgvPreview);
            this.panelPreview.Location = new System.Drawing.Point(12, 168);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(776, 300);
            this.panelPreview.TabIndex = 1;
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreview.BackgroundColor = System.Drawing.Color.White;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Location = new System.Drawing.Point(3, 3);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreview.Size = new System.Drawing.Size(770, 294);
            this.dgvPreview.TabIndex = 0;
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelActions.Controls.Add(this.btnPrint);
            this.panelActions.Controls.Add(this.lblSelectedMarksValue);
            this.panelActions.Controls.Add(this.lblSelectedMarks);
            this.panelActions.Location = new System.Drawing.Point(12, 474);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(776, 50);
            this.panelActions.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Location = new System.Drawing.Point(620, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(140, 28);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print / Export PDF";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // lblSelectedMarksValue
            // 
            this.lblSelectedMarksValue.AutoSize = true;
            this.lblSelectedMarksValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectedMarksValue.Location = new System.Drawing.Point(250, 18);
            this.lblSelectedMarksValue.Name = "lblSelectedMarksValue";
            this.lblSelectedMarksValue.Size = new System.Drawing.Size(14, 15);
            this.lblSelectedMarksValue.TabIndex = 1;
            this.lblSelectedMarksValue.Text = "0";
            // 
            // lblSelectedMarks
            // 
            this.lblSelectedMarks.AutoSize = true;
            this.lblSelectedMarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelectedMarks.Location = new System.Drawing.Point(15, 18);
            this.lblSelectedMarks.Name = "lblSelectedMarks";
            this.lblSelectedMarks.Size = new System.Drawing.Size(230, 15);
            this.lblSelectedMarks.TabIndex = 0;
            this.lblSelectedMarks.Text = "Total Marks of Selected Questions:";
            // 
            // ExamGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 536);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.panelConfig);
            this.Name = "ExamGeneratorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exam Generator";
            this.Load += new System.EventHandler(this.ExamGeneratorForm_Load);
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMedium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEasy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalMarks)).EndInit();
            this.panelPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.panelActions.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
