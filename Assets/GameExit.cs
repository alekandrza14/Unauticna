using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    
    public void OnInteractive()
    {
        VarSave.SetInt("MapUse", VarSave.GetInt("MapUse")+ 1);
        if (!GameEditor.Opened.startGenocide)
        {
            if (GameEditor.Opened.maps.Split(',').Length >= VarSave.LoadInt("MapUse", 0))
            {


                if (File.Exists("res/UserWorckspace/games/" + VarSave.GetString("GameActive") + ".ugame"))
                {
                    GameEditor.Opened = JsonUtility.FromJson<JsonGame>(File.ReadAllText("res/UserWorckspace/games/" + VarSave.GetString("GameActive") + ".ugame"));
                }
                MapData r = new MapData();
                Globalprefs.AutoSave = true;
                r = JsonUtility.FromJson<MapData>(File.ReadAllText("res/UserWorckspace/maps/" + GameEditor.Opened.maps.Split(',')[VarSave.LoadInt("MapUse", 0)]));
                Map_saver.mapLoad = "res/UserWorckspace/maps/" + GameEditor.Opened.maps.Split(',')[VarSave.LoadInt("MapUse", 0)];
                SceneManager.LoadSceneAsync(r.sceneName);
            }
            else
            {
                VarSave.SetString("GameActive", "");
                GameEditor.Opened = null;

                VarSave.SetInt("MapUse", 0);
                VarSave.SetString("CurrentSpace", "");
                SceneManager.LoadSceneAsync("GameVin");
            }
        }
        if (GameEditor.Opened.startGenocide&&FindObjectsByType<CharacterName>(sortmode.main).Length==0)
        {
            if (GameEditor.Opened.maps.Split(',').Length >= VarSave.LoadInt("MapUse", 0))
            {


                if (File.Exists("res/UserWorckspace/games/" + VarSave.GetString("GameActive") + ".ugame"))
                {
                    GameEditor.Opened = JsonUtility.FromJson<JsonGame>(File.ReadAllText("res/UserWorckspace/games/" + VarSave.GetString("GameActive") + ".ugame"));
                }
                MapData r = new MapData();
                Globalprefs.AutoSave = true;
                r = JsonUtility.FromJson<MapData>(File.ReadAllText("res/UserWorckspace/maps/" + GameEditor.Opened.maps.Split(',')[VarSave.LoadInt("MapUse", 0)]));
                Map_saver.mapLoad = "res/UserWorckspace/maps/" + GameEditor.Opened.maps.Split(',')[VarSave.LoadInt("MapUse", 0)];
                SceneManager.LoadSceneAsync(r.sceneName);
            }
            else
            {
                VarSave.SetString("GameActive", "");
                GameEditor.Opened = null;

                VarSave.SetInt("MapUse", 0);
                VarSave.SetString("CurrentSpace", "");
                SceneManager.LoadSceneAsync("GameVin");
            }
        }
    }
}
