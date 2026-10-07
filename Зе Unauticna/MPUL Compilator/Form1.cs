using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPUL_Compilator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = Program.pach;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_SHOWWINDOW = 0x0040;
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(
    IntPtr hWnd,
    int nCmdShow
);
        private const int SW_SHOW = 5;
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(
        IntPtr hWndChild,
        IntPtr hWndNewParent
    );
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern bool SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string className, string windowName);

        public static void SetWindowPosition(int x, int y)
        {
            //yield return new WaitForEndOfFrame();
            //yield return new WaitForEndOfFrame();
            //   SetWindowPos(FindWindow(null, Application.productName), 0, x, y, 0, 0, 5);
            //  SetWindowPos(FindWindow(null, Application.productName), 0, x, y, 0, 0, 5);

        }
        void WindowGet(string winmasive, string itemwin, int x, int y, int sx, int sy, string flags)
        {
            IntPtr unityWindow =
            FindWindow(null, itemwin);
            if (unityWindow == IntPtr.Zero)
            {

                return;
            }

            IntPtr javaWindow =
            FindWindow(null, winmasive);
            if (javaWindow == IntPtr.Zero)
            {

                return;
            }
            //SetParent(javaWindow, unityWindow);
            ShowWindow(javaWindow, SW_SHOW);
            Vector4 item = GetWindowPos(itemwin);
            if (flags == "none")
            {


                SetWindowPos(
                javaWindow,
                -1,
                (int)item.x + x,
                (int)item.y + y,
                sx,
                sy,
                SWP_SHOWWINDOW

                );
            }
            if (flags == "wide")
            {


                SetWindowPos(
                javaWindow,
                -1,
                (int)item.x + x,
                (int)item.y + y,
                 (int)item.z - 12,
                sy,
                SWP_SHOWWINDOW

                );
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(
            IntPtr hWnd,
            out RECT lpRect
        );

        public static Vector4 GetWindowPos(string windowName)
        {
            IntPtr hwnd = FindWindow(null, windowName);

            if (hwnd == IntPtr.Zero)
                return Vector4.zero;

            RECT rect;

            if (!GetWindowRect(hwnd, out rect))
                return Vector4.zero;

            return new Vector4(
                rect.Left,
                rect.Top,
                rect.Right - rect.Left,
                rect.Bottom - rect.Top
            );
        }

        string olditem3;
        int i = 0;
     

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            int saso = 0;
            foreach (string item2 in Program._File)
            {
                if (!File.Exists(item2))
                    return;

                string[] lines = File.ReadAllLines(item2);

                foreach (string item in lines)
                {
                    if (string.IsNullOrWhiteSpace(item))
                        continue;

                    string[] str = item.Split(',');

                    if (str.Length < 6)
                        continue;

                    WindowGet(
                        str[0], Program._Window[saso],
                        int.Parse(str[1]),
                        int.Parse(str[2]),
                        int.Parse(str[3]),
                        int.Parse(str[4]),
                        str[5]
                    );
                }
                saso++;
            }
        }
    }
    public class Vector4
    {
        public float x, y, z, w;
        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public static Vector4 zero = new Vector4(0, 0, 0, 0);
    }
}


