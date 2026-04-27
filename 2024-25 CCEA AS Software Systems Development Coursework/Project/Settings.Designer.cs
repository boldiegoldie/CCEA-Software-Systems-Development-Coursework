namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class Settings
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
            this.SettingsHeader = new System.Windows.Forms.Label();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.VolumeHeader = new System.Windows.Forms.Label();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.DeleteUsrDat = new System.Windows.Forms.Button();
            this.ResetLeaderboard = new System.Windows.Forms.Button();
            this.MessageSelection = new System.Windows.Forms.ComboBox();
            this.AdminHeader = new System.Windows.Forms.Label();
            this.EndMessageHeader = new System.Windows.Forms.Label();
            this.MessageInput = new System.Windows.Forms.RichTextBox();
            this.FontSizeInput = new System.Windows.Forms.NumericUpDown();
            this.MessageHeader = new System.Windows.Forms.Label();
            this.FontSizeLabel = new System.Windows.Forms.Label();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.AlreadyExists = new System.Windows.Forms.Label();
            this.NoMessage = new System.Windows.Forms.Label();
            this.NoOption = new System.Windows.Forms.Label();
            this.TextView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FontSizeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsHeader
            // 
            this.SettingsHeader.Font = new System.Drawing.Font("Lucida Sans", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsHeader.ForeColor = System.Drawing.Color.White;
            this.SettingsHeader.Location = new System.Drawing.Point(20, 30);
            this.SettingsHeader.Name = "SettingsHeader";
            this.SettingsHeader.Size = new System.Drawing.Size(1256, 141);
            this.SettingsHeader.TabIndex = 13;
            this.SettingsHeader.Text = "Settings";
            // 
            // volumeBar
            // 
            this.volumeBar.LargeChange = 10;
            this.volumeBar.Location = new System.Drawing.Point(30, 474);
            this.volumeBar.Maximum = 100;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(700, 45);
            this.volumeBar.TabIndex = 14;
            this.volumeBar.TickFrequency = 2;
            this.volumeBar.ValueChanged += new System.EventHandler(this.volumeBar_ValueChanged);
            // 
            // VolumeHeader
            // 
            this.VolumeHeader.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolumeHeader.ForeColor = System.Drawing.Color.White;
            this.VolumeHeader.Location = new System.Drawing.Point(35, 431);
            this.VolumeHeader.Name = "VolumeHeader";
            this.VolumeHeader.Size = new System.Drawing.Size(225, 40);
            this.VolumeHeader.TabIndex = 15;
            this.VolumeHeader.Text = "Volume:";
            // 
            // checkedListBox
            // 
            this.checkedListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.checkedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox.ForeColor = System.Drawing.Color.White;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "Admin Mode",
            "Read Out Questions",
            "Skip End Screen",
            "Dyslexia Mode"});
            this.checkedListBox.Location = new System.Drawing.Point(30, 215);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(392, 160);
            this.checkedListBox.TabIndex = 17;
            // 
            // DeleteUsrDat
            // 
            this.DeleteUsrDat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteUsrDat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.DeleteUsrDat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteUsrDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteUsrDat.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteUsrDat.ForeColor = System.Drawing.Color.White;
            this.DeleteUsrDat.Location = new System.Drawing.Point(743, 215);
            this.DeleteUsrDat.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteUsrDat.Name = "DeleteUsrDat";
            this.DeleteUsrDat.Size = new System.Drawing.Size(340, 87);
            this.DeleteUsrDat.TabIndex = 19;
            this.DeleteUsrDat.Text = "Delete UserData";
            this.DeleteUsrDat.UseVisualStyleBackColor = false;
            this.DeleteUsrDat.Click += new System.EventHandler(this.DeleteUsrDat_Click);
            // 
            // ResetLeaderboard
            // 
            this.ResetLeaderboard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ResetLeaderboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.ResetLeaderboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetLeaderboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetLeaderboard.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetLeaderboard.ForeColor = System.Drawing.Color.White;
            this.ResetLeaderboard.Location = new System.Drawing.Point(1174, 215);
            this.ResetLeaderboard.Margin = new System.Windows.Forms.Padding(0);
            this.ResetLeaderboard.Name = "ResetLeaderboard";
            this.ResetLeaderboard.Size = new System.Drawing.Size(340, 87);
            this.ResetLeaderboard.TabIndex = 20;
            this.ResetLeaderboard.Text = "Reset Leaderboard";
            this.ResetLeaderboard.UseVisualStyleBackColor = false;
            this.ResetLeaderboard.Click += new System.EventHandler(this.ResetLeaderboard_Click);
            // 
            // MessageSelection
            // 
            this.MessageSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.MessageSelection.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageSelection.ForeColor = System.Drawing.Color.White;
            this.MessageSelection.FormattingEnabled = true;
            this.MessageSelection.Items.AddRange(new object[] {
            "Very Bad (Score <= 3)",
            "Bad (Score 4 - 8)",
            "Normal (Score 9 - 12)",
            "Good (Score 12 - 16)",
            "Very Good ( Score >= 17)"});
            this.MessageSelection.Location = new System.Drawing.Point(754, 378);
            this.MessageSelection.Name = "MessageSelection";
            this.MessageSelection.Size = new System.Drawing.Size(393, 31);
            this.MessageSelection.TabIndex = 21;
            this.MessageSelection.Text = "Select a message category";
            this.MessageSelection.Click += new System.EventHandler(this.MessageSelection_Click);
            // 
            // AdminHeader
            // 
            this.AdminHeader.AutoSize = true;
            this.AdminHeader.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminHeader.ForeColor = System.Drawing.Color.White;
            this.AdminHeader.Location = new System.Drawing.Point(747, 171);
            this.AdminHeader.Name = "AdminHeader";
            this.AdminHeader.Size = new System.Drawing.Size(277, 37);
            this.AdminHeader.TabIndex = 18;
            this.AdminHeader.Text = "Admin Settings:";
            // 
            // EndMessageHeader
            // 
            this.EndMessageHeader.AutoSize = true;
            this.EndMessageHeader.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndMessageHeader.ForeColor = System.Drawing.Color.White;
            this.EndMessageHeader.Location = new System.Drawing.Point(747, 338);
            this.EndMessageHeader.Margin = new System.Windows.Forms.Padding(0);
            this.EndMessageHeader.Name = "EndMessageHeader";
            this.EndMessageHeader.Size = new System.Drawing.Size(371, 37);
            this.EndMessageHeader.TabIndex = 22;
            this.EndMessageHeader.Text = "Custom End Message:";
            // 
            // MessageInput
            // 
            this.MessageInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageInput.Font = new System.Drawing.Font("Lucida Sans", 30.75F);
            this.MessageInput.Location = new System.Drawing.Point(754, 441);
            this.MessageInput.Margin = new System.Windows.Forms.Padding(0);
            this.MessageInput.MaxLength = 128;
            this.MessageInput.Name = "MessageInput";
            this.MessageInput.Size = new System.Drawing.Size(552, 50);
            this.MessageInput.TabIndex = 24;
            this.MessageInput.Text = "";
            this.MessageInput.Click += new System.EventHandler(this.MessageInput_Click);
            this.MessageInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MessageInput_KeyUp);
            // 
            // FontSizeInput
            // 
            this.FontSizeInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FontSizeInput.Font = new System.Drawing.Font("Lucida Sans", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontSizeInput.Location = new System.Drawing.Point(1323, 441);
            this.FontSizeInput.Maximum = new decimal(new int[] {
            44,
            0,
            0,
            0});
            this.FontSizeInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FontSizeInput.Name = "FontSizeInput";
            this.FontSizeInput.Size = new System.Drawing.Size(68, 51);
            this.FontSizeInput.TabIndex = 25;
            this.FontSizeInput.Value = new decimal(new int[] {
            44,
            0,
            0,
            0});
            // 
            // MessageHeader
            // 
            this.MessageHeader.AutoSize = true;
            this.MessageHeader.Font = new System.Drawing.Font("Lucida Sans", 16F, System.Drawing.FontStyle.Bold);
            this.MessageHeader.ForeColor = System.Drawing.Color.White;
            this.MessageHeader.Location = new System.Drawing.Point(749, 412);
            this.MessageHeader.Name = "MessageHeader";
            this.MessageHeader.Size = new System.Drawing.Size(115, 25);
            this.MessageHeader.TabIndex = 26;
            this.MessageHeader.Text = "Message:";
            // 
            // FontSizeLabel
            // 
            this.FontSizeLabel.AutoSize = true;
            this.FontSizeLabel.Font = new System.Drawing.Font("Lucida Sans", 16F, System.Drawing.FontStyle.Bold);
            this.FontSizeLabel.ForeColor = System.Drawing.Color.White;
            this.FontSizeLabel.Location = new System.Drawing.Point(1309, 412);
            this.FontSizeLabel.Name = "FontSizeLabel";
            this.FontSizeLabel.Size = new System.Drawing.Size(117, 25);
            this.FontSizeLabel.TabIndex = 27;
            this.FontSizeLabel.Text = "Font Size";
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PreviewBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.PreviewBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewBtn.ForeColor = System.Drawing.Color.White;
            this.PreviewBtn.Location = new System.Drawing.Point(745, 475);
            this.PreviewBtn.Margin = new System.Windows.Forms.Padding(0);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(170, 44);
            this.PreviewBtn.TabIndex = 28;
            this.PreviewBtn.Text = "Preview";
            this.PreviewBtn.UseVisualStyleBackColor = false;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.SaveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.White;
            this.SaveBtn.Location = new System.Drawing.Point(928, 475);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(170, 44);
            this.SaveBtn.TabIndex = 29;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // AlreadyExists
            // 
            this.AlreadyExists.AutoSize = true;
            this.AlreadyExists.Font = new System.Drawing.Font("Lucida Sans", 16F, System.Drawing.FontStyle.Bold);
            this.AlreadyExists.ForeColor = System.Drawing.Color.Red;
            this.AlreadyExists.Location = new System.Drawing.Point(860, 412);
            this.AlreadyExists.Name = "AlreadyExists";
            this.AlreadyExists.Size = new System.Drawing.Size(278, 25);
            this.AlreadyExists.TabIndex = 30;
            this.AlreadyExists.Text = "Message already exists.";
            // 
            // NoMessage
            // 
            this.NoMessage.AutoSize = true;
            this.NoMessage.Font = new System.Drawing.Font("Lucida Sans", 16F, System.Drawing.FontStyle.Bold);
            this.NoMessage.ForeColor = System.Drawing.Color.Red;
            this.NoMessage.Location = new System.Drawing.Point(860, 412);
            this.NoMessage.Name = "NoMessage";
            this.NoMessage.Size = new System.Drawing.Size(281, 25);
            this.NoMessage.TabIndex = 31;
            this.NoMessage.Text = "Please enter a message.";
            // 
            // NoOption
            // 
            this.NoOption.AutoSize = true;
            this.NoOption.Font = new System.Drawing.Font("Lucida Sans", 16F, System.Drawing.FontStyle.Bold);
            this.NoOption.ForeColor = System.Drawing.Color.Red;
            this.NoOption.Location = new System.Drawing.Point(860, 412);
            this.NoOption.Name = "NoOption";
            this.NoOption.Size = new System.Drawing.Size(393, 25);
            this.NoOption.TabIndex = 32;
            this.NoOption.Text = "Please select a message category.";
            // 
            // TextView
            // 
            this.TextView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.TextView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextView.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextView.ForeColor = System.Drawing.Color.White;
            this.TextView.Location = new System.Drawing.Point(1141, 344);
            this.TextView.Margin = new System.Windows.Forms.Padding(0);
            this.TextView.Name = "TextView";
            this.TextView.Size = new System.Drawing.Size(266, 44);
            this.TextView.TabIndex = 33;
            this.TextView.Text = "See Existing Messages";
            this.TextView.UseVisualStyleBackColor = false;
            this.TextView.Click += new System.EventHandler(this.FileView_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.TextView);
            this.Controls.Add(this.NoOption);
            this.Controls.Add(this.NoMessage);
            this.Controls.Add(this.AlreadyExists);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.PreviewBtn);
            this.Controls.Add(this.FontSizeLabel);
            this.Controls.Add(this.MessageHeader);
            this.Controls.Add(this.FontSizeInput);
            this.Controls.Add(this.MessageInput);
            this.Controls.Add(this.EndMessageHeader);
            this.Controls.Add(this.MessageSelection);
            this.Controls.Add(this.ResetLeaderboard);
            this.Controls.Add(this.DeleteUsrDat);
            this.Controls.Add(this.AdminHeader);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.VolumeHeader);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.SettingsHeader);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FontSizeInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SettingsHeader;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Label VolumeHeader;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button DeleteUsrDat;
        private System.Windows.Forms.Button ResetLeaderboard;
        private System.Windows.Forms.ComboBox MessageSelection;
        private System.Windows.Forms.Label AdminHeader;
        private System.Windows.Forms.Label EndMessageHeader;
        private System.Windows.Forms.RichTextBox MessageInput;
        private System.Windows.Forms.NumericUpDown FontSizeInput;
        private System.Windows.Forms.Label MessageHeader;
        private System.Windows.Forms.Label FontSizeLabel;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label AlreadyExists;
        private System.Windows.Forms.Label NoMessage;
        private System.Windows.Forms.Label NoOption;
        private System.Windows.Forms.Button TextView;
    }
}