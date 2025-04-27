namespace COMP1551
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PlayGameBTN = new Button();
            QuestionManagementBTN = new Button();
            ScoreValueLBL = new Label();
            SuspendLayout();
            // 
            // PlayGameBTN
            // 
            PlayGameBTN.Location = new Point(293, 115);
            PlayGameBTN.Name = "PlayGameBTN";
            PlayGameBTN.Size = new Size(199, 80);
            PlayGameBTN.TabIndex = 0;
            PlayGameBTN.Text = "Play Game";
            PlayGameBTN.UseVisualStyleBackColor = true;
            // 
            // QuestionManagementBTN
            // 
            QuestionManagementBTN.Location = new Point(293, 246);
            QuestionManagementBTN.Name = "QuestionManagementBTN";
            QuestionManagementBTN.Size = new Size(199, 80);
            QuestionManagementBTN.TabIndex = 0;
            QuestionManagementBTN.Text = "Question Management";
            QuestionManagementBTN.UseVisualStyleBackColor = true;
            // 
            // ScoreValueLBL
            // 
            ScoreValueLBL.AutoSize = true;
            ScoreValueLBL.Location = new Point(15, 17);
            ScoreValueLBL.Name = "ScoreValueLBL";
            ScoreValueLBL.Size = new Size(46, 20);
            ScoreValueLBL.TabIndex = 1;
            ScoreValueLBL.Text = "Score";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ScoreValueLBL);
            Controls.Add(QuestionManagementBTN);
            Controls.Add(PlayGameBTN);
            Name = "Menu";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button PlayGameBTN;
        private Button QuestionManagementBTN;
        private Label ScoreValueLBL;
    }
}
