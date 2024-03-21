using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Burst.CompilerServices;


public class complsave : MonoBehaviour
{

    public rsave saveString1 = new rsave();
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
    public static complsave ObjectSaveManager;

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

                    GameObject.FindGameObjectsWithTag(info3[i])[i3].gameObject.AddComponent<deleter1>();


                }



            }



        }
        File.Delete(name2.ToString() + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name);

    }
    public void getallitemsroom()
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
    public static void getallMorfs()
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
    public void getallitems()
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
            getallitemsroom();
        }
        //Передача потенциальных зачений пердметов в инвентарь. без неё нерабтает инвентарь с физическойфоромой предметов.
        if (t3.Length != 0) ElementalInventory.main().getallitems();
    }





    public void Start()
    {
       
       
        ObjectSaveManager = this;
        Directory.CreateDirectory(VarSave.Worldpath + @"/objects");
        LimMath();
      
        getallitems();
        load();
        for (int i = 0; i < GameObject.FindObjectsByType<itemspawn>(sortmode.main).Length; i++)
        {
            if (VarSave.GetBool("/objects/item" + SceneManager.GetActiveScene().name + lif + i, SaveType.world) != true)
            {


                GameObject.FindObjectsByType<itemspawn>(sortmode.main)[i].sp();
                VarSave.SetBool("/objects/item" + SceneManager.GetActiveScene().name + lif + i, true, SaveType.world);

                if (GameObject.FindObjectsByType<itemspawn>(sortmode.main).Length - 1 == i)
                {
                    save();
                }
            }

        }

    }

    private void LimMath()
    {
        lif = "";
        if (!FindAnyObjectByType<StaticAnyversePosition>()) lif += Globalprefs.GetIdPlanet().ToString();
        lif += "_" + Globalprefs.GetTimeline();
        if (VarSave.GetTrash("RealityX") != 0) lif += "_" + VarSave.GetTrash("RealityX");
        //end script
       total_lif = lif;
    }

    private void Update()
    {
       
           

        if (Input.GetKeyDown(KeyCode.F1))
        {


            save();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            load();
        }

    }

    public void clear()
    {
        for (int i = 0; i < GameObject.FindObjectsByType<itemspawn>(sortmode.main).Length; i++)
        {
            


                GameObject.FindObjectsByType<itemspawn>(sortmode.main)[i].sp();
                VarSave.DeleteKey("/objects/item" + SceneManager.GetActiveScene().name + lif + i, SaveType.world);


           
            
        }
        Directory.CreateDirectory(name2.ToString());
        File.Delete(name2.ToString() + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name);


        saveString1 = new rsave();
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

    public void save()
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


        saveString1 = new rsave();


    }
    public void saveMap(string respath)
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


        saveString1 = new rsave();


    }

    private void KompObject()
    {
        saveString1 = new rsave();

        Directory.CreateDirectory(name2 + @"/objects");
        itemName[] items = FindObjectsByType<itemName>(sortmode.main);


        if (items.Length != 0)
        {

            int o3 = 0;

            for (int i3 = 0; i3 < items.Length; i3++)
            {

                saveString1.idA.Add(items[i3]._Name);
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



                if (!items[i3].GetComponent<MultyObject>()) saveString1.vector3A.Add(items[i3].transform.position);

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

        telo[] t = FindObjectsByType<telo>(sortmode.main);

        for (int i = 0; i < t.Length; i++)
        {
            saveString1.vector3B.Add(t[i].transform.position);
            saveString1.NamesCreatures.Add(t[i].nameCreature);


        }
        CustomObject[] co = FindObjectsByType<CustomObject>(sortmode.main);

        int o = 0;
        for (int i = 0; i < co.Length; i++)
        {
            if (co[i].GetComponent<MultyObject>())
            {
                Vector6 v6 = co[i].GetComponent<MultyObject>().startPosition;
                saveString1.vector3D.Add(new Vector3(v6.x, v6.y, v6.z));
            }
            if (!co[i].GetComponent<MultyObject>()) saveString1.vector3D.Add(co[i].transform.position);
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
            if (!so[i].GetComponent<MultyObject>()) saveString1.vector3C.Add(so[i].transform.position);
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
        Collider[] allobj2 = Globalprefs.allTransphorms;



          TransformObject to_save = new TransformObject();
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
           }
        Directory.CreateDirectory(VarSave.Worldpath + @"/objects");
        saveString1.editpos = JsonUtility.ToJson(to_save);
       
        saveString1.sceneName = SceneManager.GetActiveScene().name;
    }

    static public string mapLoad;

    public void load()
    {
       
        Directory.CreateDirectory( name2 + @"/objects");

      
        
        saveString1 = new rsave();
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
        for (int c = 0; c < 2; c++)
        {
            if (c == 0)
            {
                LoadADone = false;
                if (File.Exists(saveString221))
                {
                    saveString1 = JsonUtility.FromJson<rsave>(File.ReadAllText(saveString221));

                    Debug.Log("IU");
                }
                else
                {
                    Debug.Log("IU2");
                    if (VarSave.GetString("quest", SaveType.global) == "капуста") questtarget = true;
                    File.WriteAllText(name2 + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name, JsonUtility.ToJson(saveString1));
                    saveString1 = JsonUtility.FromJson<rsave>(File.ReadAllText(saveString221));
                    FirstSpawn = true;

                }






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





                itemName[] items = FindObjectsByType<itemName>(sortmode.main);



                if (items.Length != 0)
                {



                    for (int i3 = 0; i3 < items.Length; i3++)
                    {

                        items[i3].gameObject.AddComponent<deleter1>();


                    }



                }
                List<float[]> nid = new List<float[]>();
                List<float[]> nid2 = new List<float[]>();
                List<float[]> nid3 = new List<float[]>();

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


                    co2[i].gameObject.AddComponent<deleter1>();
                }

                if (saveString1.vector3B.Count != 0)
                {
                    for (int i = 0; i < saveString1.vector3B.Count; i++)
                    {

                        telo g = Instantiate(Resources.Load<GameObject>("Custom Creature"), saveString1.vector3B[i], Quaternion.identity).GetComponent<telo>();
                        g.nameCreature = saveString1.NamesCreatures[i];
                        g.gameObject.transform.position = saveString1.vector3B[i];
                    }
                }
                for (int i = 0; i < saveString1.idB.Count; i++)
                {

                    GameObject g = Instantiate(t4[toTagToIDObject(saveString1.idB[i])], saveString1.vector3C[i], Quaternion.identity);
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

                        if (saveString1.posW.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.x = saveString1.vector3D[i].x;
                        if (saveString1.posW.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.y = saveString1.vector3D[i].y;
                        if (saveString1.posW.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.z = saveString1.vector3D[i].z;
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
                        GameObject g = Instantiate(t3[toNameToID(saveString1.idA[i3])].gameObject, new Vector3(saveString1.vector3A[i3].x, saveString1.vector3A[i3].y, saveString1.vector3A[i3].z), saveString1.qA[i3]);
                        g.transform.localScale = (saveString1.Scale3A[i3]);
                        if (!g.GetComponent<breauty>())
                        {


                            g.AddComponent<breauty>().integer = saveString1.x[i3];
                        }
                        else
                        {
                            g.GetComponent<breauty>().integer = saveString1.x[i3];
                        }
                        if (!g.GetComponent<unScript>())
                        {
                            UnsFormat info = new UnsFormat();
                            info.script = saveString1.scriptA[i3];

                            if (!string.IsNullOrEmpty(saveString1.scriptA[i3])) g.AddComponent<unScript>().ins = info;
                        }
                       
                        if (saveString1.PvectorA.Count > i3 && hc != null)
                        {
                            if (!g.GetComponent<HyperbolicPoint>())
                            {


                                g.AddComponent<HyperbolicPoint>().HyperboilcPoistion = saveString1.PvectorA[i3];

                                g.transform.position = new Vector3(
                                g.transform.position.x,
                                saveString1.vector3A[i3].y,
                                g.transform.position.z
                                                 );
                            }
                            else
                            {
                                g.GetComponent<HyperbolicPoint>().HyperboilcPoistion = saveString1.PvectorA[i3];
                                g.transform.position = new Vector3(
                                g.transform.position.x,
                                saveString1.vector3A[i3].y,
                                g.transform.position.z
                                                 );
                            }
                        }


                        if (saveString1.posW.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.x = saveString1.vector3A[i3].x;
                        if (saveString1.posW.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.y = saveString1.vector3A[i3].y;
                        if (saveString1.posW.Count > 0) if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().startPosition.z = saveString1.vector3A[i3].z;
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
            if (c == 1)
            {
                mover m = mover.main();
                LoadADone = true;
                foreach (InventoryEvent i2 in FindObjectsByType<InventoryEvent>(sortmode.main))
                {
                    i2.Load();
                }
                if (VarSave.GetFloat("HorrorMode" + "_gameSettings", SaveType.global) > 0.5)
                {

                    Transform t = Instantiate(Resources.Load<GameObject>("items/Chaos_cube").gameObject, mover.main().transform.position, Quaternion.identity).transform; if (t.GetComponent<itemName>())
                        Chaos_cube.ChaosFunction(t.GetComponent<Chaos_cube>());
                    if (Random.Range(0, 8) >= 7)
                    {
                        Instantiate(Resources.Load<GameObject>("events/аруа_момент2").gameObject, mover.main().transform.position, Quaternion.identity);

                    }
                    if (Random.Range(0, 10) >= 9)
                    {
                        Instantiate(Resources.Load<GameObject>("events/аруа_момент3").gameObject, mover.main().transform.position, Quaternion.identity);

                    }
                    if (Random.Range(0, 10) >= 9)
                    {
                        Instantiate(Resources.Load<GameObject>("events/аруа_момент4").gameObject, mover.main().transform.position, Quaternion.identity);

                    }
                    //ВышийЛетун
                    if (Random.Range(0, 2) >= 1)
                    {
                        Instantiate(Resources.Load<GameObject>("events/ВышийЛетун").gameObject, mover.main().transform.position + Global.math.randomCube(-100, 100), Quaternion.identity);

                    }
                    if (FirstSpawn)
                    {
                        Ray r = new Ray(m.transform.position + (m.transform.up * 40), new Vector3(Random.rotation.x, Random.rotation.y, Random.rotation.z));
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                if (Random.Range(0, 6) >= 1)
                                {
                                    Instantiate(Resources.Load<GameObject>("events/РетуалКультяпистов").gameObject, hit.point, Quaternion.identity);

                                }
                            }
                        }
                    }
                }
                if (questtarget)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Ray r = new Ray(m.transform.position + (m.transform.up * 40), new Vector3(Random.rotation.x, Random.rotation.y, Random.rotation.z));
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/Капуста"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
                if (FirstSpawn)
                {
                    foreach (InventoryEvent i2 in FindObjectsByType<InventoryEvent>(sortmode.main))
                    {
                        i2.init();
                    }
                    if (Random.Range(0, 2) >= 1)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            Ray r = new Ray(m.transform.position + (m.transform.up * 40), new Vector3(Random.rotation.x, Random.rotation.y, Random.rotation.z));
                            RaycastHit hit;
                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    Instantiate(Resources.Load<GameObject>("Items/AnyphingJuice"), hit.point, Quaternion.identity);
                                }
                            }
                        }
                    }
                    if (Random.Range(0, 24) == 1)
                    {
                      
                            GameObject[] g = Resources.LoadAll<GameObject>("danges");

                            Instantiate(g[Random.Range(0, g.Length)], Global.math.randomCube(-1000, 1000), Quaternion.identity);


                       
                    }

                }
            }


        }





    }
    public static bool LoadADone;
    public int toNameToID(string name)
    {
        int u = 0;

        getallitems();
        for (int i = 0; i < info3.Length; i++)
        {
            if (name == info3[i])
            {
                u = i;
            }
        }
        return u;

    }
    public int toTagToIDObject(string init)
    {
        int u = 0;

        getallitems();
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
public class rsave
{

    public List<Vector3> vector3A = new List<Vector3>();
    public List<string> scriptA = new List<string>();
    public List<Vector3> vector3D = new List<Vector3>();
    public List<Vector3> Scale3A = new List<Vector3>();
    public List<Vector3> Scale3B = new List<Vector3>();
    public List<Vector3> vector3C = new List<Vector3>();
    public List<Hyperbolic2D> PvectorA = new List<Hyperbolic2D>();
    public List<Hyperbolic2D> PvectorB = new List<Hyperbolic2D>();
    public List<Hyperbolic2D> PvectorC = new List<Hyperbolic2D>();
    public List<Quaternion> qA = new List<Quaternion>();
    public List<int> x = new List<int>();
    public List<float> y = new List<float>();
    public List<string> idA = new List<string>();
    public List<string> idB = new List<string>();
    public List<string> idC = new List<string>();
    public string editpos;
    public List<float> posW = new List<float>();
    public List<float> posW2 = new List<float>();
    public List<float> posN = new List<float>();
    public List<int> curN = new List<int>();
    public List<float> posN2 = new List<float>();
    public List<int> curN2 = new List<int>();
    public List<float> posN3 = new List<float>();
    public List<int> curN3 = new List<int>();
    public List<float> posH = new List<float>();
    public List<float> posH2 = new List<float>();
    public List<float> posW3 = new List<float>();
    public List<float> posH3 = new List<float>();
    public List<bool> SavedPlayer = new List<bool>();
    public string sceneName;
    public List<Vector3> vector3B = new List<Vector3>();


    public List<string> NamesCreatures = new List<string>();

    public List<string> DataItem = new List<string>();




}


