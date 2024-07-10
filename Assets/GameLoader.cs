using System.IO;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : InventoryEvent
{
    public void Load1()
    {
        if (GameEditor.Opened.maps.Split(',').Length < VarSave.LoadInt("MapUse", 0))
        {

            VarSave.SetInt("MapUse", 0);
        }
        if (File.Exists("res/UserWorckspace/games/" + VarSave.GetString("GameActive") + ".ugame"))
        {
            GameEditor.Opened = JsonUtility.FromJson<JsonGame>(File.ReadAllText("res/UserWorckspace/games/" + VarSave.GetString("GameActive") + ".ugame"));
        }
        VarSave.SetString("MusickPatch", Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) +"/"+ GameEditor.Opened.SoudTrack);
        VarSave.SetBool("isplaying",true);
        VarSave.SetString("ProfStatus", GameEditor.Opened.Role);
        MapData r = new MapData();
        Directory.CreateDirectory(VarSave.path + "/datasurface");
        VarSave.SetMoney("datasurface/" + VarSave.GetString("GameActive"), 0);
        VarSave.SetString("CurrentSpace", VarSave.GetString("GameActive"));
        r = JsonUtility.FromJson<MapData>(File.ReadAllText("res/UserWorckspace/maps/" + GameEditor.Opened.maps.Split(',')[VarSave.LoadInt("MapUse", 0)]));
        Map_saver.mapLoad = "res/UserWorckspace/maps/" + GameEditor.Opened.maps.Split(',')[VarSave.LoadInt("MapUse", 0)];
        SceneManager.LoadSceneAsync(r.sceneName);
    }
}
