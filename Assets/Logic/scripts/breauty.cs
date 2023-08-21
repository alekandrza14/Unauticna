using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class breauty : MonoBehaviour
{
    public int integer = 10;
    Vector3 v3;
    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            if (integer <= 0)
            {
                VarSave.SetBool("cry", true);



                VarSave.SetBool("прикоснулся к анти материи", true);



                

                    GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);
               
            }
        }
    }
    private void Start()
    {
        float f = integer;
        float t = f / 10f;
        v3 = gameObject.transform.localScale;
        if (t <= 1)
        {
            gameObject.transform.localScale = v3 * t;
        }
        else if (t / 3f <= 1f)
        {
            gameObject.transform.localScale = v3 * (1f + (t / 3f));
        }
        else
        {
            gameObject.transform.localScale = v3 * (2.1f);
        }
    }
    public void resset()
    {
        float f = integer;
        float t = f / 10f;
        if (t<=1) {
            gameObject.transform.localScale = v3 * t;
        }
        else if (t / 3f <= 1f)
        {
            gameObject.transform.localScale = v3 * (1f + (t / 3f));
        }
        else 
        {
            gameObject.transform.localScale = v3 * (2.1f);
        }
    }
    
}
