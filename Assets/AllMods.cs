using UnityEngine;
using UnityEngine.UI;

public class AllMods : MonoBehaviour
{
    public GameObject pref;
    public GameObject pref2;
    GameObject[] reso;
    void Start()
    {
        reso = Resources.LoadAll<GameObject>("Mods");
        foreach (GameObject go in reso)
        {
           GameObject item = Instantiate(pref,pref2.transform);
            item.GetComponent<modEditor>().mod = go.GetComponent<mod>().modname;
            item.GetComponentInChildren<Text>().text = go.GetComponent<mod>().modname;
        }
    }
}
