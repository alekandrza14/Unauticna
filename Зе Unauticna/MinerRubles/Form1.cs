using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MinerRubles
{
    public partial class Form1 : Form
    {
        bool run_Mineing = false;
        public float rubles;
        public Form1()
        {
            InitializeComponent();
            rubles = VarSave.GetFloat("руб", SaveType.computer);
            label3.Text = rubles.ToString() + " рублей";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("Unauticna");
            if (processes.Length > 0)
            {
                run_Mineing = true;
                label2.Text = "запущен";
                label4.Text = "0.001 рубля в 1 скам";
            }
            else
            {
                run_Mineing = false;
                label2.Text = "не запущен";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            run_Mineing = true;
            label2.Text = "запущен";
            label4.Text = "0.001 рубля в 1 скам";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (run_Mineing == false)
            {
                Process[] processes = Process.GetProcessesByName("Unauticna");
                if (processes.Length > 0)
                {
                    run_Mineing = true;
                    label2.Text = "запущен";
                    label4.Text = "0.001 рубля в 1 скам";
                }
            }
            if (run_Mineing)
            {
                rubles += 0.001f;
                label3.Text = rubles.ToString() + " рублей";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string target = "https://alekandrza14.github.io/MinerSite/";

            System.Diagnostics.Process.Start(target);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VarSave.SetFloat("руб", rubles, SaveType.computer);
        }
    }
}
