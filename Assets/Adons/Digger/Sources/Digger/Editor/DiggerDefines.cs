using UnityEditor;
using UnityEditor.Callbacks;

namespace Digger
{
    [InitializeOnLoad]
    public class DiggerDefines
    {
        private const string DiggerDefine = "__DIGGER__";

        [System.Obsolete]
        static DiggerDefines()
        {
            InitDefine(DiggerDefine);
        }

        [System.Obsolete]
        private static void InitDefine(string def)
        {
            var target = EditorUserBuildSettings.selectedBuildTargetGroup;
            var defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(target);
            if (defines.Contains(def))
                return;

            if (string.IsNullOrEmpty(defines)) {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(target, def);
            }
            else {
                if (!defines[^1].Equals(';'))
                {
                    defines += ';';
                }

                defines += def;
                PlayerSettings.SetScriptingDefineSymbolsForGroup(target, defines);
            }
        }

        [PostProcessScene(0)]
        [System.Obsolete]
        public static void OnPostprocessScene()
        {
            InitDefine(DiggerDefine);
        }
    }
}