using UnityEngine;

public class RunToPlayer : MonoBehaviour
{
    mover m;
    // Start is called before the first frame update
    void Start()
    {
        m = mover.main();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(m.transform.position - transform.position, transform.up);
        transform.Translate(0, 0, 1f * Time.deltaTime);
    }
}
