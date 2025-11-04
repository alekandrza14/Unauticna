using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HINGHT : MonoBehaviour
{
    public Text days;
    public static int days1 = 4;
    public Text scounds;
    public float scounds1 = 300;
    public int scene;
    private void Update()
    {
        if (scene == 1)
        {
            days1 = days1 >= 26 ? days1 : 26;
        }
        days.text = "Ночь " + days1;
        scounds.text = (int)(scounds1 / 60) + " : " + (int)(scounds1 % 60);
        scounds1 -= Time.deltaTime;
        if (scounds1 < 0)
        {
            days1++;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        if (scene == 0) if (days1 > 25)
            {
                SceneManager.LoadSceneAsync(401);
            }
        if (scene == 1) if (days1 > 26)
            {
                SceneManager.LoadSceneAsync(402);
            }
        if (Input.GetKeyDown(KeyCode.Q) && Directory.Exists("debug"))
        {
            days1++;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
