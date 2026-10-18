using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrinhoterUnauticnatems
{
    public partial class Form1 : Form
    {
        private bool takingScreenshot;

        private readonly string screenshotFileName;

        // Конструктор для дизайнера WinForms.
        public Form1() : this(null)
        {
        }

        public Form1(string fileName)
        {
            screenshotFileName = fileName;

            InitializeComponent();

            TopMost = true;

            MouseDown -= Form1_MouseDown;
            MouseDown += Form1_MouseDown;
        }

        private async void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || takingScreenshot)
                return;

            takingScreenshot = true;

            try
            {
                // Working path — текущая рабочая папка процесса.
                string folder = Directory.GetCurrentDirectory();
                string filename = string.IsNullOrWhiteSpace(screenshotFileName)
     ? $"Screenshot_{DateTime.Now:yyyy-MM-dd_HH-mm-ss-fff}.png"
     : screenshotFileName;

                filename = Path.ChangeExtension(filename, ".png");

                string path = Path.GetFullPath(
                    Path.Combine(Directory.GetCurrentDirectory(), filename));

            
                // Область внутри формы, без заголовка и рамки.
                Rectangle bounds = RectangleToScreen(ClientRectangle);

                Hide();
                await Task.Delay(250);

                using (var bitmap = new Bitmap(
                    bounds.Width,
                    bounds.Height,
                    PixelFormat.Format32bppArgb))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(
                            bounds.Left,
                            bounds.Top,
                            0,
                            0,
                            bounds.Size,
                            CopyPixelOperation.SourceCopy);
                    }

                    bitmap.Save(path, ImageFormat.Png);
                }

                Text = "Сохранено: " + path;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось сохранить скриншот:\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                takingScreenshot = false;

                if (!IsDisposed && !Disposing)
                    Show();
            }
        }
    }
}