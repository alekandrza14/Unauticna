using UnityEngine;

public class FastMoveToPlayer : MonoBehaviour
{
    Vector3 v3;
    mover m;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(0, 0.1f);
        m = mover.main();
    }

    // Update is called once per frame
    void Update()
    {
        v3 = transform.position - m.transform.position;
        transform.position += -v3 / (1f / speed);
    }
}
