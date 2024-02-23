using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnline : MonoBehaviour
{
    public GameObject spl;
    public long lg;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < lg && !VarSave.GetBool("partic"); i++)
        {
            Instantiate(spl, transform.position + new Vector3(0, i * 3, 0), Quaternion.identity);
        }
    }

  
}
