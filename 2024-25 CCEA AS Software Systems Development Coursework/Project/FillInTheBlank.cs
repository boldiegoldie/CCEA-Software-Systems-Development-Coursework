using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class FillInTheBlank : Form
    {
        //Initialise events, objects and variables
        public event EventHandler UpdateQNum;
        public event EventHandler NextSection;
        SoundPlayer player = new SoundPlayer();
        Questions questions = new Questions();
        Random random = new Random();
        bool correct = false;

        string[] SpecialEventList = { "SmallText", "LargeText", "TimedQuestion", "ReverseText" };
        int TimeLeft = 0;

        public FillInTheBlank()
        {
            InitializeComponent();
        }

        //Reads a random line from fillinblank.txt to pull question
        public string[]NewQuestion(string path)
        {
            if (this.Visible)
            {
                //Hides event UI
                NoAns.Hide();
                TimerLabel.Hide();
                timer1.Enabled = false;

                //Loads in a question, rejects it if it has been used before or if it does not match the users selected difficulty
                try
                {
                    string[] QuestionsArray;
                    bool valid = false;
                    QuestionsArray = File.ReadAllLines(path + @"\assets\txt\fillinblank.txt");
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
                    MessageBox.Show("fillinblank.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(Environment.ExitCode);
                }
                QuestionHeader.Text = questions.Split[4];
                if (Common_Variables.dyslexia) //Chnages font to Lucida Sans or Comic Sans MS depending on if dyslexia mode is enabled
                {
                    QuestionHeader.Font = new Font("Comic Sans MS", (float)Convert.ToDecimal(questions.Split[2]), FontStyle.Regular);
                    AnswerInput.Font = new Font("Comic Sans MS", 31, FontStyle.Regular);
                    AdminText.Font = new Font("Comic Sans MS", 31, FontStyle.Regular);
                }
                else
                {
                    QuestionHeader.Font = new Font("Lucida Sans", (float)Convert.ToDecimal(questions.Split[2]), FontStyle.Bold);
                    AnswerInput.Font = new Font("Lucida Sans", 31, FontStyle.Bold);
                    AdminText.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                }
                AdminText.Text = "Admin Mode: " + questions.Split[1];
                AnswerInput.Text = string.Empty;
                if (Common_Variables.ReadQuestions)
                {
                    ReadQuestion();
                }
                SpecialEvent();
                AnswerInput.Text = "Enter Answer Here";
                return questions.Split;
            }
            return questions.Split;
        }

        //Decides if a special event is triggered if difficulty is above easy
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
                                    AnswerInput.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    break;
                                }
                                QuestionHeader.Font = new Font("Lucida Sans", 12, FontStyle.Bold);
                                AnswerInput.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                break;
                            case "LargeText":
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 84, FontStyle.Regular);
                                    AnswerInput.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    break;
                                }
                                QuestionHeader.Font = new Font("Lucida Sans", 84, FontStyle.Bold);
                                AnswerInput.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                break;
                            case "TimedQuestion":
                                TimerLabel.Show();
                                TimedQuestion();
                                break;
                            case "ReverseText": //Reverses all text on QuestionHeader
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
                                    AnswerInput.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    break;
                                }
                                QuestionHeader.Font = new Font("Lucida Sans", 12, FontStyle.Bold);
                                AnswerInput.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                break;
                            case "LargeText":
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 84, FontStyle.Regular);
                                    AnswerInput.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    break;
                                }
                                QuestionHeader.Font = new Font("Lucida Sans", 84, FontStyle.Bold);
                                AnswerInput.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
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

        //Checks users answer to see if it is correct, gives score according to difficulty if correct and then calls NewQuestion
        public void AnsCheck(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                correct = false;
                string[] answer = questions.Split[1].Split(',');
                AnswerInput.Text = ReplaceWhitespace(AnswerInput.Text);
                AnswerInput.Text = AnswerInput.Text.ToLower();
                for (int i = 0; i < answer.Length; i++)
                {
                    if (AnswerInput.Text == answer[i])
                    {
                        correct = true;
                    }
                }
                if (correct)
                {
                    Common_Variables.BlankLifeCorrect++;
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
                else if (correct == false)
                {
                    Common_Variables.BlankLifeIncorrect += 1;
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
                            Common_Variables.q_number += 1;
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
                else if (AnswerInput.Text == "Enter Answer Here" || AnswerInput.Text == string.Empty)
                {
                    NoAns.Show();
                }
            }
        }

        //Plays a wav file that contains a text to speech readout of the question, if one exists
        private async void ReadQuestion()
        {
            if (!Common_Variables.muted)
            {
                await Task.Delay(1000);
                if (File.Exists(Common_Variables.path + @"\assets\audio\blank-tts\" + questions.Split[3] + ".wav"))
                {
                    SoundPlayer read = new SoundPlayer(Common_Variables.path + @"\assets\audio\blank-tts\" + questions.Split[3] + ".wav");
                    read.Play();
                }
            }
        }


        public void CloseForm(object sender , EventArgs e)
        {
            if (this.Visible)
            {
                this.Close();
            }
        }

        //Hides AdminText if admin mode is disabled, updates QuestionUI and calls NewQuestion
        private void FillInTheBlank_Load(object sender, EventArgs e)
        {
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

        //Removes any whitespace from the users answer
        private readonly Regex sWhitespace = new Regex(@"\s+");
        private string ReplaceWhitespace(string input)
        {
            return sWhitespace.Replace(input, "");
        }

        //Sets the value of TimeLeft depending on the difficulty
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
                if (this.Visible)
                {
                    correct = false;
                    string[] answer = questions.Split[1].Split(',');
                    AnswerInput.Text = ReplaceWhitespace(AnswerInput.Text);
                    for (int i = 0; i < answer.Length; i++)
                    {
                        if (AnswerInput.Text == answer[i])
                        {
                            correct = true;
                        }
                    }
                    if (correct)
                    {
                        Common_Variables.BlankLifeCorrect++;
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
                    else if (correct == false)
                    {
                        Common_Variables.BlankLifeIncorrect += 1;
                        Common_Variables.LifetimeIncorrect += 1;
                        if (Common_Variables.muted)
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

        //Blanks text in AnswerInput if the default text is present, so the user does not have to do it themselves
        private void AnswerInput_Click(object sender, EventArgs e)
        {
            if (AnswerInput.Text == "Enter Answer Here")
            {
                AnswerInput.Text = string.Empty;
            }
        }
    }
}
