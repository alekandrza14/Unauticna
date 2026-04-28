using UnityEngine;

public class PsyhoSystem1 : MonoBehaviour
{
    public GameObject[] Voice;
    void Start()
    {
        if (VarSave.GetInt("ную") == 3)
        {
            Voice = Resources.LoadAll<GameObject>("PsihoSystem/voices");
            if (Global.Random.Chance(13))
            {
                Instantiate(Voice[Random.Range(0, Voice.Length)], transform.position, Quaternion.identity);
            }
            InvokeRepeating("Ucna", 16, 25);
        }
    }
    public void Ucna()
    {
        if (Global.Random.Chance(13))
        {
            Instantiate(Voice[Random.Range(0, Voice.Length)], transform.position, Quaternion.identity);
        }
    }
}
