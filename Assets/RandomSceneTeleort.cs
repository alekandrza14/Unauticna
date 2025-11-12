using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSceneTeleort : MonoBehaviour
{
    public button6 scene;
    void Start()
    {
        scene.id = Random.Range(0,SceneManager.sceneCountInBuildSettings);
    }
}
