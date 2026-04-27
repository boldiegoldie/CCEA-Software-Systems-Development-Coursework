using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{

    public partial class HomeScreen : Form
    {
        //Initialises objects
        ReturnTo Target = new ReturnTo();
        Random random = new Random();
        IFormatter serialise = new BinaryFormatter();
        IFormatter deserialise = new BinaryFormatter();
        UserData User = new UserData();
        List<string> UsedSection = new List<string> { "MultiChoice", "Checkbox", "FillInBlank", "TrueOrFalse", "DragAndDrop" };
        List<UserData> userlist = new List<UserData>();
        SoundPlayer player = new SoundPlayer();

        public HomeScreen()
        {
            //Sets the style of buttons
            InitializeComponent();
            BackBtn.FlatStyle = FlatStyle.Flat;
            BackBtn.FlatAppearance.BorderSize = 0;
            BackBtn.Image = Properties.Resources.BackButton64;
            MuteToggle.FlatStyle = FlatStyle.Flat;
            MuteToggle.FlatAppearance.BorderSize = 0;
            CheckAns.FlatStyle = FlatStyle.Flat;
            CheckAns.FlatAppearance.BorderSize = 0;
            TutorialBtn.FlatStyle = FlatStyle.Flat;
            TutorialBtn.FlatAppearance.BorderSize = 0;

            //Hides UI
            QuestionUI.Hide();
            BackBtn.Hide();
            MuteToggle.Hide();
            CheckAns.Hide();
            TutorialBtn.Hide();

            Common_Variables.UsedQuestions.Add("placeholder");
        }

        //Changes image shown on mute_toggle and mutes/unmutes the game
        public void MuteToggle_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                MuteToggle.Image = Properties.Resources.Muted64Red;
                Common_Variables.muted = true;
            }
            else if (Common_Variables.muted == true)
            {
                MuteToggle.Image = Properties.Resources.UnMuted64;
                Common_Variables.muted = false;
            }

            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
        }

        public void BackBtn_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            BackBtn.Location = new Point(1485, 770);
            MuteToggle.Location = new Point(1370, 770);
            CheckAns.Location = new Point(1255, 770);

            //Checks the target of the back button, shows the accorrding screen when the back button is pressed
            switch (Target.Target)
            {
                case ("welcome"):
                    WelcomeScreen Welcome = new WelcomeScreen();
                    Welcome.TopLevel = false;
                    Welcome.AutoScroll = true;
                    Welcome.FormBorderStyle = FormBorderStyle.None;
                    Welcome.Dock = DockStyle.Fill;
                    HomePanel.Controls.Clear();
                    HomePanel.Controls.Add(Welcome);
                    Welcome.ShowCreate += new EventHandler(ShowCreate);
                    Welcome.ShowLogin += new EventHandler(ShowLogin);
                    BackBtn.Hide();
                    MuteToggle.Hide();
                    TutorialBtn.Hide();
                    CheckAns.Hide();
                    this.Text = "Welcome to The Circuit Breaker Quiz";
                    Welcome.Show();
                    break;
                case ("lobby"):
                    Lobby lobby = new Lobby();
                    lobby.TopLevel = false;
                    lobby.AutoScroll = true;
                    lobby.FormBorderStyle = FormBorderStyle.None;
                    lobby.Dock = DockStyle.Fill;
                    HomePanel.Controls.Clear();
                    HomePanel.Controls.Add(lobby);
                    this.Text = "Lobby | The Circuit Breaker Quiz";
                    Target.Target = "welcome";
                    lobby.ShowDifficulty += new EventHandler(ShowDifficulty);
                    lobby.StartQuiz += new EventHandler(NextSection);
                    lobby.ShowLeaderboard += new EventHandler(ShowLeaderboard);
                    lobby.ShowQuestionDesigner += new EventHandler(ShowQuestionDesigner);
                    lobby.ShowSettings += new EventHandler(ShowSettings);;
                    TutorialBtn.Location = new Point(1255, 770);
                    BackBtn.Image = Properties.Resources.Logout64;
                    Common_Variables.score = 0;
                    Common_Variables.q_number = 1;
                    Common_Variables.UsedQuestions.Clear();
                    UsedSection.Clear();
                    UsedSection.Add("MultiChoice");
                    UsedSection.Add("Checkbox");
                    UsedSection.Add("DragAndDrop");
                    UsedSection.Add("FillInBlank");
                    UsedSection.Add("TrueOrFalse");
                    Common_Variables.CurrentPage = "Multi";
                    QuestionUI.Hide();
                    CheckAns.Hide();
                    MuteToggle.Show();
                    TutorialBtn.Show();
                    lobby.Show();
                    BackBtn.Click += lobby.CloseForm;
                    break;
                case ("settings"):
                    Settings settings = new Settings();
                    settings.TopLevel = false;
                    settings.AutoScroll = true;
                    settings.FormBorderStyle = FormBorderStyle.None;
                    settings.Dock = DockStyle.Fill;
                    HomePanel.Controls.Add(settings);
                    this.Text = "Settings | The Circuit Breaker Quiz";
                    Target.Target = "lobby";
                    BackBtn.Image = Properties.Resources.BackButton64;
                    CheckAns.Location = new Point(1485, 770);
                    BackBtn.Location = new Point(1370, 770);
                    MuteToggle.Location = new Point(1255, 770);
                    CheckAns.Show();
                    TutorialBtn.Show();
                    settings.Show();
                    settings.ShowTextView += new EventHandler(ShowTextView);
                    BackBtn.Click += settings.CloseForm;
                    CheckAns.Click += settings.ApplySettings;
                    break;
                case ("designer"):
                    QuestionDesigner designer = new QuestionDesigner();
                    designer.TopLevel = false;
                    designer.AutoScroll = true;
                    designer.FormBorderStyle = FormBorderStyle.None;
                    designer.Dock = DockStyle.Fill;
                    HomePanel.Controls.Add(designer);
                    TutorialBtn.Show();
                    this.Text = "Question Designer | The Circuit Breaker Quiz";
                    Target.Target = "lobby";
                    BackBtn.Image = Properties.Resources.BackButton64;
                    BackBtn.Click += designer.CloseForm;
                    designer.ShowTextView += new EventHandler(ShowTextView);
                    designer.Show();
                    break;
            }
        }

        //Show CreateAccount on the panel and calls the ShowLobby object when Create.LoadLobby is invoked
        public void ShowCreate(object sender, EventArgs e)
        {
            CreateAccount Create = new CreateAccount();
            Create.TopLevel = false;
            Create.AutoScroll = true;
            Create.FormBorderStyle = FormBorderStyle.None;
            Create.Dock = DockStyle.Fill;
            HomePanel.Controls.Add(Create);
            Create.LoadLobby += new EventHandler(ShowLobby);
            this.Text = "Create an account | The Circuit Breaker Quiz";
            Target.Target = "welcome";
            BackBtn.Image = Properties.Resources.BackButton64;
            BackBtn.Show();
            Create.Show();
            BackBtn.Click += Create.CloseForm;
        }

        //Shows ShowLogin on the panel, and calls ShowLobby when LoadLobby is invoked
        public void ShowLogin(object sender, EventArgs e)
        {
            Login login = new Login();
            login.TopLevel = false;
            login.AutoScroll = true;
            login.FormBorderStyle = FormBorderStyle.None;
            login.Dock = DockStyle.Fill;
            HomePanel.Controls.Add(login);
            login.LoadLobby += new EventHandler(ShowLobby);
            this.Text = "Login | The Circuit Breaker Quiz";
            Target.Target = "welcome";
            BackBtn.Image = Properties.Resources.BackButton64;
            BackBtn.Show();
            login.Show();
            BackBtn.Click += login.CloseForm;
        }

        //Shows WelcomeScreen on the panel and calls the ShowCreate object when Welcome.ShowCreate is invoked
        public void ShowWelcome(object sender, EventArgs e)
        {
            WelcomeScreen Welcome = new WelcomeScreen();
            Welcome.TopLevel = false;
            Welcome.AutoScroll = true;
            Welcome.FormBorderStyle = FormBorderStyle.None;
            Welcome.Dock = DockStyle.Fill;
            HomePanel.Controls.Add(Welcome);
            Welcome.ShowCreate += new EventHandler(ShowCreate);
            Welcome.ShowLogin += new EventHandler(ShowLogin);
            this.Text = "Welcome to The Circuit Breaker Quiz";
            BackBtn.Image = Properties.Resources.BackButton64;
            BackBtn.Location = new Point(1485, 770);
            MuteToggle.Location = new Point(1370, 770);
            CheckAns.Location = new Point(1255, 770);
            BackBtn.Hide();
            MuteToggle.Hide();
            TutorialBtn.Hide();
            CheckAns.Hide();
            Welcome.Show();
        }
    
        //Shows Lobby on the panel
        public void ShowLobby(object sender, EventArgs e)
        {
            Lobby lobby = new Lobby();
            lobby.TopLevel = false;
            lobby.AutoScroll = true;
            lobby.FormBorderStyle = FormBorderStyle.None;
            lobby.Dock = DockStyle.Fill;
            HomePanel.Controls.Add(lobby);
            this.Text = "Lobby | The Circuit Breaker Quiz";
            Target.Target = "welcome";
            lobby.ShowDifficulty += new EventHandler(ShowDifficulty);
            lobby.StartQuiz += new EventHandler(NextSection);
            lobby.ShowLeaderboard += new EventHandler(ShowLeaderboard);
            lobby.ShowQuestionDesigner += new EventHandler(ShowQuestionDesigner);
            lobby.ShowSettings += new EventHandler(ShowSettings);
            Common_Variables.UsedQuestions.Clear();
            UsedSection.Clear();
            UsedSection.Add("MultiChoice");
            UsedSection.Add("Checkbox");
            UsedSection.Add("DragAndDrop");
            UsedSection.Add("FillInBlank");
            UsedSection.Add("TrueOrFalse");
            Common_Variables.CurrentPage = "Multi";
            CheckAns.Location = new Point(1485, 770);
            MuteToggle.Location = new Point(1370, 770);
            TutorialBtn.Location = new Point(1255, 770);
            BackBtn.Image = Properties.Resources.Logout64;
            BackBtn.Click += lobby.CloseForm;
            BackBtn.Show();
            MuteToggle.Show();
            TutorialBtn.Show();
            lobby.Show();
        }

        //Shows DifficultySelect on the panel and configures UI elements accourdingly
        public void ShowDifficulty(object sender, EventArgs e)
        {
            DifficultySelect difficulty = new DifficultySelect();
            difficulty.TopLevel = false;
            difficulty.AutoScroll = true;
            difficulty.FormBorderStyle = FormBorderStyle.None;
            difficulty.Dock = DockStyle.Fill;
            HomePanel.Controls.Add(difficulty);
            this.Text = "Select Difficulty | The Circuit Breaker Quiz";
            Target.Target = "lobby";
            TutorialBtn.Hide();
            BackBtn.Image = Properties.Resources.BackButton64;
            BackBtn.Click += difficulty.CloseForm;
            difficulty.Show();
        }

        //Shows DifficultySelect on the panel and configures UI elements accourdingly
        public void ShowLeaderboard(object sender, EventArgs e)
        {
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.TopLevel = false;
            leaderboard.AutoScroll = true;
            leaderboard.FormBorderStyle = FormBorderStyle.None;
            leaderboard.Dock = DockStyle.Fill;
            HomePanel.Controls.Add(leaderboard);
            this.Text = "Leaderboard | The Circuit Breaker Quiz";
            Target.Target = "lobby";
            TutorialBtn.Hide();
            BackBtn.Show();
            MuteToggle.Show();
            BackBtn.Image = Properties.Resources.BackButton64;
            BackBtn.Click += leaderboard.CloseForm;
            leaderboard.Show();
        }

        //Shows QuestionDesigner on the panel and configures UI elements accourdingly
        public void ShowQuestionDesigner(object sender, EventArgs e)
        {
            QuestionDesigner designer = new QuestionDesigner();
            designer.TopLevel = false;
            designer.AutoScroll = true;
            designer.FormBorderStyle = FormBorderStyle.None;
            designer.Dock = DockStyle.Fill;
            HomePanel.Controls.Add(designer);
            this.Text = "Question Designer | The Circuit Breaker Quiz";
            Target.Target = "lobby";
            Common_Variables.CurrentPage = "Designer";
            BackBtn.Image = Properties.Resources.BackButton64;
            BackBtn.Click += designer.CloseForm;
            designer.ShowTextView += new EventHandler(ShowTextView);
            designer.Show();
        }

        //Shows Settings on the panel and configures UI elements accourdingly
        public void ShowSettings(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.TopLevel = false;
            settings.AutoScroll = true;
            settings.FormBorderStyle = FormBorderStyle.None;
            settings.Dock = DockStyle.Fill;
            HomePanel.Controls.Add(settings);
            this.Text = "Settings | The Circuit Breaker Quiz";
            Common_Variables.CurrentPage = "CustomEnd";
            Target.Target = "lobby";
            BackBtn.Image = Properties.Resources.BackButton64;
            CheckAns.Location = new Point(1485, 770);
            BackBtn.Location = new Point(1370, 770);
            MuteToggle.Location = new Point(1255, 770);
            TutorialBtn.Location = new Point(1140, 770);
            CheckAns.Show();
            settings.Show();
            settings.ShowTextView += new EventHandler(ShowTextView);
            settings.ShowWelcome += new EventHandler(ShowWelcome);
            BackBtn.Click += settings.CloseForm;
            CheckAns.Click += settings.ApplySettings;
        }

        //Selects next section of the Quiz randomly, ensuring no sections are duplicated
        public void NextSection(object sender, EventArgs e) 
        {
            TutorialBtn.Hide();
            if (Common_Variables.q_number < 20)
            {
                int rand_int = random.Next(0, UsedSection.Count);
                switch (UsedSection[rand_int])
                {
                    case "MultiChoice":
                        UsedSection.RemoveAt(rand_int);
                        Common_Variables.CurrentSection = "Multiple Choice";
                        ShowMultiChoice();
                        break;
                    case "Checkbox":
                        UsedSection.RemoveAt(rand_int);
                        Common_Variables.CurrentSection = "Checkbox";
                        ShowCheckbox();
                        break;
                    case "DragAndDrop":
                        UsedSection.RemoveAt(rand_int);
                        Common_Variables.CurrentSection = "Drag and Drop";
                        ShowDragDrop();
                        break;
                    case "FillInBlank":
                        UsedSection.RemoveAt(rand_int);
                        Common_Variables.CurrentSection = "Fill in the Blank";
                        ShowFillInBlank();
                        break;
                    case "TrueOrFalse":
                        UsedSection.RemoveAt(rand_int);
                        Common_Variables.CurrentSection = "True or False";
                        ShowTrueOrFalse();
                        break;
                }
            }
            else if (Common_Variables.q_number > 16) //Ends quiz after 20 questions
            { 
                if (Common_Variables.SkipEnd) //Saves users statistics to LeaderboardData and UserData and returns to lobby if user has the skip end screen setting enabled
                {
                    using (Stream fileStream = File.Open(Common_Variables.UserData, FileMode.Open))
                    {
                        userlist = (List<UserData>)(deserialise.Deserialize(fileStream));
                    }

                    File.Delete(Common_Variables.UserData);

                    using (Stream fileStream = File.Open(Common_Variables.UserData, FileMode.Create))
                    {
                        foreach (UserData searchuser in userlist)
                        {
                            if (searchuser.User_id == Common_Variables.username)
                            {
                                searchuser.BlankLifeCorrect = Common_Variables.BlankLifeCorrect;
                                searchuser.BlankLifeIncorrect = Common_Variables.BlankLifeIncorrect;
                                searchuser.CheckLifeCorrect = Common_Variables.CheckLifeCorrect;
                                searchuser.CheckLifeIncorrect = Common_Variables.CheckLifeIncorrect;
                                searchuser.DropLifeCorrect = Common_Variables.DropLifeCorrect;
                                searchuser.DropLifeIncorrect = Common_Variables.DropLifeIncorrect;
                                searchuser.MultiLifeCorrect = Common_Variables.MultiLifeCorrect;
                                searchuser.MultiLifeIncorrect = Common_Variables.MultiLifeIncorrect;
                                searchuser.TorfLifeCorrect = Common_Variables.TorfLifeCorrect;
                                searchuser.TorfLifeIncorrect = Common_Variables.TorfLifeIncorrect;
                                searchuser.LifetimeCorrect = Common_Variables.LifetimeCorrect;
                                searchuser.LifetimeIncorrect = Common_Variables.LifetimeIncorrect;
                            }
                        }
                        serialise.Serialize(fileStream, userlist); // Serialise data using a list of user objects
                        userlist.Clear();
                    }

                    List<LeaderboardData> leaderlist = new List<LeaderboardData>();
                    if (!File.Exists(Common_Variables.LeaderboardData)) //Ceates new LeaderboardData file if one does not exist
                    {
                        using (Stream fileStream = File.Open(Common_Variables.LeaderboardData, FileMode.Create))
                        {
                            LeaderboardData newdata = new LeaderboardData(Common_Variables.username, Common_Variables.score, Common_Variables.LifetimeCorrect, Common_Variables.LifetimeIncorrect);
                            leaderlist.Add(newdata);
                            serialise.Serialize(fileStream, leaderlist);
                            leaderlist.Clear();
                        }
                    }
                    else if (File.Exists(Common_Variables.LeaderboardData)) //Saves to existing LeaderboardData file
                    {
                        using (Stream fileStream = File.Open(Common_Variables.LeaderboardData, FileMode.Open))
                        {
                            leaderlist = (List<LeaderboardData>)(deserialise.Deserialize(fileStream));
                        }

                        File.Delete(Common_Variables.LeaderboardData);

                        using (Stream fileStream = File.Open(Common_Variables.LeaderboardData, FileMode.Create))
                        {
                            LeaderboardData newdata = new LeaderboardData(Common_Variables.username, Common_Variables.score, Common_Variables.LifetimeCorrect, Common_Variables.LifetimeIncorrect);
                            leaderlist.Add(newdata);
                            serialise.Serialize(fileStream, leaderlist);
                            leaderlist.Clear();
                        }
                    }

                    Lobby lobby = new Lobby();
                    lobby.TopLevel = false;
                    lobby.AutoScroll = true;
                    lobby.FormBorderStyle = FormBorderStyle.None;
                    lobby.Dock = DockStyle.Fill;
                    HomePanel.Controls.Add(lobby);
                    this.Text = "Lobby | The Circuit Breaker Quiz";
                    Target.Target = "welcome";
                    lobby.ShowDifficulty += new EventHandler(ShowDifficulty);
                    lobby.StartQuiz += new EventHandler(NextSection);
                    lobby.ShowLeaderboard += new EventHandler(ShowLeaderboard);
                    lobby.ShowQuestionDesigner += new EventHandler(ShowQuestionDesigner);
                    lobby.ShowSettings += new EventHandler(ShowSettings);
                    Common_Variables.UsedQuestions.Clear();
                    UsedSection.Clear();
                    UsedSection.Add("MultiChoice");
                    UsedSection.Add("Checkbox");
                    UsedSection.Add("DragAndDrop");
                    UsedSection.Add("FillInBlank");
                    UsedSection.Add("TrueOrFalse");
                    Common_Variables.CurrentPage = "Multi";
                    BackBtn.Location = new Point(1485, 770);
                    MuteToggle.Location = new Point(1370, 770);
                    TutorialBtn.Location = new Point(1255, 770);
                    BackBtn.Image = Properties.Resources.Logout64;
                    BackBtn.Click += lobby.CloseForm;
                    BackBtn.Show();
                    MuteToggle.Show();
                    TutorialBtn.Show();
                    lobby.Show();
                    QuestionUI.Hide();
                    CheckAns.Hide();
                    Common_Variables.q_number = 1;
                    Common_Variables.score = 0;
                    return;
                }
                else if (!Common_Variables.SkipEnd)
                {
                    ShowEndScreen();
                }          
            }
        }

        //Shows MultiChoice on the panel and configures UI elements accourdingly
        public void ShowMultiChoice()
        {
            MultiChoice multi = new MultiChoice();
            multi.TopLevel = false;
            multi.AutoScroll = true;
            multi.FormBorderStyle = FormBorderStyle.None;
            multi.Dock = DockStyle.Fill;
            HomePanel.Controls.Clear();
            HomePanel.Controls.Add(multi);
            CheckAns.Location = new Point(1485, 770);
            BackBtn.Location = new Point(1370, 770);
            MuteToggle.Location = new Point(1255, 770);
            BackBtn.Image = Properties.Resources.BackButton64;
            Target.Target = "lobby";
            this.Text = "Multiple Choice | The Circuit Breaker Quiz";
            CheckAns.Show();
            QuestionUI.Text = "Question " + Common_Variables.q_number +" - Multiple Choice" + Environment.NewLine + "Score: " + Common_Variables.score + "/20";
            multi.UpdateQNum += new EventHandler(UpdateQNumber);
            multi.NextSection += new EventHandler(NextSection);
            QuestionUI.Show();
            BackBtn.Click += multi.CloseForm;
            CheckAns.Click += multi.AnsCheck;
            multi.Show();
        }

        //Shows Checkbox on the panel and configures UI elements accourdingly
        public void ShowCheckbox()
        {
            Checkbox check = new Checkbox();
            check.TopLevel = false;
            check.AutoScroll = false;
            check.FormBorderStyle = FormBorderStyle.None;
            check.Dock = DockStyle.Fill;
            HomePanel.Controls.Clear();
            HomePanel.Controls.Add(check);
            CheckAns.Location = new Point(1485, 770);
            BackBtn.Location = new Point(1370, 770);
            MuteToggle.Location = new Point(1255, 770);
            BackBtn.Image = Properties.Resources.BackButton64;
            Target.Target = "lobby";
            this.Text = "Checkbox | The Circuit Breaker Quiz";
            QuestionUI.Text = "Question " + Common_Variables.q_number + " - Checkbox" + Environment.NewLine + "Score: " + Common_Variables.score + "/20";
            CheckAns.Show();
            check.UpdateQNum += new EventHandler(UpdateQNumber);
            check.NextSection += new EventHandler(NextSection);
            QuestionUI.Show();
            BackBtn.Click += check.CloseForm;
            CheckAns.Click += check.AnsCheck;
            check.Show();
        }

        //Shows TrueOrFalse on the panel and configures UI elements accourdingly
        private void ShowTrueOrFalse()
        {
            TrueOrFalse torf = new TrueOrFalse();
            torf.TopLevel = false;
            torf.AutoScroll = true;
            torf.FormBorderStyle = FormBorderStyle.None;
            torf.Dock = DockStyle.Fill;
            HomePanel.Controls.Clear();
            HomePanel.Controls.Add(torf);
            CheckAns.Location = new Point(1485, 770);
            BackBtn.Location = new Point(1370, 770);
            MuteToggle.Location = new Point(1255, 770);
            BackBtn.Image = Properties.Resources.BackButton64;
            Target.Target = "lobby";
            this.Text = "True or False | The Circuit Breaker Quiz";
            QuestionUI.Text = "Question " + Common_Variables.q_number + " - True or False" + Environment.NewLine + "Score: " + Common_Variables.score + "/20";
            CheckAns.Show();
            torf.UpdateQNum += new EventHandler(UpdateQNumber);
            torf.NextSection += new EventHandler(NextSection);
            QuestionUI.Show();
            BackBtn.Click += torf.CloseForm;
            CheckAns.Click += torf.AnsCheck;
            torf.Show();
        }

        //Shows DragAndDrop on the panel and configures UI elements accourdingly
        private void ShowDragDrop()
        {
            DragAndDrop drop = new DragAndDrop();
            drop.TopLevel = false;
            drop.AutoScroll = false;
            drop.FormBorderStyle = FormBorderStyle.None;
            drop.Dock = DockStyle.Fill;
            HomePanel.Controls.Clear();
            HomePanel.Controls.Add(drop);
            CheckAns.Location = new Point(1485, 770);
            BackBtn.Location = new Point(1370, 770);
            MuteToggle.Location = new Point(1255, 770);
            BackBtn.Image = Properties.Resources.BackButton64;
            Target.Target = "lobby";
            this.Text = "Drag and Drop | The Circuit Breaker Quiz";
            CheckAns.Show();
            QuestionUI.Text = "Question " + Common_Variables.q_number + " - Drag and Drop" + Environment.NewLine + "Score: " + Common_Variables.score + "/20";
            drop.UpdateQNum += new EventHandler(UpdateQNumber);
            drop.NextSection += new EventHandler(NextSection);
            QuestionUI.Show();
            BackBtn.Click += drop.CloseForm;
            CheckAns.Click += drop.AnsCheck;
            drop.Show();
        }

        //Shows FillInTheBlank on the panel and configures UI elements accourdingly
        private void ShowFillInBlank()
        {
            FillInTheBlank blank = new FillInTheBlank();
            blank.TopLevel = false;
            blank.AutoScroll = false;
            blank.FormBorderStyle = FormBorderStyle.None;
            blank.Dock = DockStyle.Fill;
            HomePanel.Controls.Clear();
            HomePanel.Controls.Add(blank);
            CheckAns.Location = new Point(1485, 770);
            BackBtn.Location = new Point(1370, 770);
            MuteToggle.Location = new Point(1255, 770);
            BackBtn.Image = Properties.Resources.BackButton64;
            Target.Target = "lobby";
            this.Text = "Fill in the Blank | The Circuit Breaker Quiz";
            CheckAns.Show();
            QuestionUI.Text = "Question " + Common_Variables.q_number + " - Fill in the Blank" + Environment.NewLine + "Score: " + Common_Variables.score + "/20";
            blank.UpdateQNum += new EventHandler(UpdateQNumber);
            blank.NextSection += new EventHandler(NextSection);
            QuestionUI.Show();
            BackBtn.Click += blank.CloseForm;
            CheckAns.Click += blank.AnsCheck;
            blank.Show();
        }

        //Shows EndScreen on the panel and configures UI elements accourdingly
        private void ShowEndScreen()
        {
            EndScreen end = new EndScreen();
            end.TopLevel = false;
            end.AutoScroll = false;
            end.FormBorderStyle = FormBorderStyle.None;
            end.Dock = DockStyle.Fill;
            HomePanel.Controls.Clear();
            HomePanel.Controls.Add(end);
            BackBtn.Hide();
            MuteToggle.Hide();
            CheckAns.Hide();
            QuestionUI.Hide();
            BackBtn.Location = new Point(1485, 770);
            MuteToggle.Location = new Point(1370, 770);
            CheckAns.Location = new Point(1255, 770);
            this.Text = "Game Over | The Circuit Breaker Quiz";
            end.ShowLobby += new EventHandler(ShowLobby);
            end.ShowLeaderboard += new EventHandler(ShowLeaderboard);
            end.Show();
            if (Common_Variables.ExitEnd)
            {
                end.Hide();
            }
        }

        //Shows TextView on the panel and configures UI elements accourdingly
        public void ShowTextView(object sender, EventArgs e)
        {
            TextViewer view = new TextViewer();
            view.TopLevel = false;
            view.AutoScroll = false;
            view.FormBorderStyle = FormBorderStyle.None;
            view.Dock = DockStyle.Fill;
            HomePanel.Controls.Clear();
            HomePanel.Controls.Add(view);
            BackBtn.Location = new Point(1485, 770);
            MuteToggle.Location = new Point(1370, 770);
            CheckAns.Hide();
            TutorialBtn.Hide();
            if (Common_Variables.FileToBeViewed == "VeryBadEnd.txt" || Common_Variables.FileToBeViewed == "BadEnd.txt" || Common_Variables.FileToBeViewed == "NormalEnd.txt" || Common_Variables.FileToBeViewed == "GoodEnd.txt" || Common_Variables.FileToBeViewed == "VeryGoodEnd.txt")
            {
                Target.Target = "settings";
            }
            else if (Common_Variables.FileToBeViewed == "checkbox.txt" || Common_Variables.FileToBeViewed == "multichoice.txt" || Common_Variables.FileToBeViewed == "trueorfalse.txt" || Common_Variables.FileToBeViewed == "fillinblank.txt")
            {
                Target.Target = "designer";
            }
            
            BackBtn.Click += view.CloseForm;
            view.Show();
            this.Text = "Text Viewer | The Circuit Breaker Quiz";
        }

        //Shows Tutorial on the panel and configures UI elements accourdingly
        public void ShowTutorial()
        {
            Tutorial tutorial = new Tutorial();
            tutorial.TopLevel = false;
            tutorial.AutoScroll = false;
            tutorial.FormBorderStyle = FormBorderStyle.None;
            tutorial.Dock = DockStyle.Fill;
            HomePanel.Controls.Clear();
            HomePanel.Controls.Add(tutorial);
            BackBtn.Location = new Point(1485, 770);
            MuteToggle.Location = new Point(1370, 770);
            CheckAns.Hide();
            TutorialBtn.Hide();
            Target.Target = "lobby";
            BackBtn.Image = Resources.BackButton64;
            BackBtn.Click += tutorial.CloseForm;
            tutorial.Show();
            this.Text = "Tutorial | The Circuit Breaker Quiz";
        }

        //Updates QuestionUI.Text with up to date information when called
        private void UpdateQNumber(object sender, EventArgs e)
        {
            QuestionUI.Text = "Question " + Common_Variables.q_number + " - " + Common_Variables.CurrentSection + Environment.NewLine + "Score: " + Common_Variables.score + "/20";
        }

        private void TutorialBtn_Click(object sender, EventArgs e)
        {
            ShowTutorial();
        }
    }

    partial class ReturnTo 
    {
        private string target;

        public string Target
        {
            get { return target; }
            set { target = value; }
        }
    }

    class Questions
    {
        private string[] split;
        public string guess { get; set; }
        public string[] Split
        {
            get { return split; }
            set { split = value; }
        }
    }
}