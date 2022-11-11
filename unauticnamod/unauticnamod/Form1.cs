using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace unauticnamod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory("C:/myMods");
        }
        float speed;

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:/myMods/sig1.sig", speed.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:/myMods/sig4.sig", speed.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:/myMods/sig3.sig", speed.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:/myMods/sig2.sig", speed.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:/myMods/sig6.sig", speed.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:/myMods/sig5.sig", speed.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:/myMods/sig7.sig", speed.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:/myMods/sig8.sig", speed.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            speed = trackBar1.Value;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:/myMods/give.sig", textBox1.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:/myMods/spawn.sig", textBox2.Text);
        }
    }
}
