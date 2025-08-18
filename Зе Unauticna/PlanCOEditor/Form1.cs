using System;
using System.Runtime;
using System.Runtime;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Web.UI.MobileControls.Adapters;
using MathNet.Numerics;
using System.Security.Claims;

namespace PlanCOEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PrototipCO_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            string plan = "";
            for (int i =0;i< int.Parse(textBox7.Text);i++)
            {
                plan += "prot." + PrototipCO.Text;  plan += "/";
                plan += "name." + NameCO.Text + ImportCommandName(RuleList.Text, i); plan += "/";
                plan += "model." + Model.Text; plan += "/";
                plan += "cr." + (float.Parse(textBox1.Text) + ImportCommandRed(RuleList.Text, i) + ImportCommandHueR(RuleList.Text, i)); plan += "/";
                plan += "cg." + (float.Parse(textBox2.Text) + ImportCommandGreen(RuleList.Text, i) + ImportCommandHueG(RuleList.Text, i)); plan += "/";
                plan += "cb." + (float.Parse(textBox3.Text) + ImportCommandBlue(RuleList.Text, i) + ImportCommandHueB(RuleList.Text, i)); plan += "/";
                plan += "x." + (float.Parse(textBox6.Text) + ImportCommandSX(RuleList.Text, i) + ImportCommandRSX(RuleList.Text, i)); plan += "/";
                plan += "y." + (float.Parse(textBox5.Text) + ImportCommandSY(RuleList.Text, i) + ImportCommandRSY(RuleList.Text, i)); plan += "/";
                plan += "z." + (float.Parse(textBox4.Text) + ImportCommandSZ(RuleList.Text, i) + ImportCommandRSZ(RuleList.Text, i)); plan += "/";
                
                //endrule
                plan += "\"";
            }
            textBox8.Text = plan;
            VarSave.SetString("CO.gc",plan,SaveType.computer);
        }
        string ImportCommandName(string ComandsText, int num)
        {
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[0].Split('.');
            if (keys[1].Replace("\n", "")[0] == "1"[0]) return num.ToString();
            else
            {
                return "[" + keys[1] + "]" + (keys[1].Replace("\n", "") == "1").ToString();
            }
        }
        float ImportCommandRed(string ComandsText, int num)
        {
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[1].Split('.');
            return float.Parse(keys[1]) * num;
        }
        float ImportCommandGreen(string ComandsText, int num)
        {
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[2].Split('.');
            return float.Parse(keys[1]) * num;

        }
        float ImportCommandBlue(string ComandsText, int num)
        {
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[3].Split('.');
            return float.Parse(keys[1]) * num;
        }
        float ImportCommandSX(string ComandsText, int num)
        {
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[4].Split('.');
            return float.Parse(keys[1]) * num;
        }
        float ImportCommandSY(string ComandsText, int num)
        {
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[5].Split('.');
            return float.Parse(keys[1]) * num;

        }
        float ImportCommandSZ(string ComandsText, int num)
        {
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[6].Split('.');
            return float.Parse(keys[1]) * num;
        }
        float ImportCommandRSX(string ComandsText, int num)
        {
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[7].Split('.');
            Random rand = new Random(num);
            float a = (float)rand.Next((int)(float.Parse(keys[1]) * 1000), (int)(float.Parse(keys[2]) * 1000));
            a *= 0.001f;
            return a;
        }
        float ImportCommandRSY(string ComandsText, int num)
        {
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[8].Split('.');
            Random rand = new Random(num);
            float a = (float)rand.Next((int)(float.Parse(keys[1]) * 1000), (int)(float.Parse(keys[2])*1000));
            a *= 0.001f;
            return a;

        }

        float ImportCommandRSZ(string ComandsText, int num)
        {
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[9].Split('.');
            Random rand = new Random(num);
            float a = (float)rand.Next((int)(float.Parse(keys[1]) * 1000), (int)(float.Parse(keys[2]) * 1000));
            a *= 0.001f;
            return a;
        }
        float ImportCommandHueR(string ComandsText, int num)
        {
            Color redShade = Color.FromArgb(255, 255, 0, 0);
            redShade.GetHue();
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[10].Split('.');
            return (float)FromHsl((double)(num) * (float.Parse(keys[1])), 1d, 0.5d).R / 256f;
        }
        float ImportCommandHueG(string ComandsText, int num)
        {
            Color redShade = Color.FromArgb(255, 255, 0, 0);
            redShade.GetHue();
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[10].Split('.');
            return (float)FromHsl((double)(num) * (float.Parse(keys[1])), 1d, 0.5d).G / 256f;
        }
        float ImportCommandHueB(string ComandsText, int num)
        {
            Color redShade = Color.FromArgb(255, 255, 0, 0);
            redShade.GetHue();
            string[] comands = ComandsText.Split('\n');
            string[] keys = comands[10].Split('.');
            return (float)FromHsl((double)(num) * (float.Parse(keys[1])), 1d, 0.5d).B / 256f;
        }


        Color FromHsl(double h, double s, double l)
        {
            // Ensure values are within valid ranges
            h = h % 360; // Wrap hue around 360 degrees
            if (h < 0) h += 360;
            s = math.Clamp(s, 0.0, 1.0);
            l = math.Clamp(l, 0.0, 1.0);

            if (s == 0)
            {
                // Achromatic (gray scale)
                int gray = (int)(l * 255.0);
                return Color.FromArgb(gray, gray, gray);
            }

            double q = l < 0.5 ? l * (1.0 + s) : (l + s) - (l * s);
            double p = 2.0 * l - q;

            double red = HueToRgb(p, q, h + 120.0);
            double green = HueToRgb(p, q, h);
            double blue = HueToRgb(p, q, h - 120.0);

            return Color.FromArgb((int)(red * 255.0), (int)(green * 255.0), (int)(blue * 255.0));
        }
        private static double HueToRgb(double p, double q, double t)
        {
            if (t < 0) t += 360;
            if (t > 360) t -= 360;

            if (t < 60) return p + (q - p) * t / 60;
            if (t < 180) return q;
            if (t < 240) return p + (q - p) * (240 - t) / 60;
            return p;
        }

    }
    static public class math
    {
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
    }
    
}
