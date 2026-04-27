using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class Leaderboard : Form
    {
        //Initialise obkects and variables
        IFormatter deserialise = new BinaryFormatter();
        List<LeaderboardData> Leaderlist = new List<LeaderboardData>();

        string SortBy = "Score";
        string OrderBy = "Descending";

        public Leaderboard()
        {
            InitializeComponent();
        }

        public void CloseForm(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Close();
            }
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            //Hides error label and configures DataGrid & SortScoreBtns visual properties
            Error.Hide();
            DataGrid.RowTemplate.Height = 35;

            SortScoreBtn.FlatAppearance.BorderSize = 5;

            if (File.Exists(Common_Variables.LeaderboardData))
            {
                LoadData();
            }
            else //Shows error label and hides sorting UI if no LeaderboardData file is present
            {
                Error.Show();
                SortLCBtn.Hide();
                SortLICBtn.Hide();
                SortNameBtn.Hide();
                SortOrderBtn.Hide();
                SortScoreBtn.Hide();
            }
        }

        private void LoadData()
        {
            using (Stream fileStream = File.OpenRead(Common_Variables.LeaderboardData))
            {
                Leaderlist = (List<LeaderboardData>)(deserialise.Deserialize(fileStream));
            }

            if (OrderBy == "Descending") //Orders values in a descending order
            {
                switch (SortBy)
                {
                    case "Name":
                        Leaderlist = Leaderlist.OrderBy(o => o.Username).ToList(); //OrderByDescending sorts from Z => A, which is not intuitive as most people would expect it to go from A => Z, so OrderBy is used instead
                        break;
                    case "Score":
                        Leaderlist = Leaderlist.OrderByDescending(o => o.Score).ToList();
                        break;
                    case "LC":
                        Leaderlist = Leaderlist.OrderByDescending(o => o.LifetimeCorrect).ToList();
                        break;
                    case "LIC":
                        Leaderlist = Leaderlist.OrderByDescending(o => o.LifetimeIncorrect).ToList(); 
                        break;
                }
            }
            else if (OrderBy == "Ascending") //Orders values in ascending order
            {
                switch (SortBy)
                {
                    case "Name":
                        Leaderlist = Leaderlist.OrderByDescending(o => o.Username).ToList(); //OrderBy sorts from A => Z, which is not intuitive for an ascending sort as most people would expect it to go from Z => A, so OrderByDescending is used instead
                        break;
                    case "Score":
                        Leaderlist = Leaderlist.OrderBy(o => o.Score).ToList();
                        break;
                    case "LC":
                        Leaderlist = Leaderlist.OrderBy(o => o.LifetimeCorrect).ToList();
                        break;
                    case "LIC":
                        Leaderlist = Leaderlist.OrderBy(o => o.LifetimeIncorrect).ToList();
                        break;
                }
            }
            DataGrid.DataSource = Leaderlist; //Shows values on DataGrid

            DataGrid.Columns[0].HeaderText = "Player:";
            DataGrid.Columns[1].HeaderText = "Score:";
            DataGrid.Columns[2].HeaderText = "Lifetime Correct:";
            DataGrid.Columns[3].HeaderText = "Lifetime Incorrect:";

        }

        //Tells the leaderboard to sort by Name and highlights the SortNameBtn
        private void SortNameBtn_Click(object sender, EventArgs e)
        {
            SortBy = "Name";
            SortNameBtn.FlatAppearance.BorderSize = 5;
            SortScoreBtn.FlatAppearance.BorderSize = 0;
            SortLCBtn.FlatAppearance.BorderSize = 0;
            SortLICBtn.FlatAppearance.BorderSize = 0;

            LoadData();
        }

        //Tells the leaderboard what order to sorder by and changes the text on OrderBy accourdingly
        private void SortOrderBtn_Click(object sender, EventArgs e)
        {
            if (OrderBy == "Ascending")
            {
                OrderBy = "Descending";
                SortOrderBtn.Text = "Descending";
                LoadData();
            }
            else if (OrderBy == "Descending")
            {
                OrderBy = "Ascending";
                SortOrderBtn.Text = "Ascending";
                LoadData();
            }
        }

        //Tells the leaderboard to sort by Score and highlights the SortScoreBtn
        private void SortScoreBtn_Click(object sender, EventArgs e)
        {
            SortBy = "Score";
            SortNameBtn.FlatAppearance.BorderSize = 0;
            SortScoreBtn.FlatAppearance.BorderSize = 5;
            SortLCBtn.FlatAppearance.BorderSize = 0;
            SortLICBtn.FlatAppearance.BorderSize = 0;

            LoadData();
        }

        //Tells the leaderboard to sort by LifetimeCorrect and highlights the SortLCBtn
        private void SortLCBtn_Click(object sender, EventArgs e)
        {
            SortBy = "LC";
            SortNameBtn.FlatAppearance.BorderSize = 0;
            SortScoreBtn.FlatAppearance.BorderSize = 0;
            SortLCBtn.FlatAppearance.BorderSize = 5;
            SortLICBtn.FlatAppearance.BorderSize = 0;
            
            LoadData();
        }

        //Tells the leaderboard to sort by LifetimeIncorrect and highlights the SortLICBtn
        private void SortLICBtn_Click(object sender, EventArgs e)
        {
            SortBy = "LIC";
            SortNameBtn.FlatAppearance.BorderSize = 0;
            SortScoreBtn.FlatAppearance.BorderSize = 0;
            SortLCBtn.FlatAppearance.BorderSize = 0;
            SortLICBtn.FlatAppearance.BorderSize = 5;

            LoadData();
        }
    }
}
