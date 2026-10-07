using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Acornima.Ast;
using Jint;

namespace MPUL_Compilator
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static string pach;
        public static string output;
        public static Dictionary<string, int> commands = new Dictionary<string, int>();
        public static Dictionary<string, string> Colorset = new Dictionary<string, string>();
        public static Dictionary<string, string> obj = new Dictionary<string, string>();
        public static Dictionary<string, List<string>> JavaModules = new Dictionary<string, List<string>>();
        public static string commandstest = "";
        public static string commandstest2 = "";
        public static string commandstest3 = "";
        public static string commandstest4 = "";
        public static string commandstest5 = "";
        public static string commandstest6 = "";
        public static List<string> commandList = new List<string>()
        {
            "окно",
            "круг",
            "ява.сборка",
            "закреп.окно",
            "изображение",
            "сигнал",
            "функция",
            "файл",
            "асм.собрать",
            "кнопка",
            "запуск",
            "асм.сообшение"
        };

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                pach = args[0];
            }
            Colorset.Add("красный", "Color.RED");
            Colorset.Add("синий", "Color.BLUE");
            Colorset.Add("зелёный", "Color.GREEN");
            Colorset.Add("жёлтый", "Color.YELLOW");
            Colorset.Add("оранжевый", "Color.ORANGE");
            Colorset.Add("розовый", "Color.PINK");
            Colorset.Add("фиолетовый", "Color.MAGENTA");
            Colorset.Add("голубой", "Color.CYAN");
            Colorset.Add("чёрный", "Color.BLACK");
            Colorset.Add("белый", "Color.WHITE");
            Colorset.Add("серый", "Color.GRAY");
            Colorset.Add("тёмно-серый", "Color.DARK_GRAY");
            Colorset.Add("светло-серый", "Color.LIGHT_GRAY");
            //output += "Язык сырой " + pach;
            func("главный",null);
            // Global.File.WriteRegionText(pach, "errors","Lenguage Raw"+pach);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static string exeutingFile;
        public static string executingFilePath;
        public static string ArgumentRuning;
        private static async void func(string function,string file)
        {
            if (!string.IsNullOrEmpty(pach))
            {
                if (file == null) if (exeutingFile != null) file = exeutingFile;
                //   if (File.Exists(Path.GetDirectoryName(pach) + "\\" + col1.Replace("png", "") + ".png"))
                string code = "";

                if (file == null) if (exeutingFile == null) code = Global.File.ReadRegionText(pach, function);

                if (file == null) if (exeutingFile == null) Global.File.WriteRegionText(
              pach,
              "ошибки",
               output
          );
                if (file != null)
                {
                    exeutingFile = file; 
                    executingFilePath = Path.GetDirectoryName(pach) + "\\" + exeutingFile;
                    code = Global.File.ReadRegionText(Path.GetDirectoryName(pach) + "\\" + exeutingFile, function);
                    Global.File.WriteRegionText(
                    Path.GetDirectoryName(pach) + "\\" + exeutingFile,
                    "ошибки",
                    output
              );
                }

                if (!string.IsNullOrEmpty(exeutingFile)) { output = "Язык сырой " + Path.GetDirectoryName(pach) + "\\" + exeutingFile + "\n"; } else { output += "Язык сырой " + pach; }
              
                //  SendInFile(code);
                string[] lines = code.Split(new char[] { '\n' });
                int i = 0;

                foreach (string line in lines)
                {

                    string cleanLine = line.Trim();

                    bool nonExistsCom = true;
                    // List<string> nonExistsComName = new List<string>();
                    foreach (string command in commandList)
                    {
                        if (cleanLine.Contains(" "))
                        {
                            string[] parts2 = cleanLine.Split(
                            new[] { ' ' },
                            StringSplitOptions.RemoveEmptyEntries
                            );
                            string com = parts2[0];
                            if (com == command)
                            {
                                nonExistsCom = false;
                                // nonExistsComName.Add(com);

                            }
                            //  nonExistsComName.Add(com);
                        }
                    }

                    if (nonExistsCom && cleanLine.Length != 0) SendInFile("строка " + i + " команда :" + cleanLine + " не существует в модели языка обновите mpul или установите модификацию");

                    foreach (string command in commandList)
                    {

                        if (cleanLine.StartsWith(command))
                        {
                            string[] parts = cleanLine.Split(
new[] { ' ' },
StringSplitOptions.RemoveEmptyEntries
);
                            if (!commands.ContainsKey(cleanLine)) commands.Add(cleanLine, i);
                            //               commandstest +=
                            //   "Команда: " + command +
                            //   "\nСтрока: " + i +
                            //   "\nТекст: " + cleanLine +
                            //   "\n\n";


                            if (command == "круг")
                            {


                                int x = 0;
                                int y = 0;
                                int w = 0;
                                int h = 0;
                                string color = "";

                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("1="))
                                        x = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("2="))
                                        y = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("ш="))
                                        w = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("в="))
                                        h = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("ц="))
                                        color = part.Substring(2);
                                    else if (part.StartsWith("т="))
                                    {
                                        if (!obj.ContainsKey(part.Substring(2))) obj.Add(part.Substring(2), "noCommand();");
                                    }
                                }
                                commandstest += "//овал " + color + "\n";
                                commandstest += JavaGen(x, y, w, h, color);
                            }
                            else if (command == "изображение")
                            {


                                int x = 0;
                                int y = 0;
                                int w = 0;
                                int h = 0;
                                string pattch = "";

                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("1="))
                                        x = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("2="))
                                        y = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("ш="))
                                        w = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("в="))
                                        h = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("п="))
                                        pattch = part.Substring(2);
                                    else if (part.StartsWith("т="))
                                    {
                                      if (!obj.ContainsKey(part.Substring(2)))  obj.Add(part.Substring(2), "noCommand();");
                                    }
                                }
                                JavaGen4(x, y, w, h, pattch, i);
                            }
                            else if (command == "окно")
                            {


                                int w = 0;
                                int h = 0;

                                string name = "";

                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("ш="))
                                        w = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("в="))
                                        h = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("и="))
                                    {
                                        name = part.Substring(2);
                                        commandstest4 = part.Substring(2);
                                    }
                                }
                                commandstest2 += "//окно " + name + "\n";
                                commandstest2 += JavaGen2(w, h, name)[".java"];
                                commandstest5 += JavaGen2(w, h, name)[".asm1"];
                                commandstest6 += JavaGen2(w, h, name)[".asm2"];
                            }
                            else if (command == "ява.сборка")
                            {
                                string name = "";

                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("и="))
                                        name = part.Substring(2);
                                }

                                commandstest3 += "//ява-архив " + name + "\n";

                                await JavaGen3(
                                    name,
                                    commandstest,
                                    commandstest2, commandstest4, JavaModules
                                );
                            }
                            else if (command == "закреп.окно")
                            {
                                string name = "";
                                string settingsFile = "";

                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("и="))
                                        name = part.Substring(2);
                                    else if (part.StartsWith("н="))
                                        settingsFile = part.Substring(2);
                                }



                                SharpUpdate(
                                    name,
                                    settingsFile
                                );
                            }
                            else if (command == "сигнал")
                            {
                                string name = "";

                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("т="))
                                        name = part.Substring(2);

                                }



                                JSUpdate(
                                    name,
                                    i
                                );
                            }
                            else if (command == "функция")
                            {
                                string name = "";

                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("и="))
                                        name = part.Substring(2);

                                }



                                func(
                                    name,null
                                );
                            }
                            else if (command == "файл")
                            {
                                string name = "";
                                string name2 = "";

                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("и="))
                                        name = part.Substring(2);
                                    if (part.StartsWith("ф="))
                                        name2 = part.Substring(2);
                                }



                                func(
                                    name, name2 + ".mpul"
                                );
                            }
                            else if (command == "асм.собрать")
                            {
                                string name = "";

                                // например, имя берём из уже созданного окна
                                // либо из текущего контекста
                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("и="))
                                        name = part.Substring(2);
                                }

                                commandstest3 += "// асм.собрать\n";

                                AsmBuild(
                                    name
                                );
                            }
                            else if (command == "кнопка")
                            {


                                int x = 0;
                                int y = 0;
                                int w = 0;
                                int h = 0;
                                string pattch = "";
                                string exe = "";

                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("1="))
                                        x = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("2="))
                                        y = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("ш="))
                                        w = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("в="))
                                        h = int.Parse(part.Substring(2));

                                    else if (part.StartsWith("п="))
                                        pattch = part.Substring(2);
                                    else if (part.StartsWith("т="))
                                    {
                                        if (!obj.ContainsKey(part.Substring(2))) obj.Add(part.Substring(2), "noCommand();");
                                    }
                                    else if (part.StartsWith("з="))
                                    {
                                        exe = part.Substring(2);
                                    }
                                }
                                JavaGen4(x, y, w, h, pattch, i, "Button", exe);
                            }
                            else if (command == "запуск")
                            {



                                string exe = "";

                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("а="))
                                        exe = part.Substring(2);


                                }
                                // JavaGen4(x, y, w, h, pattch, i, "Button", exe);
                                ArgumentRuning = exe;
                            }
                            else if (command == "асм.сообшение")
                            {



                                string exe = "";
                                string name = "";
                                string content = "";

                                foreach (string part in parts)
                                {
                                    if (part.StartsWith("п="))
                                        exe = part.Substring(2);
                                    else if (part.StartsWith("т="))
                                        content = part.Substring(2);
                                    else if (part.StartsWith("и="))
                                        name = part.Substring(2);


                                }
                                // JavaGen4(x, y, w, h, pattch, i, "Button", exe);
                                AsmSysMsg(name, content, exe);
                            }
                            //.  else
                            //   {
                            //   SendInFile("команда :" + command + " не существует в модели языка обновите mpul или установите модификацию");
                            //   }
                        }
                    }

                    i++;
                }


                //  SendInFile(commandstest);
                /*
              string JavaBegin = "import javax.swing.*;\r\n" +
                  "import java.awt.*;\r\n" +
                  "import java.awt.event.*;\r\n" +
                  "import java.awt.image.BufferedImage;\r\n" +
                  "import javax.imageio.ImageIO;\r\n" +
                  "import java.io.File;\r\n" +
                  "import java.io.IOException;\r\n" +
                  "\r\n" +
                  "public class Main extends JPanel implements Runnable {\r\n" +
                  "private boolean running = true;\r\n" +
                  "\r\n" +
                  "\r\n" +
                  " public Main() {\r\n" +
                  "        setFocusable(true);\r\n" +
                  "\r\n" +
                  "\r\n" +
                  "            }\r\n" +
                  "  @Override\r\n" +
                  "    protected void paintComponent(Graphics g) {\r\n" +
                  "        super.paintComponent(g);\r\n" +
                  "\r\n" +
                  "        Graphics2D g2 = (Graphics2D) g;\r\n" +
                  "//овал красный\r\n" +
                  $"{commandstest}" +
                  "    }\r\n" +
                  " @Override\r\n" +
                  "    public void run() {\r\n" +
                  "\r\n" +
                  "        while (running) {\r\n" +
                  "\r\n" +
                  "           \r\n" +
                  "            repaint();\r\n" +
                  "\r\n" +
                  "            try {\r\n" +
                  "                Thread.sleep(16); // примерно 60 FPS\r\n" +
                  "            } catch (InterruptedException e) {\r\n" +
                  "                e.printStackTrace();\r\n" +
                  "            }\r\n" +
                  "        }\r\n" +
                  "    }\r\n" +
                  "\r\n" +
                  "\r\n" +
                  "    public static void main(String[] args) {\r\n" +
                  "\r\n" +
                  "//окно круги\r\n" +
                  $"{commandstest2}" +
                  "\r\n" +
                  "        // Полноэкранный режим\r\n" +

                  "        //window.setExtendedState(JFrame.MAXIMIZED_BOTH);\r\n" +
                  "\r\n" +
                  "        window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);\r\n\t" +
                  "        \r\n" +
                  "        Main game = new Main();\r\n" +
                  "\r\n" +
                  "        window.add(game);\r\n" +
                  "        window.setVisible(true);\r\n" +
                  "\r\n" +
                  "        // Запуск игрового цикла\r\n" +
                  "        new Thread(game).start();\r\n" +
                  "\r\n" +
                  "        game.requestFocusInWindow();\r\n" +
                  "    }\r\n" +
                  "}\r\n" +
                  "";

              string javapach = Path.GetDirectoryName(pach)+"\\main.java";
              Console.WriteLine(javapach+"\n"+JavaBegin);
              File.WriteAllText(javapach, JavaBegin);
                */

            }
            Console.WriteLine(pach);
        }

        private static void SendInFile(string code)
        {
            output += "\n" + code;
           
            string targetFile = executingFilePath ?? pach;

            Global.File.WriteRegionText(
                targetFile,
                "ошибки",
                output
            );
        }
        private static string JavaGen(int x, int y, int w, int h, string col)
        {

            if (!Colorset.TryGetValue(col, out string javaColor))
            {
                SendInFile("Ошибка: неизвестный цвет " + col + " он это " + javaColor);
                Console.WriteLine("Ошибка: неизвестный цвет " + col + " он это " + javaColor);
                //      return "Ошибка: неизвестный цвет " + col + "\n";
            }

            string code = "g2.setColor(" + javaColor + ");\n";
            code += "g2.fillOval(" + x + "," + y + "," + w + "," + h + ");\n";

            return code;
        }
        private static void JavaGen4(int x, int y, int w, int h, string col1, int str, string flag = "image",string exe = "")
        {

            if (!File.Exists(Path.GetDirectoryName(pach) + "\\" + col1.Replace("png", "")+".png"))
            {
                SendInFile("Ошибка: неизвестное изображение " + col1);
                Console.WriteLine("Ошибка: неизвестное изображение " + col1);
                //      return "Ошибка: неизвестный цвет " + col + "\n";
            }
            //g2.drawImage(text1,115,5,60,20,null);
            //private BufferedImage player;
            //text1 = ImageIO.read(new File("text1.png"));
            //private Rectangle button1 = new Rectangle(115, 5, 60, 20);
            string col = col1;
            col = col.ToLower();
            col = col.Replace("а", "f1");//1
            col = col.Replace("б", "f2");//2
            col = col.Replace("в", "f3");//3
            col = col.Replace("г", "f4");//4
            col = col.Replace("д", "f5");//5
            col = col.Replace("е", "f6");//6
            col = col.Replace("ё", "f7");//7
            col = col.Replace("ж", "f8");//8
            col = col.Replace("з", "f9");//9
            col = col.Replace("у", "f10");//10
            col = col.Replace("ф", "f11");//11
            col = col.Replace("х", "f12");//12
            col = col.Replace("ч", "f13");//13
            col = col.Replace("щ", "f14");//14
            col = col.Replace("о", "f15");//15
            col = col.Replace("п", "f16");//16
            col = col.Replace("р", "f17");//17
            col = col.Replace("с", "f18");//18
            col = col.Replace("т", "f19");//19
            col = col.Replace("э", "f20");//20
            col = col.Replace("ъ", "f21");//21
            col = col.Replace("ы", "f22");//22
            col = col.Replace("ь", "f23");//23
            col = col.Replace("ш", "f24");//24
            col = col.Replace("к", "f25");//25
            col = col.Replace("й", "f26");//26
            col = col.Replace("м", "f27");//27
            col = col.Replace("л", "f28");//28
            col = col.Replace("н", "f29");//29
            col = col.Replace("и", "f30");//30
            col = col.Replace("ц", "f31");//31
            col = col.Replace("ы", "f32");//32


            col = col.Replace("ь", "f33");//33
            col = col.Replace("/", "f34");
            col = col.Replace("\\", "f35");
            col = col.Replace("png", "");
            col1 = col1.Replace("png", "");
            string code = "g2.drawImage(" + col.Replace(".", "").Replace(" ", "") + str + "," + x + "," + y + "," + w + "," + h + ",null);\n"; //g2.drawImage(text1, 115, 5, 60, 20, null);
            string code2 = "private BufferedImage " + col.Replace(".", "").Replace(" ", "") + str + ";\n";//private BufferedImage text1;
            string code3 = "  try {" + col.Replace(".", "").Replace(" ", "") + str + " = ImageIO.read(new File(\"" + col1.Replace(".", "").Replace(" ", "") + ".png\"));\n } catch (IOException e) {\r\n        e.printStackTrace();\r\n    }";//text1 = ImageIO.read(new File("text1.png"));

            string code4 = "private Rectangle " + col.Replace(".", "").Replace(" ", "") + str + "sbutton = new Rectangle(" + x + "," + y + "," + w + "," + h + ");\n";//private Rectangle button1 = new Rectangle(115, 5, 60, 20);
            string code5 = " if (" + col.Replace(".", "").Replace(" ", "") + str + "sbutton"/*тут удалили этот пиздец (f25f15f5f34f25f29f15f16f25f1115sbutton = ImageIO.read(new File("код/кнопка1.contains(e.getPoint()))*/ + ".contains(e.getPoint())) {\r\n                    try {\r\n\t\t\t\t\t\tProcessBuilder pb = new ProcessBuilder(\""+exe+ ".exe\");\r\n\t\t\t\t\t\tpb.start();\r\n\t\t\t\t\t} catch (IOException ex) {\r\n\t\t\t\t\t\tex.printStackTrace();\r\n\t\t\t\t\t}\r\n                }";/*  
                if (button1.contains(e.getPoint())) {
                    try {
						ProcessBuilder pb = new ProcessBuilder("msgAsm.exe");
						pb.start();
					} catch (IOException ex) {
						ex.printStackTrace();
					}
                }




            */
            if (!JavaModules.ContainsKey("изо.переменая"))
            {
                JavaModules.Add("изо.переменая", new List<string>() { code2 });

            }
            else if (JavaModules.ContainsKey("изо.переменая")) JavaModules["изо.переменая"].Add(code2);
            if (!JavaModules.ContainsKey("изо.функция"))
            {
                JavaModules.Add("изо.функция", new List<string>() { code });

            }
            else if (JavaModules.ContainsKey("изо.функция")) JavaModules["изо.функция"].Add(code);
            if (!JavaModules.ContainsKey("изо.загрузка"))
            {
                JavaModules.Add("изо.загрузка", new List<string>() { code3 });

            }
            else if (JavaModules.ContainsKey("изо.загрузка")) JavaModules["изо.загрузка"].Add(code3);
            if (flag == "Button")
            {
                if (!JavaModules.ContainsKey("кноп.переменая"))
                {
                    JavaModules.Add("кноп.переменая", new List<string>() { code4 });

                }
                else if (JavaModules.ContainsKey("кноп.переменая")) JavaModules["кноп.переменая"].Add(code4);
                if (!JavaModules.ContainsKey("кноп.функция"))
                {
                    JavaModules.Add("кноп.функция", new List<string>() { code5 });

                }
                else if (JavaModules.ContainsKey("кноп.функция")) JavaModules["кноп.функция"].Add(code5);
            }
            else
            {
                if (!JavaModules.ContainsKey("кноп.переменая"))
                {
                    JavaModules.Add("кноп.переменая", new List<string>() {"//null\n"});
                }
                else if (JavaModules.ContainsKey("кноп.переменая")) JavaModules["кноп.переменая"].Add("//null\n");
                if (!JavaModules.ContainsKey("кноп.функция"))
                {
                    JavaModules.Add("кноп.функция", new List<string>() { "//null\n" });
                }
                else if (JavaModules.ContainsKey("кноп.функция")) JavaModules["кноп.функция"].Add("//null\n");
            }

        }
        private static string ToAsmUtf16(string text)
        {
            StringBuilder result = new StringBuilder();

            result.Append("dw ");

            int count = 0;

            foreach (char c in text)
            {
                result.Append($"{(int)c:X4}h");

                count++;

                if (count >= 12)
                {
                    result.Append("\r\n     dw ");
                    count = 0;
                }
                else
                {
                    result.Append(",");
                }
            }

            result.Append("0000h");

            return result.ToString();
        }
        private static Dictionary<string, string> JavaGen2(int w, int h, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                SendInFile("где имя окна");
            }

            Dictionary<string, string> codeGenjarorasm = new Dictionary<string, string>();
            string code = $"JFrame window = new JFrame(\"{name}\");\n";
            code += "window.setUndecorated(true);\r\n";
            code += $"window.setSize({w}, {h});\n";
            // WindowName dw 0412h,043Eh,0434h,0430h,0000h
            string converted = name;
            string codeasm1 = $"WindowName {ToAsmUtf16(converted)}\n";//конвертировать в 16 иричную асм переменую
           
            string codeasm2 = $"; Width\r\n" +
                $"    mov qword ptr [rsp+30h], {w}\r\n" +
                $"\r\n" +
                $"    ; Height\r\n" +
                $"    mov qword ptr [rsp+38h], {h}";
          
            codeGenjarorasm.Add(".java", code);
            codeGenjarorasm.Add(".asm1", codeasm1);
            codeGenjarorasm.Add(".asm2", codeasm2);
            return codeGenjarorasm;
        }
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string className, string windowName);
        public static int stato = 0;
        private static async void AsmBuild(string name)
        {
            for (int i00 = 0; i00 < 2; i00++)
            {
                if (i00 == 0)
                {

                    Directory.CreateDirectory(Path.GetDirectoryName(pach) + "\\temp\\" + "temp" + stato);
                    string tempPath = Path.Combine(Path.GetDirectoryName(pach), "temp\\" + "temp" + stato);
                    string asmPath = Path.Combine(Path.GetDirectoryName(pach), "temp\\" + "temp" + stato + "\\main.asm");
                    string objPath = Path.Combine(Path.GetDirectoryName(pach), "temp\\" + "temp" + stato + "\\main.obj");
                    string exePath = Path.Combine(Path.GetDirectoryName(pach), "temp\\" + "temp" + stato + "\\" + name + ".exe");

                    string AsmCode = "option casemap:none\r\n" +
                        "\r\n" +
                        "extrn GetModuleHandleW:proc\r\n" +
                        "extrn RegisterClassExW:proc\r\n" +
                        "extrn CreateWindowExW:proc\r\n" +
                        "extrn ShowWindow:proc\r\n" +
                        "extrn UpdateWindow:proc\r\n" +
                        "extrn GetMessageW:proc\r\n" +
                        "extrn TranslateMessage:proc\r\n" +
                        "extrn DispatchMessageW:proc\r\n" +
                        "extrn DefWindowProcW:proc\r\n" +
                        "extrn PostQuitMessage:proc\r\n" +
                        "extrn ExitProcess:proc\r\n" +
                        "extrn GetStockObject:proc\r\n" +
                        "\r\n" +
                        ".data\r\n" +
                        "\r\n" +
                        "; \"WaterWindow\" в UTF-16\r\n" +
                        "ClassName   dw 'W','a','t','e','r','W','i','n','d','o','w',0\r\n" +
                        "\r\n" +
                        "; \"Вода\"\r\n" +
                        $"{commandstest5}\r\n" +
                        "\r\n" +
                        "hInstance   dq 0\r\n" +
                        "hWindow     dq 0\r\n" +
                        "\r\n" +
                        "; WNDCLASSEXW = 80 bytes\r\n" +
                        "wc          db 80 dup(0)\r\n" +
                        "\r\n" +
                        "; MSG = 48 bytes\r\n" +
                        "msg         db 48 dup(0)\r\n" +
                        "\r\n" +
                        ".code\r\n" +
                        "\r\n" +
                        "WndProc proc\r\n" +
                        "\r\n" +
                        "    ; RCX = HWND\r\n" +
                        "    ; RDX = UINT\r\n" +
                        "    ; R8  = WPARAM\r\n" +
                        "    ; R9  = LPARAM\r\n" +
                        "\r\n" +
                        "    cmp edx, 2                  ; WM_DESTROY\r\n" +
                        "    je destroy\r\n" +
                        "\r\n" +
                        "    jmp DefWindowProcW\r\n" +
                        "\r\ndestroy:\r\n" +
                        "\r\n" +
                        "    xor ecx, ecx\r\n" +
                        "    call PostQuitMessage\r\n" +
                        "\r\n" +
                        "    xor eax, eax\r\n" +
                        "    ret\r\n" +
                        "\r\n" +
                        "WndProc endp\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "main proc\r\n" +
                        "\r\n" +
                        "    ; shadow space + stack\r\n" +
                        "    sub rsp, 58h\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "    ; ========================================\r\n" +
                        "    ; GetModuleHandleW(NULL)\r\n" +
                        "    ; ========================================\r\n" +
                        "\r\n" +
                        "    xor ecx, ecx\r\n" +
                        "    call GetModuleHandleW\r\n" +
                        "\r\n" +
                        "    mov hInstance, rax\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "    ; ========================================\r\n" +
                        "    ; WNDCLASSEXW\r\n" +
                        "    ; ========================================\r\n" +
                        "\r\n" +
                        "    ; cbSize\r\n" +
                        "    mov dword ptr [wc+0], 80\r\n" +
                        "\r\n" +
                        "    ; style = CS_HREDRAW | CS_VREDRAW\r\n" +
                        "    mov dword ptr [wc+4], 3\r\n" +
                        "\r\n" +
                        "    ; lpfnWndProc\r\n" +
                        "    lea rax, WndProc\r\n" +
                        "    mov qword ptr [wc+8], rax\r\n" +
                        "\r\n" +
                        "    ; cbClsExtra\r\n" +
                        "    mov dword ptr [wc+16], 0\r\n" +
                        "\r\n" +
                        "    ; cbWndExtra\r\n" +
                        "    mov dword ptr [wc+20], 0\r\n" +
                        "\r\n" +
                        "    ; hInstance\r\n" +
                        "    mov rax, hInstance\r\n" +
                        "    mov qword ptr [wc+24], rax\r\n" +
                        "\r\n" +
                        "    ; hIcon\r\n" +
                        "    mov qword ptr [wc+32], 0\r\n" +
                        "\r\n" +
                        "    ; hCursor\r\n" +
                        "    mov qword ptr [wc+40], 0\r\n" +
                        "\r\n" +
                        "    ; hbrBackground = BLACK_BRUSH\r\n" +
                        "    mov ecx, 4\r\n" +
                        "    call GetStockObject\r\n" +
                        "\r\n" +
                        "    mov qword ptr [wc+48], rax\r\n" +
                        "\r\n" +
                        "    ; lpszMenuName\r\n" +
                        "    mov qword ptr [wc+56], 0\r\n" +
                        "\r\n" +
                        "    ; lpszClassName\r\n" +
                        "    lea rax, ClassName\r\n" +
                        "    mov qword ptr [wc+64], rax\r\n" +
                        "\r\n" +
                        "    ; hIconSm\r\n" +
                        "    mov qword ptr [wc+72], 0\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "    ; ========================================\r\n" +
                        "    ; RegisterClassExW\r\n" +
                        "    ; ========================================\r\n" +
                        "\r\n" +
                        "    lea rcx, wc\r\n" +
                        "    call RegisterClassExW\r\n" +
                        "\r\n" +
                        "    test eax, eax\r\n" +
                        "    jz exit\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "    ; ========================================\r\n" +
                        "    ; CreateWindowExW\r\n" +
                        "    ; ========================================\r\n" +
                        "\r\n" +
                        "    xor ecx, ecx                ; dwExStyle\r\n" +
                        "\r\n" +
                        "    lea rdx, ClassName          ; lpClassName\r\n" +
                        "\r\n" +
                        "    lea r8, WindowName          ; lpWindowName\r\n" +
                        "\r\n" +
                        "    mov r9d, 00CF0000h          ; WS_OVERLAPPEDWINDOW\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "    ; X\r\n" +
                        "    mov qword ptr [rsp+20h], 100\r\n" +
                        "\r\n" +
                        "    ; Y\r\n" +
                        "    mov qword ptr [rsp+28h], 100\r\n" +
                        "\r\n" +
                        $"    {commandstest6}" +
                        "\r\n" +
                        "    ; hWndParent\r\n" +
                        "    mov qword ptr [rsp+40h], 0\r\n" +
                        "\r\n" +
                        "    ; hMenu\r\n" +
                        "    mov qword ptr [rsp+48h], 0\r\n" +
                        "\r\n" +
                        "    ; hInstance\r\n" +
                        "    mov rax, hInstance\r\n" +
                        "    mov qword ptr [rsp+50h], rax\r\n" +
                        "\r\n" +
                        "    ; lpParam\r\n" +
                        "    mov qword ptr [rsp+58h], 0\r\n" +
                        "\r\n" +
                        "    call CreateWindowExW\r\n" +
                        "\r\n" +
                        "    test rax, rax\r\n" +
                        "    jz exit\r\n" +
                        "\r\n" +
                        "    mov hWindow, rax\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "    ; ========================================\r\n" +
                        "    ; ShowWindow\r\n" +
                        "    ; ========================================\r\n" +
                        "\r\n" +
                        "    mov rcx, hWindow\r\n" +
                        "    mov edx, 5\r\n" +
                        "    call ShowWindow\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "    ; ========================================\r\n" +
                        "    ; UpdateWindow\r\n" +
                        "    ; ========================================\r\n" +
                        "\r\n" +
                        "    mov rcx, hWindow\r\n" +
                        "    call UpdateWindow\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "    ; ========================================\r\n" +
                        "    ; Message Loop\r\n" +
                        "    ; ========================================\r\n" +
                        "\r\n" +
                        "message_loop:\r\n" +
                        "\r\n" +
                        "    lea rcx, msg\r\n" +
                        "\r\n" +
                        "    xor edx, edx\r\n" +
                        "    xor r8d, r8d\r\n" +
                        "    xor r9d, r9d\r\n" +
                        "\r\n" +
                        "    call GetMessageW\r\n" +
                        "\r\n" +
                        "    ; WM_QUIT\r\n" +
                        "    test eax, eax\r\n" +
                        "    jz exit\r\n" +
                        "\r\n" +
                        "    ; ошибка\r\n" +
                        "    cmp eax, -1\r\n" +
                        "    je exit\r\n" +
                        "\r\n" +
                        "    lea rcx, msg\r\n" +
                        "    call TranslateMessage\r\n" +
                        "\r\n" +
                        "    lea rcx, msg\r\n" +
                        "    call DispatchMessageW\r\n" +
                        "\r\n" +
                        "    jmp message_loop\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "exit:\r\n" +
                        "\r\n" +
                        "    xor ecx, ecx\r\n" +
                        "    call ExitProcess\r\n" +
                        "\r\n" +
                        "main endp\r\n" +
                        "\r\n" +
                        "end";
                    if (ArgumentRuning != "без.сбоки")
                    {
                        File.WriteAllText(asmPath, AsmCode);

                        Console.WriteLine("ASM создан:");
                        Console.WriteLine(asmPath);
                        DirectoryInfo dif4 = new DirectoryInfo(@"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC");
                        string ml64 = "\"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\" + dif4.GetDirectories()[0] + @"\bin\Hostx64\x64\ml64.exe" + "\"";
                        string link = "\"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\" + dif4.GetDirectories()[0] + @"\bin\Hostx64\x64\link.exe" + "\"";
                        DirectoryInfo dif5 = new DirectoryInfo("C:\\Program Files (x86)\\Windows Kits\\10\\Lib");

                        //        string sdkLib =
                        //   @"C:\Program Files (x86)\Windows Kits\10\Lib\10.0.22621.0\um\x64";
                        // 1. MASM -> OBJ
                        string command = "/C " +
                $"cd /d \"{tempPath}\" && " +
                $"{ml64} /c \"{asmPath}\" /Fo\"{objPath}\"";
                        if (!RunWithRetry(
                             "cmd.exe",
                           command, objPath))
                        {
                            SendInFile("Ошибка сборки MASM");

                        }
                        string command2 = "/C " +
             $" cd /d \"{tempPath}\" && " +
             $"{link} /c \"{objPath}\" /SUBSYSTEM:WINDOWS /ENTRY:main " +
                            $"" +
                            "\"C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\" + dif5.GetDirectories()[0] + "\\um\\x64\\user32.lib\" " +
            "\"C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\" + dif5.GetDirectories()[0] + "\\um\\x64\\kernel32.lib\" " +
            "\"C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\" + dif5.GetDirectories()[0] + "\\um\\x64\\gdi32.lib\" " + $" /OUT:\"{exePath}\"";
                        // 2. OBJ -> EXE
                        if (!RunWithRetry(
                          "cmd.exe",
                            command2, exePath))
                        {
                            SendInFile("Ошибка линковки ASM");

                        }

                        Console.WriteLine("ASM УСПЕШНО СОБРАН:");
                        Console.WriteLine(exePath);
                    }

                    bool success = await RunWithRetryWin(
              $"{tempPath}\\{name}.exe", "",
              name,
              20
          );
                }
                if (i00 == 1)
                {
                    JavaModules = new Dictionary<string, List<string>>();
                    commandstest = "";
                    commandstest2 = "";
                    commandstest3 = "";
                    commandstest4 = "";
                    commandstest5 = "";
                    commandstest6 = "";
                    stato++;
                }
            }
        }
        private static async void AsmSysMsg(string name,string parcetext,string exe)
        {
          
            name = name.Replace("(п)", " ");
            name = name.Replace("(н)", "\n");
            parcetext = parcetext.Replace("(п)", " ");
            parcetext = parcetext.Replace("(н)", "\n");
            for (int i00 = 0; i00 < 2; i00++)
            {
                if (i00 == 0)
                {

                    Directory.CreateDirectory(Path.GetDirectoryName(pach) + "\\temp\\" + "temp" + stato);
                    string tempPath = Path.Combine(Path.GetDirectoryName(pach), "temp\\" + "temp" + stato);
                    string exeName = exe.Replace("/", "\\");
                    string exePath = Path.Combine(Path.GetDirectoryName(pach), exeName + ".exe");
                    string asmPath = Path.Combine(Path.GetDirectoryName(pach), "temp\\" + "temp" + stato + "\\main1.asm");
                    string objPath = Path.Combine(Path.GetDirectoryName(pach), "temp\\" + "temp" + stato + "\\main1.obj");
                  //  string exePath = Path.Combine(Path.GetDirectoryName(pach), "temp\\" + "temp" + stato + "\\" + exe + ".exe");

                    string AsmCode = "option casemap:none\r\n" +
                        "\r\n" +
                        "extern ExitProcess:proc\r\n" +
                        "extern MessageBoxW:proc\r\n" +
                        "\r\n" +
                        "PUBLIC main\r\n" +
                        "\r\n" +
                        ".data\r\n" +
                        "\r\n" +
                        $"text    {ToAsmUtf16(parcetext)}\r\n" +
                        "\r\n" +
                       $"caption {ToAsmUtf16(name)}"+
                        "\r\n" +
                        "wideBuf dw 25600 dup(0)\r\n" +
                        "\r\n" +
                        ".code\r\n" +
                        "\r\n" +
                        "CopyPartW proc\r\n" +
                        "\r\n" +
                        "copy_loop:\r\n" +
                        "\r\n" +
                        "    mov ax, word ptr [rsi]\r\n" +
                        "\r\n" +
                        "    test ax, ax\r\n" +
                        "    jz CopyEnd\r\n" +
                        "\r\n" +
                        "    mov word ptr [rdi], ax\r\n" +
                        "\r\n" +
                        "    add rsi, 2\r\n" +
                        "    add rdi, 2\r\n" +
                        "\r\n" +
                        "    jmp copy_loop\r\n" +
                        "\r\n" +
                        "CopyEnd:\r\n" +
                        "\r\n" +
                        "    ret\r\n" +
                        "\r\n" +
                        "CopyPartW endp\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "BuildText proc\r\n" +
                        "\r\n" +
                        "    push rsi\r\n" +
                        "    push rdi\r\n" +
                        "\r\n" +
                        "    mov rdi, rcx\r\n" +
                        "\r\n" +
                        "    lea rsi, text\r\n" +
                        "    call CopyPartW\r\n" +
                        "\r\n" +
                        "    mov word ptr [rdi], 0\r\n" +
                        "\r\n" +
                        "    pop rdi\r\n" +
                        "    pop rsi\r\n" +
                        "\r\n" +
                        "    ret\r\n" +
                        "\r\n" +
                        "BuildText endp\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "main proc\r\n" +
                        "\r\n" +
                        "    sub rsp, 28h\r\n" +
                        "\r\n" +
                        "    lea rcx, wideBuf\r\n" +
                        "    call BuildText\r\n" +
                        "\r\n" +
                        "    xor ecx, ecx\r\n" +
                        "    lea rdx, wideBuf\r\n" +
                        "    lea r8, caption\r\n" +
                        "    xor r9d, r9d\r\n" +
                        "\r\n" +
                        "    call MessageBoxW\r\n" +
                        "\r\n" +
                        "    xor ecx, ecx\r\n" +
                        "    call ExitProcess\r\n" +
                        "\r\n" +
                        "main endp\r\n" +
                        "\r\n" +
                        "end";
                    if (ArgumentRuning != "без.сбоки")
                    {
                        File.WriteAllText(asmPath, AsmCode);

                        Console.WriteLine("ASM создан:");
                        Console.WriteLine(asmPath);
                        DirectoryInfo dif4 = new DirectoryInfo(@"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC");
                        string ml64 = "\"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\" + dif4.GetDirectories()[0] + @"\bin\Hostx64\x64\ml64.exe" + "\"";
                        string link = "\"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\" + dif4.GetDirectories()[0] + @"\bin\Hostx64\x64\link.exe" + "\"";
                        DirectoryInfo dif5 = new DirectoryInfo("C:\\Program Files (x86)\\Windows Kits\\10\\Lib");

                        //        string sdkLib =
                        //   @"C:\Program Files (x86)\Windows Kits\10\Lib\10.0.22621.0\um\x64";
                        // 1. MASM -> OBJ
                        string command = "/C " +
                $"cd /d \"{tempPath}\" && " +
                $"{ml64} /c \"{asmPath}\" /Fo\"{objPath}\"";
                        if (!RunWithRetry(
                             "cmd.exe",
                           command, objPath))
                        {
                            SendInFile("Ошибка сборки MASM");

                        }
                        string command2 = "/C " +
        $"cd /d \"{tempPath}\" && " +
        $"{link} \"{objPath}\" " +
        "/SUBSYSTEM:WINDOWS /ENTRY:main " +
        $"\"C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\{dif5.GetDirectories()[0]}\\um\\x64\\user32.lib\" " +
        $"\"C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\{dif5.GetDirectories()[0]}\\um\\x64\\kernel32.lib\" " +
        $"/OUT:\"{exePath}\"";
                        // 2. OBJ -> EXE
                        if (!RunWithRetry(
                          "cmd.exe",
                            command2, exePath))
                        {
                            SendInFile("Ошибка линковки ASM");

                        }

                        Console.WriteLine("ASM УСПЕШНО СОБРАН:");
                        Console.WriteLine(exePath);
                    }

                 /*   bool success = await RunWithRetryWin(
               exePath,
    "",
    name,
              20
          );
                 */
                }
                if (i00 == 1)
                {
                    JavaModules = new Dictionary<string, List<string>>();
                    commandstest = "";
                    commandstest2 = "";
                    commandstest3 = "";
                    commandstest4 = "";
                    commandstest5 = "";
                    commandstest6 = "";
                    stato++;
                }
            }
        }
        private static async Task JavaGen3(string name, string result1, string result2,string winname,Dictionary<string,List<string>> modules)
        {
            string javapach = Path.GetDirectoryName(pach) + "\\temp\\temp" + stato + "\\Main.java";
            string folder = Path.GetDirectoryName(javapach);
            string jarPath = Path.Combine(folder, name + ".jar");
            string classPath = Path.Combine(folder, "Main.class");
            for (int i00 = 0; i00 < 2; i00++)
            {
                if (i00 == 0)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(pach) + "\\temp\\" + "temp" + stato);

                    if (ArgumentRuning != "без.сбоки")
                    {
                        List<string> Varible = modules["изо.переменая"];
                        List<string> Image = modules["изо.функция"];
                        List<string> Load = modules["изо.загрузка"];
                        List<string> Variblebut = modules["кноп.переменая"];
                        List<string> Button = modules["кноп.функция"];
                        string realVaribleCode = "\n";
                        string realImageCode = "\n";
                        string realLoadCode = "\n";
                        string realVariblebutCode = "\n";
                        string realButtonCode = "\n";

                        foreach (string item in Varible)
                        {
                            realVaribleCode += item;
                        }
                        foreach (string item in Image)
                        {
                            realImageCode += item;
                        }
                        foreach (string item in Load)
                        {
                            realLoadCode += item;
                        }
                        foreach (string item in Variblebut)
                        {
                            realVariblebutCode += item;
                        }
                        foreach (string item in Button)
                        {
                            realButtonCode += item;
                        }
                        string JavaButtonUse = "\t addMouseListener(new MouseAdapter() {\r\n" +
                            "\r\n" +
                            "            @Override\r\n" +
                            "            public void mousePressed(MouseEvent e) {\r\n" +
                           $"{realButtonCode}" +
                            "   if (button1.contains(e.getPoint())) {\r\n                    try {\r\n\t\t\t\t\t\tProcessBuilder pb = new ProcessBuilder(\"msgAsm.exe\");\r\n\t\t\t\t\t\tpb.start();\r\n\t\t\t\t\t} catch (IOException ex) {\r\n\t\t\t\t\t\tex.printStackTrace();\r\n\t\t\t\t\t}\r\n                }" +
                            "}\r\n" +
                            "        });";
                        string JavaBegin = "import javax.swing.*;\r\n" +
                            "import java.awt.*;\r\n" +
                            "import java.awt.event.*;\r\n" +
                            "import java.awt.image.BufferedImage;\r\n" +
                            "import javax.imageio.ImageIO;\r\n" +
                            "import java.io.File;\r\n" +
                            "import java.io.IOException;\r\n" +
                            "\r\n" +
                            "public class Main extends JPanel implements Runnable , KeyListener {\r\n" +
                            "private boolean running = true;\r\n" +
                            "\r\n" +
                           $"\r\n{realVaribleCode}" +
                            $"\r\n{realVariblebutCode}\r\n\tprivate Rectangle button1 = new Rectangle(115, -995, 60, 20);  private boolean up;\r\n    private boolean down;\r\n    private boolean left;\r\n    private boolean right;\r\n" +
                            " public Main() {\r\n" +
                            $"        setFocusable(true);\r\n" +
                            $"        addKeyListener(this);\r\n" +
                            $"\r\n" +
                            $"{realLoadCode} " +
                            "\r\n" +
                            "\r\n" +
                            $"{JavaButtonUse}" +/*
                "\t addMouseListener(new MouseAdapter() {\r\n" +///
                "\r\n" +
                "            @Override\r\n" +
                "            public void mousePressed(MouseEvent e) {\r\n"+
                $""+
                "  }\r\n" +
                "        });" +*/
                            "\r\n" +
                            "} " +
                            " \r\n" +
                            "@Override\r\n" +
                            "    protected void paintComponent(Graphics g) {\r\n" +
                            "        super.paintComponent(g);\r\n" +
                            "\r\n" +
                            "        Graphics2D g2 = (Graphics2D) g;\r\n" +
                            "//овал красный\r\n" +
                            $"{result1}\n{realImageCode}" +
                            "    }\r\n" +
                            " @Override\r\n" +
                            "    public void run() {\r\n" +
                            "\r\n" +
                            "        while (running) {\r\n" +
                            "\r\n" +
                            "           \r\n" +
                            "            repaint();\r\n" +
                            "\r\n" +
                            "            try {\r\n" +
                            "                Thread.sleep(16); // примерно 60 FPS\r\n" +
                            "            } catch (InterruptedException e) {\r\n" +
                            "                e.printStackTrace();\r\n" +
                            "            }\r\n" +
                            "        }\r\n" +
                            "    }\r\n" +
                            "\r\n" +
                            "\r\n   @Override\r\n    public void keyPressed(KeyEvent e) {\r\n\r\n        switch (e.getKeyCode()) {\r\n\r\n            case KeyEvent.VK_W -> up = true;\r\n            case KeyEvent.VK_S -> down = true;\r\n            case KeyEvent.VK_A -> left = true;\r\n            case KeyEvent.VK_D -> right = true;\r\n        }\r\n    }\r\n\r\n    @Override\r\n    public void keyReleased(KeyEvent e) {\r\n\r\n        switch (e.getKeyCode()) {\r\n\r\n            case KeyEvent.VK_W -> up = false;\r\n            case KeyEvent.VK_S -> down = false;\r\n            case KeyEvent.VK_A -> left = false;\r\n            case KeyEvent.VK_D -> right = false;\r\n        }\r\n    }\r\n\r\n    @Override\r\n    public void keyTyped(KeyEvent e) {\r\n    }" +
                            "    public static void main(String[] args) {\r\n" +
                            "\r\n" +
                            "//окно круги\r\n" +
                            $"{result2}" +
                            "\r\n" +
                            "        // Полноэкранный режим\r\n" +

                            "        //window.setExtendedState(JFrame.MAXIMIZED_BOTH);\r\n" +
                            "\r\n" +
                            "        window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);\r\n\t" +
                            "        \r\n" +
                            "        Main game = new Main();\r\n" +
                            "\r\n" +
                            "        window.add(game);\r\n" +
                            "        window.setVisible(true);\r\n" +
                            "\r\n" +
                            "        // Запуск игрового цикла\r\n" +
                            "        new Thread(game).start();\r\n" +
                            "\r\n" +
                            "        game.requestFocusInWindow();\r\n" +
                            "    }\r\n" +
                            "}\r\n" +
                            "";



                        Console.WriteLine(javapach + "\n" + JavaBegin);
                        File.WriteAllText(javapach, JavaBegin);
                    }
                    if (ArgumentRuning != "без.сбоки")
                    {
                        if (string.IsNullOrEmpty(name))
                        {
                            SendInFile("где имя ява.сборки");
                        }
                        RunWithRetry("javac", $"\"{javapach}\"", classPath, 20);
                        RunWithRetry("jar", $"cfe \"{jarPath}\" Main -C \"{folder}\" .", jarPath, 20);

                    }
                    bool success = await RunWithRetryWin(
                 "java",
                 $"-jar \"{jarPath}\"",
                 winname,
                 20
             );
                }
                if (i00 == 1)
                {


                    JavaModules = new Dictionary<string, List<string>>();
                    commandstest = "";
                    commandstest2 = "";
                    commandstest3 = "";
                    commandstest4 = "";
                    commandstest5 = "";
                    commandstest6 = "";
                    stato++;
                    if (!File.Exists(jarPath))
                    {
                        SendInFile("установите яву");
                    }
                }
            }
        }
        private static bool RunProcess(string fileName, string arguments)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Arguments = arguments;

                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.WorkingDirectory = Path.GetDirectoryName(pach);
                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(output))
                        Console.WriteLine(output);

                    if (!string.IsNullOrEmpty(error))
                        Console.WriteLine(error);

                    return process.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка запуска: " + ex.Message);
                return false;
            }
        }
        private static bool RunWithRetry(
    string fileName,
    string arguments,
    string expectedFile,
    int attempts = 20)
        {
            for (int i = 1; i <= attempts; i++)
            {
                try
                {
                    Console.WriteLine(
                        $"Попытка {i}/{attempts}: {fileName} {arguments}"
                    );

                    using (Process process = new Process())
                    {
                        process.StartInfo.FileName = fileName;
                        process.StartInfo.Arguments = arguments;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardError = true;
                        process.StartInfo.WorkingDirectory = Path.GetDirectoryName(pach);
                        process.Start();

                        string stdout = process.StandardOutput.ReadToEnd();
                        string stderr = process.StandardError.ReadToEnd();

                        process.WaitForExit();

                        if (!string.IsNullOrEmpty(stdout))
                            Console.WriteLine(stdout);

                        if (!string.IsNullOrEmpty(stderr))
                            Console.WriteLine(stderr);

                        // Проверяем результат
                        if (process.ExitCode == 0 &&
                            File.Exists(expectedFile))
                        {
                            Console.WriteLine("УСПЕШНО!");
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message + $" {arguments}");
                }

                Thread.Sleep(100);
            }

            Console.WriteLine(
                $"Не удалось выполнить {fileName} после {attempts} попыток."
            );

            return false;
        }
        private static async Task<bool> RunWithRetryWin(
       string fileName,
       string arguments,
       string expectedWinName,
       int attempts = 20)
        {
            for (int i = 1; i <= attempts; i++)
            {
                Process process = null;

                try
                {
                    Console.WriteLine($"Попытка {i}/{attempts}");

                    process = new Process();

                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Arguments = arguments;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    //Path.GetDirectoryName(pach)
                    process.StartInfo.WorkingDirectory = Path.GetDirectoryName(pach);
                    process.Start();

                    // Проверяем окно до 10 секунд
                    for (int t = 0; t < 100; t++)
                    {
                        await Task.Delay(1000);

                        IntPtr hwnd = FindWindow(null, expectedWinName);

                        if (hwnd != IntPtr.Zero)
                        {
                            Console.WriteLine("ОКНО НАЙДЕНО!");


                          
                            return true;
                        }

                        if (process.HasExited)
                            break;
                    }

                    // Окно не появилось
                    Console.WriteLine("Окно не найдено.");

                    if (!process.HasExited)
                    {
                    //    process.Kill();
                     //   await process.WaitForExitAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message + $" {arguments}");

                    try
                    {
                        if (process != null && !process.HasExited)
                        {
                            process.Kill();
                         ///   await process.WaitForExitAsync();
                        }
                    }
                    catch { }
                }
                finally
                {
                    process?.Dispose();
                }

                await Task.Delay(200);
            }

            return false;
        }
        public static List<string> _Window = new List<string>();
        public static List<string> _File = new List<string>();
        private static void SharpUpdate(string name, string file)
        {
            _Window.Add(name);
            _File.Add(Path.GetDirectoryName(pach) + $"\\{file}.txt");
            foreach (string item in Program._File)
            {
                if (!File.Exists(item)) SendInFile("нет такого файла как " + item);
            }
            if (name == file) SendInFile("имя онка которому выприципляете совпало с файлом настроек");
        }
        private static void JSUpdate(string name, int str)
        {
            //  Path.GetDirectoryName(pach) + "\\temp";
            Directory.CreateDirectory(Path.GetDirectoryName(pach) + "\\temp\\input");
            File.WriteAllText(Path.GetDirectoryName(pach) + "\\temp\\input\\" + name+".js", "*_Update_*\r\n" + obj[name] +"\r\n*_Update_*");
        }
    }
}
namespace Global
{
    public static class File
    {
        public static string ReadRegionText(string path, string region)
        {
            string text = System.IO.File.ReadAllText(path);

            string startMarker = $"*_{region}_*";
            string endMarker = startMarker;

            // Для твоего формата *_Mod1_*
            startMarker = $"*_{region}_*";

            int start = text.IndexOf(startMarker);

            if (start == -1)
                throw new Exception($"Регион '{region}' не найден.");

            start += startMarker.Length;

            int end = text.IndexOf(endMarker, start);

            if (end == -1)
                throw new Exception($"Конец региона '{region}' не найден.");

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
                throw new Exception($"Регион '{region}' не найден.");

            int contentStart = start + marker.Length;

            int end = text.IndexOf(marker, contentStart);

            if (end == -1)
                throw new Exception($"Конец региона '{region}' не найден.");

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
}