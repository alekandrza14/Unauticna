using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] itemName itemName;

   public string mobData = "FashistEnemye";
    public GameObject spawn4DTrigger;
    public static List<GameObject> objs = new List<GameObject>();
    private void Start()
    {
        mobData = GetComponent<itemName>().ItemData;

        if (string.IsNullOrEmpty(mobData))
        {
            if (complsave.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());

                mobData = "FashistEnemye";
                GetComponent<itemName>().ItemData = mobData;
            }
        }
        InvokeRepeating("spawn", 6, 8);
    }
    public void Load1()
    {
        if (GetComponent<itemName>())
        {

            mobData = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(mobData))
            {

                // time = JsonUtility.ToJson(Random.ColorHSV());

                mobData = "FashistEnemye";
                GetComponent<itemName>().ItemData = mobData;


            }
         
        }
    }
    public void spawn()
    {
        if (Vector3.Distance(mover.main().transform.position,transform.position)<60)
        {
            SpawnAction();
            if (objs.Count > 5)
            {
                GameObject obj = objs[Random.Range(0, objs.Count)];
                objs.Remove(obj);
                Destroy(obj);
            }
        }
    }

    private void SpawnAction()
    {
        if (!spawn4DTrigger) objs.Add( Instantiate(Resources.Load<GameObject>("items/" + mobData), transform.position + Global.math.randomCube(-10, 10), Quaternion.identity));
        if (spawn4DTrigger) if (spawn4DTrigger.activeSelf) objs.Add(Instantiate(Resources.Load<GameObject>("items/" + mobData), transform.position + Global.math.randomCube(-10, 10), Quaternion.identity));
      
    }

    public void OnSignal()
    {
        SpawnAction();
    }
    private void Update()
    {
       RaycastHit hit = MainRay.MainHit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hit.collider.gameObject == gameObject)
            {
                mobData = Globalprefs.item;
                GetComponent<itemName>().ItemData = mobData;

            }
        }
    }
}
