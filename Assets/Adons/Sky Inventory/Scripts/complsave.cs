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


    public string lif;

    public static string[] nunames = new string[0];


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

        Directory.CreateDirectory(VarSave.Worldpath + @"/objects");
        lif = "";
        if(!FindAnyObjectByType<StaticAnyversePosition>()) lif += Globalprefs.GetIdPlanet().ToString(); 
        lif += "_" + Globalprefs.GetTimeline();
        getallitems();
        load();
        for (int i = 0; i < GameObject.FindObjectsByType<itemspawn>(sortmode.main).Length; i++)
        {
            if (VarSave.GetBool("/objects/item" + SceneManager.GetActiveScene().name + lif + i,SaveType.world) != true)
            {


                GameObject.FindObjectsByType<itemspawn>(sortmode.main)[i].sp();
                VarSave.SetBool("/objects/item" + SceneManager.GetActiveScene().name + lif + i, true, SaveType.world);


            }
            if (GameObject.FindObjectsByType<itemspawn>(sortmode.main).Length - 1 == i)
            {
                save();
            }
        }

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
        saveString1 = new rsave();

        Directory.CreateDirectory(name2 + @"/objects");
        itemName[] items = FindObjectsByType<itemName>(sortmode.main);


            if (items.Length != 0)
            {


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
                    if (items[i3].GetComponent<HyperbolicPoint>())
                    {
                        saveString1.PvectorA.Add(JsonUtility.ToJson(items[i3].GetComponent<HyperbolicPoint>().HyperboilcPoistion));
                        saveString1.y.Add(items[i3].GetComponent<HyperbolicPoint>().v1);
                    }
                    if (items[i3].GetComponent<itemName>())
                    {
                        saveString1.DataItem.Add(items[i3].GetComponent<itemName>().ItemData);

                    }
                    else
                    {
                        saveString1.DataItem.Add("0");

                    }



                    saveString1.vector3A.Add(items[i3].transform.position);
                    saveString1.Scale3A.Add(items[i3].transform.localScale);
                    saveString1.qA.Add(items[i3].transform.rotation);

                }
            }

        telo[] t = FindObjectsByType<telo>(sortmode.main);

        for (int i = 0; i < t.Length; i++)
        {
            saveString1.vector3B.Add(t[i].transform.position);
            saveString1.NamesCreatures.Add(t[i].nameCreature);


        }
        CustomObject[] co = FindObjectsByType<CustomObject>(sortmode.main);

        for (int i = 0; i < co.Length; i++)
        {
            saveString1.vector3D.Add(co[i].transform.position);
            saveString1.idC.Add(co[i].s);
            saveString1.SavedPlayer.Add(true);
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


        }
        StandartObject[] so = FindObjectsByType<StandartObject>(sortmode.main);
        for (int i = 0; i < so.Length; i++)
        {
            saveString1.vector3C.Add(so[i].transform.position);
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


        }






        Directory.CreateDirectory(name2.ToString());
        File.WriteAllText(name2.ToString() + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name, JsonUtility.ToJson(saveString1));


        saveString1 = new rsave();


    }
    public void load()
    {
       
        Directory.CreateDirectory( name2 + @"/objects");


        saveString1 = new rsave();
        saveString221 = Path.Combine("",   name2 + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name);


        for (int c = 0; c < 2; c++)
        {
            if (c == 0)
            {
                if (File.Exists(saveString221))
                {
                    saveString1 = JsonUtility.FromJson<rsave>(File.ReadAllText(saveString221));

                    Debug.Log("IU");
                }
                else
                {
                    Debug.Log("IU2");

                    File.WriteAllText(name2 + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name, JsonUtility.ToJson(saveString1));
                    saveString1 = JsonUtility.FromJson<rsave>(File.ReadAllText(saveString221));

                }













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
                    if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().W_Position = saveString1.posW[i];

                    if (saveString1.Scale3B[i].x != 0) g.transform.localScale = saveString1.Scale3B[i];

                }
               GameObject co = Resources.Load<GameObject>("CustomObject");
                for (int i = 0; i < saveString1.idC.Count; i++)
                {

                    GameObject g = Instantiate(co, saveString1.vector3D[i], Quaternion.identity);
                    g.GetComponent<CustomObject>().s = saveString1.idC[i];
                   g.GetComponent<CustomObject>().WHPos = new Vector2 (saveString1.posW2[i], saveString1.posH2[i]);
                    g.GetComponent<CustomObject>().saved = saveString1.SavedPlayer[i];

                }
                if (saveString1.PvectorA.Count == 0)
                {


                    for (int i3 = 0; i3 < saveString1.idA.Count; i3++)
                    {




                        Debug.Log(saveString1.idA[i3]);
                        GameObject g = Instantiate(t3[toNameToID(saveString1.idA[i3])].gameObject, new Vector3(saveString1.vector3A[i3].x, saveString1.vector3A[i3].y, saveString1.vector3A[i3].z), saveString1.qA[i3]);
                        if (!g.GetComponent<breauty>())
                        {


                            g.AddComponent<breauty>().integer = saveString1.x[i3];
                        }
                        else
                        {
                            g.GetComponent<breauty>().integer = saveString1.x[i3];
                        }
                        if (g.GetComponent<itemName>())
                        {
                            g.GetComponent<itemName>().ItemData = saveString1.DataItem[i3];
                        }
                       if(saveString1.Scale3A[i3].x!=0) g.transform.localScale = saveString1.Scale3A[i3];

                    }
                }
                else
                {
                    for (int i3 = 0; i3 < saveString1.idA.Count; i3++)
                    {




                        Debug.Log("1");
                        GameObject g = Instantiate(t3[toNameToID(saveString1.idA[i3])].gameObject, new Vector3(0, 0, 0), saveString1.qA[i3]);
                        if (!g.GetComponent<breauty>())
                        {


                            g.AddComponent<breauty>().integer = saveString1.x[i3];
                        }
                        else
                        {
                            g.GetComponent<breauty>().integer = saveString1.x[i3];
                        }
                        if (!g.GetComponent<HyperbolicPoint>())
                        {


                            g.AddComponent<HyperbolicPoint>().HyperboilcPoistion = JsonUtility.FromJson<Hyperbolic2D>(saveString1.PvectorA[i3]);

                            g.transform.position = new Vector3(
                            g.transform.position.x,
                            saveString1.vector3A[i3].y,
                            g.transform.position.z
                                             );
                        }
                        else
                        {
                            g.GetComponent<HyperbolicPoint>().HyperboilcPoistion = JsonUtility.FromJson<Hyperbolic2D>(saveString1.PvectorA[i3]);
                            g.transform.position = new Vector3(
                            g.transform.position.x,
                            saveString1.vector3A[i3].y,
                            g.transform.position.z
                                             );
                        }
                        if (g.GetComponent<itemName>())
                        {
                            g.GetComponent<itemName>().ItemData = saveString1.DataItem[i3];
                        }

                    }
                }




            }
            if (c == 1)
            {
                foreach (InventoryEvent i2 in FindObjectsByType<InventoryEvent>(sortmode.main))
                {
                    i2.Load();
                    LoadADone = true;
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
    public List<Vector3> vector3D = new List<Vector3>();
    public List<Vector3> Scale3A = new List<Vector3>();
    public List<Vector3> Scale3B = new List<Vector3>();
    public List<Vector3> vector3C = new List<Vector3>();
    public List<string> PvectorA = new List<string>();
    public List<Quaternion> qA = new List<Quaternion>();
    public List<int> x = new List<int>();
    public List<float> y = new List<float>();
    public List<string> idA = new List<string>();
    public List<string> idB = new List<string>();
    public List<string> idC = new List<string>();
    public List<float> posW = new List<float>();
    public List<float> posW2 = new List<float>();
    public List<float> posH = new List<float>();
    public List<float> posH2 = new List<float>();
    public List<bool> SavedPlayer = new List<bool>();

    public List<Vector3> vector3B = new List<Vector3>();


    public List<string> NamesCreatures = new List<string>();

    public List<string> DataItem = new List<string>();




}


