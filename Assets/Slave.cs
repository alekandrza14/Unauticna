using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slave : MonoBehaviour
{
    public static List<GameObject> plevk = new();
    public static List<GameObject> resea = new();
    public GameObject metka;
    public GameObject sexeffect;
    public string slaveData;
    public int solarytime;
    public int solarytimeold;
    public int WorkQualityTEVRO;
    public Vector3 slavePosition;
    Transform ПлевковаяКаст, taktikpoint1, Research, sex;
    private void Start()
    {
        solarytime += DateTime.Now.Year*46;
        solarytime += DateTime.Now.DayOfYear/7;
        if (solarytimeold!=solarytime)
        {
            WorkQualityTEVRO = 0;
            solarytimeold = solarytime;
        }
        if (WorkQualityTEVRO < 5000)
        {
            InvokeRepeating("РабОтбираетДеньги", 60, 60);
            InvokeRepeating("РабУвольняеться", 100, 100);
        }
        if (gameObject.GetComponent<SocialObject>())
        {
            gameObject.GetComponent<SocialObject>().AddishonalLoad(new[] { "Slave" });
        }
        slavePosition = transform.position;
        metka = Instantiate(Resources.Load<GameObject>("selectUnit"), transform);
        sexeffect = Instantiate(Resources.Load<GameObject>("sexeffect"), transform);
        metka.SetActive(false);
    }
    public void РабУвольняеться()
    {
        if (Global.Random.Chance(12))
        {
            Instantiate(Resources.Load<GameObject>("ui/Mats/РабУвольняеться"));
            Destroy(GetComponent<Slave>());
        }
    }
    public void РабОтбираетДеньги()
    {
        
        
            Instantiate(Resources.Load<GameObject>("ui/Mats/минкек"));
        
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
    Transform sexingmove(string itemname)
    {
        if (sex == null) 
        {
            itemName[] mobes = FindObjectsByType<itemName>(sortmode.main);
            itemName mob = null;
            foreach (itemName item in mobes) 
            {
                if (item.gameObject.name.Replace("(Clone)","")== itemname)
                {

                  if(item.gameObject != gameObject)  mob = item;
                }
            }
            sex = mob.transform;
        }
        return sex;
    }
    Transform ResearchTablet()
    {
        if (Research == null) Research = FindFirstObjectByType<GenScience>().transform;
        return Research;
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
        if (slaveData == "Fuck")
        {
           
            Transform igrok = sexingmove(Globalprefs.item);
          //  igrok.GetComponent<ПлевковаяКастрюля>().OnSignal();

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
            sexeffect.SetActive(true);
        }
        else
        {
            sexeffect.SetActive(false);
        }
        if (slaveData == "spitting")
        {
            if (!plevk.Contains(gameObject)) plevk.Add(gameObject);
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
        if (slaveData == "research")
        {
            if (!resea.Contains(gameObject)) resea.Add(gameObject);
            Transform igrok = ResearchTablet();
            if (GetComponent<CharacterStats>())
            {
                igrok.GetComponent<GenScience>().Research(GetComponent<CharacterStats>().data.IQ / 100);
            }
            if (!GetComponent<CharacterStats>())
            {
                igrok.GetComponent<GenScience>().Research(1);
            }

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

            if (resea.Contains(gameObject)) resea.Remove(gameObject);
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
