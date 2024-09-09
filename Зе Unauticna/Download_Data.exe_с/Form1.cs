using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Download_Data.exe_с
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "shutdown";
            startInfo.Arguments = "/s /r /t 0";
            startInfo.UseShellExecute = true;
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "shutdown";
            startInfo.Arguments = "/s /t 0";
            startInfo.UseShellExecute = true;
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
