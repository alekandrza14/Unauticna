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
        if (!VarSave.EnterFloat("planetA" + Globalprefs.GetIdPlanet())){
            if (FindObjectsOfType<Chaos_cube>().Length == 0)
            {
                for (int i = 0; i < 9; i++) Instantiate(Resources.Load<GameObject>("items/Chaos_cube").gameObject, new Vector3(
                     Random.Range(-300, 300),
                     Random.Range(-300, 300),
                     Random.Range(-300, 300)), Quaternion.identity);

            }
            if (FindObjectsOfType<Chaos_cube>().Length > 0)
            {
                musave.saveandhill();
                VarSave.SetFloat("planetA" + Globalprefs.GetIdPlanet(), 0);

                Debug.Log("Spawn Done");

            }
        }
    }


}
