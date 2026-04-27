namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class Leaderboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LeaderboardHeader = new System.Windows.Forms.Label();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.Error = new System.Windows.Forms.Label();
            this.SortNameBtn = new System.Windows.Forms.Button();
            this.SortScoreBtn = new System.Windows.Forms.Button();
            this.SortLCBtn = new System.Windows.Forms.Button();
            this.SortLICBtn = new System.Windows.Forms.Button();
            this.SortOrderBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // LeaderboardHeader
            // 
            this.LeaderboardHeader.Font = new System.Drawing.Font("Lucida Sans", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeaderboardHeader.ForeColor = System.Drawing.Color.White;
            this.LeaderboardHeader.Location = new System.Drawing.Point(20, 30);
            this.LeaderboardHeader.Name = "LeaderboardHeader";
            this.LeaderboardHeader.Size = new System.Drawing.Size(418, 74);
            this.LeaderboardHeader.TabIndex = 4;
            this.LeaderboardHeader.Text = "Leaderboard";
            // 
            // DataGrid
            // 
            this.DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid.Location = new System.Drawing.Point(30, 110);
            this.DataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            this.DataGrid.Size = new System.Drawing.Size(1140, 601);
            this.DataGrid.TabIndex = 5;
            // 
            // Error
            // 
            this.Error.AutoSize = true;
            this.Error.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.Error.Font = new System.Drawing.Font("Lucida Sans", 40F, System.Drawing.FontStyle.Bold);
            this.Error.ForeColor = System.Drawing.Color.Red;
            this.Error.Location = new System.Drawing.Point(382, 381);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(428, 61);
            this.Error.TabIndex = 47;
            this.Error.Text = "File not found.";
            // 
            // SortNameBtn
            // 
            this.SortNameBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SortNameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.SortNameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SortNameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SortNameBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortNameBtn.ForeColor = System.Drawing.Color.White;
            this.SortNameBtn.Location = new System.Drawing.Point(1207, 265);
            this.SortNameBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SortNameBtn.Name = "SortNameBtn";
            this.SortNameBtn.Size = new System.Drawing.Size(340, 87);
            this.SortNameBtn.TabIndex = 48;
            this.SortNameBtn.Text = "Username";
            this.SortNameBtn.UseVisualStyleBackColor = false;
            this.SortNameBtn.Click += new System.EventHandler(this.SortNameBtn_Click);
            // 
            // SortScoreBtn
            // 
            this.SortScoreBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SortScoreBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.SortScoreBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SortScoreBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SortScoreBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortScoreBtn.ForeColor = System.Drawing.Color.White;
            this.SortScoreBtn.Location = new System.Drawing.Point(1207, 378);
            this.SortScoreBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SortScoreBtn.Name = "SortScoreBtn";
            this.SortScoreBtn.Size = new System.Drawing.Size(340, 87);
            this.SortScoreBtn.TabIndex = 49;
            this.SortScoreBtn.Text = "Score";
            this.SortScoreBtn.UseVisualStyleBackColor = false;
            this.SortScoreBtn.Click += new System.EventHandler(this.SortScoreBtn_Click);
            // 
            // SortLCBtn
            // 
            this.SortLCBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SortLCBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.SortLCBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SortLCBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SortLCBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortLCBtn.ForeColor = System.Drawing.Color.White;
            this.SortLCBtn.Location = new System.Drawing.Point(1207, 491);
            this.SortLCBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SortLCBtn.Name = "SortLCBtn";
            this.SortLCBtn.Size = new System.Drawing.Size(340, 87);
            this.SortLCBtn.TabIndex = 50;
            this.SortLCBtn.Text = "Lifetime Correct";
            this.SortLCBtn.UseVisualStyleBackColor = false;
            this.SortLCBtn.Click += new System.EventHandler(this.SortLCBtn_Click);
            // 
            // SortLICBtn
            // 
            this.SortLICBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SortLICBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.SortLICBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SortLICBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SortLICBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortLICBtn.ForeColor = System.Drawing.Color.White;
            this.SortLICBtn.Location = new System.Drawing.Point(1207, 604);
            this.SortLICBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SortLICBtn.Name = "SortLICBtn";
            this.SortLICBtn.Size = new System.Drawing.Size(340, 87);
            this.SortLICBtn.TabIndex = 51;
            this.SortLICBtn.Text = "Lifetime Incorrect";
            this.SortLICBtn.UseVisualStyleBackColor = false;
            this.SortLICBtn.Click += new System.EventHandler(this.SortLICBtn_Click);
            // 
            // SortOrderBtn
            // 
            this.SortOrderBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SortOrderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.SortOrderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SortOrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SortOrderBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortOrderBtn.ForeColor = System.Drawing.Color.White;
            this.SortOrderBtn.Location = new System.Drawing.Point(1207, 152);
            this.SortOrderBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SortOrderBtn.Name = "SortOrderBtn";
            this.SortOrderBtn.Size = new System.Drawing.Size(340, 87);
            this.SortOrderBtn.TabIndex = 52;
            this.SortOrderBtn.Text = "Descending";
            this.SortOrderBtn.UseVisualStyleBackColor = false;
            this.SortOrderBtn.Click += new System.EventHandler(this.SortOrderBtn_Click);
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.SortOrderBtn);
            this.Controls.Add(this.SortLICBtn);
            this.Controls.Add(this.SortLCBtn);
            this.Controls.Add(this.SortScoreBtn);
            this.Controls.Add(this.SortNameBtn);
            this.Controls.Add(this.Error);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.LeaderboardHeader);
            this.Name = "Leaderboard";
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.Leaderboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LeaderboardHeader;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Label Error;
        private System.Windows.Forms.Button SortNameBtn;
        private System.Windows.Forms.Button SortScoreBtn;
        private System.Windows.Forms.Button SortLCBtn;
        private System.Windows.Forms.Button SortLICBtn;
        private System.Windows.Forms.Button SortOrderBtn;
    }
}