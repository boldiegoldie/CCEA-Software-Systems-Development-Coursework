namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class WelcomeScreen
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
            this.CreateAccountBtn = new System.Windows.Forms.Button();
            this.WelcomeHeader = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateAccountBtn
            // 
            this.CreateAccountBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.CreateAccountBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateAccountBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccountBtn.ForeColor = System.Drawing.Color.White;
            this.CreateAccountBtn.Location = new System.Drawing.Point(1172, 224);
            this.CreateAccountBtn.Name = "CreateAccountBtn";
            this.CreateAccountBtn.Size = new System.Drawing.Size(349, 87);
            this.CreateAccountBtn.TabIndex = 0;
            this.CreateAccountBtn.Text = "Create Account";
            this.CreateAccountBtn.UseVisualStyleBackColor = false;
            this.CreateAccountBtn.Click += new System.EventHandler(this.CreateAccount_click);
            // 
            // WelcomeHeader
            // 
            this.WelcomeHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WelcomeHeader.Font = new System.Drawing.Font("Lucida Sans", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeHeader.ForeColor = System.Drawing.Color.White;
            this.WelcomeHeader.Location = new System.Drawing.Point(20, 30);
            this.WelcomeHeader.Name = "WelcomeHeader";
            this.WelcomeHeader.Size = new System.Drawing.Size(870, 153);
            this.WelcomeHeader.TabIndex = 1;
            this.WelcomeHeader.Text = "Welcome to \r\nThe Circuit Breaker Quiz";
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.LoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.Color.White;
            this.LoginBtn.Location = new System.Drawing.Point(1172, 490);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(349, 87);
            this.LoginBtn.TabIndex = 2;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_click);
            // 
            // WelcomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.WelcomeHeader);
            this.Controls.Add(this.CreateAccountBtn);
            this.Name = "WelcomeScreen";
            this.Text = "please work for the love of god please work";
            this.Load += new System.EventHandler(this.WelcomeScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateAccountBtn;
        private System.Windows.Forms.Label WelcomeHeader;
        private System.Windows.Forms.Button LoginBtn;
    }
}