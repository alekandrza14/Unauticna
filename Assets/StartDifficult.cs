using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class FileDifficult
{
    [Multiline(9)]
    public string PolitFile;
    public string[] gamedifs;
    public float[] gamedifsvalue;
    public string[] bakeeffects;
    public string iterface;
    public bool gamemode;
}
public class StartDifficult : MonoBehaviour
{
    public FileDifficult difficult;
    public void Start()
    {

    }
    public void DifficultStart()
    {
        File.WriteAllText("PoliticSettings.ini", difficult.PolitFile);
        int i = 0;
        foreach (string item in difficult.gamedifs)
        {
            VarSave.SetFloat(item, difficult.gamedifsvalue[i],SaveType.global);
            i++;
        }
        foreach (string item in difficult.bakeeffects)
        {
            playerdata.Addeffect(item, float.PositiveInfinity);
            playerdata.checkeffect();
            playerdata.Saveeffect();
            playerdata.BakeAlleffect();
        }
        VarSave.SetString("interface", difficult.iterface);
        if (difficult.gamemode)
        {
            Directory.CreateDirectory("debug");
        }
        else
        {
           if(Directory.Exists("debug")) Directory.Delete("debug",true);
        }
        SceneManager.LoadSceneAsync(0);
    }
    public void TeleportScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
