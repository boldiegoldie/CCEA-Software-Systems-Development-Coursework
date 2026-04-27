namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.LoginHeader = new System.Windows.Forms.Label();
            this.AccountInfo = new System.Windows.Forms.Label();
            this.UsrnameHeader = new System.Windows.Forms.Label();
            this.UsrnameInput = new System.Windows.Forms.RichTextBox();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.Wrong = new System.Windows.Forms.Label();
            this.PassShow = new System.Windows.Forms.Button();
            this.PasswordHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginHeader
            // 
            this.LoginHeader.Font = new System.Drawing.Font("Lucida Sans", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginHeader.ForeColor = System.Drawing.Color.White;
            this.LoginHeader.Location = new System.Drawing.Point(20, 30);
            this.LoginHeader.Name = "LoginHeader";
            this.LoginHeader.Size = new System.Drawing.Size(707, 80);
            this.LoginHeader.TabIndex = 2;
            this.LoginHeader.Text = "Login to your Account";
            // 
            // AccountInfo
            // 
            this.AccountInfo.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountInfo.ForeColor = System.Drawing.Color.White;
            this.AccountInfo.Location = new System.Drawing.Point(27, 290);
            this.AccountInfo.Name = "AccountInfo";
            this.AccountInfo.Size = new System.Drawing.Size(659, 202);
            this.AccountInfo.TabIndex = 18;
            this.AccountInfo.Text = resources.GetString("AccountInfo.Text");
            // 
            // UsrnameHeader
            // 
            this.UsrnameHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsrnameHeader.AutoSize = true;
            this.UsrnameHeader.Font = new System.Drawing.Font("Lucida Sans", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrnameHeader.ForeColor = System.Drawing.Color.White;
            this.UsrnameHeader.Location = new System.Drawing.Point(1162, 275);
            this.UsrnameHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsrnameHeader.Name = "UsrnameHeader";
            this.UsrnameHeader.Size = new System.Drawing.Size(119, 23);
            this.UsrnameHeader.TabIndex = 25;
            this.UsrnameHeader.Text = "Username:";
            // 
            // UsrnameInput
            // 
            this.UsrnameInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsrnameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsrnameInput.Font = new System.Drawing.Font("Lucida Sans", 30.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrnameInput.Location = new System.Drawing.Point(1166, 300);
            this.UsrnameInput.Margin = new System.Windows.Forms.Padding(2);
            this.UsrnameInput.MaxLength = 12;
            this.UsrnameInput.Name = "UsrnameInput";
            this.UsrnameInput.Size = new System.Drawing.Size(340, 50);
            this.UsrnameInput.TabIndex = 1;
            this.UsrnameInput.Text = "";
            this.UsrnameInput.Enter += new System.EventHandler(this.UsrnameInput_enter);
            // 
            // PasswordInput
            // 
            this.PasswordInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordInput.Location = new System.Drawing.Point(1166, 386);
            this.PasswordInput.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordInput.Multiline = true;
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.PasswordChar = '*';
            this.PasswordInput.Size = new System.Drawing.Size(340, 50);
            this.PasswordInput.TabIndex = 2;
            this.PasswordInput.Enter += new System.EventHandler(this.PasswordInput_enter);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.LoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.Color.White;
            this.LoginBtn.Location = new System.Drawing.Point(1166, 454);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(2);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(340, 87);
            this.LoginBtn.TabIndex = 3;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_click);
            // 
            // Wrong
            // 
            this.Wrong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Wrong.AutoSize = true;
            this.Wrong.BackColor = System.Drawing.Color.Transparent;
            this.Wrong.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wrong.ForeColor = System.Drawing.Color.Red;
            this.Wrong.Location = new System.Drawing.Point(1187, 557);
            this.Wrong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Wrong.Name = "Wrong";
            this.Wrong.Size = new System.Drawing.Size(294, 18);
            this.Wrong.TabIndex = 31;
            this.Wrong.Text = "Username or password is incorrect.";
            // 
            // PassShow
            // 
            this.PassShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.PassShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PassShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PassShow.Image = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.PassHide64;
            this.PassShow.Location = new System.Drawing.Point(1522, 406);
            this.PassShow.Name = "PassShow";
            this.PassShow.Size = new System.Drawing.Size(50, 50);
            this.PassShow.TabIndex = 32;
            this.PassShow.UseVisualStyleBackColor = false;
            this.PassShow.Click += new System.EventHandler(this.PassShow_Click);
            // 
            // PasswordHeader
            // 
            this.PasswordHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordHeader.AutoSize = true;
            this.PasswordHeader.Font = new System.Drawing.Font("Lucida Sans", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordHeader.ForeColor = System.Drawing.Color.White;
            this.PasswordHeader.Location = new System.Drawing.Point(1162, 361);
            this.PasswordHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordHeader.Name = "PasswordHeader";
            this.PasswordHeader.Size = new System.Drawing.Size(114, 23);
            this.PasswordHeader.TabIndex = 26;
            this.PasswordHeader.Text = "Password:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.PassShow);
            this.Controls.Add(this.Wrong);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.PasswordHeader);
            this.Controls.Add(this.UsrnameHeader);
            this.Controls.Add(this.UsrnameInput);
            this.Controls.Add(this.AccountInfo);
            this.Controls.Add(this.LoginHeader);
            this.Name = "Login";
            this.Text = "Logincs";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginHeader;
        private System.Windows.Forms.Label AccountInfo;
        private System.Windows.Forms.Label UsrnameHeader;
        private System.Windows.Forms.RichTextBox UsrnameInput;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label Wrong;
        private System.Windows.Forms.Button PassShow;
        private System.Windows.Forms.Label PasswordHeader;
    }
}