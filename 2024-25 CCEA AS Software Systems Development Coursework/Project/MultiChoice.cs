using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Media;
using System.Web;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{

    public partial class MultiChoice : Form
    {
        //Initalises events, objects & variables
        public event EventHandler UpdateQNum;
        public event EventHandler NextSection;
        SoundPlayer player = new SoundPlayer();
        Questions questions = new Questions();
        Random random = new Random();

        string[] SpecialEventList = { "SmallText", "LargeText", "TimedQuestion", "ObstructedAnswer", "ReverseText", "Wingdings", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer", "ObstructedAnswer" };
        int TimeLeft = 15;
        bool isReverse = false;
        string Reversed = string.Empty;

        public MultiChoice()
        {
            InitializeComponent();
        }

        //Hides all event UI, updates QuestionUI, hides AdminText if admin mode is disabled and calls NewQuestion
        public void MultiChoice_Load(object sender, EventArgs e)
        {
            if (UpdateQNum != null)
            {
                UpdateQNum.Invoke(this, EventArgs.Empty);
            }

            questions.guess = "";
            NoAns.Hide();
            TextBlock1.Hide();
            TextBlock2.Hide();
            TextBlock3.Hide();
            TextBlock4.Hide();
            timer1.Enabled = false;
            TimerLabel.Hide();
            if (!Common_Variables.isAdmin)
            {
                AdminText.Hide();
            }
            NewQuestion(Common_Variables.path);
        }

        //Loads a question in from multichoice.txt
        public string[] NewQuestion(string path)
        {    
            if (this.Visible)
            {
                //Hides event UI
                timer1.Enabled = false;
                TextBlock1.Hide();
                TextBlock2.Hide();
                TextBlock3.Hide();
                TextBlock4.Hide();
                TimerLabel.Hide();
                NoAns.Hide();

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;

                isReverse = false;
                if (Common_Variables.dyslexia) //Sets fonts to either Lucida Sans or Comic Sans MS depending on if user has dyslexia mode enabled
                {
                    QuestionHeader.Font = new Font("Comic Sans MS", 44, FontStyle.Regular);
                    radioButton1.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    radioButton2.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    radioButton3.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    radioButton4.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    AdminText.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    NoAns.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    TimerLabel.Font = new Font("Comic Sans MS", 32, FontStyle.Regular);
                }
                else
                {
                    QuestionHeader.Font = new Font("Lucida Sans", 44, FontStyle.Regular);
                    radioButton1.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    radioButton2.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    radioButton3.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    radioButton4.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    AdminText.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    NoAns.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    TimerLabel.Font = new Font("Lucida Sans", 32, FontStyle.Bold);
                }

                try //Reads a random line in multichoice.txt to get question, rejects it if it has been used or if it does not match the difficulty
                {
                    string[] QuestionsArray;
                    bool valid = false;
                    QuestionsArray = File.ReadAllLines(path + @"\assets\txt\multichoice.txt");
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
                    MessageBox.Show("multichoice.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int rand_num2 = random.Next(5, 9); //Randomly assigns question option to radiobutton, each checks the option on the button before it so that an option is not duplicated
                radioButton1.Text = questions.Split[rand_num2];
                rand_num2 = random.Next(5, 9);
                radioButton2.Text = questions.Split[rand_num2];
                while (radioButton2.Text == radioButton1.Text)
                {
                    rand_num2 = random.Next(5, 9);
                    radioButton2.Text = questions.Split[rand_num2];
                }
                rand_num2 = random.Next(5, 9);
                radioButton3.Text = questions.Split[rand_num2];
                while (radioButton3.Text == radioButton1.Text || radioButton3.Text == radioButton2.Text)
                {
                    rand_num2 = random.Next(5, 9);
                    radioButton3.Text = questions.Split[rand_num2];
                }
                rand_num2 = random.Next(5, 9);
                radioButton4.Text = questions.Split[rand_num2];
                while (radioButton4.Text == radioButton1.Text || radioButton4.Text == radioButton2.Text || radioButton4.Text == radioButton3.Text)
                {
                    rand_num2 = random.Next(5, 9);
                    radioButton4.Text = questions.Split[rand_num2];
                }
                if (Common_Variables.ReadQuestions)
                {
                    ReadQuestion();
                }
                AdminText.Text = "Admin Mode: " + questions.Split[1];
                SpecialEvent();
                return questions.Split;
            }
            return questions.Split;
        }

        //Plays a wav file that contains a text to speech readout of the question, if one exists
        private async void ReadQuestion()
        {
            if (!Common_Variables.muted)
            {
                await Task.Delay(1000);
                if (File.Exists(Common_Variables.path + @"\assets\audio\multi-tts\" + questions.Split[3] + ".wav"))
                {
                    SoundPlayer read = new SoundPlayer(Common_Variables.path + @"\assets\audio\multi-tts\" + questions.Split[3] + ".wav");
                    read.Play();
                }
            }
        }

        //Decides if a special event is triggered if difficulty is above easy
        private void SpecialEvent()
        {
            int event_probability = random.Next(1, 21);
            int event_selected = random.Next(0, 20);
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
                                    radioButton1.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    radioButton2.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    radioButton3.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    radioButton4.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    break;
                                }
                                radioButton1.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                radioButton2.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                radioButton3.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                radioButton4.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                QuestionHeader.Font = new Font("Lucida Sans", 12, FontStyle.Bold);
                                break;
                            case "LargeText":
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 84, FontStyle.Regular);
                                    radioButton1.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    radioButton2.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    radioButton3.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    radioButton4.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    break;
                                }
                                radioButton1.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                radioButton2.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                radioButton3.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                radioButton4.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                QuestionHeader.Font = new Font("Lucida Sans", 84, FontStyle.Bold);
                                break;
                            case "TimedQuestion":
                                TimerLabel.Show();
                                TimedQuestion();
                                break;
                            case "ObstructedAnswer": //Unhides TextBlockers and randomises their positions
                                int rand_x = random.Next(43,1038);
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
                            case "ReverseText": //Reverses text on all radioButtons and QuestionHeader
                                char[] TextArray = radioButton1.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                string Reversed = new string(TextArray);
                                radioButton1.Text = Reversed;
                                TextArray = radioButton2.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                radioButton2.Text = Reversed;
                                TextArray = radioButton3.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                radioButton3.Text = Reversed;
                                TextArray = radioButton4.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                radioButton4.Text = Reversed;
                                TextArray = QuestionHeader.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                QuestionHeader.Text = Reversed;
                                isReverse = true;
                                break;
                            case "Wingdings": //Sets QuestionHeaders font to Wingdings
                                QuestionHeader.Font = new Font("Wingdings", (float)Convert.ToDecimal(questions.Split[2]), FontStyle.Bold);
                                event_probability = random.Next(1, 21);
                                if (event_probability == 1) //In rare cases all fonts are set to Wingdings, although this makes the question impossible to answer without randomly guessing
                                {
                                    radioButton1.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    radioButton2.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    radioButton3.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    radioButton4.Font = new Font("Wingdings", 24, FontStyle.Regular);
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
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 12, FontStyle.Regular);
                                    radioButton1.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    radioButton2.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    radioButton3.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    radioButton4.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    break;
                                }
                                radioButton1.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                radioButton2.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                radioButton3.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                radioButton4.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                QuestionHeader.Font = new Font("Lucida Sans", 12, FontStyle.Bold);
                                break;
                            case "LargeText":
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 84, FontStyle.Regular);
                                    radioButton1.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    radioButton2.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    radioButton3.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    radioButton4.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    break;
                                }
                                radioButton1.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                radioButton2.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                radioButton3.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                radioButton4.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
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
                                char[] TextArray = radioButton1.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                radioButton1.Text = Reversed;
                                TextArray = radioButton2.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                radioButton2.Text = Reversed;
                                TextArray = radioButton3.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                radioButton3.Text = Reversed;
                                TextArray = radioButton4.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                radioButton4.Text = Reversed;
                                TextArray = QuestionHeader.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                QuestionHeader.Text = Reversed;
                                break;
                            case "Wingdings":
                                QuestionHeader.Font = new Font("Wingdings", (float)Convert.ToDecimal(questions.Split[2]), FontStyle.Bold);
                                event_probability = random.Next(1, 21);
                                if (event_probability == 1 || event_probability == 2)
                                {
                                    radioButton1.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    radioButton2.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    radioButton3.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                    radioButton4.Font = new Font("Wingdings", 24, FontStyle.Regular);
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        //These next 4 functions set questions.guess to the current text of the radioButton that was clicked
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            questions.guess = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            questions.guess = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            questions.guess = radioButton3.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            questions.guess = radioButton4.Text;
        }

        //Checks is questions.guess is the same as the answer stored. Gives score accourding to users difficulty if correct and calls NewQuestion
        public void AnsCheck(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                TimerLabel.Hide();

                if (isReverse) //Reverses question.guess if the ReverseText special event triggered, as the answers are not stored in reverse in the text file
                {
                    char[] TextArray = questions.guess.ToCharArray();
                    Array.Reverse(TextArray);
                    questions.guess = new string(TextArray);
                }

                if (questions.guess == questions.Split[1])
                {
                    Common_Variables.LifetimeCorrect += 1;
                    Common_Variables.MultiLifeCorrect += 1;

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
                else if (questions.guess == "")
                {
                    NoAns.Show();
                }
                else
                {
                    Common_Variables.MultiLifeIncorrect += 1;
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

        //Sets the value of TimeLeft accourding to the users difficulty and starts timer
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

        public void CloseForm(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Close();
            }
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
                    TimerLabel.Hide();

                    if (isReverse)
                    {
                        char[] TextArray = questions.guess.ToCharArray();
                        Array.Reverse(TextArray);
                        questions.guess = new string(TextArray);
                    }

                    if (questions.guess == questions.Split[1])
                    {
                        Common_Variables.LifetimeCorrect += 1;
                        Common_Variables.MultiLifeCorrect += 1;

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
                        Common_Variables.MultiLifeIncorrect += 1;
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

        //These 4 functions all play click.wav if the quiz is not muted when a radioButton is clicked
        private void radioButton3_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
        }
    }
}