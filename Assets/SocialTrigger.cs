using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(menuName = "socialSysetem/socialTrriger")]
public class SocialTrigger : ScriptableObject
{
    public string[] InputText;
    public string[] IfText;
    public string OutputText;
    public string Url;
    public string exe;
    public string ErrorText;
    public string SlaveCommnad;
    public int respectConst;
    public int teuvroConst;
    public int respectMine;
    public int teuvroMine;
    public bool PriseSlave;
    public string dataCommnad;
    public bool KrimBurocrat;
    public bool KommunistYou7;
    public bool Born7;
    public bool sex;
    public GameObject morph;
    public GameObject gift;
    public string Itemsmorph;
    public string Itemsgift;
}

