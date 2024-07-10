using UnityEngine;

public class WaterCraft : InventoryEvent
{

    [SerializeField] public float ����;
    [SerializeField] float Max_����;
    float cooldown;
    [SerializeField] Transform �������, �����1, �����2;

    string energy;
    public GeneratorEnergyData energyData = new GeneratorEnergyData();



    private void Start()
    {
        ���� = float.Parse(GetComponent<itemName>().ItemData);

        if (string.IsNullOrEmpty(����.ToString()))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                GetComponent<itemName>().ItemData = ����.ToString();
            }
        }

    }
    public void Load1()
    {
        ���� = float.Parse(GetComponent<itemName>().ItemData);

        if (string.IsNullOrEmpty(����.ToString()))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                GetComponent<itemName>().ItemData = ����.ToString();
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

                ����++;
                Destroy(collision.collider.gameObject);
            }
            if (itn._Name == "Piss")
            {

                ����++;
                Destroy(collision.collider.gameObject);
            }
            //Piss
        }
    }

    public void OnSignal()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
        �������.localScale = Vector3.Lerp(�����1.localScale, �����2.localScale, ���� / Max_����);

        if (cooldown <= 0)
        {

            cooldown += 2;

            ����++;
            GetComponent<itemName>().ItemData = ����.ToString();
            Instantiate(Resources.Load("voices/plevok_blad"));

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
        �������.localScale = Vector3.Lerp(�����1.localScale, �����2.localScale, ���� / Max_����);
        RaycastHit hit = MainRay.MainHit;
        if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider != null && cooldown <= 0)
        {
            if (gameObject == hit.collider.gameObject)
            {
                cooldown += 2;

                ����++;
                GetComponent<itemName>().ItemData = ����.ToString();
                Instantiate(Resources.Load("voices/plevok_blad"));
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && hit.collider != null && cooldown <= 0)
        {
            if (gameObject == hit.collider.gameObject)
            {
                if (Globalprefs.item == "�������_������_��������")
                {


                    ElementalInventory ei = ElementalInventory.main();
                    ei.setItem("", 0, Color.red, ei.select);
                    ���� += 10;
                    GetComponent<itemName>().ItemData = ����.ToString();
                }
              else  if (Globalprefs.item == "Octopus")
                {

                    if (���� > Max_����)
                    {
                        ElementalInventory ei = ElementalInventory.main();
                        ei.setItem("UPortalGun", 21, Color.red, ei.select);
                        ���� = 0;
                        GetComponent<itemName>().ItemData = ����.ToString();
                    }
                }
                else if (Globalprefs.item == "Mistical_penteract")
                {

                    if (���� > Max_����)
                    {
                        ElementalInventory ei = ElementalInventory.main();
                        ei.setItem("Model341", 21, Color.red, ei.select);
                        ���� = 0;
                        GetComponent<itemName>().ItemData = ����.ToString();
                    }
                }
                else if (Globalprefs.item == "ItemSandFromMinecraft")
                {

                    if (���� > Max_����)
                    {
                        ElementalInventory ei = ElementalInventory.main();
                        ei.setItem("LittleFish", 21, Color.red, ei.select);
                        ���� = 0;
                        GetComponent<itemName>().ItemData = ����.ToString();
                    }
                }
                else if (Globalprefs.item == "�����_��")
                {

                    if (���� > Max_����)
                    {
                        ElementalInventory ei = ElementalInventory.main();
                        ei.setItem(Map_saver.t3[Random.Range(0, Map_saver.t3.Length)].name, 21, Color.red, ei.select);
                        ���� = 0;
                        GetComponent<itemName>().ItemData = ����.ToString();
                    }
                }
                else if (Globalprefs.item != "")
                {
                    if (���� > Max_����)
                    {
                        ElementalInventory ei = ElementalInventory.main();
                        ei.setItem("ChaosResource", 42, Color.red, ei.select);
                        ���� = 0;
                        GetComponent<itemName>().ItemData = ����.ToString();
                    }
                }

            }
        }
    }
}
