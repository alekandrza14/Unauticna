using dnSpyModer;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Chaos_Item_seed : MonoBehaviour
{
    string[] massiveEffect = new string[]
    {
        "Undyning",
        "No kapitalism",
        "Unyverseium_money_cart",
        "invisible",
        "Axelerate",
        "Vampaire",
        "BigShot",
        "Шизфрения",
        "Совиное Зрение",
        "MetabolismUp",
        "Regeneration",
        "ImbalenceRegeneration",
        "-1FPS",
        "Tripl2",
        "Tripl3",
        "mild hangover",
        "severe hangover",
        "InfaltionUp",
        "meat"
    };
    public string s;
    CustomObjectData Model = new CustomObjectData();
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider != null)
        {
            if (gameObject == hit.collider.gameObject)
            {
                s = "Chaos_Item" + Random.Range(0,long.MaxValue);
                if (ElementalInventory.main().Getitem("Universal-ье_Удобрения"))
                {
                    Model = new CustomObjectData();
                    Model.nDemention = (NDemention)Random.Range(0, 4);
                    Model.standartKey = (StandartKey)Random.Range(0, 5);
                    Model.functional = (Functional)Random.Range(0, 6);
                    Model.scale = Vector3.one;
                    Model._Color = Random.ColorHSV()* Random.Range(0.2f, 2);
                    GameObject[] res = Resources.LoadAll<GameObject>("events");

                    Model.EventSpawn = res[Random.Range(0, res.Length)].name;
                    Model.AnigilateItem = Random.Range(0, 2) == 1;
                    Model.Dublicate = Random.Range(0, 2) == 1;
                    Model.FreezeEffect = Random.Range(0, 2) == 1;
                    Model.ClearEffect = Random.Range(0, 2) == 1;
                    DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");
                    Model.CoSpawn = dif.GetFiles()[Random.Range(0, dif.GetFiles().Length)].Name.Replace(".txt", "");
                    Model.RegenerateHp = Random.Range(-6000, 6000);
                    Model.Recycler = Random.Range(-600000, 6000000);
                    Model.Redecycler = Random.Range(-600000, 6000000);
                    Model.itemSpawn = complsave.t3[Random.Range(-1, complsave.t3.Length)].name;
                    bool monet = false;
                    while(!monet){
                        Model.effect_no_use.Add(new useeffect(massiveEffect[Random.Range(0, massiveEffect.Length)], Random.Range(-600000, 6000000)));
                        monet = Random.Range(0, 2) == 1;
                    }
                    Model.DefultInfo = "Hello im devil item";
                    Model.InfinityRecycler = Random.Range(-600000, 6000000);
                    Model.playerMove = Global.math.randomCube(-300000, 300000);
                    Model.playerRotate = Global.math.randomCube(-300000, 300000);
                    Model.playerWHMove = new Vector2(Random.Range(-600, 600),Random.Range(-600, 600));
                    bool monet2 = false;
                    List<float> fn = new List<float>();
                    while (!monet2)
                    {
                        fn.Add(Random.Range(1, 90));
                        
                        monet2 = Random.Range(0, 2) == 1;
                    }
                    Model.ScaleN = fn.ToArray();

                        Model.NameModel = "Non_Load";
                    File.WriteAllText("res/UserWorckspace/Items/" + s + ".txt", JsonUtility.ToJson(Model));
                   


                    GameObject g = Instantiate(Resources.Load<GameObject>("CustomObject"), gameObject.transform.position, Quaternion.identity);
                    g.GetComponent<CustomObject>().s = s;
                    Destroy(gameObject);
                }
            }
        }
    }
}
