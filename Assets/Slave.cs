using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Burst.CompilerServices;

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
    Transform �������������, taktikpoint1, Research, sex;
    FormationSwap formation;
    private void Start()
    {
        formation ??= FindFirstObjectByType<FormationSwap>();
        solarytime += DateTime.Now.Year*46;
        solarytime += DateTime.Now.DayOfYear/7;
        if (solarytimeold!=solarytime)
        {
            WorkQualityTEVRO = 0;
            solarytimeold = solarytime;
        }
        if (WorkQualityTEVRO < 5000)
        {
            if (formation == null)
            {


                InvokeRepeating("�����������������", 60, 60);
                InvokeRepeating("���������������", 100, 100);
            }
          if(formation != null)  if (formation.formation == Formation.right)
            {


                InvokeRepeating("�����������������", 60, 60);
                InvokeRepeating("���������������", 100, 100);
            }
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
    public void ���������������()
    {
        if (Global.Random.Chance(12))
        {
            Instantiate(Resources.Load<GameObject>("ui/Mats/���������������"));
            Destroy(GetComponent<Slave>());
        }
    }
    public void �����������������()
    {
        GameObject select = gameObject; if (select.GetComponent<itemName>())
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
        Instantiate(Resources.Load<GameObject>("ui/Mats/������"));
        
    }
    public void onSelect()
    {
        gameunitselect._this = gameObject;
    }
    Transform spittinglull()
    {
        if (������������� == null) ������������� = FindFirstObjectByType<�����������������>().transform;
        return �������������;
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
    private void Update()
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
          //  igrok.GetComponent<�����������������>().OnSignal();

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
            if (sexeffect) sexeffect.SetActive(true);
        }
        else
        {
          if (sexeffect)  sexeffect.SetActive(false);
        }
        if (slaveData == "spitting")
        {
            if (!plevk.Contains(gameObject)) plevk.Add(gameObject);
            Transform igrok = spittinglull();
            igrok.GetComponent<�����������������>().OnSignal();

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
