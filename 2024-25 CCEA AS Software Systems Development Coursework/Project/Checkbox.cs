using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class Checkbox : Form
    {
        //Setup events, declare variables, initialise objects
        public event EventHandler UpdateQNum;
        public event EventHandler NextSection;

        SoundPlayer player = new SoundPlayer();
        Random random = new Random();
        Questions questions = new Questions();

        string cb1ans = string.Empty;
        string cb2ans = string.Empty;
        string cb3ans = string.Empty;
        string cb4ans = string.Empty;

        string[] SpecialEventList = { "SmallText", "LargeText", "TimedQuestion", "ObstructedAnswer", "ReverseText", "Wingdings" };

        int TimeLeft = 0;

        public Checkbox()
        {
            InitializeComponent();
        }

        //Hide UI elements and update the QuestionUI before calling NewQuestion
        private void Checkbox_Load(object sender, EventArgs e)
        {
            TextBlock1.Hide();
            TextBlock2.Hide();
            TextBlock3.Hide();
            TextBlock4.Hide();
            TimerLabel.Hide();
            NoAns.Hide();
            if (!Common_Variables.isAdmin)
            {
                AdminText.Hide();
            }
            if (UpdateQNum != null)
            {
                UpdateQNum.Invoke(this, EventArgs.Empty);
            }
            NewQuestion(Common_Variables.path);
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                cb1ans = "1";
            }
            else
            {
                cb1ans = string.Empty;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                cb2ans = "2";
            }
            else
            {
                cb2ans = string.Empty;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                cb3ans = "3";
            }
            else
            {
                cb3ans = string.Empty;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                cb4ans = "4";
            }
            else
            {
                cb4ans = string.Empty;
            }
        }

        public string[] NewQuestion(string path)
        {
            if (this.Visible)
            {//Hides  Event UI and unchecks all checkboxes
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;

                TextBlock1.Hide();
                TextBlock2.Hide();
                TextBlock3.Hide();
                TextBlock4.Hide();
                TimerLabel.Hide();
                timer1.Enabled = false;
                NoAns.Hide();

                //Sets fonts for label to either Lucida Sans or Comic Sans MS
                if (Common_Variables.dyslexia)
                {
                    checkBox1.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    checkBox2.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    checkBox3.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    checkBox4.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    AdminText.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    NoAns.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    TimerLabel.Font = new Font("Comic Sans MS", 32, FontStyle.Regular);
                }
                else
                {
                    checkBox1.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    checkBox2.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    checkBox3.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    checkBox4.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    AdminText.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    NoAns.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    TimerLabel.Font = new Font("Lucida Sans", 32, FontStyle.Bold);
                }

                //Picks a random question from checkbox.txt and loads it onto the checkboxes and QuestionHeader
                try
                {
                    string[] QuestionsArray;
                    QuestionsArray = File.ReadAllLines(path + @"\assets\txt\checkbox.txt");
                    int no_of_questions = QuestionsArray.Count();
                    int rand_num = random.Next(0, no_of_questions);
                    questions.Split = QuestionsArray[rand_num].Split('/');

                    bool valid = false;
                    while (valid == false) //Rejects questions if they have been used before or if the difficulty does not match the current difficulty
                    {
                        if (questions.Split[0] != Common_Variables.difficulty && Common_Variables.difficulty != "n")
                        {
                            rand_num = random.Next(1, no_of_questions);
                            questions.Split = QuestionsArray[rand_num].Split('/');
                            valid = true;
                        }
                        else
                        {
                            bool duplicate = false;
                            for (int i = 0; i < Common_Variables.UsedQuestions.Count; i++)
                            {
                                if (Common_Variables.UsedQuestions.ElementAt(i) == questions.Split[3])
                                {
                                    duplicate = true;
                                    rand_num = random.Next(0, no_of_questions);
                                    questions.Split = QuestionsArray[rand_num].Split('/');
                                    break;
                                }
                            }
                            if (duplicate == false)
                            {
                                Common_Variables.UsedQuestions.Add(questions.Split[3]);
                                valid = true;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("checkbox.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(Environment.ExitCode);
                }
                QuestionHeader.Text = questions.Split[4];
                if (Common_Variables.dyslexia)
                {
                    QuestionHeader.Font = new Font("Comic Sans MS", (float)Convert.ToDecimal(questions.Split[2]), FontStyle.Bold);
                }
                else
                {
                    QuestionHeader.Font = new Font("Lucida Sans", (float)Convert.ToDecimal(questions.Split[2]), FontStyle.Bold);
                }
                checkBox1.Text = questions.Split[5];
                checkBox2.Text = questions.Split[6];
                checkBox3.Text = questions.Split[7];
                checkBox4.Text = questions.Split[8];
                UpdateAdmin();
                SpecialEvent();
                if (Common_Variables.ReadQuestions)
                {
                    ReadQuestion();
                }
                return questions.Split;
            }
            return questions.Split;
        }

        //Checks users answer to see if it is correct, gives score according to difficulty if correct and then calls NewQuestion
        public void AnsCheck(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                string cbcombined = cb1ans + cb2ans + cb3ans + cb4ans;
                if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
                {
                    NoAns.Show();
                }
                else if (cbcombined == questions.Split[1])
                {
                    Common_Variables.CheckLifeCorrect += 1;
                    Common_Variables.LifetimeCorrect += 1;
                    switch (Common_Variables.difficulty)
                    {
                        case "e":
                            Common_Variables.score += 0.5;
                            if (Common_Variables.muted == false)
                            {
                                player.Stream = Properties.Resources.ding;
                                player.Play();
                            }
                            break;
                        case "n":
                            Common_Variables.score += 0.75;
                            if (Common_Variables.muted == false)
                            {
                                player.Stream = Properties.Resources.ding;
                                player.Play();
                            }
                            break;
                        case "h":
                            Common_Variables.score += 1;
                            if (Common_Variables.muted == false)
                            {
                                player.Stream = Properties.Resources.ding;
                                player.Play();
                            }
                            break;
                    }
                    if (Common_Variables.q_number % 5 == 0 || Common_Variables.q_number > 19)
                    {
                        if (NextSection != null)
                        {
                            Common_Variables.q_number = Common_Variables.q_number + 1;
                            NextSection.Invoke(this, EventArgs.Empty);
                            this.Close();
                            return;
                        }
                    }
                    Common_Variables.q_number = Common_Variables.q_number + 1;
                    if (UpdateQNum != null)
                    {
                        UpdateQNum.Invoke(this, EventArgs.Empty);
                    }
                    NewQuestion(Common_Variables.path);
                }
                else
                {
                    Common_Variables.CheckLifeIncorrect += 1;
                    Common_Variables.LifetimeIncorrect += 1;

                    if (!Common_Variables.muted)
                    {
                        player.Stream = Properties.Resources.wrong;
                        player.Play();
                    }

                    if (Common_Variables.q_number % 5 == 0 || Common_Variables.q_number > 19)
                    {
                        if (NextSection != null)
                        {
                            Common_Variables.q_number = Common_Variables.q_number + 1;
                            NextSection.Invoke(this, EventArgs.Empty);
                            this.Close();
                            return;
                        }
                    }
                    Common_Variables.q_number = Common_Variables.q_number + 1;

                    if (UpdateQNum != null)
                    {
                        UpdateQNum.Invoke(this, EventArgs.Empty);
                    }
                    NewQuestion(Common_Variables.path);
                }
            }
        }

        public void CloseForm(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Close();
            }
        }

        //Decides if a special event is triggered if difficulty is above easy
        private void SpecialEvent()
        {
            int event_probability = random.Next(1, 21);
            int event_selected = random.Next(0, 6);
            switch (Common_Variables.difficulty)
            {
                case "n":
                    if (event_probability == 1 || event_probability == 2)
                    {
                        switch (SpecialEventList[event_selected])
                        {
                            case "SmallText":
                                checkBox1.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                checkBox2.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                checkBox3.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                checkBox4.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                QuestionHeader.Font = new Font("Lucida Sans", 12, FontStyle.Bold);
                                break;
                            case "LargeText":
                                checkBox1.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                checkBox2.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                checkBox3.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                checkBox4.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                QuestionHeader.Font = new Font("Lucida Sans", 84, FontStyle.Bold);
                                break;
                            case "TimedQuestion":
                                TimerLabel.Show();
                                TimedQuestion();
                                break;
                            case "ObstructedAnswer": //Randomises position of TextBlockers
                                int rand_x = random.Next(43, 1038);
                                int rand_y = random.Next(163, 600);
                                TextBlock1.Location = new Point(rand_x, rand_y);
                                TextBlock2.Location = new Point((rand_x = random.Next(43, 1038)), (rand_y = random.Next(163, 600)));
                                TextBlock3.Location = new Point((rand_x = random.Next(43, 1038)), (rand_y = random.Next(163, 600)));
                                TextBlock4.Location = new Point((rand_x = random.Next(43, 1038)), (rand_y = random.Next(163, 600)));
                                TextBlock1.Show();
                                TextBlock2.Show();
                                TextBlock3.Show();
                                TextBlock4.Show();
                                break;
                            case "ReverseText": //Reverses all text on QuestionHeader & checkboxes
                                char[] TextArray = checkBox1.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                string checkBoxReversed = new string(TextArray);
                                checkBox1.Text = checkBoxReversed;
                                TextArray = checkBox2.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                checkBoxReversed = new string(TextArray);
                                checkBox2.Text = checkBoxReversed;
                                TextArray = checkBox3.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                checkBoxReversed = new string(TextArray);
                                checkBox3.Text = checkBoxReversed;
                                TextArray = checkBox4.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                checkBoxReversed = new string(TextArray);
                                checkBox4.Text = checkBoxReversed;
                                TextArray = QuestionHeader.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                checkBoxReversed = new string(TextArray);
                                QuestionHeader.Text = checkBoxReversed;
                                break;
                            case "Wingdings":
                                QuestionHeader.Font = new Font("Wingdings", (float)Convert.ToDecimal(questions.Split[2]), FontStyle.Bold);
                                event_probability = random.Next(1, 21);
                                if (event_probability == 1) //In rare cases all fonts are set to Wingdings, although this makes the question impossible to answer without randomly guessing
                                {
                                    checkBox1.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    checkBox2.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    checkBox3.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    checkBox4.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                }
                                break;
                        }
                    }
                    break;
                case "h":
                    if (event_probability == 1 || event_probability == 2 || event_probability == 3)
                    {
                        switch (SpecialEventList[event_selected])
                        {
                            case "SmallText":
                                checkBox1.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                checkBox2.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                checkBox3.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                checkBox4.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                QuestionHeader.Font = new Font("Lucida Sans", 12, FontStyle.Bold);
                                break;
                            case "LargeText":
                                checkBox1.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                checkBox2.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                checkBox3.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                checkBox4.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                QuestionHeader.Font = new Font("Lucida Sans", 84, FontStyle.Bold);
                                break;
                            case "TimedQuestion":
                                TimerLabel.Show();
                                TimedQuestion();
                                break;
                            case "ObstructedAnswer":
                                int rand_x = random.Next(43, 1038);
                                int rand_y = random.Next(163, 600);
                                TextBlock1.Location = new Point(rand_x, rand_y);
                                TextBlock2.Location = new Point((rand_x = random.Next(43, 1038)), (rand_y = random.Next(163, 600)));
                                TextBlock3.Location = new Point((rand_x = random.Next(43, 1038)), (rand_y = random.Next(163, 600)));
                                TextBlock4.Location = new Point((rand_x = random.Next(43, 1038)), (rand_y = random.Next(163, 600)));
                                TextBlock1.Show();
                                TextBlock2.Show();
                                TextBlock3.Show();
                                TextBlock4.Show();
                                break;
                            case "ReverseText":
                                char[] TextArray = checkBox1.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                string checkBoxReversed = new string(TextArray);
                                checkBox1.Text = checkBoxReversed;
                                TextArray = checkBox2.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                checkBoxReversed = new string(TextArray);
                                checkBox2.Text = checkBoxReversed;
                                TextArray = checkBox3.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                checkBoxReversed = new string(TextArray);
                                checkBox3.Text = checkBoxReversed;
                                TextArray = checkBox4.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                checkBoxReversed = new string(TextArray);
                                checkBox4.Text = checkBoxReversed;
                                TextArray = QuestionHeader.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                checkBoxReversed = new string(TextArray);
                                QuestionHeader.Text = checkBoxReversed;
                                break;
                            case "Wingdings":
                                QuestionHeader.Font = new Font("Wingdings", (float)Convert.ToDecimal(questions.Split[2]), FontStyle.Bold);
                                event_probability = random.Next(1, 21);
                                if (event_probability == 1)
                                {
                                    checkBox1.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    checkBox2.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    checkBox3.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    checkBox4.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                }
                                break;
                        }
                    }
                    break;
            }

        }

        //Runs every second the timer is active, ticks down TimeLeft and runs the code from AnsCheck (bar the no answer detection) if TimeLeft is less than 1
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLeft--;
            TimerLabel.Text = TimeLeft.ToString();
            if (TimeLeft <= 0)
            {
                string cbcombined = cb1ans + cb2ans + cb3ans + cb4ans;
                if (cbcombined == questions.Split[1])
                {
                    switch (Common_Variables.difficulty)
                    {
                        case "e":
                            Common_Variables.score += 0.5;
                            if (Common_Variables.muted == false)
                            {
                                player.Stream = Properties.Resources.ding;
                                player.Play();
                            }
                            break;
                        case "n":
                            Common_Variables.score += 0.75;
                            if (Common_Variables.muted == false)
                            {
                                player.Stream = Properties.Resources.ding;
                                player.Play();
                            }
                            break;
                        case "h":
                            Common_Variables.score += 1;
                            if (Common_Variables.muted == false)
                            {
                                player.Stream = Properties.Resources.ding;
                                player.Play();
                            }
                            break;
                    }
                    if (Common_Variables.q_number % 5 == 0 || Common_Variables.q_number > 19)
                    {
                        if (NextSection != null)
                        {
                            NextSection.Invoke(this, EventArgs.Empty);
                            this.Close();
                        }
                    }
                    Common_Variables.q_number = Common_Variables.q_number + 1;
                    if (UpdateQNum != null)
                    {
                        UpdateQNum.Invoke(this, EventArgs.Empty);
                    }
                    NewQuestion(Common_Variables.path);
                }
                else
                {
                    Common_Variables.CheckLifeIncorrect += 1;
                    Common_Variables.LifetimeIncorrect += 1;
                    if (!Common_Variables.muted)
                    {
                        player.Stream = Properties.Resources.wrong;
                        player.Play();
                    }

                    if (Common_Variables.q_number % 5 == 0 || Common_Variables.q_number > 19)
                    {
                        if (NextSection != null)
                        {
                            NextSection.Invoke(this, EventArgs.Empty);
                            this.Close();
                        }
                    }
                    Common_Variables.q_number = Common_Variables.q_number + 1;

                    if (UpdateQNum != null)
                    {
                        UpdateQNum.Invoke(this, EventArgs.Empty);
                    }
                    NewQuestion(Common_Variables.path);
                }
            }
        }

        //Sets the value of TimeLeft accourding to the difficulty
        public void TimedQuestion()
        {
            timer1.Enabled = true;
            if (Common_Variables.difficulty == "n")
            {
                TimeLeft = 15;
            }
            else
            {
                TimeLeft = 10;
            }
        }

        //Plays a wav file that contains a text to speech readout of the question, if one exists
        private async void ReadQuestion()
        {
            if (!Common_Variables.muted)
            {
                await Task.Delay(1000);
                if (File.Exists(Common_Variables.path + @"\assets\audio\check-tts\" + questions.Split[3] + ".wav"))
                {
                    SoundPlayer read = new SoundPlayer(Common_Variables.path + @"\assets\audio\check-tts\" + questions.Split[3] + ".wav");
                    read.Play();
                }
            }
        }

        //Shows the user the answer of the current question if Admin mode is enabled
        private void UpdateAdmin()
        {
            string tempAdmin = string.Empty;
            char[] tempArray = questions.Split[1].ToCharArray();

            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] == '1')
                {
                    tempAdmin = tempAdmin + checkBox1.Text + ", ";
                }
                else if (tempArray[i] == '2')
                {
                    tempAdmin = tempAdmin + checkBox2.Text + ", ";
                }
                else if (tempArray[i] == '3')
                {
                    tempAdmin += checkBox3.Text + ", ";
                }
                else if (tempArray[i] == '4')
                {
                    tempAdmin += checkBox4.Text;
                }
            }

            AdminText.Text = "Admin Mode: " + tempAdmin;
        }

        //These 4 events all play click.wav if the quiz is not muted when the checkboxes are clicked
        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
        }
    }
}