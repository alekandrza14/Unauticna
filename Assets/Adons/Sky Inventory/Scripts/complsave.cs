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


    public GameObject[] t3;
    public GameObject[] t4;
    public string[] info4;


    public string lif;

    public string[] nunames;


    public string[] info3;


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

    public void getallitems()
    {

        GameObject[] g = Resources.LoadAll<GameObject>("items");
        t3 = new GameObject[g.Length];
        info3 = new string[g.Length];
        for (int i = 0; i < g.Length; i++)
        {
            t3[i] = g[i];
            info3[i] = g[i].tag;

        }
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
        for (int i = 0; i < info3.Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag(info3[i]).Length != 0)
            {


                for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag(info3[i]).Length; i3++)
                {


                    if (GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<breauty>())
                    {
                        GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<breauty>();
                    }
                    else
                    {
                        GameObject.FindGameObjectsWithTag(info3[i])[i3].AddComponent<breauty>().integer = 10;

                    }




                }
            }

        }
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

        saveString1.DataItem.Clear();
        saveString1.vector3A.Clear();
        saveString1.vector3A2.Clear();
        saveString1.PvectorA.Clear();
        saveString1.qA.Clear();
        saveString1.x.Clear();
        saveString1.y.Clear();
        saveString1.id.Clear();
        saveString1.id2.Clear();
        saveString1.vector3B.Clear();
        saveString1.NamesCreatures.Clear();
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

        for (int i = 0; i < FindObjectsByType<telo>(sortmode.main).Length; i++)
        {


            GameObject.FindObjectsByType<telo>(sortmode.main)[i].gameObject.AddComponent<deleter1>();
        }
        for (int i = 0; i < FindObjectsByType<StandartObject>(sortmode.main).Length; i++)
        {


            GameObject.FindObjectsByType<StandartObject>(sortmode.main)[i].gameObject.AddComponent<deleter1>();
        }
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void save()
    {


        saveString1.DataItem.Clear();
        saveString1.vector3A.Clear();
        saveString1.vector3A2.Clear();
        saveString1.PvectorA.Clear();
        saveString1.qA.Clear();
        saveString1.x.Clear();
        saveString1.y.Clear();
        saveString1.id.Clear();
        saveString1.id2.Clear();
        saveString1.vector3B.Clear();
        saveString1.NamesCreatures.Clear();

        Directory.CreateDirectory(name2 + @"/objects");

        for (int i = 0; i < info3.Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag(info3[i]).Length != 0)
            {


                for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag(info3[i]).Length; i3++)
                {

                    saveString1.id.Add(info3[i]);
                    if (GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<breauty>())
                    {
                        saveString1.x.Add(GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<breauty>().integer);
                    }
                    else
                    {
                        saveString1.x.Add(GameObject.FindGameObjectsWithTag(info3[i])[i3].AddComponent<breauty>().integer = 10);

                    }
                    if (GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<HyperbolicPoint>())
                    {
                        saveString1.PvectorA.Add(JsonUtility.ToJson(GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<HyperbolicPoint>().HyperboilcPoistion));
                        saveString1.y.Add(GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<HyperbolicPoint>().v1);
                    }
                    if (GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<itemName>())
                    {
                        saveString1.DataItem.Add(GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<itemName>().ItemData);

                    }
                    else
                    {
                        saveString1.DataItem.Add("0");

                    }



                    saveString1.vector3A.Add(GameObject.FindGameObjectsWithTag(info3[i])[i3].transform.position);
                    saveString1.qA.Add(GameObject.FindGameObjectsWithTag(info3[i])[i3].transform.rotation);

                }
            }

        }

        for (int i = 0; i < FindObjectsByType<telo>(sortmode.main).Length; i++)
        {
            saveString1.vector3B.Add(FindObjectsByType<telo>(sortmode.main)[i].transform.position);
            saveString1.NamesCreatures.Add(FindObjectsByType<telo>(sortmode.main)[i].nameCreature);


        }
        for (int i = 0; i < FindObjectsByType<StandartObject>(sortmode.main).Length; i++)
        {
            saveString1.vector3A2.Add(FindObjectsByType<StandartObject>(sortmode.main)[i].transform.position);
            saveString1.id2.Add(FindObjectsByType<StandartObject>(sortmode.main)[i].init);
            if (FindObjectsByType<StandartObject>(sortmode.main)[i].
                GetComponent<MultyObject>())
                saveString1.posW.Add(
                    FindObjectsByType<StandartObject>(sortmode.main)[i].
                    GetComponent<MultyObject>().W_Position);
            else
            {
                saveString1.posW.Add(0);
            }


        }






        Directory.CreateDirectory(name2.ToString());
        File.WriteAllText(name2.ToString() + @"/objects/scene_" + lif + SceneManager.GetActiveScene().name, JsonUtility.ToJson(saveString1));

        saveString1.vector3A.Clear();
        saveString1.vector3A2.Clear();
        saveString1.PvectorA.Clear();
        saveString1.qA.Clear();
        saveString1.x.Clear();
        saveString1.y.Clear();
        saveString1.id.Clear();
        saveString1.id2.Clear();
        saveString1.vector3B.Clear();
        saveString1.NamesCreatures.Clear();
        saveString1.posW.Clear();
        saveString1.DataItem.Clear();


    }
    public void load()
    {

        Directory.CreateDirectory( name2 + @"/objects");

        saveString1.DataItem.Clear();

        saveString1.vector3A.Clear();
        saveString1.vector3A2.Clear();
        saveString1.PvectorA.Clear();
        saveString1.qA.Clear();
        saveString1.x.Clear();
        saveString1.y.Clear();
        saveString1.id.Clear();
        saveString1.id2.Clear();
        saveString1.vector3B.Clear();
        saveString1.NamesCreatures.Clear();
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

                for (int i = 0; i < FindObjectsByType<telo>(sortmode.main).Length; i++)
                {


                    GameObject.FindObjectsByType<telo>(sortmode.main)[i].gameObject.AddComponent<deleter1>();
                }
                for (int i = 0; i < FindObjectsByType<StandartObject>(sortmode.main).Length; i++)
                {


                    GameObject.FindObjectsByType<StandartObject>(sortmode.main)[i].gameObject.AddComponent<deleter1>();
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
                for (int i = 0; i < saveString1.id2.Count; i++)
                {

                    GameObject g = Instantiate(t4[toTagToIDObject(saveString1.id2[i])], saveString1.vector3A2[i], Quaternion.identity);
                    if (g.GetComponent<MultyObject>()) g.GetComponent<MultyObject>().W_Position = saveString1.posW[i];


                }
                if (saveString1.PvectorA.Count == 0)
                {


                    for (int i3 = 0; i3 < saveString1.id.Count; i3++)
                    {




                        Debug.Log(saveString1.id[i3]);
                        GameObject g = Instantiate(t3[toTagToID(saveString1.id[i3])].gameObject, new Vector3(saveString1.vector3A[i3].x, saveString1.vector3A[i3].y, saveString1.vector3A[i3].z), saveString1.qA[i3]);
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

                    }
                }
                else
                {
                    for (int i3 = 0; i3 < saveString1.id.Count; i3++)
                    {




                        Debug.Log("1");
                        GameObject g = Instantiate(t3[toTagToID(saveString1.id[i3])].gameObject, new Vector3(0, 0, 0), saveString1.qA[i3]);
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
                }
            }


        }





    }

    public int toTagToID(string tag)
    {
        int u = 0;

        getallitems();
        for (int i = 0; i < info3.Length; i++)
        {
            if (tag == info3[i])
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
    public List<Vector3> vector3A2 = new List<Vector3>();
    public List<string> PvectorA = new List<string>();
    public List<Quaternion> qA = new List<Quaternion>();
    public List<int> x = new List<int>();
    public List<float> y = new List<float>();
    public List<string> id = new List<string>();
    public List<string> id2 = new List<string>();
    public List<float> posW = new List<float>();

    public List<Vector3> vector3B = new List<Vector3>();


    public List<string> NamesCreatures = new List<string>();

    public List<string> DataItem = new List<string>();




}


