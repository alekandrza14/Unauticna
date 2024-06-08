using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class breauty : MonoBehaviour
{
    [HideInInspector] public int integer = 10;
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

    private void Awake()
    {
        // integer = 10;
    }

    private void Start()
    {
        if (GetComponent<itemName>() && Map_saver.t3.Length > 0)
        {
            // integer = 10;
            float f = integer;
            float t = f / 10f;
            GameObject g = null;
            foreach (GameObject item in Map_saver.t3)
            {
                if (item.GetComponent<itemName>()._Name == GetComponent<itemName>()._Name)
                {
                    g = item;
                }
            }
            v3 = g.transform.localScale;
            if (t < 0.9f)
            {
                gameObject.transform.localScale = v3 * t;
            }
            else if (t / 3f <= 1f)
            {
             //   gameObject.transform.localScale = v3 * (1f + (t / 3f));
            }
            else if (t >= 0.9f)
            {

            }
            else
            {
                gameObject.transform.localScale = v3 * (2.1f);
            }
        }
    }
    public void resset()
    {
        if (GetComponent<itemName>() && Map_saver.t3.Length > 0)
        {
            float f = integer;
            float t = f / 10f;
            if (t < 0.9f)
            {
                gameObject.transform.localScale = v3 * t;
            }
            else if (t / 3f <= 1f)
            {
             //   gameObject.transform.localScale = v3 * (1f + (t / 3f));
            }
            else if (t >= 0.9f)
            {

            }
            else
            {
                gameObject.transform.localScale = v3 * (2.1f);
            }
        }
    }

}
