using EO.WebEngine;
using System;
using System.IO;
using System.Windows.Forms;

namespace yandex__
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            EngineOptions.Default.RemoteDebugPort = 9222;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string webExeFile = null;

            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    webExeFile =
                        Path.GetFullPath(args[0]);
                }
            }

            Application.Run(
                new Form1(webExeFile)
            );
        }
    }
}