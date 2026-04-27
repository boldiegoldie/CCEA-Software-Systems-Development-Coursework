using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties;
using System.Text.RegularExpressions;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class Settings : Form
    {
        //Initalise variables, objects and events
        private const int VOLUME_UP = 0xA0000;
        private const int VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        public event EventHandler ShowTextView;
        public event EventHandler ShowWelcome;
        
        int previous_vol = 0;
        bool SaveFirstClick = true;
        bool UserFirstClick = true;
        bool Duplicate = false;
        bool BoardFirstClick = true;
        string[] MessageArray;
        string[] MessageArraySplit;
        
        List<UserData> userlist = new List<UserData>();
        IFormatter serialise = new BinaryFormatter();
        IFormatter deserialise = new BinaryFormatter();
        SoundPlayer player = new SoundPlayer();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            using (Stream fileStream = File.Open(Common_Variables.UserData, FileMode.Open)) //Loads settings from users account
            {
                userlist = (List<UserData>)(deserialise.Deserialize(fileStream));

                foreach (UserData searchuser in userlist)
                {
                    if (searchuser.User_id == Common_Variables.username)
                    {
                        Common_Variables.isAdmin = searchuser.IsAdmin;
                        Common_Variables.ReadQuestions = searchuser.ReadQuestions;
                        Common_Variables.dyslexia = searchuser.Dyslexia;
                        Common_Variables.SkipEnd = searchuser.SkipEnd;
                        break;
                    }
                }
            }

            //Hides admin settings
            DeleteUsrDat.Hide();
            ResetLeaderboard.Hide();
            AdminHeader.Hide();
            EndMessageHeader.Hide();
            MessageSelection.Hide();
            MessageHeader.Hide();
            MessageInput.Hide();
            FontSizeLabel.Hide();
            FontSizeInput.Hide();
            PreviewBtn.Hide();
            SaveBtn.Hide();
            AlreadyExists.Hide();
            NoMessage.Hide();
            NoOption.Hide();
            TextView.Hide();

            //Configures appearence for buttons
            SaveBtn.FlatAppearance.BorderSize = 0;
            PreviewBtn.FlatAppearance.BorderSize = 0;
            DeleteUsrDat.FlatAppearance.BorderSize = 0;
            ResetLeaderboard.FlatAppearance.BorderSize = 0;
            TextView.FlatAppearance.BorderSize = 0;

            MessageSelection.FlatStyle = FlatStyle.Flat;

            //Shows admin settings if admin mode is enabled and checks the admin mode checkbox
            if (Common_Variables.isAdmin)
            {
                checkedListBox.SetItemChecked(0, true);
                DeleteUsrDat.Show();
                ResetLeaderboard.Show();
                AdminHeader.Show();
                EndMessageHeader.Show();
                MessageSelection.Show();
                MessageHeader.Show();
                MessageInput.Show();
                FontSizeLabel.Show();
                FontSizeInput.Show();
                PreviewBtn.Show();
                SaveBtn.Show();
                TextView.Show();
            }

            //These 3 if statements check the checkboxes in the checkedListBox is their settings are enabled
            if (Common_Variables.ReadQuestions)
            {
                checkedListBox.SetItemChecked(1, true);
            }

            if (Common_Variables.SkipEnd)
            {
                checkedListBox.SetItemChecked(2, true);
            }

            if (Common_Variables.dyslexia)
            {
                checkedListBox.SetItemChecked(3, true);
            }
        }

        //Updates HolumeHeader with the current value of the volume variable
        private void volumeBar_ValueChanged(object sender, EventArgs e)
        {   
            if (volumeBar.Value % 2 != 0) //Volume can only be set to multiples of 2
            {
                volumeBar.Value--;
            }
            VolumeHeader.Text = "Volume: " + volumeBar.Value;
        }

        //Calls the user32 dll to decrease the volume by 2
        private void VolDown()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)VOLUME_DOWN);
        }

        //Calls the user32 dll to increase the volume by 2
        private void VolUp()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)VOLUME_UP);
        }

        //Applies any changes to the settings
        public void ApplySettings(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (!Common_Variables.muted)
                {
                    player.Stream = Resources.click;
                    player.Play();
                }
                if (volumeBar.Value != previous_vol) //Prevents volume being changed if it has not been changed by the user
                {
                    for (int i = 0; i < 50; i++) //Current system volume cannot be grabbed, so VolDown is called 50 times so volume is 0, so the code does not over/under shoot the desired volume
                    {
                        VolDown();
                    }

                    if (volumeBar.Value != 0) //Divides volumeBar value by 2 and calls VolUp that amount of times so that desired volume is reached.
                    {
                        for (int i = 0; i < volumeBar.Value / 2; i++)
                        {
                            VolUp();
                        }
                    }
                    previous_vol = volumeBar.Value;
                }

                if (checkedListBox.GetItemChecked(0)) //Sets admin mode to true and shows admin settings
                {
                    Common_Variables.isAdmin = true;
                    DeleteUsrDat.Show();
                    ResetLeaderboard.Show();
                    AdminHeader.Show();
                    EndMessageHeader.Show();
                    MessageSelection.Show();
                    MessageHeader.Show();
                    MessageInput.Show();
                    FontSizeLabel.Show();
                    FontSizeInput.Show();
                    PreviewBtn.Show();
                    SaveBtn.Show();
                    TextView.Show();
                }
                else //Sets admin mode to false and hides admin settings
                {
                    Common_Variables.isAdmin = false;
                    DeleteUsrDat.Hide();
                    ResetLeaderboard.Hide();
                    AdminHeader.Hide();
                    EndMessageHeader.Hide();
                    MessageSelection.Hide();
                    MessageHeader.Hide();
                    MessageInput.Hide();
                    FontSizeLabel.Hide();
                    FontSizeInput.Hide();
                    PreviewBtn.Hide();
                    SaveBtn.Hide();
                    TextView.Hide();
                }
                if (checkedListBox.GetItemChecked(1))
                {
                    Common_Variables.ReadQuestions = true;
                }
                else
                {
                    Common_Variables.ReadQuestions = false;
                }
                if (checkedListBox.GetItemChecked(2))
                {
                    Common_Variables.SkipEnd = true;
                }
                else
                {
                    Common_Variables.SkipEnd = false;
                }
                if (checkedListBox.GetItemChecked(3))
                {
                    Common_Variables.dyslexia = true;
                }
                else
                {
                    Common_Variables.dyslexia = false;
                }

                using (Stream fileStream = File.Open(Common_Variables.UserData, FileMode.Open))
                {
                    userlist = (List<UserData>)(deserialise.Deserialize(fileStream));
                }

                File.Delete(Common_Variables.UserData);

                using (Stream fileStream = File.Open(Common_Variables.UserData, FileMode.Create)) //Saves settings to user account in UserData
                {
                    foreach (UserData searchuser in userlist)
                    {
                        if (searchuser.User_id == Common_Variables.username)
                        {
                            searchuser.IsAdmin = Common_Variables.isAdmin;
                            searchuser.ReadQuestions = Common_Variables.ReadQuestions;
                            searchuser.Dyslexia = Common_Variables.dyslexia;
                            searchuser.SkipEnd = Common_Variables.SkipEnd;
                            break;
                        }
                    }
                    serialise.Serialize(fileStream, userlist); // Serialise data using a list of user objects
                    userlist.Clear();
                }
            }
        }

        public void CloseForm(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Close();
            }
        }

        //Changes the text and font size of SettingsHeader to the text in MessageInput and the value of FontSizeInput
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            SettingsHeader.Font = new Font("Lucida Sans", (float)Convert.ToDecimal(FontSizeInput.Value), FontStyle.Bold);
            SettingsHeader.Text = MessageInput.Text;
        }

        //Saves end message to file when button is clicked twice
        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (Common_Variables.muted == false)
                {
                    player.Stream = Properties.Resources.click;
                    player.Play();
                }

                if (SaveFirstClick) //Requires user to click button twice
                {
                    SaveBtn.Text = "Are you sure?";
                    SaveFirstClick = false;
                    await Task.Delay(3000);
                    if (!SaveFirstClick)
                    {
                        SaveBtn.Text = "Save";
                        SaveFirstClick = true;
                    }
                }
                else if (!SaveFirstClick)
                {
                    MessageInput.Text = MessageInput.Text.Replace("/", string.Empty);
                    if (MessageInput.Text == string.Empty)
                    {
                        NoMessage.Show();
                        MessageHeader.ForeColor = Color.Red;
                        SaveBtn.Text = "Save";
                    }
                    else if (MessageSelection.Text == "Select a message category")
                    {
                        NoOption.Show();
                        MessageHeader.ForeColor = Color.Red;
                    }
                    else
                    {
                        MessageInput.Text = Regex.Replace(MessageInput.Text, @"\t|\n|\r", ""); //Removes any new paragraph markers

                        Duplicate = false;
                        switch (MessageSelection.SelectedIndex) //Saves messgae to correct file for category chosen
                        {
                            case (0):
                                if (File.Exists(Common_Variables.path + @"\assets\txt\EndScreen\VeryBadEnd.txt"))
                                {
                                    MessageArray = File.ReadAllLines(Common_Variables.path + @"\assets\txt\EndScreen\VeryBadEnd.txt");
                                    for (int index = 0; index < MessageArray.Length; index++)
                                    {
                                        MessageArraySplit = MessageArray[index].Split('/');
                                        if (MessageArraySplit[1] == MessageInput.Text)
                                        {
                                            Duplicate = true;
                                        }
                                    }
                                    if (Duplicate)
                                    {
                                        AlreadyExists.Show();
                                        MessageHeader.ForeColor = Color.Red;
                                        MessageInput.Text = string.Empty;
                                    }
                                    else
                                    {
                                        File.AppendAllText(Common_Variables.path + @"\assets\txt\EndScreen\VeryBadEnd.txt", FontSizeInput.Value + "/" + MessageInput.Text + Environment.NewLine);
                                    }
                                }
                                else
                                {
                                    File.CreateText(Common_Variables.path + @"\assets\txt\EndScreen\VeryBadEnd.txt");
                                    File.AppendAllText(Common_Variables.path + @"\assets\txt\EndScreen\VeryBadEnd.txt", FontSizeInput.Value + " / " + MessageInput.Text + Environment.NewLine);
                                }
                                break;
                            case (1):
                                if (File.Exists(Common_Variables.path + @"\assets\txt\EndScreen\VeryBadEnd.txt"))
                                {
                                    MessageArray = File.ReadAllLines(Common_Variables.path + @"\assets\txt\EndScreen\BadEnd.txt");
                                    for (int index = 0; index < MessageArray.Length; index++)
                                    {
                                        MessageArraySplit = MessageArray[index].Split('/');
                                        if (MessageArraySplit[1] == MessageInput.Text)
                                        {
                                            Duplicate = true;
                                        }
                                    }
                                    if (Duplicate)
                                    {
                                        AlreadyExists.Show();
                                        MessageHeader.ForeColor = Color.Red;
                                        MessageInput.Text = string.Empty;
                                    }
                                    else
                                    {
                                        File.AppendAllText(Common_Variables.path + @"\assets\txt\EndScreen\BadEnd.txt", FontSizeInput.Value + "/" + MessageInput.Text + Environment.NewLine);
                                    }
                                }
                                else
                                {
                                    File.CreateText(Common_Variables.path + @"\assets\txt\EndScreen\BadEnd.txt");
                                    File.AppendAllText(Common_Variables.path + @"\assets\txt\EndScreen\BadEnd.txt", FontSizeInput.Value + " / " + MessageInput.Text + Environment.NewLine);
                                }
                                break;
                            case (2):
                                if (File.Exists(Common_Variables.path + @"\assets\txt\EndScreen\NormalEnd.txt"))
                                {
                                    MessageArray = File.ReadAllLines(Common_Variables.path + @"\assets\txt\EndScreen\NormalEnd.txt");
                                    for (int index = 0; index < MessageArray.Length; index++)
                                    {
                                        MessageArraySplit = MessageArray[index].Split('/');
                                        if (MessageArraySplit[1] == MessageInput.Text)
                                        {
                                            Duplicate = true;
                                        }
                                    }
                                    if (Duplicate)
                                    {
                                        AlreadyExists.Show();
                                        MessageHeader.ForeColor = Color.Red;
                                        MessageInput.Text = string.Empty;
                                    }
                                    else
                                    {
                                        File.AppendAllText(Common_Variables.path + @"\assets\txt\EndScreen\NormalEnd.txt", FontSizeInput.Value + "/" + MessageInput.Text + Environment.NewLine);
                                    }
                                }
                                else
                                {
                                    File.CreateText(Common_Variables.path + @"\assets\txt\EndScreen\NormalEnd.txt");
                                    File.AppendAllText(Common_Variables.path + @"\assets\txt\EndScreen\NormalEnd.txt", FontSizeInput.Value + " / " + MessageInput.Text + Environment.NewLine);
                                }
                                break;
                            case (3):
                                if (File.Exists(Common_Variables.path + @"\assets\txt\EndScreen\GoodEnd.txt"))
                                {
                                    MessageArray = File.ReadAllLines(Common_Variables.path + @"\assets\txt\EndScreen\GoodEnd.txt");
                                    for (int index = 0; index < MessageArray.Length; index++)
                                    {
                                        MessageArraySplit = MessageArray[index].Split('/');
                                        if (MessageArraySplit[1] == MessageInput.Text)
                                        {
                                            Duplicate = true;
                                        }
                                    }
                                    if (Duplicate)
                                    {
                                        AlreadyExists.Show();
                                        MessageHeader.ForeColor = Color.Red;
                                        MessageInput.Text = string.Empty;
                                    }
                                    else
                                    {
                                        File.AppendAllText(Common_Variables.path + @"\assets\txt\EndScreen\GoodEnd.txt", FontSizeInput.Value + "/" + MessageInput.Text + Environment.NewLine);
                                    }
                                }
                                else
                                {
                                    File.Create(Common_Variables.path + @"\assets\txt\EndScreen\GoodEnd.txt").Close();
                                    File.AppendAllText(Common_Variables.path + @"\assets\txt\EndScreen\GoodEnd.txt", FontSizeInput.Value + " / " + MessageInput.Text + Environment.NewLine);
                                }
                                break;
                            case (4):
                                if (File.Exists(Common_Variables.path + @"\assets\txt\EndScreen\VeryGoodEnd.txt"))
                                {
                                    MessageArray = File.ReadAllLines(Common_Variables.path + @"\assets\txt\EndScreen\VeryGoodEnd.txt");
                                    for (int index = 0; index < MessageArray.Length; index++)
                                    {
                                        MessageArraySplit = MessageArray[index].Split('/');
                                        if (MessageArraySplit[1] == MessageInput.Text)
                                        {
                                            Duplicate = true;
                                        }
                                    }
                                    if (Duplicate)
                                    {
                                        AlreadyExists.Show();
                                        MessageHeader.ForeColor = Color.Red;
                                        MessageInput.Text = string.Empty;
                                    }
                                    else
                                    {
                                        File.AppendAllText(Common_Variables.path + @"\assets\txt\EndScreen\VeryGoodEnd.txt", FontSizeInput.Value + "/" + MessageInput.Text + Environment.NewLine);
                                    }
                                }
                                else
                                {
                                    File.Create(Common_Variables.path + @"\assets\txt\EndScreen\VeryGoodEnd.txt").Close();
                                    File.AppendAllText(Common_Variables.path + @"\assets\txt\EndScreen\VeryGoodEnd.txt", FontSizeInput.Value + "/" + MessageInput.Text + Environment.NewLine);
                                }

                                break;
                        }
                    }
                    SaveBtn.Text = "Saved!";
                    MessageInput.Text = string.Empty;
                    SaveFirstClick = true;
                    await Task.Delay(1000);
                    if (SaveFirstClick)
                    {
                        SaveBtn.Text = "Save";
                    }
                }
            }
        }

        //Removes anyt error messages when MessageInput is clicked
        private void MessageInput_Click(object sender, EventArgs e)
        {
            MessageHeader.ForeColor = Color.White;
            AlreadyExists.Hide();
            NoMessage.Hide();
        }

        //Sends user to TextViewer and tells TextViewer what file to show
        private void FileView_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (MessageSelection.Text == "Select a message category")
            {
                NoOption.Show();
                MessageHeader.ForeColor= Color.Red;
            }
            else
            {
                switch (MessageSelection.SelectedIndex)
                {
                    case (0):
                        Common_Variables.FileToBeViewed = "VeryBadEnd.txt";
                        break;
                    case (1):
                        Common_Variables.FileToBeViewed = "BadEnd.txt";
                        break;
                    case (2):
                        Common_Variables.FileToBeViewed = "NormalEnd.txt";
                        break;
                    case (3):
                        Common_Variables.FileToBeViewed = "GoodEnd.txt";
                        break;
                    case (4):
                        Common_Variables.FileToBeViewed = "VeryGoodEnd.txt";
                        break;
                }

                if (ShowTextView != null)
                {
                    ShowTextView.Invoke(sender, EventArgs.Empty);
                }
                this.Close();
            }
        }

        //Hides any error messages when MessageSelection is clicked
        private void MessageSelection_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }
            NoOption.Hide();
            MessageHeader.ForeColor = Color.White;
        }

        //Deletes UserData when button is clicked twice and sends user back to WelcomeScreen
        async private void DeleteUsrDat_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (UserFirstClick) //Makes user click button twice
            {
                DeleteUsrDat.Text = "Are you sure?";
                UserFirstClick = false;
                await Task.Delay(3000);
                if (!UserFirstClick)
                {
                    DeleteUsrDat.Text = "Delete UserData";
                    UserFirstClick = true;
                }
            }
            else if (!UserFirstClick)
            { 
                UserFirstClick = true;
                File.Delete(Common_Variables.UserData);
                DeleteUsrDat.Text = "Deleted!";
                await Task.Delay(500);
                if (ShowWelcome != null)
                {
                    ShowWelcome.Invoke(sender, EventArgs.Empty);
                }
                this.Close();
            }
        }

        //Deletes LeaderboardData when button is clicked twice
        async private void ResetLeaderboard_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (BoardFirstClick) //Ensures that user has to click button twice before any data is deleted
            {
                ResetLeaderboard.Text = "Are you sure?";
                BoardFirstClick = false;
                await Task.Delay(3000);
                if (!BoardFirstClick)
                {
                    ResetLeaderboard.Text = "Reset Leaderboard";
                    UserFirstClick = true;
                }
            }
            else if (!BoardFirstClick)
            {
                BoardFirstClick = true;
                File.Delete(Common_Variables.LeaderboardData);
                ResetLeaderboard.Text = "Deleted!";
                await Task.Delay(500);
                ResetLeaderboard.Text = "Reset Leaderboard";
            }
        }

        //Prevents user from typing any / into MessageInput, as it would cause the quiz to crash when the end message is read by EndScreen
        private void MessageInput_KeyUp(object sender, KeyEventArgs e)
        {
            var regex = new Regex(@"\/+");

            if (regex.IsMatch(MessageInput.Text))
            {
                MessageInput.Text = MessageInput.Text.Replace("/", string.Empty);
            }
        }
    }
}