using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace UnauticnaProgramOptionsN4
{
    public partial class Form1 : Form
    {
        private readonly string LauncherPath = Application.StartupPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RunExe(string relativeExePath, string relativeWorkingDirectory = "")
        {
            string exePath = Path.Combine(LauncherPath, relativeExePath);

            string workingDirectory = string.IsNullOrEmpty(relativeWorkingDirectory)
                ? LauncherPath
                : Path.Combine(LauncherPath, relativeWorkingDirectory);

            if (!File.Exists(exePath))
            {
                MessageBox.Show(
                    "Файл не найден:\n" + exePath,
                    "Unauticna",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    WorkingDirectory = workingDirectory,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка запуска:\n" + ex.Message,
                    "Unauticna",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void RunJar(string relativeJarPath, string relativeWorkingDirectory = "")
        {
            string jarPath = Path.Combine(LauncherPath, relativeJarPath);

            string workingDirectory = string.IsNullOrEmpty(relativeWorkingDirectory)
                ? LauncherPath
                : Path.Combine(LauncherPath, relativeWorkingDirectory);

            if (!File.Exists(jarPath))
            {
                MessageBox.Show(
                    "JAR не найден:\n" + jarPath,
                    "Unauticna",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "java",
                    Arguments = "-jar \"" + jarPath + "\"",
                    WorkingDirectory = workingDirectory,
                    UseShellExecute = false
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось запустить Java/JAR:\n" + ex.Message,
                    "Unauticna",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // UCreator 1
        private void button1_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\UnityDemo\UCreator_\UCreator.exe",
                @"windows\UnityDemo\UCreator_"
            );
        }

        // Unauticna Visual Studio 2
        private void button2_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\IDE Visual Studio\Unauticna Visual Studio.exe",
                 @"windows\IDE Visual Studio"
            );
        }

        // My Engine 3
        private void button3_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\MyEngine\MyHub.exe",
                @"windows\MyEngine"
            );
        }

        // Anti-ussr-cursor 4
        private void button4_Click(object sender, EventArgs e)
        {
            RunJar(
                @"res\scripts\MouseMove.jar"
            );
        }

        // HDRP Module 5
        private void button5_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\UnityDemo\hdrp\HDRP.exe"
            );
        }

        // Ucna Paint :: Save Format 64 bit 6
        private void button6_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\UnityDemo\PaintJson\ucnaPaint.exe",
                @"windows\UnityDemo\PaintJson"
            );
        }

        // Hyper Realyze 7
        private void button7_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\UnityDemo\Hyper-realize\Hyper-Realize.exe"
            );
        }

        // Plan CO Editor 8
        private void button8_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\PlanCOEditor.exe"
            );
        }

        // Unauticna E.G.O.5 9
        private void button9_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\UnityDemo\Unauticna E.G.O.S.exe"
            );
        }

        // ViewMiner 10
        private void button10_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\OnlineTools\BotViewer\ViewMiner.exe"
            );
        }

        // FastCheatMenu 11
        private void button11_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\FastCheatMenu.exe"
            );
        }

        // GetClassWindow 12
        private void button12_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\GetClassWindow.exe"
            );
        }

        // VoicePlayer 13
        private void button13_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\VoicePlayer.exe"
            );
        }

        // StrangeRadar 14
        private void button14_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\StrangeRadar.exe"
            );
        }

        // SolarSystem 15
        private void button15_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\SolarSystem.exe"
            );
        }

        // MinerRubles 16
        private void button16_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\MinerRubles.exe"
            );
        }
        // YG++Module 17
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                // Папка, где лежит yandex++Intaler.exe
                string modulePath = Path.Combine(
                    Application.StartupPath,
                    "windows",
                    "YG++Module"
                );

                // Папка установленных игр
                string gamesPath = Path.Combine(
                    Application.StartupPath,
                    "windows",
                    "YandexGames"
                );

                // Если папки игр ещё нет — создаём
                Directory.CreateDirectory(gamesPath);

                // -------------------------------------------------
                // 1. Проводник с поиском установщика
                // -------------------------------------------------

                string encodedModulePath =
                    Uri.EscapeDataString(modulePath);

                string searchUri =
                    "search-ms:" +
                    "displayname=" +
                    Uri.EscapeDataString(
                        "Установщик Yandex++"
                    ) +
                    "&crumb=" +
                    Uri.EscapeDataString(
                        "System.Generic.String:exe"
                    ) +
                    "&crumb=location:" +
                    encodedModulePath;

                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = searchUri,
                        UseShellExecute = true
                    }
                );

                // -------------------------------------------------
                // 2. Проводник с установленными играми
                // -------------------------------------------------

                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = "explorer.exe",
                        Arguments =
                            "\"" + gamesPath + "\"",
                        UseShellExecute = true
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось открыть Yandex Games:\n\n" +
                    ex.Message,
                    "Unauticna",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Unauticna Console 18
        private void button18_Click(object sender, EventArgs e)
        {
            RunExe(
                @"windows\Unauticna#Console.exe",
                @"windows"
            );
        }
    }
}