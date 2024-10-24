using UnityEngine;

public class Merisyu : MonoBehaviour
{
    public Transform target;
    public float speed;
    float timer;
    private void Start()
    {
        InvokeRepeating("Shoot", 10, 5);
    }
    public void Shoot()
    {
        GameObject g = Resources.Load<GameObject>("Cum");
        Instantiate(g, transform.position, Quaternion.identity);
    }
    
    void Update()
    {
        RaycastHit hit;

        mover m = mover.main();
        timer += Time.deltaTime;
        if (timer > 12)
        {
            for (int i = 0; i < 0 + Global.Random.Range(1, 5); i++)
            {


                GameObject g = Resources.Load<GameObject>("Items/Взрыв");
                Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        Instantiate(g, hit.point, Quaternion.identity);
                    }
                }
            }
            for (int i = 0; i < 0 + Global.Random.Range(1, 2); i++)
            {


                GameObject g = Resources.Load<GameObject>("Items/Primetives/E1/BlackHole");
                Ray r = new(m.transform.position + (m.transform.up * 400), Random_vector_down());

                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        Instantiate(g, hit.point, Quaternion.identity);
                    }
                }
            }
            timer = 0;

        }
        transform.rotation = Quaternion.LookRotation(target.position - transform.position, transform.up);
        transform.Translate(0, 0, 1f * Time.deltaTime * speed);
    }
    Vector3 Random_vector()
    {
        Vector3 rand = new(Random.rotation.x, Random.rotation.y, Random.rotation.z);
        return rand;
    }
    Vector3 Random_vector_down()
    {
        Vector3 down = Random_vector() - transform.up * .5f;
        return down;
    }
}
