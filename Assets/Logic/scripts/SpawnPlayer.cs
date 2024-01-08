using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject mover;

    void Start()
    {
        Ray r = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit hit;
        

        
        if (Physics.Raycast(r, out hit))
        {
            Instantiate(mover, hit.point, Quaternion.identity);
        }
    }
    private void Update()
    {
        if (!VarSave.ExistenceVar("planetA" + Globalprefs.GetIdPlanet(), SaveType.world)){
            if (FindObjectsByType<Chaos_cube>(sortmode.main).Length == 0)
            {
                for (int i = 0; i < 9; i++) Instantiate(Resources.Load<GameObject>("items/Chaos_cube").gameObject, new Vector3(
                     Random.Range(-300, 300),
                     Random.Range(-300, 300),
                     Random.Range(-300, 300)), Quaternion.identity);
                for (int i = 0; i < 4; i++)
                {
                  GameObject g = Instantiate(Resources.Load<GameObject>("complectItems/4DChaos_cube").gameObject, new Vector3(
                     Random.Range(-300, 300),
                     Random.Range(-300, 300),
                     Random.Range(-300, 300)), Quaternion.identity);
                    g.GetComponent<MultyObject>().W_Position = Random.Range(-300, 300);
                }

            }
                if (FindObjectsByType<Chaos_cube>(sortmode.main).Length > 0)
            {
                GameManager.saveandhill();
                VarSave.SetFloat("planetA" + Globalprefs.GetIdPlanet(), 0,SaveType.world);

                Debug.Log("Spawn Done");

            }
        }
    }


}
