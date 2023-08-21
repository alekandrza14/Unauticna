using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUTOSAVE : MonoBehaviour
{
    public GameObject i;
    public bool isdone;
    public bool onetimes = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && !isdone)
        {
            Instantiate(i, transform.position, transform.rotation);
            GameManager.saveandhill();
if(onetimes){
            isdone = true;
}
        }
    }
}
