using UnityEngine;
[System.Serializable]
public class recipte
{
    public string Item;
    public GameObject instance;
}
public class NullPoution : MonoBehaviour
{
    public ����������������� water;
    public recipte[] Items;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<�����������������>()) water = collision.collider.GetComponent<�����������������>();
    }
    
    void Update()
    {
        if (water!=null)
        {
            if (water.������>0)
            {
                RaycastHit hit = MainRay.MainHit;
                if (hit.collider.gameObject == gameObject)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        foreach (recipte item in Items) {
                            if (item.Item == Globalprefs.item)
                            {
                                water.������ -= 10;
                                water.GetComponent<itemName>().ItemData = water.������.ToString();
                                ElementalInventory ei = ElementalInventory.main();
                                ei.setItem("", 0, Color.red, ei.select);
                                if (Random.Range(0, 7) < 1)
                                {
                                    Instantiate(item.instance, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    water.������ -= 2;
                                    water.GetComponent<itemName>().ItemData = water.������.ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
