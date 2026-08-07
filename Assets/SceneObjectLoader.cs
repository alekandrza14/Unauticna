using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class SceneObjectLoader : MonoBehaviour
{
	public static List<GameObject> list2 = new List<GameObject>();
	public List<GameObject> list3 = new List<GameObject>();
    List<GameObject> list = new List<GameObject>();
    public GameObject CO;
    public Transform panel;
    public static GameObject CO2;
    public static Transform panel2;
	
	public InputField output;
	public static InputField input_;
    int i;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CO2 = CO;
        panel2 = panel;
        SceneResource();
		input_ = output;
		
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
		
		list2.Clear();
		
		GameObject[] roots = SceneManager.GetActiveScene().GetRootGameObjects();
		
		foreach (GameObject obj in roots)
		{
			GameObject button = Instantiate(CO, panel);
			list2.Add(button);
		
			ObjectDelete od = button.GetComponent<ObjectDelete>();
			od.Object2 = obj;
			od.objname.text = obj.name;
		}

    }
	
}
