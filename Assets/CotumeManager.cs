using System.Drawing;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CotumeManager : MonoBehaviour 
{
    public string scin_name;
    Scin scin = new();
    public string Interfacetext;
    public string Difficulttext;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<mover>())
        {
            VarSave.SetString("ActiveScin", scin_name); 
            if (File.Exists("res/UserWorckspace/skins/" + scin_name + ".txt"))
            {
                scin = JsonUtility.FromJson<Scin>(File.ReadAllText("res/UserWorckspace/skins/" + scin_name + ".txt"));

                VarSave.SetString("Scin", scin.CO_name);
            }
            VarSave.SetString("interface", Interfacetext);
            SetDifficult();
            Loger.Sand("перезагрузисцену");
        }
    }

    public FileDifficult difficult;
   public void SetDifficult()
    {
        if (File.Exists("res/UserWorckspace/DifficultPreset/" + Difficulttext))
        {
            FileDifficult difficult_ = JsonUtility.FromJson<FileDifficult>(File.ReadAllText("res/UserWorckspace/DifficultPreset/" + Difficulttext));
            difficult = difficult_;
            DifficultStart();
        }
    }
    public void DifficultStart()
    {
        File.WriteAllText("PoliticSettings.ini", difficult.PolitFile);
        int i = 0;
        foreach (string item in difficult.gamedifs)
        {
            VarSave.SetFloat(item, difficult.gamedifsvalue[i], SaveType.global);
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
            if (Directory.Exists("debug")) Directory.Delete("debug", true);
        }
        SceneManager.LoadSceneAsync(0);
    }
}
