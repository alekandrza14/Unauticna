using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class SocialSystemSexEncounter
{
    public string CoAnimation;
    public string Target;
}
public class SexSaver : MonoBehaviour
{
    public InputField COAnim;
    public InputField Target;
    public CustomObject loaditem;
    public SocialSystemSexEncounter social = new SocialSystemSexEncounter();
    public void load()
    {
        loaditem.s = COAnim.text;
        loaditem.AnimInvoke();
    }

public void Save()
    {

        social.CoAnimation = COAnim.text;
        Directory.CreateDirectory("res/UserWorckspace/socialScene");
     //   if (!File.Exists("res/UserWorckspace/socialScene" + Target.text + ".txt"))
     
            File.WriteAllText("res/UserWorckspace/socialScene/" + Target.text + ".txt", JsonUtility.ToJson(social));
     
    }
}
