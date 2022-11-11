using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fallzone : MonoBehaviour
{
    public GameObject up1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, up1.gameObject.transform.position.y, other.gameObject.transform.position.z);
        }
    }
}
