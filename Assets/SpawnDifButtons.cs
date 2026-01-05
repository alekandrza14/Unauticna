using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDifButtons : MonoBehaviour
{
    public GameObject button;
    public Transform point;
    void Start()
    {
        DirectoryInfo dir = new DirectoryInfo("res/UserWorckspace/DifficultPreset");
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            if (!(file.Name).Contains("906...")) 
            {
                GameObject obj = Instantiate(button, point);
                FileDifficult difficult = JsonUtility.FromJson<FileDifficult>(File.ReadAllText("res/UserWorckspace/DifficultPreset/" + file.Name));
                obj.GetComponentInChildren<Text>().text = file.Name;
                obj.GetComponent<StartDifficult>().difficult = difficult;
                obj.name = file.Name;
            } 
        }

    }
}
