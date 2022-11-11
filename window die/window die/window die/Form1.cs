using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace window_die
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Random x = new Random();
            Random y = new Random();
            
            Location = new Point(x.Next(-200,200)+ Location.X, y.Next(-200, 200) + Location.Y);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
