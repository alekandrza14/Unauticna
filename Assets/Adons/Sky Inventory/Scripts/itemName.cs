
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class mods
{
    public List<string> modname = new();
    public List<string> modnameco = new();
    public List<Vector3> modposition = new();
}
public class itemName : CustomSaveObject
{
    public float ItemPrise;
    public bool ItemInfinitysPrise;
    public string ItemData = "";
    public bool isLife;
    public bool Undeleteble;
    public bool Unprohibiteble;
    public string ItemDangerLiberty = "";
    public string ItemDangerLiberty2 = "";
    public string ItemDangerLiberty3 = "";
    public string ItemDangerLiberty4 = "";
    public string ItemDangerLiberty5 = "";
    public string ItemDangerLiberty6 = "";
    public string ItemDangerLiberty7 = "";
    public string ItemDangerLiberty8 = "";
    public string ItemDangerLiberty9 = "";
    public string _Name;
    [Multiline(3)]
    public string _Discription;
    public int titan = 4;
    public int carbon;
    public int calciy;
    public int copper;
    public int aurum;
    public int uoxil;
    public int uran;
    public int silicat;
    public int farum;
    public int helium;
    public int itemtype;
    public mods modsStats = new();
    public void modsLoad()
    {
        for (int i = 0; i < modsStats.modname.Count; i++)
        {
            GameObject moda = Instantiate(Resources.Load<GameObject>("mods/" + modsStats.modname[i]), transform);
            moda.transform.position += moda.transform.right * modsStats.modposition[i].x + moda.transform.up * modsStats.modposition[i].y + moda.transform.forward * modsStats.modposition[i].z;
         if (modsStats.modname[i] == "CustomObject")
            {
                moda.GetComponent<mod>().data = Instantiate(moda.GetComponent<mod>().prefab, moda.transform).GetComponent<CustomObject>();
                moda.GetComponent<mod>().data.s = modsStats.modnameco[i];
            }
            moda.GetComponent<mod>().Parent = gameObject.transform;
        }
    }
    void Start()
    {
		gameObject.AddComponent<SelectObjectTag>();
        Directory.CreateDirectory("C:\\data\\rkn");
        if (File.Exists("C:\\data\\rkn\\"+ _Name + ".BAN"))
        {
            gameObject.SetActive(false);
            if (!File.Exists("C:\\data\\solaryAdd"))
            {
                File.WriteAllText("C:\\data\\solaryAdd", "0");
            }
            if (File.Exists("C:\\data\\solaryAdd"))
            {
                int addtevro = int.Parse(File.ReadAllText("C:\\data\\solaryAdd"));
                Globalprefs.LoadTevroPrise(addtevro);
                Globalprefs.UpadateTevro();
                File.WriteAllText("C:\\data\\solaryAdd", "0");
            }
        }
    }
    public GameObject modSpawn(string mod)
    {
        GameObject moda = Instantiate(Resources.Load<GameObject>("mods/" + mod), transform);
        modsStats.modname.Add(mod);
        if (modsStats.modname[modsStats.modname.Count - 1] == "CustomObject")
        {
            moda.GetComponent<mod>().data = Instantiate(moda.GetComponent<mod>().prefab, moda.transform).GetComponent<CustomObject>();
            moda.GetComponent<mod>().data.s = GlobalInputField.g_text.text;
            modsStats.modnameco.Add(moda.GetComponent<mod>().data.s);
        }
        else
        {
            modsStats.modnameco.Add("null");
        }
        modsStats.modposition.Add(Vector3.zero);
        moda.GetComponent<mod>().Parent = gameObject.transform;
        return moda;
    }
}

