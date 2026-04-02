namespace ExamReady.Forms
{
    partial class QuestionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvQuestions;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblQuestionText;
        private System.Windows.Forms.TextBox txtQuestionText;
        private System.Windows.Forms.Label lblQType;
        private System.Windows.Forms.ComboBox cmbQType;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.Label lblMarks;
        private System.Windows.Forms.NumericUpDown numMarks;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Panel panelMCQ;
        private System.Windows.Forms.Label lblOptionA;
        private System.Windows.Forms.TextBox txtOptionA;
        private System.Windows.Forms.Label lblOptionB;
        private System.Windows.Forms.TextBox txtOptionB;
        private System.Windows.Forms.Label lblOptionC;
        private System.Windows.Forms.TextBox txtOptionC;
        private System.Windows.Forms.Label lblOptionD;
        private System.Windows.Forms.TextBox txtOptionD;
        private System.Windows.Forms.Label lblCorrectAnswer;
        private System.Windows.Forms.ComboBox cmbCorrectAnswer;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblFilterSubject;
        private System.Windows.Forms.ComboBox cmbFilterSubject;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnShowAll;

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
            this.dgvQuestions = new System.Windows.Forms.DataGridView();
            this.panelInput = new System.Windows.Forms.Panel();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblQuestionText = new System.Windows.Forms.Label();
            this.txtQuestionText = new System.Windows.Forms.TextBox();
            this.lblQType = new System.Windows.Forms.Label();
            this.cmbQType = new System.Windows.Forms.ComboBox();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.lblMarks = new System.Windows.Forms.Label();
            this.numMarks = new System.Windows.Forms.NumericUpDown();
            this.panelMCQ = new System.Windows.Forms.Panel();
            this.cmbCorrectAnswer = new System.Windows.Forms.ComboBox();
            this.lblCorrectAnswer = new System.Windows.Forms.Label();
            this.lblOptionD = new System.Windows.Forms.Label();
            this.txtOptionD = new System.Windows.Forms.TextBox();
            this.lblOptionC = new System.Windows.Forms.Label();
            this.txtOptionC = new System.Windows.Forms.TextBox();
            this.lblOptionB = new System.Windows.Forms.Label();
            this.txtOptionB = new System.Windows.Forms.TextBox();
            this.lblOptionA = new System.Windows.Forms.Label();
            this.txtOptionA = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cmbFilterSubject = new System.Windows.Forms.ComboBox();
            this.lblFilterSubject = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.panelInput.SuspendLayout();
            this.panelMCQ.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.AllowUserToAddRows = false;
            this.dgvQuestions.AllowUserToDeleteRows = false;
            this.dgvQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuestions.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestions.Location = new System.Drawing.Point(12, 50);
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.ReadOnly = true;
            this.dgvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestions.Size = new System.Drawing.Size(776, 300);
            this.dgvQuestions.TabIndex = 0;
            this.dgvQuestions.SelectionChanged += new System.EventHandler(this.DgvQuestions_SelectionChanged);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.LightGray;
            this.panelInput.Controls.Add(this.txtSubject);
            this.panelInput.Controls.Add(this.lblSubject);
            this.panelInput.Controls.Add(this.lblQuestionText);
            this.panelInput.Controls.Add(this.txtQuestionText);
            this.panelInput.Controls.Add(this.lblQType);
            this.panelInput.Controls.Add(this.cmbQType);
            this.panelInput.Controls.Add(this.lblDifficulty);
            this.panelInput.Controls.Add(this.cmbDifficulty);
            this.panelInput.Controls.Add(this.lblMarks);
            this.panelInput.Controls.Add(this.numMarks);
            this.panelInput.Controls.Add(this.panelMCQ);
            this.panelInput.Controls.Add(this.panelButtons);
            this.panelInput.Location = new System.Drawing.Point(12, 356);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(776, 180);
            this.panelInput.TabIndex = 1;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(120, 15);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(200, 23);
            this.txtSubject.TabIndex = 0;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(15, 18);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(51, 15);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "Subject:";
            // 
            // lblQuestionText
            // 
            this.lblQuestionText.AutoSize = true;
            this.lblQuestionText.Location = new System.Drawing.Point(15, 50);
            this.lblQuestionText.Name = "lblQuestionText";
            this.lblQuestionText.Size = new System.Drawing.Size(89, 15);
            this.lblQuestionText.TabIndex = 2;
            this.lblQuestionText.Text = "Question Text:";
            // 
            // txtQuestionText
            // 
            this.txtQuestionText.Location = new System.Drawing.Point(120, 47);
            this.txtQuestionText.Multiline = true;
            this.txtQuestionText.Name = "txtQuestionText";
            this.txtQuestionText.Size = new System.Drawing.Size(400, 60);
            this.txtQuestionText.TabIndex = 3;
            // 
            // lblQType
            // 
            this.lblQType.AutoSize = true;
            this.lblQType.Location = new System.Drawing.Point(530, 18);
            this.lblQType.Name = "lblQType";
            this.lblQType.Size = new System.Drawing.Size(87, 15);
            this.lblQType.TabIndex = 4;
            this.lblQType.Text = "Question Type:";
            // 
            // cmbQType
            // 
            this.cmbQType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQType.FormattingEnabled = true;
            this.cmbQType.Items.AddRange(new object[] { "MCQ", "Descriptive" });
            this.cmbQType.Location = new System.Drawing.Point(620, 15);
            this.cmbQType.Name = "cmbQType";
            this.cmbQType.Size = new System.Drawing.Size(140, 23);
            this.cmbQType.TabIndex = 5;
            this.cmbQType.SelectedIndexChanged += new System.EventHandler(this.CmbQType_SelectedIndexChanged);
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(530, 50);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(60, 15);
            this.lblDifficulty.TabIndex = 6;
            this.lblDifficulty.Text = "Difficulty:";
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulty.FormattingEnabled = true;
            this.cmbDifficulty.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            this.cmbDifficulty.Location = new System.Drawing.Point(620, 47);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(140, 23);
            this.cmbDifficulty.TabIndex = 7;
            // 
            // lblMarks
            // 
            this.lblMarks.AutoSize = true;
            this.lblMarks.Location = new System.Drawing.Point(530, 82);
            this.lblMarks.Name = "lblMarks";
            this.lblMarks.Size = new System.Drawing.Size(42, 15);
            this.lblMarks.TabIndex = 8;
            this.lblMarks.Text = "Marks:";
            // 
            // numMarks
            // 
            this.numMarks.Location = new System.Drawing.Point(620, 80);
            this.numMarks.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numMarks.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numMarks.Name = "numMarks";
            this.numMarks.Size = new System.Drawing.Size(80, 23);
            this.numMarks.TabIndex = 9;
            this.numMarks.Value = 1;
            // 
            // panelMCQ
            // 
            this.panelMCQ.Controls.Add(this.cmbCorrectAnswer);
            this.panelMCQ.Controls.Add(this.lblCorrectAnswer);
            this.panelMCQ.Controls.Add(this.lblOptionD);
            this.panelMCQ.Controls.Add(this.txtOptionD);
            this.panelMCQ.Controls.Add(this.lblOptionC);
            this.panelMCQ.Controls.Add(this.txtOptionC);
            this.panelMCQ.Controls.Add(this.lblOptionB);
            this.panelMCQ.Controls.Add(this.txtOptionB);
            this.panelMCQ.Controls.Add(this.lblOptionA);
            this.panelMCQ.Controls.Add(this.txtOptionA);
            this.panelMCQ.Location = new System.Drawing.Point(15, 115);
            this.panelMCQ.Name = "panelMCQ";
            this.panelMCQ.Size = new System.Drawing.Size(505, 60);
            this.panelMCQ.TabIndex = 10;
            this.panelMCQ.Visible = false;
            // 
            // cmbCorrectAnswer
            // 
            this.cmbCorrectAnswer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCorrectAnswer.FormattingEnabled = true;
            this.cmbCorrectAnswer.Items.AddRange(new object[] { "A", "B", "C", "D" });
            this.cmbCorrectAnswer.Location = new System.Drawing.Point(420, 30);
            this.cmbCorrectAnswer.Name = "cmbCorrectAnswer";
            this.cmbCorrectAnswer.Size = new System.Drawing.Size(70, 23);
            this.cmbCorrectAnswer.TabIndex = 12;
            // 
            // lblCorrectAnswer
            // 
            this.lblCorrectAnswer.AutoSize = true;
            this.lblCorrectAnswer.Location = new System.Drawing.Point(320, 33);
            this.lblCorrectAnswer.Name = "lblCorrectAnswer";
            this.lblCorrectAnswer.Size = new System.Drawing.Size(94, 15);
            this.lblCorrectAnswer.TabIndex = 13;
            this.lblCorrectAnswer.Text = "Correct Answer:";
            // 
            // lblOptionD
            // 
            this.lblOptionD.AutoSize = true;
            this.lblOptionD.Location = new System.Drawing.Point(320, 5);
            this.lblOptionD.Name = "lblOptionD";
            this.lblOptionD.Size = new System.Drawing.Size(52, 15);
            this.lblOptionD.TabIndex = 10;
            this.lblOptionD.Text = "Option D:";
            // 
            // txtOptionD
            // 
            this.txtOptionD.Location = new System.Drawing.Point(380, 2);
            this.txtOptionD.Name = "txtOptionD";
            this.txtOptionD.Size = new System.Drawing.Size(110, 23);
            this.txtOptionD.TabIndex = 11;
            // 
            // lblOptionC
            // 
            this.lblOptionC.AutoSize = true;
            this.lblOptionC.Location = new System.Drawing.Point(170, 5);
            this.lblOptionC.Name = "lblOptionC";
            this.lblOptionC.Size = new System.Drawing.Size(52, 15);
            this.lblOptionC.TabIndex = 8;
            this.lblOptionC.Text = "Option C:";
            // 
            // txtOptionC
            // 
            this.txtOptionC.Location = new System.Drawing.Point(230, 2);
            this.txtOptionC.Name = "txtOptionC";
            this.txtOptionC.Size = new System.Drawing.Size(70, 23);
            this.txtOptionC.TabIndex = 9;
            // 
            // lblOptionB
            // 
            this.lblOptionB.AutoSize = true;
            this.lblOptionB.Location = new System.Drawing.Point(15, 33);
            this.lblOptionB.Name = "lblOptionB";
            this.lblOptionB.Size = new System.Drawing.Size(52, 15);
            this.lblOptionB.TabIndex = 6;
            this.lblOptionB.Text = "Option B:";
            // 
            // txtOptionB
            // 
            this.txtOptionB.Location = new System.Drawing.Point(75, 30);
            this.txtOptionB.Name = "txtOptionB";
            this.txtOptionB.Size = new System.Drawing.Size(70, 23);
            this.txtOptionB.TabIndex = 7;
            // 
            // lblOptionA
            // 
            this.lblOptionA.AutoSize = true;
            this.lblOptionA.Location = new System.Drawing.Point(15, 5);
            this.lblOptionA.Name = "lblOptionA";
            this.lblOptionA.Size = new System.Drawing.Size(52, 15);
            this.lblOptionA.TabIndex = 4;
            this.lblOptionA.Text = "Option A:";
            // 
            // txtOptionA
            // 
            this.txtOptionA.Location = new System.Drawing.Point(75, 2);
            this.txtOptionA.Name = "txtOptionA";
            this.txtOptionA.Size = new System.Drawing.Size(70, 23);
            this.txtOptionA.TabIndex = 5;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnClear);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnUpdate);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Location = new System.Drawing.Point(530, 115);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(230, 60);
            this.panelButtons.TabIndex = 11;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(170, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 28);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(110, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(55, 25);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(55, 28);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(0, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelFilter.Controls.Add(this.btnShowAll);
            this.panelFilter.Controls.Add(this.btnFilter);
            this.panelFilter.Controls.Add(this.cmbFilterSubject);
            this.panelFilter.Controls.Add(this.lblFilterSubject);
            this.panelFilter.Location = new System.Drawing.Point(12, 12);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(776, 32);
            this.panelFilter.TabIndex = 2;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(680, 5);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(90, 23);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.BtnShowAll_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(580, 5);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(90, 23);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // cmbFilterSubject
            // 
            this.cmbFilterSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterSubject.FormattingEnabled = true;
            this.cmbFilterSubject.Location = new System.Drawing.Point(180, 5);
            this.cmbFilterSubject.Name = "cmbFilterSubject";
            this.cmbFilterSubject.Size = new System.Drawing.Size(200, 23);
            this.cmbFilterSubject.TabIndex = 1;
            // 
            // lblFilterSubject
            // 
            this.lblFilterSubject.AutoSize = true;
            this.lblFilterSubject.Location = new System.Drawing.Point(15, 8);
            this.lblFilterSubject.Name = "lblFilterSubject";
            this.lblFilterSubject.Size = new System.Drawing.Size(150, 15);
            this.lblFilterSubject.TabIndex = 0;
            this.lblFilterSubject.Text = "Filter by Subject:";
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.dgvQuestions);
            this.Name = "QuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Question Management";
            this.Load += new System.EventHandler(this.QuestionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelMCQ.ResumeLayout(false);
            this.panelMCQ.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
