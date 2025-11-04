using UnityEngine;
public enum typeItem
{
    none,gun,mobe
}
public class ItemDetector : MonoBehaviour
{
    public static int coutnitem;
    public static typeItem type;
    public GameObject[] animation;
    private void Update()
    {
        if (coutnitem > 0)
        {
            if (type == typeItem.none)
            {
                animation[0].SetActive(true);
                animation[1].SetActive(false);
                animation[2].SetActive(false);
            }
            if (type == typeItem.gun)
            {
                animation[0].SetActive(false);
                animation[1].SetActive(true);
                animation[2].SetActive(false);
            }
            if (type == typeItem.mobe)
            {
                animation[0].SetActive(false);
                animation[1].SetActive(false);
                animation[2].SetActive(true);
            }
        }
        else
        {
            animation[0].SetActive(false);
            animation[1].SetActive(false);
            animation[2].SetActive(false);
        }
    }
}
