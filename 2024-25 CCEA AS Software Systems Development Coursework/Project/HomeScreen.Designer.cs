using System.Windows.Forms;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class HomeScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
            this.HomePanel = new System.Windows.Forms.Panel();
            this.BackBtn = new System.Windows.Forms.Button();
            this.QuestionUI = new System.Windows.Forms.Label();
            this.MuteToggle = new System.Windows.Forms.Button();
            this.CheckAns = new System.Windows.Forms.Button();
            this.TutorialBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HomePanel
            // 
            this.HomePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.HomePanel.Location = new System.Drawing.Point(0, 0);
            this.HomePanel.Name = "HomePanel";
            this.HomePanel.Size = new System.Drawing.Size(1600, 750);
            this.HomePanel.TabIndex = 0;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Location = new System.Drawing.Point(1485, 770);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(68, 68);
            this.BackBtn.TabIndex = 1;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_click);
            // 
            // QuestionUI
            // 
            this.QuestionUI.Font = new System.Drawing.Font("Lucida Sans", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionUI.ForeColor = System.Drawing.Color.White;
            this.QuestionUI.Location = new System.Drawing.Point(33, 770);
            this.QuestionUI.Name = "QuestionUI";
            this.QuestionUI.Size = new System.Drawing.Size(836, 68);
            this.QuestionUI.TabIndex = 3;
            this.QuestionUI.Text = "Question X\r\nabcdefghijklmnopqrstuvwxyz";
            // 
            // MuteToggle
            // 
            this.MuteToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.MuteToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MuteToggle.FlatAppearance.BorderSize = 0;
            this.MuteToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MuteToggle.Image = ((System.Drawing.Image)(resources.GetObject("MuteToggle.Image")));
            this.MuteToggle.Location = new System.Drawing.Point(1370, 770);
            this.MuteToggle.Name = "MuteToggle";
            this.MuteToggle.Size = new System.Drawing.Size(68, 68);
            this.MuteToggle.TabIndex = 2;
            this.MuteToggle.UseVisualStyleBackColor = false;
            this.MuteToggle.Click += new System.EventHandler(this.MuteToggle_click);
            // 
            // CheckAns
            // 
            this.CheckAns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.CheckAns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckAns.FlatAppearance.BorderSize = 0;
            this.CheckAns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckAns.Image = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.Check64;
            this.CheckAns.Location = new System.Drawing.Point(1255, 770);
            this.CheckAns.Name = "CheckAns";
            this.CheckAns.Size = new System.Drawing.Size(68, 68);
            this.CheckAns.TabIndex = 4;
            this.CheckAns.UseVisualStyleBackColor = false;
            // 
            // TutorialBtn
            // 
            this.TutorialBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.TutorialBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TutorialBtn.FlatAppearance.BorderSize = 0;
            this.TutorialBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TutorialBtn.Image = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.Tutorial64;
            this.TutorialBtn.Location = new System.Drawing.Point(1255, 770);
            this.TutorialBtn.Name = "TutorialBtn";
            this.TutorialBtn.Size = new System.Drawing.Size(68, 68);
            this.TutorialBtn.TabIndex = 5;
            this.TutorialBtn.UseVisualStyleBackColor = false;
            this.TutorialBtn.Click += new System.EventHandler(this.TutorialBtn_Click);
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.TutorialBtn);
            this.Controls.Add(this.CheckAns);
            this.Controls.Add(this.QuestionUI);
            this.Controls.Add(this.MuteToggle);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.HomePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1600, 900);
            this.MinimumSize = new System.Drawing.Size(1600, 900);
            this.Name = "HomeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.ShowWelcome);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HomePanel;
        private System.Windows.Forms.Button BackBtn;
        private Button MuteToggle;
        private Label QuestionUI;
        private Button CheckAns;
        private Button TutorialBtn;
    }
}