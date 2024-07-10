using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JsonGame
{
    public string Role;
    public string maps;
    public string scenary;
    public string SoudTrack;
    public bool genFinish;
    public bool genFashits;
    public bool genFarm;
    public bool genChaosCube;
    public bool genLokation;
    public bool startGenocide;
    public bool startSurvival;
}

public class GameEditor : MonoBehaviour
{
    public JsonGame file = new JsonGame();
    public static JsonGame Opened = new JsonGame();
    public Toggle GenFinish;
    public Toggle GenFashists;
    public Toggle GenFarm;
    public Toggle GenCaoscube;
    public Toggle GenLokation;
    public Toggle StartGenocide;
    public Toggle StartSurvival;
    public Toggle OwerWrite;
    public InputField GameName;
    public InputField GameRole;
    public InputField GameMaps;
    public InputField GameScenary;
    public InputField GameSoundtack;
    public void SaveGame()
    {
        file.genFinish = GenFinish.isOn;
        file.genFarm = GenFarm.isOn;
        file.genChaosCube = GenCaoscube.isOn;
        file.genFashits = GenFashists.isOn;
        file.genLokation = GenLokation.isOn;
        file.startGenocide = StartGenocide.isOn;
        file.startSurvival = StartSurvival.isOn;
        file.Role = GameRole.text;
        file.maps = GameMaps.text;
        file.scenary = GameScenary.text;
        file.SoudTrack = GameSoundtack.text;
        if (!OwerWrite.isOn && !File.Exists("res/UserWorckspace/games/" + GameName.text)) File.WriteAllText("res/UserWorckspace/games/" + GameName.text + ".ugame", JsonUtility.ToJson(file));
        else if (OwerWrite.isOn)
        {
            File.WriteAllText("res/UserWorckspace/games/" + GameName.text+".ugame", JsonUtility.ToJson(file));
        }
    }
    public void LoadGame()
    {
        if (File.Exists("res/UserWorckspace/games/" + GameName.text + ".ugame"))
        {
            file = JsonUtility.FromJson<JsonGame>(File.ReadAllText("res/UserWorckspace/games/" + GameName.text + ".ugame"));
            GenFinish.isOn = file.genFinish;
            GenFarm.isOn = file.genFarm;
            GenCaoscube.isOn = file.genChaosCube;
            GenFashists.isOn = file.genFashits;
            GenLokation.isOn = file.genLokation;
            StartGenocide.isOn = file.startGenocide;
            StartSurvival.isOn = file.startSurvival;
            GameRole.text = file.Role;
            GameMaps.text = file.maps;
            GameScenary.text = file.scenary;
            GameSoundtack.text = file.SoudTrack;
        }
    }
    public void OpenGame()
    {
        if (File.Exists("res/UserWorckspace/games/" + GameName.text + ".ugame"))
        {
            Opened = JsonUtility.FromJson<JsonGame>(File.ReadAllText("res/UserWorckspace/games/" + GameName.text + ".ugame"));
        }
            VarSave.SetString("GameActive", GameName.text);
        SceneManager.LoadSceneAsync("GameLoader");
    }
}
