using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class DragAndDrop : Form
    {
        //Initalises evens, objects & variables
        public event EventHandler UpdateQNum;
        public event EventHandler NextSection;

        Random random = new Random();
        Questions questions = new Questions();
        SoundPlayer player = new SoundPlayer();

        string answer = string.Empty;
        string[] SpecialEventList = { "SmallText", "LargeText", "TimedQuestion", "ReverseText", "Wingdings" };
        int TimeLeft = 0;

        public DragAndDrop()
        { 
            InitializeComponent();
        }

        //Updates QuestionUI, hides admin UI if not admin and calls NewQuestion
        private void DragAndDrop_Load(object sender, EventArgs e)
        {
            if (UpdateQNum != null)
            {
                UpdateQNum.Invoke(this, EventArgs.Empty);
            }

            if (!Common_Variables.isAdmin)
            {
                AdminTxt1.Hide();
                AdminTxt2.Hide();
                AdminTxt3.Hide();
                AdminTxt4.Hide();
                One.Hide();
                Two.Hide();
                Three.Hide();
                Four.Hide();
            }
            
            NewQuestion(Common_Variables.path);
        }

        //Loads new question from draganddrop.txt
        public void NewQuestion(string path)
        {
            NoAns.Hide();
            TimerLabel.Hide();
            timer1.Enabled = false;

            try
            {
                string[] QuestionsArray;
                bool valid = false;
                QuestionsArray = File.ReadAllLines(path + @"\assets\txt\draganddrop.txt");
                int no_of_questions = QuestionsArray.Count();
                int rand_num = random.Next(0, no_of_questions);
                questions.Split = QuestionsArray[rand_num].Split('/');

                //Allows user to drag images from / onto the pictureboxes
                pictureBox1.AllowDrop = true;
                pictureBox2.AllowDrop = true;
                pictureBox3.AllowDrop = true;
                pictureBox4.AllowDrop = true;
                pictureBox5.AllowDrop = true;
                pictureBox6.AllowDrop = true;
                pictureBox7.AllowDrop = true;
                pictureBox8.AllowDrop = true;

                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;
                pictureBox5.Image = Resources.UI_Purple;
                pictureBox6.Image = Resources.UI_Purple;
                pictureBox7.Image = Resources.UI_Purple;
                pictureBox8.Image = Resources.UI_Purple;

                pictureBox1.Tag = null;
                pictureBox2.Tag = null;
                pictureBox3.Tag = null;
                pictureBox4.Tag = null;
                pictureBox5.Tag = null;
                pictureBox6.Tag = null;
                pictureBox7.Tag = null;
                pictureBox8.Tag = null;

                //Sets font for UI to either Lucida Sans or Comic Sans MS, depending on if dyslexia mode is enabled
                if (Common_Variables.dyslexia)
                {
                    AnsHeader1.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    AnsHeader2.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    AnsHeader3.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    AnsHeader4.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    AdminTxt1.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    AdminTxt2.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    AdminTxt3.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    AdminTxt4.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    TimerLabel.Font = new Font("Comic Sans MS", 32, FontStyle.Regular);
                    NoAns.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    One.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    Two.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    Three.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                    Four.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
                }
                else
                {
                    AnsHeader1.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    AnsHeader2.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    AnsHeader3.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    AnsHeader4.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    AdminTxt1.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    AdminTxt2.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    AdminTxt3.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    AdminTxt4.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    TimerLabel.Font = new Font("Lucida Sans", 32, FontStyle.Bold);
                    NoAns.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    One.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    Two.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    Three.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                    Four.Font = new Font("Lucida Sans", 24, FontStyle.Bold);
                }

                while (valid == false) //Rejects questionif it has already been used or if it does not match quiz difficulty
                {
                    if (questions.Split[0] != Common_Variables.difficulty && Common_Variables.difficulty != "n")
                    {
                        rand_num = random.Next(1, no_of_questions);
                        questions.Split = QuestionsArray[rand_num].Split('/');
                    }
                    else
                    {
                        bool duplicate = false;
                        for (int i = 0; i < Common_Variables.UsedQuestions.Count; i++)
                        {
                            if (Common_Variables.UsedQuestions.ElementAt(i) == questions.Split[2])
                            {
                                duplicate = true;
                                rand_num = random.Next(0, no_of_questions);
                                questions.Split = QuestionsArray[rand_num].Split('/');
                                break;
                            }
                        }
                        if (duplicate == false)
                        {
                            Common_Variables.UsedQuestions.Add(questions.Split[2]);
                            valid = true;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("draganddrop.txt is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(Environment.ExitCode);
            }

            int rand_num2 = random.Next(1, 5); //Randomly assign answer options to picturebox 5-8, loads positions, size and image for picturebox 1-4 accordingly

            if (rand_num2 == 1)
            {
                pictureBox1.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[4]);
                pictureBox1.Size = new Size(Convert.ToInt32(questions.Split[5]), Convert.ToInt32(questions.Split[6]));
                pictureBox1.Location = new Point(Convert.ToInt32(questions.Split[7]), Convert.ToInt32(questions.Split[8]));
                pictureBox1.Tag = questions.Split[4];
                AnsHeader1.Text = questions.Split[24];
                AdminTxt1.Text = "1";
            }
            else if (rand_num2 == 2)
            {
                pictureBox1.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[9]);
                pictureBox1.Size = new Size(Convert.ToInt32(questions.Split[10]), Convert.ToInt32(questions.Split[11]));
                pictureBox1.Location = new Point(Convert.ToInt32(questions.Split[12]), Convert.ToInt32(questions.Split[13]));
                pictureBox1.Tag = questions.Split[9];
                AnsHeader1.Text = questions.Split[25];
                AdminTxt1.Text = "2";
            }
            else if (rand_num2 == 3)
            {
                pictureBox1.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[14]);
                pictureBox1.Size = new Size(Convert.ToInt32(questions.Split[15]), Convert.ToInt32(questions.Split[16]));
                pictureBox1.Location = new Point(Convert.ToInt32(questions.Split[17]), Convert.ToInt32(questions.Split[18]));
                pictureBox1.Tag = questions.Split[14];
                AnsHeader1.Text = questions.Split[26];
                AdminTxt1.Text = "3";
            }
            else if (rand_num2 == 4)
            {
                pictureBox1.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[19]);
                pictureBox1.Size = new Size(Convert.ToInt32(questions.Split[20]), Convert.ToInt32(questions.Split[21]));
                pictureBox1.Location = new Point(Convert.ToInt32(questions.Split[22]), Convert.ToInt32(questions.Split[23]));
                pictureBox1.Tag = questions.Split[19];
                AnsHeader1.Text = questions.Split[27];
                AdminTxt1.Text = "4";
            }

            rand_num2 = random.Next(1, 5);

            if (rand_num2 == 1)
            {
                pictureBox2.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[4]);
                pictureBox2.Size = new Size(Convert.ToInt32(questions.Split[5]), Convert.ToInt32(questions.Split[6]));
                pictureBox2.Location = new Point(Convert.ToInt32(questions.Split[7]), Convert.ToInt32(questions.Split[8]));
                pictureBox2.Tag = questions.Split[4];
                AnsHeader2.Text = questions.Split[24];
                AdminTxt2.Text = "1";
            }
            else if (rand_num2 == 2)
            {
                pictureBox2.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[9]);
                pictureBox2.Size = new Size(Convert.ToInt32(questions.Split[10]), Convert.ToInt32(questions.Split[11]));
                pictureBox2.Location = new Point(Convert.ToInt32(questions.Split[12]), Convert.ToInt32(questions.Split[13]));
                pictureBox2.Tag = questions.Split[9];
                AnsHeader2.Text = questions.Split[25];
                AdminTxt2.Text = "2";
            }
            else if (rand_num2 == 3)
            {
                pictureBox2.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[14]);
                pictureBox2.Size = new Size(Convert.ToInt32(questions.Split[15]), Convert.ToInt32(questions.Split[16]));
                pictureBox2.Location = new Point(Convert.ToInt32(questions.Split[17]), Convert.ToInt32(questions.Split[18]));
                pictureBox2.Tag = questions.Split[14];
                AnsHeader2.Text = questions.Split[26];
                AdminTxt2.Text = "3";
            }
            else if (rand_num2 == 4)
            {
                pictureBox2.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[19]);
                pictureBox2.Size = new Size(Convert.ToInt32(questions.Split[20]), Convert.ToInt32(questions.Split[21]));
                pictureBox2.Location = new Point(Convert.ToInt32(questions.Split[22]), Convert.ToInt32(questions.Split[23]));
                pictureBox2.Tag = questions.Split[19];
                AnsHeader2.Text = questions.Split[27];
                AdminTxt2.Text = "4";
            }

            while (pictureBox1.Tag == pictureBox2.Tag)//Each picturebox is checked to make sure that no option is duplicated, new option picked if one is duplicated.
            {
                rand_num2 = random.Next(1, 5);
                if (rand_num2 == 1)
                {
                    pictureBox2.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[4]);
                    pictureBox2.Size = new Size(Convert.ToInt32(questions.Split[5]), Convert.ToInt32(questions.Split[6]));
                    pictureBox2.Location = new Point(Convert.ToInt32(questions.Split[7]), Convert.ToInt32(questions.Split[8]));
                    pictureBox2.Tag = questions.Split[4];
                    AnsHeader2.Text = questions.Split[24];
                    AdminTxt2.Text = "1";
                }
                else if (rand_num2 == 2)
                {
                    pictureBox2.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[9]);
                    pictureBox2.Size = new Size(Convert.ToInt32(questions.Split[10]), Convert.ToInt32(questions.Split[11]));
                    pictureBox2.Location = new Point(Convert.ToInt32(questions.Split[12]), Convert.ToInt32(questions.Split[13]));
                    pictureBox2.Tag = questions.Split[9];
                    AnsHeader2.Text = questions.Split[25];
                    AdminTxt2.Text = "2";
                }
                else if (rand_num2 == 3)
                {
                    pictureBox2.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[14]);
                    pictureBox2.Size = new Size(Convert.ToInt32(questions.Split[15]), Convert.ToInt32(questions.Split[16]));
                    pictureBox2.Location = new Point(Convert.ToInt32(questions.Split[17]), Convert.ToInt32(questions.Split[18]));
                    pictureBox2.Tag = questions.Split[14];
                    AnsHeader2.Text = questions.Split[26];
                    AdminTxt2.Text = "3";
                }
                else if (rand_num2 == 4)
                {
                    pictureBox2.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[19]);
                    pictureBox2.Size = new Size(Convert.ToInt32(questions.Split[20]), Convert.ToInt32(questions.Split[21]));
                    pictureBox2.Location = new Point(Convert.ToInt32(questions.Split[22]), Convert.ToInt32(questions.Split[23]));
                    pictureBox2.Tag = questions.Split[19];
                    AnsHeader2.Text = questions.Split[27];
                    AdminTxt2.Text = "4";
                }
            }

            rand_num2 = random.Next(1, 5);

            if (rand_num2 == 1)
            {
                pictureBox3.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[4]);
                pictureBox3.Size = new Size(Convert.ToInt32(questions.Split[5]), Convert.ToInt32(questions.Split[6]));
                pictureBox3.Location = new Point(Convert.ToInt32(questions.Split[7]), Convert.ToInt32(questions.Split[8]));
                pictureBox3.Tag = questions.Split[4];
                AnsHeader3.Text = questions.Split[24];
                AdminTxt3.Text = "1";
            }
            else if (rand_num2 == 2)
            {
                pictureBox3.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[9]);
                pictureBox3.Size = new Size(Convert.ToInt32(questions.Split[10]), Convert.ToInt32(questions.Split[11]));
                pictureBox3.Location = new Point(Convert.ToInt32(questions.Split[12]), Convert.ToInt32(questions.Split[13]));
                pictureBox3.Tag = questions.Split[9];
                AnsHeader3.Text = questions.Split[25];
                AdminTxt3.Text = "2";
            }
            else if (rand_num2 == 3)
            {
                pictureBox3.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[14]);
                pictureBox3.Size = new Size(Convert.ToInt32(questions.Split[15]), Convert.ToInt32(questions.Split[16]));
                pictureBox3.Location = new Point(Convert.ToInt32(questions.Split[17]), Convert.ToInt32(questions.Split[18]));
                pictureBox3.Tag = questions.Split[14];
                AnsHeader3.Text = questions.Split[26];
                AdminTxt3.Text = "3";
            }
            else if (rand_num2 == 4)
            {
                pictureBox3.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[19]);
                pictureBox3.Size = new Size(Convert.ToInt32(questions.Split[20]), Convert.ToInt32(questions.Split[21]));
                pictureBox3.Location = new Point(Convert.ToInt32(questions.Split[22]), Convert.ToInt32(questions.Split[23]));
                pictureBox3.Tag = questions.Split[19];
                AnsHeader3.Text = questions.Split[27];
                AdminTxt3.Text = "4";
            }

            while (pictureBox3.Tag == pictureBox2.Tag || pictureBox3.Tag == pictureBox1.Tag)
            {
                rand_num2 = random.Next(1, 5);
                if (rand_num2 == 1)
                {
                    pictureBox3.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[4]);
                    pictureBox3.Size = new Size(Convert.ToInt32(questions.Split[5]), Convert.ToInt32(questions.Split[6]));
                    pictureBox3.Location = new Point(Convert.ToInt32(questions.Split[7]), Convert.ToInt32(questions.Split[8]));
                    pictureBox3.Tag = questions.Split[4];
                    AnsHeader3.Text = questions.Split[24];
                    AdminTxt3.Text = "1";
                }
                else if (rand_num2 == 2)
                {
                    pictureBox3.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[9]);
                    pictureBox3.Size = new Size(Convert.ToInt32(questions.Split[10]), Convert.ToInt32(questions.Split[11]));
                    pictureBox3.Location = new Point(Convert.ToInt32(questions.Split[12]), Convert.ToInt32(questions.Split[13]));
                    pictureBox3.Tag = questions.Split[9];
                    AnsHeader3.Text = questions.Split[25];
                    AdminTxt3.Text = "2";
                }
                else if (rand_num2 == 3)
                {
                    pictureBox3.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[14]);
                    pictureBox3.Size = new Size(Convert.ToInt32(questions.Split[15]), Convert.ToInt32(questions.Split[16]));
                    pictureBox3.Location = new Point(Convert.ToInt32(questions.Split[17]), Convert.ToInt32(questions.Split[18]));
                    pictureBox3.Tag = questions.Split[14];
                    AnsHeader3.Text = questions.Split[26];
                    AdminTxt3.Text = "3";
                }
                else if (rand_num2 == 4)
                {
                    pictureBox3.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[19]);
                    pictureBox3.Size = new Size(Convert.ToInt32(questions.Split[20]), Convert.ToInt32(questions.Split[21]));
                    pictureBox3.Location = new Point(Convert.ToInt32(questions.Split[22]), Convert.ToInt32(questions.Split[23]));
                    pictureBox3.Tag = questions.Split[19];
                    AnsHeader3.Text = questions.Split[27];
                    AdminTxt3.Text = "4";
                }
            }

            rand_num2 = random.Next(1, 5);

            if (rand_num2 == 1)
            {
                pictureBox4.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[4]);
                pictureBox4.Size = new Size(Convert.ToInt32(questions.Split[5]), Convert.ToInt32(questions.Split[6]));
                pictureBox4.Location = new Point(Convert.ToInt32(questions.Split[7]), Convert.ToInt32(questions.Split[8]));
                pictureBox4.Tag = questions.Split[4];
                AnsHeader4.Text = questions.Split[24];
                AdminTxt4.Text = "1";
            }
            else if (rand_num2 == 2)
            {
                pictureBox4.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[9]);
                pictureBox4.Size = new Size(Convert.ToInt32(questions.Split[10]), Convert.ToInt32(questions.Split[11]));
                pictureBox4.Location = new Point(Convert.ToInt32(questions.Split[12]), Convert.ToInt32(questions.Split[13]));
                pictureBox4.Tag = questions.Split[9];
                AnsHeader4.Text = questions.Split[25];
                AdminTxt4.Text = "2";
            }
            else if (rand_num2 == 3)
            {
                pictureBox4.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[14]);
                pictureBox4.Size = new Size(Convert.ToInt32(questions.Split[15]), Convert.ToInt32(questions.Split[16]));
                pictureBox4.Location = new Point(Convert.ToInt32(questions.Split[17]), Convert.ToInt32(questions.Split[18]));
                pictureBox4.Tag = questions.Split[14];
                AnsHeader4.Text = questions.Split[26];
                AdminTxt4.Text = "3";
            }
            else if (rand_num2 == 4)
            {
                pictureBox4.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[19]);
                pictureBox4.Size = new Size(Convert.ToInt32(questions.Split[20]), Convert.ToInt32(questions.Split[21]));
                pictureBox4.Location = new Point(Convert.ToInt32(questions.Split[22]), Convert.ToInt32(questions.Split[23]));
                pictureBox4.Tag = questions.Split[19];
                AnsHeader4.Text = questions.Split[27];
                AdminTxt4.Text = "4";
            }

            while (pictureBox4.Tag == pictureBox2.Tag || pictureBox4.Tag == pictureBox1.Tag || pictureBox4.Tag == pictureBox3.Tag)
            {
                rand_num2 = random.Next(1, 5);
                if (rand_num2 == 1)
                {
                    pictureBox4.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[4]);
                    pictureBox4.Size = new Size(Convert.ToInt32(questions.Split[5]), Convert.ToInt32(questions.Split[6]));
                    pictureBox4.Location = new Point(Convert.ToInt32(questions.Split[7]), Convert.ToInt32(questions.Split[8]));
                    pictureBox4.Tag = questions.Split[4];
                    AnsHeader4.Text = questions.Split[24];
                    AdminTxt4.Text = "1";
                }
                else if (rand_num2 == 2)
                {
                    pictureBox4.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[9]);
                    pictureBox4.Size = new Size(Convert.ToInt32(questions.Split[10]), Convert.ToInt32(questions.Split[11]));
                    pictureBox4.Location = new Point(Convert.ToInt32(questions.Split[12]), Convert.ToInt32(questions.Split[13]));
                    pictureBox4.Tag = questions.Split[9];
                    AnsHeader4.Text = questions.Split[25];
                    AdminTxt4.Text = "2";
                }
                else if (rand_num2 == 3)
                {
                    pictureBox4.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[14]);
                    pictureBox4.Size = new Size(Convert.ToInt32(questions.Split[15]), Convert.ToInt32(questions.Split[16]));
                    pictureBox4.Location = new Point(Convert.ToInt32(questions.Split[17]), Convert.ToInt32(questions.Split[18]));
                    pictureBox4.Tag = questions.Split[14];
                    AnsHeader4.Text = questions.Split[26];
                    AdminTxt4.Text = "3";
                }
                else if (rand_num2 == 4)
                {
                    pictureBox4.Image = (Bitmap)Resources.ResourceManager.GetObject(questions.Split[19]);
                    pictureBox4.Size = new Size(Convert.ToInt32(questions.Split[20]), Convert.ToInt32(questions.Split[21]));
                    pictureBox4.Location = new Point(Convert.ToInt32(questions.Split[22]), Convert.ToInt32(questions.Split[23]));
                    pictureBox4.Tag = questions.Split[19];
                    AnsHeader4.Text = questions.Split[27];
                    AdminTxt4.Text = "4";
                }
            }

            answer = pictureBox1.Tag.ToString() + pictureBox2.Tag.ToString() + pictureBox3.Tag.ToString() + pictureBox4.Tag.ToString();
            QuestionHeader.Text = questions.Split[3];
            if (Common_Variables.dyslexia) //Sets font for QuestionHeader to either Lucida Sans or Comic Sans MS depending ifthe user has enabled dyslexia mode
            {
                QuestionHeader.Font = new Font("Comic Sans MS", (float)Convert.ToDecimal(questions.Split[1]), FontStyle.Bold);
            }
            else
            {
                QuestionHeader.Font = new Font("Lucida Sans", (float)Convert.ToDecimal(questions.Split[1]), FontStyle.Bold);
            }

            if (Common_Variables.ReadQuestions)
            {
                ReadQuestion();
            }
            SpecialEvent();
        }

        //These next 4 functions set the e variabl to the current image of its respective picturebox
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.DoDragDrop(pictureBox1.Image, DragDropEffects.Copy);        
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.DoDragDrop(pictureBox2.Image, DragDropEffects.Copy);
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.DoDragDrop(pictureBox3.Image, DragDropEffects.Copy);
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox4.DoDragDrop(pictureBox4.Image, DragDropEffects.Copy);
        }

        //Sets the image for picturebox5 to the image in e and sets its tag to the tag of the source picturebox
        private void pictureBox5_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox5.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            
            if (pictureBox5.Image == pictureBox1.Image)
            {
                pictureBox5.Tag = pictureBox1.Tag;
            }
            else if (pictureBox5.Image == pictureBox2.Image)
            {
                pictureBox5.Tag = pictureBox2.Tag;
            }
            else if (pictureBox5.Image == pictureBox3.Image)
            {
                pictureBox5.Tag = pictureBox3.Tag;
            }
            else if (pictureBox5.Image == pictureBox4.Image)
            {
                pictureBox5.Tag = pictureBox4.Tag;
            }
        }

        //Sets the image for picturebox5 to the image in e and sets its tag to the tag of the source picturebox
        private void pictureBox6_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox6.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            
            if (pictureBox6.Image == pictureBox1.Image)
            {
                pictureBox6.Tag = pictureBox1.Tag;
            }
            else if (pictureBox6.Image == pictureBox2.Image)
            {
                pictureBox6.Tag = pictureBox2.Tag;
            }
            else if (pictureBox6.Image == pictureBox3.Image)
            {
                pictureBox6.Tag = pictureBox3.Tag;
            }
            else if (pictureBox6.Image == pictureBox4.Image)
            {
                pictureBox6.Tag = pictureBox4.Tag;
            }
        }

        //Sets the image for picturebox5 to the image in e and sets its tag to the tag of the source picturebox
        private void pictureBox7_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox7.Image = (Image)e.Data.GetData(DataFormats.Bitmap);

            if (pictureBox7.Image == pictureBox1.Image)
            {
                pictureBox7.Tag = pictureBox1.Tag;
            }
            else if (pictureBox7.Image == pictureBox2.Image)
            {
                pictureBox7.Tag = pictureBox2.Tag;
            }
            else if (pictureBox7.Image == pictureBox3.Image)
            {
                pictureBox7.Tag = pictureBox3.Tag;
            }
            else if (pictureBox7.Image == pictureBox4.Image)
            {
                pictureBox7.Tag = pictureBox4.Tag;
            }
        }

        //Sets the image for picturebox5 to the image in e and sets its tag to the tag of the source picturebox
        private void pictureBox8_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox8.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
           
            if (pictureBox8.Image == pictureBox1.Image)
            {
                pictureBox8.Tag = pictureBox1.Tag;
            }
            else if (pictureBox8.Image == pictureBox2.Image)
            {
                pictureBox8.Tag = pictureBox2.Tag;
            }
            else if (pictureBox8.Image == pictureBox3.Image)
            {
                pictureBox8.Tag = pictureBox3.Tag;
            }
            else if (pictureBox8.Image == pictureBox4.Image)
            {
                pictureBox8.Tag = pictureBox4.Tag;
            }
        }

        private void pictureBox5_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox6_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox7_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox8_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        //Checks if users answer is correct, gives points accourding to difficulty if correct and then calls NewQuestion
        public void AnsCheck(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                TimerLabel.Hide();
                if ((string)pictureBox5.Tag + (string)pictureBox6.Tag + (string)pictureBox7.Tag + (string)pictureBox8.Tag == answer)
                {
                    Common_Variables.DropLifeCorrect += 1;
                    Common_Variables.LifetimeCorrect += 1;
                    switch (Common_Variables.difficulty)
                    {
                        case "e":
                            Common_Variables.score += 0.5;
                            if (Common_Variables.muted == false)
                            {
                                player.Stream = Properties.Resources.ding;
                                player.Play();
                            }
                            break;
                        case "n":
                            Common_Variables.score += 0.75;
                            if (Common_Variables.muted == false)
                            {
                                player.Stream = Properties.Resources.ding;
                                player.Play();
                            }
                            break;
                        case "h":
                            Common_Variables.score += 1;
                            if (Common_Variables.muted == false)
                            {
                                player.Stream = Properties.Resources.ding;
                                player.Play();
                            }
                            break;
                    }

                    if (Common_Variables.q_number % 5 == 0 || Common_Variables.q_number > 19)
                    {
                        if (NextSection != null)
                        {
                            Common_Variables.q_number = Common_Variables.q_number + 1;
                            NextSection.Invoke(this, EventArgs.Empty);
                            this.Close();
                            return;
                        }
                    }
                    Common_Variables.q_number = Common_Variables.q_number + 1;

                    if (UpdateQNum != null)
                    {
                        UpdateQNum.Invoke(this, EventArgs.Empty);
                    }
                    NewQuestion(Common_Variables.path);
                }
                else if (pictureBox5.Tag == null || pictureBox6.Tag == null || pictureBox7.Tag == null || pictureBox8.Tag == null)
                {
                    NoAns.Show();
                }
                else
                {
                    Common_Variables.DropLifeIncorrect += 1;
                    Common_Variables.LifetimeIncorrect += 1;

                    if (!Common_Variables.muted)
                    {
                        player.Stream = Properties.Resources.wrong;
                        player.Play();
                    }

                    if (Common_Variables.q_number % 5 == 0 || Common_Variables.q_number > 19)
                    {
                        if (NextSection != null)
                        {
                            Common_Variables.q_number = Common_Variables.q_number + 1;
                            NextSection.Invoke(this, EventArgs.Empty);
                            this.Close();
                            return;
                        }
                    }
                    Common_Variables.q_number = Common_Variables.q_number + 1;

                    if (UpdateQNum != null)
                    {
                        UpdateQNum.Invoke(this, EventArgs.Empty);
                    }
                    NewQuestion(Common_Variables.path);
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

        //Decides if special event is triggered and what each event does
        private void SpecialEvent()
        {
            int event_probability = random.Next(1, 21);
            int event_selected = random.Next(0, 5);
            switch (Common_Variables.difficulty)
            {
                case "n":
                    if (event_probability == 1 || event_probability == 2)
                    {
                        switch (SpecialEventList[event_selected])
                        {
                            case "SmallText":
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 12, FontStyle.Regular);
                                    AnsHeader1.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    AnsHeader2.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    AnsHeader3.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    AnsHeader4.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    break;
                                }
                                AnsHeader1.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                AnsHeader2.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                AnsHeader3.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                AnsHeader4.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                QuestionHeader.Font = new Font("Lucida Sans", 12, FontStyle.Bold);
                                break;
                            case "LargeText":
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 84, FontStyle.Regular);
                                    AnsHeader1.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    AnsHeader2.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    AnsHeader3.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    AnsHeader4.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    break;
                                }
                                AnsHeader1.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                AnsHeader2.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                AnsHeader3.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                AnsHeader4.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                QuestionHeader.Font = new Font("Lucida Sans", 84, FontStyle.Bold);
                                break;
                            case "TimedQuestion":
                                TimerLabel.Show();
                                TimedQuestion();
                                break;
                            case "ReverseText": //Reverses all text in QuestionHeader and the AnsArrays
                                char[] TextArray = AnsHeader1.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                string Reversed = new string(TextArray);
                                AnsHeader1.Text = Reversed;
                                TextArray = AnsHeader2.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                AnsHeader2.Text = Reversed;
                                TextArray = AnsHeader3.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                AnsHeader3.Text = Reversed;
                                TextArray = AnsHeader4.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                AnsHeader4.Text = Reversed;
                                TextArray = QuestionHeader.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                QuestionHeader.Text = Reversed;
                                break;
                            case "Wingdings": //Sets QuestionHeaders font to Wingdings
                                QuestionHeader.Font = new Font("Wingdings", (float)Convert.ToDecimal(questions.Split[1]), FontStyle.Bold);
                                break;
                        }
                    }
                    break;
                case "h":
                    if (event_probability == 1 || event_probability == 2 || event_probability == 3)
                    {
                        switch (SpecialEventList[event_selected])
                        {
                            case "SmallText":
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 12, FontStyle.Regular);
                                    AnsHeader1.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    AnsHeader2.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    AnsHeader3.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    AnsHeader4.Font = new Font("Comic Sans MS", 8, FontStyle.Regular);
                                    break;
                                }
                                AnsHeader1.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                AnsHeader2.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                AnsHeader3.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                AnsHeader4.Font = new Font("Lucida Sans", 8, FontStyle.Bold);
                                QuestionHeader.Font = new Font("Lucida Sans", 12, FontStyle.Bold);
                                break;
                            case "LargeText":
                                if (Common_Variables.dyslexia)
                                {
                                    QuestionHeader.Font = new Font("Comic Sans MS", 84, FontStyle.Regular);
                                    AnsHeader1.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    AnsHeader2.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    AnsHeader3.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    AnsHeader4.Font = new Font("Comic Sans MS", 64, FontStyle.Regular);
                                    break;
                                }
                                AnsHeader1.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                AnsHeader2.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                AnsHeader3.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                AnsHeader4.Font = new Font("Lucida Sans", 64, FontStyle.Bold);
                                QuestionHeader.Font = new Font("Lucida Sans", 84, FontStyle.Bold);
                                break;
                            case "TimedQuestion":
                                TimerLabel.Show();
                                TimedQuestion();
                                break;
                            case "ReverseText":
                                char[] TextArray = AnsHeader1.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                string Reversed = new string(TextArray);
                                AnsHeader1.Text = Reversed;
                                TextArray = AnsHeader2.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                AnsHeader2.Text = Reversed;
                                TextArray = AnsHeader3.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                AnsHeader3.Text = Reversed;
                                TextArray = AnsHeader4.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                AnsHeader4.Text = Reversed;
                                TextArray = QuestionHeader.Text.ToCharArray();
                                Array.Reverse(TextArray);
                                Reversed = new string(TextArray);
                                QuestionHeader.Text = Reversed;
                                break;
                            case "Wingdings":
                                QuestionHeader.Font = new Font("Wingdings", (float)Convert.ToDecimal(questions.Split[1]), FontStyle.Bold);
                                break;
                        }
                    }
                    break;
            }

        }

        //Sets valuse of TimeLeft and enables the timer
        public void TimedQuestion()
        {
            if (Common_Variables.difficulty == "n")
            {
                TimeLeft = 15;
            }
            else
            {
                TimeLeft = 10;
            }
            timer1.Enabled = true;
        }

        //Decreases value of TimeLeft by 1 and runs same code as AnsCheck (bar the no answer detection) if TimeLeftis lowerer than 1
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLeft--;
            TimerLabel.Text = TimeLeft.ToString();

            if (TimeLeft <= 0)
            {
                if (this.Visible == true)
                {
                    TimerLabel.Hide();
                    if ((string)pictureBox5.Tag + (string)pictureBox6.Tag + (string)pictureBox7.Tag + (string)pictureBox8.Tag == answer)
                    {
                        Common_Variables.DropLifeCorrect += 1;
                        Common_Variables.LifetimeCorrect += 1;
                        switch (Common_Variables.difficulty)
                        {
                            case "e":
                                Common_Variables.score += 0.5;
                                if (Common_Variables.muted == false)
                                {
                                    player.Stream = Properties.Resources.ding;
                                    player.Play();
                                }
                                break;
                            case "n":
                                Common_Variables.score += 0.75;
                                if (Common_Variables.muted == false)
                                {
                                    player.Stream = Properties.Resources.ding;
                                    player.Play();
                                }
                                break;
                            case "h":
                                Common_Variables.score += 1;
                                if (Common_Variables.muted == false)
                                {
                                    player.Stream = Properties.Resources.ding;
                                    player.Play();
                                }
                                break;
                        }

                        if (Common_Variables.q_number % 5 == 0 || Common_Variables.q_number > 19)
                        {
                            if (NextSection != null)
                            {
                                Common_Variables.q_number = Common_Variables.q_number + 1;
                                NextSection.Invoke(this, EventArgs.Empty);
                                this.Close();
                                return;
                            }
                        }
                        Common_Variables.q_number = Common_Variables.q_number + 1;

                        if (UpdateQNum != null)
                        {
                            UpdateQNum.Invoke(this, EventArgs.Empty);
                        }
                        NewQuestion(Common_Variables.path);
                    }
                    else
                    {
                        Common_Variables.DropLifeIncorrect += 1;
                        Common_Variables.LifetimeIncorrect += 1;

                        if (!Common_Variables.muted)
                        {
                            player.Stream = Properties.Resources.wrong;
                            player.Play();
                        }

                        if (Common_Variables.q_number % 5 == 0 || Common_Variables.q_number > 19)
                        {
                            if (NextSection != null)
                            {
                                Common_Variables.q_number = Common_Variables.q_number + 1;
                                NextSection.Invoke(this, EventArgs.Empty);
                                this.Close();
                                return;
                            }
                        }
                        Common_Variables.q_number = Common_Variables.q_number + 1;

                        if (UpdateQNum != null)
                        {
                            UpdateQNum.Invoke(this, EventArgs.Empty);
                        }
                        NewQuestion(Common_Variables.path);
                    }
                }
            }
        }

        //Plays a wav file that contains a text to speech readout of the question, if one exists
        private async void ReadQuestion()
        {
            if (!Common_Variables.muted)
            {
                await Task.Delay(1000);
                if (File.Exists(Common_Variables.path + @"\assets\audio\drop-tts\" + questions.Split[2] + ".wav"))
                {
                    SoundPlayer read = new SoundPlayer(Common_Variables.path + @"\assets\audio\drop-tts\" + questions.Split[2] + ".wav");
                    read.Play();
                }
            }
        }
    }
}