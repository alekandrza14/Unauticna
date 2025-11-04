using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SocialTriggerData
{
    public string[] InputText = new[] 
    {
    "",};
    public string[] IfText = new[]
    {
    "",};
    public string OutputText;
    public string Url;
    public string exe;
    public string ErrorText;
    public int respectConst;
    public int teuvroConst;
    public int respectMine;
    public int teuvroMine;
    public bool PriseSlave;
    public bool KommunistYou7;
    public bool sex;
    public string SlaveCommnad;
    public string dataCommnad;
    public string Itemsmorph;
    public string Itemsgift;
    public SocialTrigger export()
    {
        SocialTrigger new_ST = new();
        new_ST.InputText = this.InputText;
        new_ST.IfText = this.IfText;
        new_ST.OutputText = this.OutputText;
        new_ST.Url = this.Url;
        new_ST.exe = this.exe;
        new_ST.ErrorText = this.ErrorText;
        new_ST.respectConst = this.respectConst;
        new_ST.teuvroConst = this.teuvroConst;
        new_ST.respectMine = this.respectMine;
        new_ST.teuvroMine = this.teuvroMine;
        new_ST.PriseSlave = this.PriseSlave;
        new_ST.KommunistYou7 = this.KommunistYou7;
        new_ST.sex = this.sex;
        new_ST.KrimBurocrat = false;
        new_ST.SlaveCommnad = this.SlaveCommnad;
        new_ST.dataCommnad = this.dataCommnad;
        new_ST.Itemsmorph = this.Itemsmorph;
        new_ST.Itemsgift = this.Itemsgift;
        return new_ST;
    }
}

public class SocialObject : MonoBehaviour
{
    GameObject self,spawnedSocialSystem;
    public string[] STAPaths = new[]
    {
        "Default"
    }; 
    public List<SocialTriggerArray> loadedSTA = new();
    private void Start()
    {
        self = gameObject;
        foreach (string item in STAPaths)
        {
            loadedSTA.Add(Resources.Load<SocialTriggerArray>("STA/" + item));
        }
        SocialTriggerArray customSTA = new SocialTriggerArray();
        customSTA.profesion = "any";
        List<SocialTrigger> customST = new List<SocialTrigger>();
        DirectoryInfo di = new("res/UserWorckspace/Social");
        foreach (FileInfo item in di.GetFiles())
        {
            if (File.Exists(item.FullName))
            {
                Debug.LogError(File.ReadAllText(item.FullName) + " is name");
                customST.Add(JsonUtility.FromJson<SocialTriggerData>(File.ReadAllText(item.FullName)).export());
            }
        }
        customSTA.array = customST.ToArray();
        loadedSTA.Add(customSTA);
    }
    public void AddishonalLoad(string[] items)
    {
        self = gameObject;
        foreach (string item in items)
        {
            loadedSTA.Add(Resources.Load<SocialTriggerArray>("STA/" + item));
        }
        
       
       
        
      
    }

    public void OnInteractive()
    {
        Global.PauseManager.Pause();
        spawnedSocialSystem = Instantiate(Resources.Load<GameObject>("SocialSystem"));
        SocialSystem ss = spawnedSocialSystem.GetComponent<SocialSystem>();
        ss.loadedSTA = loadedSTA;
        ss.self = self;
    }
}
