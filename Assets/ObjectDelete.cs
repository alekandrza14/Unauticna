using UnityEngine;
using UnityEngine.UI;

public class ObjectDelete : MonoBehaviour
{
    public GameObject Object2;
    public Text objname;
    public void deleting()
    {
        Object2.gameObject.AddComponent<DELETE>();
        gameObject.AddComponent<DELETE>();
    }

    public void SceneResource()
    {
 
    }

    void AddObject(Transform tr, int level)
    {
        GameObject obj = Instantiate(SceneObjectLoader.CO2, SceneObjectLoader.panel2);
      //  list.Add(obj);

        ObjectDelete od = obj.GetComponent<ObjectDelete>();
        od.Object2 = tr.gameObject;

        // Отступ
        string prefix = "";

        for (int i = 0; i < level; i++)
            prefix += "    ";

        // Уголок
        if (tr.childCount > 0)
            prefix += "▼ ";
        else
            prefix += "  ";

        od.objname.text = prefix + tr.name;

        // Добавляем детей
        foreach (Transform child in tr)
        {
            AddObject(child, level + 1);
        }
    }
}
