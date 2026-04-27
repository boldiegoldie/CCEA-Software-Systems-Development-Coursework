using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class Tutorial : Form
    {
        //Initialise objects and variables
        string[] Pages = { "Designer", "DesignerMulti", "DesignerCheckbox", "DesignerTorf", "DesignerBlank", "CustomEnd", "Multi", "Checkbox", "Torf", "Blank", "Drop", "Event" };
        SoundPlayer player = new SoundPlayer();

        public Tutorial()
        {
            InitializeComponent();
        }

        //Goes to the previous tutorial page when GoBack is clicked
        private void GoBack_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            for (int i = 0; i < Pages.Length; i++)
            {
                if (Pages[i] == Common_Variables.CurrentPage)
                {
                    if (i - 1 < 0) //Loops foward to end of list if user goes back on the 1st page
                    {
                        i = Pages.Length - 1;
                        Common_Variables.CurrentPage = Pages[i];
                        break;
                    }
                    Common_Variables.CurrentPage = Pages[i - 1];
                    break;
                }
            }
            UpdateForm();
        }

        public void CloseForm(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Close();
            }
        }

        //Goes to the previous tutorial page when GoBack is clicked
        private void GoFoward_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            for (int i = 0; i < Pages.Length; i++)
            {
                if (Pages[i] == Common_Variables.CurrentPage)
                {
                    if (i + 1 >= Pages.Length) //Loops back to start of list if user goes foward on the last page
                    {
                        i = 0;
                        Common_Variables.CurrentPage = Pages[i];
                        break;
                    }
                    Common_Variables.CurrentPage = Pages[i + 1];

                    break;
                }
            }

            UpdateForm();
        }

        private void Tutorial_Load(object sender, EventArgs e)
        {  
            UpdateForm();
        }

        //Configures TutorialText,Header and pictureBox1 for the tutorial page that has been selected
        private void UpdateForm()
        {
            switch (Common_Variables.CurrentPage)
            {
                case "DesignerCheckbox":
                    TutorialTxt.Location = new Point(26, 218);
                    TutorialTxt.Size = new Size(649, 311);
                    TutorialTxt.Text = "This section allows you to add custom Checkbox questions to the Quiz." + Environment.NewLine + Environment.NewLine + "Enter your question into the textbox marked Question, with the font size for the question label being entered next to it." + Environment.NewLine + Environment.NewLine + "You can then enter the 4 possible options for your question in the 4 text boxes below, making sure to select which one of the options is the correct answer." + Environment.NewLine + Environment.NewLine + "Remember to choose the correct difficulty for your question using the difficulty buttons!";
                    Header.Text = "Making Questions: Checkbox";
                    pictureBox1.Image = Properties.Resources.DesignerCheck;
                    break;
                case "DesignerMulti":
                    TutorialTxt.Location = new Point(26, 218);
                    TutorialTxt.Size = new Size(649, 311);
                    TutorialTxt.Text = "This section allows you to add custom Multiple Choice questions to the Quiz." + Environment.NewLine + Environment.NewLine + "Enter your question into the textbox marked Question, with the font size for the question label being entered next to it." + Environment.NewLine + Environment.NewLine + "You can then enter the 4 possible options for your question in the 4 text boxes below, making sure to select which of the options is the correct answer(s)." + Environment.NewLine + Environment.NewLine + "Remember to choose the correct difficulty for your question using the difficulty buttons!";
                    Header.Text = "Making Questions: Multiple Choice";
                    pictureBox1.Image = Properties.Resources.DesignerMulti;
                    break;
                case "DesignerBlank":
                    TutorialTxt.Location = new Point(26, 218);
                    TutorialTxt.Size = new Size(649, 311);
                    TutorialTxt.Text = "This section allows you to add custom Fill in the Blank questions to the Quiz." + Environment.NewLine + Environment.NewLine + "Enter your question into the textbox marked Question, with the font size for the question label being entered next to it." + Environment.NewLine + Environment.NewLine + "You can then enter the answer to the question by typing into the textbox labelled Answer, you can also add up to 3 alternative answers using the checkboxes." + Environment.NewLine + Environment.NewLine + "Remember to choose the correct difficulty for your question using the difficulty buttons!";
                    Header.Text = "Making Questions: Fill in the Blank";
                    pictureBox1.Image = Properties.Resources.DesignerBlank;
                    break;
                case "DesignerTorf":
                    TutorialTxt.Location = new Point(26, 218);
                    TutorialTxt.Size = new Size(649, 311);
                    TutorialTxt.Text = "This section allows you to add custom True or False questions to the Quiz." + Environment.NewLine + Environment.NewLine + "Enter your question into the textbox marked Question, with the font size for the question label being entered next to it." + Environment.NewLine + Environment.NewLine + "You can then pick if the answer to your question is either True or False using the true and false buttons. The current answer to the question will be highlighted." + Environment.NewLine + Environment.NewLine + "Remember to choose the correct difficulty for your question using the difficulty buttons!";
                    Header.Text = "Making Questions: True or False";
                    pictureBox1.Image = Properties.Resources.DesignerTorf;
                    break;
                case "Designer":
                    TutorialTxt.Location = new Point(26, 187);
                    TutorialTxt.Size = new Size(649, 403);
                    TutorialTxt.Text = "The Question Designer allows you to add custom questions for 4/5 of the question types, these questions will be added to the list of questions that can show up in-game.\r\n\r\nTo begin, first select the type of question you want to add using the drop down menu. You can see existing questions of this type by hitting the \"See Existing Questions\" button.\r\n\r\nYou can preview what your question will look like in-game by hitting the Preview button and your question can be saved by hitting the Save button, any errors with your question will also show up here.\r\n\r\nNote: Custom questions will not be read out if question reading is enabled in the settings.\r\n";
                    Header.Text = "Making Questions";
                    pictureBox1.Image= Properties.Resources.Designer;
                    break;
                case "CustomEnd":
                    TutorialTxt.Location = new Point(26, 225);
                    TutorialTxt.Size = new Size(649, 327);
                    TutorialTxt.Text = "If you have Admin mode enabled in the settings, you can make custom end messages that will show up at the end of the Quiz.\r\n\r\nTo begin, first select the category of message you want to add using the drop down menu. You can see existing messages of this category by hitting the \"See Existing Questions\" button.\r\n\r\nType your message into the textbox and pick an appropriate font size, you can preview what your message will look like in by hitting the Preview button.\r\n\r\nYour message can be saved by hitting the Save button.\r\n";
                    Header.Text = "Making End Messages";
                    pictureBox1.Image = Properties.Resources.CustomEnd;
                    break;
                case "Multi":
                    TutorialTxt.Location = new Point(26, 333);
                    TutorialTxt.Size = new Size(649, 123);
                    TutorialTxt.Text = "In a Multiple Choise question you will be given a question that has 4 possible answers.\r\n\r\nYou must pick one of thse answers and then click the tick on the bottom bar to submit your answer.\r\n";
                    Header.Text = "Answering Questions: Multiple Choice";
                    pictureBox1.Image = Properties.Resources.MultiChoice;
                    break;
                case "Checkbox":
                    TutorialTxt.Location = new Point(30, 297);
                    TutorialTxt.Size = new Size(649, 168);
                    TutorialTxt.Text = "In a Checkbox question you are given a questino that has 4 possible answers.\r\n\r\nThe answer to the question may be any combination of these, but all questions require at least 1 option.\r\n\r\nTo confirm your answer, click the tick on the bottom bar.";
                    Header.Text = "Answering Questions: Checkbox";
                    pictureBox1.Image = Properties.Resources.Checkbox;
                    break;
                case "Torf":
                    TutorialTxt.Location = new Point(30, 277);
                    TutorialTxt.Size = new Size(649, 219);
                    TutorialTxt.Text = "In a True or False question you will be given a statement that is either true or false.\r\n\r\nYou must pick either true or false by clicking on either the true or false buttons. The button you have selected will he highlighted to show that you have chosen that answer.\r\n\r\nTo confirm your answer, click the tick on the bottom bar.\r\n";
                    pictureBox1.Image = Properties.Resources.TrueOrFalse;
                    Header.Text = "Answering Questions: True or False";
                    break;
                case "Blank":
                    TutorialTxt.Location = new Point(30, 285);
                    TutorialTxt.Size = new Size(649, 199);
                    TutorialTxt.Text = "In a Fill in the Blank question you are given a question and must type in the answer using the textbox.\r\n\r\nThere is anywhere from 1 to 4 possible answers for these questions.The answers are not case-sensitive and will ignore any spaces, but you must spell them right.\r\n\r\nTo confirm your answer, click the tick on the bottom bar.\r\n";
                    pictureBox1.Image = Properties.Resources.FillIInTheBlank;
                    Header.Text = "Answering Questions: Fill in the Blank";
                    break;
                case "Drop":
                    TutorialTxt.Location = new Point(30, 255);
                    TutorialTxt.Size = new Size(649, 256);
                    TutorialTxt.Text = "In a Drag and Drop question you will be given 4 images that you have to match to 4 labels.\r\n\r\nTo do this you must click and drag the images from the side bar to one of the purple boxes below the labels.\r\n\r\nWhen you do this the image will appear under the label instead of the purple box, but it will not disappear from the side bar.\r\n\r\nTo confirm your answer, click the tick on the bottom bar.";
                    pictureBox1.Image = Properties.Resources.DragDrop;
                    Header.Text = "Answering Questions: Drag and Drop";
                    break;
                case "Event":
                    TutorialTxt.Location = new Point(30, 251);
                    TutorialTxt.Size = new Size(649, 274);
                    TutorialTxt.Text = "You may get a special event while playing the quiz on Easy or Normal difficulty." + Environment.NewLine + Environment.NewLine + "These events will make the question harder to answer." + Environment.NewLine + Environment.NewLine + "There are 6 possible special events: Small Text, Large Text, Timed Question, Obstructed Answer, Reversed Text and Wingdings." + Environment.NewLine + Environment.NewLine + "Events can show up multiple times, but not all question types use all events.";
                    pictureBox1.Image = Properties.Resources.SpecialEvent;
                    Header.Text = "Answering Questions: Special Events";
                    break;
            }
        }
    }
}
