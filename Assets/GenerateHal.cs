using UnityEngine;
using UnityEngine.UI;

public class GenerateHal : MonoBehaviour
{
    public Text ���������;
    void Update()
    {
       float ��������� = Globalprefs.Hash(new Vector2(-(float)Globalprefs.GetIdUniverse()/100, (float)Globalprefs.GetIdUniverse()/100)*464.56756f)*21.546767f % 4;
        Debug.Log("HalCoord" + ���������);
        if ((int)��������� == 3)
        {
            RaycastHit hit = MainRay.MainHit;
            ���������.text = "� �������� ���� ��������� : ��";
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (gameObject == hit.collider.gameObject)
                {
                    GameObject obj = Instantiate(Resources.Load<GameObject>("Items/���������"), transform.position, Quaternion.identity);
                    obj.GetComponent<itemName>().ItemData = "True";
                    obj.GetComponent<Hal>().halActived = true;
                }
            }
        }
        else
        {
            ���������.text = "� �������� ���� ��������� : ����� ������ �����";
        }
    }
}
