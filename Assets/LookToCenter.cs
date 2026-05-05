using UnityEngine;

public class LookToCenter : MonoBehaviour
{
    GameObject m;
    // Start is called before the first frame update
    void Start()
    {
        m = new GameObject("Наносить добро! Причинять Справедливость!");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(-(m.transform.position - transform.position), transform.up);
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
    }
}
