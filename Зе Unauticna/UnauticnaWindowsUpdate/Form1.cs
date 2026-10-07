using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnauticnaWindowsUpdate
{
    public partial class Form1 : Form
    {
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
        void WindowGet(string winmasive, int x, int y, int sx, int sy, string flags)
        {
            IntPtr unityWindow =
            FindWindow(null, "Unauticna");
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
            Vector4 item = GetWindowPos("Unauticna");
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
                 (int)item.z-12,
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
        public Form1()
        {
            InitializeComponent();
        }
        string olditem3;
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("Unauticna.txt");
            foreach (string item in lines)
            {
                Vector4 item2 = GetWindowPos("Unauticna");
                string item3 = "" + item2.x+ item2.y;
                i++;
                
                    string[] str = item.Split(',');
                    WindowGet(str[0].Replace(",",""),//name
                        int.Parse(str[1].Replace(",", "")),//xpos
                        int.Parse(str[2].Replace(",", "")),//ypos
                        int.Parse(str[3].Replace(",", "")), //xscale
                        int.Parse(str[4].Replace(",", "")),//yscale
                        str[5].Replace(",", ""));//setings
                 
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
