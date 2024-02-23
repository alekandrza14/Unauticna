using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace StrangeRadar
{
    public partial class Form1 : Form
    {
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
        RectangleF[] f;
        Specilpositiuon vectors = new Specilpositiuon();

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
         //   e.Graphics.Clear(Color.Black);
           DirectoryInfo dif = new DirectoryInfo("C:/data/t");
            FileInfo[] fi = dif.GetFiles();
            Specilpositiuon vectors = new Specilpositiuon();
            for (int i = 0; i < fi.Length; i++)
            {
                if (VarSave.ExistenceVar("t/"+fi[i].Name, SaveType.computer))
                {

                 string s  = VarSave.GetString("t/" + fi[i].Name, SaveType.computer);
                    vectors.pos.Add(new Vector2(float.Parse(s.Split()[0]), float.Parse(s.Split()[1])));

                }
            }
                if (vectors != null) { f = new RectangleF[vectors.pos.Count];
                // f = new RectangleF[2];
                for (int i = 0; i < f.Length; i++)
                {
                    //vectors.pos[i].x
                    f[i] = new RectangleF((600 / 2) - 10 - vectors.pos[i].x, (600 / 2) - 10 - vectors.pos[i].y, 20, 20);
                    e.Graphics.DrawEllipse(Pens.Green, f[i]);
                }
                RectangleF f1 = new RectangleF((600 / 2) - 5, (600 / 2) - 5, 10, 10);
                e.Graphics.DrawEllipse(Pens.Green, f1);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }



    public class Vector2
    {
       public float x, y;
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Specilpositiuon
    {
        public List<Vector2> pos = new  List<Vector2>();
    }
   
    
}
