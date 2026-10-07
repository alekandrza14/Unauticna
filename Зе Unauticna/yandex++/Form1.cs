using EO.Base;
using EO.WebBrowser;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EOMouseArgs = EO.Base.UI.MouseEventArgs;
using EOMouseButtons = EO.Base.UI.MouseButtons;

namespace yandex__
{
    public partial class Form1 : Form
    {
        private string webExePath;

        private System.Windows.Forms.Timer clipboardTimer;
        private string lastClipboardCommand = "";
        private PictureBox gameOutput;
        private System.Windows.Forms.Timer frameTimer;

        // JAR, который нужно запустить после появления окна
        private string pendingJarPath = null;

        public Form1(string filePath = null)
        {
            InitializeComponent();
           
            
            gameOutput = pictureBox1;
            gameOutput.SizeMode =
    PictureBoxSizeMode.Zoom;
               gameOutput.Dock = DockStyle.Fill;
            // gameOutput.Dock = DockStyle.Bottom;
            //  gameOutput.Location = new System.Drawing.Point(900,0);
            //  gameOutput.Size = new System.Drawing.Size(900,450);
            gameOutput.SizeMode = PictureBoxSizeMode.StretchImage;
            gameOutput.BackColor = System.Drawing.Color.Black;
            gameOutput.MouseMove += GameOutput_MouseMove;
            gameOutput.MouseDown += GameOutput_MouseDown;
            gameOutput.MouseUp += GameOutput_MouseUp;
            gameOutput.MouseWheel += GameOutput_MouseWheel;
            gameOutput.Size =
    new System.Drawing.Size(
        VisibleWidth,
        VisibleHeight
    );

            // Клавиатуру ловим на всей форме
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            this.Controls.Add(gameOutput);
         //   gameOutput.BringToFront();

            frameTimer = new System.Windows.Forms.Timer();
         //   frameTimer.Interval = 50; // примерно 30 FPS
           // frameTimer.Tick += FrameTimer_Tick;
          //  frameTimer.Start();
            webControl1.Size =
                new System.Drawing.Size(
                    Size.Width,
                    Size.Height + 30
                );

            this.Text = "yandex++";

            webExePath = filePath;

            // НЕ включаем глобальный костыль.
            webView2.DisableInputMsgRouting = false;

            // Только мышь отправляем напрямую в WebView.
            webView2.InputMsgFilter =
      new GameInputFilter(this);
            webView2.RequestPermissions += WebView2_RequestPermissions;

            webView2.JSInitCode =
                GetYandexFullscreenAdBlockScript();

            this.Shown += Form1_Shown;

            // ...
        

        // =========================================
        // Clipboard
        // =========================================

        clipboardTimer = new System.Windows.Forms.Timer();
            clipboardTimer.Interval = 200;
            clipboardTimer.Tick += ClipboardTimer_Tick;
            clipboardTimer.Start();

            // =========================================

            if (!string.IsNullOrEmpty(webExePath))
            {
                OpenWebExe(webExePath);
            }
            else
            {
                webView2.Url =
                    "https://yandex.ru/games/app/593983?draft=true&lang=ru";
            }
            pinWindowTimer =
    new System.Windows.Forms.Timer();

            pinWindowTimer.Interval = 50;

            pinWindowTimer.Tick +=
                PinWindowTimer_Tick;

            pinWindowTimer.Start();

        }
        private ClientWebSocket cdpSocket;
        private CancellationTokenSource cdpCancel;
        private int cdpCommandId = 100;
        private string pinOnWindowByName = null;
        private IntPtr pinnedWindow = IntPtr.Zero;

        private System.Windows.Forms.Timer pinWindowTimer;
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(
    string lpClassName,
    string lpWindowName
);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(
            IntPtr hWnd,
            out RECT lpRect
        );

        [DllImport("user32.dll")]
        private static extern bool IsWindow(
            IntPtr hWnd
        );

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        private async Task StartChromiumStream()
        {
            try
            {
                string wsUrl =
                    await GetCdpWebSocketUrl();

                if (string.IsNullOrEmpty(wsUrl))
                {
                    MessageBox.Show(
                        "CDP WebSocket не найден."
                    );

                    return;
                }

                cdpCancel =
                    new CancellationTokenSource();

                CancellationToken token =
                    cdpCancel.Token;

                cdpSocket =
                    new ClientWebSocket();

                await cdpSocket.ConnectAsync(
                    new Uri(wsUrl),
                    token
                );

                // Включаем Page domain
                await SendCdp(
                    "{" +
                    "\"id\":1," +
                    "\"method\":\"Page.enable\"" +
                    "}",
                    token
                );

                // Запускаем поток кадров.
                await SendCdp(
                    "{" +
                    "\"id\":2," +
                    "\"method\":\"Page.startScreencast\"," +
                    "\"params\":{" +
                        "\"format\":\"png\"," +
                        "\"quality\":85," +
                        "\"maxWidth\":1200," +
                        "\"maxHeight\":600," +
                        "\"everyNthFrame\":1" +
                    "}" +
                    "}",
                    token
                );

                Debug.WriteLine(
                    "[Yandex++] CDP screencast started"
                );

                while (!token.IsCancellationRequested)
                {
                    string message =
                        await ReceiveCdp(token);

                    if (message == null)
                        break;

                    if (!message.Contains(
                        "\"method\":\"Page.screencastFrame\""))
                    {
                        continue;
                    }

                    Match dataMatch =
                        Regex.Match(
                            message,
                            "\"data\"\\s*:\\s*\"([^\"]+)\""
                        );

                    Match sessionMatch =
                        Regex.Match(
                            message,
                            "\"sessionId\"\\s*:\\s*(\\d+)"
                        );

                    if (!dataMatch.Success ||
                        !sessionMatch.Success)
                    {
                        continue;
                    }

                    string base64 =
                        dataMatch.Groups[1].Value;

                    int sessionId =
                        int.Parse(
                            sessionMatch.Groups[1].Value
                        );

                    // ВАЖНО:
                    // Chromium ждёт подтверждение кадра.
                    int id = ++cdpCommandId;

                    await SendCdp(
                        "{" +
                        "\"id\":" + id + "," +
                        "\"method\":\"Page.screencastFrameAck\"," +
                        "\"params\":{" +
                            "\"sessionId\":" +
                            sessionId +
                        "}" +
                        "}",
                        token
                    );

                    byte[] imageBytes;

                    try
                    {
                        imageBytes =
                            Convert.FromBase64String(
                                base64
                            );
                    }
                    catch
                    {
                        continue;
                    }

                    Bitmap frame;

                    using (MemoryStream ms =
                           new MemoryStream(imageBytes))
                    using (Image image =
                           Image.FromStream(ms))
                    {
                        frame = CropBrowserFrame(image);
                    }

                    if (IsDisposed ||
                        !IsHandleCreated)
                    {
                        frame.Dispose();
                        break;
                    }

                    BeginInvoke(
                        new System.Action(() =>
                        {
                            if (gameOutput == null ||
                                gameOutput.IsDisposed)
                            {
                                frame.Dispose();
                                return;
                            }

                            Image old =
                                gameOutput.Image;

                            gameOutput.Image =
                                frame;

                            old?.Dispose();
                        })
                    );
                }
            }
            catch (OperationCanceledException)
            {
                // Нормально при закрытии программы.
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "CDP STREAM ERROR:\n" +
                    ex
                );
            }
        }
        private void Form1_FormClosing(
    object sender,
    FormClosingEventArgs e)
        {
            try
            {
                cdpCancel?.Cancel();

                if (cdpSocket != null)
                {
                    try
                    {
                        cdpSocket.Abort();
                        cdpSocket.Dispose();
                    }
                    catch
                    {
                    }
                }

                if (jarProcess != null &&
                    !jarProcess.HasExited)
                {
                    jarProcess.Kill();
                }
            }
            catch
            {
            }
        }
        private async Task<string> ReceiveCdp(
    CancellationToken token)
        {
            byte[] buffer =
                new byte[1024 * 1024];

            using (MemoryStream result =
                   new MemoryStream())
            {
                WebSocketReceiveResult receive;

                do
                {
                    receive =
                        await cdpSocket.ReceiveAsync(
                            new ArraySegment<byte>(buffer),
                            token
                        );

                    if (receive.MessageType ==
                        WebSocketMessageType.Close)
                    {
                        return null;
                    }

                    result.Write(
                        buffer,
                        0,
                        receive.Count
                    );
                }
                while (!receive.EndOfMessage);

                return Encoding.UTF8.GetString(
                    result.ToArray()
                );
            }
        }
        private async Task SendCdp(
    string json,
    CancellationToken token)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(json);

            await cdpSocket.SendAsync(
                new ArraySegment<byte>(bytes),
                WebSocketMessageType.Text,
                true,
                token
            );
        }
        private async Task<string> GetCdpWebSocketUrl()
        {
            using (WebClient client = new WebClient())
            {
                string json =
                    await client.DownloadStringTaskAsync(
                        "http://127.0.0.1:9222/json"
                    );

                MatchCollection matches =
                    Regex.Matches(
                        json,
                        "\"webSocketDebuggerUrl\"\\s*:\\s*\"([^\"]+)\""
                    );

                if (matches.Count == 0)
                    return null;

                return matches[0]
                    .Groups[1]
                    .Value
                    .Replace("\\/", "/");
            }
        }
        private async Task TestChromiumCapture()
        {
            try
            {
                string json;

                using (WebClient client = new WebClient())
                {
                    json =
                        await client.DownloadStringTaskAsync(
                            "http://127.0.0.1:9222/json"
                        );
                }

                Debug.WriteLine("CDP TARGETS:");
                Debug.WriteLine(json);

                // Берём debugger URL страницы Yandex Games.
                MatchCollection matches =
                    Regex.Matches(
                        json,
                        "\"webSocketDebuggerUrl\"\\s*:\\s*\"([^\"]+)\""
                    );

                if (matches.Count == 0)
                {
                    MessageBox.Show(
                        "CDP: webSocketDebuggerUrl не найден.\n\n" +
                        json
                    );

                    return;
                }

                string wsUrl =
                    matches[0]
                        .Groups[1]
                        .Value
                        .Replace("\\/", "/");

                Debug.WriteLine(
                    "CDP WebSocket: " +
                    wsUrl
                );

                using (ClientWebSocket socket =
                       new ClientWebSocket())
                {
                    await socket.ConnectAsync(
                        new Uri(wsUrl),
                        CancellationToken.None
                    );

                    string command =
                        "{" +
                        "\"id\":1," +
                        "\"method\":\"Page.captureScreenshot\"," +
                        "\"params\":{" +
                            "\"format\":\"png\"," +
                            "\"fromSurface\":true" +
                        "}" +
                        "}";

                    byte[] commandBytes =
                        Encoding.UTF8.GetBytes(command);

                    await socket.SendAsync(
                        new ArraySegment<byte>(commandBytes),
                        WebSocketMessageType.Text,
                        true,
                        CancellationToken.None
                    );

                    byte[] buffer =
                        new byte[8 * 1024 * 1024];

                    int total = 0;

                    WebSocketReceiveResult result;

                    do
                    {
                        result =
                            await socket.ReceiveAsync(
                                new ArraySegment<byte>(
                                    buffer,
                                    total,
                                    buffer.Length - total
                                ),
                                CancellationToken.None
                            );

                        total += result.Count;

                        if (total >= buffer.Length)
                            throw new Exception(
                                "CDP screenshot слишком большой."
                            );
                    }
                    while (!result.EndOfMessage);

                    string response =
                        Encoding.UTF8.GetString(
                            buffer,
                            0,
                            total
                        );

                    Match imageMatch =
                        Regex.Match(
                            response,
                            "\"data\"\\s*:\\s*\"([^\"]+)\""
                        );

                    if (!imageMatch.Success)
                    {
                        MessageBox.Show(
                            "CDP screenshot data не найден:\n\n" +
                            response
                        );

                        return;
                    }

                    string base64 =
                        imageMatch.Groups[1].Value;

                    byte[] png =
                        Convert.FromBase64String(base64);

                    using (MemoryStream stream = new MemoryStream(png))
                    using (Image image = Image.FromStream(stream))
                    {
                        Bitmap frame = CropBrowserFrame(image);

                        Image old = gameOutput.Image;
                        gameOutput.Image = frame;
                        old?.Dispose();
                    }

                    Debug.WriteLine(
                        "CDP CAPTURE OK: " +
                        png.Length +
                        " bytes"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "CDP capture error:\n\n" +
                    ex.ToString(),
                    "Yandex++"
                );
            }
        }
        private void GameOutput_MouseMove(
    object sender,
    System.Windows.Forms.MouseEventArgs e)
        {
            if (!OutputToBrowser(
                e.Location,
                out System.Drawing.Point p))
            {
                return;
            }

            webView2.SendMouseEvent(
                MouseEventType.Move,
                new EOMouseArgs(
                    ConvertMouseButton(e.Button),
                    0,
                    p.X,
                    p.Y,
                    0
                )
            );
        }
        private bool TryConvertKey(
    Keys key,
    out EO.WebBrowser.KeyCode eoKey)
        {
            switch (key)
            {
                case Keys.W:
                    eoKey = KeyCode.W;
                    gameOutput.Enabled = false;
                    return true;

                case Keys.A:
                    eoKey = KeyCode.A;
                    gameOutput.Enabled = true;
                    return true;

                case Keys.S:
                    eoKey = KeyCode.S;
                    return true;

                case Keys.D:
                    eoKey = KeyCode.D;
                    return true;

                case Keys.E:
                    eoKey = KeyCode.E;
                    return true;

                case Keys.Space:
                    eoKey = KeyCode.Space;
                    return true;

                case Keys.Escape:
                    eoKey = KeyCode.Escape;
                    return true;

                case Keys.ShiftKey:
                    eoKey = KeyCode.ShiftKey;
                    return true;

                case Keys.ControlKey:
                    eoKey = KeyCode.ControlKey;
                    return true;

                case Keys.Up:
                    eoKey = KeyCode.Up;
                    return true;

                case Keys.Down:
                    eoKey = KeyCode.Down;
                    return true;

                case Keys.Left:
                    eoKey = KeyCode.Left;
                    return true;

                case Keys.Right:
                    eoKey = KeyCode.Right;
                    return true;
            }

            eoKey = default;
            return false;
        }
        private void Form1_KeyDown(
    object sender,
    KeyEventArgs e)
        {
            if (TryConvertKey(
                e.KeyCode,
                out EO.WebBrowser.KeyCode key))
            {
                webView2.SendKeyEvent(true, key);

                e.Handled = true;
            }
        }

        private void Form1_KeyUp(
            object sender,
            KeyEventArgs e)
        {
            if (TryConvertKey(
                e.KeyCode,
                out EO.WebBrowser.KeyCode key))
            {
                webView2.SendKeyEvent(false, key);

                e.Handled = true;
            }
        }
        private void GameOutput_MouseDown(
            object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            if (!OutputToBrowser(
                e.Location,
                out System.Drawing.Point p))
            {
                return;
            }

            webView2.SetFocus();

            webView2.SendMouseEvent(
                MouseEventType.Down,
                new EOMouseArgs(
                    ConvertMouseButton(e.Button),
                    1,
                    p.X,
                    p.Y,
                    0
                )
            );
        }

        private void GameOutput_MouseUp(
            object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            if (!OutputToBrowser(
                e.Location,
                out System.Drawing.Point p))
            {
                return;
            }

            webView2.SendMouseEvent(
                MouseEventType.Up,
                new EOMouseArgs(
                    ConvertMouseButton(e.Button),
                    1,
                    p.X,
                    p.Y,
                    0
                )
            );
        }

        private void GameOutput_MouseWheel(
            object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            if (!OutputToBrowser(
                e.Location,
                out System.Drawing.Point p))
            {
                return;
            }

            webView2.SendMouseEvent(
                MouseEventType.Wheel,
                new EOMouseArgs(
                    EOMouseButtons.None,
                    0,
                    p.X,
                    p.Y,
                    e.Delta
                )
            );
        }
        private EOMouseButtons ConvertMouseButton(
    System.Windows.Forms.MouseButtons button)
        {
            switch (button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    return EOMouseButtons.Left;

                case System.Windows.Forms.MouseButtons.Right:
                    return EOMouseButtons.Right;

                case System.Windows.Forms.MouseButtons.Middle:
                    return EOMouseButtons.Middle;

                case System.Windows.Forms.MouseButtons.XButton1:
                    return EOMouseButtons.XButton1;

                case System.Windows.Forms.MouseButtons.XButton2:
                    return EOMouseButtons.XButton2;

                default:
                    return EOMouseButtons.None;
            }
        }
        [DllImport("user32.dll")]
        private static extern bool PrintWindow(
    IntPtr hwnd,
    IntPtr hdcBlt,
    uint nFlags
);

        private const uint PW_RENDERFULLCONTENT = 0x00000002;
        private bool OutputToBrowser(
       System.Drawing.Point mouse,
       out System.Drawing.Point browserPoint)
        {
            browserPoint = System.Drawing.Point.Empty;

            int controlWidth = gameOutput.ClientSize.Width;
            int controlHeight = gameOutput.ClientSize.Height;

            if (controlWidth <= 0 || controlHeight <= 0)
                return false;

            float visibleAspect =
                VisibleWidth / (float)VisibleHeight;

            float controlAspect =
                controlWidth / (float)controlHeight;

            float drawWidth;
            float drawHeight;
            float offsetX;
            float offsetY;

            if (controlAspect > visibleAspect)
            {
                // Поля слева и справа
                drawHeight = controlHeight;
                drawWidth = drawHeight * visibleAspect;

                offsetX =
                    (controlWidth - drawWidth) * 0.5f;

                offsetY = 0;
            }
            else
            {
                // Поля сверху и снизу
                drawWidth = controlWidth;
                drawHeight = drawWidth / visibleAspect;

                offsetX = 0;

                offsetY =
                    (controlHeight - drawHeight) * 0.5f;
            }

            if (mouse.X < offsetX ||
                mouse.Y < offsetY ||
                mouse.X >= offsetX + drawWidth ||
                mouse.Y >= offsetY + drawHeight)
            {
                return false;
            }

            float normalizedX =
                (mouse.X - offsetX) / drawWidth;

            float normalizedY =
                (mouse.Y - offsetY) / drawHeight;

            // Координаты внутри ОБРЕЗАННОЙ области
            int visibleX =
                (int)(normalizedX * VisibleWidth);

            int visibleY =
                (int)(normalizedY * VisibleHeight);

            visibleX = Math.Max(
                0,
                Math.Min(VisibleWidth - 1, visibleX)
            );

            visibleY = Math.Max(
                0,
                Math.Min(VisibleHeight - 1, visibleY)
            );

            // Переводим обратно в координаты полного браузерного кадра
            int browserX = CropLeft + visibleX;
            int browserY = CropTop + visibleY;

            browserPoint =
                new System.Drawing.Point(
                    browserX,
                    browserY
                );

            return true;
        }
        private const int BrowserWidth = 1200;
        private const int BrowserHeight = 600;

        private const int CropLeft = 0;
        private const int CropTop = 30;
        private const int CropRight = 161;
        private const int CropBottom = 0;

        private const int VisibleWidth =
            BrowserWidth - CropLeft - CropRight;

        private const int VisibleHeight =
            BrowserHeight - CropTop - CropBottom;
        private Bitmap CropBrowserFrame(Image source)
        {
            int width =
                source.Width - CropLeft - CropRight;

            int height =
                source.Height - CropTop - CropBottom;

            if (width <= 0 || height <= 0)
                throw new InvalidOperationException(
                    "Неверные размеры crop области."
                );

            Rectangle srcRect =
                new Rectangle(
                    CropLeft,
                    CropTop,
                    width,
                    height
                );

            Bitmap cropped =
                new Bitmap(
                    srcRect.Width,
                    srcRect.Height,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb
                );

            using (Graphics g = Graphics.FromImage(cropped))
            {
                g.DrawImage(
                    source,
                    new Rectangle(0, 0, cropped.Width, cropped.Height),
                    srcRect,
                    GraphicsUnit.Pixel
                );
            }

            return cropped;
        }
        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (webControl1.Width <= 0 ||
                    webControl1.Height <= 0)
                    return;

                Bitmap frame =
                    new Bitmap(
                        BrowserWidth,
                        BrowserHeight,
                        System.Drawing.Imaging.PixelFormat.Format32bppArgb
                    );

                using (Graphics g = Graphics.FromImage(frame))
                {
                    IntPtr hdc = g.GetHdc();

                    try
                    {
                        PrintWindow(
                            webControl1.Handle,
                            hdc,
                            PW_RENDERFULLCONTENT
                        );
                    }
                    finally
                    {
                        g.ReleaseHdc(hdc);
                    }
                }

                Image old = gameOutput.Image;

                gameOutput.Image = frame;

                old?.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "PrintWindow capture error: " +
                    ex.Message
                );
            }
        }
        private const int GameRenderWidth = 1920;
        private const int GameRenderHeight = 1080;
        private System.Drawing.Point ScreenToGame(
    System.Drawing.Point mouse)
        {
            float scaleX =
                (float)GameRenderWidth /
                gameOutput.ClientSize.Width;

            float scaleY =
                (float)GameRenderHeight /
                gameOutput.ClientSize.Height;

            return new System.Drawing.Point(
                (int)(mouse.X * scaleX),
                (int)(mouse.Y * scaleY)
            );
        }
        private string GetYandexFullscreenAdBlockScript()
        {
            return @"
(function()
{
    'use strict';

    if (window.__unauticnaFullscreenBlockInstalled)
        return;

    window.__unauticnaFullscreenBlockInstalled = true;
    window.__unauticnaBlockFullscreenAds = true;

    console.log(
        '[yandex++] Fullscreen ad blocker loaded'
    );


    // =====================================================
    // Подменяем конкретный объект YSDK
    // =====================================================

    function patchSdk(sdk)
    {
        try
        {
            if (!sdk)
                return sdk;

            if (!sdk.adv)
                return sdk;

            if (sdk.adv.__unauticnaPatched)
                return sdk;

            sdk.adv.__unauticnaPatched = true;


            // -------------------------------------------------
            // Сохраняем оригинальную fullscreen рекламу
            // -------------------------------------------------

            const originalFullscreen =
                sdk.adv.showFullscreenAdv;


            sdk.adv.__unauticnaOriginalFullscreenAdv =
                originalFullscreen;


            // -------------------------------------------------
            // Подменяем ТОЛЬКО showFullscreenAdv
            // -------------------------------------------------

            sdk.adv.showFullscreenAdv =
                function(options)
                {
                    if (!window.__unauticnaBlockFullscreenAds)
                    {
                        if (typeof originalFullscreen === 'function')
                        {
                            return originalFullscreen.apply(
                                sdk.adv,
                                arguments
                            );
                        }

                        return;
                    }


                    console.log(
                        '[yandex++] FULLSCREEN AD BLOCKED'
                    );


                    /*
                     * Yandex сообщает игре:
                     * реклама закрылась / не была показана.
                     *
                     * wasShown = false
                     */

                    setTimeout(function()
                    {
                        try
                        {
                            if (
                                options &&
                                options.callbacks &&
                                typeof options.callbacks.onClose ===
                                    'function'
                            )
                            {
                                options.callbacks.onClose(false);
                            }
                        }
                        catch (e)
                        {
                            console.error(
                                '[yandex++] onClose error:',
                                e
                            );
                        }

                    }, 0);
                };


            /*
             * ВАЖНО:
             *
             * showRewardedVideo НЕ МЕНЯЕМ.
             *
             * Поэтому реклама за награду
             * продолжит работать.
             */


            console.log(
                '[yandex++] YSDK fullscreen patched'
            );

        }
        catch (e)
        {
            console.error(
                '[yandex++] patchSdk error:',
                e
            );
        }

        return sdk;
    }


    // =====================================================
    // Патчим YaGames.init()
    // =====================================================

    function patchYaGames(yaGames)
    {
        try
        {
            if (!yaGames)
                return yaGames;

            if (yaGames.__unauticnaPatched)
                return yaGames;

            if (typeof yaGames.init !== 'function')
                return yaGames;


            yaGames.__unauticnaPatched = true;

            const originalInit =
                yaGames.init;


            yaGames.init =
                function()
                {
                    const result =
                        originalInit.apply(
                            this,
                            arguments
                        );


                    // -----------------------------------------
                    // Promise
                    // -----------------------------------------

                    if (
                        result &&
                        typeof result.then === 'function'
                    )
                    {
                        return result.then(
                            function(sdk)
                            {
                                return patchSdk(sdk);
                            }
                        );
                    }


                    // -----------------------------------------
                    // Синхронный вариант
                    // -----------------------------------------

                    return patchSdk(result);
                };


            console.log(
                '[yandex++] YaGames.init patched'
            );
        }
        catch (e)
        {
            console.error(
                '[yandex++] patchYaGames error:',
                e
            );
        }

        return yaGames;
    }


    // =====================================================
    // Если YaGames уже существует
    // =====================================================

    if (window.YaGames)
    {
        patchYaGames(window.YaGames);
    }


    // =====================================================
    // Следим за появлением SDK
    // =====================================================

    const timer =
        setInterval(function()
        {
            try
            {
                if (window.YaGames)
                {
                    patchYaGames(
                        window.YaGames
                    );
                }
            }
            catch (e)
            {
            }

        }, 10);


    // На всякий случай не оставляем таймер навечно
    setTimeout(function()
    {
        clearInterval(timer);

    }, 60000);

})();
";
        }
        private void InstallAdCleaner()
        {
            try
            {
                string js = @"
(function()
{
    if (window.__unauticnaAdCleanerInstalled)
        return;

    window.__unauticnaAdCleanerInstalled = true;

    function removeAds()
    {
        const selectors = [
            'iframe[src*=""yandexadexchange""]',
            'iframe[src*=""adfox""]',
            'iframe[src*=""an.yandex.ru""]',
            'iframe[src*=""banner.bidder.ru""]',

            'iframe[src*=""doubleclick.net""]',
            'iframe[src*=""googlesyndication.com""]',

            'div[id^=""adfox_""]'
        ];

        for (const selector of selectors)
        {
            document
                .querySelectorAll(selector)
                .forEach(function(element)
                {
                    try
                    {
                        console.log(
                            '[Unauticna AdBlock] removed:',
                            element
                        );

                        element.remove();
                    }
                    catch(e)
                    {
                    }
                });
        }
    }

    removeAds();

    const observer =
        new MutationObserver(function()
        {
            removeAds();
        });

    observer.observe(
        document.documentElement,
        {
            childList: true,
            subtree: true
        }
    );
})();
";

                webView2.QueueScriptTask(js);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "[AD CLEANER ERROR] " +
                    ex.Message
                );
            }
        }
        private static readonly string[] BlockedAdDomains =
        {
    // Yandex Advertising Network
    "an.yandex.ru",
    "yandexadexchange.net",
    "adfox.ru",
    "banner.bidder.ru",

    // Внешняя реклама, которая может приходить через Yandex
    "doubleclick.net",
    "googlesyndication.com",
    "googleadservices.com"
};

        private void WebView2_BeforeRequestLoad(
            object sender,
            BeforeRequestLoadEventArgs e)
        {
            try
            {
                if (e.Request == null)
                    return;

                string url = e.Request.Url;

                if (string.IsNullOrWhiteSpace(url))
                    return;

                if (IsAdUrl(url))
                {
                    Debug.WriteLine(
                        "[ADBLOCK] BLOCKED: " + url
                    );

                    e.Canceled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "[ADBLOCK ERROR] " +
                    ex.Message
                );
            }
        }


        private bool IsAdUrl(string url)
        {
            Uri uri;

            if (!Uri.TryCreate(
                url,
                UriKind.Absolute,
                out uri))
            {
                return false;
            }

            string host =
                uri.Host.ToLowerInvariant();

            foreach (string domain in BlockedAdDomains)
            {
                if (host.Equals(
                        domain,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (host.EndsWith(
                        "." + domain,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        // ============================================================
        // ПОСЛЕ ПОЯВЛЕНИЯ ОКНА
        // ============================================================
        private Process jarProcess;
        private async void Form1_Shown(
     object sender, EventArgs e)
        {

            LimitWindowSize();

            UpdateWebControlSize();

            if (!string.IsNullOrEmpty(pendingJarPath))
            {
                RunJar(pendingJarPath);
            }

            await Task.Delay(8000);

            await TestChromiumCapture();
            _ = StartChromiumStream();
            // SetupWebControl();
        }

        // ============================================================
        // ЗАПУСК JAR
        // ============================================================
        private void RunJar(string jarPath)
        {
            try
            {
                if (!File.Exists(jarPath))
                {
                    MessageBox.Show(
                        "JAR не найден:\n\n" + jarPath,
                        "web_exe",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                int parentPid =
                    Process.GetCurrentProcess().Id;

                ProcessStartInfo psi =
                    new ProcessStartInfo();

                psi.FileName = "javaw.exe";

                psi.Arguments =
                    "-jar \"" +
                    jarPath +
                    "\" " +
                    parentPid;

                psi.WorkingDirectory =
                    Path.GetDirectoryName(jarPath);

                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                jarProcess =
                    Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось запустить JAR:\n\n" +
                    ex.Message,
                    "ControlWindow.jar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

       // public System.Windows.Forms.Timer clipboardTimer;
     //   public string lastClipboardCommand = "";
        // ============================================================
        // .web_exe
        // ============================================================
        public string Dev;

        int rightsLevel = 1;
        private int ParseYandexRights(string rights)
        {
            if (string.IsNullOrWhiteSpace(rights))
                return 0;

            rights = rights.Trim();

            // Старый / level1 вариант
            if (rights == "Yandex++ Rigths Active")
                return 1;

            const string prefix =
                "Yandex++ Rigths lvl ";

            const string suffix =
                " Active";

            if (!rights.StartsWith(prefix) ||
                !rights.EndsWith(suffix))
            {
                return 0;
            }

            string levelText =
                rights.Substring(
                    prefix.Length,
                    rights.Length -
                    prefix.Length -
                    suffix.Length
                );

            if (int.TryParse(
                levelText,
                out int level) &&
                level > 0)
            {
                return level;
            }

            return 0;
        }
        private void OpenWebExe(string path)
        {
            try
            {
                path = Path.GetFullPath(path);

                string localPath =
                    Path.GetDirectoryName(path);

                string[] lines =
                    File.ReadAllLines(
                        path,
                        Encoding.UTF8
                    );

                string url = null;
                string jar = null;
                string clipboardText = null;
                string developerCode = null;

                foreach (string line in lines)
                {
                    if (line.StartsWith("url="))
                    {
                        url = line.Substring(
                            "url=".Length
                        );
                    }

                    else if (line.StartsWith("jar="))
                    {
                        jar = line.Substring(
                            "jar=".Length
                        );
                    }

                    else if (line.StartsWith("clipboard="))
                    {
                        clipboardText =
                            line.Substring(
                                "clipboard=".Length
                            );
                    }

                    else if (line.StartsWith("developer_code="))
                    {
                        developerCode =
                            line.Substring(
                                "developer_code=".Length
                            );
                    }

                    else if (line.StartsWith(
    "YG++Rigths=level",
    StringComparison.OrdinalIgnoreCase))
                    {
                        string levelText =
                            line.Substring("YG++Rigths=level".Length)
                                .Trim();

                        if (int.TryParse(levelText, out int parsedLevel) &&
                            parsedLevel > 0)
                        {
                            rightsLevel = parsedLevel;
                        }
                    }
                    else if (line.StartsWith(
    "PinOnWindowByName=",
    StringComparison.OrdinalIgnoreCase))
                    {
                        pinOnWindowByName =
                            line.Substring(
                                "PinOnWindowByName=".Length
                            ).Trim();

                        Console.WriteLine(
                            "[PIN WINDOW] Target: " +
                            pinOnWindowByName
                        );
                    }
                }

                // ===================================================
                // JAR
                // ===================================================

                if (!string.IsNullOrWhiteSpace(jar) &&
                    !jar.Equals(
                        "null",
                        StringComparison.OrdinalIgnoreCase
                    ))
                {
                    jar = jar.Trim();

                    // [localPath]
                    // превращаем в папку самого .web_exe
                    jar = jar.Replace(
                        "[localPath]",
                        localPath
                    );

                    // / -> \
                    jar = jar.Replace(
                        '/',
                        Path.DirectorySeparatorChar
                    );

                    pendingJarPath =
                        Path.GetFullPath(jar);
                }

                // ===================================================
                // CLIPBOARD
                // ===================================================

                if (!string.IsNullOrEmpty(clipboardText))
                {
                    System.Windows.Forms.Clipboard.SetText(
                        clipboardText
                    );
                }
                else if (!string.IsNullOrEmpty(developerCode))
                {
                    string rightsMessage;

                    if (rightsLevel <= 1)
                    {
                        rightsMessage =
                            "Yandex++ Rigths Active";
                    }
                    else
                    {
                        rightsMessage =
                            "Yandex++ Rigths lvl " +
                            rightsLevel +
                            " Active";
                    }

                    System.Windows.Forms.Clipboard.SetText(
                        rightsMessage
                    );

                    Dev = developerCode;

                    Debug.WriteLine(
                        "[Yandex++] Rights level: " +
                        rightsLevel +
                        " -> " +
                        rightsMessage
                    );
                }
                else if (String.IsNullOrEmpty(Dev))
                {
                    button1.Location = new System.Drawing.Point(-1000000, -1000000);
                }
                //Contrl+v
                // ===================================================
                // URL
                // ===================================================

                if (!string.IsNullOrEmpty(url))
                {
                    webView2.Url = url;
                }
                else
                {
                    MessageBox.Show(
                        "В файле нет url=",
                        "web_exe",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка открытия .web_exe:\n\n" +
                    ex.Message,
                    "web_exe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void PinWindowTimer_Tick(
    object sender,
    EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    pinOnWindowByName))
                {
                    return;
                }

                // Если окно ещё не найдено
                // или старый HWND уже уничтожен.
                if (pinnedWindow == IntPtr.Zero ||
                    !IsWindow(pinnedWindow))
                {
                    pinnedWindow =
                        FindWindow(
                            null,
                            pinOnWindowByName
                        );

                    if (pinnedWindow == IntPtr.Zero)
                    {
                        Console.WriteLine(
                            "[PIN WINDOW] Waiting: " +
                            pinOnWindowByName
                        );

                        return;
                    }

                    Console.WriteLine(
                        "[PIN WINDOW] FOUND: " +
                        pinOnWindowByName
                    );
                }

                if (!GetWindowRect(
                    pinnedWindow,
                    out RECT rect))
                {
                    return;
                }

                int width =
                    rect.Right - rect.Left;

                int height =
                    rect.Bottom - rect.Top;

                // Как в AttachHDRPWindow:
                // убираем рамку родительского окна.
                int x = rect.Left + 8;
                int y = rect.Top + 30;

                int w = width - 16;
                int h = height - 38;

                if (w <= 0 || h <= 0)
                    return;

                // Чтобы не вызывать лишний Resize каждый тик.
                if (this.Left != x ||
                    this.Top != y ||
                    this.Width != w ||
                    this.Height != h)
                {
                    this.Bounds =
                        new Rectangle(
                            x,
                            y,
                            w,
                            h
                        );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "[PIN WINDOW ERROR] " +
                    ex.Message
                );
            }
        }
        // ============================================================
        // CLIPBOARD COMMANDS
        // ============================================================
        private void ExecuteReadFile(string command)
        {
            try
            {
                const string prefix = "ReadFile(";

                int closeBracket = command.IndexOf(
                    ')',
                    prefix.Length
                );

                if (closeBracket == -1)
                    return;

                string originalPath = command.Substring(
                    prefix.Length,
                    closeBracket - prefix.Length
                );

                originalPath = originalPath.Trim();

                string path =
                    originalPath.Replace('/', '\\');

                string content = "";

                if (File.Exists(path))
                {
                    content = File.ReadAllText(
                        path,
                        Encoding.UTF8
                    );
                }

                string answer =
                    "ReadedFile(" +
                    originalPath +
                    ")," +
                    content;

                Clipboard.SetText(answer);

                // Важно:
                // чтобы ответ ReadedFile(...) не блокировал
                // следующую команду Unity.
                lastClipboardCommand = answer;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "ReadFile error: " +
                    ex.Message
                );
            }
        }
        private void ExecuteDeleteFile(string command)
        {
            try
            {
                const string prefix = "DeleteFile(";

                int closeBracket = command.IndexOf(
                    ')',
                    prefix.Length
                );

                if (closeBracket == -1)
                    return;

                string path = command.Substring(
                    prefix.Length,
                    closeBracket - prefix.Length
                );

                path = path
                    .Trim()
                    .Replace('/', '\\');

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                Clipboard.SetText(
                    "DeletedFile(" +
                    path.Replace('\\', '/') +
                    ")"
                );
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "DeleteFile error: " +
                    ex.Message
                );
            }
        }

        private void ClipboardTimer_Tick(
    object sender,
    EventArgs e)
        {
            try
            {
                if (!Clipboard.ContainsText())
                    return;

                string text = Clipboard.GetText();

                if (string.IsNullOrWhiteSpace(text))
                    return;

                if (text == lastClipboardCommand)
                    return;

                if (text.StartsWith("WriteFile("))
                {
                    lastClipboardCommand = text;
                    ExecuteWriteFile(text);
                }
                else if (text.StartsWith("ReadFile("))
                {
                    lastClipboardCommand = text;
                    ExecuteReadFile(text);
                }
                else if (text.StartsWith("DeleteFile("))
                {
                    lastClipboardCommand = text;
                    ExecuteDeleteFile(text);
                }
                else if (text.StartsWith("OpenJar("))
                {
                    lastClipboardCommand = text;
                    ExecuteOpenJar(text);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "Clipboard error: " +
                    ex.Message
                );
            }
        }
        private void ExecuteOpenJar(string command)
        {
            try
            {
                const string prefix = "OpenJar(";

                int closeBracket = command.IndexOf(
                    ')',
                    prefix.Length
                );

                if (closeBracket == -1)
                    return;

                string jarPath = command.Substring(
                    prefix.Length,
                    closeBracket - prefix.Length
                );

                jarPath = jarPath.Trim();

                string localPath1 = Path.GetFullPath(webExePath);

                string localPath =
                Path.GetDirectoryName(localPath1);
                // Поддержка [LocalPach]
                jarPath = jarPath.Replace(
                    "[LocalPach]",
                    localPath
                );

                // И на всякий случай правильный вариант написания
                jarPath = jarPath.Replace(
                    "[LocalPath]",
                  localPath
                );

                jarPath = jarPath.Replace(
                    '/',
                    Path.DirectorySeparatorChar
                );

                jarPath = Path.GetFullPath(jarPath);

                RunJar(jarPath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "OpenJar error: " +
                    ex.Message
                );
            }
        }

        private void ExecuteWriteFile(string command)
        {
            try
            {
                const string prefix = "WriteFile(";

                int closeBracket =
                    command.IndexOf(
                        ')',
                        prefix.Length
                    );

                if (closeBracket == -1)
                    return;

                string path =
                    command.Substring(
                        prefix.Length,
                        closeBracket -
                        prefix.Length
                    );

                path = path.Trim();

                string data =
                    command.Substring(
                        closeBracket + 1
                    );

                if (data.StartsWith(","))
                {
                    data =
                        data.Substring(1);
                }

                path =
                    path.Replace('/', '\\');

                if (string.IsNullOrWhiteSpace(path))
                    return;

                string directory =
                    Path.GetDirectoryName(path);

                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(
                        directory
                    );
                }

                File.WriteAllText(
                    path,
                    data,
                    Encoding.UTF8
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка WriteFile:\n\n" +
                    ex.Message,
                    "Unauticna WebExe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // EO
        // ============================================================

        private void WebView2_RequestPermissions(
            object sender,
            RequestPermissionEventArgs e)
        {
            if ((e.Permissions &
                 Permissions.Clipboard) != 0)
            {
                e.Allow();
                return;
            }

            e.Deny();
        }

        private void Form1_Load(
            object sender,
            EventArgs e)
        {
           
        }

        private void webControl1_Click(
            object sender,
            EventArgs e)
        {
        }

        private void webBrowser1_DocumentCompleted(
            object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void axWebBrowser1_Enter(
            object sender,
            EventArgs e)
        {
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           
          //  webControl1.Dock = DockStyle.None;
          //  webControl1.Location = new System.Drawing.Point(-161, -30);
          //
          //  webControl1.Size = new System.Drawing.Size(
          //      this.ClientSize.Width + (161 * 2),
          //      this.ClientSize.Height + 60 + 109
          //  );

        }
        private const int VirtualWidth = 25600;
        private const int VirtualHeight = 14400;
        private const int WebOffsetX = 161;
        private const int WebOffsetY = 30;
        private const int WebExtraHeight = 30 + 109;

        private void UpdateWebControlSize()
        {
            webControl1.Dock = DockStyle.None;

            // webControl1.Location =
            //      new System.Drawing.Point(
            //         -0,
            //        -WebOffsetY
            //    );

            // webControl1.Size =
            //     new System.Drawing.Size(
            //        this.ClientSize.Width + WebOffsetX,
            //      this.ClientSize.Height + WebExtraHeight
            //  );
      //      webControl1.Location =
//  new System.Drawing.Point(
  //    0,
  //    0
//  );

            webControl1.Size =
                new System.Drawing.Size(
                    BrowserWidth,BrowserHeight
                    
                );
        }

        private System.Drawing.Size GetMaximumScreenResolution()
        {
            int maxWidth = 0;
            int maxHeight = 0;

            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Bounds.Width > maxWidth)
                    maxWidth = screen.Bounds.Width;

                if (screen.Bounds.Height > maxHeight)
                    maxHeight = screen.Bounds.Height;
            }

            return new System.Drawing.Size(
                maxWidth,
                maxHeight
            );
        }

        private void LimitWindowSize()
        {
            /*
            System.Drawing.Size screen =
                GetMaximumScreenResolution();

            int maxClientWidth =
                screen.Width - WebOffsetX * 2;

            int maxClientHeight =
                screen.Height - WebExtraHeight;

            // На всякий случай
            maxClientWidth =
                Math.Max(320, maxClientWidth);

            maxClientHeight =
                Math.Max(240, maxClientHeight);

            
             * MaximumSize относится ко всему окну,
             * включая рамку и заголовок.
             *
             * SizeFromClientSize автоматически
             * добавит размер рамок WinForms.
             
            this.MaximumSize =
                this.SizeFromClientSize(
                    new System.Drawing.Size(
                        maxClientWidth,
                        maxClientHeight
                    )
                );

            Console.WriteLine(
                "Maximum screen: " +
                screen.Width +
                "x" +
                screen.Height
            );

            Console.WriteLine(
                "Maximum Form ClientSize: " +
                maxClientWidth +
                "x" +
                maxClientHeight
            );
            */
        }
        private void SetupWebControl()
        {
            webControl1.Dock = DockStyle.None;

            webControl1.Location =
                new System.Drawing.Point(0, 0);

            webControl1.Size =
                new System.Drawing.Size(
                    VirtualWidth,
                    VirtualHeight
                );
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateWebControlSize();
            // webControl1.Location = new System.Drawing.Point(-161, -30);
            //
            // webControl1.Size = new System.Drawing.Size(
            //     this.ClientSize.Width+(161*2),
            //     this.ClientSize.Height + 60+109
            // );
        }


        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(
                       Dev
                   );
        }

           
       
        private bool autoPasteRouting = true;
        private async void autoPasteTimer_Tick(
        object sender,
        System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(
                "[AUTO PASTE] TIMER FIRED"
            );

            try
            {
                if (!IsYandexWindowActiveAndUnderCursor())
                {
                    Console.WriteLine(
                        "[AUTO PASTE] Window not foreground"
                    );

                    return;
                }

                Console.WriteLine(
                    "[AUTO PASTE] focus WebView"
                );

                // Сначала отдаём фокус реальному EO браузеру.
                webControl1.Focus();
                webView2.SetFocus();

                await Task.Delay(50);

                // На время Ctrl+V клавиатура идёт прямо в Chromium.
                autoPasteRouting = true;

                try
                {
                    Console.WriteLine(
                        "[AUTO PASTE] SendKeys CTRL+V"
                    );

                    SendKeys.SendWait("^v");

                    await Task.Delay(100);
                }
                finally
                {
                 //   autoPasteRouting = false;
                }

                Console.WriteLine(
                    "[AUTO PASTE] completed"
                );
            }
            catch (Exception ex)
            {
              //  autoPasteRouting = false;

                Console.WriteLine(
                    "[AUTO PASTE ERROR] " +
                    ex
                );
            }
        }
        private sealed class GameInputFilter : IInputMsgFilter
        {
            private readonly Form1 owner;

            public GameInputFilter(Form1 owner)
            {
                this.owner = owner;
            }

            private const int WM_KEYDOWN = 0x0100;
            private const int WM_KEYUP = 0x0101;
            private const int WM_SYSKEYDOWN = 0x0104;
            private const int WM_SYSKEYUP = 0x0105;

            private const int WM_MOUSEMOVE = 0x0200;
            private const int WM_LBUTTONDOWN = 0x0201;
            private const int WM_LBUTTONUP = 0x0202;
            private const int WM_LBUTTONDBLCLK = 0x0203;
            private const int WM_RBUTTONDOWN = 0x0204;
            private const int WM_RBUTTONUP = 0x0205;
            private const int WM_MBUTTONDOWN = 0x0207;
            private const int WM_MBUTTONUP = 0x0208;
            private const int WM_MOUSEWHEEL = 0x020A;

            public InputMsgTarget PreDispatchMsg(
                int Msg,
                IntPtr wParam,
                IntPtr lParam)
            {
                switch (Msg)
                {
                    case WM_MOUSEMOVE:
                    case WM_LBUTTONDOWN:
                    case WM_LBUTTONUP:
                    case WM_LBUTTONDBLCLK:
                    case WM_RBUTTONDOWN:
                    case WM_RBUTTONUP:
                    case WM_MBUTTONDOWN:
                    case WM_MBUTTONUP:
                    case WM_MOUSEWHEEL:

                        return InputMsgTarget.WebView;

                    case WM_KEYDOWN:
                    case WM_KEYUP:
                    case WM_SYSKEYDOWN:
                    case WM_SYSKEYUP:

                        if (owner.autoPasteRouting)
                            return InputMsgTarget.WebView;

                        return InputMsgTarget.Application;

                    default:
                        return InputMsgTarget.Application;
                }
            }
        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(POINT Point);

        [DllImport("user32.dll")]
        private static extern IntPtr GetAncestor(IntPtr hwnd, uint gaFlags);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        private const uint GA_ROOT = 2;

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }

        private bool IsYandexWindowActiveAndUnderCursor()
        {
            IntPtr foreground =
                GetForegroundWindow();

            IntPtr root =
                GetAncestor(
                    foreground,
                    GA_ROOT
                );

            return foreground == this.Handle ||
                   root == this.Handle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameOutput.Enabled = !gameOutput.Enabled;

        }
        bool U_visible = false;
        private void Form1_Click(object sender, EventArgs e)
        {
        }
        bool web_visible = true;
        private void button2_Click_1(object sender, EventArgs e)
        {
            web_visible = !web_visible;
            if (web_visible)
            {
                webControl1.BringToFront();
                button1.BringToFront();
                button2.BringToFront();
                button3.BringToFront();
            }
            else
            {
                gameOutput.BringToFront();
                button1.BringToFront();
                button2.BringToFront(); 
                button3.BringToFront();
            }
        }
        bool web_fullScreen = false;
        private void button3_Click(object sender, EventArgs e)
        {
            web_fullScreen = !web_fullScreen;
            if (web_fullScreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                Location = new Point(0, 0);
                Bounds = Screen.FromControl(this).Bounds;
                Size = Bounds.Size;

                //  TopMost = true;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Fixed3D;
                Size = new Size(1200, 600);
              //  TopMost = false;
            }
        }

        private async void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Tab)
            {

                U_visible = !U_visible;
                if (U_visible)
                {
                    gameOutput.BringToFront();
                }
                else
                {
                    gameOutput.BringToFront();
                    button1.BringToFront();
                    button2.BringToFront();
                    button3.BringToFront();
                }
            }
            //
            if (e.KeyCode == Keys.Left)
            {
                Console.WriteLine("[AUTO PASTE] TIMER FIRED");

                try
                {
                    if (!IsYandexWindowActiveAndUnderCursor())
                    {
                        Console.WriteLine(
                            "[AUTO PASTE] Window not foreground"
                        );

                        //         return;
                    }

                    Console.WriteLine(
                        "[AUTO PASTE] Sending CTRL+V"
                    );

                    webView2.SetFocus();

                    await Task.Delay(200);

                    // CTRL нажали
                    webView2.SendKeyEvent(
                        true,
                        KeyCode.ControlKey
                    );

                    await Task.Delay(200);

                    // Пока CTRL зажат — нажимаем V
                    webView2.SendKeyEvent(
                        true,
                        KeyCode.V
                    );

                    await Task.Delay(300);

                    // Отпускаем V
                    webView2.SendKeyEvent(
                        false,
                        KeyCode.V
                    );

                    await Task.Delay(200);

                    // Отпускаем CTRL
                    webView2.SendKeyEvent(
                        false,
                        KeyCode.ControlKey
                    );

                    Console.WriteLine(
                        "[AUTO PASTE] CTRL+V completed"
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        "[AUTO PASTE ERROR] " +
                        ex
                    );
                }
            }
        }
    }
}