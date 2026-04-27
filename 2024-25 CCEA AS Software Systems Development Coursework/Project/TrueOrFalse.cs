using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class TrueOrFalse : Form
    {
        //Initalises objects, variables and events
        Random random = new Random();
        Questions questions = new Questions();
        SoundPlayer player = new SoundPlayer();

        string[] SpecialEventList = { "SmallText", "LargeText", "TimedQuestion", "ReverseText" };
        int TimeLeft = 0;

        public event EventHandler UpdateQNum;
        public event EventHandler NextSection;

        public TrueOrFalse()
        {
            InitializeComponent();
        }

        //Calls NewQuestion when form loads
        private void TrueOrFalse_Load(object sender, EventArgs e)
        {
            //Configures visual style for buttons
            FalseBtn.FlatStyle = FlatStyle.Flat;
            FalseBtn.FlatAppearance.BorderSize = 0;
            FalseBtn.FlatAppearance.BorderColor = Color.White;
            TrueBtn.FlatStyle = FlatStyle.Flat;
            TrueBtn.FlatAppearance.BorderSize = 0;
            TrueBtn.FlatAppearance.BorderColor = Color.White;

            if (UpdateQNum != null)
            {
                UpdateQNum.Invoke(this, EventArgs.Empty);
            }

            if (!Common_Variables.isAdmin)
            {
                AdminText.Hide();
            }
            NoAns.Hide();
            TimerLabel.Hide();

            NewQuestion(Common_Variables.path);
        }

        //Pulls a random question from trueorfalse.txt
        public string[] NewQuestion(string path)
        {
            if (this.Visible)
            {
                //Resets buttons & event UI
                FalseBtn.FlatAppearance.BorderSize = 0;
                TrueBtn.FlatAppearance.BorderSize = 0;
                NoAns.Hide();
                TimerLabel.Hide();

                timer1.Enabled = false;

                questions.guess = "no ans";

                //Load a question, rejects it if it has been used before or does not match the difficulty selected
                try
                {
                    string[] QuestionsArray;
                    bool valid = false;
                    QuestionsArray = File.ReadAllLines(path + @"\assets\txt\trueorfalse.txt");
                    int no_of_questions = QuestionsArray.Count();
                    int rand_num = random.Next(0, no_of_questions);
                    questions.Split = QuestionsArray[rand_num].Split('/');
                    while (valid == false)
                    {
                        if (questions.Split[0] != Common_Variables.difficulty && Common_Variables.difficulty != "n")
                        {
                            rand_num = random.Next(1, no_of_questions);
                            questions.Split = QuestionsArray[rand_num].Split('/');
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
                    MessageBox.Show("trueorfalse.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(Environment.ExitCode);
                }
                QuestionHeader.Text = questions.Split[4];
                if (Common_Variables.dyslexia) // Sets font to either Lucida Sans or Comic Sans MS, depending on if dyslexia mode is enabled
                {
                    QuestionHeader.Font = new Font("Comic Sans MS", (float)Convert.ToDecimal(questions.Split[2]), FontStyle.Regular);
                    TrueBtn.Font = new Font("Comic Sans MS", 44, FontStyle.Regular);
                    FalseBtn.Font = new Font("Comic Sans MS", 44, FontStyle.Regular);
                    TimerLabel.Font = new Font("Comic Sans MS", 32, FontStyle.Regular);
                    AdminText.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    NoAns.Font = new Font("Comic Sans MS", 28, FontStyle.Regular);
                }
                else
                {
                    QuestionHeader.Font = new Font("Lucida Sans", (float)Convert.ToDecimal(questions.Split[2]), FontStyle.Bold);
                    TrueBtn.Font = new Font("Lucida Sans", 44, FontStyle.Bold);
                    FalseBtn.Font = new Font("Lucida Sans", 44, FontStyle.Bold);
                    TimerLabel.Font = new Font("Lucida Sans", 32, FontStyle.Bold);
                    AdminText.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    NoAns.Font = new Font("Lucida Sans", 28, FontStyle.Bold);
                }
                AdminText.Text = "Admin Mode: " + questions.Split[1];
                if (Common_Variables.ReadQuestions)
                {
                    ReadQuestion();
                }
                SpecialEvent();
                return questions.Split;
            }
            return questions.Split;
        }

        //checks if users answer is correct, gives points accourdingly and calls NewQuestion
        public void AnsCheck(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                if (questions.guess != "no ans")
                {
                    if (questions.guess == questions.Split[1])
                    {
                        Common_Variables.TorfLifeCorrect++;
                        Common_Variables.LifetimeCorrect++;
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
                        Common_Variables.TorfLifeIncorrect += 1;
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
                else
                {
                    NoAns.Show();
                }
            }
        }

        //Determines if a special event happens, only when diffculty is above easy
        private void SpecialEvent()
        {
            int event_probability = random.Next(1, 21);
            int event_selected = random.Next(0, 4);
            switch (Common_Variables.difficulty)
            {
                case "n":
                    if (event_probability == 1 || event_probability == 2)
                    {
                        switch (SpecialEventList[event_selected])
                        {
                            case "SmallText":
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 12, FontStyle.Regular);
                                    break;
                                }
                                QuestionHeader.Font = new Font("Lucida Sans", 12, FontStyle.Bold);
                                break;
                            case "LargeText":
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 84, FontStyle.Regular);
                                    break;
                                }
                                QuestionHeader.Font = new Font("Lucida Sans", 84, FontStyle.Bold);
                                break;
                            case "TimedQuestion":
                                TimerLabel.Show();
                                TimedQuestion();
                                break;
                            case "ReverseText": //Reverses text on QuestionHeader
                                char[] TextArray = QuestionHeader.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                string Reversed = new string(TextArray);
                                QuestionHeader.Text = Reversed;
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
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 12, FontStyle.Regular);
                                    break;
                                }
                                QuestionHeader.Font = new Font("Lucida Sans", 12, FontStyle.Bold);
                                break;
                            case "LargeText":
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 84, FontStyle.Regular);
                                    break;
                                }
                                QuestionHeader.Font = new Font("Lucida Sans", 84, FontStyle.Bold);
                                break;
                            case "TimedQuestion":
                                TimerLabel.Show();
                                TimedQuestion();
                                break;
                            case "ReverseText":
                                char[] TextArray = QuestionHeader.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                string Reversed = new string(TextArray);
                                QuestionHeader.Text = Reversed;
                                break;
                        }
                    }
                    break;
            }
        }

        //Sets users guess to false and highlights the FalseBtn
        private void FalseBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            questions.guess = "false";
            FalseBtn.FlatAppearance.BorderSize = 5;
            TrueBtn.FlatAppearance.BorderSize = 0;
        }

        //Sets users guess to false and highlights the TrueBtn
        private void TrueBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            questions.guess = "true";
            TrueBtn.FlatAppearance.BorderSize = 5;
            FalseBtn.FlatAppearance.BorderSize = 0;
        }

        public void CloseForm(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Close();
            }
        }

        //Plays a wav file that contains a text to speech readout of the question, if one exists
        private async void ReadQuestion()
        {
            if (!Common_Variables.muted)
            {
                await Task.Delay(1000);
                if (File.Exists(Common_Variables.path + @"\assets\audio\torf-tts\" + questions.Split[3] + ".wav"))
                {
                    SoundPlayer read = new SoundPlayer(Common_Variables.path + @"\assets\audio\torf-tts\" + questions.Split[3] + ".wav");
                    read.Play();
                }
            }
        }

        //Sets TimeLeft accourding to difficulty & starts timer
        public void TimedQuestion()
        {
            if (Common_Variables.difficulty == "n")
            {
                TimeLeft = 15;
            }
            else
            {
                TimeLeft = 10;
            }
            timer1.Enabled = true;
        }

        //Runs every second the timer is active, ticks down TimeLeft and runs the code from AnsCheck (bar the no answer detection) if TimeLeft is less than 1
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLeft--;
            TimerLabel.Text = TimeLeft.ToString();

            if (TimeLeft <= 0)
            {
                if (this.Visible == true)
                { 
                    if (questions.guess == questions.Split[1])
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
                            MessageBox.Show("Next Section");
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
                        Common_Variables.TorfLifeIncorrect += 1;
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
        }
    }
}
