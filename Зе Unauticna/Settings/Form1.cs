using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Settings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Application.StartupPath) + "/debug");
            }
            if (checkBox1.Checked == false)
            {
                Directory.Delete(Path.GetDirectoryName(Application.StartupPath) + "/debug");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          if (Directory.Exists(Path.GetDirectoryName(Application.StartupPath) + "/unsave"))  Directory.Delete(Path.GetDirectoryName(Application.StartupPath) + "/unsave",true);
            if (Directory.Exists(Path.GetDirectoryName(Application.StartupPath) + "/munsave")) Directory.Delete(Path.GetDirectoryName(Application.StartupPath) + "/munsave", true);
            if (Directory.Exists(Path.GetDirectoryName(Application.StartupPath) + "/unsavet")) Directory.Delete(Path.GetDirectoryName(Application.StartupPath) + "/unsavet", true);
            if (Directory.Exists(Path.GetDirectoryName(Application.StartupPath) + "/world")) Directory.Delete(Path.GetDirectoryName(Application.StartupPath) + "/world", true);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {

            System.Diagnostics.Process.Start(Application.StartupPath + "/windows/UnauticnaConsole.exe");
        }
    }
}
