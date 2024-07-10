using MoonSharp.Interpreter;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LuaConstructer : InventoryEvent
{
    string code;
    public InputField ifd;
    string codepath;

    public itemName itemName;
    // Start is called before the first frame update
    void Start()
    {
        //  code = File.ReadAllText("res/scripts/Jump.lua");
        if (Map_saver.LoadADone) if (itemName)
            {

                codepath = itemName.ItemData;

                if (string.IsNullOrEmpty(codepath))
                {

                    codepath = "res/scripts/Build.lua";
                    itemName.ItemData = codepath;
                }
                code = File.ReadAllText(codepath);

            }
        ifd.text = codepath;
    }
    public void Load1()
    {
        if (itemName)
        {

            codepath = itemName.ItemData;

            if (string.IsNullOrEmpty(codepath))
            {

                codepath = "res/scripts/Build.lua";
                itemName.ItemData = codepath;
            }
            code = File.ReadAllText(codepath);

        }
        ifd.text = codepath;
    }
    List<float> v3 = new List<float>();
    public List<Vector3> BuildPosition(List<float> vec)
    {
        List<Vector3> vec3 = new List<Vector3>();
        for (int i=0; i < vec.Count;i+=3)
        {
           
                vec3.Add(new(vec[i],vec[i+1],vec[i+2]));
           
          
        }
        return vec3;
    }
    public List<Vector3> Pos = new List<Vector3>();
    public List<string> data = new List<string>();
    private void Update()
    {

      //  if (!string.IsNullOrEmpty(code)) rb.AddForce(v3 * 1 * (JumpLogic(code)), ForceMode.Impulse);
        if (itemName) itemName.ItemData = ifd.text;

    }
    float timer = 0;
    int maxpatrn = 0;
    int patrn = 0;
    public void LuaLogic()
    {
        timer += Time.deltaTime;
        //   string scriptCode = @"    
        //	-- defines a Jump function
        //	function Jump (time)
        //		if (time>= 1) then
        //			return 1
        //       else
        //           return 0
        //		end
        //	end";
        UserData.RegisterType<Vector3>();
        UserData.RegisterType<List<float>>();
        UserData.RegisterType<List<string>>();
        Script script = new Script();
        script.Globals["vec3"] = v3;
        script.Globals["ditem"] = data;
        script.DoString(code);


        DynValue luaFactFunction = script.Globals.Get("Build");
    
        DynValue res = script.Call(luaFactFunction, new object[]
        {
            ((double)patrn)
        }
        );
        DynValue luaFactFunction2 = script.Globals.Get("Item");

        DynValue res2 = script.Call(luaFactFunction2, new object[]
        {
            ((double)patrn)
        }
        );



       if (res.UserData.Object != null)
       {
           v3 = (List<float>)res.UserData.Object;
       }
        Pos = BuildPosition(v3);
        if (res2.UserData.Object != null)
        {
            data = (List<string>)res2.UserData.Object;
        }
        patrn++;

        for (int i=0;i<Pos.Count; i++) 
        {
            Instantiate(Resources.Load<GameObject>("items/" + data[i]),new Vector3(Pos[i].x, Pos[i].y, Pos[i].z) + transform.position, Quaternion.identity); 
        }

      
    }



}
