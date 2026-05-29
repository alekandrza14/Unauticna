using ObjParser;
using System.Collections.Generic;
using UnityEngine;

public class CunkGenerator : MonoBehaviour
{
    public GameObject[] res;
    List<GameObject> pul = new List<GameObject>();
    public Vector4 Cancord3 = Vector4.zero;
    public Vector4 Cancord3_3 = Vector4.zero;
    public Vector4Int Cancord3_2 = Vector4Int.zero;
    Vector4Int Cancord3_old = Vector4Int.up_max;
    public int id;
    void Update()
    {
        Cancord3 = new Vector4(mover.main().transform.position.x,
            mover.main().transform.position.y,
            mover.main().transform.position.z,
            mover.main().W_position
            );
        Cancord3_2 = new Vector4Int((int)(Cancord3.x / 100) * 100, (int)(Cancord3.y / 100) * 100, (int)(Cancord3.z / 100) * 100, (int)(Cancord3.w / 100) * 100);
        Cancord3_3 = new Vector4((int)(Cancord3.x / 100) * 100, (int)(Cancord3.y / 100) * 100, (int)(Cancord3.z / 100) * 100, (int)(Cancord3.w / 100) * 100);
        if (Cancord3_2.x != Cancord3_old.x ||
            Cancord3_2.y != Cancord3_old.y ||
            Cancord3_2.z != Cancord3_old.z ||
            Cancord3_2.w != Cancord3_old.w)
        {
            if (pul.Count!=0)
            {

                UpdateChank();
                Debug.Log("<color=green>Chank Rebuild</color>");
            }
            else
            {
                StartGen();
                UpdateChank();
                Debug.Log("<color=green>Chank Build</color>");
            }
            Debug.Log("<color=green>Chank Updated</color>");
            
        }
    }
    public void StartGen()
    {
        for (int i = 0; i < 100; i++)
        {
           
                    System.Random ra = new System.Random(Cancord3_2.x + (Cancord3_2.y * 566) + (Cancord3_2.z * 906) - (Cancord3_2.w * 453) + i+id);
                  //  Vector3 sau = hit.normal;
                  //  sau *= 0.01f;
                    pul.Add(Instantiate(res[ra.Next(0, res.Length)], Vector3.one, Quaternion.identity));
                   
        }
    }
    public void UpdateChank()
    {
        for (int i = 0; i < pul.Count; i++)
        {
            
                //pul[i]
                Ray r = new Ray(new Vector3(Cancord3_2.x, Cancord3_2.y, Cancord3_2.z) + new Vector3(0, 100, 0), Global.math.randomCubeDeterminatic(-10, 10, Cancord3_2.x + (Cancord3_2.y * 566) + (Cancord3_2.z * 906) - (Cancord3_2.w * 453) + i + id, i));
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        //hit.point, Quaternion.FromToRotation(Vector3.forward, -hit.normal)
                        Vector3 sau = hit.normal;
                        sau *= 0.01f;
                        pul[i].transform.position = hit.point + (sau);
                        pul[i].transform.rotation = Quaternion.FromToRotation(Vector3.forward, -hit.normal);
                        if (pul[i].transform.rotation.x > 0.2)
                        {
                            pul[i].transform.Rotate(0, 0, 180);
                        }
                        else
                        {

                        }

                    }
                }
             
        }
        Cancord3_old = Cancord3_2.copy();
    }

}
