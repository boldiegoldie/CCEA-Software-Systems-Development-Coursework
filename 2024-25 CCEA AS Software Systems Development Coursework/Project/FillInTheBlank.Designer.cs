namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class FillInTheBlank
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
            this.components = new System.ComponentModel.Container();
            this.QuestionHeader = new System.Windows.Forms.Label();
            this.AnswerInput = new System.Windows.Forms.RichTextBox();
            this.AdminText = new System.Windows.Forms.Label();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.NoAns = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // QuestionHeader
            // 
            this.QuestionHeader.Font = new System.Drawing.Font("Lucida Sans", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionHeader.ForeColor = System.Drawing.Color.White;
            this.QuestionHeader.Location = new System.Drawing.Point(20, 30);
            this.QuestionHeader.Name = "QuestionHeader";
            this.QuestionHeader.Size = new System.Drawing.Size(1192, 165);
            this.QuestionHeader.TabIndex = 3;
            this.QuestionHeader.Text = "{placeholder}";
            // 
            // AnswerInput
            // 
            this.AnswerInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AnswerInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.AnswerInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AnswerInput.Font = new System.Drawing.Font("Lucida Sans", 30.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerInput.ForeColor = System.Drawing.Color.White;
            this.AnswerInput.Location = new System.Drawing.Point(32, 264);
            this.AnswerInput.Margin = new System.Windows.Forms.Padding(0);
            this.AnswerInput.MaxLength = 0;
            this.AnswerInput.Name = "AnswerInput";
            this.AnswerInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AnswerInput.Size = new System.Drawing.Size(1259, 164);
            this.AnswerInput.TabIndex = 19;
            this.AnswerInput.Text = "Enter Answer Here";
            this.AnswerInput.Click += new System.EventHandler(this.AnswerInput_Click);
            // 
            // AdminText
            // 
            this.AdminText.AutoSize = true;
            this.AdminText.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminText.ForeColor = System.Drawing.Color.White;
            this.AdminText.Location = new System.Drawing.Point(32, 453);
            this.AdminText.Margin = new System.Windows.Forms.Padding(0);
            this.AdminText.Name = "AdminText";
            this.AdminText.Size = new System.Drawing.Size(232, 37);
            this.AdminText.TabIndex = 20;
            this.AdminText.Text = "Admin Mode:";
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Lucida Sans", 32F, System.Drawing.FontStyle.Bold);
            this.TimerLabel.ForeColor = System.Drawing.Color.White;
            this.TimerLabel.Location = new System.Drawing.Point(1484, 30);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(76, 49);
            this.TimerLabel.TabIndex = 23;
            this.TimerLabel.Text = "10";
            // 
            // NoAns
            // 
            this.NoAns.AutoSize = true;
            this.NoAns.Font = new System.Drawing.Font("Lucida Sans", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoAns.ForeColor = System.Drawing.Color.Red;
            this.NoAns.Location = new System.Drawing.Point(1078, 660);
            this.NoAns.Name = "NoAns";
            this.NoAns.Size = new System.Drawing.Size(494, 42);
            this.NoAns.TabIndex = 24;
            this.NoAns.Text = "Please type in an answer.";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FillInTheBlank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.NoAns);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.AdminText);
            this.Controls.Add(this.AnswerInput);
            this.Controls.Add(this.QuestionHeader);
            this.Name = "FillInTheBlank";
            this.Text = "FillInTheBlank";
            this.Load += new System.EventHandler(this.FillInTheBlank_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuestionHeader;
        private System.Windows.Forms.RichTextBox AnswerInput;
        private System.Windows.Forms.Label AdminText;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Label NoAns;
        private System.Windows.Forms.Timer timer1;
    }
}