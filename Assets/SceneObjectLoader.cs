using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneObjectLoader : MonoBehaviour
{
    List<GameObject> list = new List<GameObject>();
    public GameObject CO;
    public Transform panel;
    public static GameObject CO2;
    public static Transform panel2;
    int i;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CO2 = CO;
        panel2 = panel;
        SceneResource();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            i++;
            i %= 3;
            if (i == 0)
            {
                SceneResource();
            }
            if (i == 1)
            {
                SceneResource();
            }
            if (i == 2)
            {
                SceneResource();
            }

        }

    }
    public void SceneResource()
    {

        foreach (GameObject item in list)
		{
			if (item != null)
				item.AddComponent<DELETE>();
		}
		
		list.Clear();
		
		GameObject[] roots = SceneManager.GetActiveScene().GetRootGameObjects();
		
		foreach (GameObject obj in roots)
		{
			GameObject button = Instantiate(CO, panel);
			list.Add(button);
		
			ObjectDelete od = button.GetComponent<ObjectDelete>();
			od.Object2 = obj;
			od.objname.text = obj.name;
		}

    }
	public void AllObjects()
    {

        foreach (GameObject item in list)
        {
            if (item != null) item.AddComponent<DELETE>();
        }
        list.Clear();
        Transform[] charactors = FindObjectsByType<Transform>(sortmode.main);
        foreach (Transform file in charactors)
        {
            list.Add(Instantiate(CO, panel));
            list[list.Count - 1].GetComponent<ObjectDelete>().Object2 = file.gameObject;
            list[list.Count - 1].GetComponent<ObjectDelete>().objname.text = file.gameObject.name;


        }

    }
    public void Items()
    {
        foreach (GameObject item in list)
        {
           if(item!=null) item.AddComponent<DELETE>();
        }
        list.Clear();
        CustomObject[] charactors = FindObjectsByType<CustomObject>(sortmode.main);
        if (charactors.Length != 0) foreach (CustomObject file in charactors)
            {
                list.Add(Instantiate(CO, panel));
                list[list.Count - 1].GetComponent<ObjectDelete>().Object2 = file.gameObject;
                list[list.Count - 1].GetComponent<ObjectDelete>().objname.text = file.gameObject.name;


            }
        itemName[] charactors1 = FindObjectsByType<itemName>(sortmode.main);
        if (charactors1.Length != 0) foreach (itemName file in charactors1)
            {
                list.Add(Instantiate(CO, panel));
                list[list.Count - 1].GetComponent<ObjectDelete>().Object2 = file.gameObject;
                list[list.Count - 1].GetComponent<ObjectDelete>().objname.text = file.gameObject.name;


            }

    }
    public void Scripts()
    {

        foreach (GameObject item in list)
        {
            if (item != null) item.AddComponent<DELETE>();
        }
        list.Clear();
        MonoBehaviour[] charactors = FindObjectsByType<MonoBehaviour>(sortmode.main);
        foreach (MonoBehaviour file in charactors)
        {
            list.Add(Instantiate(CO, panel));
            list[list.Count - 1].GetComponent<ObjectDelete>().Object2 = file.gameObject;
            list[list.Count - 1].GetComponent<ObjectDelete>().objname.text = file.gameObject.name;


        }

    }
}
