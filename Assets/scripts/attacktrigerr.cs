using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacktrigerr : MonoBehaviour
{
    public GameObject[] allobj;
    public List<GameObject> otherobj = new List<GameObject>();
    public GameObject player;
    public GameObject platform;
    public GameObject platformactive;
    public string bol;
    public bool onetimes;
    public float tic, tic2, time = 20, timer = 20, timer2 = 200, range = 20;
    public GameObject ob; bool isactive = true;
    // Start is called before the first frame update
    void Awake()
    {
        if (VarSave.GetInt(bol) == 1 && onetimes)
        {
            isactive = true;
        }
        if (VarSave.GetInt(bol) != 1 && onetimes)
        {
            isactive = false;
        }
        if (VarSave.GetInt(bol) == 1 && !onetimes)
        {
            isactive = false;
        }
        if (VarSave.GetInt(bol) != 1 && !onetimes)
        {
            isactive = false;
        }
    }
    void Start()
    {
        if (VarSave.GetInt(bol) == 1 && onetimes)
        {
            isactive = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (VarSave.GetInt(bol) == 1 && onetimes)
        {
            isactive = true;
        }
        if (other.tag== "Player" && !isactive)
        {


            attack(other.gameObject);
        }
        if (VarSave.GetInt(bol) == 1 && onetimes)
        {
            isactive = true;
        }
    }
        // Update is called once per frame
    void Update()
    {
        OnAttack();
        tic += Time.deltaTime * 20;

        
    }
    public void end()
    {
        Destroy(platformactive);
        for (int i = 0; i < allobj.Length; i++)
        {



            allobj[i].SetActive(true);

        }
        
    }
    public void OnAttack()
    {
        if (platformactive.gameObject != null)
        {
            tic2 += Time.deltaTime * 20;
        }
            if (tic >= timer && platformactive.gameObject != null)
        {

            for (int i = 0; i < time; i++)
            {
                Instantiate(ob.gameObject, new Vector3(Random.Range(-range, range), Random.Range(20, 21), Random.Range(-range, range)) + player.transform.position, Quaternion.identity);
            }
            tic = 0;
        }
        if (tic2 >= timer2 && platformactive.gameObject != null)
        {
            

                isactive = false;
            
            
            VarSave.SetInt(bol,1);
            end();
            tic2 = 0;
        }
    }
    public void attack(GameObject p)
    {
        
            isactive = true;

        

        end();
        
        allobj = GameObject.FindObjectsOfType<GameObject>();
        for (int i = 0; i < allobj.Length; i++)
        {
            if (allobj[i].gameObject != gameObject)
            {
                if (allobj[i].GetComponent<BoxCollider>())
                {
                    allobj[i].SetActive(false);
                }
                if (allobj[i].GetComponent<SphereCollider>())
                {
                    allobj[i].SetActive(false);
                }
                if (allobj[i].GetComponent<MeshCollider>())
                {
                    allobj[i].SetActive(false);
                }
                if (allobj[i].GetComponent<CapsuleCollider>())
                {
                    allobj[i].SetActive(false);
                }
                if (allobj[i].GetComponent<TerrainCollider>())
                {
                    allobj[i].SetActive(false);
                }
            }
        }
            for (int i = 0; i < allobj.Length; i++)
        {
            if (allobj[i].GetComponent<mover>())
            {
                

                allobj[i].SetActive(true);
            }
            if (allobj[i].GetComponent<player>())
            {

                
                allobj[i].SetActive(true);
            }
        }
        player = p;
        
        platformactive = Instantiate(platform, player.transform.position - new Vector3(0, platform.transform.localScale.y, 0),Quaternion.identity);
    }
}
