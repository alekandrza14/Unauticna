using UnityEngine;
using UnityEngine.UI;

public class Loger : MonoBehaviour
{
    public Text logConsole;
    public static Loger Instance;
    public static void Sand(string Masage)
    {
        if (!Instance)
        {
            Instance = Instantiate(Resources.Load<GameObject>("Logger"),mover.main().transform).GetComponent<Loger>(); 
            Instance.logConsole.text = Masage;
        }
        else
        {
            Instance.logConsole.text = Masage;
        }
    }
    private void Update()
    {
        logConsole.rectTransform.anchoredPosition -= new Vector2(0, Input.GetAxisRaw("Mouse ScrollWheel"))*(Screen.height/10);
    }
}
