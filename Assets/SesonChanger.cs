using UnityEngine;
using UnityEngine.UI;
public enum Seson
{
    Лето,Глён,Осень,Зима,Мака,Весна
}
public class SesonChanger : MonoBehaviour
{
    Seson seson;
    bool enter;
    public GameObject Canvas;
    public Dropdown dd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            enter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            enter = false;
        }
    }
    void Start()
    {
        
    }
    public void setSeson()
    {
        seson = (Seson)dd.value;
        VarSave.SetInt("Seson",(int)seson);
    }
    // Update is called once per frame
    void Update()
    {
        Canvas.SetActive(enter);
    }
}
