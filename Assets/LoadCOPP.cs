using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LoadCOPP : MonoBehaviour
{
    public InputField _file;
    public InputField _file2;
    public CustomObject _Object;

    public float screenshotTimeout = 300f;

    private bool screenshotBusy;

    public void FileOpen()
    {
        _Object.s = _file.text;
        _Object.resetCurrentSettings();
    }

    public async void FileScreen()
    {
        if (screenshotBusy)
            return;

        screenshotBusy = true;
        System.Diagnostics.Process process = null;

        try
        {
            string name = _file.text.Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0 ||
                name == "." || name == "..")
            {
                throw new ArgumentException("Укажи корректное имя без пути и расширения.");
            }

            // Все относительные пути считаются от Working Directory.
            string root = Directory.GetCurrentDirectory();

            string exePath = Path.Combine(
                root, "windows", "ScrinhoterUnauticnatems.exe");

            string txtPath = Path.Combine(
                root, "res", "UserWorckspace", "Items", name + ".txt");

            string pngPath = Path.Combine(
                root, "res", "UserWorckspace", "Items++", "CO", name + ".png");

            // Читаем до запуска программы, чтобы сразу обнаружить ошибку.
            string json = System.IO.File.ReadAllText(txtPath);

            Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

            if (!System.IO.File.Exists(pngPath))
            {
                if (!System.IO.File.Exists(exePath))
                    throw new FileNotFoundException(
                        "Скриншотер не найден.", exePath);

                process = System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = exePath,

                        // Первый аргумент — полный путь итогового PNG.
                        Arguments = "\"" + pngPath + "\"",

                        WorkingDirectory = root,
                        UseShellExecute = false
                    });

                if (process == null)
                    throw new InvalidOperationException(
                        "Не удалось запустить скриншотер.");
            }

            DateTime deadline = DateTime.UtcNow.AddSeconds(
                Math.Max(1.0, screenshotTimeout));

            // Самого File.Exists недостаточно:
            // файл может существовать, но ещё записываться.
            while (!IsPngReady(pngPath))
            {
                if (process != null && process.HasExited)
                    throw new IOException(
                        "Скриншотер закрыт, но готовый PNG не найден.");

                if (DateTime.UtcNow >= deadline)
                    throw new TimeoutException(
                        "Истекло время ожидания скриншота.");

                await Task.Delay(200);

                if (this == null)
                    return;
            }

            try
            {
                Global._2026_08_10.File.AddRegion(
                    pngPath, "Json", json);
            }
            catch (InvalidOperationException)
            {
                // Твой AddRegion выдаёт эту ошибку,
                // когда регион уже существует.
                Global._2026_08_10.File.WriteRegionText(
                    pngPath, "Json", json);
            }

            UnityEngine.Debug.Log(
                "PNG с регионом Json сохранён: " + pngPath);
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogError(
                "Ошибка сохранения предмета: " + ex.Message);
        }
        finally
        {
            // Освобождаем объект Process, не завершая чужое окно.
            process?.Dispose();
            screenshotBusy = false;
        }
    }

    private static bool IsPngReady(string path)
    {
        if (!System.IO.File.Exists(path))
            return false;

        try
        {
            // Не открываем файл, пока другой процесс записывает его.
            using (var stream = new FileStream(
                path, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var reader = new BinaryReader(stream))
            {
                byte[] signature =
                {
                    137, 80, 78, 71, 13, 10, 26, 10
                };

                for (int i = 0; i < signature.Length; i++)
                {
                    if (stream.Position >= stream.Length ||
                        reader.ReadByte() != signature[i])
                        return false;
                }

                // Ищем завершающий блок PNG — IEND.
                while (stream.Length - stream.Position >= 12)
                {
                    uint length =
                        ((uint)reader.ReadByte() << 24) |
                        ((uint)reader.ReadByte() << 16) |
                        ((uint)reader.ReadByte() << 8) |
                        reader.ReadByte();

                    string type = Encoding.ASCII.GetString(
                        reader.ReadBytes(4));

                    // Данные блока + четыре байта CRC.
                    if ((long)length + 4 > stream.Length - stream.Position)
                        return false;

                    stream.Seek((long)length + 4, SeekOrigin.Current);

                    if (type == "IEND")
                        return length == 0;
                }

                return false;
            }
        }
        catch (IOException)
        {
            return false;
        }
    }
}
namespace Global._2026_08_10
{
    public class File{
    public static void WriteRegionText(
    string path,
    string region,
    string content)
    {
        if (string.IsNullOrEmpty(region))
            throw new System.ArgumentException("Имя региона пустое.", nameof(region));

        if (content == null)
            throw new System.ArgumentNullException(nameof(content));

        byte[] fileBytes = System.IO.File.ReadAllBytes(path);

        string[] markers =
        {
        $"*_{region}_*",
        $"_*{region}*_"
    };

        System.Text.Encoding[] encodings =
        {
        new System.Text.UTF8Encoding(false, true),
        System.Text.Encoding.GetEncoding(
            1251,
            System.Text.EncoderFallback.ExceptionFallback,
            System.Text.DecoderFallback.ExceptionFallback)
    };

        foreach (System.Text.Encoding encoding in encodings)
        {
            foreach (string markerText in markers)
            {
                byte[] marker;

                try
                {
                    marker = encoding.GetBytes(markerText);
                }
                catch (System.Text.EncoderFallbackException)
                {
                    continue;
                }

                int start = FindBytes(fileBytes, marker, 0);
                if (start < 0)
                    continue;

                int contentStart = start + marker.Length;
                int end = FindBytes(fileBytes, marker, contentStart);

                if (end < 0)
                    throw new System.IO.InvalidDataException(
                        $"Конец региона '{region}' не найден.");

                if (content.Contains(markerText))
                    throw new System.ArgumentException(
                        "Содержимое не должно включать маркер региона.",
                        nameof(content));

                // Сохраняем кодировку найденного региона.
                // Неподдерживаемые символы вызовут ошибку, а не заменятся на '?'.
                byte[] replacement = encoding.GetBytes(
                    "\r\n" + content + "\r\n");

                int newLength = checked(
                    contentStart + replacement.Length + fileBytes.Length - end);

                byte[] result = new byte[newLength];

                // Всё до содержимого региона, включая первый маркер.
                System.Buffer.BlockCopy(
                    fileBytes, 0, result, 0, contentStart);

                // Новое содержимое.
                System.Buffer.BlockCopy(
                    replacement, 0, result, contentStart, replacement.Length);

                // Закрывающий маркер и всё после него.
                System.Buffer.BlockCopy(
                    fileBytes, end,
                    result, contentStart + replacement.Length,
                    fileBytes.Length - end);

                System.IO.File.WriteAllBytes(path, result);
                return;
            }
        }

        throw new System.IO.InvalidDataException(
            $"Регион '{region}' не найден.");
    }
    public static string ReadRegionText(string path, string region)
    {
        if (string.IsNullOrEmpty(region))
            throw new System.ArgumentException(
                "Имя региона пустое.", nameof(region));

        byte[] fileBytes = System.IO.File.ReadAllBytes(path);

        string[] markers =
        {
        $"*_{region}_*",
        $"_*{region}*_"
    };

        System.Text.Encoding[] encodings =
        {
        new System.Text.UTF8Encoding(false, true),
        System.Text.Encoding.GetEncoding(
            1251,
            System.Text.EncoderFallback.ExceptionFallback,
            System.Text.DecoderFallback.ExceptionFallback)
    };

        foreach (System.Text.Encoding encoding in encodings)
        {
            foreach (string markerText in markers)
            {
                byte[] marker;

                try
                {
                    marker = encoding.GetBytes(markerText);
                }
                catch (System.Text.EncoderFallbackException)
                {
                    continue;
                }

                int start = FindBytes(fileBytes, marker, 0);
                if (start < 0)
                    continue;

                int contentStart = start + marker.Length;
                int end = FindBytes(fileBytes, marker, contentStart);

                if (end < 0)
                    throw new System.IO.InvalidDataException(
                        $"Конец региона '{region}' не найден.");

                // Декодируем только содержимое региона, а не весь PNG.
                return encoding.GetString(
                    fileBytes,
                    contentStart,
                    end - contentStart
                ).Trim();
            }
        }

        throw new System.IO.InvalidDataException(
            $"Регион '{region}' не найден.");
    }
    public static void AddRegion(
    string path,
    string region,
    string content = "")
    {
        if (string.IsNullOrWhiteSpace(region))
            throw new System.ArgumentException(
                "Имя региона пустое.", nameof(region));

        if (content == null)
            throw new System.ArgumentNullException(nameof(content));

        byte[] fileBytes = System.IO.File.ReadAllBytes(path);

        string[] markers =
        {
        $"*_{region}_*",
        $"_*{region}*_"
    };

        System.Text.Encoding[] encodings =
        {
        new System.Text.UTF8Encoding(false, true),
        System.Text.Encoding.GetEncoding(
            1251,
            System.Text.EncoderFallback.ExceptionFallback,
            System.Text.DecoderFallback.ExceptionFallback)
    };

        // Проверяем оба формата маркеров и обе кодировки.
        foreach (System.Text.Encoding encoding in encodings)
        {
            foreach (string existingMarker in markers)
            {
                byte[] markerBytes;

                try
                {
                    markerBytes = encoding.GetBytes(existingMarker);
                }
                catch (System.Text.EncoderFallbackException)
                {
                    continue;
                }

                if (FindBytes(fileBytes, markerBytes, 0) >= 0)
                    throw new System.InvalidOperationException(
                        $"Регион '{region}' уже существует. Используй WriteRegionText().");
            }
        }

        string marker = markers[0];

        if (content.Contains(marker))
            throw new System.ArgumentException(
                "Содержимое не должно включать маркер региона.",
                nameof(content));

        // Новые регионы записываем в UTF-8 без BOM.
        byte[] addition = encodings[0].GetBytes(
            "\r\n" + marker +
            "\r\n" + content +
            "\r\n" + marker + "\r\n");

        using (var stream = new System.IO.FileStream(
            path,
            System.IO.FileMode.Open,
            System.IO.FileAccess.Write,
            System.IO.FileShare.None))
        {
            stream.Seek(0, System.IO.SeekOrigin.End);
            stream.Write(addition, 0, addition.Length);
        }
    }
    private static int FindBytes(byte[] source, byte[] pattern, int start)
    {
        for (int i = start; i <= source.Length - pattern.Length; i++)
        {
            int j = 0;

            while (j < pattern.Length && source[i + j] == pattern[j])
                j++;

            if (j == pattern.Length)
                return i;
        }

        return -1;
    }
}
}