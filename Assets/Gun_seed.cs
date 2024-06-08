using dnSpyModer;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Gun_seed : MonoBehaviour
{
    string[] massiveEffect = new string[]
    {
        "Undyning",
        "invisible",
        "Axelerate",
        "Vampaire",
        "Regeneration",
        "ImbalenceRegeneration"
    };
    public string s;
    CustomObjectData Model = new CustomObjectData();
    public List<GameObject> fr = new List<GameObject>();
    List<GameObject> sfr = new List<GameObject>();
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<itemName>())
        {
            itemName item = collision.GetComponent<itemName>();
            if (item._Name == "fr")
            {
                fr.Add(item.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponent<itemName>())
        {
            itemName item = collision.GetComponent<itemName>();
            if (item._Name == "fr")
            {
                fr.Remove(item.gameObject);
            }
        }
    }
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider != null)
        {
            itemName item = hit.collider.GetComponent<itemName>();
            if (item._Name == "Anvil" && fr.Count >= 2)
            {
                s = "Gun" + Global.Random.Range(0, int.MaxValue) + Global.Random.Range(0, int.MaxValue);
                if (ElementalInventory.main().Getitem("Hummer"))
                {
                    Model = new CustomObjectData();
                    Model.nDemention = NDemention._5D;
                    Model.standartKey = StandartKey.leftmouse;
                    Model.functional = Functional.user;
                    Model.scale = Vector3.one;
                    Model._Color = Color.gray;
                    Model.RegenerateHp = Global.Random.Range(-6, 6);
                    if (Global.Random.Range(-8, 8) == 0) Model.itemSpawn = Map_saver.t3[Global.Random.Range(-1, Map_saver.t3.Length)].name;
                    
                    Model.ObjSpawn = "DamageObject";
                    bool monet = false;

                    while (!monet)
                    {
                        Model.effect_no_use.Add(new useeffect(massiveEffect[Global.Random.Range(0,massiveEffect.Length)], Global.Random.Range(-600000, 6000000)));
                        monet = Global.Random.Range(0, 2) == 1;
                    }
                    Model.DefultInfo = "Hello im gun item";
                    if (Global.Random.Range(-4, 4) == 0) Model.playerMove = Global.math.randomCube(-2, 2);
                    bool monet2 = false;
                    List<float> fn = new List<float>();
                    while (!monet2)
                    {
                        fn.Add(Global.Random.Range(1, 90));
                        
                        monet2 = Global.Random.Range(0, 2) == 1;
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        if(j == 0) for (int i = 0; i < 2; i++)
                        {
                            sfr.Add(fr[i]);
                        }
                        if (j == 1) for (int i = 0; i < sfr.Count; i++)
                        {
                            fr.Remove(sfr[i]);
                            Destroy(sfr[i]);
                        }
                        if (j == 2) sfr.Clear();
                    }
                        Model.NameModel = "Gun";
                    File.WriteAllText("res/UserWorckspace/Items/" + s + ".txt", JsonUtility.ToJson(Model));
                   


                    GameObject g = Instantiate(Resources.Load<GameObject>("CustomObject"), gameObject.transform.position, Quaternion.identity);
                    g.GetComponent<CustomObject>().s = s;
                }
            }
        }
    }
}
