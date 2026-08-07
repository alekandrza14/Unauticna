using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class dataeditor
{
	public List<string> Comands = new List<string>();
}

public class ObjectDelete : MonoBehaviour
{
    public GameObject Object2;
    public Text objname;
	public int docher = 1;
	public static GameObject Use;
    public void deleting()
    {
        Object2.gameObject.AddComponent<DELETE>();
        gameObject.AddComponent<DELETE>();
    }
	public void SelectObject()
	{
		Use = Object2.gameObject;
		Component[] comps = Object2.transform.GetComponents<Component>();
		dataeditor rawdata = new dataeditor();
		rawdata.Comands.Add("Position x" + Object2.transform.position.x + " z" +Object2.transform.position.y + " y" + Object2.transform.position.z);
		rawdata.Comands.Add("Rotation x" + Object2.transform.rotation.x + " z" +Object2.transform.rotation.y + " y" + Object2.transform.rotation.z + " w" +Object2.transform.rotation.w);
		rawdata.Comands.Add("Scale x" + Object2.transform.localScale.x + " z" + Object2.transform.localScale.y + " y"+Object2.transform.localScale.z);
		foreach (Component c in comps)
		{	
			rawdata.Comands.Add("Mono " + c.GetType().Name+" COMMAND");
		}
		rawdata.Comands.Add("Use " + "COMMAND");
		SceneObjectLoader.input_.text = JsonUtility.ToJson(rawdata).Replace(",",",\n");
	}

    public void SceneResource()
    {
		AddObject(false,Object2.transform,1);
    }

    public void AddObject(bool recurce , Transform tr,int level)
    {
		//docher = level;
        GameObject obj = Instantiate(SceneObjectLoader.CO2, SceneObjectLoader.panel2);
      //  list.Add(obj);

        ObjectDelete od = obj.GetComponent<ObjectDelete>();
        od.Object2 = tr.gameObject;
		od.docher = level;
        // Отступ
        string prefix = "";

        for (int i = 0; i < docher; i++)
            prefix += "    ";

        // Уголок
       
            prefix += "▼ ";
      

        od.objname.text = prefix + tr.name;
		int index = SceneObjectLoader.list2.IndexOf(gameObject);
		List<GameObject> but = new List<GameObject>();
		GameObject sua = new GameObject("sua");
		if(!recurce) for (int i2 = 0; i2 < 4; i2++)
		{
		if(i2==0)	for (int i = 0; i < SceneObjectLoader.list2.Count; i++)
			{
				if(i>index)
				{
					but.Add(SceneObjectLoader.list2[i]);
					SceneObjectLoader.list2[i].transform.SetParent(sua.transform);
				}
			}
			// Добавляем детей
		if(i2==1)	
				for (int i = 0; i < Object2.transform.childCount; i++)
				{
					Transform child = Object2.transform.GetChild(i);
				
			
						AddObject(true,child.transform,docher+1);
				}
			if(i2==2)for (int i = 0; i < but.Count; i++)
			{
				
				but[i].transform.SetParent(SceneObjectLoader.panel2.transform);
			}
			if(i2==3)
			{
				SceneObjectLoader.list2.Clear();
				for (int i = 0; i < SceneObjectLoader.panel2.childCount; i++)
				{
					
						Transform child = SceneObjectLoader.panel2.transform.GetChild(i);
						
						SceneObjectLoader.list2.Add(child.gameObject);
					
				}
			}
		}
		
    }
}
