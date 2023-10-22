using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemspawn : MonoBehaviour
{
    public string prefabname;
    public HyperbolicPoint hyperbolic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void sp()
    {
      GameObject g = Instantiate(Resources.Load<GameObject>("items/"+prefabname), transform.position, transform.rotation);
        if (hyperbolic != null)
        {
            g.gameObject.AddComponent<HyperbolicPoint>().HyperboilcPoistion = hyperbolic.HyperboilcPoistion;
            g.transform.position = new Vector3(
                0,
                hyperbolic.transform.position.y,
                0
                );
            g.gameObject.GetComponent<HyperbolicPoint>().ScriptSacle = g.gameObject.transform.localScale;

        }

    }
}
