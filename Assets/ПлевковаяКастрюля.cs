using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ПлевковаяКастрюля : InventoryEvent
{
    [SerializeField] public float плевки;
    [SerializeField] float Max_плевки;
    float cooldown;
    [SerializeField] Text level_plevkov;
    [SerializeField] Transform уровень, точка1, точка2;

    [SerializeField] itemName itemName;
    [SerializeField] Text EnergyCounter;
    string energy;
    public GeneratorEnergyData energyData = new GeneratorEnergyData();
    private void Start()
    {
        плевки = float.Parse( GetComponent<itemName>().ItemData);

        if (string.IsNullOrEmpty(плевки.ToString()))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                GetComponent<itemName>().ItemData = плевки.ToString();
            }
        }

    }
    public void Load1()
    {
        плевки = float.Parse(GetComponent<itemName>().ItemData);

        if (string.IsNullOrEmpty(плевки.ToString()))
        {
           
                // time = JsonUtility.ToJson(Random.ColorHSV());
                GetComponent<itemName>().ItemData = плевки.ToString();
            

        }
    }

    public void OnSignal()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
        уровень.position = Vector3.Lerp(точка1.position, точка2.position, плевки / Max_плевки);
     
        level_plevkov.text = "Плевки " + плевки + " / 1000";
        if (cooldown <= 0)
        {
          
                cooldown += 2;

                плевки+=1 * Slave.plevk.Count;
                GetComponent<itemName>().ItemData = плевки.ToString();
                Instantiate(Resources.Load("voices/plevok_blad"));
          
        }
    }
        // Update is called once per frame
        void Update()
    {
        if (cooldown > 0) cooldown-= Time.deltaTime;
        уровень.position = Vector3.Lerp(точка1.position,точка2.position,плевки/Max_плевки);
      RaycastHit hit = MainRay.MainHit;
        level_plevkov.text = "Плевки " + плевки + " / 1000";
        if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider != null && cooldown <= 0)
        {
            if (gameObject == hit.collider.gameObject)
            {
                cooldown += 2;
                if (VarSave.GetFloat(
       "Конец" + "_gameSettings", SaveType.global) >= 0.5f)
                {
                    if (Random.Range(-1f,1f- VarSave.GetFloat(
       "Конец" + "_gameSettings", SaveType.global))<=0)
                    {
                        плевки = 1000;
                    }
                }
                if (VarSave.GetFloat(
      "Конец" + "_gameSettings", SaveType.global) <= -0.5f)
                {
                    if (Random.Range(-1f, 1f - VarSave.GetFloat(
       "Конец" + "_gameSettings", SaveType.global)) <= 0)
                    {
                        плевки = 0;
                    }
                }
                плевки++;
                GetComponent<itemName>().ItemData = плевки.ToString();
                Instantiate(Resources.Load("voices/plevok_blad"));
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && hit.collider != null && cooldown <= 0)
        {
            if (gameObject == hit.collider.gameObject)
            {
                if (Globalprefs.item == "Смачный_плевок_Спамтона")
                {
                    if (VarSave.GetFloat(
      "Конец" + "_gameSettings", SaveType.global) >= 0.5f)
                    {
                        if (Random.Range(-1f, 1f - VarSave.GetFloat(
           "Конец" + "_gameSettings", SaveType.global)) <= 0)
                        {
                            плевки = 1000;
                        }
                    }
                    if (VarSave.GetFloat(
      "Конец" + "_gameSettings", SaveType.global) <= -0.5f)
                    {
                        if (Random.Range(-1f, 1f - VarSave.GetFloat(
           "Конец" + "_gameSettings", SaveType.global)) <= 0)
                        {
                            плевки = 0;
                        }
                    }

                    ElementalInventory ei = ElementalInventory.main();
                    ei.setItem("", 0, Color.red, ei.select);
                    плевки += 10;
                    GetComponent<itemName>().ItemData = плевки.ToString();
                }
             
            }
        }
    }
}
