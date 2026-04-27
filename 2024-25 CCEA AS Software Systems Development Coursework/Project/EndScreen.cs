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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class EndScreen : Form
    {
        //Initalises objects, events & variables
        Random random = new Random();
        IFormatter serialise = new BinaryFormatter();
        IFormatter deserialise = new BinaryFormatter();

        List<LeaderboardData> leaderlist = new List<LeaderboardData>();
        List<UserData> userlist = new List<UserData>();

        public event EventHandler ShowLeaderboard;
        public event EventHandler ShowLobby;

        SoundPlayer player = new SoundPlayer();

        public EndScreen()
        {
            InitializeComponent();
        }

        public void EndScreen_Load(object sender,EventArgs e)
        {
            Common_Variables.ExitEnd = false;
            if (!File.Exists(Common_Variables.LeaderboardData)) // Creates new LeaderboardData file if one does not exist and saves users statistics to it
            {
                using (Stream fileStream = File.Open(Common_Variables.LeaderboardData, FileMode.Create))
                {
                    LeaderboardData newdata = new LeaderboardData(Common_Variables.username, Common_Variables.score, Common_Variables.LifetimeCorrect, Common_Variables.LifetimeIncorrect);
                    leaderlist.Add(newdata);
                    serialise.Serialize(fileStream, leaderlist);
                    leaderlist.Clear();
                }
            }
            else if (File.Exists(Common_Variables.LeaderboardData)) //Adds users statistics to existing LeaderboardData file
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

            if (File.Exists(Common_Variables.UserData)) //Updates users account statistics (LifetimeCorrect,LifetimeIncorrect etc.)
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
            }
            else
            {
                MessageBox.Show("UserData file has been deleted during gameplay, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(Environment.ExitCode);
            }
            string[] LabelArray;
            string[] ChosenLabel;

            int tempScore = (int)(Common_Variables.score * 4);

            progressBar1.Value = tempScore; //Represents score on progressBar

            //Sets EndMessage to random line from EndMessage text files, according to users final score. Sets value of EndScoreTxt to current score and changes its colour according to users final score
            try
            {
                if (Common_Variables.score <= 3)
                {
                    LabelArray = File.ReadAllLines(Common_Variables.path + @"\assets\txt\EndScreen\VeryBadEnd.txt");
                    int rand = random.Next(0, LabelArray.Count());
                    ChosenLabel = LabelArray[rand].Split('/');
                    EndMessage.Font = new Font("Lucida Sans", (float)Convert.ToDecimal(ChosenLabel[0]), FontStyle.Bold);
                    EndMessage.Text = ChosenLabel[1];
                    EndScoreTxt.ForeColor = Color.Red;
                    if (Common_Variables.score == 0)
                    {
                        EndScoreTxt.ForeColor = Color.DarkRed;
                    }
                    EndScoreTxt.Text = Common_Variables.score.ToString();
                }
                else if (Common_Variables.score > 3 && Common_Variables.score <= 8)
                {
                    LabelArray = File.ReadAllLines(Common_Variables.path + @"\assets\txt\EndScreen\BadEnd.txt");
                    int rand = random.Next(0, LabelArray.Count());
                    ChosenLabel = LabelArray[rand].Split('/');
                    EndMessage.Font = new Font("Lucida Sans", (float)Convert.ToDecimal(ChosenLabel[0]), FontStyle.Bold);
                    EndMessage.Text = ChosenLabel[1];
                    EndScoreTxt.ForeColor = Color.OrangeRed;
                    EndScoreTxt.Text = Common_Variables.score.ToString();
                }
                else if (Common_Variables.score > 8 && Common_Variables.score <= 12)
                {
                    LabelArray = File.ReadAllLines(Common_Variables.path + @"\assets\txt\EndScreen\NormalEnd.txt");
                    int rand = random.Next(0, LabelArray.Count());
                    ChosenLabel = LabelArray[rand].Split('/');
                    EndMessage.Font = new Font("Lucida Sans", (float)Convert.ToDecimal(ChosenLabel[0]), FontStyle.Bold);
                    EndMessage.Text = ChosenLabel[1];
                    Bronze.Image = Resources.CopperTrophy;
                    EndScoreTxt.ForeColor = Color.Orange;
                    EndScoreTxt.Text = Common_Variables.score.ToString();
                }
                else if (Common_Variables.score > 12 && Common_Variables.score <= 16)
                {
                    LabelArray = File.ReadAllLines(Common_Variables.path + @"\assets\txt\EndScreen\GoodEnd.txt");
                    int rand = random.Next(0, LabelArray.Count());
                    ChosenLabel = LabelArray[rand].Split('/');
                    EndMessage.Font = new Font("Lucida Sans", (float)Convert.ToDecimal(ChosenLabel[0]), FontStyle.Bold);
                    EndMessage.Text = ChosenLabel[1];
                    Bronze.Image = Resources.CopperTrophy;
                    Silver.Image = Resources.SilverTrophy;
                    EndScoreTxt.ForeColor = Color.Lime;
                    EndScoreTxt.Text = Common_Variables.score.ToString();
                }
                else if (Common_Variables.score > 16)
                {
                    LabelArray = File.ReadAllLines(Common_Variables.path + @"\assets\txt\EndScreen\VeryGoodEnd.txt");
                    int rand = random.Next(0, LabelArray.Count());
                    ChosenLabel = LabelArray[rand].Split('/');
                    EndMessage.Font = new Font("Lucida Sans", (float)Convert.ToDecimal(ChosenLabel[0]), FontStyle.Bold);
                    EndMessage.Text = ChosenLabel[1];
                    Bronze.Image = Resources.CopperTrophy;
                    Silver.Image = Resources.SilverTrophy;
                    Gold.Image = Resources.GoldTrophy;
                    EndScoreTxt.ForeColor = Color.LimeGreen;
                    EndScoreTxt.Text = Common_Variables.score.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Messgage text file is corrupted or does not exist, returning to lobby...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Common_Variables.score = 0;
                Common_Variables.q_number = 1;

                if (ShowLobby != null)
                {
                    ShowLobby.Invoke(this, EventArgs.Empty);
                }
                Common_Variables.ExitEnd = true;
            }
        }

        //Triggers event that shows Leaderboard.cs on panel when clicked, resets score variables
        private void GoToLeaderboard_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            Common_Variables.score = 0;
            Common_Variables.q_number = 1;

            if (ShowLeaderboard != null)
            {
                ShowLeaderboard.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        //Triggers event that shows Lobby.cs on panel when clicked, resets score variables
        private void ReturnLobby_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            Common_Variables.score = 0;
            Common_Variables.q_number = 1;

            if (ShowLobby != null)
            {
                ShowLobby.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }
    }
}
