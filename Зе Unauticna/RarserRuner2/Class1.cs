using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
namespace RarserRuner
{
    class Program
    {
        static void Main(string[] args)
        {
           // File.WriteAllText("вещь.ркн", File.ReadAllText(args[0]));
            RunCommand("node.exe", "index.js");
            Start();
        }
        static string cFile = "C_consle";
        static void Start()
        {
            string root = "";

            string vcvars =
                @"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvars64.bat";

            string source =
                root + @"" + cFile + ".c";

            string outputDir =
                root + @"";

            string command =
                 $"chcp 65001 > nul && " +
    $"call \"{vcvars}\" && " +
    $"cl /utf-8 /nologo /EHsc " +
    $"\"{source}\" " +
    $"/Fe:\"{outputDir + cFile}.exe\"";

            RunCommand("cmd.exe", "/c " + command);
        }


        private static void RunCommand(string fileName, string arguments)
        {
            Process process = new Process();

            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WorkingDirectory = @"";

            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine(e.Data);
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine(e.Data);
            };

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();
        }
    }
}
