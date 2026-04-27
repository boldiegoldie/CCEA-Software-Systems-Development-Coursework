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

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class Login : Form
    {
        //Initalises events, objects & variables
        public event EventHandler LoadLobby;
        List<UserData> userlist = new List<UserData>();
        IFormatter deserialise = new BinaryFormatter();
        SoundPlayer player = new SoundPlayer();

        bool PassShown = false;
        public Login()
        {
            InitializeComponent();
        }

        //Hides error label and sets visual properties for LoginBtn
        private void Login_Load(object sender, EventArgs e)
        {
            Wrong.Hide();
            LoginBtn.FlatStyle = FlatStyle.Flat;
            LoginBtn.FlatAppearance.BorderSize = 0;
        }

        //Attemps to log into an account when clicked
        private void LoginBtn_click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (!File.Exists(Common_Variables.UserData)) //Tells user to make account if UserData does not exist
            {
                MessageBox.Show("No user data file found, please make an account.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (Stream fileStream = File.OpenRead(Common_Variables.UserData))
                {
                    userlist = (List<UserData>)deserialise.Deserialize(fileStream);
                }

                foreach (UserData searchuser in userlist)
                {
                    if (searchuser.User_id == UsrnameInput.Text && searchuser.Passcode == PasswordInput.Text) //Checks to see if username and password inputted match any accounts stored in UserData, logs into account and shows lobby if successful
                    {
                        Common_Variables.username = UsrnameInput.Text;
                        Common_Variables.LifetimeCorrect = searchuser.LifetimeCorrect;
                        Common_Variables.LifetimeIncorrect = searchuser.LifetimeIncorrect;
                        Common_Variables.BlankLifeCorrect = searchuser.BlankLifeCorrect;
                        Common_Variables.BlankLifeIncorrect = searchuser.BlankLifeIncorrect;
                        Common_Variables.CheckLifeCorrect = searchuser.CheckLifeCorrect;
                        Common_Variables.CheckLifeIncorrect = searchuser.CheckLifeIncorrect;
                        Common_Variables.DropLifeCorrect = searchuser.DropLifeCorrect;
                        Common_Variables.DropLifeIncorrect = searchuser.DropLifeIncorrect;
                        Common_Variables.MultiLifeCorrect = searchuser.MultiLifeCorrect;
                        Common_Variables.MultiLifeIncorrect = searchuser.MultiLifeIncorrect;
                        Common_Variables.TorfLifeCorrect = searchuser.TorfLifeCorrect;
                        Common_Variables.TorfLifeIncorrect = searchuser.TorfLifeIncorrect;
                        Common_Variables.isAdmin = searchuser.IsAdmin;
                        Common_Variables.ReadQuestions = searchuser.ReadQuestions;
                        Common_Variables.dyslexia = searchuser.Dyslexia;
                        Common_Variables.SkipEnd = searchuser.SkipEnd;

                        if (LoadLobby != null)
                        {
                            LoadLobby.Invoke(this, EventArgs.Empty);
                        }
                        this.Close();
                    }
                    else //Shows error label if account sign in fails
                    {
                        Wrong.Show();
                        UsrnameHeader.ForeColor = System.Drawing.Color.Red;
                        PasswordHeader.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            //Blanks text boxes so user wont try to sign in with incorrect details
            UsrnameInput.Text = "";
            PasswordInput.Text = "";
        }

        //These 2 functions hide the error label when a textbox is clicked
        private void UsrnameInput_enter(object sender, EventArgs e)
        {
            UsrnameHeader.ForeColor = System.Drawing.Color.White;
            Wrong.Hide();
        }

        private void PasswordInput_enter(object sender, EventArgs e)
        {
            PasswordHeader.ForeColor = System.Drawing.Color.White;
            Wrong.Hide();
        }

        //Hides/unhides the password when clicked and changes image on PassShow accourdingly
        private void PassShow_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (PassShown == false)
            {
                PasswordInput.PasswordChar = '\0';
                PassShown = true;
                PassShow.Image = Properties.Resources.PassShow;
            }
            else if (PassShown == true)
            {
                PasswordInput.PasswordChar = '*';
                PassShown = false;
                PassShow.Image = Properties.Resources.PassHide64;
            }
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
