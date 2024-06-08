using UnityEngine;
using UnityEngine.UI;

public class SpawnRinkarnation : MonoBehaviour
{
    public GameObject RinkarnationButton;
    public static GameObject[] t5 = new GameObject[0];
    string namecrechure;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        if (Map_saver.t5.Length == 0)
        {
            if (t5.Length == 0)
            {
                GameObject[] g3 = Resources.LoadAll<GameObject>("Morfs");
                t5 = new GameObject[g3.Length];
                for (int i = 0; i < g3.Length; i++)
                {
                    t5[i] = g3[i];

                }
            }
        }
        else
        {
            t5 = new GameObject[0];
            t5 = Map_saver.t5;
        }

       
        for (int i = 0;i<5+Random.Range(0,2+1);i++)
        {
            namecrechure = t5[Random.Range(0, t5.Length)].name;
            if (Random.Range(0, 6)==3)
            {
                namecrechure = "Nravix";
            }
            GameObject obj = Instantiate(RinkarnationButton,transform);
            obj.SetActive(true);
            Text button = obj.transform.GetChild(0).gameObject.GetComponent<Text>();
            button.text = namecrechure; obj.GetComponent<RincarnationButton>().CreachureName = namecrechure;
        }
    }
}
