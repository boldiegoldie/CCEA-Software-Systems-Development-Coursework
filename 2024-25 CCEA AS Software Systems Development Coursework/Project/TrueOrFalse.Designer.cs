namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class TrueOrFalse
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
            this.TrueBtn = new System.Windows.Forms.Button();
            this.FalseBtn = new System.Windows.Forms.Button();
            this.NoAns = new System.Windows.Forms.Label();
            this.AdminText = new System.Windows.Forms.Label();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // QuestionHeader
            // 
            this.QuestionHeader.Font = new System.Drawing.Font("Lucida Sans", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionHeader.ForeColor = System.Drawing.Color.White;
            this.QuestionHeader.Location = new System.Drawing.Point(20, 30);
            this.QuestionHeader.Name = "QuestionHeader";
            this.QuestionHeader.Size = new System.Drawing.Size(1274, 165);
            this.QuestionHeader.TabIndex = 11;
            this.QuestionHeader.Text = "{placeholder}";
            // 
            // TrueBtn
            // 
            this.TrueBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.TrueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TrueBtn.Font = new System.Drawing.Font("Lucida Sans", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrueBtn.ForeColor = System.Drawing.Color.White;
            this.TrueBtn.Location = new System.Drawing.Point(30, 226);
            this.TrueBtn.Name = "TrueBtn";
            this.TrueBtn.Size = new System.Drawing.Size(700, 400);
            this.TrueBtn.TabIndex = 12;
            this.TrueBtn.Text = "True";
            this.TrueBtn.UseVisualStyleBackColor = false;
            this.TrueBtn.Click += new System.EventHandler(this.TrueBtn_Click);
            // 
            // FalseBtn
            // 
            this.FalseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.FalseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FalseBtn.Font = new System.Drawing.Font("Lucida Sans", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FalseBtn.ForeColor = System.Drawing.Color.White;
            this.FalseBtn.Location = new System.Drawing.Point(860, 226);
            this.FalseBtn.Name = "FalseBtn";
            this.FalseBtn.Size = new System.Drawing.Size(700, 400);
            this.FalseBtn.TabIndex = 13;
            this.FalseBtn.Text = "False";
            this.FalseBtn.UseVisualStyleBackColor = false;
            this.FalseBtn.Click += new System.EventHandler(this.FalseBtn_Click);
            // 
            // NoAns
            // 
            this.NoAns.AutoSize = true;
            this.NoAns.Font = new System.Drawing.Font("Lucida Sans", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoAns.ForeColor = System.Drawing.Color.Red;
            this.NoAns.Location = new System.Drawing.Point(1097, 670);
            this.NoAns.Name = "NoAns";
            this.NoAns.Size = new System.Drawing.Size(475, 42);
            this.NoAns.TabIndex = 14;
            this.NoAns.Text = "Please select an answer.";
            // 
            // AdminText
            // 
            this.AdminText.AutoSize = true;
            this.AdminText.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminText.ForeColor = System.Drawing.Color.White;
            this.AdminText.Location = new System.Drawing.Point(20, 670);
            this.AdminText.Margin = new System.Windows.Forms.Padding(0);
            this.AdminText.Name = "AdminText";
            this.AdminText.Size = new System.Drawing.Size(232, 37);
            this.AdminText.TabIndex = 21;
            this.AdminText.Text = "Admin Mode:";
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Lucida Sans", 32F, System.Drawing.FontStyle.Bold);
            this.TimerLabel.ForeColor = System.Drawing.Color.White;
            this.TimerLabel.Location = new System.Drawing.Point(1484, 19);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(76, 49);
            this.TimerLabel.TabIndex = 22;
            this.TimerLabel.Text = "10";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TrueOrFalse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.AdminText);
            this.Controls.Add(this.NoAns);
            this.Controls.Add(this.FalseBtn);
            this.Controls.Add(this.TrueBtn);
            this.Controls.Add(this.QuestionHeader);
            this.Name = "TrueOrFalse";
            this.Text = "TrueOrFalse";
            this.Load += new System.EventHandler(this.TrueOrFalse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuestionHeader;
        private System.Windows.Forms.Button TrueBtn;
        private System.Windows.Forms.Button FalseBtn;
        private System.Windows.Forms.Label NoAns;
        private System.Windows.Forms.Label AdminText;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Timer timer1;
    }
}