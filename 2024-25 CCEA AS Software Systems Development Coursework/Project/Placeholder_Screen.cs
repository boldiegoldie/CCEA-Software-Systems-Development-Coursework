using System;
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
    public partial class Placeholder_Screen : Form
    {
        public Placeholder_Screen()
        {
            InitializeComponent();
        }

        private void Placeholder_Load(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.Stream = _2024_25_CCEA_AS_Software_Systems_Development_Coursework.Properties.Resources.minecraft;
            player.Play();
        }
    }
}