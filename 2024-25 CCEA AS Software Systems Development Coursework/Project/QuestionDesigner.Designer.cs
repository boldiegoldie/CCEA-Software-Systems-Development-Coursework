namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    partial class QuestionDesigner
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
            this.Header = new System.Windows.Forms.Label();
            this.QuestionInput = new System.Windows.Forms.RichTextBox();
            this.FirstInput = new System.Windows.Forms.RichTextBox();
            this.SecondInput = new System.Windows.Forms.RichTextBox();
            this.ThirdInput = new System.Windows.Forms.RichTextBox();
            this.FourthInput = new System.Windows.Forms.RichTextBox();
            this.questionTypeSelector = new System.Windows.Forms.ComboBox();
            this.HardBtn = new System.Windows.Forms.Button();
            this.EasyBtn = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.SizeInput = new System.Windows.Forms.NumericUpDown();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.TextView = new System.Windows.Forms.Button();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.TrueBtn = new System.Windows.Forms.Button();
            this.FalseBtn = new System.Windows.Forms.Button();
            this.DummyTxtbox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SizeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.Font = new System.Drawing.Font("Lucida Sans", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.White;
            this.Header.Location = new System.Drawing.Point(20, 30);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1274, 139);
            this.Header.TabIndex = 13;
            this.Header.Text = "Question Designer";
            // 
            // QuestionInput
            // 
            this.QuestionInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QuestionInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuestionInput.Font = new System.Drawing.Font("Lucida Sans", 30.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionInput.ForeColor = System.Drawing.Color.Gainsboro;
            this.QuestionInput.Location = new System.Drawing.Point(730, 199);
            this.QuestionInput.Margin = new System.Windows.Forms.Padding(0);
            this.QuestionInput.MaxLength = 0;
            this.QuestionInput.Name = "QuestionInput";
            this.QuestionInput.Size = new System.Drawing.Size(680, 50);
            this.QuestionInput.TabIndex = 18;
            this.QuestionInput.Text = "Question";
            this.QuestionInput.Click += new System.EventHandler(this.QuestionInput_Click);
            this.QuestionInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuestionInput_KeyUp);
            // 
            // FirstInput
            // 
            this.FirstInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FirstInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FirstInput.Font = new System.Drawing.Font("Lucida Sans", 30.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FirstInput.Location = new System.Drawing.Point(730, 319);
            this.FirstInput.Margin = new System.Windows.Forms.Padding(0);
            this.FirstInput.MaxLength = 64;
            this.FirstInput.Name = "FirstInput";
            this.FirstInput.Size = new System.Drawing.Size(680, 50);
            this.FirstInput.TabIndex = 19;
            this.FirstInput.Text = "First Option";
            this.FirstInput.Click += new System.EventHandler(this.FirstInput_Click);
            this.FirstInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FirstInput_KeyPress);
            // 
            // SecondInput
            // 
            this.SecondInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SecondInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SecondInput.Font = new System.Drawing.Font("Lucida Sans", 30.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SecondInput.Location = new System.Drawing.Point(730, 383);
            this.SecondInput.Margin = new System.Windows.Forms.Padding(0);
            this.SecondInput.MaxLength = 64;
            this.SecondInput.Name = "SecondInput";
            this.SecondInput.Size = new System.Drawing.Size(680, 50);
            this.SecondInput.TabIndex = 20;
            this.SecondInput.Text = "Second Option";
            this.SecondInput.Click += new System.EventHandler(this.SecondInput_Click);
            this.SecondInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SecondInput_KeyUp);
            // 
            // ThirdInput
            // 
            this.ThirdInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ThirdInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ThirdInput.Font = new System.Drawing.Font("Lucida Sans", 30.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThirdInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ThirdInput.Location = new System.Drawing.Point(730, 447);
            this.ThirdInput.Margin = new System.Windows.Forms.Padding(0);
            this.ThirdInput.MaxLength = 64;
            this.ThirdInput.Name = "ThirdInput";
            this.ThirdInput.Size = new System.Drawing.Size(680, 50);
            this.ThirdInput.TabIndex = 21;
            this.ThirdInput.Text = "Third Option";
            this.ThirdInput.Click += new System.EventHandler(this.ThirdInput_Click);
            this.ThirdInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ThirdInput_KeyUp);
            // 
            // FourthInput
            // 
            this.FourthInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FourthInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FourthInput.Font = new System.Drawing.Font("Lucida Sans", 30.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourthInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FourthInput.Location = new System.Drawing.Point(730, 510);
            this.FourthInput.Margin = new System.Windows.Forms.Padding(0);
            this.FourthInput.MaxLength = 64;
            this.FourthInput.Name = "FourthInput";
            this.FourthInput.Size = new System.Drawing.Size(680, 50);
            this.FourthInput.TabIndex = 22;
            this.FourthInput.Text = "Fourth Option";
            this.FourthInput.Click += new System.EventHandler(this.FourthInput_Click);
            this.FourthInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FourthInput_KeyUp);
            // 
            // questionTypeSelector
            // 
            this.questionTypeSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.questionTypeSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.questionTypeSelector.Font = new System.Drawing.Font("Lucida Sans", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionTypeSelector.ForeColor = System.Drawing.Color.White;
            this.questionTypeSelector.FormattingEnabled = true;
            this.questionTypeSelector.Items.AddRange(new object[] {
            "Checkbox",
            "Fill in the Blank",
            "Multiple Choice",
            "True or False"});
            this.questionTypeSelector.Location = new System.Drawing.Point(42, 124);
            this.questionTypeSelector.Margin = new System.Windows.Forms.Padding(0);
            this.questionTypeSelector.Name = "questionTypeSelector";
            this.questionTypeSelector.Size = new System.Drawing.Size(469, 41);
            this.questionTypeSelector.TabIndex = 26;
            this.questionTypeSelector.Text = "Please select a question type.";
            this.questionTypeSelector.TextChanged += new System.EventHandler(this.TypeChanged);
            this.questionTypeSelector.Click += new System.EventHandler(this.questionTypeSelector_Click);
            // 
            // HardBtn
            // 
            this.HardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.HardBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HardBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardBtn.ForeColor = System.Drawing.Color.White;
            this.HardBtn.Location = new System.Drawing.Point(42, 473);
            this.HardBtn.Name = "HardBtn";
            this.HardBtn.Size = new System.Drawing.Size(349, 87);
            this.HardBtn.TabIndex = 30;
            this.HardBtn.Text = "Hard Question";
            this.HardBtn.UseVisualStyleBackColor = false;
            this.HardBtn.Click += new System.EventHandler(this.HardBtn_Click);
            // 
            // EasyBtn
            // 
            this.EasyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.EasyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EasyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EasyBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyBtn.ForeColor = System.Drawing.Color.White;
            this.EasyBtn.Location = new System.Drawing.Point(42, 250);
            this.EasyBtn.Name = "EasyBtn";
            this.EasyBtn.Size = new System.Drawing.Size(349, 87);
            this.EasyBtn.TabIndex = 31;
            this.EasyBtn.Text = "Easy Question";
            this.EasyBtn.UseVisualStyleBackColor = false;
            this.EasyBtn.Click += new System.EventHandler(this.EasyBtn_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton1.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.Lime;
            this.radioButton1.Location = new System.Drawing.Point(1427, 319);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(122, 50);
            this.radioButton1.TabIndex = 32;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton2.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.Lime;
            this.radioButton2.Location = new System.Drawing.Point(1427, 387);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(122, 50);
            this.radioButton2.TabIndex = 33;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton3.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.ForeColor = System.Drawing.Color.Lime;
            this.radioButton3.Location = new System.Drawing.Point(1427, 447);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(122, 50);
            this.radioButton3.TabIndex = 34;
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton4.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.ForeColor = System.Drawing.Color.Lime;
            this.radioButton4.Location = new System.Drawing.Point(1427, 510);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(122, 50);
            this.radioButton4.TabIndex = 35;
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.Color.Lime;
            this.checkBox1.Location = new System.Drawing.Point(1427, 319);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 50);
            this.checkBox1.TabIndex = 36;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox2.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold);
            this.checkBox2.ForeColor = System.Drawing.Color.Lime;
            this.checkBox2.Location = new System.Drawing.Point(1427, 383);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(152, 50);
            this.checkBox2.TabIndex = 37;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox3.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold);
            this.checkBox3.ForeColor = System.Drawing.Color.Lime;
            this.checkBox3.Location = new System.Drawing.Point(1427, 447);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(152, 50);
            this.checkBox3.TabIndex = 38;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox4.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold);
            this.checkBox4.ForeColor = System.Drawing.Color.Lime;
            this.checkBox4.Location = new System.Drawing.Point(1427, 510);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(152, 50);
            this.checkBox4.TabIndex = 39;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // SizeInput
            // 
            this.SizeInput.Font = new System.Drawing.Font("Lucida Sans", 28.75F);
            this.SizeInput.Location = new System.Drawing.Point(1415, 196);
            this.SizeInput.Margin = new System.Windows.Forms.Padding(0);
            this.SizeInput.Maximum = new decimal(new int[] {
            44,
            0,
            0,
            0});
            this.SizeInput.Name = "SizeInput";
            this.SizeInput.Size = new System.Drawing.Size(72, 53);
            this.SizeInput.TabIndex = 40;
            this.SizeInput.Value = new decimal(new int[] {
            44,
            0,
            0,
            0});
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PreviewBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.PreviewBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewBtn.ForeColor = System.Drawing.Color.White;
            this.PreviewBtn.Location = new System.Drawing.Point(32, 151);
            this.PreviewBtn.Margin = new System.Windows.Forms.Padding(0);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(170, 44);
            this.PreviewBtn.TabIndex = 41;
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
            this.SaveBtn.Location = new System.Drawing.Point(211, 151);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(170, 44);
            this.SaveBtn.TabIndex = 42;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // TextView
            // 
            this.TextView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.TextView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextView.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextView.ForeColor = System.Drawing.Color.White;
            this.TextView.Location = new System.Drawing.Point(511, 104);
            this.TextView.Margin = new System.Windows.Forms.Padding(0);
            this.TextView.Name = "TextView";
            this.TextView.Size = new System.Drawing.Size(272, 41);
            this.TextView.TabIndex = 43;
            this.TextView.Text = "See Existing Questions";
            this.TextView.UseVisualStyleBackColor = false;
            this.TextView.Click += new System.EventHandler(this.TextView_Click);
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.ReturnBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReturnBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnBtn.ForeColor = System.Drawing.Color.White;
            this.ReturnBtn.Location = new System.Drawing.Point(1230, 658);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(349, 87);
            this.ReturnBtn.TabIndex = 44;
            this.ReturnBtn.Text = "Return";
            this.ReturnBtn.UseVisualStyleBackColor = false;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // TrueBtn
            // 
            this.TrueBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.TrueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TrueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TrueBtn.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold);
            this.TrueBtn.ForeColor = System.Drawing.Color.White;
            this.TrueBtn.Location = new System.Drawing.Point(730, 319);
            this.TrueBtn.Name = "TrueBtn";
            this.TrueBtn.Size = new System.Drawing.Size(330, 241);
            this.TrueBtn.TabIndex = 45;
            this.TrueBtn.Text = "True";
            this.TrueBtn.UseVisualStyleBackColor = false;
            this.TrueBtn.Click += new System.EventHandler(this.TrueBtn_Click);
            // 
            // FalseBtn
            // 
            this.FalseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.FalseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FalseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FalseBtn.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold);
            this.FalseBtn.ForeColor = System.Drawing.Color.White;
            this.FalseBtn.Location = new System.Drawing.Point(1157, 319);
            this.FalseBtn.Name = "FalseBtn";
            this.FalseBtn.Size = new System.Drawing.Size(330, 241);
            this.FalseBtn.TabIndex = 46;
            this.FalseBtn.Text = "False";
            this.FalseBtn.UseVisualStyleBackColor = false;
            this.FalseBtn.Click += new System.EventHandler(this.FalseBtn_Click);
            // 
            // DummyTxtbox
            // 
            this.DummyTxtbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DummyTxtbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.DummyTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DummyTxtbox.Font = new System.Drawing.Font("Lucida Sans", 30.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DummyTxtbox.ForeColor = System.Drawing.Color.White;
            this.DummyTxtbox.Location = new System.Drawing.Point(32, 264);
            this.DummyTxtbox.Margin = new System.Windows.Forms.Padding(0);
            this.DummyTxtbox.MaxLength = 0;
            this.DummyTxtbox.Name = "DummyTxtbox";
            this.DummyTxtbox.Size = new System.Drawing.Size(1259, 164);
            this.DummyTxtbox.TabIndex = 47;
            this.DummyTxtbox.Text = "Enter Answer Here";
            // 
            // QuestionDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(32)))), ((int)(((byte)(129)))));
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.FalseBtn);
            this.Controls.Add(this.TrueBtn);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.TextView);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.PreviewBtn);
            this.Controls.Add(this.SizeInput);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.EasyBtn);
            this.Controls.Add(this.HardBtn);
            this.Controls.Add(this.questionTypeSelector);
            this.Controls.Add(this.FourthInput);
            this.Controls.Add(this.ThirdInput);
            this.Controls.Add(this.SecondInput);
            this.Controls.Add(this.FirstInput);
            this.Controls.Add(this.QuestionInput);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.DummyTxtbox);
            this.Name = "QuestionDesigner";
            this.Text = "Font Size";
            this.Load += new System.EventHandler(this.QuestionDesigner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SizeInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.RichTextBox QuestionInput;
        private System.Windows.Forms.RichTextBox FirstInput;
        private System.Windows.Forms.RichTextBox SecondInput;
        private System.Windows.Forms.RichTextBox ThirdInput;
        private System.Windows.Forms.RichTextBox FourthInput;
        private System.Windows.Forms.ComboBox questionTypeSelector;
        private System.Windows.Forms.Button HardBtn;
        private System.Windows.Forms.Button EasyBtn;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.NumericUpDown SizeInput;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button TextView;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.Button TrueBtn;
        private System.Windows.Forms.Button FalseBtn;
        private System.Windows.Forms.RichTextBox DummyTxtbox;
    }
}