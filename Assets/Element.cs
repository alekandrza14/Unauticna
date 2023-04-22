using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class El
{
    [SerializeField] public GameObject element;
    [SerializeField] public GameObject item;

}
public class Element : MonoBehaviour
{
    [SerializeField] public El[] element;

   

    private void Start()
    {
        gameObject.AddComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().drag = 100;
        gameObject.GetComponent<Rigidbody>().angularDrag = 100;
    }
    private void OnCollisionEnter(Collision c)
    {
        for (int i =0; i< element.Length;i++)
        {
           if( element[i].element.tag == c.collider.tag)
            {
                Instantiate(element[i].item,transform.position,transform.rotation);
                Destroy(gameObject);
                Destroy(c.collider.gameObject);
            }
        }
    }
}
