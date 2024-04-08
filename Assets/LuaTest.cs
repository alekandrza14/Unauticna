using MoonSharp.Interpreter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LuaTest : InventoryEvent
{
  public Rigidbody rb; string code;
    public InputField ifd;
    string codepath;

    public itemName itemName;
    // Start is called before the first frame update
    void Start()
    {
        //  code = File.ReadAllText("res/scripts/Jump.lua");
      if(complsave.LoadADone)  if (itemName)
        {

            codepath = itemName.ItemData;

            if (string.IsNullOrEmpty(codepath))
            {

                codepath = "res/scripts/Jump.lua";
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

                codepath = "res/scripts/Jump.lua";
                itemName.ItemData = codepath;
            }
            code = File.ReadAllText(codepath);

        }
        ifd.text = codepath;
    }
    Vector3 v3 = new Vector3();
    private void Update()
    {
       
     if (!string.IsNullOrEmpty(code))   rb.AddForce(v3 * 1 * (JumpLogic(code)), ForceMode.Impulse);
        if (itemName) itemName.ItemData = ifd.text;

    }
    float timer = 0;
    int maxpatrn = 0;
    int patrn = 0;
    float JumpLogic(string scriptCode)
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
        Script script = new Script();
        script.Globals["vec3"] = v3;
        script.DoString(scriptCode);

        DynValue luaFactFunction = script.Globals.Get("Jump");

        DynValue res = script.Call(luaFactFunction, (double)timer);
        DynValue luaFactFunction2 = script.Globals.Get("Velosity");

        DynValue res2 = script.Call(luaFactFunction2, new object[] 
        {
            ((double)timer) , ((double)patrn)
        }
        );
       
       
        if (res.Number != 0)
        {
            if (res2.UserData.Object != null)
            {
                v3 = (Vector3)res2.UserData.Object;
            }
            patrn++;
            timer = 0;
        }

        return (float)res.Number;
    }



}
