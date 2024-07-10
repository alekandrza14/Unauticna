using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FastCheatMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Day(object sender, EventArgs e)
        {
            VarSave.SetBool("Day", !VarSave.GetBool("Day", SaveType.computer), SaveType.computer);
        }

        private void UnlockOmniscience(object sender, EventArgs e)
        {

            VarSave.SetBool("UnlockOmniscience", !VarSave.GetBool("UnlockOmniscience", SaveType.computer), SaveType.computer);
        }

        private void ClearEffect(object sender, EventArgs e)
        {

            VarSave.SetBool("ClearEffect", !VarSave.GetBool("ClearEffect", SaveType.computer), SaveType.computer);
        }

        private void iddqd(object sender, EventArgs e)
        {

            VarSave.SetBool("iddqd", !VarSave.GetBool("iddqd", SaveType.computer), SaveType.computer);
        }

        private void OrtoCam(object sender, EventArgs e)
        {

            VarSave.SetBool("OrtoCam", !VarSave.GetBool("OrtoCam", SaveType.computer), SaveType.computer);
        }

        private void Ranall(object sender, EventArgs e)
        {

            VarSave.SetBool("Ranall", !VarSave.GetBool("Ranall", SaveType.computer), SaveType.computer);
        }

        private void DataFolder(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "C:\\data");
        }
    }
}
