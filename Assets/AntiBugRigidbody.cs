using UnityEngine;

public class AntiBugRigidbody : MonoBehaviour
{
    public Rigidbody body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject s = new("pos");
        s.transform.position = transform.position;
        transform.SetParent(s.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (!body)
        {
            Destroy(gameObject);
        }
    }
}
