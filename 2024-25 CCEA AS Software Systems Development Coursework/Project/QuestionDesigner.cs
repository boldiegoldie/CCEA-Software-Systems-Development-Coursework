using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class QuestionDesigner : Form
    {
        //Initalise variables, objects and events
        bool question_clear = true;
        bool first_clear = true;
        bool second_clear = true;
        bool third_clear = true;
        bool fourth_clear = true;
        bool SaveFirstClick = true;
        bool valid = false;
        bool preview = false;

        string cb1ans = string.Empty;
        string cb2ans = string.Empty;
        string cb3ans = string.Empty;
        string cb4ans = string.Empty;
        string difficulty = string.Empty;
        string answer = string.Empty;
        string ID = string.Empty;
        string cbcombined = string.Empty;
        string fillAnswer = string.Empty;

        string[] ReadFile;

        Random random = new Random();
        Stopwatch sw = new Stopwatch();
        SoundPlayer player = new SoundPlayer();

        int selected = 0;

        public event EventHandler ShowTextView;

        public QuestionDesigner()
        {
            InitializeComponent();
        }

        //Hides question making UI and configures visual properties for buttons and the questionTypeSelector
        private void QuestionDesigner_Load(object sender, EventArgs e)
        {
            questionTypeSelector.FlatStyle = FlatStyle.Flat;
            EasyBtn.FlatStyle = FlatStyle.Flat;
            EasyBtn.FlatAppearance.BorderSize = 0;
            EasyBtn.FlatAppearance.BorderColor = Color.LimeGreen;
            HardBtn.FlatStyle = FlatStyle.Flat;
            HardBtn.FlatAppearance.BorderSize = 0;
            HardBtn.FlatAppearance.BorderColor = Color.Red;
            EasyBtn.FlatAppearance.BorderSize = 0;
            HardBtn.FlatAppearance.BorderSize = 0;
            SaveBtn.FlatAppearance.BorderSize = 0;
            PreviewBtn.FlatAppearance.BorderSize = 0;
            ReturnBtn.FlatAppearance.BorderSize = 0;
            TextView.FlatAppearance.BorderSize = 0;
            TrueBtn.FlatAppearance.BorderSize = 0;
            FalseBtn.FlatAppearance.BorderSize = 0;

            FirstInput.Hide();
            SecondInput.Hide();
            ThirdInput.Hide();
            FourthInput.Hide();
            QuestionInput.Hide();
            EasyBtn.Hide();
            HardBtn.Hide();
            SizeInput.Hide();
            ReturnBtn.Hide();
            TrueBtn.Hide();
            FalseBtn.Hide();
            DummyTxtbox.Hide();

            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();
            radioButton4.Hide();

            checkBox1.Hide();
            checkBox2.Hide();
            checkBox3.Hide();
            checkBox4.Hide();
        }

        private void TypeChanged(object sender, EventArgs e)
        {
            //Tells each textbox to clear when clicked for the first time
            question_clear = true;
            first_clear = true;
            second_clear = true;
            third_clear = true;
            fourth_clear = true;

            switch (questionTypeSelector.Text)
            {
                case "Checkbox": //Confugures the UI for making Checkbox questions
                    FirstInput.Text = "First Option";
                    SecondInput.Text = "Second Option";
                    ThirdInput.Text = "Third Option";
                    FourthInput.Text = "Fourth Option";
                    QuestionInput.Text = "Question";

                    QuestionInput.ForeColor = Color.Gainsboro;
                    FirstInput.ForeColor = Color.Gainsboro;
                    SecondInput.ForeColor = Color.Gainsboro;
                    ThirdInput.ForeColor = Color.Gainsboro;
                    FourthInput.ForeColor = Color.Gainsboro;

                    QuestionInput.Location = new Point(730, 199);
                    FirstInput.Location = new Point(730, 319);
                    SecondInput.Location = new Point(730, 383);
                    ThirdInput.Location = new Point(730, 447);
                    FourthInput.Location = new Point(730, 510);
                    SizeInput.Location = new Point(1427, 199);

                    QuestionInput.Show();
                    FirstInput.Show();
                    SecondInput.Show();
                    ThirdInput.Show();
                    FourthInput.Show();
                    SizeInput.Show();
                    EasyBtn.Show();
                    HardBtn.Show();

                    checkBox1.Text = string.Empty;
                    checkBox2.Text = string.Empty;
                    checkBox3.Text = string.Empty;
                    checkBox4.Text = string.Empty;

                    checkBox1.Show();
                    checkBox2.Show();
                    checkBox3.Show();
                    checkBox4.Show();

                    radioButton1.Hide();
                    radioButton2.Hide();
                    radioButton3.Hide();
                    radioButton4.Hide();

                    TrueBtn.Hide();
                    FalseBtn.Hide();

                    Common_Variables.CurrentPage = "DesignerCheckbox";
                    break;

                case "Multiple Choice": //Confugures the UI for making MultiChoice questions
                    FirstInput.Text = "First Option";
                    SecondInput.Text = "Second Option";
                    ThirdInput.Text = "Third Option";
                    FourthInput.Text = "Fourth Option";
                    QuestionInput.Text = "Question";

                    QuestionInput.ForeColor = Color.Gainsboro;
                    FirstInput.ForeColor = Color.Gainsboro;
                    SecondInput.ForeColor = Color.Gainsboro;
                    ThirdInput.ForeColor = Color.Gainsboro;
                    FourthInput.ForeColor = Color.Gainsboro;

                    QuestionInput.Location = new Point(730, 199);
                    FirstInput.Location = new Point(730, 319);
                    SecondInput.Location = new Point(730, 383);
                    ThirdInput.Location = new Point(730, 447);
                    FourthInput.Location = new Point(730, 510);
                    SizeInput.Location = new Point(1427, 199);

                    QuestionInput.Show();
                    FirstInput.Show();
                    SecondInput.Show();
                    ThirdInput.Show();
                    FourthInput.Show();
                    SizeInput.Show();
                    EasyBtn.Show();
                    HardBtn.Show();

                    radioButton1.Show();
                    radioButton2.Show();
                    radioButton3.Show();
                    radioButton4.Show();

                    checkBox1.Hide();
                    checkBox2.Hide();
                    checkBox3.Hide();
                    checkBox4.Hide();

                    TrueBtn.Hide();
                    FalseBtn.Hide();

                    Common_Variables.CurrentPage = "DesignerMulti";
                    break;

                case "Fill in the Blank": //Confugures the UI for making FillInTheBlank questions
                    radioButton1.Hide();
                    radioButton2.Hide();
                    radioButton3.Hide();
                    radioButton4.Hide();
                    checkBox1.Hide();
                    checkBox2.Hide();
                    checkBox3.Hide();
                    checkBox4.Hide();
                    SecondInput.Hide();
                    ThirdInput.Hide();
                    FourthInput.Hide();
                    TrueBtn.Hide();
                    FalseBtn.Hide();

                    QuestionInput.Location = new Point(730, 199);
                    FirstInput.Location = new Point(730, 319);
                    SecondInput.Location = new Point(730, 383);
                    ThirdInput.Location = new Point(730, 447);
                    FourthInput.Location = new Point(730, 510);
                    SizeInput.Location = new Point(1427, 199);
                    FirstInput.Text = "Answer";
                    SecondInput.Text = "Alternative Answer 1";
                    ThirdInput.Text = "Alternative Answer 2";
                    FourthInput.Text = "Alternative Answer 3";
                    checkBox1.Text = "Add answer";
                    checkBox2.Text = "Add answer";
                    checkBox3.Text = "Add answer";
                    checkBox1.Font = new Font("Lucida Sans", 15, FontStyle.Bold);
                    checkBox2.Font = new Font("Lucida Sans", 15, FontStyle.Bold);
                    checkBox3.Font = new Font("Lucida Sans", 15, FontStyle.Bold);
                    checkBox4.Font = new Font("Lucida Sans", 15, FontStyle.Bold);
                    checkBox1.Size = new Size(152, 50);
                    checkBox2.Size = new Size(152, 50);
                    checkBox3.Size = new Size(152, 50);
                    checkBox4.Size = new Size(152, 50);
                    checkBox1.Show();
                    FirstInput.Show();
                    QuestionInput.Show();
                    SizeInput.Show();
                    EasyBtn.Show();
                    HardBtn.Show();

                    Common_Variables.CurrentPage = "DesignerBlank";
                    break;

                case "True or False": //Confugures the UI for making TrueOrFalse questions
                    TrueBtn.Show();
                    FalseBtn.Show();
                    radioButton1.Hide();
                    radioButton2.Hide();
                    radioButton3.Hide();
                    radioButton4.Hide();
                    checkBox1.Hide();
                    checkBox2.Hide();
                    checkBox3.Hide();
                    checkBox4.Hide();
                    FirstInput.Hide(); SecondInput.Hide(); ThirdInput.Hide(); FourthInput.Hide();
                    QuestionInput.Show();
                    SizeInput.Show();
                    QuestionInput.Location = new Point(730, 199);
                    EasyBtn.Show();
                    HardBtn.Show();

                    Common_Variables.CurrentPage = "DesignerTorf";
                    break;
            }
        }

        //These 5 functions clear the text in their respective textboxes if their _clear variable is true
        private void QuestionInput_Click(object sender, EventArgs e)
        {
            if (question_clear == true)
            {
                QuestionInput.Text = "";
                QuestionInput.ForeColor = Color.Black;
            }
            question_clear = false;
        }

        private void FirstInput_Click(object sender, EventArgs e)
        {
            if (first_clear == true)
            {
                FirstInput.Text = "";
                FirstInput.ForeColor = Color.Black;
            }
            first_clear = false;
        }

        private void SecondInput_Click(object sender, EventArgs e)
        {
            if (second_clear == true)
            {
                SecondInput.Text = "";
                SecondInput.ForeColor = Color.Black;
            }
            second_clear = false;
        }

        private void ThirdInput_Click(object sender, EventArgs e)
        {
            if (third_clear == true)
            {
                ThirdInput.Text = "";
                ThirdInput.ForeColor = Color.Black;
            }
            third_clear = false;
        }

        private void FourthInput_Click(object sender, EventArgs e)
        {
            if (fourth_clear == true)
            {
                FourthInput.Text = "";
                FourthInput.ForeColor = Color.Black;
            }
            fourth_clear = false;
        }

        //Sets the answer for a MultiChoice question to the 4th option, sets the 4th radioButtons text to "Answer" and blanks the other 3
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (selected != 4 && !preview)
            {
                radioButton1.Text = "";
                radioButton2.Text = "";
                radioButton3.Text = "";
                radioButton4.Text = "Answer";
                selected = 4;
                answer = FourthInput.Text;
            } 
        }

        //Sets the answer for a MultiChoice question to the 3rd option, sets the 3rd radioButtons text to "Answer" and blanks the other 3
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (selected != 3 && !preview)
            {
                radioButton1.Text = "";
                radioButton2.Text = "";
                radioButton3.Text = "Answer";
                radioButton4.Text = "";
                selected = 3;
                answer = ThirdInput.Text;
            }
        }

        //Sets the answer for a MultiChoice question to the 2nd option, sets the 2nd radioButtons text to "Answer" and blanks the other 3
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (selected != 2 && !preview )
            {
                radioButton1.Text = "";
                radioButton2.Text = "Answer";
                radioButton3.Text = "";
                radioButton4.Text = "";
                selected = 2;
                answer = SecondInput.Text;
            }         
        }

        //Sets the answer for a MultiChoice question to the 1st option, sets the 1sr radioButtons text to "Answer" and blanks the other 3
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (selected != 1 && !preview)
            {
                radioButton1.Text = "Answer";
                radioButton2.Text = "";
                radioButton3.Text = "";
                radioButton4.Text = "";
                selected = 1;
                answer = FirstInput.Text;
            }
        }


        public void CloseForm(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Close();
            }
        }

        //Sets the difficulty for the question to easy and highlights the EasyBtn
        private void EasyBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            EasyBtn.FlatAppearance.BorderSize = 5;
            HardBtn.FlatAppearance.BorderSize = 0;
            difficulty = "e";
        }

        //Sets the difficulty for the question to hard and highlights the HardBtn
        private void HardBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            EasyBtn.FlatAppearance.BorderSize = 0;
            HardBtn.FlatAppearance.BorderSize = 5;
            difficulty = "h";
        }

        //Sends the user to TextView and tells TextView what text file to show
        private void TextView_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (questionTypeSelector.Text == "Please select a question type.")
            {
                questionTypeSelector.ForeColor = Color.Red;
            }
            else
            {
                switch (questionTypeSelector.SelectedIndex)
                {
                    case (0):
                        Common_Variables.FileToBeViewed = "checkbox.txt";
                        break;
                    case (1):
                        Common_Variables.FileToBeViewed = "fillinblank.txt";
                        break;
                    case (2):
                        Common_Variables.FileToBeViewed = "multichoice.txt";
                        break;
                    case (3):
                        Common_Variables.FileToBeViewed = "trueorfalse.txt";
                        break;
                }

                if (ShowTextView != null)
                {
                    ShowTextView.Invoke(sender, EventArgs.Empty);
                }
                this.Close();
            }
        }

        //Saves the userews quesstion with a unique ID after button is clicked twice
        async private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (SaveFirstClick) //Makes user click button again to save
            {
                SaveBtn.ForeColor = Color.White;
                SaveBtn.Text = "Are you sure?";
                SaveFirstClick = false;
                await Task.Delay(3000);
                if (!SaveFirstClick)
                {
                    SaveBtn.Text = "Save";
                    SaveFirstClick = true;
                }
                else if (SaveBtn.Text == "No Difficulty" || SaveBtn.Text == "No Question" || SaveBtn.Text == "No Answer")
                {
                    SaveFirstClick = true;
                }
            }
            else if (!SaveFirstClick)
            {
                SaveFirstClick = true;

                //Removes all / from the inputs so file does not break game
                QuestionInput.Text = QuestionInput.Text.Replace("/", string.Empty);
                FirstInput.Text = FirstInput.Text.Replace("/", string.Empty);
                SecondInput.Text = SecondInput.Text.Replace("/", string.Empty);
                ThirdInput.Text = ThirdInput.Text.Replace("/", string.Empty);
                FourthInput.Text = FourthInput.Text.Replace("/", string.Empty);

                //Rejects question if all criteria not met
                if (difficulty == string.Empty)
                {
                    SaveBtn.Text = "No Difficulty";
                    SaveBtn.ForeColor = Color.Red;
                    return;
                }
                else if ((QuestionInput.Text == string.Empty || FirstInput.Text == string.Empty || SecondInput.Text == string.Empty || ThirdInput.Text == string.Empty || FourthInput.Text == string.Empty) && questionTypeSelector.Text != "Fill in the Blank" && questionTypeSelector.Text != "True or False")
                {
                    SaveBtn.Text = "No Question";
                    SaveBtn.ForeColor = Color.Red;
                    return;
                }
                else if ((QuestionInput.Text == "Question" || FirstInput.Text == "First Option" || SecondInput.Text == "Second Option" || ThirdInput.Text == "Third Option" || FourthInput.Text == "Fourth Option") && (questionTypeSelector.Text != "Fill in the Blank" && questionTypeSelector.Text != "True or False"))
                {
                    SaveBtn.Text = "No Question";
                    SaveBtn.ForeColor = Color.Red;
                    return;
                }
                else if ((questionTypeSelector.Text == "Fill in the Blank" || questionTypeSelector.Text == "True or False") && (QuestionInput.Text == "Question" || QuestionInput.Text == string.Empty))
                {
                    SaveBtn.Text = "No Question";
                    SaveBtn.ForeColor = Color.Red;
                    return;
                }
                else if (answer == string.Empty && questionTypeSelector.Text != "Checkbox" && questionTypeSelector.Text != "Fill in the Blank")
                {
                    SaveBtn.Text = "No Answer";
                    SaveBtn.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    switch (questionTypeSelector.Text)
                    {
                        case "Checkbox": //Saves Checkbox questions
                            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
                            {
                                cbcombined = cb1ans + cb2ans + cb3ans + cb4ans;
                                sw.Start();
                                while (!valid)
                                {
                                    ID = IDGen();
                                    try
                                    {
                                        string[] ReadFile = File.ReadAllLines(Common_Variables.path + @"\assets\txt\checkbox.txt");
                                        for (int index = 0; index < ReadFile.Length; index++)
                                        {
                                            string[] SplitFile = ReadFile[index].Split('/');
                                            if (SplitFile[3] != ID.ToUpper())
                                            {
                                                valid = true;
                                            }
                                            else
                                            {
                                                ID = IDGen();
                                            }
                                            if (sw.ElapsedMilliseconds > 1500)
                                            {
                                                MessageBox.Show("Too many questions in file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                SaveBtn.Text = "Save";
                                                return;
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        MessageBox.Show("checkbox.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        Environment.Exit(Environment.ExitCode);
                                    }
                                }
                            }
                            else if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
                            {
                                SaveBtn.Text = "No Answer";
                                SaveBtn.ForeColor = Color.Red;
                                break;
                            }
                            valid = false;
                            sw.Reset();
                            try
                            {
                                File.AppendAllText(Common_Variables.path + @"\assets\txt\checkbox.txt", difficulty + "/" + cbcombined + "/" + Convert.ToString(SizeInput.Value) + "/" + "c" + ID + "/" + QuestionInput.Text + "/" + FirstInput.Text + "/" + SecondInput.Text + "/" + ThirdInput.Text + "/" + FourthInput.Text + Environment.NewLine);
                            }
                            catch
                            {
                                MessageBox.Show("checkbox.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Environment.Exit(Environment.ExitCode);
                            }
                            SaveBtn.Text = "Saved!";
                            answer = string.Empty;
                            await Task.Delay(1000);
                            SaveBtn.Text = "Save";
                            break;

                        case "Multiple Choice": //Saves MultiChoice questions
                            sw.Start();
                            while (!valid)
                            {
                                ID = IDGen();
                                try
                                {
                                    string[] ReadFile = File.ReadAllLines(Common_Variables.path + @"\assets\txt\multichoice.txt");
                                    for (int index = 0; index < ReadFile.Length; index++)
                                    {
                                        string[] SplitFile = ReadFile[index].Split('/');
                                        if (SplitFile[3] != ID.ToUpper())
                                        {
                                            valid = true;
                                        }
                                        else
                                        {
                                            ID = IDGen();
                                        }
                                        if (sw.ElapsedMilliseconds > 1500)
                                        {
                                            MessageBox.Show("Error: Too many questions in file.");
                                            SaveBtn.Text = "Save";
                                            return;
                                        }
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("multichoice.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Environment.Exit(Environment.ExitCode);
                                }
                                
                            }
                            valid = false;
                            sw.Reset();
                            try
                            {
                                File.AppendAllText(Common_Variables.path + @"\assets\txt\multichoice.txt", difficulty + "/" + answer + "/" + Convert.ToString(SizeInput.Value) + "/" + "m" + ID + "/" + QuestionInput.Text + "/" + FirstInput.Text + "/" + SecondInput.Text + "/" + ThirdInput.Text + "/" + FourthInput.Text + Environment.NewLine);
                            }
                            catch
                            {
                                MessageBox.Show("multichoice.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Environment.Exit(Environment.ExitCode);
                            }
                            SaveBtn.Text = "Saved!";
                            answer = string.Empty;
                            await Task.Delay(1000);
                            SaveBtn.Text = "Save";
                            break;

                        case "Fill in the Blank": //Saves FillInTheBlank questions
                            sw.Start();
                            while (!valid)
                            {
                                ID = IDGen();
                                try
                                {
                                    string[] ReadFile = File.ReadAllLines(Common_Variables.path + @"\assets\txt\fillinblank.txt");
                                    for (int index = 0; index < ReadFile.Length; index++)
                                    {
                                        string[] SplitFile = ReadFile[index].Split('/');
                                        if (SplitFile[3] != ID.ToUpper())
                                        {
                                            valid = true;
                                        }
                                        else
                                        {
                                            ID = IDGen();
                                        }
                                        if (sw.ElapsedMilliseconds > 1500)
                                        {
                                            MessageBox.Show("Error: Too many questions in file.");
                                            SaveBtn.Text = "Save";
                                            return;
                                        }
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("fillinblank.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Environment.Exit(Environment.ExitCode);
                                }
                            }
                            valid = false;
                            sw.Reset();
                            if (checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
                            {
                                if ((FirstInput.Text == "" || FirstInput.Text == "Answer") || (SecondInput.Text == "" || SecondInput.Text == "Alternative Answer 1"))
                                {
                                    SaveBtn.Text = "No Answer";
                                    SaveBtn.ForeColor = Color.Red;
                                    break;
                                }
                                FirstInput.Text = ReplaceWhitespace(FirstInput.Text);
                                SecondInput.Text = ReplaceWhitespace(SecondInput.Text);
                                fillAnswer = (FirstInput.Text.ToLower() + ',' + SecondInput.Text.ToLower());
                            }
                            else if (checkBox2.Checked && !checkBox3.Checked)
                            {
                                if (FirstInput.Text == "" || FirstInput.Text == "Answer" || SecondInput.Text == "" || SecondInput.Text == "Alternative Answer 1" || ThirdInput.Text == "" || ThirdInput.Text == "Alternative Answer 2")
                                {
                                    SaveBtn.Text = "No Answer";
                                    SaveBtn.ForeColor = Color.Red;
                                    break;
                                }
                                FirstInput.Text = ReplaceWhitespace(FirstInput.Text);
                                SecondInput.Text = ReplaceWhitespace(SecondInput.Text);
                                ThirdInput.Text = ReplaceWhitespace(ThirdInput.Text);
                                fillAnswer = (FirstInput.Text.ToLower() + ',' + SecondInput.Text.ToLower() + ',' + ThirdInput.Text.ToLower());
                            }
                            else if (checkBox3.Checked)
                            {
                                if (FirstInput.Text == "" || FirstInput.Text == "Answer" || SecondInput.Text == "" || SecondInput.Text == "Alternative Answer 1" || ThirdInput.Text == "" || ThirdInput.Text == "Alternative Answer 2" || FourthInput.Text == "" || FourthInput.Text == "Alternative Answer 3")
                                {
                                    SaveBtn.Text = "No Answer";
                                    SaveBtn.ForeColor = Color.Red;
                                    break;
                                }
                                FirstInput.Text = ReplaceWhitespace(FirstInput.Text);
                                SecondInput.Text = ReplaceWhitespace(SecondInput.Text);
                                ThirdInput.Text = ReplaceWhitespace(ThirdInput.Text);
                                FourthInput.Text = ReplaceWhitespace(FourthInput.Text);
                                fillAnswer = (FirstInput.Text.ToLower() + ',' + SecondInput.Text.ToLower() + ',' + ThirdInput.Text.ToLower() + ',' + FourthInput.Text.ToLower());
                            }
                            else
                            {
                                if (FirstInput.Text == "" || FirstInput.Text == "Answer")
                                {
                                    SaveBtn.Text = "No Answer";
                                    SaveBtn.ForeColor = Color.Red;
                                    break;
                                }
                                FirstInput.Text = ReplaceWhitespace(FirstInput.Text);
                                fillAnswer = FirstInput.Text.ToLower();
                            }
                            try
                            {
                                File.AppendAllText(Common_Variables.path + @"\assets\txt\fillinblank.txt", difficulty + "/" + fillAnswer + "/" + Convert.ToString(SizeInput.Value) + "/" + "f" + ID + "/" + QuestionInput.Text + Environment.NewLine);
                            }
                            catch
                            {
                                MessageBox.Show("fillinblank.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Environment.Exit(Environment.ExitCode);
                            }
                            SaveBtn.Text = "Saved!";
                            answer = string.Empty;
                            await Task.Delay(1000);
                            SaveBtn.Text = "Save";
                            break;

                        case "True or False": //Saves TrueOrFalse questions
                            sw.Start();
                            while (!valid)
                            {
                                ID = IDGen();
                                try
                                {
                                    ReadFile = File.ReadAllLines(Common_Variables.path + @"\assets\txt\trueorfalse.txt");
                                    for (int index = 0; index < ReadFile.Length; index++)
                                    {
                                        string[] SplitFile = ReadFile[index].Split('/');
                                        if (SplitFile[3] != ID.ToUpper())
                                        {
                                            valid = true;
                                        }
                                        else
                                        {
                                            ID = IDGen();
                                        }
                                        if (sw.ElapsedMilliseconds > 1500)
                                        {
                                            MessageBox.Show("Error: Too many questions in file.");
                                            SaveBtn.Text = "Save";
                                            return;
                                        }
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("trueorfalse.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Environment.Exit(Environment.ExitCode);
                                } 
                            }
                            valid = false;
                            sw.Reset();
                            try
                            {
                                File.AppendAllText(Common_Variables.path + @"\assets\txt\trueorfalse.txt", difficulty + "/" + answer + "/" + Convert.ToString(SizeInput.Value) + "/" + "t" + ID + "/" + QuestionInput.Text + Environment.NewLine);
                            }
                            catch
                            {
                                MessageBox.Show("trueorfalse.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Environment.Exit(Environment.ExitCode);
                            }
                            SaveBtn.Text = "Saved!";
                            answer = string.Empty;
                            await Task.Delay(1000);
                            SaveBtn.Text = "Save";
                            break;

                    }
                }
                
            }
        }

        //Sets ForeColour to white to remove error state
        private void questionTypeSelector_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            questionTypeSelector.ForeColor = Color.White;
        }

        //Generates an ID of 3 random letters
        public string IDGen()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //Configures UI to look like the quesion form the user is making a question for
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (questionTypeSelector.Text == "Please select a question type.")
            {
                questionTypeSelector.ForeColor = Color.Red;
                return;
            }

            HardBtn.Hide();
            EasyBtn.Hide();
            SaveBtn.Hide();
            PreviewBtn.Hide();
            QuestionInput.Hide();
            FirstInput.Hide(); SecondInput.Hide(); ThirdInput.Hide(); FourthInput.Hide();
            TextView.Hide();
            SizeInput.Hide();
            questionTypeSelector.Hide();
            ReturnBtn.Show();

            preview = true;

            Header.Font = new Font("Lucida Sans", (float)SizeInput.Value, FontStyle.Bold);

            switch (questionTypeSelector.Text)
            {
                case ("Checkbox"):
                    Header.Text = QuestionInput.Text;
                    checkBox1.Text = FirstInput.Text;
                    checkBox2.Text = SecondInput.Text;
                    checkBox3.Text = ThirdInput.Text;
                    checkBox4.Text = FourthInput.Text;
                    
                    checkBox1.Location = new Point(43, 245);
                    checkBox2.Location = new Point(741, 245);
                    checkBox3.Location = new Point(43, 439);
                    checkBox4.Location = new Point(741, 439);

                    checkBox1.Size = new Size(670, 48);
                    checkBox2.Size = new Size(670, 48);
                    checkBox3.Size = new Size(670, 48);
                    checkBox4.Size = new Size(670, 48);

                    checkBox1.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    checkBox2.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    checkBox3.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    checkBox4.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    Header.Font = new Font("Lucida Sans", (float)SizeInput.Value, FontStyle.Bold);

                    checkBox1.ForeColor = Color.White;
                    checkBox2.ForeColor = Color.White;
                    checkBox3.ForeColor = Color.White;
                    checkBox4.ForeColor = Color.White;

                    radioButton1.Hide();
                    radioButton2.Hide();
                    radioButton3.Hide();
                    radioButton4.Hide();
                    break;
                case ("Multiple Choice"):
                    Header.Text = QuestionInput.Text;
                    radioButton1.Text = FirstInput.Text;
                    radioButton2.Text = SecondInput.Text;
                    radioButton3.Text = ThirdInput.Text;
                    radioButton4.Text = FourthInput.Text;

                    radioButton1.Location = new Point(43, 245);
                    radioButton2.Location = new Point(741, 245);
                    radioButton3.Location = new Point(741, 439);
                    radioButton4.Location = new Point(43, 439);

                    radioButton1.Size = new Size(670, 173);
                    radioButton2.Size = new Size(705, 173);
                    radioButton3.Size = new Size(705, 173);
                    radioButton4.Size = new Size(670, 173);

                    radioButton1.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    radioButton2.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    radioButton3.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    radioButton4.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    
                    radioButton1.ForeColor = Color.White;
                    radioButton2.ForeColor = Color.White;
                    radioButton3.ForeColor = Color.White;
                    radioButton4.ForeColor = Color.White;

                    checkBox1.Hide();
                    checkBox2.Hide();
                    checkBox3.Hide();
                    checkBox4.Hide();

                    break;
                case ("Fill in the Blank"):
                    Header.Text = QuestionInput.Text;
                    DummyTxtbox.Show();
                    checkBox1.Hide();
                    checkBox2.Hide();
                    checkBox3.Hide();
                    checkBox4.Hide();

                    break;
                case ("True or False"):
                    Header.Text = QuestionInput.Text;
                    TrueBtn.Size = new Size(700, 400);
                    FalseBtn.Size = new Size(700, 400);
                    TrueBtn.Location = new Point(30, 226);
                    FalseBtn.Location = new Point(860, 226);
                    TrueBtn.FlatAppearance.BorderColor = Color.White;
                    FalseBtn.FlatAppearance.BorderColor = Color.White;
                    break;
            }
        }

        //Reverts the UI to the state it was before the PreviewBtn is clicked
        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            preview = false;
            HardBtn.Show();
            EasyBtn.Show();
            SaveBtn.Show();
            PreviewBtn.Show();
            QuestionInput.Show();

            FirstInput.Show(); SecondInput.Show(); ThirdInput.Show(); FourthInput.Show();

            TextView.Show();
            SizeInput.Show();
            questionTypeSelector.Show();
            ReturnBtn.Hide();
            DummyTxtbox.Hide();

            radioButton1.Size = new Size(122, 50);
            radioButton2.Size = new Size(122, 50);
            radioButton3.Size = new Size(122, 50);
            radioButton4.Size = new Size(122, 50);

            checkBox1.Size = new Size(152, 50);
            checkBox2.Size = new Size(152, 50);
            checkBox3.Size = new Size(152, 50);
            checkBox4.Size = new Size(152, 50);

            radioButton1.Font = new Font("Lucida Sans", 18, FontStyle.Bold);
            radioButton2.Font = new Font("Lucida Sans", 18, FontStyle.Bold);
            radioButton3.Font = new Font("Lucida Sans", 18, FontStyle.Bold);
            radioButton4.Font = new Font("Lucida Sans", 18, FontStyle.Bold);

            radioButton1.ForeColor = Color.Lime;
            radioButton2.ForeColor = Color.Lime;
            radioButton3.ForeColor = Color.Lime;
            radioButton4.ForeColor = Color.Lime;

            checkBox1.Font = new Font("Lucida Sans", 18, FontStyle.Bold);
            checkBox2.Font = new Font("Lucida Sans", 18, FontStyle.Bold);
            checkBox3.Font = new Font("Lucida Sans", 18, FontStyle.Bold);
            checkBox4.Font = new Font("Lucida Sans", 18, FontStyle.Bold);

            checkBox1.ForeColor = Color.Lime;
            checkBox2.ForeColor = Color.Lime;
            checkBox3.ForeColor = Color.Lime;
            checkBox4.ForeColor = Color.Lime;

            radioButton1.Text = string.Empty;
            radioButton2.Text = string.Empty;
            radioButton3.Text = string.Empty;
            radioButton4.Text = string.Empty;

            checkBox1.Text = string.Empty;
            checkBox2.Text = string.Empty;
            checkBox3.Text = string.Empty;
            checkBox4.Text = string.Empty;

            radioButton1.Location = new Point(1427, 319);
            radioButton2.Location = new Point(1427, 387);
            radioButton3.Location = new Point(1427, 447);
            radioButton4.Location = new Point(1427, 510);

            checkBox1.Location = new Point(1427, 319);
            checkBox2.Location = new Point(1427, 387);
            checkBox3.Location = new Point(1427, 447);
            checkBox4.Location = new Point(1427, 510);

            TrueBtn.Location = new Point(730, 319);
            FalseBtn.Location = new Point(1157, 319);
            TrueBtn.Size = new Size(330, 241);
            FalseBtn.Size = new Size(330, 241);

            Header.Text = "Question Designer";
            Header.Font = new Font("Lucida Sans", 44, FontStyle.Bold);

            switch (questionTypeSelector.Text)
            {
                case ("Checkbox"):
                    radioButton1.Hide();
                    radioButton2.Hide();
                    radioButton3.Hide();
                    radioButton4.Hide();

                    if (checkBox1.Checked)
                    {
                        checkBox1.Text = "Answer";
                    }
                    if (checkBox2.Checked)
                    {
                        checkBox2.Text = "Answer";
                    }
                    if (checkBox3.Checked)
                    {
                        checkBox3.Text = "Answer";
                    }
                    if (checkBox4.Checked)
                    {
                        checkBox4.Text = "Answer";
                    }
                    break;
                case ("Multiple Choice"):
                    checkBox1.Hide();
                    checkBox2.Hide();
                    checkBox3.Hide();
                    checkBox4.Hide();

                    if (radioButton1.Checked)
                    {
                        radioButton1.Text = "Answer";
                    }
                    else if (radioButton2.Checked)
                    {
                        radioButton2.Text = "Answer";
                    }
                    else if (radioButton3.Checked)
                    {
                        radioButton3.Text = "Answer";
                    }
                    else if (radioButton4.Checked)
                    {
                        radioButton4.Text = "Answer";
                    }
                    break;
                case ("Fill in the Blank"):
                    radioButton1.Hide();
                    radioButton2.Hide();
                    radioButton3.Hide();
                    radioButton4.Hide();
                    checkBox1.Hide();
                    checkBox2.Hide();
                    checkBox3.Hide();
                    checkBox4.Hide();
                    SecondInput.Hide();
                    ThirdInput.Hide();
                    FourthInput.Hide();
                    TrueBtn.Hide();
                    FalseBtn.Hide();

                    QuestionInput.Location = new Point(730, 199);
                    SizeInput.Location = new Point(1427, 199);
                    FirstInput.Show();
                    QuestionInput.Show();
                    SizeInput.Show();

                    checkBox1.Text = "Add answer";
                    checkBox2.Text = "Add answer";
                    checkBox3.Text = "Add answer";

                    checkBox1.Show();

                    if (checkBox1.Checked)
                    {
                        checkBox2.Show();
                        SecondInput.Show();
                    }
                    if (checkBox2.Checked)
                    {
                        checkBox3.Show();
                        ThirdInput.Show();
                    }

                    if (checkBox3.Checked)
                    {
                        FourthInput.Show();
                    }

                    checkBox1.Font = new Font("Lucida Sans", 15, FontStyle.Bold);
                    checkBox2.Font = new Font("Lucida Sans", 15, FontStyle.Bold);
                    checkBox3.Font = new Font("Lucida Sans", 15, FontStyle.Bold);
                    checkBox4.Font = new Font("Lucida Sans", 15, FontStyle.Bold);
                    checkBox1.Size = new Size(152, 50);
                    checkBox2.Size = new Size(152, 50);
                    checkBox3.Size = new Size(152, 50);
                    checkBox4.Size = new Size(152, 50);
                    break;
                case ("True or False"):
                    TrueBtn.Show();
                    FalseBtn.Show();
                    radioButton1.Hide();
                    radioButton2.Hide();
                    radioButton3.Hide();
                    radioButton4.Hide();
                    checkBox1.Hide();
                    checkBox2.Hide();
                    checkBox3.Hide();
                    checkBox4.Hide();
                    FirstInput.Hide(); SecondInput.Hide(); ThirdInput.Hide(); FourthInput.Hide();
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (preview) //Prevents button from doing anything if a question is being previewed
            {
                return;
            }
            else if (checkBox1.Checked && questionTypeSelector.Text != "Fill in the Blank") //Sets FirstInput to be one of the answers for a Checkbox question
            {
                cb1ans = "1";
                checkBox1.Text = "Answer";
            }
            else if (questionTypeSelector.Text != "Fill in the Blank")
            {
                cb1ans = string.Empty;
                checkBox1.Text = string.Empty;
            }
            else
            {
                if (checkBox1.Checked) //Shows 1st alrernative answer textbox and 2nd checkbox
                {
                    checkBox2.Show();
                    SecondInput.Show();
                }
                else
                {
                    checkBox2.Hide();
                    checkBox3.Hide();
                    SecondInput.Hide();
                    ThirdInput.Hide();
                    FourthInput.Hide();
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) //Sets SecondInput to be one of the answers for a Checkbox question
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (preview)
            {
                return;
            }
            else if (checkBox2.Checked && questionTypeSelector.Text != "Fill in the Blank")
            {
                cb2ans = "2";
                checkBox2.Text = "Answer";
            }
            else if (questionTypeSelector.Text != "Fill in the Blank")
            {
                cb2ans = string.Empty;
                checkBox2.Text = string.Empty;
               
            }
            else
            {
                if (checkBox2.Checked) //Shows 2nd alrernative answer textbox and 3rd checkbox
                {
                    checkBox3.Show();
                    cb2ans = string.Empty; ThirdInput.Show();
                }
                else
                {
                    checkBox3.Hide();
                    ThirdInput.Hide();
                    FourthInput.Hide();
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) //Sets ThirdInput to be one of the answers for a Checkbox question
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (preview)
            {
                return;
            }
            else if (checkBox3.Checked && questionTypeSelector.Text != "Fill in the Blank")
            {
                cb3ans = "3";
                checkBox3.Text = "Answer";
            }
            else if (questionTypeSelector.Text != "Fill in the Blank")
            {
                cb3ans = string.Empty;
                checkBox3.Text = string.Empty;
            }
            else
            {
                if (checkBox3.Checked) //Shows 3rd alrernative answer textbox
                {
                    FourthInput.Show();
                }
                else
                {
                    FourthInput.Hide();
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e) //Sets FourthInput to be one of the answers for a Checkbox question
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (preview)
            {
                return;
            }
            else if (checkBox4.Checked && questionTypeSelector.Text != "Fill in the Blank")
            {
                cb4ans = "4";
                checkBox4.Text = "Answer";
            }
            else if (questionTypeSelector.Text != "Fill in the Blank")
            {
                cb4ans = string.Empty;
                checkBox4.Text = string.Empty;
            }
        }

        //Sets answer for a TrueOrFalse question to true, unless a question is being previewed. It will also highlight the TrueBtn
        private void TrueBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (preview)
            {
                TrueBtn.FlatAppearance.BorderColor = Color.White;
            }
            else
            {
                TrueBtn.FlatAppearance.BorderColor = Color.Lime;
                answer = "true";
            }
            TrueBtn.FlatAppearance.BorderSize = 5;
            FalseBtn.FlatAppearance.BorderSize = 0;
        }

        //Sets answer for a TrueOrFalse question to false, unless a question is being previewed. It will also highlight the FalseBtn
        private void FalseBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (preview)
            {
                FalseBtn.FlatAppearance.BorderColor = Color.White;
            }
            else
            {
                FalseBtn.FlatAppearance.BorderColor= Color.Red;
                answer = "false";
            }
            TrueBtn.FlatAppearance.BorderSize = 0;
            FalseBtn.FlatAppearance.BorderSize = 5;   
        }

        //Removes any whitespace from a FillInTheBlank answer
        private readonly Regex sWhitespace = new Regex(@"\s+");
        public string ReplaceWhitespace(string input)
        {
            return sWhitespace.Replace(input, "");
        }

        //These 5 functions prevent users from typing a / into the textbox which would cause the quiz to crash
        private void FirstInput_KeyPress(object sender, KeyEventArgs e)
        {
            var regex = new Regex(@"\/+");
            
            if (regex.IsMatch(FirstInput.Text))
            {
                FirstInput.Text = FirstInput.Text.Replace("/", string.Empty);
            }
        }

        private void SecondInput_KeyUp(object sender, KeyEventArgs e)
        {
            var regex = new Regex(@"\/+");

            if (regex.IsMatch(SecondInput.Text))
            {
                SecondInput.Text = SecondInput.Text.Replace("/", string.Empty);
            }
        }

        private void ThirdInput_KeyUp(object sender, KeyEventArgs e)
        {
            var regex = new Regex(@"\/+");

            if (regex.IsMatch(ThirdInput.Text))
            {
                ThirdInput.Text = ThirdInput.Text.Replace("/", string.Empty);
            }
        }

        private void FourthInput_KeyUp(object sender, KeyEventArgs e)
        {
            var regex = new Regex(@"\/+");

            if (regex.IsMatch(FourthInput.Text))
            {
                FourthInput.Text = FourthInput.Text.Replace("/", string.Empty);
            }
        }

        private void QuestionInput_KeyUp(object sender, KeyEventArgs e)
        {
            var regex = new Regex(@"\/+");

            if (regex.IsMatch(QuestionInput.Text))
            {
                QuestionInput.Text.Replace(@"/", "");
            }
        }
    }
}
