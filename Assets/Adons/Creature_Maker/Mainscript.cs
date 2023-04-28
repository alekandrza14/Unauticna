using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainscript : MonoBehaviour
{
    public GameObject telo;
    public long hp;
    public void selfLeft()
    {
        Destroy(this.gameObject);
    }
}
