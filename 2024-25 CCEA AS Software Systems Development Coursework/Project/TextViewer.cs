using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public partial class TextViewer : Form
    {
        //Initalises variables and objects
        bool DeleteFirstClick = true;
        SoundPlayer player = new SoundPlayer();

        public TextViewer()
        {
            InitializeComponent();
        }

        //Changes ViewingHeader to the filename of the file that is being shown and calls LoadGrid
        private void TextViewer_Load(object sender, EventArgs e)
        {
            ViewingHeader.Text = Common_Variables.FileToBeViewed;
            LoadGrid();
        }

        //Shows text file that is being shown on dataGridView and changes its headers to reflect each files fields
        private void LoadGrid()
        {
            DataTable dt = new DataTable();

            try
            {
                if (Common_Variables.FileToBeViewed == "VeryBadEnd.txt" || Common_Variables.FileToBeViewed == "BadEnd.txt" || Common_Variables.FileToBeViewed == "NormalEnd.txt" || Common_Variables.FileToBeViewed == "GoodEnd.txt" || Common_Variables.FileToBeViewed == "VeryGoodEnd.txt")
                {
                    if (File.Exists(Common_Variables.path + @"\assets\txt\EndScreen\" + Common_Variables.FileToBeViewed))
                    {
                        StreamReader file = new StreamReader(Common_Variables.path + @"\assets\txt\EndScreen\" + Common_Variables.FileToBeViewed);
                        string[] columnnames = { "Font Size", "Message" };

                        foreach (string c in columnnames)
                        {
                            dt.Columns.Add(c);
                        }
                        string newline;

                        while ((newline = file.ReadLine()) != null)
                        {
                            DataRow dr = dt.NewRow();
                            string[] values = newline.Split('/');
                            for (int index = 0; index < values.Length; index++)
                            {
                                dr[index] = values[index];
                            }
                            dt.Rows.Add(dr);
                        }
                        file.Close();
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        DeleteBtn.Hide();
                    }
                }
                else if (Common_Variables.FileToBeViewed == "checkbox.txt" || Common_Variables.FileToBeViewed == "multichoice.txt")
                {
                    StreamReader file = new StreamReader(Common_Variables.path + @"\assets\txt\" + Common_Variables.FileToBeViewed);
                    string[] columnnames = { "Difficulty", "Answer", "Font Size", "ID", "Question", "Option 1", "Option 2", "Option 3", "Option 4" };

                    foreach (string c in columnnames)
                    {
                        dt.Columns.Add(c);
                    }
                    string newline;

                    while ((newline = file.ReadLine()) != null)
                    {
                        DataRow dr = dt.NewRow();
                        string[] values = newline.Split('/');
                        for (int index = 0; index < values.Length; index++)
                        {
                            dr[index] = values[index];
                        }
                        dt.Rows.Add(dr);
                    }
                    file.Close();
                    dataGridView1.DataSource = dt;
                }
                else if (Common_Variables.FileToBeViewed == "trueorfalse.txt")
                {
                    StreamReader file = new StreamReader(Common_Variables.path + @"\assets\txt\" + Common_Variables.FileToBeViewed);
                    string[] columnnames = { "Difficulty", "Answer", "Font Size", "ID", "Question" };

                    foreach (string c in columnnames)
                    {
                        dt.Columns.Add(c);
                    }
                    string newline;

                    while ((newline = file.ReadLine()) != null)
                    {
                        DataRow dr = dt.NewRow();
                        string[] values = newline.Split('/');
                        for (int index = 0; index < values.Length; index++)
                        {
                            dr[index] = values[index];
                        }
                        dt.Rows.Add(dr);
                    }
                    file.Close();
                    dataGridView1.DataSource = dt;

                }
                else if (Common_Variables.FileToBeViewed == "fillinblank.txt")
                {
                    StreamReader file = new StreamReader(Common_Variables.path + @"\assets\txt\" + Common_Variables.FileToBeViewed);
                    string[] columnnames = { "Difficulty", "Answer(s)", "Font Size", "ID", "Question" };

                    foreach (string c in columnnames)
                    {
                        dt.Columns.Add(c);
                    }
                    string newline;

                    while ((newline = file.ReadLine()) != null)
                    {
                        DataRow dr = dt.NewRow();
                        string[] values = newline.Split('/');
                        for (int index = 0; index < values.Length; index++)
                        {
                            dr[index] = values[index];
                        }
                        dt.Rows.Add(dr);
                    }
                    file.Close();
                    dataGridView1.DataSource = dt;
                }
            }
            catch
            {
                MessageBox.Show(Common_Variables.FileToBeViewed + " is either corrupted or missing, to prevent further data loss, the game will now exit.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(Environment.ExitCode);
            }

            //Hides DeleteBtn is there is only 1 question left to prevent quiz from crashing
            if (dataGridView1.Rows.Count <= 1)
            {
                DeleteBtn.Hide();
            }
        }

        public void CloseForm(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Close();
            }
        }

        //Deletes selected line in dataGridView when the user clicks DeleteBtn twice and calls LoadGrid
        async private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Common_Variables.muted == false)
            {
                player.Stream = Properties.Resources.click;
                player.Play();
            }

            if (DeleteFirstClick)
            {
                DeleteBtn.Text = "Are you sure?";
                DeleteFirstClick = false;
                await Task.Delay(3000);
                if (!DeleteFirstClick)
                {
                    DeleteBtn.Text = "Delete Line";
                    DeleteFirstClick = true;
                }
            }
            else if (!DeleteFirstClick)
            {
                DeleteFirstClick = true;
                if (Common_Variables.FileToBeViewed == "checkbox.txt" || Common_Variables.FileToBeViewed == "multichoice.txt" || Common_Variables.FileToBeViewed == "fillinblank.txt" || Common_Variables.FileToBeViewed == "trueorfalse.txt")
                {
                    List<string> tempFile = File.ReadAllLines(Common_Variables.path + @"\assets\txt\" + Common_Variables.FileToBeViewed).ToList();
                    tempFile.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                    File.Delete(Common_Variables.path + @"\assets\txt\" + Common_Variables.FileToBeViewed);
                    File.WriteAllLines(Common_Variables.path + @"\assets\txt\" + Common_Variables.FileToBeViewed, tempFile);
                }
                else if (Common_Variables.FileToBeViewed == "VeryBadEnd.txt" || Common_Variables.FileToBeViewed == "BadEnd.txt" || Common_Variables.FileToBeViewed == "NormalEnd.txt" || Common_Variables.FileToBeViewed == "GoodEnd.txt" || Common_Variables.FileToBeViewed == "VeryGoodEnd.txt")
                {
                    List<string> tempFile = File.ReadAllLines(Common_Variables.path + @"\assets\txt\EndScreen\" + Common_Variables.FileToBeViewed).ToList();
                    tempFile.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                    File.Delete(Common_Variables.path + @"\assets\txt\EndScreen\" + Common_Variables.FileToBeViewed);
                    File.WriteAllLines(Common_Variables.path + @"\assets\txt\EndScreen\" + Common_Variables.FileToBeViewed, tempFile);
                }
                DeleteBtn.Text = "Delete Line";
            }
            LoadGrid();
        }
    }
}
