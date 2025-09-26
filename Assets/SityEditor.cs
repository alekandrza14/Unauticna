using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class SityJson
{
    public List<string> Home = new List<string>();
    public List<Vector3> Pos = new List<Vector3>();

}
public class SityEditor : MonoBehaviour
{
    public GameObject player;
    public GameObject _player;
    public GameObject cum;
    public InputField CO;
    public InputField sityname;
    public SityJson sity = new SityJson();
    public void Save()
    {
        sity = new SityJson();
        CustomObject[] co = FindObjectsByType<CustomObject>(sortmode.main);
        foreach (CustomObject item in co)
        {
            sity.Home.Add(item.s);
            sity.Pos.Add(item.transform.position);
        }
        File.WriteAllText("res/UserWorckspace/Sitys/" + sityname.text + ".json", JsonUtility.ToJson(sity));
    }
    public void Load()
    {
        sity = new SityJson();
        CustomObject[] co = FindObjectsByType<CustomObject>(sortmode.main);
        foreach (CustomObject item in co)
        {
            item.gameObject.AddComponent<DELETE>();
        }

        if (File.Exists(("res/UserWorckspace/Sitys/" + sityname.text + ".json")))
        {
            sity = JsonUtility.FromJson<SityJson>(File.ReadAllText(("res/UserWorckspace/Sitys/" + sityname.text + ".json")));
            int i = 0;
            foreach (string item in sity.Home)
            {
                CustomObject c = Instantiate(player, sity.Pos[i], Quaternion.identity).GetComponent<CustomObject>();
                c.s = item;
                i++;
            }
        }
      //  File.WriteAllText("res/UserWorckspace/Sitys/" + "uniqsity.json", JsonUtility.ToJson(sity));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && player)
        {
           CustomObject c = Instantiate(player, _player.transform.position, Quaternion.identity).GetComponent<CustomObject>();
            c.s = CO.text;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * 15;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.forward * Time.deltaTime * 15;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * 15;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * Time.deltaTime * 15;
        }
        if (Input.GetKey(KeyCode.X))
        {
            cum.transform.position += Vector3.up * Time.deltaTime * 15;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            cum.transform.position -= Vector3.up * Time.deltaTime * 15;
        }
    }
}
