using UnityEngine;
using Jint;
using System;
using System.IO;
using System.Runtime.CompilerServices;
public class Telepotaion
{
    public Vector3 PosXYZ;
}

[AddComponentMenu("JavaScript Behaviour")]
public class JSBehaviour : InventoryEvent
{
    public string js_File;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (Map_saver.LoadADone)
            Load1();
    }
    void Load1()
    {
        var engine = new Engine()
    .SetValue("log", new Action<object>(Debug.Log));
        engine.SetValue("summon", new Action<object>(this.summon));
        engine.SetValue("AddComponent", new Action<object, object>(this.AddJsComponent));
        engine.SetValue("AddPyComponent", new Action<object, object>(this.AddPyComponent));
        engine.SetValue("AddAsmComponent", new Action<object, object>(this.AddAsmComponent));
        engine.SetValue("AddUnsComponent", new Action<object, object>(this.AddUnsComponent));
        engine.SetValue("AddLuaComponent", new Action<object, object>(this.AddLuaComponent));
        engine.SetValue("AddAhkComponent", new Action<object, object>(this.AddAhkComponent));
        engine.SetValue("AddSharpComponent", new Action<object, object>(this.AddSharpComponent));
        engine.SetValue("AddCmmComponent", new Action<object, object>(this.AddCmmComponent));
        engine.SetValue("AddCccComponent", new Action<object, object>(this.AddCccComponent));
        engine.SetValue("Add10Component", new Action<object, object>(this.AddBCComponent));
        engine.SetValue("AddRknComponent", new Action<object, object>(this.AddРКНComponent));
        engine.SetValue("GameObjectAddComponent", new Action<object>(this.GameObjectAddJsComponent));
        engine.SetValue("GameObjectAddPyComponent", new Action<object>(this.GameObjectAddPyComponent));
        engine.SetValue("GameObjectAddAsmComponent", new Action<object>(this.GameObjectAddAsmComponent));
        engine.SetValue("GameObjectAddUnsComponent", new Action<object>(this.GameObjectAddUnsComponent));
        engine.SetValue("GameObjectAddLuaComponent", new Action<object>(this.GameObjectAddLuaComponent));
        engine.SetValue("GameObjectAddAhkComponent", new Action<object>(this.GameObjectAddAhkComponent));
        engine.SetValue("GameObjectAddSharpComponent", new Action<object>(this.GameObjectAddSharpComponent));
        engine.SetValue("GameObjectAddCmmComponent", new Action<object>(this.GameObjectAddCmmComponent));
        engine.SetValue("GameObjectAddCccComponent", new Action<object>(this.GameObjectAddCccComponent));
        engine.SetValue("GameObjectAdd10Component", new Action<object>(this.GameObjectAddBCComponent));
        engine.SetValue("GameObjectAddRknComponent", new Action<object>(this.GameObjectAddРКНComponent));
        engine.SetValue("summonAddComponent", new Action<object, object>(this.summonAddJsComponent));
        engine.SetValue("summonAddPyComponent", new Action<object, object>(this.summonAddPyComponent));
        engine.SetValue("summonAddAsmComponent", new Action<object, object>(this.summonAddAsmComponent));
        engine.SetValue("summonAddUnsComponent", new Action<object, object>(this.summonAddUnsComponent));
        engine.SetValue("summonAddLuaComponent", new Action<object, object>(this.summonAddLuaComponent));
        engine.SetValue("summonAddAhkComponent", new Action<object, object>(this.summonAddAhkComponent));
        engine.SetValue("summonAddSharpComponent", new Action<object, object>(this.summonAddSharpComponent));
        engine.SetValue("summonAddCmmComponent", new Action<object, object>(this.summonAddCmmComponent));
        engine.SetValue("summonAddCccComponent", new Action<object, object>(this.summonAddCccComponent));
        engine.SetValue("summonAdd10Component", new Action<object, object>(this.summonAddBCComponent));
        engine.SetValue("summonAddRknComponent", new Action<object, object>(this.summonAddРКНComponent));
        engine.SetValue("Telep", new Action<object>(this.Teleport));

        engine.Execute(File.ReadAllText("res/scripts/" + js_File + ".js"));

    }
    public void summon(object co)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
    }
    public void summonAddJsComponent(object co, object js_file)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
        obj.AddComponent<JSBehaviour>().js_File = (string)js_file;
    }
    public void summonAddCmmComponent(object co, object cmm_file)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
        gameObject.AddComponent<CmmBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void summonAddCccComponent(object co, object cmm_file)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
        gameObject.AddComponent<CCrossCrossBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void summonAddBCComponent(object co, object cmm_file)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
        gameObject.AddComponent<BCBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void summonAddРКНComponent(object co, object cmm_file)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
        gameObject.AddComponent<RKNBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void summonAddSharpComponent(object co, object cs_file)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
        obj.AddComponent(System.Type.GetType((string)cs_file));
    }
    public void AddSharpComponent(object name, object cs_file)
    {
        GameObject obj = GameObject.Find((string)name);
        obj.AddComponent(System.Type.GetType((string)cs_file));
    }
    public void AddJsComponent(object name, object js_file)
    {
        GameObject obj = GameObject.Find((string)name);
        obj.AddComponent<JSBehaviour>().js_File = (string)js_file;
    }
    public void AddCmmComponent(object name, object cmm_file)
    {
        GameObject obj = GameObject.Find((string)name);
        obj.AddComponent<CmmBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void AddCccComponent(object name, object cmm_file)
    {
        GameObject obj = GameObject.Find((string)name);
        obj.AddComponent<CCrossCrossBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void AddBCComponent(object name, object cmm_file)
    {
        GameObject obj = GameObject.Find((string)name);
        obj.AddComponent<BCBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void AddРКНComponent(object name, object cmm_file)
    {
        GameObject obj = GameObject.Find((string)name);
        obj.AddComponent<RKNBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void AddAsmComponent(object name, object asm_file)
    {
        GameObject obj = GameObject.Find((string)name);
        obj.AddComponent<ASMBehaviour>().deStart((string)asm_file, @"res\scripts\");
    }
    public void AddPyComponent(object name, object asm_file)
    {
        GameObject obj = GameObject.Find((string)name);
        obj.AddComponent<PyBehaviour>().deStart((string)asm_file, @"res\scripts\");
    }
    public void AddUnsComponent(object name, object asm_file)
    {
        GameObject obj = GameObject.Find((string)name);
        obj.AddComponent<unScript>().deStart((string)asm_file);
    }
    public void AddLuaComponent(object name, object asm_file)
    {
        GameObject obj = GameObject.Find((string)name);
        obj.AddComponent<LuaTest>().lua_File = @"res\scripts\" + (string)asm_file;
    }
    public void AddAhkComponent(object name, object asm_file)
    {
        GameObject obj = GameObject.Find((string)name);
        obj.AddComponent<AhkBehaviour>().deStart((string)asm_file, @"\res\scripts\");
    }
    public void GameObjectAddSharpComponent(object cs_file)
    {
        gameObject.AddComponent(System.Type.GetType((string)cs_file));
    }
    public void GameObjectAddJsComponent(object js_file)
    {
        gameObject.AddComponent<JSBehaviour>().js_File = (string)js_file;
    }
    public void GameObjectAddCmmComponent(object cmm_file)
    {
        gameObject.AddComponent<CmmBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void GameObjectAddCccComponent(object cmm_file)
    {
        gameObject.AddComponent<CCrossCrossBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void GameObjectAddBCComponent(object cmm_file)
    {
        gameObject.AddComponent<BCBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void GameObjectAddРКНComponent(object cmm_file)
    {
        gameObject.AddComponent<RKNBehaviour>().deStart((string)cmm_file, @"\res\scripts\");
    }
    public void GameObjectAddAsmComponent(object asm_file)
    {
        gameObject.AddComponent<ASMBehaviour>().deStart((string)asm_file, @"res\scripts\");
    }
    public void GameObjectAddPyComponent(object asm_file)
    {
        gameObject.AddComponent<PyBehaviour>().deStart((string)asm_file, @"res\scripts\");
    }
    public void GameObjectAddUnsComponent(object asm_file)
    {
        gameObject.AddComponent<unScript>().deStart((string)asm_file);
    }
    public void GameObjectAddLuaComponent(object asm_file)
    {
        gameObject.AddComponent<LuaTest>().lua_File = @"res\scripts\" + (string)asm_file;
    }
    public void GameObjectAddAhkComponent(object asm_file)
    {
        gameObject.AddComponent<AhkBehaviour>().deStart((string)asm_file, @"\res\scripts\");
    }
    public void summonAddAsmComponent(object co, object asm_file)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
        gameObject.AddComponent<ASMBehaviour>().deStart((string)asm_file, @"res\scripts\");
    }
    public void summonAddPyComponent(object co, object asm_file)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
        gameObject.AddComponent<PyBehaviour>().deStart((string)asm_file, @"res\scripts\");
    }
    public void summonAddUnsComponent(object co, object asm_file)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
        gameObject.AddComponent<unScript>().deStart((string)asm_file);
    }
    public void summonAddLuaComponent(object co, object asm_file)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
        gameObject.AddComponent<LuaTest>().lua_File = @"res\scripts\" + (string)asm_file;
    }
    public void summonAddAhkComponent(object co, object asm_file)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
        obj.GetComponent<CustomObject>().s = (string)co;
        gameObject.AddComponent<AhkBehaviour>().deStart((string)asm_file, @"\res\scripts\");
    }
    public void Teleport(object xyz)
    {
        Debug.Log(xyz);
        transform.position = JsonUtility.FromJson<Telepotaion>((string)xyz).PosXYZ;
        Debug.Log(xyz);
    }

}

