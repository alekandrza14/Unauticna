using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDemake
{
    public List<string> item = new List<string>();
    public List<string> co = new List<string>();
}
public enum Inator
{
    Duper,Deleter,Demeker,Restorer
}
public class Duper : MonoBehaviour
{
    [SerializeField] Transform point;
    [SerializeField] Inator inator;
    ItemDemake Demake = new ItemDemake();
    public void OnSignal()
    {
        Ray updown = new Ray(point.position, -point.up);
        RaycastHit hitupdown;
        if (Physics.Raycast(updown, out hitupdown))
        {
            if (inator == Inator.Duper)
            {
                GameObject obj = Instantiate(hitupdown.collider.gameObject, point.position, Quaternion.identity);
                obj.name = obj.name.Remove(obj.name.Length - 7);
            }
            else if (inator == Inator.Deleter)
            {
                if (hitupdown.collider.GetComponent<SocialObject>())
                {
                    Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                    VarSave.SetInt("Agr", cistalenemy.dies);
                }
                if (hitupdown.collider.GetComponent<CharacterName>())
                {
                    Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                    VarSave.SetInt("Agr", cistalenemy.dies);
                }
                if (hitupdown.collider.GetComponent<CharacterStats>())
                {
                    Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                    VarSave.SetInt("Agr", cistalenemy.dies);
                }
                if (hitupdown.collider.GetComponent<itemName>())
                {
                    if (hitupdown.collider.GetComponent<itemName>().isLife)
                    {
                        Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                        VarSave.SetInt("Agr", cistalenemy.dies);
                    }
                }
                GameObject select = hitupdown.collider.gameObject;
                if (select.GetComponent<itemName>().ItemDangerLiberty != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty2 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty2, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty3 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty3, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty4 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty4, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty5 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty5, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty6 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty6, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty7 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty7, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty8 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty8, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty9 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty9, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty2 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty2, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty3 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty3, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty4 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty4, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty5 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty5, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty6 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty6, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty7 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty7, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty8 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty8, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty9 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty9, 1);

                }
                if (hitupdown.collider.gameObject != gameObject) Destroy(hitupdown.collider.gameObject);
            }
            else if (inator == Inator.Demeker)
            {
                if (hitupdown.collider.GetComponent<SocialObject>())
                {
                    Globalprefs.LoadTevroPrise(-1000); cistalenemy.dies += 1000;

                    VarSave.SetInt("Agr", cistalenemy.dies);
                }
                if (hitupdown.collider.GetComponent<CharacterName>())
                {
                    Globalprefs.LoadTevroPrise(-1000); cistalenemy.dies += 1000;

                    VarSave.SetInt("Agr", cistalenemy.dies);
                }
                if (hitupdown.collider.GetComponent<CharacterStats>())
                {
                    Globalprefs.LoadTevroPrise(-1000); cistalenemy.dies+=1000;

                    VarSave.SetInt("Agr", cistalenemy.dies);
                }
                if (hitupdown.collider.GetComponent<itemName>())
                {
                    if (hitupdown.collider.GetComponent<itemName>().isLife)
                    {
                        Globalprefs.LoadTevroPrise(-1000); cistalenemy.dies += 1000;

                        VarSave.SetInt("Agr", cistalenemy.dies);
                    }
                }
                if (hitupdown.collider.gameObject != gameObject)
                {
                    //  Destroy(hitupdown.collider.gameObject);
                    if (VarSave.GetString("Demake" + Globalprefs.Reality) != "") Demake = JsonUtility.FromJson<ItemDemake>(VarSave.GetString("Demake" + Globalprefs.Reality));
                    if (hitupdown.collider.GetComponent<itemName>()) Demake.item.Add(hitupdown.collider.GetComponents<itemName>()[0]._Name);
                    if (hitupdown.collider.GetComponent<CustomObject>()) Demake.co.Add(hitupdown.collider.GetComponent<CustomObject>().s);
                    VarSave.SetString("Demake" + Globalprefs.Reality, JsonUtility.ToJson(Demake));
                }
                GameObject select = hitupdown.collider.gameObject;
                if (select.GetComponent<itemName>().ItemDangerLiberty != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty2 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty2, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty3 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty3, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty4 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty4, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty5 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty5, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty6 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty6, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty7 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty7, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty8 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty8, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty9 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty9, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty2 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty2, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty3 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty3, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty4 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty4, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty5 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty5, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty6 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty6, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty7 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty7, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty8 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty8, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty9 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty9, 1);

                }
            }
            else if (inator == Inator.Restorer)
            {
                if (hitupdown.collider.gameObject != gameObject)
                {
                    //  Destroy(hitupdown.collider.gameObject);
                    if (VarSave.GetString("Demake" + Globalprefs.Reality) != "") Demake = JsonUtility.FromJson<ItemDemake>(VarSave.GetString("Demake" + Globalprefs.Reality));
                    if (hitupdown.collider.GetComponent<itemName>())
                    {
                        for (int i = 0; i < Demake.item.Count; i++)
                        {

                            if (Demake.item[i] == hitupdown.collider.GetComponents<itemName>()[0]._Name)
                            {
                                Demake.item.RemoveAt(i);
                            }
                        }
                    }
                    if (hitupdown.collider.GetComponent<CustomObject>())
                        for (int i = 0; i < Demake.co.Count; i++)
                        {

                            if (Demake.co[i] == hitupdown.collider.GetComponent<CustomObject>().s)
                            {
                                Demake.co.RemoveAt(i);
                            }
                        }
                    VarSave.SetString("Demake" + Globalprefs.Reality, JsonUtility.ToJson(Demake));
                }
            }
        }
    
    Debug.Log("its Work");
    }
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
                    if (inator == Inator.Duper)
                    {
                        GameObject obj = Instantiate(hitupdown.collider.gameObject, point.position, Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                    }
                    else if (inator == Inator.Deleter)
                    {

                        if (hitupdown.collider.GetComponent<SocialObject>())
                        {
                            Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                            VarSave.SetInt("Agr", cistalenemy.dies);
                        }
                        if (hitupdown.collider.GetComponent<CharacterName>())
                        {
                            Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                            VarSave.SetInt("Agr", cistalenemy.dies);
                        }
                        if (hitupdown.collider.GetComponent<CharacterStats>())
                        {
                            Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                            VarSave.SetInt("Agr", cistalenemy.dies);
                        }
                        if (hitupdown.collider.GetComponent<itemName>())
                        {
                            if (hitupdown.collider.GetComponent<itemName>().isLife)
                            {
                                Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                                VarSave.SetInt("Agr", cistalenemy.dies);
                            }
                        }
                        GameObject select = hitupdown.collider.gameObject;
                        if (select.GetComponent<itemName>())
                        {

                            if (select.GetComponent<itemName>().Unprohibiteble)
                            {
                                return;
                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty2 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty2, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty3 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty3, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty4 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty4, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty5 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty5, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty6 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty6, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty7 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty7, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty8 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty8, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty9 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty9, 1);

                            }
                        }
                        if (select.GetComponent<CustomObject>())
                        {

                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty2 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty2, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty3 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty3, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty4 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty4, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty5 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty5, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty6 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty6, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty7 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty7, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty8 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty8, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty9 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty9, 1);

                            }
                        }
                        if (hitupdown.collider.gameObject != gameObject) Destroy(hitupdown.collider.gameObject);
                    }
                    else if (inator == Inator.Demeker)
                    {
                        if (hitupdown.collider.GetComponent<SocialObject>())
                        {
                            Globalprefs.LoadTevroPrise(-1000); cistalenemy.dies += 1000;

                            VarSave.SetInt("Agr", cistalenemy.dies);
                        }
                        if (hitupdown.collider.GetComponent<CharacterName>())
                        {
                            Globalprefs.LoadTevroPrise(-1000); cistalenemy.dies += 1000;

                            VarSave.SetInt("Agr", cistalenemy.dies);
                        }
                        if (hitupdown.collider.GetComponent<CharacterStats>())
                        {
                            Globalprefs.LoadTevroPrise(-1000); cistalenemy.dies += 1000;

                            VarSave.SetInt("Agr", cistalenemy.dies);
                        }
                        if (hitupdown.collider.GetComponent<itemName>())
                        {
                            if (hitupdown.collider.GetComponent<itemName>().isLife)
                            {
                                Globalprefs.LoadTevroPrise(-1000); cistalenemy.dies += 1000;

                                VarSave.SetInt("Agr", cistalenemy.dies);
                            }
                        }
                        GameObject select = hitupdown.collider.gameObject; 
                        if (select.GetComponent<itemName>())
                        {
                            if (select.GetComponent<itemName>().ItemDangerLiberty != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty2 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty2, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty3 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty3, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty4 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty4, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty5 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty5, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty6 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty6, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty7 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty7, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty8 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty8, 1);

                            }
                            if (select.GetComponent<itemName>().ItemDangerLiberty9 != "")
                            {
                                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty9, 1);

                            }
                        }
                        if (select.GetComponent<CustomObject>())
                        {
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty2 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty2, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty3 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty3, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty4 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty4, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty5 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty5, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty6 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty6, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty7 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty7, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty8 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty8, 1);

                            }
                            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty9 != "")
                            {
                                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty9, 1);

                            }
                        }
                        if (hitupdown.collider.gameObject != gameObject)
                        {
                            //  Destroy(hitupdown.collider.gameObject);
                            if (VarSave.GetString("Demake" + Globalprefs.Reality) != "") Demake = JsonUtility.FromJson<ItemDemake>(VarSave.GetString("Demake" + Globalprefs.Reality));
                            if (hitupdown.collider.GetComponent<itemName>()) Demake.item.Add(hitupdown.collider.GetComponents<itemName>()[0]._Name);
                            if (hitupdown.collider.GetComponent<CustomObject>()) Demake.co.Add(hitupdown.collider.GetComponent<CustomObject>().s);
                            VarSave.SetString("Demake" + Globalprefs.Reality, JsonUtility.ToJson(Demake));
                        }
                    }
                    else if (inator == Inator.Restorer)
                    {
                        if (hitupdown.collider.gameObject != gameObject)
                        {
                            //  Destroy(hitupdown.collider.gameObject);
                            if (VarSave.GetString("Demake" + Globalprefs.Reality) != "") Demake = JsonUtility.FromJson<ItemDemake>(VarSave.GetString("Demake" + Globalprefs.Reality));
                            if (hitupdown.collider.GetComponent<itemName>())
                            {
                                for (int i=0;i< Demake.item.Count;i++)
                                {
                                    
                                    if (Demake.item[i] == hitupdown.collider.GetComponents<itemName>()[0]._Name)
                                    {
                                        Demake.item.RemoveAt(i);
                                    }
                                }
                            }
                            if (hitupdown.collider.GetComponent<CustomObject>())
                                for (int i = 0; i < Demake.co.Count; i++)
                                {

                                    if (Demake.co[i] == hitupdown.collider.GetComponent<CustomObject>().s)
                                    {
                                        Demake.co.RemoveAt(i);
                                    }
                                }
                            VarSave.SetString("Demake" + Globalprefs.Reality, JsonUtility.ToJson(Demake));
                        }
                    }
                }
            }
        }
    }
}
