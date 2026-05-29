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
using IWshRuntimeLibrary;
using Microsoft.Win32;

namespace Dinamic_Ico_manager
{
    public partial class Form1 : Form
    {
        Random rans;
        public Form1()
        {
            
            InitializeComponent(); 
            rans = new Random();
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            // Добавить значение в реестр для запуска напару с ОС
            rkApp.SetValue("Dinamic Ico manager", Application.ExecutablePath.ToString());
            RegistryKey rkApp2 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            // Добавить значение в реестр для запуска напару с ОС
            rkApp2.SetValue("Unauticna E.G.O.S", Application.StartupPath + @"\UnityDemo\Unauticna E.G.O.S.exe");
            RegistryKey rkApp3 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            rkApp3.SetValue("Auto", Application.StartupPath + @"\UnityDemo\Auto.exe");
        }

        private void Form1_Click(object sender, EventArgs e)
        {
          //  CreateShortcut(Application.StartupPath+@"/Launcher Unauticna.exe", Application.StartupPath + @"/"+ rans.Next(1,7) + ".ico", @"C:\Users\User\Desktop\Launcher Unauticna.lnk", "Блокнот");
        }
        public void CreateShortcut(string targetPath, string IconPath, string shortcutPath, string description = "")
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.IconLocation = IconPath;
            shortcut.TargetPath = targetPath;
            shortcut.RelativePath = targetPath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(Application.StartupPath);
            shortcut.Description = description;
            shortcut.Save();
        }
        public void CreateShortcut2(string targetPath, string IconPath, string shortcutPath, string description = "")
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.IconLocation = IconPath;
            shortcut.TargetPath = targetPath;
            shortcut.RelativePath = targetPath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.Description = description;
            shortcut.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Application.StartupPath + @"\пути.txt")) 
            {
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                CreateShortcut(Path.GetDirectoryName(Application.StartupPath) + @"\Launcher Unauticna.exe", Application.StartupPath + @"\" + rans.Next(1, 7) + ".ico", Path.GetDirectoryName(Application.StartupPath) + @"/Launcher Unauticna.lnk", "Блокнот");
                CreateShortcut(Path.GetDirectoryName(Application.StartupPath) + @"\Launcher Unauticna.exe", Application.StartupPath + @"\" + rans.Next(1, 7) + ".ico", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/Launcher Unauticna.lnk", "Блокнот");
                CreateShortcut2(Application.StartupPath + @"\UnityDemo\Unauticna E.G.O.S.exe", Application.StartupPath + @"\" + rans.Next(1, 7) + ".ico", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/Unauticna E.G.O.S.lnk", "Блокнот");
                CreateShortcut2(Application.StartupPath + @"\UnityDemo\Auto.exe", Application.StartupPath + @"\" + rans.Next(1, 7) + ".ico", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/Auto.lnk", "Блокнот");

                string[] paths = System.IO.File.ReadAllText(Application.StartupPath + @"\пути.txt").Split(',');
                foreach (string obj in paths)
                {
                    CreateShortcut2(Application.StartupPath + @"\UnityDemo\Unauticna E.G.O.S.exe", Application.StartupPath + @"\" + rans.Next(1, 7) + ".ico", obj + @"/Unauticna E.G.O.S.lnk", "Блокнот");

                    CreateShortcut2(Application.StartupPath + @"\UnityDemo\Auto.exe", Application.StartupPath + @"\" + rans.Next(1, 7) + ".ico", obj + @"/Auto.lnk", "Блокнот");

                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
