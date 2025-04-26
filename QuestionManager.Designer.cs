namespace COMP1551
{
    partial class QuestionManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            QuestionManagementLBL = new Label();
            databaseBindingSource = new BindingSource(components);
            quizDbContextBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            QuestionName = new Label();
            QuestionNameTextBox = new TextBox();
            MultipleCheckBox = new CheckBox();
            TrueFalseCheckBox = new CheckBox();
            OpenEndedCheckBox = new CheckBox();
            OptionALBL = new Label();
            OptionATextBox = new TextBox();
            OptionBLBL = new Label();
            OptionBTextBox = new TextBox();
            OptionCLBL = new Label();
            OptionCTextBox = new TextBox();
            OptionDLBL = new Label();
            OptionDTextBox = new TextBox();
            label1 = new Label();
            AnswerA = new CheckBox();
            AnswerB = new CheckBox();
            AnswerC = new CheckBox();
            AnswerD = new CheckBox();
            label2 = new Label();
            TrueAnswer = new CheckBox();
            FalseAnswer = new CheckBox();
            label3 = new Label();
            OpenEndedTextBox = new TextBox();
            label4 = new Label();
            CreateButton = new Button();
            UpdateButton = new Button();
            DeleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)databaseBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quizDbContextBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // QuestionManagementLBL
            // 
            QuestionManagementLBL.AutoSize = true;
            QuestionManagementLBL.Location = new Point(274, 38);
            QuestionManagementLBL.Name = "QuestionManagementLBL";
            QuestionManagementLBL.Size = new Size(160, 20);
            QuestionManagementLBL.TabIndex = 0;
            QuestionManagementLBL.Text = "Question Management";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 81);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(908, 188);
            dataGridView1.TabIndex = 1;
            // 
            // QuestionName
            // 
            QuestionName.AutoSize = true;
            QuestionName.Location = new Point(32, 290);
            QuestionName.Name = "QuestionName";
            QuestionName.Size = new Size(112, 20);
            QuestionName.TabIndex = 2;
            QuestionName.Text = "Question Name";
            // 
            // QuestionNameTextBox
            // 
            QuestionNameTextBox.Location = new Point(155, 287);
            QuestionNameTextBox.Name = "QuestionNameTextBox";
            QuestionNameTextBox.Size = new Size(510, 27);
            QuestionNameTextBox.TabIndex = 3;
            // 
            // MultipleCheckBox
            // 
            MultipleCheckBox.AutoSize = true;
            MultipleCheckBox.Location = new Point(946, 128);
            MultipleCheckBox.Name = "MultipleCheckBox";
            MultipleCheckBox.Size = new Size(86, 24);
            MultipleCheckBox.TabIndex = 4;
            MultipleCheckBox.Text = "Multiple";
            MultipleCheckBox.UseVisualStyleBackColor = true;
            // 
            // TrueFalseCheckBox
            // 
            TrueFalseCheckBox.AutoSize = true;
            TrueFalseCheckBox.Location = new Point(946, 158);
            TrueFalseCheckBox.Name = "TrueFalseCheckBox";
            TrueFalseCheckBox.Size = new Size(97, 24);
            TrueFalseCheckBox.TabIndex = 4;
            TrueFalseCheckBox.Text = "True/False";
            TrueFalseCheckBox.UseVisualStyleBackColor = true;
            // 
            // OpenEndedCheckBox
            // 
            OpenEndedCheckBox.AutoSize = true;
            OpenEndedCheckBox.Location = new Point(946, 188);
            OpenEndedCheckBox.Name = "OpenEndedCheckBox";
            OpenEndedCheckBox.Size = new Size(113, 24);
            OpenEndedCheckBox.TabIndex = 4;
            OpenEndedCheckBox.Text = "Open Ended";
            OpenEndedCheckBox.UseVisualStyleBackColor = true;
            // 
            // OptionALBL
            // 
            OptionALBL.AutoSize = true;
            OptionALBL.Location = new Point(32, 329);
            OptionALBL.Name = "OptionALBL";
            OptionALBL.Size = new Size(69, 20);
            OptionALBL.TabIndex = 2;
            OptionALBL.Text = "Option A";
            // 
            // OptionATextBox
            // 
            OptionATextBox.Location = new Point(155, 326);
            OptionATextBox.Name = "OptionATextBox";
            OptionATextBox.Size = new Size(510, 27);
            OptionATextBox.TabIndex = 3;
            // 
            // OptionBLBL
            // 
            OptionBLBL.AutoSize = true;
            OptionBLBL.Location = new Point(32, 373);
            OptionBLBL.Name = "OptionBLBL";
            OptionBLBL.Size = new Size(68, 20);
            OptionBLBL.TabIndex = 2;
            OptionBLBL.Text = "Option B";
            // 
            // OptionBTextBox
            // 
            OptionBTextBox.Location = new Point(155, 370);
            OptionBTextBox.Name = "OptionBTextBox";
            OptionBTextBox.Size = new Size(510, 27);
            OptionBTextBox.TabIndex = 3;
            // 
            // OptionCLBL
            // 
            OptionCLBL.AutoSize = true;
            OptionCLBL.Location = new Point(32, 419);
            OptionCLBL.Name = "OptionCLBL";
            OptionCLBL.Size = new Size(68, 20);
            OptionCLBL.TabIndex = 2;
            OptionCLBL.Text = "Option C";
            // 
            // OptionCTextBox
            // 
            OptionCTextBox.Location = new Point(155, 416);
            OptionCTextBox.Name = "OptionCTextBox";
            OptionCTextBox.Size = new Size(510, 27);
            OptionCTextBox.TabIndex = 3;
            // 
            // OptionDLBL
            // 
            OptionDLBL.AutoSize = true;
            OptionDLBL.Location = new Point(32, 473);
            OptionDLBL.Name = "OptionDLBL";
            OptionDLBL.Size = new Size(70, 20);
            OptionDLBL.TabIndex = 2;
            OptionDLBL.Text = "Option D";
            // 
            // OptionDTextBox
            // 
            OptionDTextBox.Location = new Point(155, 470);
            OptionDTextBox.Name = "OptionDTextBox";
            OptionDTextBox.Size = new Size(510, 27);
            OptionDTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1081, 93);
            label1.Name = "label1";
            label1.Size = new Size(165, 20);
            label1.TabIndex = 2;
            label1.Text = "Multiple Choice Answer";
            // 
            // AnswerA
            // 
            AnswerA.AutoSize = true;
            AnswerA.Location = new Point(1081, 128);
            AnswerA.Name = "AnswerA";
            AnswerA.Size = new Size(41, 24);
            AnswerA.TabIndex = 4;
            AnswerA.Text = "A";
            AnswerA.UseVisualStyleBackColor = true;
            // 
            // AnswerB
            // 
            AnswerB.AutoSize = true;
            AnswerB.Location = new Point(1081, 158);
            AnswerB.Name = "AnswerB";
            AnswerB.Size = new Size(40, 24);
            AnswerB.TabIndex = 4;
            AnswerB.Text = "B";
            AnswerB.UseVisualStyleBackColor = true;
            // 
            // AnswerC
            // 
            AnswerC.AutoSize = true;
            AnswerC.Location = new Point(1081, 188);
            AnswerC.Name = "AnswerC";
            AnswerC.Size = new Size(40, 24);
            AnswerC.TabIndex = 4;
            AnswerC.Text = "C";
            AnswerC.UseVisualStyleBackColor = true;
            // 
            // AnswerD
            // 
            AnswerD.AutoSize = true;
            AnswerD.Location = new Point(1081, 221);
            AnswerD.Name = "AnswerD";
            AnswerD.Size = new Size(42, 24);
            AnswerD.TabIndex = 4;
            AnswerD.Text = "D";
            AnswerD.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1256, 93);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 2;
            label2.Text = "True/False Answer";
            // 
            // TrueAnswer
            // 
            TrueAnswer.AutoSize = true;
            TrueAnswer.Location = new Point(1256, 128);
            TrueAnswer.Name = "TrueAnswer";
            TrueAnswer.Size = new Size(59, 24);
            TrueAnswer.TabIndex = 4;
            TrueAnswer.Text = "True";
            TrueAnswer.UseVisualStyleBackColor = true;
            // 
            // FalseAnswer
            // 
            FalseAnswer.AutoSize = true;
            FalseAnswer.Location = new Point(1256, 158);
            FalseAnswer.Name = "FalseAnswer";
            FalseAnswer.Size = new Size(63, 24);
            FalseAnswer.TabIndex = 4;
            FalseAnswer.Text = "False";
            FalseAnswer.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 539);
            label3.Name = "label3";
            label3.Size = new Size(143, 20);
            label3.TabIndex = 2;
            label3.Text = "Open Ended Answer";
            // 
            // OpenEndedTextBox
            // 
            OpenEndedTextBox.Location = new Point(207, 536);
            OpenEndedTextBox.Name = "OpenEndedTextBox";
            OpenEndedTextBox.Size = new Size(510, 27);
            OpenEndedTextBox.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(946, 93);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 2;
            label4.Text = "Question Type";
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(943, 272);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(440, 29);
            CreateButton.TabIndex = 5;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(943, 347);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(440, 29);
            UpdateButton.TabIndex = 5;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(946, 410);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(440, 29);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // QuestionManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1395, 637);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(CreateButton);
            Controls.Add(AnswerD);
            Controls.Add(AnswerC);
            Controls.Add(OpenEndedCheckBox);
            Controls.Add(FalseAnswer);
            Controls.Add(AnswerB);
            Controls.Add(TrueFalseCheckBox);
            Controls.Add(TrueAnswer);
            Controls.Add(AnswerA);
            Controls.Add(MultipleCheckBox);
            Controls.Add(OpenEndedTextBox);
            Controls.Add(OptionDTextBox);
            Controls.Add(label3);
            Controls.Add(OptionCTextBox);
            Controls.Add(OptionDLBL);
            Controls.Add(OptionBTextBox);
            Controls.Add(OptionCLBL);
            Controls.Add(OptionATextBox);
            Controls.Add(OptionBLBL);
            Controls.Add(QuestionNameTextBox);
            Controls.Add(OptionALBL);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(QuestionName);
            Controls.Add(dataGridView1);
            Controls.Add(QuestionManagementLBL);
            Name = "QuestionManager";
            Text = "QuestionManager";
            ((System.ComponentModel.ISupportInitialize)databaseBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)quizDbContextBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label QuestionManagementLBL;
        private BindingSource databaseBindingSource;
        private BindingSource quizDbContextBindingSource;
        private DataGridView dataGridView1;
        private Label QuestionName;
        private TextBox QuestionNameTextBox;
        private CheckBox MultipleCheckBox;
        private CheckBox TrueFalseCheckBox;
        private CheckBox OpenEndedCheckBox;
        private Label OptionALBL;
        private TextBox OptionATextBox;
        private Label OptionBLBL;
        private TextBox OptionBTextBox;
        private Label OptionCLBL;
        private TextBox OptionCTextBox;
        private Label OptionDLBL;
        private TextBox OptionDTextBox;
        private Label label1;
        private CheckBox AnswerA;
        private CheckBox AnswerB;
        private CheckBox AnswerC;
        private CheckBox AnswerD;
        private Label label2;
        private CheckBox TrueAnswer;
        private CheckBox FalseAnswer;
        private Label label3;
        private TextBox OpenEndedTextBox;
        private Label label4;
        private Button CreateButton;
        private Button UpdateButton;
        private Button DeleteButton;
    }
}