using UnityEngine;

public class LoadingПоинт : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Close",1);
    }

    // Update is called once per frame
    public void Close()
    {
        Destroy(gameObject);
    }
}
