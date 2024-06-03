
using System.Collections.Generic;
using UnityEngine;
public class NodeData
{
    public List<Vector3> pos = new List<Vector3>();
    public List<Vector3> scale = new List<Vector3>();
    public List<Quaternion> rot = new List<Quaternion>();
    public List<string> itemID = new List<string>();
    public List<string> itemData = new List<string>();

}
public class MainNode : MonoBehaviour
{

    [SerializeField] itemName itemName1;
    [SerializeField] GameObject g;
    public List<GameObject> Childs = new List<GameObject>();
    string energy;
    bool loaded;
    public NodeData energyData = new NodeData();
    Collider other1;
    Collider other2;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<itemName>())
        {
            other1 = collision.collider;
            AddChild(other1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<itemName>())
        {
            other2 = other;
            AddChild(other2);
        }
    }
    void AddChild(Collider collider)
    {
        if (!collider.gameObject.GetComponent<ChildNode>())
        {
            if (!Childs.Contains(collider.gameObject))
            {

                Childs.Add(collider.gameObject);
                itemName item = collider.GetComponent<itemName>();
                energyData.pos.Add(item.transform.position - transform.position);
                energyData.scale.Add(item.transform.localScale);
                energyData.rot.Add(item.transform.rotation);
                energyData.itemData.Add(item.ItemData);
                energyData.itemID.Add(item._Name);
                item.GetComponent<ChildNode>();
                item.transform.SetParent(transform);
                energy = JsonUtility.ToJson(energyData);
                GetComponent<itemName>().ItemData = energy;
            }
        }
        ReWriteChild();
    }
    void ReWriteChild()
    {

        energyData = new NodeData();
        for (int i =0;i<Childs.Count;i++)
        {


            if (Childs[i]!=null)
            { itemName item = Childs[i].GetComponent<itemName>();
                energyData.pos.Add(item.transform.position - transform.position);
                energyData.scale.Add(item.transform.localScale);
                energyData.rot.Add(item.transform.rotation);
                energyData.itemData.Add(item.ItemData);
                energyData.itemID.Add(item._Name);
                energy = JsonUtility.ToJson(energyData);
                GetComponent<itemName>().ItemData = energy;
            }
        }
        
    }
    public GameObject ItemNameToGameObject(string itemname)
    {
        GameObject item = null;
        foreach (GameObject obj in complsave.t3)
        {
            if(obj != null)
            {
                if (obj.GetComponent<itemName>()._Name == itemname)
                {
                   return obj;
                }
            }
        }
        return item;
    }
    public void LoadChild()
    {
        if (!loaded)
        {
            Childs = new List<GameObject>();
            for (int i =0;i < energyData.itemID.Count;i ++)
            {
                if (!loaded)
                {
                    GameObject obj = Instantiate(ItemNameToGameObject(energyData.itemID[i]),
                    energyData.pos[i] + transform.position, Quaternion.identity);
                    if (energyData.scale.Count > 0)
                    {
                        if (energyData.scale.Count > i)
                        {
                            obj.transform.localScale = energyData.scale[i];
                        }
                    }
                    if (energyData.rot.Count > 0)
                    {
                        if (energyData.rot.Count > i)
                        {
                            obj.transform.rotation = energyData.rot[i];
                        }
                    }
                    itemName item = obj.GetComponent<itemName>();
                    item.ItemData = energyData.itemData[i];
                    obj.transform.SetParent(transform);
                    obj.AddComponent<ChildNode>();

                    Childs.Add((GameObject)obj);
                }
            }
          
        }

    }
    private void Start()
    {
        energy = GetComponent<itemName>().ItemData;

        if (string.IsNullOrEmpty(energy))
        {
            if (complsave.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
              
                energy = JsonUtility.ToJson(energyData);
                GetComponent<itemName>().ItemData = energy;
            }
            else
            {
                energyData = JsonUtility.FromJson<NodeData>(energy);
            }
        }
        else
        {
            energyData = JsonUtility.FromJson<NodeData>(energy);
        }
        if (!loaded) LoadChild();
        loaded = true;
    }
    public void Load1()
    {
        if (GetComponent<itemName>())
        {

            energy = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(energy))
            {

                energy = JsonUtility.ToJson(energyData);
                GetComponent<itemName>().ItemData = energy;


            }
            else
            {
                energyData = JsonUtility.FromJson<NodeData>(energy);
            }
        }
        else
        {
            energyData = JsonUtility.FromJson<NodeData>(energy);
        }
        if (!loaded) LoadChild();
        loaded = true;
    }
    public void OnSignal()
    {
        
    }
    public void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider.gameObject == gameObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ReWriteChild();
            }
        }
    }
}
