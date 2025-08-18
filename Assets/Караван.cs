using UnityEngine;

public class Караван : MonoBehaviour
{
    public GameObject[] products;
    void Start()
    {
        Instantiate(products[Random.Range(0, products.Length)],transform).gameObject.AddComponent<ChildNode>();
    }
}
