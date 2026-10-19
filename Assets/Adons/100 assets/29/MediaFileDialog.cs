using System;
using System.Runtime.InteropServices;
using System.Text;
namespace Unauticna.MediaStudio
{
    internal static class MediaFileDialog
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        [StructLayout(LayoutKind.Sequential,CharSet=CharSet.Unicode)]
        sealed class OpenFileName
        {
            public int size=Marshal.SizeOf(typeof(OpenFileName));public IntPtr owner,instance;
            public string filter;public IntPtr customFilter;public int maxCustomFilter,filterIndex=1;
            public StringBuilder file=new StringBuilder(32768);public int maxFile=32768;
            public IntPtr fileTitle;public int maxFileTitle;public string initialDir,title;public int flags;
            public short fileOffset,extensionOffset;public string defaultExt;public IntPtr data,hook,template,reserved;
            public int reserved2,flagsEx;
        }
        [DllImport("comdlg32.dll",CharSet=CharSet.Unicode,SetLastError=true)] static extern bool GetOpenFileNameW([In,Out] OpenFileName o);
        [DllImport("comdlg32.dll",CharSet=CharSet.Unicode,SetLastError=true)] static extern bool GetSaveFileNameW([In,Out] OpenFileName o);
        [DllImport("user32.dll")] static extern IntPtr GetActiveWindow();
#endif
        public static string Choose(bool save,string title,string filter,string extension,string initial)
        {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
            var o=new OpenFileName{owner=GetActiveWindow(),title=title,filter=filter.Replace('|','\0')+"\0\0",defaultExt=extension,initialDir=initial,flags=0x00080000|0x00000008|0x00001000|(save?0x00000002:0x00000800)};
            return (save?GetSaveFileNameW(o):GetOpenFileNameW(o))?o.file.ToString():null;
#else
            throw new PlatformNotSupportedException("Выбор файлов этой версии рассчитан на Windows.");
#endif
        }
    }
}
