using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace IcoToButeClipBoard
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "ICO To Bytes Clipboard";

            try
            {
                string icoPath = null;

                // Если .ico перетащили на EXE
                // или передали как аргумент
                if (args.Length > 0)
                {
                    icoPath = args[0];
                }
                else
                {
                    Console.WriteLine("ICO To Bytes Clipboard");
                    Console.WriteLine();
                    Console.WriteLine("Введите путь к .ico:");
                    Console.Write("> ");

                    icoPath = Console.ReadLine();
                }

                if (string.IsNullOrWhiteSpace(icoPath))
                {
                    Console.WriteLine("Путь не указан.");
                    Console.ReadKey();
                    return;
                }

                // Убираем кавычки
                icoPath = icoPath.Trim().Trim('"');

                if (!File.Exists(icoPath))
                {
                    Console.WriteLine();
                    Console.WriteLine("Файл не найден:");
                    Console.WriteLine(icoPath);

                    Console.ReadKey();
                    return;
                }

                if (!Path.GetExtension(icoPath)
                    .Equals(".ico", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine();
                    Console.WriteLine("Это не .ico файл.");

                    Console.ReadKey();
                    return;
                }

                // ==========================================
                // ICO -> bytes
                // ==========================================

                byte[] bytes =
                    File.ReadAllBytes(icoPath);

                // ==========================================
                // bytes -> Base64
                // ==========================================

                string base64 =
                    Convert.ToBase64String(bytes);

                // ==========================================
                // Clipboard
                // ==========================================

                Clipboard.SetText(base64);

                Console.WriteLine();
                Console.WriteLine("Готово.");
                Console.WriteLine();

                Console.WriteLine(
                    "Файл: " +
                    Path.GetFileName(icoPath)
                );

                Console.WriteLine(
                    "Размер: " +
                    bytes.Length +
                    " байт"
                );

                Console.WriteLine(
                    "Base64: " +
                    base64.Length +
                    " символов"
                );

                Console.WriteLine();
                Console.WriteLine(
                    "Данные ICO скопированы в буфер обмена."
                );

                Console.WriteLine();
                Console.WriteLine(
                    "Нажмите любую клавишу..."
                );

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка:");
                Console.WriteLine(ex.Message);

                Console.ReadKey();
            }
        }
    }
}