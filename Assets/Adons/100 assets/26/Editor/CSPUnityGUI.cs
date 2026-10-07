// Assets/CSP-Link/CSPUnityGUI.cs

#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class CSPUnityGUI : EditorWindow
{
    private MonoScript sourceScript;

    private string generatedPath = "";

    [MenuItem("CSP/CSP Link")]
    public static void OpenWindow()
    {
        CSPUnityGUI window = GetWindow<CSPUnityGUI>();
        window.titleContent = new GUIContent("CSP Link");
        window.minSize = new Vector2(420, 180);
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        GUILayout.Label("CSP Link", EditorStyles.boldLabel);

        GUILayout.Space(10);

        sourceScript = (MonoScript)EditorGUILayout.ObjectField(
            "Исходный скрипт",
            sourceScript,
            typeof(MonoScript),
            false
        );

        GUILayout.Space(10);

        if (sourceScript != null)
        {
            string sourcePath = AssetDatabase.GetAssetPath(sourceScript);
            string sourceName = Path.GetFileNameWithoutExtension(sourcePath);

            generatedPath =
                "Assets/CSP-Link/" +
                sourceName +
                "CSP.cs";

            EditorGUILayout.LabelField(
                "Будет создан:",
                generatedPath
            );
        }

        GUILayout.Space(15);

        GUI.enabled = sourceScript != null;

        if (GUILayout.Button("Сохранить CSP скрипт", GUILayout.Height(35)))
        {
            CreateCSPScript();
        }

        GUILayout.Space(5);

        if (GUILayout.Button("Подключить CSP скрипт", GUILayout.Height(35)))
        {
            ConnectCSPScript();
        }

        GUI.enabled = true;
    }

    // --------------------------------------------------------
    // КНОПКА 1
    // --------------------------------------------------------

    private void CreateCSPScript()
    {
        if (sourceScript == null)
        {
            Debug.LogError("CSP: скрипт не выбран.");
            return;
        }

        string sourcePath = AssetDatabase.GetAssetPath(sourceScript);

        if (!File.Exists(sourcePath))
        {
            Debug.LogError(
                "CSP: файл не найден: " + sourcePath
            );
            return;
        }

        string sourceName =
            Path.GetFileNameWithoutExtension(sourcePath);

        string text =
            File.ReadAllText(sourcePath);
        text = AutoReplasingPreSave(text,sourceName+"CSP");
        // Проверяем именно исходный текст.
        // Это работает даже до получения Type через MonoScript.GetClass().
        string inheritancePattern =
            @"class\s+" +
            Regex.Escape(sourceName) +
            @"\s*:\s*[^{]*\bCSPBehaviour\b";

        if (!Regex.IsMatch(text, inheritancePattern))
        {
            EditorUtility.DisplayDialog(
                "CSP",
                "Скрипт " + sourceName +
                " не наследуется от CSPBehaviour.",
                "OK"
            );

            return;
        }

        string folder = "Assets/CSP-Link";

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        string newClassName =
            sourceName + "CSP";

        generatedPath =
            folder + "/" +
            newClassName +
            ".cs";

        /*
         * ВАЖНО:
         *
         * Нельзя просто скопировать
         *
         * textDownload.cs
         *
         * в
         *
         * textDownloadCSP.cs
         *
         * оставив:
         *
         * public class textDownload
         *
         * Иначе в проекте появятся два класса
         * textDownload.
         *
         * Поэтому меняем название класса:
         *
         * textDownload
         *
         * ->
         *
         * textDownloadCSP
         */

        string classPattern =
            @"(\bclass\s+)" +
            Regex.Escape(sourceName) +
            @"(\b)";
Regex classRegex = new Regex(classPattern);

        
string newText =
    classRegex.Replace(
        text,
        "$1" + newClassName + "$2",
        1
    );

        File.WriteAllText(
            generatedPath,
            newText
        );

        AssetDatabase.Refresh();

        Debug.Log(
            "CSP: создан скрипт: " +
            generatedPath
        );

        EditorUtility.DisplayDialog(
            "CSP",
            "Создан:\n" +
            generatedPath +
            "\n\n" +
            sourceName +
            " -> " +
            newClassName,
            "OK"
        );
    }

    // --------------------------------------------------------
    // КНОПКА 2
    // --------------------------------------------------------

    private void ConnectCSPScript()
    {
        if (sourceScript == null)
        {
            Debug.LogError("CSP: скрипт не выбран.");
            return;
        }

        GameObject target =
            Selection.activeGameObject;

        if (target == null)
        {
            EditorUtility.DisplayDialog(
                "CSP",
                "Сначала выбери GameObject в Hierarchy.",
                "OK"
            );

            return;
        }

        string sourcePath =
            AssetDatabase.GetAssetPath(sourceScript);

        string sourceName =
            Path.GetFileNameWithoutExtension(sourcePath);

        string cspName =
            sourceName + "CSP";

        string cspPath =
            "Assets/CSP-Link/" +
            cspName +
            ".cs";

        MonoScript cspScript =
            AssetDatabase.LoadAssetAtPath<MonoScript>(
                cspPath
            );

        if (cspScript == null)
        {
            EditorUtility.DisplayDialog(
                "CSP",
                "CSP-скрипт ещё не создан.\n\n" +
                "Нажми сначала:\n" +
                "\"Сохранить CSP скрипт\"",
                "OK"
            );

            return;
        }

        Type componentType =
            cspScript.GetClass();

        if (componentType == null)
        {
            EditorUtility.DisplayDialog(
                "CSP",
                "Unity пока не может получить класс " +
                cspName +
                ".\n\n" +
                "Проверь ошибки компиляции в Console.",
                "OK"
            );

            return;
        }

        if (!typeof(CSPBehaviour).IsAssignableFrom(componentType))
        {
            EditorUtility.DisplayDialog(
                "CSP",
                cspName +
                " не является CSPBehaviour.",
                "OK"
            );

            return;
        }

        Component oldComponent =
            target.GetComponent(componentType);

        if (oldComponent != null)
        {
            EditorUtility.DisplayDialog(
                "CSP",
                cspName +
                " уже подключён к " +
                target.name,
                "OK"
            );

            return;
        }

        Undo.AddComponent(
            target,
            componentType
        );

        EditorUtility.SetDirty(target);

        Debug.Log(
            "CSP: " +
            cspName +
            " подключён к " +
            target.name
        );
    }
	string AutoReplasingPreSave(string data,string _Class)
	{
		data = ReplaceForND(data);
		data = ReplaceUsingIncludes(data);
		data = ReplaceUseCommands(data);
		data = ReplaceIOCommands(data);
		data = data.Replace("//PUBLIC ONLYCSP\r\n","public ");
		data = data.Replace("//GLOBAL ONLYCSP\r\n","public static ");
		data = data.Replace("//PUBLIC ONLYCSP\n","public ");
		data = data.Replace("//GLOBAL ONLYCSP\n","public static ");
		data = data.Replace("//FILE ONLYCSP int var﴾","int load");
		data = data.Replace("//_","(return VarSave.GetInt(\"");
		data = data.Replace("//﴿var int","\");)");
		data = data.Replace("null;//int ﴾","load");
		data = data.Replace("﴿int","();");
		data = data.Replace("//csp","");
		data = data.Replace("Vector3.zero","(UnityEngine.Vector3)Vector3zero");
		data = data.Replace("Vector3.up","(UnityEngine.Vector3)Vector3up");
		data = data.Replace("Vector3.down","(UnityEngine.Vector3)Vector3down");
		data = data.Replace("Vector3.right","(UnityEngine.Vector3)Vector3right");
		data = data.Replace("Vector3.left","(UnityEngine.Vector3)Vector3left");
		data = data.Replace("Vector3.forward","(UnityEngine.Vector3)Vector3forward");
		data = data.Replace("Vector3.back","(UnityEngine.Vector3)Vector3beck");
		data = data.Replace("Vector3 ","UnityEngine.Vector3 ");
		data = data.Replace("null;// Vector3","new UnityEngine.Vector3");
		data = data.Replace("new Vector3",$"{_Class}.Vector3");
		data = data.Replace("null;//csp","");
		data = data.Replace("St.ri(\"","St.ri2(\"");
        data = data.Replace("//CSPBegin","namespace var"+UnityEngine.Random.Range(0,200000)+"");
		data = data.Replace("//.","{");
        data = data.Replace("//CSPEnd","}");
		return data;
	}
	string ReplaceIOCommands(string data)
{
    /*
        Описание функции берём из:

        //Get IO{Load}=LoadTexure

        Команда:

        //IO﴾Load=C:/data/textDownloaded﴿>>image

        Результат:

        image = LoadTexure("C:/data/textDownloaded");
    */

    Regex commandRegex = new Regex(
        @"(?m)^(?<indent>\s*)//(?<name>[A-Za-z_][A-Za-z0-9_]*)﴾" +
        @"(?<operation>[A-Za-z_][A-Za-z0-9_]*)=(?<value>.*?)﴿" +
        @">>(?<target>[A-Za-z_][A-Za-z0-9_\.]*)\s*$"
    );

    return commandRegex.Replace(
        data,
        match =>
        {
            string indent =
                match.Groups["indent"].Value;

            string name =
                match.Groups["name"].Value.Trim();

            string operation =
                match.Groups["operation"].Value.Trim();

            string value =
                match.Groups["value"].Value.Trim();

            string target =
                match.Groups["target"].Value.Trim();

            // Ищем:
            //
            // //Get IO{Load}=LoadTexure

            string pattern =
                @"//Get\s+" +
                Regex.Escape(name) +
                @"\{" +
                Regex.Escape(operation) +
                @"\}\s*=\s*" +
                @"(?<function>[A-Za-z_][A-Za-z0-9_]*)";

            Match functionMatch =
                Regex.Match(data, pattern);

            if (!functionMatch.Success)
            {
                Debug.LogError(
                    "CSP: не найден обработчик " +
                    name +
                    "{" +
                    operation +
                    "}"
                );

                return match.Value;
            }

            string functionName =
                functionMatch.Groups["function"].Value;

            value =
                value
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"");

            return
                indent +
                target +
                " = " +
                functionName +
                "(\"" +
                value +
                "\");";
        }
    );
}
	string ReplaceUseCommands(string data)
{
    /*
        Ищем конструкцию:

        //GitConnect﴾alekandrza14.YourAcount.file.png,C:/data/textDownloaded﴿.download

        Общий формат:

        //[NAME]﴾arg1,arg2,arg3...﴿.FLAG

        В подключённых через //Using﴾...﴿ файлах ищем:

        void git(...)//Use GitConnect

        После чего получаем:

        git("alekandrza14.YourAcount.file.png",
            "C:/data/textDownloaded",
            "DOWNLOAD");
    */

    Regex commandRegex = new Regex(
        @"(?m)^(?<indent>\s*)//(?<name>[A-Za-z_][A-Za-z0-9_]*)﴾(?<args>.*?)﴿\.(?<flag>[A-Za-z_][A-Za-z0-9_]*)\s*$"
    );

    return commandRegex.Replace(
        data,
        match =>
        {
            string indent =
                match.Groups["indent"].Value;

            string name =
                match.Groups["name"].Value.Trim();

            string argsText =
                match.Groups["args"].Value.Trim();

            string flag =
                match.Groups["flag"].Value.Trim();

            // --------------------------------------
            // Ищем функцию с:
            //
            // //Use GitConnect
            // --------------------------------------

            string functionName =
                FindUseFunctionName(data, name);

            if (functionName == null)
            {
                Debug.LogError(
                    "CSP: не найдена функция //Use " +
                    name
                );

                return match.Value;
            }

            // --------------------------------------
            // Аргументы
            // --------------------------------------

            string[] args =
                argsText.Split(',');

            List<string> finalArgs =
                new List<string>();

            foreach (string arg in args)
            {
                string value = arg.Trim();

                // CSP сейчас рассматривает эти значения
                // как строки.
                finalArgs.Add(
                    "\"" +
                    value
                        .Replace("\\", "\\\\")
                        .Replace("\"", "\\\"") +
                    "\""
                );
            }

            // FLAG становится последним аргументом.
            //
            // .download
            //
            // ->
            //
            // "DOWNLOAD"

            finalArgs.Add(
                "\"" +
                flag.ToUpperInvariant() +
                "\""
            );

            return
                indent +
                functionName +
                "(" +
                string.Join(",", finalArgs) +
                ");";
        }
    );
}
string FindUseFunctionName(
    string data,
    string useName
)
{
    /*
        Например ищем:

        void git(string link,string file,string command)//Use GitConnect

        useName = GitConnect

        результат:
        git
    */

    Regex useRegex = new Regex(
        @"\b(?:void|string|int|float|double|bool|object|[A-Za-z_][A-Za-z0-9_<>\[\]]*)\s+" +
        @"(?<function>[A-Za-z_][A-Za-z0-9_]*)\s*" +
        @"\([^)]*\)\s*" +
        @"//Use\s+" +
        Regex.Escape(useName) +
        @"\b"
    );

    Match match =
        useRegex.Match(data);

    if (!match.Success)
        return null;

    return match.Groups["function"].Value;
}
	string ReplaceFor3D(string data)
{
    // Для одинаковой обработки Windows/Linux переносов.
    data = data.Replace("\r\n", "\n");
    data = data.Replace("\r", "\n");

    string[] lines = data.Split('\n');

    int openedFor3D = 0;

    Regex for3DRegex = new Regex(
        @"^(?<indent>\s*)//For3D﴾(?<body>.*?)﴿\s*$"
    );

    for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
    {
        string line = lines[lineIndex];

        Match match = for3DRegex.Match(line);

        if (match.Success)
        {
            string indent =
                match.Groups["indent"].Value;

            string body =
                match.Groups["body"].Value;

            /*
                Получаем:

                i = 0
                &
                i.x<2,i.y<2,i.z<2
                &
                i.x++,i.y++,i.z++
            */

            string[] parts =
                body.Split('&');

            if (parts.Length != 3)
            {
                Debug.LogError(
                    "CSP For3D: неправильное количество частей:\n" +
                    line
                );

                continue;
            }

            // -----------------------------
            // i = 0
            // -----------------------------

            string initialization =
                parts[0].Trim();

            int equals =
                initialization.IndexOf('=');

            if (equals == -1)
            {
                Debug.LogError(
                    "CSP For3D: отсутствует '=':\n" +
                    line
                );

                continue;
            }

            string variable =
                initialization
                .Substring(0, equals)
                .Trim();

            string startValue =
                initialization
                .Substring(equals + 1)
                .Trim();

            // -----------------------------
            // i.x<2,i.y<2,i.z<2
            // -----------------------------

            string[] conditions =
                parts[1].Split(',');

            // -----------------------------
            // i.x++,i.y++,i.z++
            // -----------------------------

            string[] increments =
                parts[2].Split(',');

            if (
                conditions.Length != 3 ||
                increments.Length != 3
            )
            {
                Debug.LogError(
                    "CSP For3D: должно быть ровно 3 условия " +
                    "и 3 изменения:\n" +
                    line
                );

                continue;
            }

            string xCondition =
                conditions[0].Trim();

            string yCondition =
                conditions[1].Trim();

            string zCondition =
                conditions[2].Trim();

            string xIncrement =
                increments[0].Trim();

            string yIncrement =
                increments[1].Trim();

            string zIncrement =
                increments[2].Trim();

            // Создаём обычный C#

            lines[lineIndex] =
                indent +
                "for (" +
                variable + ".x = " + startValue +
                "; " +
                xCondition +
                "; " +
                xIncrement +
                ")\n" +

                indent + "{\n" +

                indent + "\tfor (" +
                variable + ".y = " + startValue +
                "; " +
                yCondition +
                "; " +
                yIncrement +
                ")\n" +

                indent + "\t{\n" +

                indent + "\t\tfor (" +
                variable + ".z = " + startValue +
                "; " +
                zCondition +
                "; " +
                zIncrement +
                ")\n" +

                indent + "\t\t{";

            openedFor3D++;

            continue;
        }

        // -------------------------------------
        // //For3DEnd
        // -------------------------------------

        if (
            line.Trim() == "//For3DEnd" &&
            openedFor3D > 0
        )
        {
            string indent =
                line.Substring(
                    0,
                    line.Length -
                    line.TrimStart().Length
                );

            lines[lineIndex] =
                indent + "\t\t}\n" +
                indent + "\t}\n" +
                indent + "}";

            openedFor3D--;
        }
    }

    return string.Join("\n", lines);
}
string GetForNDConditionVariable(string condition)
{
    /*
        Поддерживает:

        i.x < 2
        i.x <= 10
        i.y > 0
        i.z >= -5
        i.w != 10
    */

    Match match = Regex.Match(
        condition,
        @"^\s*(?<variable>[A-Za-z_][A-Za-z0-9_\.]*)\s*(?:<=|>=|==|!=|<|>)"
    );

    if (!match.Success)
    {
        return null;
    }

    return match.Groups["variable"].Value.Trim();
}

string GetForNDIncrementVariable(string increment)
{
    /*
        Поддерживает:

        i.x++
        i.x--
        i.x += 2
        i.x -= 2
        i.x *= 2
        i.x /= 2
    */

    Match match = Regex.Match(
        increment,
        @"^\s*(?<variable>[A-Za-z_][A-Za-z0-9_\.]*)\s*(?:\+\+|--|\+=|-=|\*=|/=)"
    );

    if (!match.Success)
    {
        return null;
    }

    return match.Groups["variable"].Value.Trim();
}
string ReplaceForND(string data)
{
    data = data.Replace("\r\n", "\n");
    data = data.Replace("\r", "\n");

    string[] lines = data.Split('\n');

    Regex forNDRegex = new Regex(
        @"^(?<indent>\s*)//For(?<dimension>\d+)D﴾(?<body>.*?)﴿\s*$"
    );

    Regex forNDEndRegex = new Regex(
        @"^(?<indent>\s*)//For(?<dimension>\d+)DEnd\s*$"
    );

    Stack<int> openedLoops = new Stack<int>();

    for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
    {
        string line = lines[lineIndex];

        // ==========================================
        // ForND START
        // ==========================================

        Match startMatch = forNDRegex.Match(line);

        if (startMatch.Success)
        {
            string indent =
                startMatch.Groups["indent"].Value;

            int dimension;

            if (!int.TryParse(
                startMatch.Groups["dimension"].Value,
                out dimension
            ))
            {
                Debug.LogError(
                    "CSP ForND: невозможно определить размерность:\n" +
                    line
                );

                continue;
            }

            if (dimension <= 0)
            {
                Debug.LogError(
                    "CSP ForND: размерность должна быть больше 0:\n" +
                    line
                );

                continue;
            }

            string body =
                startMatch.Groups["body"].Value;

            /*
                Например:

                i = 0
                &
                i.x<2,i.y<2,i.z<2
                &
                i.x++,i.y++,i.z++

                Или:

                [i2,i3] = 0
                &
                8 условий
                &
                8 изменений
            */

            string[] parts =
                body.Split('&');

            if (parts.Length != 3)
            {
                Debug.LogError(
                    "CSP For" +
                    dimension +
                    "D: ожидаются 3 части через '&':\n" +
                    line
                );

                continue;
            }

            // ==========================================
            // INIT
            // ==========================================

            string initialization =
                parts[0].Trim();

            int equals =
                initialization.IndexOf('=');

            if (equals == -1)
            {
                Debug.LogError(
                    "CSP For" +
                    dimension +
                    "D: отсутствует '=':\n" +
                    line
                );

                continue;
            }

            string variables =
                initialization
                .Substring(0, equals)
                .Trim();

            string startValue =
                initialization
                .Substring(equals + 1)
                .Trim();

            // variables пока используется
            // только для проверки/отладки.
            //
            // Может быть:
            //
            // i
            //
            // или:
            //
            // [i2,i3]

            // ==========================================
            // CONDITIONS
            // ==========================================

            string[] conditions =
                parts[1].Split(',');

            // ==========================================
            // INCREMENTS
            // ==========================================

            string[] increments =
                parts[2].Split(',');

            if (conditions.Length != dimension)
            {
                Debug.LogError(
                    "CSP For" +
                    dimension +
                    "D: требуется " +
                    dimension +
                    " условий, найдено " +
                    conditions.Length +
                    ":\n" +
                    line
                );

                continue;
            }

            if (increments.Length != dimension)
            {
                Debug.LogError(
                    "CSP For" +
                    dimension +
                    "D: требуется " +
                    dimension +
                    " изменений, найдено " +
                    increments.Length +
                    ":\n" +
                    line
                );

                continue;
            }

            // ==========================================
            // СОЗДАЁМ N ВЛОЖЕННЫХ FOR
            // ==========================================

            string generated = "";

            bool error = false;

            for (int d = 0; d < dimension; d++)
            {
                string condition =
                    conditions[d].Trim();

                string increment =
                    increments[d].Trim();

                string conditionVariable =
                    GetForNDConditionVariable(condition);

                string incrementVariable =
                    GetForNDIncrementVariable(increment);

                if (conditionVariable == null)
                {
                    Debug.LogError(
                        "CSP For" +
                        dimension +
                        "D: невозможно определить переменную " +
                        "из условия:\n" +
                        condition
                    );

                    error = true;
                    break;
                }

                if (incrementVariable == null)
                {
                    Debug.LogError(
                        "CSP For" +
                        dimension +
                        "D: невозможно определить переменную " +
                        "из изменения:\n" +
                        increment
                    );

                    error = true;
                    break;
                }

                // Например:
                //
                // условие:
                // i2.x < 2
                //
                // increment:
                // i2.x++
                //
                // Они обязаны работать с одной координатой.

                if (conditionVariable != incrementVariable)
                {
                    Debug.LogError(
                        "CSP For" +
                        dimension +
                        "D: условие и изменение используют " +
                        "разные координаты:\n" +
                        conditionVariable +
                        " != " +
                        incrementVariable +
                        "\n\nСтрока:\n" +
                        line
                    );

                    error = true;
                    break;
                }

                string tabs =
                    new string('\t', d);

                generated +=
                    indent +
                    tabs +
                    "for (" +
                    conditionVariable +
                    " = " +
                    startValue +
                    "; " +
                    condition +
                    "; " +
                    increment +
                    ")\n";

                generated +=
                    indent +
                    tabs +
                    "{\n";
            }

            if (error)
            {
                continue;
            }

            // Убираем последний перенос
            if (generated.EndsWith("\n"))
            {
                generated =
                    generated.Substring(
                        0,
                        generated.Length - 1
                    );
            }

            lines[lineIndex] =
                generated;

            openedLoops.Push(dimension);

            continue;
        }

        // ==========================================
        // ForND END
        // ==========================================

        Match endMatch =
            forNDEndRegex.Match(line);

        if (endMatch.Success)
        {
            int requestedDimension;

            if (!int.TryParse(
                endMatch.Groups["dimension"].Value,
                out requestedDimension
            ))
            {
                continue;
            }

            if (openedLoops.Count == 0)
            {
                Debug.LogError(
                    "CSP For" +
                    requestedDimension +
                    "DEnd найден без начала."
                );

                continue;
            }

            int openedDimension =
                openedLoops.Pop();

            if (openedDimension != requestedDimension)
            {
                Debug.LogError(
                    "CSP ForND: начало и конец не совпадают.\n" +
                    "Открыт For" +
                    openedDimension +
                    "D, но найден For" +
                    requestedDimension +
                    "DEnd."
                );
            }

            string indent =
                endMatch.Groups["indent"].Value;

            string generated = "";

            for (
                int d = requestedDimension - 1;
                d >= 0;
                d--
            )
            {
                generated +=
                    indent +
                    new string('\t', d) +
                    "}";

                if (d != 0)
                {
                    generated += "\n";
                }
            }

            lines[lineIndex] =
                generated;
        }
    }

    if (openedLoops.Count > 0)
    {
        Debug.LogError(
            "CSP ForND: найден незакрытый ForND."
        );
    }

    return string.Join("\n", lines);
}
string ReplaceUsingIncludes(string data)
{
    // Нормализуем переносы
    data = data.Replace("\r\n", "\n");
    data = data.Replace("\r", "\n");

    // Ищем:
    // //Using﴾NL_IO﴿
    // //Using﴾NL_Git﴿
    // и т.д.
    Regex usingRegex = new Regex(
        @"^\s*//Using﴾(?<name>[^﴿﴾]+)﴿\s*$",
        RegexOptions.Multiline
    );

    MatchCollection matches = usingRegex.Matches(data);

    List<string> preBeginLines = new List<string>();
    List<string> includeCode = new List<string>();

    foreach (Match match in matches)
    {
        string name = match.Groups["name"].Value.Trim();

        // Например:
        // Assets/CSPInclude/NL_IO.cs
        string path =
            "Assets/CSPInclude/" +
            name +
            ".cs";

        if (!File.Exists(path))
        {
            Debug.LogError(
                "CSP Using: файл не найден: " + path
            );

            continue;
        }

        string includeText =
            File.ReadAllText(path);

        includeText =
            includeText.Replace("\r\n", "\n");

        includeText =
            includeText.Replace("\r", "\n");

        string[] lines =
            includeText.Split('\n');

        foreach (string originalLine in lines)
        {
            string line = originalLine;
            string trimmed = line.Trim();

            // ==========================================
            // //CUT
            // ==========================================
            // Эту строку вообще не переносим.
            //
            // using UnityEngine;//CUT
            // public class NL_IO : MonoBehaviour//CUT
            // {//CUT
            // }//CUT

            if (trimmed.EndsWith("//CUT"))
            {
                continue;
            }

            // ==========================================
            // //PreBegin
            // ==========================================
            //
            // using System.IO;//PreBegin
            //
            // превращаем в:
            //
            // using System.IO;
            //
            // и позже вставляем перед //RpeBeginUsing

            if (trimmed.EndsWith("//PreBegin"))
            {
                string preBegin =
                    line.Replace("//PreBegin", "").Trim();

                if (
                    preBegin.Length > 0 &&
                    !preBeginLines.Contains(preBegin)
                )
                {
                    preBeginLines.Add(preBegin);
                }

                continue;
            }

            // ==========================================
            // Остальной код
            // ==========================================

            includeCode.Add(line);
        }
    }

    // ==============================================
    // ВСТАВЛЯЕМ //PreBegin
    // ==============================================

    foreach (string preBegin in preBeginLines)
    {
        // Если такой using уже есть,
        // второй раз его не добавляем.

        Regex existsRegex =
            new Regex(
                @"^\s*" +
                Regex.Escape(preBegin) +
                @"\s*$",
                RegexOptions.Multiline
            );

        if (!existsRegex.IsMatch(data))
        {
            data = data.Replace(
                "//RpeBeginUsing",
                preBegin +
                "\n//RpeBeginUsing"
            );
        }
    }

    // ==============================================
    // ВСТАВЛЯЕМ КОД В //Include
    // ==============================================

    if (includeCode.Count > 0)
    {
        string code =
            string.Join("\n", includeCode);

        data = data.Replace(
            "//Include",
            "//Include\n" + code
        );
    }

    // ==============================================
    // Удаляем сами команды //Using﴾...﴿
    // ==============================================

    data = usingRegex.Replace(data, "");

    return data;
}
}

#endif

