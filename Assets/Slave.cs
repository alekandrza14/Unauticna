using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public class Slave : MonoBehaviour
{
    public static List<GameObject> plevk =new();
    public GameObject metka;
    public string slaveData;
    public Vector3 slavePosition;
    Transform ПлевковаяКаст, taktikpoint1;
    private void Start()
    {
        if (gameObject.GetComponent<SocialObject>())
        {
            gameObject.GetComponent<SocialObject>().AddishonalLoad(new[] { "Slave" });
        }
        slavePosition = transform.position;
        metka = Instantiate(Resources.Load<GameObject>("selectUnit"),transform);
        metka.SetActive(false);
    }
    public void onSelect()
    {
        gameunitselect._this = gameObject;
    }
    Transform spittinglull()
    {
        if (ПлевковаяКаст == null) ПлевковаяКаст = FindFirstObjectByType<ПлевковаяКастрюля>().transform;
        return ПлевковаяКаст;
    }
    Transform taktikpoint2()
    {
        if (taktikpoint1 == null) 
        {
            if (FindFirstObjectByType<taktikpoint>()) 
            {
                taktikpoint1 = FindFirstObjectByType<taktikpoint>().transform;
            }
            else
            {
                return transform;
            }
        }
        return taktikpoint1;
    }
    private void FixedUpdate()
    {
       
        
        if (slaveData=="stoping")
        {
            transform.position = slavePosition;
        }
        else
        {

            slavePosition = transform.position;
        }
        if (slaveData == "spitting")
        {
          if (!plevk.Contains(gameObject))  plevk.Add(gameObject);
            Transform igrok = spittinglull();
            igrok.GetComponent<ПлевковаяКастрюля>().OnSignal();
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameunitselect._this = null;
            }
            if (Vector3.Distance(igrok.position, transform.position) > 3)
            {

                Vector3 Rotation = igrok.position - transform.position;
                transform.rotation = Quaternion.LookRotation(Rotation, transform.up);
                transform.position += transform.forward * (6f * Time.deltaTime);
                transform.Rotate(0, -90, 0);
                transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                //  transform.transform.localPosition = new Vector3(transform.position.x, 0.5f, transform.position.z);
            }

        }
        else
        {

            if (plevk.Contains(gameObject)) plevk.Remove(gameObject);
        }
        if (taktikpoint2())
        {
            Transform igrok = taktikpoint2();
            if (gameunitselect._this == gameObject) metka.SetActive(true); else { metka.SetActive(false); }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameunitselect._this = null;
            }
            if (gameunitselect._this == gameObject && Vector3.Distance(igrok.position, transform.position) > 3)
            {

                Vector3 Rotation = igrok.position - transform.position;
                transform.rotation = Quaternion.LookRotation(Rotation, transform.up);
                transform.position += transform.forward * (6f * Time.deltaTime);
                transform.Rotate(0, -90, 0);
                transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                //  transform.transform.localPosition = new Vector3(transform.position.x, 0.5f, transform.position.z);
            }
        }
    }
}
