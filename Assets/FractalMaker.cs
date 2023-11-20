using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FractalMakerManager
{
    static public FractalMaker instance;
}

public class FractalMaker : MonoBehaviour
{
    public int startCountObjects;
    [SerializeField] Transform[] points;
    [SerializeField] float scaleDownUp;
    void Start()
    {
        if (FractalMakerManager.instance == null)
        {
            FractalMakerManager.instance = this;
            foreach (Transform tf in points)
            {
                GameObject obj = Instantiate(gameObject, tf.position, transform.rotation * tf.rotation, transform);
                obj.transform.localScale *= scaleDownUp;
            }
        }
        if (FractalMakerManager.instance != null)
        {

            foreach (Transform tf in points)
            {



                if (startCountObjects > FindObjectsByType<FractalMaker>(FindObjectsSortMode.None).Length)
                {
                    GameObject obj = Instantiate(gameObject, tf.position, transform.rotation * tf.rotation, transform);
                    obj.transform.localScale *= scaleDownUp;
                }

            }
        }
       

    }
}
