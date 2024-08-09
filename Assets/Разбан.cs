using UnityEngine;
using UnityEngine.SceneManagement;

public class Разбан : MonoBehaviour
{
    void Start()
    {
        if (VarSave.GetFloat(
      "Конец" + "_gameSettings", SaveType.global) <= -0.5f)
        {
            if (Random.Range(-1f, 5f - VarSave.GetFloat(
"Конец" + "_gameSettings", SaveType.global)) <= 0)
            {
                VarSave.DeleteKey("lol you Banned");
                SceneManager.LoadSceneAsync(0);
            }
        }
        if (VarSave.GetFloat(
      "Конец" + "_gameSettings", SaveType.global) <= -1f)
        {
            
                VarSave.DeleteKey("lol you Banned");
                SceneManager.LoadSceneAsync(0);
        }

    }
}
