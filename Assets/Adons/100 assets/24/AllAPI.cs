using Jint;
using Jint.Runtime.Interop;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

public static class AllAPI
{
    public static void Register(Engine engine, GameObject obj,bool useAsoluteAPI)
    {
        // Объекты
        if (useAsoluteAPI) 
        {
            engine.SetValue("This", obj);
        engine.SetValue("Origin", obj.transform);

        if(obj.TryGetComponent(out Rigidbody rb))
            engine.SetValue("Rigidbody", rb);

        if(obj.TryGetComponent(out Collider col))
            engine.SetValue("Collider", col);

        if(obj.TryGetComponent(out MeshRenderer mr))
            engine.SetValue("Renderer", mr);

        if(obj.TryGetComponent(out MeshFilter mf))
            engine.SetValue("MeshFilter", mf);

        // Unity Static Classes
        engine.SetValue("Time", TypeReference.CreateTypeReference(engine, typeof(Time)));
        engine.SetValue("Physics", TypeReference.CreateTypeReference(engine, typeof(Physics)));
        engine.SetValue("Mathf", TypeReference.CreateTypeReference(engine, typeof(Mathf)));
        engine.SetValue("Random", TypeReference.CreateTypeReference(engine, typeof(UnityEngine.Random)));
        engine.SetValue("Debug", TypeReference.CreateTypeReference(engine, typeof(Debug)));
        engine.SetValue("Input", TypeReference.CreateTypeReference(engine, typeof(Input)));
        engine.SetValue("Resources", TypeReference.CreateTypeReference(engine, typeof(Resources)));

        // Structs
        engine.SetValue("Vector2", TypeReference.CreateTypeReference(engine, typeof(Vector2)));
        engine.SetValue("Vector3", TypeReference.CreateTypeReference(engine, typeof(Vector3)));
        engine.SetValue("Vector4", TypeReference.CreateTypeReference(engine, typeof(Vector4)));
        engine.SetValue("Quaternion", TypeReference.CreateTypeReference(engine, typeof(Quaternion)));
        engine.SetValue("Color", TypeReference.CreateTypeReference(engine, typeof(Color)));
        engine.SetValue("Bounds", TypeReference.CreateTypeReference(engine, typeof(Bounds)));
        engine.SetValue("Ray", TypeReference.CreateTypeReference(engine, typeof(Ray)));

        // Unity Classes
        engine.SetValue("ThisClass", TypeReference.CreateTypeReference(engine, typeof(GameObject)));
        engine.SetValue("OriginClass", TypeReference.CreateTypeReference(engine, typeof(Transform)));
        engine.SetValue("Object", TypeReference.CreateTypeReference(engine, typeof(UnityEngine.Object)));

        // Пользовательские функции
        engine.SetValue("Instantiate", new System.Func<GameObject, GameObject>(UnityEngine.Object.Instantiate));
       
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {

                if (!asm.GetName().Name.StartsWith("Unity"))
                    continue;

                foreach (Type t in asm.GetExportedTypes())
                {
                    engine.SetValue(
                        t.Name,
                        TypeReference.CreateTypeReference(engine, t)
                    );
                }
            }
        }
      
        engine.SetValue("Destroy", new System.Action<UnityEngine.Object>(UnityEngine.Object.Destroy));
    }
}