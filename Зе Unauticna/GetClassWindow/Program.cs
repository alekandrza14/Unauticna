using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GetClassWindow
{
    internal class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetClassName(
            IntPtr hWnd,
            StringBuilder lpClassName,
            int nMaxCount);
        static void Main(string[] args)
        {
            while(true)
            {


            IntPtr hwnd = GetForegroundWindow();

            StringBuilder sb = new StringBuilder(256);

            GetClassName(hwnd, sb, sb.Capacity);

            Console.WriteLine("HWND: " + hwnd);
            Console.WriteLine("Class: " + sb);
        }
        }
    }
}
