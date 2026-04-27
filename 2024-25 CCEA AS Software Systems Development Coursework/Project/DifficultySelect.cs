using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class DifficultySelect : Form
    {
        public DifficultySelect()
        {
            InitializeComponent();
        }
        //Initialise objects and variables
        string difficulty = Common_Variables.difficulty;
        SoundPlayer player = new SoundPlayer();

        private void Dfficulty_Load(object sender, EventArgs e)
        {
            //Sets default visual properties for all buttons
            NormalBtn.FlatStyle = FlatStyle.Flat;
            NormalBtn.FlatAppearance.BorderSize = 0;
            EasyBtn.FlatStyle = FlatStyle.Flat;
            EasyBtn.FlatAppearance.BorderSize = 0;
            hard_btn.FlatStyle = FlatStyle.Flat;
            hard_btn.FlatAppearance.BorderSize = 0;
            
            //Sets border size and colour for the button that represents current difficulty
            switch (difficulty)
            {
                case "e":
                    EasyBtn.FlatAppearance.BorderSize = 5;
                    EasyBtn.FlatAppearance.BorderColor = Color.LimeGreen;
                    break;
                case "n":
                    NormalBtn.FlatAppearance.BorderSize = 5;
                    NormalBtn.FlatAppearance.BorderColor = Color.Orange;
                    break;
                case "h":
                    hard_btn.FlatAppearance.BorderSize = 5;
                    hard_btn.FlatAppearance.BorderColor = Color.Red;
                    break;
            }
            
        }

        //Sets difficulty to n and sets border size for NormaLBtn to 5, while setting others to 0
        private void NormalBtn_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            NormalBtn.FlatAppearance.BorderSize = 5;
            NormalBtn.FlatAppearance.BorderColor = Color.Orange;
            EasyBtn.FlatAppearance.BorderSize = 0;
            hard_btn.FlatAppearance.BorderSize = 0;
            Common_Variables.difficulty = "n";
            difficulty = Common_Variables.difficulty;

        }

        //Sets difficulty to e and sets border size for EasyBtn to 5, while setting others to 0
        private void EasyBtn_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            EasyBtn.FlatAppearance.BorderSize = 5;
            EasyBtn.FlatAppearance.BorderColor = Color.LimeGreen; 
            NormalBtn.FlatAppearance.BorderSize = 0;
            hard_btn.FlatAppearance.BorderSize = 0;
            Common_Variables.difficulty = "e";
            difficulty = Common_Variables.difficulty;
        }

        //Sets difficulty to h and sets border size for NormaLBtn to 0, while setting others to 5
        private void HardBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            hard_btn.FlatAppearance.BorderSize = 5;
            hard_btn.FlatAppearance.BorderColor = Color.Red;
            NormalBtn.FlatAppearance.BorderSize = 0;
            EasyBtn.FlatAppearance.BorderSize = 0;
            Common_Variables.difficulty = "h";
            difficulty = Common_Variables.difficulty;
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
