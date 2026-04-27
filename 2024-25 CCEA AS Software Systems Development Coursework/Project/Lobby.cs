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

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class Lobby : Form
    {
        //Initalises events & objects
        public event EventHandler ShowDifficulty;
        public event EventHandler StartQuiz;
        public event EventHandler ShowSettings;
        public event EventHandler ShowQuestionDesigner;
        public event EventHandler ShowLeaderboard;

        SoundPlayer player = new SoundPlayer();

        public Lobby()
        {
            InitializeComponent();
        }

        //Loads DifficultySelect when clicked
        public void DifficultyBtn_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (ShowDifficulty != null)
            {
                ShowDifficulty.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        //Calls NextSection in HomeScreen when clicked
        public void PlayBtn_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (StartQuiz != null)
            {
                StartQuiz.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        //Shows Leaderboard when clicked
        public void LeaderboardBtn_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (ShowLeaderboard != null)
            {
                ShowLeaderboard.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        //Shows the QuestionDesigner when clicked
        private void DesignerBtn_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (ShowQuestionDesigner != null)
            {
                ShowQuestionDesigner.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        //Shows Settings when clicked
        private void SettingsBtn_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (ShowSettings != null)
            {
                ShowSettings.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        //Loads users statistics when clicked andsets visaul properties for buttons
        private void Lobby_Load(object sender, EventArgs e)
        {
            LobbyHeader.Text = $"Hello, {Common_Variables.username}";
            PlayGameBtn.FlatStyle = FlatStyle.Flat;
            PlayGameBtn.FlatAppearance.BorderSize = 0; 
            DifficultySelectBtn.FlatStyle = FlatStyle.Flat;
            DifficultySelectBtn.FlatAppearance.BorderSize = 0;
            LeaderboardBtn.FlatStyle = FlatStyle.Flat;
            LeaderboardBtn.FlatAppearance.BorderSize= 0;
            SettingsBtn.FlatStyle = FlatStyle.Flat;
            SettingsBtn.FlatAppearance.BorderSize = 0;
            DesignerBtn.FlatStyle = FlatStyle.Flat;
            DesignerBtn.FlatAppearance.BorderSize = 0;

            Stats.Text = ("Your lifetime correct answers: " + Common_Variables.LifetimeCorrect + Environment.NewLine + "Your lifetime incorrect answers: " + Common_Variables.LifetimeIncorrect + Environment.NewLine+ Environment.NewLine + "========================" + Environment.NewLine + "Lifetime Correct/Lifetime Incorrect"+ Environment.NewLine + "========================" + Environment.NewLine + "Checkbox:" + Environment.NewLine + "Drag and Drop:" + Environment.NewLine + "Fill in the Blank:" + Environment.NewLine + "Multiple Choice:" + Environment.NewLine + "True or False:");
            ExtendedStats.Text = (Common_Variables.CheckLifeCorrect + "/" + Common_Variables.CheckLifeIncorrect + Environment.NewLine + Common_Variables.DropLifeCorrect + "/" + Common_Variables.DropLifeIncorrect + Environment.NewLine + Common_Variables.BlankLifeCorrect + "/" + Common_Variables.BlankLifeIncorrect + Environment.NewLine + Common_Variables.MultiLifeCorrect + "/" + Common_Variables.MultiLifeIncorrect + Environment.NewLine + Common_Variables.TorfLifeCorrect + "/" + Common_Variables.TorfLifeIncorrect);
        }

        public void CloseForm(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Close();
            }
        }
    }
}
