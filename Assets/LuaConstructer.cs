using MoonSharp.Interpreter;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Lua Script Behaviour")]
public class LuaConstructer : InventoryEvent
{
    [Multiline]
    public string code;
    public InputField ifd;
    string codepath;
    public bool unity;
    public bool trigger;
    public bool is_static;
    public itemName itemName;
    // Start is called before the first frame update
    void Start()
    {
        //  code = File.ReadAllText("res/scripts/Jump.lua");
        if (Map_saver.LoadADone|| unity) if (itemName)
            {

                codepath = itemName.ItemData;

                if (string.IsNullOrEmpty(codepath))
                {

                    codepath = "res/scripts/Build.lua";
                    itemName.ItemData = codepath;
                }
                code = File.ReadAllText(codepath);
                if (unity)
                {
                    LuaLogic();
                }

            }
        if (!unity) ifd.text = codepath;
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
        if (!unity) ifd.text = codepath;
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
        if (trigger)
        {
            Map_saver.LoadADone = true;
            Start();
            trigger = !trigger;
        }
    }
    float timer = 0;
    int maxpatrn = 0;
    int patrn = 0;
    static public List<GameObject> deletePost = new List<GameObject>();
    bool inita = false;
    GameObject up;
    public void LuaLogic()
    {
        if(inita) return;
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
        UserData.RegisterType<List<bool>>();
        UserData.RegisterType<List<float>>();
        UserData.RegisterType<List<string>>();
        Script script = new Script();
        script.Globals["vec3"] = v3;
        script.Globals["ditem"] = data;
        script.Globals["stat"] = new List<bool>();
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
        if (code.Contains("Big_constuction"))
        {
            DynValue luaFactFunction3 = script.Globals.Get("Big_constuction");

            DynValue res3 = script.Call(luaFactFunction3, new object[]
            {
            ((double)patrn)
           
        }
            );
            if (res3.UserData.Object != null)
            {
                is_static = ((List<bool>)res3.UserData.Object)[0];
            }
        }


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
        if (is_static)
        {
            deletePost = new List<GameObject>();
            GameObject superoptimize = new GameObject("Megastucture");
            up = superoptimize;
            for (int i = 0; i < Pos.Count; i++)
            {
                GameObject superoptimize2 = Instantiate(Resources.Load<GameObject>("items/" + data[i]), new Vector3(Pos[i].x, Pos[i].y, Pos[i].z) + transform.position, Quaternion.identity, superoptimize.transform);
                deletePost.Add(superoptimize2);

            }
         
            up.AddComponent<MeshCombiner>();
            up.GetComponent<MeshCombiner>().CreateMultiMaterialMesh = true;
            up.GetComponent<MeshCombiner>().DeactivateCombinedChildren = false;
            up.GetComponent<MeshCombiner>().destroyAllItems = true;
           // up.GetComponent<MeshCombiner>().destroyCombinedChildren = true;
            up.GetComponent<MeshCombiner>().combineInactiveChildren = true;
           
            Invoke("CooldowtoRender", 1);
           
        }
        if (!is_static) for (int i = 0; i < Pos.Count; i++)
            {
             Instantiate(Resources.Load<GameObject>("items/" + data[i]), new Vector3(Pos[i].x, Pos[i].y, Pos[i].z) + transform.position, Quaternion.identity);
            
              }
        inita = true;

    }

    public void CooldowtoRender()
    {
       
        up.GetComponent<MeshCombiner>().CombineMeshes(true);
        ClearObjects();
        up.AddComponent<MeshCollider>().sharedMesh = up.GetComponent<MeshFilter>().sharedMesh;
        up.GetComponent<MeshCollider>().cookingOptions = MeshColliderCookingOptions.None;
    }

    private void ClearObjects()
    {
        foreach (GameObject item in LuaConstructer.deletePost)
        {
            item.AddComponent<DELETE>();
         /*   MeshFilter[] var = item.GetComponentsInChildren<MeshFilter>();
            foreach (MeshFilter item2 in var)
            {
                item2.transform.SetParent(up.transform, true);
            }
            if (item.GetComponentsInChildren<MeshFilter>().Length==0)
            {
                Transform[] var2 = item.GetComponentsInChildren<Transform>();
                foreach (Transform item2 in var2)
                {
                    MeshFilter[] var3 = item.GetComponentsInChildren<MeshFilter>();
                    foreach (MeshFilter item3 in var3)
                    {
                        item3.transform.SetParent(up.transform, true);
                    }
                    if (item2.GetComponentsInChildren<MeshFilter>().Length == 0)
                    {
                        Transform[] var4 = item.GetComponentsInChildren<Transform>();
                        foreach (Transform item3 in var4)
                        {
                            MeshFilter[] var5 = item.GetComponentsInChildren<MeshFilter>();
                            foreach (MeshFilter item4 in var5)
                            {
                                item4.transform.SetParent(up.transform, true);
                            }
                        }
                    }
                }
            }
         */

        }
    }
}
