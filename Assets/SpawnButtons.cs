using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnButtons : MonoBehaviour
{
    public GameObject Buttom;
    public Transform Panel; 
    List<GameObject> objs = new List<GameObject>();
    private void Start()
    {
        DirectoryInfo DIF = new DirectoryInfo("res/UserWorckspace/items");
        FileInfo[] fi = DIF.GetFiles();
        foreach (FileInfo item in fi)
        {
            GameObject text = Instantiate(Buttom, Panel);
            text.GetComponent<OCPolitNode>().IdCustomObject = item.Name.Replace(".txt","");
            text.GetComponent<OCPolitNode>().Update2();
            objs.Add(text);
        }
    }
    private void Update()
    {
        foreach (GameObject obj in objs)
        {
            obj.transform.position += new Vector3(0,0+Input.GetAxisRaw("Mouse ScrollWheel")*300,0);
        }
    }

}
