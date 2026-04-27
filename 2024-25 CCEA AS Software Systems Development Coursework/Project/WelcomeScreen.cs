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
    public partial class WelcomeScreen : Form
    {
        public event EventHandler ShowCreate;
        public event EventHandler ShowLogin;
        SoundPlayer player = new SoundPlayer();

        public WelcomeScreen()
        {
            InitializeComponent();
        }  

        //Invokes ShowCreate when the create account button is clicked
        private void CreateAccount_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (ShowCreate != null)
            {
               ShowCreate.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        //Invokes ShowLogin when the create account button is clicked
        private void LoginBtn_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (ShowLogin != null)
            {
                ShowLogin.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        //Configures buttons visual properties
        private void WelcomeScreen_Load(object sender, EventArgs e)
        {
            CreateAccountBtn.FlatStyle = FlatStyle.Flat;
            LoginBtn.FlatStyle = FlatStyle.Flat;
            LoginBtn.FlatAppearance.BorderSize = 0;
            CreateAccountBtn.FlatAppearance.BorderSize = 0;
        }
    }
}
