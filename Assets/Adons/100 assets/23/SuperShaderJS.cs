using System;
using System.IO;
using Jint;
using Jint.Native;
using UnityEngine;
using UnityEngine.UI;

namespace UnauticnaMods
{
    /// <summary>
    /// Загружает .js мод-шейдер (например, res/Shaders/Shader.js) через Jint,
    /// генерирует из него Unity Material на основе Standard шейдера
    /// с диффузной текстурой и сохраняет результат в Generated/.
    ///
    /// Контракт JS-мода:
    ///   usingShader(name)   — имя шейдера (сейчас фиксируется Standard, имя логируется)
    ///   usingTexture(path)  — путь к PNG/JPG текстуре (относительно папки игры)
    ///   render()            — обязательная функция, в которой мод описывает материал
    /// </summary>
    public class SuperShaderJS : MonoBehaviour
    {
        [Tooltip("Путь к .js файлу мода относительно папки игры (где лежит Assets/)")]
        public string shaderScriptPath = @"res/Shaders/Shader.js";

        [Tooltip("Имя сгенерированного материала (без расширения)")]
        public string materialName = "UnauticnaGenerated";

        [Tooltip("Папка внутри Assets, куда сохранять .mat")]
        public string generatedFolder = @"Assets/Adons/100 assets/23/Generated";

        public Material LastGeneratedMaterial { get; private set; }

        private string _selectedShaderName = "Standard";
        private string _selectedTexturePath;
		public InputField patchShader;


        public void ShaderLoad(string shader)
        {
          if(shader != "input") shaderScriptPath = shader;
		  if(shader == "input") shaderScriptPath = patchShader.text;
                string result = GenerateFromJs(shaderScriptPath, materialName, generatedFolder);
            Invoke("WaitCode",1);
        }
        Engine JS;
        string file;
        public void WaitCode()
        {   JS = new Engine();
			JS.SetValue("_SetFloat_", new Action<object, object>(this.SETFLOAT));
			JS.SetValue("_SetColor_", new Action<object, object>(this.SETCOLOR));
            if (file.Contains("function SDF()"))
            {
                
				
                JS.SetValue("_Elipsoid_", new Action<object, object, object, object, object, object, object, object>(this.sdfElipcoid));
				JS.SetValue("_Cube_", new Action<object, object, object, object, object, object, object, object>(this.sdfCube));
				JS.SetValue("_sdfApposition_", new Action<object, object>(this.sdfApposition));
                JS.SetValue("_MathSin_", new Action<object, object, object, object>(this.MathSin));
                JS.SetValue("_MathPos_", new Action<object, object, object, object>(this.MathPos));
                JS.SetValue("_null_", new Action<object, object, object, object, object, object, object, object>(this.sdfElipcoidNull));
				
				JS.SetValue("_null_", new Action<object, object, object, object, object, object, object>(this.sdfElipcoidNull));
				
				JS.SetValue("_null_", new Action<object, object, object, object, object, object>(this.sdfElipcoidNull));
				
				JS.SetValue("_null_", new Action<object, object, object, object, object>(this.sdfElipcoidNull));
				
				JS.SetValue("_null_", new Action<object, object, object, object>(this.sdfElipcoidNull));
				
				JS.SetValue("_null_", new Action<object, object>(this.sdfElipcoidNull));
				JS.SetValue("_null_", new Action<object>(this.sdfElipcoidNull));
                JS.SetValue("_usingShader_", new Action<object>(this.sdfObj1Null));
                JS.SetValue("_usingTexture_", new Action<object>(this.sdfObj1Null));
                JS.Execute(file);
            }
        } 
		public void sdfApposition(object obj, object obj1)
        {
			if((string)obj=="format:Soft"){ GetComponent<MeshRenderer>().material.SetFloat("appForm", 1.0f);}
            GetComponent<MeshRenderer>().material.SetFloat("appEff", float.Parse((string)obj1));
			
			if((string)obj=="format:Cut"){ GetComponent<MeshRenderer>().material.SetFloat("appForm", 2.0f);}
		  	if((string)obj=="format:Rigd"){ GetComponent<MeshRenderer>().material.SetFloat("appForm", 0.0f);}
		  
		  
        }
        public void MathSin(object obj, object obj1, object obj2, object obj3)
        {
            GetComponent<MeshRenderer>().material.SetFloat((string)obj + "_sin" + (string)obj1 + "Eff", float.Parse((string)obj2));
            GetComponent<MeshRenderer>().material.SetFloat((string)obj + "_sin" + (string)obj1 + "Eff2", float.Parse((string)obj3));
            //obj1_sinZEff = 179,0
        } 
		public void SETFLOAT(object obj, object obj1)
        {
            GetComponent<MeshRenderer>().material.SetFloat((string)obj, float.Parse((string)obj1));
            //obj1_sinZEff = 179,0
        }public void SETCOLOR(object obj, object obj1)
        {
            GetComponent<MeshRenderer>().material.SetColor((string)obj, new Color( float.Parse(((string)obj1).Split(" "[0])[0]),float.Parse(((string)obj1).Split(" "[0])[1]),float.Parse(((string)obj1).Split(" "[0])[2])));
            //obj1_sinZEff = 179,0
        }
        public void MathPos(object obj, object obj1, object obj2, object obj3)
        {
            GetComponent<MeshRenderer>().material.SetFloat((string)obj + "_sin" + (string)obj1 + "Pos", float.Parse((string)obj2));
            GetComponent<MeshRenderer>().material.SetFloat((string)obj + "_sin" + (string)obj1 + "Pos2", float.Parse((string)obj3));
            //obj1_sinZEff = 179,0
        }
        public void sdfElipcoid(object obj, object obj1, object obj2, object obj3, object obj11, object obj21, object obj31, object obj4)
        {
           if((string)obj=="obj1")
		   {
			GetComponent<MeshRenderer>().material.SetFloat("P1", float.Parse((string)obj1));
            GetComponent<MeshRenderer>().material.SetFloat("P2", float.Parse((string)obj2));
            GetComponent<MeshRenderer>().material.SetFloat("P3", float.Parse((string)obj3));
            GetComponent<MeshRenderer>().material.SetFloat("P11", float.Parse((string)obj11));
            GetComponent<MeshRenderer>().material.SetFloat("P21", float.Parse((string)obj21));
            GetComponent<MeshRenderer>().material.SetFloat("P31", float.Parse((string)obj31));
            GetComponent<MeshRenderer>().material.SetFloat("P4", float.Parse((string)obj4));
		   }  if((string)obj=="obj2")
		   {
			GetComponent<MeshRenderer>().material.SetFloat("obj2_P1", float.Parse((string)obj1));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P2", float.Parse((string)obj2));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P3", float.Parse((string)obj3));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P11", float.Parse((string)obj11));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P21", float.Parse((string)obj21));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P31", float.Parse((string)obj31));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P4", float.Parse((string)obj4));
		   }
        } 
		public void sdfCube(object obj, object obj1, object obj2, object obj3, object obj11, object obj21, object obj31, object obj4)
        {
           if((string)obj=="obj1")
		   {
			GetComponent<MeshRenderer>().material.SetFloat("P1", float.Parse((string)obj1));
            GetComponent<MeshRenderer>().material.SetFloat("P2", float.Parse((string)obj2));
            GetComponent<MeshRenderer>().material.SetFloat("P3", float.Parse((string)obj3));
            GetComponent<MeshRenderer>().material.SetFloat("P11", float.Parse((string)obj11));
            GetComponent<MeshRenderer>().material.SetFloat("P21", float.Parse((string)obj21));
            GetComponent<MeshRenderer>().material.SetFloat("P31", float.Parse((string)obj31));
            GetComponent<MeshRenderer>().material.SetFloat("P4", float.Parse((string)obj4));
            GetComponent<MeshRenderer>().material.SetFloat("obj1id", 1.0f);
		   } 
		   if((string)obj=="obj2")
		   {
			GetComponent<MeshRenderer>().material.SetFloat("obj2_P1", float.Parse((string)obj1));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P2", float.Parse((string)obj2));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P3", float.Parse((string)obj3));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P11", float.Parse((string)obj11));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P21", float.Parse((string)obj21));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P31", float.Parse((string)obj31));
            GetComponent<MeshRenderer>().material.SetFloat("obj2_P4", float.Parse((string)obj4));
            GetComponent<MeshRenderer>().material.SetFloat("obj2id", 1.0f);
		   }
        }
        public void sdfElipcoidNull(object obj, object obj1, object obj2, object obj3, object obj11, object obj21, object obj31, object obj4)
        {

        } public void sdfElipcoidNull(object obj, object obj1, object obj2, object obj3, object obj11, object obj21, object obj31)
        {

        } public void sdfElipcoidNull(object obj, object obj1, object obj2, object obj3, object obj11, object obj21)
        {

        } public void sdfElipcoidNull(object obj, object obj1, object obj2, object obj3, object obj11)
        {

        } public void sdfElipcoidNull(object obj, object obj1, object obj2, object obj3)
        {

        } public void sdfElipcoidNull(object obj, object obj1, object obj2)
        {

        } public void sdfElipcoidNull(object obj, object obj1)
        {

        } public void sdfElipcoidNull(object obj)
        {

        }
        public void sdfObj1Null(object obj)
        {

        }
		string codeverion = "1";
		[Multiline(200)]
		public string linkCode;
        public string GenerateFromJs(string jsRelativePath, string matName, string outFolder)
        {
            string gameRoot = GetGameRoot();
            string jsFullPath = Path.GetFullPath(Path.Combine(gameRoot, jsRelativePath));

            if (!File.Exists(jsFullPath))
                throw new FileNotFoundException("Shader.js not found", jsFullPath);

            string rawcode = File.ReadAllText(jsFullPath);
			string[] raw1code = rawcode.Split('♥');
			
			string raw2code = "";
			string donecode = "";
			int i=0;
			foreach(string item in raw1code)
			{
				if(i%2==1)
				{
					if(item.Contains("ver sahider 1"))
					{
						raw2code += item;
					}
				}
				else
				{
					raw2code += item;
				}
				i++;
			}
			string[] raw3code = raw2code.Split('_');
			int i2=0;
			foreach(string item in raw3code)
			{
				if(i2%2==1)
				{
					if(item.Contains("usingShader"))
					{
						donecode += "_usingShader_";
					}
					else if(item.Contains("usingTexture"))
					{
						donecode += "_usingTexture_";
					}
					else if(item.Contains("SetFloat"))
					{
						donecode += "_SetFloat_";
					}
					else if(item.Contains("SetColor"))
					{
						donecode += "_SetColor_";
					}
					else if(item.Contains("Elipsoid"))
					{
						donecode += "_Elipsoid_";
					}
					else if(item.Contains("Cube"))
					{
						donecode += "_Cube_";
					}
					else if(item.Contains("sdfApposition"))
					{
						donecode += "_sdfApposition_";
					}
                    else if (item.Contains("MathSin"))
                    {
                        donecode += "_MathSin_";
                    }
                    else if (item.Contains("MathPos"))
                    {
                        donecode += "_MathPos_";
                    }
                    else if(item.Contains("null"))
					{
						donecode += "_null_";
					}
					else
					{
						donecode += "_null_";
					}
				}
				else
				{
					donecode += item;
				}
				i2++;
			}
			linkCode = "Version : "+codeverion+" /n"+ donecode;
			string code = donecode;
            _selectedShaderName = "Standard";
            _selectedTexturePath = null;

            var engine = new Engine();

            engine.SetValue("_usingShader_", new Action<JsValue>(name =>
            {
                _selectedShaderName = name != null ? name.ToString() : "Standard";
                Debug.Log("[SuperShaderJS] usingShader: " + _selectedShaderName);
            }));

            engine.SetValue("_usingTexture_", new Action<JsValue>(p =>
            {
                _selectedTexturePath = p != null ? p.ToString() : null;
                Debug.Log("[SuperShaderJS] usingTexture: " + _selectedTexturePath);
            })); 
			 engine.SetValue("_SetFloat_", new Action<object, object>(this.SETFLOAT));
			 engine.SetValue("_SetColor_", new Action<object, object>(this.SETCOLOR));
			
			if (code.Contains("function SDF()"))
            {
                engine.SetValue("_Elipsoid_", new Action<object, object, object, object, object, object, object, object>(this.sdfElipcoidNull));
				engine.SetValue("_Cube_", new Action<object, object, object, object, object, object, object, object>(this.sdfElipcoidNull));
				engine.SetValue("_sdfApposition_", new Action<object, object>(this.sdfElipcoidNull));
				engine.SetValue("_MathSin_", new Action<object, object, object, object>(this.sdfElipcoidNull));
				engine.SetValue("_null_", new Action<object, object, object, object, object, object, object>(this.sdfElipcoidNull));
                engine.SetValue("_MathPos_", new Action<object, object, object, object>(this.MathPos));
                engine.SetValue("_null_", new Action<object, object, object, object, object, object>(this.sdfElipcoidNull));
				engine.SetValue("_null_", new Action<object, object, object, object, object>(this.sdfElipcoidNull));
				engine.SetValue("_null_", new Action<object, object, object, object>(this.sdfElipcoidNull));
				engine.SetValue("_null_", new Action<object, object, object>(this.sdfElipcoidNull));
				engine.SetValue("_null_", new Action<object, object>(this.sdfElipcoidNull));
				engine.SetValue("_null_", new Action<object>(this.sdfElipcoidNull));
            }
            engine.SetValue("gameRoot", gameRoot);

            engine.Execute(code);

            try
            {
                var renderFn = engine.GetValue("render");
                if (renderFn != null && renderFn.IsCallable())
                    renderFn.Call();
            }
            catch (Exception ex)
            {
                Debug.LogWarning("[SuperShaderJS] render() call failed: " + ex.Message);
            }

            Shader shader = ResolveShader(_selectedShaderName);
            if (shader == null)
                throw new Exception("Не удалось получить Shader для: " + _selectedShaderName);

            Material mat = new Material(shader) { name = matName };

            Texture2D tex = LoadTexture(_selectedTexturePath, gameRoot);
            if (tex != null)
            {
                if (mat.HasProperty("_MainTex"))
                    mat.SetTexture("_MainTex", tex);
				if (mat.HasProperty("_MainTexture"))
                    mat.SetTexture("_MainTexture", tex);
                if (mat.HasProperty("_BaseMap"))
                    mat.SetTexture("_BaseMap", tex);
                if (mat.HasProperty("_Color"))
                    mat.SetColor("_Color", Color.white);
            }
            GetComponent<MeshRenderer>().material = mat;
            file = code;
            
            EnsureFolder(outFolder);
            //   string assetPath = Path.Combine(outFolder, matName + ".mat").Replace('\\', '/'); 
            string assetPath = "отключено";
            //     string absMatPath = Path.GetFullPath(assetPath);
            //  if (File.Exists(absMatPath)) File.Delete(absMatPath);

#if UNITY_EDITOR
         //   UnityEditor.AssetDatabase.CreateAsset(mat, assetPath);
         //   UnityEditor.AssetDatabase.SaveAssets();
        //    LastGeneratedMaterial = UnityEditor.AssetDatabase.LoadAssetAtPath<Material>(assetPath);
#else
         //   LastGeneratedMaterial = mat;
         //   Debug.Log("[SuperShaderJS] Runtime material: " + Path.Combine(Application.persistentDataPath, matName + ".mat"));
#endif

            return string.Format(
                "Material '{0}' сгенерирован. Shader='{1}', Texture='{2}', Path='{3}'",
                matName,
                _selectedShaderName,
                _selectedTexturePath ?? "<none>",
                assetPath);
        }

        private static Shader ResolveShader(string name)
        {
            // Контракт: всегда Standard с диффузной текстурой
            Shader s = Shader.Find(name);
            if (s == null) s = Shader.Find("Unlit/Texture");
            if (s == null) s = Shader.Find("Sprites/Default");
            return s;
        }

        private static Texture2D LoadTexture(string relPath, string gameRoot)
        {
            if (string.IsNullOrEmpty(relPath)) return null;

            string fullPath = Path.IsPathRooted(relPath)
                ? relPath
                : Path.GetFullPath(Path.Combine(gameRoot, relPath));

            if (!File.Exists(fullPath))
            {
                Debug.LogWarning("[SuperShaderJS] Texture not found: " + fullPath);
                return null;
            }

            try
            {
                byte[] data = File.ReadAllBytes(fullPath);
                var tex = new Texture2D(256, 256, TextureFormat.RGBA32, false);
                tex.name = Path.GetFileNameWithoutExtension(fullPath);
                tex.filterMode = FilterMode.Bilinear;
                tex.wrapMode = TextureWrapMode.Repeat;
                if (tex.LoadImage(data)) return tex;
            }
            catch (Exception ex)
            {
                Debug.LogError("[SuperShaderJS] LoadTexture error: " + ex.Message);
            }
            return null;
        }

        private static void EnsureFolder(string folder)
        {
            if (string.IsNullOrEmpty(folder)) return;
            string abs = Path.GetFullPath(folder);
            if (!Directory.Exists(abs)) Directory.CreateDirectory(abs);
        }

        private static string GetGameRoot()
        {
            string dataPath = Application.dataPath;
            return Directory.GetParent(dataPath)?.FullName ?? dataPath;
        }
    }
}
