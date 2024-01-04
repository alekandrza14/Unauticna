using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDemake
{
    public List<string> item = new List<string>();
    public List<string> co = new List<string>();
}

public class Duper : MonoBehaviour
{
    [SerializeField] Transform point;
    [SerializeField] bool delete;
    [SerializeField] bool gdm;
    ItemDemake Demake = new ItemDemake();
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.E))
            {
                Ray updown = new Ray(point.position, -point.up);
                RaycastHit hitupdown;
                if (Physics.Raycast(updown, out hitupdown))
                {
                    if (!delete && !gdm)
                    {
                        GameObject obj = Instantiate(hitupdown.collider.gameObject, point.position, Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                    }
                    else if (delete)
                    {
                        if (hitupdown.collider.gameObject != gameObject) Destroy(hitupdown.collider.gameObject);
                    }
                    else if (gdm)
                    {
                        if (hitupdown.collider.gameObject != gameObject)
                        {
                            //  Destroy(hitupdown.collider.gameObject);
                          if(VarSave.GetString("Demake" + Globalprefs.Reality) != "")  Demake = JsonUtility.FromJson<ItemDemake>(VarSave.GetString("Demake"+Globalprefs.Reality));
                            if (hitupdown.collider.GetComponent<itemName>()) Demake.item.Add(hitupdown.collider.GetComponents<itemName>()[0]._Name);
                            if (hitupdown.collider.GetComponent<CustomObject>()) Demake.co.Add(hitupdown.collider.GetComponent<CustomObject>().s);
                            VarSave.SetString("Demake" + Globalprefs.Reality, JsonUtility.ToJson(Demake));
                        }
                    }
                }
            }
        }
    }
}
