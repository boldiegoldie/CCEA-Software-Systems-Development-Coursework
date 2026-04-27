namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class Tutorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tutorial));
            this.Header = new System.Windows.Forms.Label();
            this.TutorialTxt = new System.Windows.Forms.Label();
            this.GoFowardBtn = new System.Windows.Forms.PictureBox();
            this.GoBackBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GoFowardBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoBackBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.Font = new System.Drawing.Font("Lucida Sans", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.White;
            this.Header.Location = new System.Drawing.Point(20, 30);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1274, 71);
            this.Header.TabIndex = 12;
            this.Header.Text = "Making Questions: Multiple Choice";
            // 
            // TutorialTxt
            // 
            this.TutorialTxt.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TutorialTxt.ForeColor = System.Drawing.Color.White;
            this.TutorialTxt.Location = new System.Drawing.Point(30, 255);
            this.TutorialTxt.Name = "TutorialTxt";
            this.TutorialTxt.Size = new System.Drawing.Size(649, 256);
            this.TutorialTxt.TabIndex = 15;
            this.TutorialTxt.Text = resources.GetString("TutorialTxt.Text");
            // 
            // GoFowardBtn
            // 
            this.GoFowardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.GoFowardBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoFowardBtn.Image = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.GoFoward;
            this.GoFowardBtn.Location = new System.Drawing.Point(1508, 538);
            this.GoFowardBtn.Name = "GoFowardBtn";
            this.GoFowardBtn.Size = new System.Drawing.Size(64, 64);
            this.GoFowardBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.GoFowardBtn.TabIndex = 17;
            this.GoFowardBtn.TabStop = false;
            this.GoFowardBtn.Click += new System.EventHandler(this.GoFoward_Click);
            // 
            // GoBackBtn
            // 
            this.GoBackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.GoBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoBackBtn.Image = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.BackButton64;
            this.GoBackBtn.Location = new System.Drawing.Point(1508, 187);
            this.GoBackBtn.Name = "GoBackBtn";
            this.GoBackBtn.Size = new System.Drawing.Size(64, 64);
            this.GoBackBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.GoBackBtn.TabIndex = 14;
            this.GoBackBtn.TabStop = false;
            this.GoBackBtn.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.DragDrop;
            this.pictureBox1.Location = new System.Drawing.Point(685, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.UI_Purple;
            this.pictureBox3.Location = new System.Drawing.Point(1491, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 786);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // Tutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.GoFowardBtn);
            this.Controls.Add(this.TutorialTxt);
            this.Controls.Add(this.GoBackBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.pictureBox3);
            this.Name = "Tutorial";
            this.Text = "Tutorial";
            this.Load += new System.EventHandler(this.Tutorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GoFowardBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoBackBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox GoBackBtn;
        private System.Windows.Forms.Label TutorialTxt;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox GoFowardBtn;
    }
}