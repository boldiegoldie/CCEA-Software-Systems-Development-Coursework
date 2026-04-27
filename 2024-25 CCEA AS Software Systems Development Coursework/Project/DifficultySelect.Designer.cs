namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class DifficultySelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DifficultySelect));
            this.DifficultyHeader = new System.Windows.Forms.Label();
            this.NormalBtn = new System.Windows.Forms.Button();
            this.hard_btn = new System.Windows.Forms.Button();
            this.EasyBtn = new System.Windows.Forms.Button();
            this.DifficultyInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DifficultyHeader
            // 
            this.DifficultyHeader.Font = new System.Drawing.Font("Lucida Sans", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyHeader.ForeColor = System.Drawing.Color.White;
            this.DifficultyHeader.Location = new System.Drawing.Point(20, 30);
            this.DifficultyHeader.Name = "DifficultyHeader";
            this.DifficultyHeader.Size = new System.Drawing.Size(633, 80);
            this.DifficultyHeader.TabIndex = 1;
            this.DifficultyHeader.Text = "Select Difficulty";
            // 
            // NormalBtn
            // 
            this.NormalBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.NormalBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NormalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NormalBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NormalBtn.ForeColor = System.Drawing.Color.White;
            this.NormalBtn.Location = new System.Drawing.Point(1172, 332);
            this.NormalBtn.Name = "NormalBtn";
            this.NormalBtn.Size = new System.Drawing.Size(349, 87);
            this.NormalBtn.TabIndex = 3;
            this.NormalBtn.Text = "Normal  :/";
            this.NormalBtn.UseVisualStyleBackColor = false;
            this.NormalBtn.Click += new System.EventHandler(this.NormalBtn_click);
            // 
            // hard_btn
            // 
            this.hard_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.hard_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hard_btn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hard_btn.ForeColor = System.Drawing.Color.White;
            this.hard_btn.Location = new System.Drawing.Point(1172, 522);
            this.hard_btn.Name = "hard_btn";
            this.hard_btn.Size = new System.Drawing.Size(349, 87);
            this.hard_btn.TabIndex = 4;
            this.hard_btn.Text = "Hard  >:(";
            this.hard_btn.UseVisualStyleBackColor = false;
            this.hard_btn.Click += new System.EventHandler(this.HardBtn_Click);
            // 
            // EasyBtn
            // 
            this.EasyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.EasyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EasyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EasyBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyBtn.ForeColor = System.Drawing.Color.White;
            this.EasyBtn.Location = new System.Drawing.Point(1172, 142);
            this.EasyBtn.Name = "EasyBtn";
            this.EasyBtn.Size = new System.Drawing.Size(349, 87);
            this.EasyBtn.TabIndex = 5;
            this.EasyBtn.Text = "Easy  :D";
            this.EasyBtn.UseVisualStyleBackColor = false;
            this.EasyBtn.Click += new System.EventHandler(this.EasyBtn_click);
            // 
            // DifficultyInfo
            // 
            this.DifficultyInfo.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyInfo.ForeColor = System.Drawing.Color.White;
            this.DifficultyInfo.Location = new System.Drawing.Point(26, 173);
            this.DifficultyInfo.Name = "DifficultyInfo";
            this.DifficultyInfo.Size = new System.Drawing.Size(1060, 387);
            this.DifficultyInfo.TabIndex = 6;
            this.DifficultyInfo.Text = resources.GetString("DifficultyInfo.Text");
            // 
            // DifficultySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.DifficultyInfo);
            this.Controls.Add(this.EasyBtn);
            this.Controls.Add(this.hard_btn);
            this.Controls.Add(this.NormalBtn);
            this.Controls.Add(this.DifficultyHeader);
            this.Name = "DifficultySelect";
            this.Text = "Change Difficulty";
            this.Load += new System.EventHandler(this.Dfficulty_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DifficultyHeader;
        private System.Windows.Forms.Button NormalBtn;
        private System.Windows.Forms.Button hard_btn;
        private System.Windows.Forms.Button EasyBtn;
        private System.Windows.Forms.Label DifficultyInfo;
    }
}