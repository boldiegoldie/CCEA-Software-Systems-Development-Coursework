
namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class CreateAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccount));
            this.UsrnameInput = new System.Windows.Forms.RichTextBox();
            this.UsrSymbol = new System.Windows.Forms.Label();
            this.UsrnameHeader = new System.Windows.Forms.Label();
            this.PasswordHeader = new System.Windows.Forms.Label();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.NoUsrname = new System.Windows.Forms.Label();
            this.NoPassword = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.NoSymbol = new System.Windows.Forms.Label();
            this.NotMixed = new System.Windows.Forms.Label();
            this.NoNumber = new System.Windows.Forms.Label();
            this.TooShort = new System.Windows.Forms.Label();
            this.CreateHeader = new System.Windows.Forms.Label();
            this.PassRequirements = new System.Windows.Forms.Label();
            this.ConfirmHeader = new System.Windows.Forms.Label();
            this.NoMatch = new System.Windows.Forms.Label();
            this.ConfirmPassword = new System.Windows.Forms.TextBox();
            this.UsrTaken = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PassShow = new System.Windows.Forms.Button();
            this.UsrTooShort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UsrnameInput
            // 
            this.UsrnameInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsrnameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsrnameInput.Font = new System.Drawing.Font("Lucida Sans", 30.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrnameInput.Location = new System.Drawing.Point(1166, 244);
            this.UsrnameInput.Margin = new System.Windows.Forms.Padding(2);
            this.UsrnameInput.MaxLength = 12;
            this.UsrnameInput.Name = "UsrnameInput";
            this.UsrnameInput.Size = new System.Drawing.Size(340, 50);
            this.UsrnameInput.TabIndex = 1;
            this.UsrnameInput.Text = "";
            this.UsrnameInput.Enter += new System.EventHandler(this.UsrnameInput_Click);
            // 
            // UsrSymbol
            // 
            this.UsrSymbol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsrSymbol.AutoSize = true;
            this.UsrSymbol.BackColor = System.Drawing.Color.Transparent;
            this.UsrSymbol.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrSymbol.ForeColor = System.Drawing.Color.Red;
            this.UsrSymbol.Location = new System.Drawing.Point(1279, 226);
            this.UsrSymbol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsrSymbol.Name = "UsrSymbol";
            this.UsrSymbol.Size = new System.Drawing.Size(227, 15);
            this.UsrSymbol.TabIndex = 4;
            this.UsrSymbol.Text = "Usernane cannot have a symbol.";
            // 
            // UsrnameHeader
            // 
            this.UsrnameHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsrnameHeader.AutoSize = true;
            this.UsrnameHeader.Font = new System.Drawing.Font("Lucida Sans", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrnameHeader.ForeColor = System.Drawing.Color.White;
            this.UsrnameHeader.Location = new System.Drawing.Point(1162, 219);
            this.UsrnameHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsrnameHeader.Name = "UsrnameHeader";
            this.UsrnameHeader.Size = new System.Drawing.Size(119, 23);
            this.UsrnameHeader.TabIndex = 6;
            this.UsrnameHeader.Text = "Username:";
            // 
            // PasswordHeader
            // 
            this.PasswordHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordHeader.AutoSize = true;
            this.PasswordHeader.Font = new System.Drawing.Font("Lucida Sans", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordHeader.ForeColor = System.Drawing.Color.White;
            this.PasswordHeader.Location = new System.Drawing.Point(1162, 305);
            this.PasswordHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordHeader.Name = "PasswordHeader";
            this.PasswordHeader.Size = new System.Drawing.Size(114, 23);
            this.PasswordHeader.TabIndex = 7;
            this.PasswordHeader.Text = "Password:";
            // 
            // CreateBtn
            // 
            this.CreateBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.CreateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateBtn.ForeColor = System.Drawing.Color.White;
            this.CreateBtn.Location = new System.Drawing.Point(1166, 488);
            this.CreateBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(340, 87);
            this.CreateBtn.TabIndex = 4;
            this.CreateBtn.Text = "Create Account";
            this.CreateBtn.UseVisualStyleBackColor = false;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // NoUsrname
            // 
            this.NoUsrname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NoUsrname.AutoSize = true;
            this.NoUsrname.BackColor = System.Drawing.Color.Transparent;
            this.NoUsrname.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoUsrname.ForeColor = System.Drawing.Color.Red;
            this.NoUsrname.Location = new System.Drawing.Point(1331, 226);
            this.NoUsrname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NoUsrname.Name = "NoUsrname";
            this.NoUsrname.Size = new System.Drawing.Size(175, 15);
            this.NoUsrname.TabIndex = 9;
            this.NoUsrname.Text = "Please enter a username.";
            // 
            // NoPassword
            // 
            this.NoPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NoPassword.AutoSize = true;
            this.NoPassword.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.NoPassword.ForeColor = System.Drawing.Color.Red;
            this.NoPassword.Location = new System.Drawing.Point(1330, 313);
            this.NoPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NoPassword.Name = "NoPassword";
            this.NoPassword.Size = new System.Drawing.Size(176, 15);
            this.NoPassword.TabIndex = 10;
            this.NoPassword.Text = "Please enter a password.";
            // 
            // PasswordInput
            // 
            this.PasswordInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordInput.Location = new System.Drawing.Point(1166, 330);
            this.PasswordInput.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordInput.Multiline = true;
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.PasswordChar = '*';
            this.PasswordInput.Size = new System.Drawing.Size(340, 50);
            this.PasswordInput.TabIndex = 2;
            this.PasswordInput.Enter += new System.EventHandler(this.PasswordInput_Click);
            // 
            // NoSymbol
            // 
            this.NoSymbol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NoSymbol.AutoSize = true;
            this.NoSymbol.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.NoSymbol.ForeColor = System.Drawing.Color.Red;
            this.NoSymbol.Location = new System.Drawing.Point(1271, 312);
            this.NoSymbol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NoSymbol.Name = "NoSymbol";
            this.NoSymbol.Size = new System.Drawing.Size(235, 15);
            this.NoSymbol.TabIndex = 12;
            this.NoSymbol.Text = "Password must contain a symbol.";
            // 
            // NotMixed
            // 
            this.NotMixed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NotMixed.AutoSize = true;
            this.NotMixed.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.NotMixed.ForeColor = System.Drawing.Color.Red;
            this.NotMixed.Location = new System.Drawing.Point(1292, 312);
            this.NotMixed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NotMixed.Name = "NotMixed";
            this.NotMixed.Size = new System.Drawing.Size(214, 15);
            this.NotMixed.TabIndex = 13;
            this.NotMixed.Text = "Password must be mixed case.";
            // 
            // NoNumber
            // 
            this.NoNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NoNumber.AutoSize = true;
            this.NoNumber.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.NoNumber.ForeColor = System.Drawing.Color.Red;
            this.NoNumber.Location = new System.Drawing.Point(1270, 313);
            this.NoNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NoNumber.Name = "NoNumber";
            this.NoNumber.Size = new System.Drawing.Size(236, 15);
            this.NoNumber.TabIndex = 14;
            this.NoNumber.Text = "Password must contain a number.";
            // 
            // TooShort
            // 
            this.TooShort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TooShort.AutoSize = true;
            this.TooShort.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.TooShort.ForeColor = System.Drawing.Color.Red;
            this.TooShort.Location = new System.Drawing.Point(1346, 313);
            this.TooShort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TooShort.Name = "TooShort";
            this.TooShort.Size = new System.Drawing.Size(160, 15);
            this.TooShort.TabIndex = 15;
            this.TooShort.Text = "Password is too short.";
            // 
            // CreateHeader
            // 
            this.CreateHeader.Font = new System.Drawing.Font("Lucida Sans", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateHeader.ForeColor = System.Drawing.Color.White;
            this.CreateHeader.Location = new System.Drawing.Point(20, 30);
            this.CreateHeader.Name = "CreateHeader";
            this.CreateHeader.Size = new System.Drawing.Size(633, 80);
            this.CreateHeader.TabIndex = 16;
            this.CreateHeader.Text = "Create an Account";
            // 
            // PassRequirements
            // 
            this.PassRequirements.Font = new System.Drawing.Font("Lucida Sans", 18.25F, System.Drawing.FontStyle.Bold);
            this.PassRequirements.ForeColor = System.Drawing.Color.White;
            this.PassRequirements.Location = new System.Drawing.Point(27, 244);
            this.PassRequirements.Name = "PassRequirements";
            this.PassRequirements.Size = new System.Drawing.Size(659, 290);
            this.PassRequirements.TabIndex = 17;
            this.PassRequirements.Text = resources.GetString("PassRequirements.Text");
            // 
            // ConfirmHeader
            // 
            this.ConfirmHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConfirmHeader.AutoSize = true;
            this.ConfirmHeader.Font = new System.Drawing.Font("Lucida Sans", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmHeader.ForeColor = System.Drawing.Color.White;
            this.ConfirmHeader.Location = new System.Drawing.Point(1162, 392);
            this.ConfirmHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConfirmHeader.Name = "ConfirmHeader";
            this.ConfirmHeader.Size = new System.Drawing.Size(204, 23);
            this.ConfirmHeader.TabIndex = 19;
            this.ConfirmHeader.Text = "Confirm Password:";
            // 
            // NoMatch
            // 
            this.NoMatch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NoMatch.AutoSize = true;
            this.NoMatch.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold);
            this.NoMatch.ForeColor = System.Drawing.Color.Red;
            this.NoMatch.Location = new System.Drawing.Point(1360, 399);
            this.NoMatch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NoMatch.Name = "NoMatch";
            this.NoMatch.Size = new System.Drawing.Size(169, 15);
            this.NoMatch.TabIndex = 20;
            this.NoMatch.Text = "Passwords don\'t match.";
            // 
            // ConfirmPassword
            // 
            this.ConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPassword.Location = new System.Drawing.Point(1166, 417);
            this.ConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.ConfirmPassword.Multiline = true;
            this.ConfirmPassword.Name = "ConfirmPassword";
            this.ConfirmPassword.PasswordChar = '*';
            this.ConfirmPassword.Size = new System.Drawing.Size(340, 50);
            this.ConfirmPassword.TabIndex = 3;
            this.ConfirmPassword.Enter += new System.EventHandler(this.ConfirmPassword_Click);
            // 
            // UsrTaken
            // 
            this.UsrTaken.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsrTaken.AutoSize = true;
            this.UsrTaken.BackColor = System.Drawing.Color.Transparent;
            this.UsrTaken.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrTaken.ForeColor = System.Drawing.Color.Red;
            this.UsrTaken.Location = new System.Drawing.Point(1375, 226);
            this.UsrTaken.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsrTaken.Name = "UsrTaken";
            this.UsrTaken.Size = new System.Drawing.Size(135, 15);
            this.UsrTaken.TabIndex = 21;
            this.UsrTaken.Text = "Username is taken.";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // PassShow
            // 
            this.PassShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.PassShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PassShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PassShow.Image = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.PassHide64;
            this.PassShow.Location = new System.Drawing.Point(1522, 350);
            this.PassShow.Name = "PassShow";
            this.PassShow.Size = new System.Drawing.Size(50, 50);
            this.PassShow.TabIndex = 22;
            this.PassShow.UseVisualStyleBackColor = false;
            this.PassShow.Click += new System.EventHandler(this.PassShow_Click);
            // 
            // UsrTooShort
            // 
            this.UsrTooShort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsrTooShort.AutoSize = true;
            this.UsrTooShort.BackColor = System.Drawing.Color.Transparent;
            this.UsrTooShort.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrTooShort.ForeColor = System.Drawing.Color.Red;
            this.UsrTooShort.Location = new System.Drawing.Point(1344, 227);
            this.UsrTooShort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsrTooShort.Name = "UsrTooShort";
            this.UsrTooShort.Size = new System.Drawing.Size(162, 15);
            this.UsrTooShort.TabIndex = 23;
            this.UsrTooShort.Text = "Username is too short.";
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.TooShort);
            this.Controls.Add(this.UsrTooShort);
            this.Controls.Add(this.PassShow);
            this.Controls.Add(this.NoMatch);
            this.Controls.Add(this.ConfirmHeader);
            this.Controls.Add(this.ConfirmPassword);
            this.Controls.Add(this.PassRequirements);
            this.Controls.Add(this.CreateHeader);
            this.Controls.Add(this.NoNumber);
            this.Controls.Add(this.NotMixed);
            this.Controls.Add(this.NoSymbol);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.NoPassword);
            this.Controls.Add(this.CreateBtn);
            this.Controls.Add(this.PasswordHeader);
            this.Controls.Add(this.UsrnameHeader);
            this.Controls.Add(this.UsrnameInput);
            this.Controls.Add(this.UsrTaken);
            this.Controls.Add(this.UsrSymbol);
            this.Controls.Add(this.NoUsrname);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "CreateAccount";
            this.Text = "    ";
            this.Enter += new System.EventHandler(this.PasswordInput_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label UsrSymbol;
        private System.Windows.Forms.Label UsrnameHeader;
        private System.Windows.Forms.Label PasswordHeader;
        private System.Windows.Forms.RichTextBox UsrnameInput;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Label NoUsrname;
        private System.Windows.Forms.Label NoPassword;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label NoSymbol;
        private System.Windows.Forms.Label NotMixed;
        private System.Windows.Forms.Label NoNumber;
        private System.Windows.Forms.Label TooShort;
        private System.Windows.Forms.Label CreateHeader;
        private System.Windows.Forms.Label PassRequirements;
        private System.Windows.Forms.Label ConfirmHeader;
        private System.Windows.Forms.Label NoMatch;
        private System.Windows.Forms.TextBox ConfirmPassword;
        private System.Windows.Forms.Label UsrTaken;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Button PassShow;
        private System.Windows.Forms.Label UsrTooShort;
    }
}

