using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
public class CustomObjectCommand
{
    public Color color;
    public Vector3 scale;
    public string prototype;
    public string name;
    public string model;
}

public class ExportGCPlanForCO : InventoryEvent
{
    [SerializeField] string ItemsFile;
    [SerializeField] List<string> Items = new();
    [SerializeField] List<string> FItems = new();
    [SerializeField] string FItem;
    [SerializeField] List<CustomObjectCommand> Commands = new();
    [SerializeField] List<CustomObjectData> Model = new();
    void Start()
    {
        ItemsFile = VarSave.GetString("CO.gc",SaveType.computer);
        Items = ItemsFile.Split('"').ToList();
        Items.RemoveAt(Items.Count-1);
        for (int i = 0; i < Items.Count;i++)
        {
            string[] item = Items[i].Split('/');
            FItems = Items[0].Split('/').ToList();
            FItem = Items[0].Split('/').ToList()[0].Split('.')[1];
            Commands.Add(new CustomObjectCommand());
            Commands[i].prototype = item[0].Split('.')[1];
            Commands[i].name = item[1].Split('.')[1];
            Commands[i].model = item[2].Split('.')[1];
            Commands[i].color = new Color(float.Parse(item[3].Split('.')[1]), float.Parse(item[4].Split('.')[1]), float.Parse(item[5].Split('.')[1]));
            Commands[i].scale = new Vector3(float.Parse(item[6].Split('.')[1]), float.Parse(item[7].Split('.')[1]), float.Parse(item[8].Split('.')[1]));
        }
        for (int i = 0;i < Commands.Count;i++) 
        {
            if (File.Exists("res/UserWorckspace/Items/" + Commands[i].prototype + ".txt"))
            {
                Model.Add(JsonUtility.FromJson<CustomObjectData>(File.ReadAllText("res/UserWorckspace/Items/" + Commands[i].prototype + ".txt")));
                
                Model[i].NameModel = Commands[i].model;
                Model[i]._Color = Commands[i].color;
                Model[i].scale = Commands[i].scale;

                File.WriteAllText("res/UserWorckspace/Items/" + Commands[i].name + ".txt", JsonUtility.ToJson(Model[i]));
            }
        }
        
        VarSave.DeleteKey("CO.gc", SaveType.computer);
    }
    public void Load1()
    {
        for (int i = 0; i < Commands.Count; i++)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
            obj.GetComponent<CustomObject>().s = Commands[i].name;
        }
    }
}
