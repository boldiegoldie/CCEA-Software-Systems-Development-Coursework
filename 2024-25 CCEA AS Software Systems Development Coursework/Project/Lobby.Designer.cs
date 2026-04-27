namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class Lobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lobby));
            this.LobbyHeader = new System.Windows.Forms.Label();
            this.PlayGameBtn = new System.Windows.Forms.Button();
            this.DifficultySelectBtn = new System.Windows.Forms.Button();
            this.LeaderboardBtn = new System.Windows.Forms.Button();
            this.DesignerBtn = new System.Windows.Forms.Button();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.ExtendedStats = new System.Windows.Forms.Label();
            this.Stats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LobbyHeader
            // 
            this.LobbyHeader.AutoSize = true;
            this.LobbyHeader.Font = new System.Drawing.Font("Lucida Sans", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LobbyHeader.ForeColor = System.Drawing.Color.White;
            this.LobbyHeader.Location = new System.Drawing.Point(20, 30);
            this.LobbyHeader.Name = "LobbyHeader";
            this.LobbyHeader.Size = new System.Drawing.Size(775, 67);
            this.LobbyHeader.TabIndex = 0;
            this.LobbyHeader.Text = "Hello, {insert name here}";
            // 
            // PlayGameBtn
            // 
            this.PlayGameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.PlayGameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayGameBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayGameBtn.ForeColor = System.Drawing.Color.White;
            this.PlayGameBtn.Location = new System.Drawing.Point(1126, 332);
            this.PlayGameBtn.Name = "PlayGameBtn";
            this.PlayGameBtn.Size = new System.Drawing.Size(436, 108);
            this.PlayGameBtn.TabIndex = 2;
            this.PlayGameBtn.Text = "Play Quiz";
            this.PlayGameBtn.UseVisualStyleBackColor = false;
            this.PlayGameBtn.Click += new System.EventHandler(this.PlayBtn_click);
            // 
            // DifficultySelectBtn
            // 
            this.DifficultySelectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.DifficultySelectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DifficultySelectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DifficultySelectBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultySelectBtn.ForeColor = System.Drawing.Color.White;
            this.DifficultySelectBtn.Location = new System.Drawing.Point(1172, 121);
            this.DifficultySelectBtn.Name = "DifficultySelectBtn";
            this.DifficultySelectBtn.Size = new System.Drawing.Size(349, 87);
            this.DifficultySelectBtn.TabIndex = 3;
            this.DifficultySelectBtn.Text = "Change Difficulty";
            this.DifficultySelectBtn.UseVisualStyleBackColor = false;
            this.DifficultySelectBtn.Click += new System.EventHandler(this.DifficultyBtn_click);
            // 
            // LeaderboardBtn
            // 
            this.LeaderboardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.LeaderboardBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeaderboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeaderboardBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeaderboardBtn.ForeColor = System.Drawing.Color.White;
            this.LeaderboardBtn.Location = new System.Drawing.Point(1172, 224);
            this.LeaderboardBtn.Name = "LeaderboardBtn";
            this.LeaderboardBtn.Size = new System.Drawing.Size(349, 87);
            this.LeaderboardBtn.TabIndex = 4;
            this.LeaderboardBtn.Text = "Leaderboard";
            this.LeaderboardBtn.UseVisualStyleBackColor = false;
            this.LeaderboardBtn.Click += new System.EventHandler(this.LeaderboardBtn_click);
            // 
            // DesignerBtn
            // 
            this.DesignerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.DesignerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DesignerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DesignerBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesignerBtn.ForeColor = System.Drawing.Color.White;
            this.DesignerBtn.Location = new System.Drawing.Point(1172, 462);
            this.DesignerBtn.Name = "DesignerBtn";
            this.DesignerBtn.Size = new System.Drawing.Size(349, 87);
            this.DesignerBtn.TabIndex = 6;
            this.DesignerBtn.Text = "Question Designer";
            this.DesignerBtn.UseVisualStyleBackColor = false;
            this.DesignerBtn.Click += new System.EventHandler(this.DesignerBtn_click);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.SettingsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsBtn.ForeColor = System.Drawing.Color.White;
            this.SettingsBtn.Location = new System.Drawing.Point(1172, 565);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(349, 87);
            this.SettingsBtn.TabIndex = 7;
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.UseVisualStyleBackColor = false;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_click);
            // 
            // ExtendedStats
            // 
            this.ExtendedStats.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold);
            this.ExtendedStats.ForeColor = System.Drawing.Color.White;
            this.ExtendedStats.Location = new System.Drawing.Point(431, 380);
            this.ExtendedStats.Margin = new System.Windows.Forms.Padding(0);
            this.ExtendedStats.Name = "ExtendedStats";
            this.ExtendedStats.Size = new System.Drawing.Size(122, 188);
            this.ExtendedStats.TabIndex = 8;
            this.ExtendedStats.Text = "0/0\r\n0/0\r\n0/0\r\n0/0\r\n0/0";
            // 
            // Stats
            // 
            this.Stats.AutoSize = true;
            this.Stats.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stats.ForeColor = System.Drawing.Color.White;
            this.Stats.Location = new System.Drawing.Point(25, 161);
            this.Stats.Margin = new System.Windows.Forms.Padding(0);
            this.Stats.Name = "Stats";
            this.Stats.Size = new System.Drawing.Size(606, 407);
            this.Stats.TabIndex = 5;
            this.Stats.Text = resources.GetString("Stats.Text");
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.ExtendedStats);
            this.Controls.Add(this.SettingsBtn);
            this.Controls.Add(this.DesignerBtn);
            this.Controls.Add(this.Stats);
            this.Controls.Add(this.LeaderboardBtn);
            this.Controls.Add(this.DifficultySelectBtn);
            this.Controls.Add(this.PlayGameBtn);
            this.Controls.Add(this.LobbyHeader);
            this.Name = "Lobby";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Lobby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LobbyHeader;
        private System.Windows.Forms.Button PlayGameBtn;
        private System.Windows.Forms.Button DifficultySelectBtn;
        private System.Windows.Forms.Button LeaderboardBtn;
        private System.Windows.Forms.Button DesignerBtn;
        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.Label ExtendedStats;
        private System.Windows.Forms.Label Stats;
    }
}