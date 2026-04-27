using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;
using System.IO;
using System.IO.Pipes;
using static _2024_25_CCEA_AS_Software_Systems_Development_Coursework.UserData;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class CreateAccount : Form
    {
        //Setup events, declare variables, initialise objects
        public event EventHandler LoadLobby;

        List<UserData> userlist = new List<UserData>();
        IFormatter serialise = new BinaryFormatter();
        IFormatter deserialise = new BinaryFormatter();
        SoundPlayer player = new SoundPlayer();

        bool PassShown = false;

        public CreateAccount()
        { //Hide error messages & change button style when screen is loaded
            InitializeComponent();
            NoPassword.Hide();
            NoSymbol.Hide();
            NotMixed.Hide();
            NoNumber.Hide();
            TooShort.Hide();
            NoUsrname.Hide();
            UsrSymbol.Hide();
            NoMatch.Hide();
            UsrTaken.Hide();
            UsrTooShort.Hide();
            CreateBtn.FlatStyle = FlatStyle.Flat;
            CreateBtn.FlatAppearance.BorderSize = 0;
        }

        //Code runs when create account button is clicked
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
            Validation();
        }

        private void Validation()
        {
            bool usrname_valid = false;
            bool password_valid = false;
            bool password_confirm = false;

            try
            {
                UsrnameInput.Text = ReplaceWhitespace(UsrnameInput.Text);

                if (UsrnameInput.Text == "")
                {
                    throw new NoUsernameEx("VALIDATION ERROR #06: No username has been entered.");
                }
                else if (!UsrnameInput.Text.All(char.IsLetterOrDigit))
                {
                    throw new UsrSymbolEx("VALIDATION ERROR #07: Username cannot contain a symbol.");
                }
                else if (UsrnameInput.Text.Length <= 3)
                {
                    throw new UsrTooShortEx("VALIDATION ERROR #08: Username must be longer than 4 characters");
                }
                else
                {
                    usrname_valid = true;
                }
            }
            catch (NoUsernameEx ex) //Custom exceptions for errors during username validation, each writes to the ErrorLog and shows error label
            {
                NoUsrname.Show();
                UsrnameHeader.ForeColor= System.Drawing.Color.Red;
                ErrorLog(ex.Message);
                UsrnameInput.Text = string.Empty;
            }
            catch (UsrSymbolEx ex)
            {
                UsrSymbol.Show();
                UsrnameHeader.ForeColor = System.Drawing.Color.Red;
                ErrorLog(ex.Message);
                UsrnameInput.Text = string.Empty;
            }
            catch (UsrTooShortEx ex)
            {
                UsrTooShort.Show();
                UsrnameHeader.ForeColor = System.Drawing.Color.Red;
                ErrorLog(ex.Message);
                UsrnameInput.Text = string.Empty;
            }

            try
            {
                //Check if password follows rules (using regex, very fancy)
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpper = new Regex(@"[A-Z]+");
                var hasLower = new Regex(@"[a-z]+");
                var hasSpecial = new Regex(@"[^A-Za-z0-9]");
                var hasMinimum4Chars = new Regex(@".{4,}");

                PasswordInput.Text = ReplaceWhitespace(PasswordInput.Text);

                if (PasswordInput.Text != "")
                {
                    if (hasMinimum4Chars.IsMatch(PasswordInput.Text) == false)
                    {
                        throw new TooShortEx("VALIDATION ERROR #04: Your password must be longer than 3 characters.");
                    }
                    else if ((hasNumber.IsMatch(PasswordInput.Text) == false))
                    {
                        throw new NoNumberEx("VALIDATION ERROR #01: Your password must contain at least one number.");
                    }
                    else if (hasUpper.IsMatch(PasswordInput.Text) == false || hasLower.IsMatch(PasswordInput.Text) == false)
                    {
                        throw new NotMixedEx("VALIDATION ERROR #02: Your password must be in mixed case.");
                    }
                    else if (hasSpecial.IsMatch(PasswordInput.Text) == false)
                    {
                        throw new NoSpecialEx("VALIDATION ERROR #03: Your password must contain at least one special character.");
                    }
                    else 
                    {
                        password_valid = true;
                    }
                }
                else
                {
                    throw new NoPasswordEx("VALIDATION ERROR #05: No password has been entered.");
                }
            }
            catch (NoPasswordEx ex) //Custom exceptions for errors with password validation, each writes to ErrorLog and shows error label
            {
                NoPassword.Show();
                PasswordHeader.ForeColor = System.Drawing.Color.Red;
                ErrorLog(ex.Message);
                PasswordInput.Text = string.Empty;
                return;
            }
            catch (NoNumberEx ex)
            {
                NoNumber.Show();
                PasswordHeader.ForeColor = System.Drawing.Color.Red;
                ErrorLog(ex.Message);
                PasswordInput.Text = string.Empty;
                return;
            }
            catch (NoSpecialEx ex)
            {
                NoSymbol.Show();
                PasswordHeader.ForeColor = System.Drawing.Color.Red;
                ErrorLog(ex.Message);
                PasswordInput.Text = string.Empty;
                return;
            }
            catch (NotMixedEx ex)
            {
                NotMixed.Show();
                PasswordHeader.ForeColor = System.Drawing.Color.Red;
                ErrorLog(ex.Message);
                PasswordInput.Text = string.Empty;
                return;
            }
            catch (TooShortEx ex)
            {
                TooShort.Show();
                PasswordHeader.ForeColor = System.Drawing.Color.Red;
                ErrorLog(ex.Message);
                PasswordInput.Text = string.Empty;
                return;
            }

            //Checks if the user has inputted the same password in both the password & confirm password boxes match
            try
            {
                ConfirmPassword.Text = ReplaceWhitespace(ConfirmPassword.Text);
                if (PasswordInput.Text == ConfirmPassword.Text)
                {
                    password_confirm = true;
                }
                else
                {
                    throw new NoConfirmEx("VALIDATION ERROR #09: Password not confirmed.");
                }
            }
            catch (NoConfirmEx ex) 
            {
                NoMatch.Show();
                ConfirmHeader.ForeColor = System.Drawing.Color.Red;
                ConfirmPassword.Text = "";
                ErrorLog(ex.Message);

            }
            //Loads Lobby.cs when all checks on the users inputs are valid & then hides the CreateAccount screen after account is created
            if (password_valid == true && usrname_valid == true && password_confirm == true)
            {
                Common_Variables.username = UsrnameInput.Text;
                Common_Variables.BlankLifeCorrect = 0;
                Common_Variables.BlankLifeIncorrect = 0;
                Common_Variables.CheckLifeCorrect = 0;
                Common_Variables.CheckLifeIncorrect = 0;
                Common_Variables.DropLifeCorrect = 0;
                Common_Variables.DropLifeIncorrect = 0;
                Common_Variables.MultiLifeCorrect = 0;
                Common_Variables.MultiLifeIncorrect = 0;
                Common_Variables.TorfLifeCorrect = 0;
                Common_Variables.TorfLifeIncorrect = 0;
                Common_Variables.LifetimeCorrect = 0;
                Common_Variables.LifetimeIncorrect = 0;
                Common_Variables.isAdmin = false;
                Common_Variables.ReadQuestions = false;
                Common_Variables.dyslexia = false;
                Common_Variables.SkipEnd = false;
                if (!File.Exists(Common_Variables.UserData))
                {
                    using (Stream fileStream = File.Open(Common_Variables.UserData, FileMode.Create)) //Check if UserDate file exists, make a new one if not
                    {
                        UserData newuser = new UserData(UsrnameInput.Text, PasswordInput.Text);
                        userlist.Add(newuser);
                        serialise.Serialize(fileStream, userlist); // Serialise data using a list of user objects
                        userlist.Clear();
                        if (LoadLobby != null)
                        {
                            LoadLobby.Invoke(this, EventArgs.Empty);
                        }
                        this.Close();
                    }
                }
                else // User file exists so check username not taken
                {
                    //Get the list of users by deserializing to a list of user objects
                    using (Stream fileStream = File.Open(Common_Variables.UserData, FileMode.Open))
                    {
                        userlist = (List<UserData>)(deserialise.Deserialize(fileStream));
                    }

                    //Check the list to see if username already in use, show error and write to ErrorLog if username is used
                    try
                    {
                        foreach (UserData searchuser in userlist)
                        {
                            if (searchuser.User_id == UsrnameInput.Text)
                            {
                                throw new UsrnameTakenEx("VALIDATION ERROR #10: Username already taken.");
                            }
                        }
                    }
                    catch (UsrnameTakenEx ex)
                    {
                        UsrTaken.Show();
                        UsrnameHeader.ForeColor = System.Drawing.Color.Red;
                        ErrorLog(ex.Message);
                        UsrnameInput.Text = string.Empty;
                        return;
                    }
                    
                    //Username not found so delete old file and write a new file or existing users plus new user

                    File.Delete(Common_Variables.UserData);

                    using (Stream fileStream = File.Open(Common_Variables.UserData, FileMode.Create))
                    {
                        UserData newuser = new UserData(UsrnameInput.Text, PasswordInput.Text);
                        userlist.Add(newuser);
                        serialise.Serialize(fileStream, userlist); // Serialise data using a list of user objects
                        userlist.Clear();
                        if (LoadLobby != null)
                        {
                            LoadLobby.Invoke(this, EventArgs.Empty);
                        }
                        this.Close();
                    }
                }
            }
        }

        //Remove highlight & error messages on input boxes
        private void PasswordInput_Click(object sender, EventArgs e)
        {
            PasswordHeader.ForeColor = System.Drawing.Color.White;
            NoPassword.Hide();
            NoSymbol.Hide();
            NotMixed.Hide();
            NoNumber.Hide();
            TooShort.Hide();
        }

        //Removes error messages related to the username when the username box is clicked
        private void UsrnameInput_Click(object sender, EventArgs e)
        {
            UsrnameHeader.ForeColor = System.Drawing.Color.White;
            UsrSymbol.Hide();
            NoUsrname.Hide();
            UsrTaken.Hide();
        }

        //Removes error messages related to the password when the password box is clicked
        private void ConfirmPassword_Click(object sender, EventArgs e)
        {
            ConfirmHeader.ForeColor = System.Drawing.Color.White;
            NoMatch.Hide();
        }

        //Hides or unhides text in the password inputs
        private void PassShow_Click(object sender, EventArgs e)
        {
            if (PassShown == false)
            {
                PasswordInput.PasswordChar = '\0';
                ConfirmPassword.PasswordChar = '\0';
                PassShown = true;
                PassShow.Image = Properties.Resources.PassShow;
            }
            else if (PassShown == true)
            {
                PasswordInput.PasswordChar = '*';
                ConfirmPassword.PasswordChar = '*';
                PassShown = false;
                PassShow.Image = Properties.Resources.PassHide64;
            }

            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
        }

        //Writes error to ErrorLog with current time and message provided by exception
        public void ErrorLog(string Message)
        {
            try
            {
                string entry = $"{DateTime.UtcNow} : {Message}";
                File.AppendAllText(Common_Variables.ErrorLog, entry + Environment.NewLine);
            }
            catch 
            {
                return;
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

