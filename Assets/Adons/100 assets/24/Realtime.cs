using Jint;
using UnityEngine;
using System.IO;
using System.Reflection;
using System;

public class Realtime : MonoBehaviour
{
    public string ScriptFile;

    private Engine engine;
    void Start()
    {
        engine = new Engine();

      //  foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
      //  {
      //      if (asm.GetName().Name.Contains("Unity"))
      //      {
      //          foreach (Type t in asm.GetExportedTypes())
      //          {
      //              Debug.Log(t.FullName);
      //          }
      //      }
      //  }
        string code = File.ReadAllText(ScriptFile);
          AllAPI.Register(engine, gameObject, code.Contains("//uns+using+AsoluteUnityAPI"));
        engine.SetValue("This", gameObject);
        engine.SetValue("Origin", transform);

        if (GetComponent<Rigidbody>())
            engine.SetValue("ThisPhysycs", GetComponent<Rigidbody>());

        engine.SetValue("Time", new TimeAPI());
        engine.SetValue("Input", new InputAPI());
        engine.SetValue("Physics", new PhysicsAPI());
        engine.SetValue("Debug", new DebugAPI());
        engine.SetValue("TransformAPI", new TransformAPI());
        engine.SetValue("AddSharpComponent", new Action<object, object>(this.AddSharpComponent));
        engine.SetValue("AddJSComponent", new Action<object, object>(this.AddJSComponent));
        //engine.SetValue("Mathf", new MathfAPI());

        engine.SetValue("Instantiate",
            new System.Action<string>(InstantiateObject));
        transform.Translate(new Vector3(0,0,0));
        engine.SetValue("Destroy",
            new System.Action<GameObject>(Destroy));
        engine.Execute(code);
        Call("Start");
    }
    public void AddJSComponent(object name, object cs_file)
    {
        GameObject obj = (GameObject)name;
        gameObject.AddComponent<JSBehaviour>().js_File = (string)cs_file;
    }
    public void AddSharpComponent(object name, object cs_file)
    {
        GameObject obj = (GameObject)name;
        foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (asm.GetName().Name.Contains("Unity"))
            {
                foreach (Type t in asm.GetExportedTypes())
                {
                   if(t.FullName.Contains((string)cs_file)) obj.AddComponent(t);
                }
            }
        }
       
    }
    void Update()
    {
        Call("Update");
    }

    void FixedUpdate()
    {
        Call("FixedUpdate");
    }

    void LateUpdate()
    {
        Call("LateUpdate");
    }

    void OnDestroy()
    {
        Call("OnDestroy");
    }

    void Call(string fn)
    {
        var f = engine.GetValue(fn);

        if(!f.IsUndefined())
            engine.Invoke(fn);
    }

    void InstantiateObject(string name)
    {
        Instantiate(Resources.Load<GameObject>(name));
    }
}
public static class UnityMath
{
    public static Vector3 Add(Vector3 a, Vector3 b)
        => a + b;

    public static Vector3 Mul(Vector3 a, float b)
        => a * b;

    public static Vector3 Sub(Vector3 a, Vector3 b)
        => a - b;

    public static float Dot(Vector3 a, Vector3 b)
        => Vector3.Dot(a, b);

    public static Vector3 Cross(Vector3 a, Vector3 b)
        => Vector3.Cross(a, b);

    public static float Distance(Vector3 a, Vector3 b)
        => Vector3.Distance(a, b);

    public static Vector3 Normalize(Vector3 a)
        => a.normalized;
}