using UnityEngine;

public class NonEat7 : MonoBehaviour
{
    public int i;
    void Start()
    {
        if (VarSave.GetInt("≈‰‡") == 1 && i == 3)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        if (VarSave.GetInt("≈‰‡") == 2)
        {
        }
        if (VarSave.GetInt("≈‰‡") == 3 && i == 1)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
