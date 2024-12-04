using UnityEngine;

public class Construct : MonoBehaviour
{
    public GameObject Item;
    public void OnInteractive()
    {
        Instantiate(Item,transform.position,Quaternion.identity);
        gameObject.AddComponent<DELETE>();
    }
}
