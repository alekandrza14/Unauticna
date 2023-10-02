using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Burst.CompilerServices;
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
                string reserch = c.collider.gameObject.GetComponent<itemName>()._Name + gameObject.GetComponent<itemName>()._Name;

                Directory.CreateDirectory("unsave/var/technologies");
                if (!VarSave.ExistenceVar("technologies/" + reserch))
                    {
                        Directory.CreateDirectory("unsave/var/technologies");
                        VarSave.LoadMoney("_technologies", 1);
                        Globalprefs.technologies = VarSave.GetMoney("_technologies");
                        VarSave.SetInt("technologies/" + reserch, 0);
                    }

                   

                Instantiate(element[i].item,transform.position,transform.rotation);
                Destroy(gameObject);
                Destroy(c.collider.gameObject);
            }
        }
    }
}
