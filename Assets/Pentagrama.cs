using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Pentagrama : MonoBehaviour
{
    [SerializeField] GameObject[] tragets;
    [SerializeField] string[] items;
    gsave gsave = new gsave();

    int _true;
    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            
            for (int i = 0;i<tragets.Length;i++)
            {
                Ray r = new Ray(tragets[i].transform.position, -tragets[i].transform.up);
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    itemName item = hit.collider.gameObject.GetComponent<itemName>();

                    if (item._Name == items[i])
                    {
                        _true++;
                    }
                }
            }

            Debug.Log(_true);
            if (_true < items.Length)
            {
                _true = 0;
            }
            if (_true >= items.Length)
            {
                if (playerdata.Geteffect("Trip") != null)
                {
                    gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + Globalprefs.GetTimeline()));
                    if (gsave.progressofthepassage < 2)
                    {
                        playerdata.Addeffect("LevelUp", 60);
                        GameManager.save();
                        _true = 0;
                    }
                    Debug.Log("endRetual");
                }

            }
        }
    }

}
