using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loaderAnyTubeVideo
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            button1.AllowDrop = true; InitializeComponent(); this.AllowDrop = true; 
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop); foreach (string file in files)
            {
                VarSave.SetString("uploadvideo.sing", file, SaveType.computer);
                Console.WriteLine(file); // Process each file path } 
            }
        }
        private void button1_DragEnter(object sender, DragEventArgs e) 
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None; 
        }

        private void button1_DragEnter_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }
    }
}
