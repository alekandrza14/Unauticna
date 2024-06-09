using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class itemspawn : MonoBehaviour
{
    public string prefabname;
    public string prefabname2;
    public HyperbolicPoint hyperbolic;
    public bool FirstEvent;
    public string timeLine;
    public float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        if (FirstEvent)
        {
            if (VarSave.CreateEvent("item" + transform.position.x + transform.position.y + transform.position.z + SceneManager.GetActiveScene().buildIndex + Globalprefs.GetIdPlanet() + Globalprefs.GetTimeline()+DateTime.Now.DayOfYear.ToString()))
            {
                sp();
            }
        }
        
                 
            
        
    }

    // Update is called once per frame
    public void sp()
    {
        csp();
        if (string.IsNullOrEmpty(timeLine))
        {
            Spawn();
        }

    }

    private void Spawn()
    {
        if (Global.Random.Chance(17)&& !string.IsNullOrEmpty(prefabname2))
        {
            prefabname = prefabname2;
        }
            GameObject g = Instantiate(Resources.Load<GameObject>("items/" + prefabname), transform.position, transform.rotation);
        if (hyperbolic != null)
        {
            g.gameObject.AddComponent<HyperbolicPoint>().HyperboilcPoistion = hyperbolic.HyperboilcPoistion;
            g.transform.position = new Vector3(
                0,
                hyperbolic.transform.position.y+ offsetY,
                0
                );
            g.gameObject.GetComponent<HyperbolicPoint>().ScriptSacle = g.gameObject.transform.localScale;

        }
    }

    public void csp()
    {
        if (!string.IsNullOrEmpty(timeLine))
        {
            if (timeLine == Globalprefs.GetTimeline())
            {
                Spawn();
            }
        }

    }
}
