using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LOADINGGAME : MonoBehaviour
{
    public Scrollbar loadbar;
    public static object scene = (int)0;
    void Update()
    {
        loadbar.size += Time.deltaTime;
        if (loadbar.size>=1)
        {
            if (VarSave.isNumber(scene.ToString())) SceneManager.LoadScene((int)scene); else SceneManager.LoadScene(scene.ToString());

        }
    }
}
public class SceneLoad
{
    public static void loadbar(object scene)
    {
        if (VarSave.isNumber(scene.ToString())) LOADINGGAME.scene = (int)scene;
        else LOADINGGAME.scene = scene.ToString();

        SceneManager.LoadSceneAsync(433);
    }
}