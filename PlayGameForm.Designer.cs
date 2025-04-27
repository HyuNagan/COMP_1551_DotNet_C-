namespace COMP1551
{
    partial class PlayGameForm
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
            ScoreLabel = new Label();
            ScoreValue = new Label();
            TimerLabel = new Label();
            TimerValue = new Label();
            QuestionTextLBL = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            OpenEndedTextBox = new TextBox();
            SubmitBTN = new Button();
            SuspendLayout();
            // 
            // ScoreLabel
            // 
            ScoreLabel.AutoSize = true;
            ScoreLabel.Location = new Point(12, 9);
            ScoreLabel.Name = "ScoreLabel";
            ScoreLabel.Size = new Size(46, 20);
            ScoreLabel.TabIndex = 0;
            ScoreLabel.Text = "Score";
            // 
            // ScoreValue
            // 
            ScoreValue.AutoSize = true;
            ScoreValue.Location = new Point(64, 10);
            ScoreValue.Name = "ScoreValue";
            ScoreValue.Size = new Size(17, 20);
            ScoreValue.TabIndex = 0;
            ScoreValue.Text = "0";
            // 
            // TimerLabel
            // 
            TimerLabel.AutoSize = true;
            TimerLabel.Location = new Point(710, 9);
            TimerLabel.Name = "TimerLabel";
            TimerLabel.Size = new Size(47, 20);
            TimerLabel.TabIndex = 0;
            TimerLabel.Text = "Timer";
            // 
            // TimerValue
            // 
            TimerValue.AutoSize = true;
            TimerValue.Location = new Point(762, 10);
            TimerValue.Name = "TimerValue";
            TimerValue.Size = new Size(17, 20);
            TimerValue.TabIndex = 0;
            TimerValue.Text = "0";
            // 
            // QuestionTextLBL
            // 
            QuestionTextLBL.AutoSize = true;
            QuestionTextLBL.Location = new Point(296, 68);
            QuestionTextLBL.Name = "QuestionTextLBL";
            QuestionTextLBL.Size = new Size(136, 20);
            QuestionTextLBL.TabIndex = 1;
            QuestionTextLBL.Text = "Name Of Question ";
            // 
            // button1
            // 
            button1.Location = new Point(64, 215);
            button1.Name = "button1";
            button1.Size = new Size(251, 90);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(446, 215);
            button2.Name = "button2";
            button2.Size = new Size(251, 90);
            button2.TabIndex = 2;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(64, 343);
            button3.Name = "button3";
            button3.Size = new Size(251, 90);
            button3.TabIndex = 2;
            button3.Text = "button1";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(446, 348);
            button4.Name = "button4";
            button4.Size = new Size(251, 90);
            button4.TabIndex = 2;
            button4.Text = "button1";
            button4.UseVisualStyleBackColor = true;
            // 
            // OpenEndedTextBox
            // 
            OpenEndedTextBox.Location = new Point(59, 154);
            OpenEndedTextBox.Name = "OpenEndedTextBox";
            OpenEndedTextBox.Size = new Size(467, 27);
            OpenEndedTextBox.TabIndex = 3;
            // 
            // SubmitBTN
            // 
            SubmitBTN.Location = new Point(570, 153);
            SubmitBTN.Name = "SubmitBTN";
            SubmitBTN.Size = new Size(94, 29);
            SubmitBTN.TabIndex = 4;
            SubmitBTN.Text = "Submit";
            SubmitBTN.UseVisualStyleBackColor = true;
            // 
            // PlayGameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SubmitBTN);
            Controls.Add(OpenEndedTextBox);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(QuestionTextLBL);
            Controls.Add(TimerValue);
            Controls.Add(ScoreValue);
            Controls.Add(TimerLabel);
            Controls.Add(ScoreLabel);
            Name = "PlayGameForm";
            Text = "PlayGameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ScoreLabel;
        private Label ScoreValue;
        private Label TimerLabel;
        private Label TimerValue;
        private Label QuestionTextLBL;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox OpenEndedTextBox;
        private Button SubmitBTN;
    }
}