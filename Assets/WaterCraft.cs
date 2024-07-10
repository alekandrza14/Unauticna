using UnityEngine;

public class WaterCraft : InventoryEvent
{

    [SerializeField] public float жижа;
    [SerializeField] float Max_жижа;
    float cooldown;
    [SerializeField] Transform уровень, точка1, точка2;

    string energy;
    public GeneratorEnergyData energyData = new GeneratorEnergyData();



    private void Start()
    {
        жижа = float.Parse(GetComponent<itemName>().ItemData);

        if (string.IsNullOrEmpty(жижа.ToString()))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                GetComponent<itemName>().ItemData = жижа.ToString();
            }
        }

    }
    public void Load1()
    {
        жижа = float.Parse(GetComponent<itemName>().ItemData);

        if (string.IsNullOrEmpty(жижа.ToString()))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                GetComponent<itemName>().ItemData = жижа.ToString();
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.GetComponent<itemName>())
        {
            itemName itn = collision.collider.GetComponent<itemName>();
            if (itn._Name == "Water")
            {

                жижа++;
                Destroy(collision.collider.gameObject);
            }
            if (itn._Name == "Piss")
            {

                жижа++;
                Destroy(collision.collider.gameObject);
            }
            //Piss
        }
    }

    public void OnSignal()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
        уровень.localScale = Vector3.Lerp(точка1.localScale, точка2.localScale, жижа / Max_жижа);

        if (cooldown <= 0)
        {

            cooldown += 2;

            жижа++;
            GetComponent<itemName>().ItemData = жижа.ToString();
            Instantiate(Resources.Load("voices/plevok_blad"));

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
        уровень.localScale = Vector3.Lerp(точка1.localScale, точка2.localScale, жижа / Max_жижа);
        RaycastHit hit = MainRay.MainHit;
        if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider != null && cooldown <= 0)
        {
            if (gameObject == hit.collider.gameObject)
            {
                cooldown += 2;

                жижа++;
                GetComponent<itemName>().ItemData = жижа.ToString();
                Instantiate(Resources.Load("voices/plevok_blad"));
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && hit.collider != null && cooldown <= 0)
        {
            if (gameObject == hit.collider.gameObject)
            {
                if (Globalprefs.item == "Смачный_плевок_Спамтона")
                {


                    ElementalInventory ei = ElementalInventory.main();
                    ei.setItem("", 0, Color.red, ei.select);
                    жижа += 10;
                    GetComponent<itemName>().ItemData = жижа.ToString();
                }
              else  if (Globalprefs.item == "Octopus")
                {

                    if (жижа > Max_жижа)
                    {
                        ElementalInventory ei = ElementalInventory.main();
                        ei.setItem("UPortalGun", 21, Color.red, ei.select);
                        жижа = 0;
                        GetComponent<itemName>().ItemData = жижа.ToString();
                    }
                }
                else if (Globalprefs.item == "Mistical_penteract")
                {

                    if (жижа > Max_жижа)
                    {
                        ElementalInventory ei = ElementalInventory.main();
                        ei.setItem("Model341", 21, Color.red, ei.select);
                        жижа = 0;
                        GetComponent<itemName>().ItemData = жижа.ToString();
                    }
                }
                else if (Globalprefs.item == "ItemSandFromMinecraft")
                {

                    if (жижа > Max_жижа)
                    {
                        ElementalInventory ei = ElementalInventory.main();
                        ei.setItem("LittleFish", 21, Color.red, ei.select);
                        жижа = 0;
                        GetComponent<itemName>().ItemData = жижа.ToString();
                    }
                }
                else if (Globalprefs.item == "Акции_ХР")
                {

                    if (жижа > Max_жижа)
                    {
                        ElementalInventory ei = ElementalInventory.main();
                        ei.setItem(Map_saver.t3[Random.Range(0, Map_saver.t3.Length)].name, 21, Color.red, ei.select);
                        жижа = 0;
                        GetComponent<itemName>().ItemData = жижа.ToString();
                    }
                }
                else if (Globalprefs.item != "")
                {
                    if (жижа > Max_жижа)
                    {
                        ElementalInventory ei = ElementalInventory.main();
                        ei.setItem("ChaosResource", 42, Color.red, ei.select);
                        жижа = 0;
                        GetComponent<itemName>().ItemData = жижа.ToString();
                    }
                }

            }
        }
    }
}
