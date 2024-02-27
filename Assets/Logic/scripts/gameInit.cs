using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransformObject
{
    public Vector3[] v3;
    public Quaternion[] q4;
    public Vector3[] s3;
    public string[] name;
    public Vector3[] initpos;

}

public class gameInit : MonoBehaviour
{
    static public GameObject init;

    Specilpositiuon specilpositiuon = new Specilpositiuon();

    static public void Init(GameObject g)
    {
#if !UNITY_EDITOR
        dnSpyModer.MainModData.Main();
#endif

       
        if (init==null) {
            g.AddComponent<gameInit>();
            init = g;
        }
        else
        {
            g.AddComponent<deleter1>();
        }
        if(Directory.Exists("C:/data/t")) Directory.Delete("C:/data/t",true);
        Debug.Log("Forck?");
    }


    private void Update()
    {
        if (VarSave.ExistenceVar("res3", SaveType.global) && SceneManager.GetActiveScene().buildIndex != 129)
            Screen.SetResolution(VarSave.GetInt("res3", SaveType.global), VarSave.GetInt("res4", SaveType.global), !VarSave.GetBool("windowed", SaveType.global));

        if (Globalprefs.RadarOn) 
        { tag2dmap[] m2 = FindObjectsByType<tag2dmap>(sortmode.main);
            if (m2.Length >= 0)
            {
                Directory.CreateDirectory("C:/data/t");
                mover m = mover.main();
                specilpositiuon.pos = new List<Vector2>();
                for (int i = 0; i < m2.Length; i++)
                {
                    Vector3 v3 = m2[i].transform.position;
                    //m2.Length
                    specilpositiuon.pos.Add(new Vector2(v3.x - m.transform.position.x, v3.z - m.transform.position.z));

                    VarSave.SetString("t/points" + i, specilpositiuon.pos[i].x/20 + " " + specilpositiuon.pos[i].y/20, SaveType.computer);

                }
            } 
        }
    }

}
public class Specilpositiuon
{
    public List<Vector2> pos = new List<Vector2>();
}