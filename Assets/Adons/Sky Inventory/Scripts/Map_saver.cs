using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Burst.CompilerServices;


public class Map_saver : MonoBehaviour
{

    public MapData saveString1 = new();
    public string name2;



    public string saveString221;


    public static GameObject[] t3 = new GameObject[0];
    public static GameObject[] t4 = new GameObject[0];
    public static GameObject[] t5 = new GameObject[0];
    public static string[] t6 = new string[0];
    public static string[] info4 = new string[0];

    ItemDemake Demake;

    public string lif;
    public static string total_lif;

    public static string[] nunames = new string[0];
    public static Map_saver ObjectSaveManager;

    public static string[] info3 = new string[0];


    public void ResetItem()
    {

        for (int i = 0; i < GameObject.FindObjectsByType<itemspawn>(sortmode.main).Length; i++)
        {
            if (VarSave.GetBool("item" + SceneManager.GetActiveScene().name + lif + i, SaveType.world) == true)
            {



                VarSave.SetBool("item" + SceneManager.GetActiveScene().name + lif + i, false, SaveType.world);

            }

        }
        for (int i = 0; i < info3.Length; i++)
        {

            if (GameObject.FindGameObjectsWithTag(info3[i]).Length != 0)
            {



                for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag(info3[i]).Length; i3++)
                {

                    GameObject.FindGameObjectsWithTag(info3[i])[i3].AddComponent<deleter1>();


                }



            }



        }
        File.Delete(name2.ToString() + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name);

    }
    public void Get_all_items_room()
    {
        GameObject[] g = Resources.LoadAll<GameObject>("itms/room" + lif + SceneManager.GetActiveScene().buildIndex);
        nunames = new string[g.Length];
        for (int i = 0; i < nunames.Length; i++)
        {
            nunames[i] = g[i].name;

        }
        for (int i2 = 0; i2 < nunames.Length; i2++)
        {
            for (int i = 0; i < t3.Length; i++)
            {
                if (nunames[i2] != t3[i].name)
                {

                }
                if (nunames[i2] == t3[i].name)
                {
                    t3[i] = g[i2];
                    i2 = nunames.Length;
                    i = t3.Length;
                }

            }
        }
    }
    public static void GetAllMorphs()
    {
        if (t5.Length == 0)
        {
            GameObject[] g3 = Resources.LoadAll<GameObject>("Morfs");
            t5 = new GameObject[g3.Length];
            for (int i = 0; i < g3.Length; i++)
            {
                t5[i] = g3[i];

            }
        }
    }
    public void GetAllItems()
    {
        if (VarSave.GetString("Demake" + Globalprefs.Reality) != "") Demake = JsonUtility.FromJson<ItemDemake>(VarSave.GetString("Demake" + Globalprefs.Reality));

        if (t5.Length == 0)
        {
            GameObject[] g3 = Resources.LoadAll<GameObject>("Morfs");
            t5 = new GameObject[g3.Length];
            for (int i = 0; i < g3.Length; i++)
            {
                t5[i] = g3[i];

            }
        }
        if (t3.Length == 0)
        {
            GameObject[] g = Resources.LoadAll<GameObject>("items");
            t3 = new GameObject[g.Length];
            info3 = new string[g.Length];
            for (int i = 0; i < g.Length; i++)
            {
                t3[i] = g[i];
                if (g[i].GetComponent<breauty>()) g[i].GetComponent<breauty>().integer = 10;
               if(!g[i].GetComponent<itemName>()) Debug.Log(g[i].name+"!NoForck");
                info3[i] = g[i].GetComponent<itemName>()._Name;

            }
        }
        if (t4.Length == 0)
        {
            GameObject[] g2 = Resources.LoadAll<GameObject>("Primetives");
            t4 = new GameObject[g2.Length];
            info4 = new string[g2.Length];
            for (int i = 0; i < g2.Length; i++)
            {
                t4[i] = g2[i];
                info4[i] = g2[i].GetComponent<StandartObject>().init;

            }
            Get_all_items_room();
        }
        //Передача потенциальных зачений пердметов в инвентарь. без неё нерабтает инвентарь с физическойфоромой предметов.
        if (t3.Length != 0) ElementalInventory.main().getallitems();
    }





    public void Start()
    {
       
       
        ObjectSaveManager = this;
        Directory.CreateDirectory(VarSave.Worldpath + @"/objects");
        LimMath();
      
        GetAllItems();
        LoadObjects();
        itemspawn[] isn = FindObjectsByType<itemspawn>(sortmode.main);
        for (int i = 0; i < isn.Length; i++)
        {



            
            if (VarSave.GetBool("/objects/item" + SceneManager.GetActiveScene().name + lif + i, SaveType.world) != true)
            {


                isn[i].sp();
                VarSave.SetBool("/objects/item" + SceneManager.GetActiveScene().name + lif + i, true, SaveType.world);

                if (isn.Length - 1 == i)
                {
                    Save();
                }
            }

        }
    }

    private void LimMath()
    {
        Directory.CreateDirectory(VarSave.path + "/datasurface");
        DirectoryInfo di = new(VarSave.path + "/datasurface");
        string str = "";
        foreach (FileInfo fi in di.GetFiles())
        {
            if (File.Exists(fi.FullName))
            {
                string spase = File.ReadAllText(fi.FullName);
                if (script.isNumber(spase)) str += fi.Name + spase; 
            }
        }
        lif = "";
        if (!FindAnyObjectByType<StaticAnyversePosition>()) lif += Globalprefs.GetIdPlanet().ToString();
        lif += "_" + Globalprefs.GetTimeline();
      if(VarSave.GetString("CurrentSpace")!="")  lif += "_" + str;
        if (VarSave.GetTrash("RealityX") != 0) lif += "_" + VarSave.GetTrash("RealityX");
        //end script
       total_lif = lif;
    }

    private void Update()
    {
       
           

        if (Input.GetKeyDown(KeyCode.F1))
        {


            Save();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            LoadObjects();
        }

    }

    public void ClearObjects()
    {
        itemspawn[] isn = FindObjectsByType<itemspawn>(sortmode.main);
        for (int i = 0; i < isn.Length; i++)
        {



            isn[i].sp();
                VarSave.DeleteKey("/objects/item" + SceneManager.GetActiveScene().name + lif + i, SaveType.world);


           
            
        }
        Directory.CreateDirectory(name2.ToString());
        File.Delete(name2.ToString() + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name);


        saveString1 = new MapData();
        itemName[] items = FindObjectsByType<itemName>(sortmode.main);



        if (items.Length != 0)
            {



                for (int i3 = 0; i3 < items.Length; i3++)
                {

                items[i3].gameObject.AddComponent<deleter1>();


                }



            }




        telo[] t = FindObjectsByType<telo>(sortmode.main);


        for (int i = 0; i < t.Length; i++)
        {


            t[i].gameObject.AddComponent<deleter1>();
        }
        StandartObject[] so = FindObjectsByType<StandartObject>(sortmode.main);
        for (int i = 0; i < so.Length; i++)
        {


            so[i].gameObject.AddComponent<deleter1>();
        }
        CustomObject[] co = FindObjectsByType<CustomObject>(sortmode.main);
        for (int i = 0; i < co.Length; i++)
        {


            co[i].gameObject.AddComponent<deleter1>();
        }
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Save()
    {

        //  if (GameObject.FindObjectsByType<itemName>(sortmode.main).Length != 0)
        //  {
        //
        //
        //      for (int i3 = 0; i3 < FindObjectsByType<itemName>(sortmode.main).Length; i3++)
        //      {
        //
        //
        //          if (FindObjectsByType<itemName>(sortmode.main)[i3].GetComponent<breauty>())
        //          {
        //              FindObjectsByType<itemName>(sortmode.main)[i3].GetComponent<breauty>();
        //          }
        //          else
        //          {
        //              FindObjectsByType<itemName>(sortmode.main)[i3].gameObject.AddComponent<breauty>().integer = 10;
        //
        //          }
        //
        //
        //
        //
        //      }
        //  }
        KompObject();


        Directory.CreateDirectory(name2.ToString());
        if (t3.Length > 0) File.WriteAllText(name2.ToString() + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name, JsonUtility.ToJson(saveString1));


        saveString1 = new MapData();


    }
    public void SaveMap(string respath)
    {
        //  if (GameObject.FindObjectsByType<itemName>(sortmode.main).Length != 0)
        //  {
        //
        //
        //      for (int i3 = 0; i3 < FindObjectsByType<itemName>(sortmode.main).Length; i3++)
        //      {
        //
        //
        //          if (FindObjectsByType<itemName>(sortmode.main)[i3].GetComponent<breauty>())
        //          {
        //              FindObjectsByType<itemName>(sortmode.main)[i3].GetComponent<breauty>();
        //          }
        //          else
        //          {
        //              FindObjectsByType<itemName>(sortmode.main)[i3].gameObject.AddComponent<breauty>().integer = 10;
        //
        //          }
        //
        //
        //
        //
        //      }
        //  }
        KompObject();

        if (t3.Length > 0) File.WriteAllText(respath+".map", JsonUtility.ToJson(saveString1));


        saveString1 = new MapData();


    }
    static bool NewRunGame;
    private void KompObject()
    {
        saveString1 = new MapData();

        Directory.CreateDirectory(name2 + @"/objects");
        itemName[] items = FindObjectsByType<itemName>(sortmode.main);

        genmodel[] gm = FindObjectsByType<genmodel>(sortmode.main);
        if (gm.Length != 0)
        {
            for (int i = 0; i < gm.Length; i++)
            {
                saveString1.idG.Add(gm[i].s);
                saveString1.vector3G.Add(gm[i].transform.position);
                saveString1.Scale3G.Add(gm[i].transform.localScale);
            }
        }
        if (items.Length != 0)
        {

            int o3 = 0;

            for (int i3 = 0; i3 < items.Length; i3++)
            {
                if (!items[i3].GetComponent<ChildNode>())
                {


                    saveString1.idA.Add(items[i3]._Name);
                    if (items[i3].GetComponent<CharacterStats>())
                    {

                        saveString1.Stats_B.Add(JsonUtility.ToJson(items[i3].GetComponent<CharacterStats>().data));

                    }
                    else
                    {



                        saveString1.Stats_B.Add("");
                    }
                    if (items[i3].GetComponent<breauty>())
                    {
                        saveString1.x.Add(items[i3].GetComponent<breauty>().integer);
                    }
                    else
                    {
                        saveString1.x.Add(10);

                    }
                    if (items[i3].GetComponent<unScript>())
                    {
                        saveString1.scriptA.Add(items[i3].GetComponent<unScript>().ins.script);
                    }
                    else
                    {
                        saveString1.scriptA.Add(null);

                    }

                    if (items[i3].GetComponent<HyperbolicPoint>())
                    {
                        saveString1.PvectorA.Add(items[i3].GetComponent<HyperbolicPoint>().HyperboilcPoistion);
                        saveString1.y.Add(items[i3].GetComponent<HyperbolicPoint>().v1);
                    }
                    else
                    {
                        saveString1.PvectorA.Add(new Hyperbolic2D());
                    }
                    if (items[i3].GetComponent<itemName>())
                    {
                        saveString1.DataItem.Add(items[i3].GetComponent<itemName>().ItemData);

                    }
                    else
                    {
                        saveString1.DataItem.Add("0");

                    }

                    if (items[i3].GetComponent<Slave>())
                    {
                        saveString1.isSlaveA.Add(true); 
                        saveString1.SlaveA.Add(items[i3].GetComponent<Slave>().slaveData);

                        saveString1.SlaveTevA.Add(items[i3].GetComponent<Slave>().WorkQualityTEVRO);
                        saveString1.SlaveSTA.Add(items[i3].GetComponent<Slave>().solarytimeold);
                    }
                    else
                    {

                        saveString1.isSlaveA.Add(false);
                        saveString1.SlaveA.Add("");

                        saveString1.SlaveTevA.Add(0);
                        saveString1.SlaveSTA.Add(0);
                    }

                    if (!items[i3].GetComponent<MultyObject>())
                    {
                        saveString1.vector3A.Add(items[i3].transform.position);
                        if (VarSave.GetBool("full4D"))
                        {
                            Vector6 v6 = items[i3].gameObject.AddComponent<MultyObject>().startPosition;
                            saveString1.vector3A.Add(new Vector3(v6.x, v6.y, v6.z));

                            items[i3].gameObject.GetComponent<MultyObject>().shape = Shape.cube5D; 
                            saveString1.posW3.Add(items[i3].GetComponent<MultyObject>().W_Position);
                            saveString1.posH3.Add(items[i3].GetComponent<MultyObject>().H_Position);
                        }
                    }

                    if (items[i3].GetComponent<MultyObject>())
                    {
                        Vector6 v6 = items[i3].GetComponent<MultyObject>().startPosition;
                        saveString1.vector3A.Add(new Vector3(v6.x, v6.y, v6.z));
                    }
                    saveString1.Scale3A.Add(items[i3].transform.localScale);
                    saveString1.qA.Add(items[i3].transform.rotation);
                    if (items[i3].GetComponent<MultyObject>())
                    {
                        saveString1.posW3.Add(items[i3].GetComponent<MultyObject>().W_Position);
                        saveString1.posH3.Add(items[i3].GetComponent<MultyObject>().H_Position);
                    }
                    else
                    {
                        saveString1.posW3.Add(0);
                        saveString1.posH3.Add(0);
                    }
                    saveString1.curN.Add(o3);
                    if (items[i3].GetComponent<MultyObject>())
                    {
                        MultyObject mo = items[i3].GetComponent<MultyObject>();
                        if (mo.N_Positions != null)
                        {

                            for (int i = 0; i < mo.N_Positions.Length; i++)
                            {
                                o3++;
                                saveString1.posN.Add(mo.N_Positions[i]);
                            }

                        }
                        else
                        {

                            saveString1.posN.Add(0);
                        }

                        saveString1.curN.Add(o3);
                    }
                    else
                    {
                        o3++;
                        saveString1.posN.Add(0);
                        saveString1.curN.Add(o3);
                    }

                } 
            }
        }

        telo[] t = FindObjectsByType<telo>(sortmode.main);

        for (int i = 0; i < t.Length; i++)
        {
            saveString1.vector3B.Add(t[i].transform.position);
            saveString1.NamesCreatures.Add(t[i].nameCreature);
            if (t[i].GetComponent<Slave>())
            {
                saveString1.isSlaveB.Add(true);

                saveString1.SlaveB.Add(t[i].GetComponent<Slave>().slaveData);
                saveString1.SlaveTevB.Add(t[i].GetComponent<Slave>().WorkQualityTEVRO);
                saveString1.SlaveSTB.Add(t[i].GetComponent<Slave>().solarytimeold);
            }
            else
            {

                saveString1.isSlaveB.Add(false);

                saveString1.SlaveB.Add("");
                saveString1.SlaveTevB.Add(0);
                saveString1.SlaveSTB.Add(0);

            }
            if (t[i].GetComponent<CharacterStats>())
            {

                saveString1.Stats_C.Add(JsonUtility.ToJson(t[i].GetComponent<CharacterStats>().data));

            }
            else
            {



                saveString1.Stats_C.Add("");
            }
        }
        CustomObject[] co = FindObjectsByType<CustomObject>(sortmode.main);

        int o = 0;
        for (int i = 0; i < co.Length; i++)
        {
            if (!co[i].Imsaveble) 
            {
                if (co[i].GetComponent<Slave>())
                {
                    saveString1.isSlaveD.Add(true);
                    saveString1.SlaveD.Add(co[i].GetComponent<Slave>().slaveData);
                    saveString1.SlaveTevD.Add(co[i].GetComponent<Slave>().WorkQualityTEVRO);
                    saveString1.SlaveSTD.Add(co[i].GetComponent<Slave>().solarytimeold);

                }
                else
                {

                    saveString1.isSlaveD.Add(false);

                    saveString1.SlaveD.Add("");
                    saveString1.SlaveTevD.Add(0);
                    saveString1.SlaveSTD.Add(0);
                }
                if (co[i].GetComponent<CharacterStats>())
                {
                    
                    saveString1.Stats_A.Add(JsonUtility.ToJson(co[i].GetComponent<CharacterStats>().data));

                }
                else
                {

                    

                    saveString1.Stats_A.Add("");
                }
                if (co[i].GetComponent<MultyObject>())
                {
                    Vector6 v6 = co[i].GetComponent<MultyObject>().startPosition;
                    saveString1.vector3D.Add(new Vector3(v6.x, v6.y, v6.z));
                }
                if (!co[i].GetComponent<MultyObject>()) 
                {
                    saveString1.vector3D.Add(co[i].transform.position);
                    if (VarSave.GetBool("full4D"))
                    {
                        Vector6 v6 = co[i].gameObject.AddComponent<MultyObject>().startPosition;
                        saveString1.vector3D.Add(new Vector3(v6.x, v6.y, v6.z));

                        co[i].gameObject.GetComponent<MultyObject>().shape = Shape.cube5D;
                        saveString1.posW2.Add(co[i].GetComponent<MultyObject>().W_Position);
                        saveString1.posH2.Add(co[i].GetComponent<MultyObject>().H_Position);
                    }
                }
                saveString1.idC.Add(co[i].s);
                saveString1.SavedPlayer.Add(true);
                if (co[i].GetComponent<HyperbolicPoint>())
                {
                    saveString1.PvectorC.Add(co[i].GetComponent<HyperbolicPoint>().HyperboilcPoistion);
                }
                else
                {
                    saveString1.PvectorC.Add(new Hyperbolic2D());
                }
                if (co[i].GetComponent<MultyObject>())
                {
                    saveString1.posW2.Add(co[i].GetComponent<MultyObject>().W_Position);
                    saveString1.posH2.Add(co[i].GetComponent<MultyObject>().H_Position);
                }
                else
                {
                    saveString1.posW2.Add(0);
                    saveString1.posH2.Add(0);
                }
                saveString1.curN2.Add(o);
                if (co[i].GetComponent<MultyObject>())
                {
                    MultyObject mo = co[i].GetComponent<MultyObject>();
                    //   Debug.Log("Start masiive position " + i); 
                    //  Debug.Log("Start masiive position position " + o + " / " + mo.gameObject.name);
                    if (mo.N_Positions != null)
                    {

                        for (int i3 = 0; i3 < mo.N_Positions.Length; i3++)
                        {

                            //    Debug.Log("Start masiive position position " + o + " / " + mo.N_Positions[i3] + " / " + i3 + " / " + mo.gameObject.name);
                            o++;
                            saveString1.posN2.Add(mo.N_Positions[i3]);
                        }

                    }
                    else
                    {

                        saveString1.posN2.Add(0);
                    }
                    //  Debug.Log("End masiive position " + i);
                    saveString1.curN2.Add(o);
                }
                else
                {
                    o++;
                    saveString1.posN2.Add(0);
                    saveString1.curN2.Add(o);
                }
            }

        }
        int o2 = 0;
        StandartObject[] so = FindObjectsByType<StandartObject>(sortmode.main);
        for (int i = 0; i < so.Length; i++)
        {
            if (so[i].GetComponent<MultyObject>())
            {
                Vector6 v6 = so[i].GetComponent<MultyObject>().startPosition;
                saveString1.vector3C.Add(new Vector3(v6.x, v6.y, v6.z));
            }
            if (so[i].GetComponent<HyperbolicPoint>())
            {
                saveString1.PvectorB.Add(so[i].GetComponent<HyperbolicPoint>().HyperboilcPoistion);
            }
            else
            {
                saveString1.PvectorB.Add(new Hyperbolic2D());
            }
            if (!so[i].GetComponent<MultyObject>()) 
            {
                saveString1.vector3C.Add(so[i].transform.position);
                if (VarSave.GetBool("full4D"))
                {
                    so[i].gameObject.AddComponent<MultyObject>();
                    if (so[i].
              GetComponent<MultyObject>())
                        saveString1.posW.Add(
                            so[i].
                            GetComponent<MultyObject>().W_Position);
                    if (so[i].
                        GetComponent<MultyObject>())
                        saveString1.posH.Add(
                            so[i].
                            GetComponent<MultyObject>().H_Position);
                    so[i].gameObject.GetComponent<MultyObject>().shape = Shape.cube5D;
                }
            }
            saveString1.idB.Add(so[i].init);
            saveString1.Scale3B.Add(so[i].transform.localScale);
            if (so[i].
                GetComponent<MultyObject>())
                saveString1.posW.Add(
                    so[i].
                    GetComponent<MultyObject>().W_Position);
            if (so[i].
                GetComponent<MultyObject>())
                saveString1.posH.Add(
                    so[i].
                    GetComponent<MultyObject>().H_Position);
            else
            {
               
                    saveString1.posW.Add(0);
                    saveString1.posH.Add(0);
               
            }
            saveString1.curN3.Add(o2);
            
            if (so[i].GetComponent<MultyObject>())
            {
                
                MultyObject mo = so[i].GetComponent<MultyObject>(); if (mo.N_Positions != null)
                {

                    for (int i3 = 0; i3 < mo.N_Positions.Length; i3++)
                    {
                        o2++;
                        saveString1.posN3.Add(mo.N_Positions[i3]);
                    }

                }
                else
                {

                    saveString1.posN3.Add(0);
                }

                saveString1.curN3.Add(o2);
            }
            else
            {
                o2++;
                saveString1.posN3.Add(0);
                saveString1.curN3.Add(o2);
            }

        }
      //  Collider[] allobj2 = Globalprefs.allTransphorms;



        /*  TransformObject to_save = new TransformObject();
           to_save.v3 = new Vector3[allobj2.Length];
           to_save.q4 = new Quaternion[allobj2.Length];
           to_save.s3 = new Vector3[allobj2.Length];
           to_save.name = new string[allobj2.Length];
           to_save.initpos = Globalprefs.allpos;
          int i4 = 0;
           foreach (Collider obj in allobj2)
           {
               if (obj != null)
               {
                   to_save.v3[i4] = obj.transform.position;
                   to_save.q4[i4] = obj.transform.rotation;
                   to_save.s3[i4] = obj.transform.localScale;
                   to_save.name[i4] = obj.transform.name;

               }
               if (obj == null)
               {
                   to_save.v3[i4] = Vector3.zero;
                   to_save.q4[i4] = Quaternion.identity;
                   to_save.s3[i4] = Vector3.one;
                   to_save.name[i4] = "";

               }
               if (true) i4 += 1;
           }*/
        Directory.CreateDirectory(VarSave.Worldpath + @"/objects");
      //  saveString1.editpos = JsonUtility.ToJson(to_save);
       
        saveString1.sceneName = SceneManager.GetActiveScene().name;
    }

    static public string mapLoad;

    public void LoadObjects()
    {

        Directory.CreateDirectory(name2 + @"/objects");



        saveString1 = new MapData();
        if (string.IsNullOrEmpty(mapLoad))
        {
            saveString221 = Path.Combine("", name2 + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name);
        }
        if (!string.IsNullOrEmpty(mapLoad))
        {
            saveString221 = Path.Combine("", mapLoad);
            mapLoad = null;
        }
        HyperbolicCamera hc = HyperbolicCamera.Main();
        bool questtarget = false;
        bool FirstSpawn = false;
        for (int c = 0; c < 4; c++)
        {
            if (c == 0)
            {
                SetObjects(hc, ref questtarget, ref FirstSpawn);
            }
            List<GameObject> objs = new();
            if (c == 1)
            {
                RaycastHit hit;

                mover m = mover.main();
                LoadADone = true;
                foreach (InventoryEvent i2 in FindObjectsByType<InventoryEvent>(sortmode.main))
                {
                    i2.Load();
                }
                if (Global.Random.Chance(2) && VarSave.GetInt("Agr") > 1000)
                {
                    if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("events/Legal_mafia"), mover.main().transform.position, Quaternion.identity));

                }
                if (VarSave.GetFloat("HorrorMode" + "_gameSettings", SaveType.global) > 0.5)
                {

                    Transform t = Instantiate(Resources.Load<GameObject>("items/Chaos_cube"), mover.main().transform.position, Quaternion.identity).transform; if (t.GetComponent<itemName>())
                        Chaos_cube.ChaosFunction(t.GetComponent<Chaos_cube>());
                    if (Global.Random.Chance(8))
                    {
                        if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("events/аруа_момент2"), mover.main().transform.position, Quaternion.identity));

                    }
                    if (Global.Random.Chance(10))
                    {
                        if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("events/аруа_момент3"), mover.main().transform.position, Quaternion.identity));

                    }
                    if (Global.Random.Chance(10))
                    {
                        if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("events/аруа_момент4"), mover.main().transform.position, Quaternion.identity));

                    }
                    //ВышийЛетун
                    if (Global.Random.Chance(2))
                    {
                        if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("Items/ВышийЛетун"), mover.main().transform.position + Global.math.randomCube(-100, 100), Quaternion.identity));

                    }
                    if (FirstSpawn)
                    {
                        Ray r = new(m.transform.position + (m.transform.up * 40), Random_vector());

                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                if (!Global.Random.Chance(6))
                                {
                                    if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("Items/РетуалКультяпистов"), hit.point, Quaternion.identity));

                                }
                            }
                        }
                    }
                }
                if (questtarget)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (objs.Count > 100)
                        {
                            break;
                        }
                        Ray r = new(m.transform.position + (m.transform.up * 40), Random_vector());

                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("Items/Капуста"), hit.point, Quaternion.identity));
                            }
                        }
                    }
                }
                if (GameEditor.Opened.genFinish)
                {
                    bool Exit = false;
                    while (!Exit)
                    {



                        Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector());

                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Exit = true;
                                objs.Add(Instantiate(Resources.Load<GameObject>("GameEditorProp/Exit"), hit.point, Quaternion.identity));
                            }
                        }
                    }
                }
                if (GameEditor.Opened.genChaosCube)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (objs.Count > 100)
                        {
                            break;
                        }
                        Ray r = new(m.transform.position + (m.transform.up * 200), Random_vector());

                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("Items/Chaos_cube"), hit.point, Quaternion.identity));
                            }
                        }
                    }
                }
                if (GameEditor.Opened.genFarm)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        if (objs.Count > 100)
                        {
                            break;
                        }
                        Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector());

                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("Items/WaterFarm"), hit.point, Quaternion.identity));
                            }
                        }
                    }
                }
                if (GameEditor.Opened.genLokation)
                {
                    for (int i = 0; i < 3 + Global.Random.Range(0, 7); i++)
                    {
                        if (objs.Count > 100)
                        {
                            break;
                        }
                        GameObject[] g = Resources.LoadAll<GameObject>("Ministructures");
                        Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                if (objs.Count < 100) objs.Add(Instantiate(g[Global.Random.Range(0, g.Length)], hit.point, Quaternion.identity));
                            }
                        }
                    }
                }
                if (GameEditor.Opened.genFashits)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (objs.Count > 100)
                        {
                            break;
                        }
                        Ray r = new(m.transform.position + (m.transform.up * 200), Random_vector());

                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("Items/FashistEnemye"), hit.point, Quaternion.identity));
                            }
                        }
                    }
                }
                if (objs.Count < 100 && !NewRunGame)
                {
                    if (System.DateTime.Now.Month == 12 || System.DateTime.Now.Month == 1 || System.DateTime.Now.Month == 0)
                    {


                        for (int i = 0; i < 7; i++)
                        {
                            if (objs.Count > 100)
                            {
                                break;
                            }
                            GameObject g = Resources.Load<GameObject>("Items/Bubenchick");
                            Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    if (objs.Count < 100) objs.Add(Instantiate(g, hit.point, Quaternion.identity));
                                }
                            }
                        }
                    }
                }
                if (objs.Count < 100)
                {
                    if (VarSave.GetInt("LastPrisved6BreadData") < System.DateTime.Now.DayOfYear)
                    {


                        for (int i = 0; i < 7; i++)
                        {
                            if (objs.Count > 100)
                            {
                                break;
                            }
                            GameObject g = Resources.Load<GameObject>("Items/ПроизводительХлеба");
                            Instantiate(Resources.Load<GameObject>("КамуИнтерфейс"));
                            Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    if (objs.Count < 100) objs.Add(Instantiate(g, mover.main().transform.position, Quaternion.identity));
                                }
                            }
                        }
                    }
                }
                if (objs.Count < 100)
                {
                    if (VarSave.GetInt("LastPrisved6BreadDataMobs"+SceneManager.GetActiveScene().buildIndex+lif) < System.DateTime.Now.DayOfYear)
                    {


                        for (int i = 0; i < 7; i++)
                        {
                            if (objs.Count > 100)
                            {
                                break;
                            }
                            GameObject g = Resources.Load<GameObject>("Items/КамунийскийХлеб");
                            Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());
                            CharacterName[] cn = objFind.ArrayByType<CharacterName>();
                            foreach (CharacterName item in cn)
                            {


                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                    }
                                }
                            }
                            SocialObject[] so = objFind.ArrayByType<SocialObject>();
                            foreach (SocialObject item in so)
                            {


                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                        if (objs.Count < 100) objs.Add(Instantiate(g, item.transform.position, Quaternion.identity));
                                    }
                                }
                            }
                        }
                        VarSave.SetInt("LastPrisved6BreadDataMobs" + SceneManager.GetActiveScene().buildIndex + lif, System.DateTime.Now.DayOfYear);
                    }
                }
                if (Globalprefs.AutoSave)
                {
                    GameManager.saveandhill();
                    Globalprefs.AutoSave = false;
                }
                if (FirstSpawn)
                {
                    if (Global.Random.Chance(2)) AddObject(hc, ref questtarget, ref FirstSpawn, true);
                    if (Global.Random.Chance(3)) AddObject(hc, ref questtarget, ref FirstSpawn, true);
                    if (Global.Random.Chance(5)) AddObject(hc, ref questtarget, ref FirstSpawn, true);
                    if (Global.Random.Chance(25)) AddObject(hc, ref questtarget, ref FirstSpawn, true);
                    if (Global.Random.Chance(150)) AddObject(hc, ref questtarget, ref FirstSpawn, true);
                    foreach (InventoryEvent i2 in FindObjectsByType<InventoryEvent>(sortmode.main))
                    {
                        i2.init();
                    }

                    //GameObject co = Resources.Load<GameObject>("CustomObject");
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(2))
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                Ray r = new(m.transform.position + (m.transform.up * 40), Random_vector());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("Items/AnyphingJuice"), hit.point, Quaternion.identity));
                                    }
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(2))
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                Ray r = new(m.transform.position + (m.transform.up * 40), Random_vector());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("Items/Chaos_cube"), hit.point, Quaternion.identity));
                                    }
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(2))
                        {
                            DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");
                            for (int i = 0; i < 6; i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                Ray r = new(m.transform.position + (m.transform.up * 40), Random_vector());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("CustomObject"), hit.point, Quaternion.identity));
                                        FileInfo fi = dif.GetFiles()[Random.Range(0, dif.GetFiles().Length)];
                                        objs[objs.Count - 1].GetComponent<CustomObject>().s = fi.Name.Replace(".txt", "");
                                    }
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(7))
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                Ray r = new(m.transform.position + (m.transform.up * 40), Random_vector());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(Resources.Load<GameObject>("Items/Попрашайка"), hit.point, Quaternion.identity));
                                    }
                                }
                            }
                        }
                    }

                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(24))
                        {

                            GameObject[] g = Resources.LoadAll<GameObject>("danges");

                            if (objs.Count < 100) objs.Add(Instantiate(g[Global.Random.Range(0, g.Length)], Global.math.randomCube(-1000, 1000), Quaternion.identity));



                        }
                    }
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(3))
                        {
                            for (int i = 0; i < 3 + Global.Random.Range(0, 7); i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                GameObject[] g = Resources.LoadAll<GameObject>("Ministructures");
                                Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(g[Global.Random.Range(0, g.Length)], hit.point, Quaternion.identity));
                                    }
                                }
                            }
                        }
                    }
                    //Nuclear_plant
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(3))
                        {
                            for (int i = 0; i < 0 + Global.Random.Range(0, 28); i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                GameObject g = Resources.Load<GameObject>("Items/БлестящийКамень");
                                Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(g, hit.point, Quaternion.identity));
                                    }
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(6))
                        {
                            for (int i = 0; i < 1; i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                GameObject g = Resources.Load<GameObject>("Items/Мерисью");
                                Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(g, hit.point, Quaternion.identity));
                                    }
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(12))
                        {
                            for (int i = 0; i < 0 + Global.Random.Range(-5, 5); i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                GameObject g = Resources.Load<GameObject>("Items/spamtonAnarhyUMUVoencom");
                                Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(g, hit.point, Quaternion.identity));
                                    }
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(12))
                        {
                            for (int i = 0; i < 0 + Global.Random.Range(5, 50); i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                GameObject g = Resources.Load<GameObject>("Items/Nuclear_plant");
                                Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(g, hit.point, Quaternion.identity));
                                    }
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(5))
                        {
                            for (int i = 0; i < 0 + Global.Random.Range(5, 10); i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                GameObject g = Resources.Load<GameObject>("Items/болотник");
                                Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(g, hit.point, Quaternion.identity));
                                    }
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(5))
                        {
                            for (int i = 0; i < 0 + Global.Random.Range(5, 10); i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                GameObject g = Resources.Load<GameObject>("Items/болотник");
                                Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(g, hit.point, Quaternion.identity));
                                    }
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        for (int i = 0; i < 0 + Global.Random.Range(25, 100); i++)
                        {
                            if (objs.Count > 100)
                            {
                                break;
                            }
                            GameObject g = Resources.Load<GameObject>("Items/Каменьщикоый_камень");
                            Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    if (objs.Count < 100) objs.Add(Instantiate(g, hit.point, Quaternion.identity));
                                }
                            }
                        }
                    }
                    //VideoStolb
                    //БилетКазино
                    if (objs.Count < 100)
                    {
                        for (int i = 0; i < 0 + Global.Random.Range(15, 20); i++)
                        {
                            if (objs.Count > 100)
                            {
                                break;
                            }
                            GameObject g = Resources.Load<GameObject>("Items/БилетКазино");
                            Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    if (objs.Count < 100) objs.Add(Instantiate(g, hit.point + (Vector3.up * 0.5f), Quaternion.identity));
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        for (int i = 0; i < 0 + Global.Random.Range(5, 10); i++)
                        {
                            if (objs.Count > 100)
                            {
                                break;
                            }
                            GameObject g = Resources.Load<GameObject>("Items/HotDog");
                            Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    if (objs.Count < 100) objs.Add(Instantiate(g, hit.point + (Vector3.up * 0.5f), Quaternion.identity));
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        for (int i = 0; i < 0 + Global.Random.Range(1, 3); i++)
                        {
                            if (objs.Count > 100)
                            {
                                break;
                            }
                            GameObject g = Resources.Load<GameObject>("Items/VideoStolb");
                            Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    if (objs.Count < 100) objs.Add(Instantiate(g, hit.point, Quaternion.identity));
                                }
                            }
                        }
                    }
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(9)) for (int i = 0; i < 0 + Global.Random.Range(1, 3); i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                GameObject g = Resources.Load<GameObject>("Items/Kamunist");
                                Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100) objs.Add(Instantiate(g, hit.point, Quaternion.identity));
                                    }
                                }
                            }
                    }
                    

                    //Custom creature
                    DirectoryInfo info = new("res/Creatures");
                    FileInfo[] inf = info.GetFiles();
                    if (objs.Count < 100)
                    {
                        if (Global.Random.Chance(2))
                        {
                            for (int i = 0; i < 0 + Global.Random.Range(1, 6); i++)
                            {
                                if (objs.Count > 100)
                                {
                                    break;
                                }
                                GameObject g = Resources.Load<GameObject>("Custom creature");
                                Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        if (objs.Count < 100)
                                        {
                                            GameObject obj = Instantiate(g, hit.point, Quaternion.identity);
                                            FileInfo creacure = inf[Global.Random.Range(0, inf.Length)];
                                            string screachure = creacure.Name.Replace(".creature", "");
                                            Creature fileSafe = JsonUtility.FromJson<Creature>(File.ReadAllText(creacure.FullName));
                                            //Запрещаю естесвеный спавн планетарных титанов. Причина : 0 FPS не хочю терпеть на протяжении долгих минут иза своей огромного хит бокса задивающи 1 000 000 физических объектов.
                                            //Ты ж ведь тож не хочешь? или оптимизируй если хочешь но я вообще не знаю как ты это сделаешь...
                                            if (fileSafe.sc != SizeCreachure.planet)
                                            {


                                                obj.GetComponent<telo>().nameCreature = screachure;
                                                objs.Add(obj);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (c == 2)
            {
                if (VarSave.GetBool("full4D"))
                {
                    GameObject[] objs2 = FindObjectsByType<GameObject>(sortmode.main);
                    foreach (GameObject item in objs2)
                    {
                        if (item.layer!=10)
                        {
                            if (!item.GetComponent<mover>())
                            {
                                if (!item.GetComponent<CustomObject>())
                                {
                                    if (item.GetComponent<Collider>())
                                    {
                                        if (!item.GetComponent<MultyObject>())
                                        {
                                            item.AddComponent<MultyObject>();

                                            item.gameObject.GetComponent<MultyObject>().shape = Shape.cube5D;
                                        }
                                    }
                                    else if (item.GetComponent<itemName>())
                                    {

                                        if (!item.GetComponent<MultyObject>())
                                        {
                                            item.AddComponent<MultyObject>();

                                            item.gameObject.GetComponent<MultyObject>().shape = Shape.cube5D;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (c==3)
            {
                NewRunGame = true;
            }


        }





    }

    private void SetObjects(HyperbolicCamera hc, ref bool questtarget, ref bool FirstSpawn)
    {
        LoadADone = false;
        



        genmodel[] gm = FindObjectsByType<genmodel>(sortmode.main);
        for (int i = 0; i < gm.Length; i++)
        {
            gm[i].gameObject.AddComponent<deleter1>();
        }

        for (int i = 0; i < saveString1.vector3G.Count; i++)
        {
            genmodel g = Instantiate(Resources.Load<GameObject>("Custom model"), saveString1.vector3G[i], Quaternion.identity).GetComponent<genmodel>();
            g.s = saveString1.idG[i];
            g.transform.localScale = saveString1.Scale3G[i];

        }

        /*
                        if (!string.IsNullOrEmpty(saveString1.editpos) && mover.main().hyperbolicCamera == null)
                        {
                            TransformObject to_save = JsonUtility.FromJson<TransformObject>(saveString1.editpos);

                            for (int i = 0; i < Globalprefs.allpos.Length; i++)
                            {
                                for (int i5 = 0; i5 < to_save.initpos.Length; i5++)
                                {
                                   if(i>i5) if (Globalprefs.allTransphorms.Length > i)
                                    {
                                        if (Globalprefs.allTransphorms[i] != null) if (Vector3.negativeInfinity.ToString() == to_save.initpos[i5].ToString() &&
                                              Globalprefs.allTransphorms[i].name == to_save.name[i5])
                                            {

                                            }
                                            else if (Globalprefs.allpos[i].ToString() == to_save.initpos[i5].ToString() &&
                                                Globalprefs.allTransphorms[i].name == to_save.name[i5])
                                            {
                                                Globalprefs.allTransphorms[i].transform.position = to_save.v3[i5];
                                                Globalprefs.allTransphorms[i].transform.rotation = to_save.q4[i5];
                                                Globalprefs.allTransphorms[i].transform.localScale = to_save.s3[i5];
                                            }
                                    }
                                }
                            }

                        }



                        */

        telo[] t = FindObjectsByType<telo>(sortmode.main);


        for (int i = 0; i < t.Length; i++)
        {


            t[i].gameObject.AddComponent<deleter1>();
        }
        StandartObject[] so = FindObjectsByType<StandartObject>(sortmode.main);
        for (int i = 0; i < so.Length; i++)
        {


            so[i].gameObject.AddComponent<deleter1>();
        }
        CustomObject[] co2 = FindObjectsByType<CustomObject>(sortmode.main);
        for (int i = 0; i < co2.Length; i++)
        {


            if (!co2[i].Imsaveble) co2[i].gameObject.AddComponent<deleter1>();
        }

        itemName[] items = FindObjectsByType<itemName>(sortmode.main);



        if (items.Length != 0)
        {



            for (int i3 = 0; i3 < items.Length; i3++)
            {

                items[i3].gameObject.AddComponent<deleter1>();


            }



        }
        AddObject(hc, ref questtarget, ref FirstSpawn,false);

    }

    private void AddObject(HyperbolicCamera hc, ref bool questtarget, ref bool FirstSpawn,bool LoadMapPlus)
    {
        if (!LoadMapPlus) 
        { if (File.Exists(saveString221))
            {
                saveString1 = JsonUtility.FromJson<MapData>(File.ReadAllText(saveString221));

                Debug.Log("IU");
            }
            else
            {
                Debug.Log("IU2");
                if (VarSave.GetString("quest", SaveType.global) == "капуста") questtarget = true;
                File.WriteAllText(name2 + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name, JsonUtility.ToJson(saveString1));
                saveString1 = JsonUtility.FromJson<MapData>(File.ReadAllText(saveString221));
                FirstSpawn = true;

            }
        }
        else
        {
            DirectoryInfo dif = new("res/UserWorckspace/maps");
            MapData NewData = new();
            FileInfo[] fis = dif.GetFiles();
            for (int i = Random.Range(0,fis.Length); i<fis.Length; i++)
            {

                FileInfo fi = fis[i]; 
                if (fi.FullName.Contains(".map"))
                {
                    if (File.Exists(fi.FullName))
                    {

                        if (File.ReadAllText(fi.FullName)[0] == '{')  NewData = JsonUtility.FromJson<MapData>(File.ReadAllText(fi.FullName));

                        Debug.Log("IU");
                    }
                    else
                    {
                        Debug.Log("IU2");
                        if (VarSave.GetString("quest", SaveType.global) == "капуста") questtarget = true;
                        File.WriteAllText(fi.FullName, JsonUtility.ToJson(NewData));
                        NewData = JsonUtility.FromJson<MapData>(File.ReadAllText(fi.FullName));
                        FirstSpawn = true;

                    }
                    if (NewData.sceneName == SceneManager.GetActiveScene().name)
                    {
                        saveString1 = NewData;
                        break;
                    }
                }
            }
            if (NewData.sceneName == "")
            {
                return;
            }
        }
        
        List<float[]> nid = new();
        List<float[]> nid2 = new();
        List<float[]> nid3 = new();

        if (saveString1.posN.Count > 0)
        {
            for (int i = 0; i < saveString1.curN.Count - 1; i += 2)
            {
                nid.Add(saveString1.posN.GetRange(saveString1.curN[i], saveString1.curN[i + 1] - saveString1.curN[i]).ToArray());
            }
            Debug.Log(saveString1.curN.Count);
        }
        if (saveString1.posN2.Count > 0)
        {
            //  nid.Add(saveString1.posN.GetRange(saveString1.curN[saveString1.curN.Count - 2], saveString1.curN[saveString1.curN.Count - 1]-1).ToArray());
            for (int i = 0; i < saveString1.curN2.Count - 1; i++)
            {
                nid2.Add(saveString1.posN2.GetRange(saveString1.curN2[i], saveString1.curN2[i + 1] - saveString1.curN2[i]).ToArray());
            }
        }
        if (saveString1.posN3.Count > 0)
        {
            //  nid2.Add(saveString1.posN2.GetRange(saveString1.curN2[saveString1.curN2.Count - 2], saveString1.curN2[saveString1.curN2.Count - 1]-1).ToArray());

            for (int i = 0; i < saveString1.curN3.Count - 1; i++)
            {
                nid3.Add(saveString1.posN3.GetRange(saveString1.curN3[i], saveString1.curN3[i + 1] - saveString1.curN3[i]).ToArray());
            }
        }
        //  nid3.Add(saveString1.posN3.GetRange(saveString1.curN3[saveString1.curN3.Count - 2], saveString1.curN3[saveString1.curN3.Count - 1] - 1).ToArray());


      
        if (saveString1.vector3B.Count != 0)
        {
            for (int i = 0; i < saveString1.vector3B.Count; i++)
            {

                telo g = Instantiate(Resources.Load<GameObject>("Custom Creature"), saveString1.vector3B[i], Quaternion.identity).GetComponent<telo>();
                if (saveString1.isSlaveB != null)
                {
                    if (saveString1.isSlaveB.Count != 0)
                    {
                        if (saveString1.isSlaveB[i]) g.gameObject.AddComponent<Slave>();
                        if (saveString1.SlaveB.Count != 0)
                        {
                            if (saveString1.SlaveB.Count > i) if (g.gameObject.GetComponent<Slave>()) g.gameObject.GetComponent<Slave>().slaveData = saveString1.SlaveB[i];
                        }
                        if (saveString1.SlaveTevB.Count > i) if (saveString1.SlaveTevB.Count != 0)
                            {
                                if (g.gameObject.GetComponent<Slave>()) g.gameObject.GetComponent<Slave>().WorkQualityTEVRO = saveString1.SlaveTevB[i];
                                if (g.gameObject.GetComponent<Slave>()) g.gameObject.GetComponent<Slave>().solarytimeold = saveString1.SlaveSTB[i];
                            }
                    }
                }
                if (saveString1.Stats_C != null)
                {
                    if (saveString1.Stats_C.Count != 0)
                    {
                        if (saveString1.Stats_C[i]!="") g.gameObject.AddComponent<CharacterStats>().data = JsonUtility.FromJson<CharacterStatsData>(saveString1.Stats_C[i]);
                        if (saveString1.Stats_C.Count != 0)
                        {
                            if (saveString1.Stats_C.Count > i) if (g.gameObject.GetComponent<CharacterStats>()) g.gameObject.GetComponent<CharacterStats>().data = JsonUtility.FromJson<CharacterStatsData>(saveString1.Stats_C[i]);
                        }
                    }
                }

                g.nameCreature = saveString1.NamesCreatures[i];
                g.gameObject.transform.position = saveString1.vector3B[i];
            }
        }
        //StandartObject
        for (int i = 0; i < saveString1.idB.Count; i++)
        {

            GameObject g = Instantiate(t4[ToTagToIDObject(saveString1.idB[i])], saveString1.vector3C[i], Quaternion.identity);
            if (saveString1.PvectorB.Count > i && hc != null)
            {
                if (!g.GetComponent<HyperbolicPoint>())
                {


                    g.AddComponent<HyperbolicPoint>().HyperboilcPoistion = saveString1.PvectorB[i];

                    g.transform.position = new Vector3(
                    g.transform.position.x,
                    saveString1.vector3C[i].y,
                    g.transform.position.z
                                     );
                }
                else
                {
                    g.GetComponent<HyperbolicPoint>().HyperboilcPoistion = saveString1.PvectorB[i];
                    g.transform.position = new Vector3(
                    g.transform.position.x,
                    saveString1.vector3C[i].y,
                    g.transform.position.z
                                     );
                }
            }
            if (VarSave.GetBool("full4D")) if (!g.GetComponent<MultyObject>()) g.AddComponent<MultyObject>().shape = Shape.cube5D;
            if (saveString1.posW.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.x = saveString1.vector3C[i].x;
            if (saveString1.posW.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.y = saveString1.vector3C[i].y;
            if (saveString1.posW.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.z = saveString1.vector3C[i].z;

            if (saveString1.posW.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().W_Position = saveString1.posW[i];
            if (saveString1.posH.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().H_Position = saveString1.posH[i];
            if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().saved = true;

            if (saveString1.Scale3B[i].x != 0) g.transform.localScale = saveString1.Scale3B[i];
            if (saveString1.posN3.Count > 0) if (g.GetComponent<MultyObject>()) for (int i2 = 0; i2 < nid3.Count; i2++)
                    {
                        g.GetComponent<MultyObject>().N_Positions = nid3[i];
                    }

        }
        bool j1 = false;
        GameObject co = Resources.Load<GameObject>("CustomObject");

        for (int i = 0; i < saveString1.idC.Count; i++)
        {

            if (Demake != null)
                if (Demake.co != null)
                    if (Demake.co.Count > 0)
                        foreach (string s in Demake.co)
                        {
                            if (saveString1.idC[i] == s)
                            {
                                j1 = true;
                            }
                        }
            if (!j1)
            {
                GameObject g = Instantiate(co, saveString1.vector3D[i], Quaternion.identity);
                if (saveString1.isSlaveD != null)
                {
                    if (saveString1.isSlaveD.Count != 0)
                    {
                        if (saveString1.isSlaveD[i]) co.gameObject.AddComponent<Slave>();
                        if (saveString1.SlaveD.Count > i) if (saveString1.SlaveD.Count != 0)
                            {
                                if (co.gameObject.GetComponent<Slave>()) co.gameObject.GetComponent<Slave>().slaveData = saveString1.SlaveD[i];
                            }
                        if (saveString1.SlaveTevD.Count > i) if (saveString1.SlaveTevD.Count != 0)
                            {
                                if (co.gameObject.GetComponent<Slave>()) co.gameObject.GetComponent<Slave>().WorkQualityTEVRO = saveString1.SlaveTevD[i]; 
                                if (co.gameObject.GetComponent<Slave>()) co.gameObject.GetComponent<Slave>().solarytimeold = saveString1.SlaveSTD[i];
                            }
                    }
                }
                if (saveString1.Stats_A != null)
                {
                    if (saveString1.Stats_A.Count != 0)
                    {
                        if (saveString1.Stats_A[i] != "") g.gameObject.AddComponent<CharacterStats>().data = JsonUtility.FromJson<CharacterStatsData>(saveString1.Stats_A[i]);
                        if (saveString1.Stats_A.Count != 0)
                        {
                            if (saveString1.Stats_A.Count > i) if (g.gameObject.GetComponent<CharacterStats>()) g.gameObject.GetComponent<CharacterStats>().data = JsonUtility.FromJson<CharacterStatsData>(saveString1.Stats_A[i]);
                        }
                    }
                }

                if (VarSave.GetBool("full4D")) if (!g.GetComponent<MultyObject>()) g.AddComponent<MultyObject>().shape = Shape.cube5D;
                if (saveString1.posW2.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.x = saveString1.vector3D[i].x;
                if (saveString1.posW2.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.y = saveString1.vector3D[i].y;
                if (saveString1.posW2.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.z = saveString1.vector3D[i].z;
                if (saveString1.PvectorC.Count > i && hc != null)
                {
                    if (!g.GetComponent<HyperbolicPoint>())
                    {


                        g.AddComponent<HyperbolicPoint>().HyperboilcPoistion = saveString1.PvectorC[i];

                        g.transform.position = new Vector3(
                        g.transform.position.x,
                        saveString1.vector3D[i].y,
                        g.transform.position.z
                                         );
                    }
                    else
                    {
                        g.GetComponent<HyperbolicPoint>().HyperboilcPoistion = saveString1.PvectorC[i];
                        g.transform.position = new Vector3(
                        g.transform.position.x,
                        saveString1.vector3D[i].y,
                        g.transform.position.z
                                         );
                    }
                }
                g.GetComponent<CustomObject>().s = saveString1.idC[i];
                g.GetComponent<CustomObject>().WHPos = new Vector2(saveString1.posW2[i], saveString1.posH2[i]);
                g.GetComponent<CustomObject>().saved = saveString1.SavedPlayer[i];
                if (saveString1.posN2.Count > 0) if (g.GetComponent<MultyObject>()) for (int i2 = 0; i2 < nid2.Count; i2++)
                        {
                            g.GetComponent<MultyObject>().N_Positions = nid2[i];
                        }
            }
            else
            {
                j1 = false;
            }
        }
        bool j2 = false;
        for (int i3 = 0; i3 < saveString1.idA.Count; i3++)
        {

            if (Demake != null)
                if (Demake.item != null)
                    if (Demake.item.Count > 0) foreach (string s in Demake.item)
                        {
                            if (saveString1.idA[i3] == s)
                            {
                                j2 = true;
                            }
                        }
            if (!j2)
            {

                Debug.Log("1");
                GameObject g = Instantiate(t3[ToNameToID(saveString1.idA[i3])], new Vector3(saveString1.vector3A[i3].x, saveString1.vector3A[i3].y, saveString1.vector3A[i3].z), saveString1.qA[i3]);
                if (saveString1.isSlaveA != null)
                {
                    if (saveString1.isSlaveA.Count != 0)
                    {
                        if (saveString1.isSlaveA[i3]) g.gameObject.AddComponent<Slave>();
                        if (saveString1.SlaveA.Count != 0)
                        {

                            if (saveString1.SlaveA.Count > i3) if (g.gameObject.GetComponent<Slave>()) g.gameObject.GetComponent<Slave>().slaveData = saveString1.SlaveA[i3];
                        }
                        if (saveString1.SlaveTevA.Count > i3) if (saveString1.SlaveTevA.Count != 0)
                            {
                                if (g.gameObject.GetComponent<Slave>()) g.gameObject.GetComponent<Slave>().WorkQualityTEVRO = saveString1.SlaveTevA[i3];
                                if (g.gameObject.GetComponent<Slave>()) g.gameObject.GetComponent<Slave>().solarytimeold = saveString1.SlaveSTA[i3];
                            }
                    }

                }
                if (saveString1.Stats_B != null)
                {
                    if (saveString1.Stats_B.Count != 0)
                    {
                        if (saveString1.Stats_B[i3] != "") g.gameObject.AddComponent<CharacterStats>().data = JsonUtility.FromJson<CharacterStatsData>(saveString1.Stats_B[i3]);
                        if (saveString1.Stats_B.Count != 0)
                        {
                            if (saveString1.Stats_B.Count > i3) if (g.gameObject.GetComponent<CharacterStats>()) g.gameObject.GetComponent<CharacterStats>().data = JsonUtility.FromJson<CharacterStatsData>(saveString1.Stats_B[i3]);
                        }
                    }
                }

                g.transform.localScale = (saveString1.Scale3A[i3]);
                if (!g.GetComponent<breauty>())
                {


                    g.AddComponent<breauty>().integer = saveString1.x[i3];
                }
                else
                {
                    g.GetComponent<breauty>().integer = saveString1.x[i3];
                }
                if (saveString1.scriptA.Count != 0) if (!g.GetComponent<unScript>())
                    {
                        UnsFormat info = new()
                        {
                            script = saveString1.scriptA[i3]
                        };
                        if (!string.IsNullOrEmpty(saveString1.scriptA[i3])) g.AddComponent<unScript>().ins = info;
                    }

                if (saveString1.PvectorA.Count > i3 && hc != null)
                {
                    if (!g.GetComponent<HyperbolicPoint>())
                    {

                        if (saveString1.PvectorA[i3].m + saveString1.PvectorA[i3].s + saveString1.PvectorA[i3].n != 0)
                        {
                            g.AddComponent<HyperbolicPoint>().HyperboilcPoistion = saveString1.PvectorA[i3];

                            g.transform.position = new Vector3(
                            g.transform.position.x,
                            saveString1.vector3A[i3].y,
                            g.transform.position.z
                                             );
                        }
                    }
                    else
                    {
                        if (saveString1.PvectorA[i3].m + saveString1.PvectorA[i3].s + saveString1.PvectorA[i3].n != 0)
                        {
                            g.GetComponent<HyperbolicPoint>().HyperboilcPoistion = saveString1.PvectorA[i3];
                            g.transform.position = new Vector3(
                            g.transform.position.x,
                            saveString1.vector3A[i3].y,
                            g.transform.position.z

                                         );
                        }
                    }
                }


                if (VarSave.GetBool("full4D")) if (!g.GetComponent<MultyObject>()) g.AddComponent<MultyObject>().shape = Shape.cube5D;
                if (saveString1.posW3.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.x = saveString1.vector3A[i3].x;
                if (saveString1.posW3.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.y = saveString1.vector3A[i3].y;
                if (saveString1.posW3.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.z = saveString1.vector3A[i3].z;
                if (saveString1.posW3.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().W_Position = saveString1.posW3[i3];
                if (saveString1.posH3.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().H_Position = saveString1.posH3[i3];
                if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().saved = true;
                if (g.GetComponent<itemName>())
                {
                    g.GetComponent<itemName>().ItemData = saveString1.DataItem[i3];
                }
                if (saveString1.posN.Count > 0) if (g.GetComponent<MultyObject>()) for (int i = 0; i < nid.Count; i++)
                        {
                            g.GetComponent<MultyObject>().N_Positions = nid[i];
                        }
            }
            else
            {
                j2 = false;
            }


        }
    }

    Vector3 Random_vector()
    {
        Vector3 rand = new(Random.rotation.x, Random.rotation.y, Random.rotation.z);
        return rand;
    }
    Vector3 Random_vector_down()
    {
        Vector3 down = Random_vector() - mover.main().transform.up * .5f;
        return down;
    }

    public static bool LoadADone;
    public int ToNameToID(string name)
    {
        int u = 0;

        GetAllItems();
        for (int i = 0; i < info3.Length; i++)
        {
            if (name == info3[i])
            {
                u = i;
            }
        }
        return u;

    }
    public int ToTagToIDObject(string init)
    {
        int u = 0;

        GetAllItems();
        for (int i = 0; i < info4.Length; i++)
        {
            if (init == info4[i])
            {
                u = i;
            }
        }
        return u;

    }
}





[SerializeField]
public class MapData
{

    public List<Vector3> vector3A = new();
    public List<string> scriptA = new();
    public List<Vector3> vector3D = new();
    public List<Vector3> vector3G = new();
    public List<Vector3> Scale3G = new();
    public List<string> idG = new();
    public List<Vector3> Scale3A = new();
    public List<Vector3> Scale3B = new();
    public List<Vector3> vector3C = new();
    public List<Hyperbolic2D> PvectorA = new();
    public List<Hyperbolic2D> PvectorB = new();
    public List<Hyperbolic2D> PvectorC = new();
    public List<Quaternion> qA = new();
    public List<int> x = new();
    public List<string> Stats_A = new();
    public List<string> Stats_B = new();
    public List<string> Stats_C = new();
    public List<float> y = new();
    public List<string> idA = new();
    public List<string> idB = new();
    public List<string> idC = new();
    public string editpos;
    public List<float> posW = new();
    public List<float> posW2 = new();
    public List<float> posN = new();
    public List<int> curN = new();
    public List<float> posN2 = new();
    public List<int> curN2 = new();
    public List<float> posN3 = new();
    public List<int> curN3 = new();
    public List<float> posH = new();
    public List<float> posH2 = new();
    public List<float> posW3 = new();
    public List<float> posH3 = new();
    public List<bool> SavedPlayer = new();
    public List<bool> isSlaveA = new();
    public List<bool> isSlaveB = new();
    public List<bool> isSlaveD = new();
    public List<string> SlaveA = new();
    public List<string> SlaveB = new();
    public List<string> SlaveD = new();
    public List<int> SlaveTevA = new();
    public List<int> SlaveTevB = new();
    public List<int> SlaveTevD = new();
    public List<int> SlaveSTA = new();
    public List<int> SlaveSTB = new();
    public List<int> SlaveSTD = new();
    public string sceneName;
    public List<Vector3> vector3B = new();


    public List<string> NamesCreatures = new();

    public List<string> DataItem = new();




}


