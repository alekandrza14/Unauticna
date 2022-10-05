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
            label1.Text = "не работает";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            System.Diagnostics.Process.Start(Application.StartupPath + "/Application/Unauticna.exe");
            Application.Exit();
        }

        
    }
}
