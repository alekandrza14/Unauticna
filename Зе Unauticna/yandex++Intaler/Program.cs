using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace yandex__Intaler
{
    internal class Program
    {
        private const uint SHCNE_ASSOCCHANGED = 0x08000000;
        private const uint SHCNF_IDLIST = 0x0000;

        [DllImport("shell32.dll")]
        private static extern void SHChangeNotify(
            uint wEventId,
            uint uFlags,
            IntPtr dwItem1,
            IntPtr dwItem2
        );

        static int Main(string[] args)
        {
            Console.Title = "yandex++ Installer";

            try
            {
                string folder =
                    AppDomain.CurrentDomain.BaseDirectory;

                string browserPath =
                    Path.Combine(
                        folder,
                        "yandex++.exe"
                    );

                string dllPath =
                    Path.Combine(
                        folder,
                        "WebExeIconHandler.dll"
                    );

                Console.WriteLine("==================================");
                Console.WriteLine("       yandex++ Installer");
                Console.WriteLine("==================================");
                Console.WriteLine();

                // ==========================================
                // UNINSTALL
                // ==========================================

                if (args.Length > 0 &&
                    args[0].Equals(
                        "/uninstall",
                        StringComparison.OrdinalIgnoreCase))
                {
                    return Uninstall(dllPath);
                }

                // ==========================================
                // Проверяем файлы
                // ==========================================

                if (!File.Exists(browserPath))
                {
                    Console.WriteLine(
                        "[ERROR] yandex++.exe не найден:"
                    );

                    Console.WriteLine(browserPath);
                    Console.ReadKey();

                    return 1;
                }

                if (!File.Exists(dllPath))
                {
                    Console.WriteLine(
                        "[ERROR] WebExeIconHandler.dll не найден:"
                    );

                    Console.WriteLine(dllPath);
                    Console.ReadKey();

                    return 2;
                }

                Console.WriteLine(
                    "[1/3] Регистрация Icon Handler..."
                );

                // ==========================================
                // COM DLL
                // ==========================================

                int exitCode =
                    RunRegsvr32(
                        dllPath,
                        false
                    );

                if (exitCode != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "[ERROR] regsvr32 вернул код: " +
                        exitCode
                    );

                    Console.ReadKey();

                    return 3;
                }

                Console.WriteLine(
                    "[OK] WebExeIconHandler.dll зарегистрирована."
                );

                // ==========================================
                // Ассоциация .web_exe
                // ==========================================

                Console.WriteLine(
                    "[2/3] Настройка .web_exe..."
                );

                RegisterWebExeAssociation(
                    browserPath
                );

                Console.WriteLine(
                    "[OK] .web_exe связан с yandex++."
                );

                // ==========================================
                // Обновление Explorer
                // ==========================================

                Console.WriteLine(
                    "[3/3] Обновление Проводника..."
                );

                SHChangeNotify(
                    SHCNE_ASSOCCHANGED,
                    SHCNF_IDLIST,
                    IntPtr.Zero,
                    IntPtr.Zero
                );

                Console.WriteLine();
                Console.WriteLine(
                    "=================================="
                );

                Console.WriteLine(
                    "        Установка завершена"
                );

                Console.WriteLine(
                    "=================================="
                );

                Console.WriteLine();
                Console.WriteLine(
                    ".web_exe теперь открывается через yandex++."
                );

                Console.WriteLine(
                    "Персональные иконки .web_exe включены."
                );

                Console.WriteLine();
                Console.WriteLine(
                    "Можно закрыть установщик."
                );

                Console.ReadKey();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("[FATAL ERROR]");
                Console.WriteLine(ex);

                Console.ReadKey();

                return -1;
            }
        }


        // ============================================================
        // РЕГИСТРАЦИЯ .web_exe
        // ============================================================

        private static void RegisterWebExeAssociation(
            string browserPath)
        {
            // ------------------------------------------
            // .web_exe
            // ------------------------------------------

            using (
                RegistryKey extension =
                    Registry.CurrentUser.CreateSubKey(
                        @"Software\Classes\.web_exe"
                    )
            )
            {
                extension.SetValue(
                    "",
                    "Unauticna.WebExe"
                );
            }


            // ------------------------------------------
            // ProgID
            // ------------------------------------------

            using (
                RegistryKey progId =
                    Registry.CurrentUser.CreateSubKey(
                        @"Software\Classes\Unauticna.WebExe"
                    )
            )
            {
                progId.SetValue(
                    "",
                    "Unauticna Web Executable"
                );
            }


            // ------------------------------------------
            // DefaultIcon=%1
            //
            // Это обязательно для нашего Icon Handler.
            // ------------------------------------------

            using (
                RegistryKey icon =
                    Registry.CurrentUser.CreateSubKey(
                        @"Software\Classes\Unauticna.WebExe\DefaultIcon"
                    )
            )
            {
                icon.SetValue(
                    "",
                    "%1"
                );
            }


            // ------------------------------------------
            // double click -> yandex++.exe "%1"
            // ------------------------------------------

            using (
                RegistryKey command =
                    Registry.CurrentUser.CreateSubKey(
                        @"Software\Classes\Unauticna.WebExe\shell\open\command"
                    )
            )
            {
                string value =
                    "\"" +
                    browserPath +
                    "\" \"%1\"";

                command.SetValue(
                    "",
                    value
                );
            }
        }


        // ============================================================
        // REGSVR32
        // ============================================================

        private static int RunRegsvr32(
            string dllPath,
            bool unregister)
        {
            string regsvr32 =
                Get64BitRegsvr32();

            string arguments;

            if (unregister)
            {
                arguments =
                    "/u /s \"" +
                    dllPath +
                    "\"";
            }
            else
            {
                arguments =
                    "/s \"" +
                    dllPath +
                    "\"";
            }

            ProcessStartInfo psi =
                new ProcessStartInfo();

            psi.FileName =
                regsvr32;

            psi.Arguments =
                arguments;

            psi.UseShellExecute =
                false;

            psi.CreateNoWindow =
                true;

            psi.WorkingDirectory =
                Path.GetDirectoryName(
                    dllPath
                );

            using (
                Process process =
                    Process.Start(psi)
            )
            {
                process.WaitForExit();

                return process.ExitCode;
            }
        }


        // ============================================================
        // Именно 64-bit regsvr32
        // ============================================================

        private static string Get64BitRegsvr32()
        {
            string windows =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.Windows
                );

            /*
             * Если сам Installer случайно собран x86,
             * Windows перенаправляет System32 -> SysWOW64.
             *
             * Sysnative позволяет x86-программе вызвать
             * настоящий x64 System32.
             */

            if (
                Environment.Is64BitOperatingSystem &&
                !Environment.Is64BitProcess
            )
            {
                return Path.Combine(
                    windows,
                    "Sysnative",
                    "regsvr32.exe"
                );
            }

            return Path.Combine(
                windows,
                "System32",
                "regsvr32.exe"
            );
        }


        // ============================================================
        // UNINSTALL
        // ============================================================

        private static int Uninstall(
            string dllPath)
        {
            Console.WriteLine(
                "Удаление yandex++ integration..."
            );

            // ------------------------------------------
            // COM
            // ------------------------------------------

            if (File.Exists(dllPath))
            {
                int result =
                    RunRegsvr32(
                        dllPath,
                        true
                    );

                Console.WriteLine(
                    "regsvr32 uninstall: " +
                    result
                );
            }


            // ------------------------------------------
            // Реестр
            // ------------------------------------------

            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(
                    @"Software\Classes\Unauticna.WebExe",
                    false
                );
            }
            catch
            {
            }

            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(
                    @"Software\Classes\.web_exe",
                    false
                );
            }
            catch
            {
            }


            // ------------------------------------------
            // Explorer refresh
            // ------------------------------------------

            SHChangeNotify(
                SHCNE_ASSOCCHANGED,
                SHCNF_IDLIST,
                IntPtr.Zero,
                IntPtr.Zero
            );

            Console.WriteLine();
            Console.WriteLine(
                "yandex++ integration удалена."
            );

            Console.ReadKey();

            return 0;
        }
    }
}