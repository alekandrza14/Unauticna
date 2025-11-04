using UnityEngine;

public class loadSex : MonoBehaviour
{
    public CustomObject day;
    void Start()
    {
        day.s = Globalprefs.SexObject;

    }
}
