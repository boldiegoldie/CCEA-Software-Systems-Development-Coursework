namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class EndScreen
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
            this.EndMessage = new System.Windows.Forms.Label();
            this.Bronze = new System.Windows.Forms.PictureBox();
            this.Gold = new System.Windows.Forms.PictureBox();
            this.Silver = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ReturnLobby = new System.Windows.Forms.Button();
            this.GoToLeaderboard = new System.Windows.Forms.Button();
            this.Twenty = new System.Windows.Forms.Label();
            this.Ten = new System.Windows.Forms.Label();
            this.Zero = new System.Windows.Forms.Label();
            this.ScoreMessage1 = new System.Windows.Forms.Label();
            this.EndScoreTxt = new System.Windows.Forms.Label();
            this.ScoreMessage2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Bronze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Silver)).BeginInit();
            this.SuspendLayout();
            // 
            // EndMessage
            // 
            this.EndMessage.Font = new System.Drawing.Font("Lucida Sans", 44.25F, System.Drawing.FontStyle.Bold);
            this.EndMessage.ForeColor = System.Drawing.Color.White;
            this.EndMessage.Location = new System.Drawing.Point(20, 30);
            this.EndMessage.Name = "EndMessage";
            this.EndMessage.Size = new System.Drawing.Size(1256, 165);
            this.EndMessage.TabIndex = 0;
            this.EndMessage.Text = "{placeholder}";
            // 
            // Bronze
            // 
            this.Bronze.Image = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.CopperTrophyBlack;
            this.Bronze.Location = new System.Drawing.Point(106, 241);
            this.Bronze.Name = "Bronze";
            this.Bronze.Size = new System.Drawing.Size(143, 220);
            this.Bronze.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Bronze.TabIndex = 1;
            this.Bronze.TabStop = false;
            // 
            // Gold
            // 
            this.Gold.Image = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.GoldTrophyBlack;
            this.Gold.Location = new System.Drawing.Point(336, 205);
            this.Gold.Name = "Gold";
            this.Gold.Size = new System.Drawing.Size(178, 256);
            this.Gold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Gold.TabIndex = 2;
            this.Gold.TabStop = false;
            // 
            // Silver
            // 
            this.Silver.Image = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.SilverTrophyBlack;
            this.Silver.Location = new System.Drawing.Point(606, 217);
            this.Silver.Name = "Silver";
            this.Silver.Size = new System.Drawing.Size(121, 244);
            this.Silver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Silver.TabIndex = 3;
            this.Silver.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(106, 513);
            this.progressBar1.Maximum = 80;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(621, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            // 
            // ReturnLobby
            // 
            this.ReturnLobby.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReturnLobby.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.ReturnLobby.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReturnLobby.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnLobby.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnLobby.ForeColor = System.Drawing.Color.White;
            this.ReturnLobby.Location = new System.Drawing.Point(1233, 627);
            this.ReturnLobby.Margin = new System.Windows.Forms.Padding(2);
            this.ReturnLobby.Name = "ReturnLobby";
            this.ReturnLobby.Size = new System.Drawing.Size(340, 87);
            this.ReturnLobby.TabIndex = 5;
            this.ReturnLobby.Text = "Return to Lobby";
            this.ReturnLobby.UseVisualStyleBackColor = false;
            this.ReturnLobby.Click += new System.EventHandler(this.ReturnLobby_Click);
            // 
            // GoToLeaderboard
            // 
            this.GoToLeaderboard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GoToLeaderboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.GoToLeaderboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToLeaderboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoToLeaderboard.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoToLeaderboard.ForeColor = System.Drawing.Color.White;
            this.GoToLeaderboard.Location = new System.Drawing.Point(889, 627);
            this.GoToLeaderboard.Margin = new System.Windows.Forms.Padding(2);
            this.GoToLeaderboard.Name = "GoToLeaderboard";
            this.GoToLeaderboard.Size = new System.Drawing.Size(340, 87);
            this.GoToLeaderboard.TabIndex = 6;
            this.GoToLeaderboard.Text = "Leaderboard";
            this.GoToLeaderboard.UseVisualStyleBackColor = false;
            this.GoToLeaderboard.Click += new System.EventHandler(this.GoToLeaderboard_Click);
            // 
            // Twenty
            // 
            this.Twenty.AutoSize = true;
            this.Twenty.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Twenty.ForeColor = System.Drawing.Color.LimeGreen;
            this.Twenty.Location = new System.Drawing.Point(710, 548);
            this.Twenty.Name = "Twenty";
            this.Twenty.Size = new System.Drawing.Size(36, 23);
            this.Twenty.TabIndex = 7;
            this.Twenty.Text = "20";
            // 
            // Ten
            // 
            this.Ten.AutoSize = true;
            this.Ten.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ten.ForeColor = System.Drawing.Color.Orange;
            this.Ten.Location = new System.Drawing.Point(398, 548);
            this.Ten.Name = "Ten";
            this.Ten.Size = new System.Drawing.Size(36, 23);
            this.Ten.TabIndex = 8;
            this.Ten.Text = "10";
            // 
            // Zero
            // 
            this.Zero.AutoSize = true;
            this.Zero.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zero.ForeColor = System.Drawing.Color.Red;
            this.Zero.Location = new System.Drawing.Point(100, 548);
            this.Zero.Name = "Zero";
            this.Zero.Size = new System.Drawing.Size(23, 23);
            this.Zero.TabIndex = 9;
            this.Zero.Text = "0";
            // 
            // ScoreMessage1
            // 
            this.ScoreMessage1.AutoSize = true;
            this.ScoreMessage1.Font = new System.Drawing.Font("Lucida Sans", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreMessage1.ForeColor = System.Drawing.Color.White;
            this.ScoreMessage1.Location = new System.Drawing.Point(1045, 181);
            this.ScoreMessage1.Name = "ScoreMessage1";
            this.ScoreMessage1.Size = new System.Drawing.Size(389, 49);
            this.ScoreMessage1.TabIndex = 10;
            this.ScoreMessage1.Text = "Your final score:";
            // 
            // EndScoreTxt
            // 
            this.EndScoreTxt.Font = new System.Drawing.Font("Lucida Sans", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndScoreTxt.ForeColor = System.Drawing.Color.LimeGreen;
            this.EndScoreTxt.Location = new System.Drawing.Point(1016, 230);
            this.EndScoreTxt.Name = "EndScoreTxt";
            this.EndScoreTxt.Size = new System.Drawing.Size(434, 259);
            this.EndScoreTxt.TabIndex = 11;
            this.EndScoreTxt.Text = "17.25";
            this.EndScoreTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoreMessage2
            // 
            this.ScoreMessage2.AutoSize = true;
            this.ScoreMessage2.Font = new System.Drawing.Font("Lucida Sans", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreMessage2.ForeColor = System.Drawing.Color.White;
            this.ScoreMessage2.Location = new System.Drawing.Point(1113, 489);
            this.ScoreMessage2.Name = "ScoreMessage2";
            this.ScoreMessage2.Size = new System.Drawing.Size(236, 49);
            this.ScoreMessage2.TabIndex = 12;
            this.ScoreMessage2.Text = "out of 20!";
            // 
            // EndScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.ScoreMessage2);
            this.Controls.Add(this.EndScoreTxt);
            this.Controls.Add(this.ScoreMessage1);
            this.Controls.Add(this.Zero);
            this.Controls.Add(this.Ten);
            this.Controls.Add(this.Twenty);
            this.Controls.Add(this.GoToLeaderboard);
            this.Controls.Add(this.ReturnLobby);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Silver);
            this.Controls.Add(this.Gold);
            this.Controls.Add(this.Bronze);
            this.Controls.Add(this.EndMessage);
            this.Name = "EndScreen";
            this.Load += new System.EventHandler(this.EndScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Bronze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Silver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EndMessage;
        private System.Windows.Forms.PictureBox Bronze;
        private System.Windows.Forms.PictureBox Gold;
        private System.Windows.Forms.PictureBox Silver;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button ReturnLobby;
        private System.Windows.Forms.Button GoToLeaderboard;
        private System.Windows.Forms.Label Twenty;
        private System.Windows.Forms.Label Ten;
        private System.Windows.Forms.Label Zero;
        private System.Windows.Forms.Label ScoreMessage1;
        private System.Windows.Forms.Label EndScoreTxt;
        private System.Windows.Forms.Label ScoreMessage2;
    }
}