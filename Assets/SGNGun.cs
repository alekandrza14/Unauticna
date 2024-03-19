using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGNGun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SGNCharacter.Instance.povid == PvidSGN.strelat)
        {

            Instantiate(Resources.Load<GameObject>("SGNBoll"), gameObject.transform.position, Quaternion.identity);
        }
        if (SGNCharacter.Instance.povid == PvidSGN.pantovatsa)
        {

            Instantiate(Resources.Load<GameObject>("SGNBoll"), gameObject.transform.position, Quaternion.identity); 
            Instantiate(Resources.Load<GameObject>("SGNBoll"), gameObject.transform.position, Quaternion.identity);
        }
    }
}
