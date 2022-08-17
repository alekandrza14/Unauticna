using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemspawn : MonoBehaviour
{
    public string prefabname;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void sp()
    {
        Instantiate(Resources.Load<GameObject>("items/"+prefabname), transform.position, transform.rotation);
        
    }
}
