
using UnityEngine;
[System.Serializable]
public class mods
{
    public string[] modname;
    public Vector3[] modposition;
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
        for (int i =0;i< modsStats.modname.Length;i++)
        {
            GameObject moda = Instantiate(Resources.Load<GameObject>("mods/"+modsStats.modname[i]),transform);
            moda.transform.position += moda.transform.right * modsStats.modposition[i].x + moda.transform.up * modsStats.modposition[i].y+ moda.transform.forward * modsStats.modposition[i].z;
        }
    }
}

