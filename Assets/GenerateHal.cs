using UnityEngine;
using UnityEngine.UI;

public class GenerateHal : MonoBehaviour
{
    public Text Халароний;
    void Update()
    {
       float халароний = Globalprefs.Hash(new Vector2(-(float)Globalprefs.GetIdUniverse()/100, (float)Globalprefs.GetIdUniverse()/100)*464.56756f)*21.546767f % 4;
        Debug.Log("HalCoord" + халароний);
        if ((int)халароний == 3)
        {
            RaycastHit hit = MainRay.MainHit;
            Халароний.text = "в вселеной есть халароний : Да";
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (gameObject == hit.collider.gameObject)
                {
                    GameObject obj = Instantiate(Resources.Load<GameObject>("Items/Халароний"), transform.position, Quaternion.identity);
                    obj.GetComponent<itemName>().ItemData = "True";
                    obj.GetComponent<Hal>().halActived = true;
                }
            }
        }
        else
        {
            Халароний.text = "в вселеной есть халароний : когда нибудь будет";
        }
    }
}
