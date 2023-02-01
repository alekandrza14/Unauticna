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
using UnauticnaLauncher.Properties;

namespace Зе_Unauticna
{
    public partial class Form1 : Form
    {
        Graphics g;
        Graphics g1;
        int attack;
        bool myed;
        Point oldcursor= new Point(2,2);
        Point newcursor = new Point(2, 2);
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserMouse |
                ControlStyles.FixedHeight |
                ControlStyles.FixedWidth, true);
            UpdateStyles();
          int s = new Random().Next(0, 6);

            if (s == 0)
            {
                BackgroundImage = Resources.arua_and_gaster;
            }
            if (s == 1)
            {
                BackgroundImage = Resources.arua_neo;
            }
            if (s == 2)
            {
                BackgroundImage = Resources.Hyper_agel___Enero;
            }
            if (s == 3)
            {
                BackgroundImage = Resources.dowfgnload;
            }
            if (s == 4)
            {
                BackgroundImage = Resources.hollow_knight_ввиде_террата_из_mu_unauticna;
            }
            if (s == 5)
            {
                BackgroundImage = Resources.main_paras_;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            newcursor = e.Location;
            g1 = CreateGraphics();
            switch (myed)
            {
                case true:
                    g1.DrawLine(Pens.Red, oldcursor, newcursor);
                    break;
                case false:
                    g1.DrawLine(Pens.Green, oldcursor, newcursor);
                    break;
            }
            myed = !myed;
            oldcursor = newcursor;
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "/windows/Settings.exe");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            System.Diagnostics.Process.Start(Application.StartupPath + "/Application/Unauticna.exe");
            Application.Exit();
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            OnBackgroundImageChanged(new EventArgs());
            int s = new Random().Next(0, 6);

            if (s == 0)
            {
                BackgroundImage = Resources.arua_and_gaster;
            }
            if (s == 1)
            {
                BackgroundImage = Resources.arua_neo;
            }
            if (s == 2)
            {
                BackgroundImage = Resources.Hyper_agel___Enero;
            }
            if (s == 3)
            {
                BackgroundImage = Resources.dowfgnload;
            }
            if (s == 4)
            {
                BackgroundImage = Resources.hollow_knight_ввиде_террата_из_mu_unauticna;
            }
            if (s == 5)
            {
                BackgroundImage = Resources.main_paras_;
            }
            OnBackgroundImageChanged( new EventArgs());
        }

        private void button4_Click(object sender, EventArgs e)
        {
           DialogResult g = folderBrowserDialog1.ShowDialog();
            if (g == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(folderBrowserDialog1.SelectedPath + "/Unauticna.exe");
                Application.Exit();
            }
        }
    }
}
