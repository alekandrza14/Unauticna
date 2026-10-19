using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Unauticna.Mechanics
{
    // At most one running snapshot + one pending snapshot. No Unity API in worker delegates.
    public sealed class LatestFileWorker
    {
        readonly object gate = new object();
        Action<Action<string, byte[]>> latest;
        bool running;
        int generation;
        string error;
        public bool Busy { get { lock (gate) return running; } }
        public string TakeError() { lock (gate) { string value = error; error = null; return value; } }
        public void Cancel() { lock (gate) { generation++; latest = null; } }
        public void SubmitText(string path, string text)
        { Submit(publish => publish(path, new UTF8Encoding(false).GetBytes(text))); }
        public void Submit(Action<Action<string, byte[]>> work)
        {
            lock (gate)
            {
                latest = work;
                if (running) return;
                running = true; Task.Run((Action)Run);
            }
        }
        void Run()
        {
            while (true)
            {
                Action<Action<string, byte[]>> work; int epoch;
                lock (gate)
                {
                    work = latest; latest = null; epoch = generation;
                    if (work == null) { running = false; return; }
                }
                try { work((path, bytes) => Publish(path, bytes, epoch)); }
                catch (Exception ex) { lock (gate) if (generation == epoch) error = ex.Message; }
            }
        }
        void Publish(string path, byte[] bytes, int epoch)
        {
            path = Path.GetFullPath(path);
            string directory = Path.GetDirectoryName(path);
            string temp = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                lock (gate) if (generation != epoch) return;
                Directory.CreateDirectory(directory);
                File.WriteAllBytes(temp, bytes);
                lock (gate)
                {
                    if (generation != epoch) return;
                    // Never truncate a file while a reader is reading it.
                    if (File.Exists(path)) File.Replace(temp, path, null);
                    else File.Move(temp, path);
                }
            }
            finally { if (File.Exists(temp)) File.Delete(temp); }
        }
    }
}
