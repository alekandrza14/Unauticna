using Jint;//Вот он
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Unauticna_Visual_Studio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataJSLib("Begin", "Begin");
        }

        private void DataJSLib(string region, string Dialog)
        {
            string nameActions = Global.File.ReadRegionText($"{textBox3.Text}", region);
            string[] nameAction = nameActions.Split(',');

            if (nameAction.Length > 0&& !string.IsNullOrEmpty( nameAction[0])) button2.Text = nameAction[0]; else button2.Text ="button2";
            if (nameAction.Length > 1) button3.Text = nameAction[1]; else button3.Text ="button3";
            if (nameAction.Length > 2) button4.Text = nameAction[2]; else button4.Text ="button4";
            if (nameAction.Length > 3) button5.Text = nameAction[3]; else button5.Text ="button5";
            if (nameAction.Length > 4) button6.Text = nameAction[4]; else button6.Text ="button6";
            if (nameAction.Length > 5) button7.Text = nameAction[5]; else button7.Text ="button7";
            if (nameAction.Length > 6) button8.Text = nameAction[6]; else button8.Text ="button8";
            if (nameAction.Length > 7) button9.Text = nameAction[7]; else button9.Text ="button9";
            if (nameAction.Length > 8) button10.Text = nameAction[8]; else button10.Text = "button10";
            textBox1.Text = Global.File.ReadRegionText($"{textBox3.Text}", Dialog+ "Dialog")+ $" Errors:{Global.Msg.Errors}";
        }

        int listCurent = 1;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           // Point WindowCursorPosition = new Point(Location.X - Cursor.Position.X, Location.Y - Cursor.Position.Y);
          //  Location = new Point(Cursor.Position.X + WindowCursorPosition.X, Cursor.Position.Y + WindowCursorPosition.Y);
        }
        Point WindowCursorPosition;
        bool tp;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            tp = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            WindowCursorPosition = new Point(Location.X - Cursor.Position.X, Location.Y - Cursor.Position.Y);
            Location = new Point(Cursor.Position.X + WindowCursorPosition.X, Cursor.Position.Y + WindowCursorPosition.Y);
            tp = true;
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(tp)Location = new Point(Cursor.Position.X + WindowCursorPosition.X, Cursor.Position.Y + WindowCursorPosition.Y);
            label2.Text = $"лист {listCurent}/{Global.File.GetPagesCount($"{textBox3.Text}")} библиотеки {textBox3.Text}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonFunction(button3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ButtonFunction(button8);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ButtonFunction(button10);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ButtonFunction(button9);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ButtonFunction(button7);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonFunction(button6);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonFunction(button5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonFunction(button4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonFunction(button2);
        }

        private void ButtonFunction(Button function)
        {
            string filePath =
                $"{textBox3.Text}";

            string pageName =
                "List" + listCurent;

            string pageData =
                Global.File.ReadRegionText(
                    filePath,
                    pageName
                );

            // -------------------------
            // 1. Обычный replacement
            // -------------------------

            string replacement;

            if (Global.Data.TryReadRegionText(
                pageData,
                function.Text,
                out replacement))
            {
                // Пустой регион тоже разрешён,
                // но Module удаляем только если там реально есть код.
                if (!string.IsNullOrWhiteSpace(replacement))
                {
                    string module =
                        $"//Module\"List{listCurent}\".{textBox3.Text}";

                    textBox2.Text =
                        textBox2.Text.Replace(
                            module,
                            replacement
                        );
                }
            }

            // -------------------------
            // 2. JS replacement
            // -------------------------

            textBox2.Text = RunJSCommands(
                pageData,
                function.Text,
                textBox2.Text
            );
            if(textBox3.Text.Contains(".mpullib"))
            {
                textBox2.Text = textBox2.Text.Replace(".png","");
            }
            // -------------------------
            // Следующая страница
            // -------------------------

            listCurent++;

            DataJSLib(
                $"List{listCurent - 1}.end",
                $"List{listCurent - 1}"
            );
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text = $"//Module\"List1\".{textBox3.Text}";
            listCurent = 0;
            DataJSLib("Begin", "Begin");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = $"//Module\"List1\".{textBox3.Text}";
            listCurent = 1;
            DataJSLib("Begin", "Begin");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private string RunJSCommands(
    string pageData,
    string actionName,
    string jsRaw)
        {
            string commands;

            if (!Global.Data.TryReadRegionText(
                pageData,
                actionName + "JSRUN",
                out commands))
            {
                return jsRaw;
            }

            MatchCollection runs = Regex.Matches(
                commands,
                @"Run\s*\(\s*""([^""]+)""\s*\)\s*;"
            );

            foreach (Match run in runs)
            {
                string fileName = run.Groups[1].Value;

                jsRaw = RunJsFile(
                    fileName,
                    jsRaw
                );
            }

            return jsRaw;
        }
      
        private string DragTexture(string currentTexture)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title =
                    "Текущая текстура: " + currentTexture;

                dialog.Filter =
                    "PNG texture (*.png)|*.png|Все файлы (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return Path.GetFileNameWithoutExtension(
                        dialog.FileName
                    );
                }
            }

            return "";
        }
        private string RunJsFile(string scriptName, string jsRaw)
        {
            string scriptPath = Path.Combine(
                Application.StartupPath,
                scriptName
            );

            // Если скрипты лежат в res\scripts
            if (!File.Exists(scriptPath))
            {
                scriptPath = Path.Combine(
                    Application.StartupPath,
                    "res",
                    "scripts",
                    scriptName
                );
            }

            if (!File.Exists(scriptPath))
            {
                MessageBox.Show(
                    "JS файл не найден:\n" + scriptName
                );

                return jsRaw;
            }

            try
            {
                string script = File.ReadAllText(scriptPath);

                Engine engine = new Engine();

                // Передаём JS функцию из C#
                engine.SetValue(
                    "drag",
                    new Func<string, string>(DragTexture)
                );

                engine.Execute(script);

                var result = engine.Invoke(
                    "Main",
                    jsRaw
                );

                return result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "JINT ERROR:\n" + ex.Message
                );

                return jsRaw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "Core.jslib";
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            textBox3.Text = "Shader.jslib";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            WindowCursorPosition = new Point(Location.X - Cursor.Position.X, Location.Y - Cursor.Position.Y);
            Location = new Point(Cursor.Position.X + WindowCursorPosition.X, Cursor.Position.Y + WindowCursorPosition.Y);
            tp = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            tp = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox3.Text = "JavaWindow.mpul.jslib";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {

            WindowCursorPosition = new Point(Location.X - Cursor.Position.X, Location.Y - Cursor.Position.Y);
            Location = new Point(Cursor.Position.X + WindowCursorPosition.X, Cursor.Position.Y + WindowCursorPosition.Y);
            tp = true;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            tp = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
namespace Global
{

    public static class Msg { public static string Errors = ""; }
    public static class File
    {
        public static int GetPagesCount(string path)
        {
            string text = System.IO.File.ReadAllText(path);

            MatchCollection matches = Regex.Matches(
                text,
                @"\*_List(\d+)_\*"
            );

            HashSet<int> pages = new HashSet<int>();

            foreach (Match match in matches)
            {
                pages.Add(int.Parse(match.Groups[1].Value));
            }

            return pages.Count;
        }

        public static string ReadRegionText(string path, string region)
        {
            string text = System.IO.File.ReadAllText(path);

            string startMarker = $"*_{region}_*";
            string endMarker = startMarker;

            // Для твоего формата *_Mod1_*
            startMarker = $"*_{region}_*";

            int start = text.IndexOf(startMarker);

            if (start == -1)
                Msg.Errors +=$"Регион '{region}' не найден.";

            start += startMarker.Length;

            int end = text.IndexOf(endMarker, start);

            if (end == -1)
                Msg.Errors += $"Конец региона '{region}' не найден.";

            return text.Substring(start, end - start).Trim();
        }

        public static void WriteRegionText(
            string path,
            string region,
            string content)
        {
            string text = System.IO.File.ReadAllText(path);

            string marker = $"*_{region}_*";

            int start = text.IndexOf(marker);

            if (start == -1)
                Msg.Errors += $"Регион '{region}' не найден.";

            int contentStart = start + marker.Length;

            int end = text.IndexOf(marker, contentStart);

            if (end == -1)
                Msg.Errors += $"Конец региона '{region}' не найден.";

            string newText =
                text.Substring(0, contentStart)
                + Environment.NewLine
                + Environment.NewLine
                + content
                + Environment.NewLine
                + Environment.NewLine
                + text.Substring(end);

            System.IO.File.WriteAllText(path, newText);
        }

        public static void AppendRegionText(
            string path,
            string region,
            string content)
        {
            string oldContent = ReadRegionText(path, region);

            if (string.IsNullOrWhiteSpace(oldContent))
                WriteRegionText(path, region, content);
            else
                WriteRegionText(
                    path,
                    region,
                    oldContent + Environment.NewLine + content
                );
        }
    }
    
    public static class Data
    {
        public static bool TryReadRegionText(
    string data,
    string region,
    out string result)
        {
            result = "";

            string marker = $"*_{region}_*";

            int start = data.IndexOf(marker);

            if (start == -1)
                return false;

            start += marker.Length;

            int end = data.IndexOf(marker, start);

            if (end == -1)
                return false;

            result = data.Substring(
                start,
                end - start
            ).Trim();

            return true;
        }
        public static string ReadRegionText(string data, string region)
        {
            string text = data;

            string startMarker = $"*_{region}_*";
            string endMarker = startMarker;

            // Для твоего формата *_Mod1_*
            startMarker = $"*_{region}_*";

            int start = text.IndexOf(startMarker);

            if (start == -1)
                Msg.Errors += $"Регион '{region}' не найден.";

            start += startMarker.Length;

            int end = text.IndexOf(endMarker, start);

            if (end == -1)
                Msg.Errors += $"Конец региона '{region}' не найден.";

            return text.Substring(start, end - start).Trim();
        }

        
    }


}
