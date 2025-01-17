using UnityEngine;

public class Bombarderovka : MonoBehaviour
{
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
    
    float timer;
    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        mover m = mover.main();
        timer += Time.deltaTime;
        if (timer > 30)
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
        }
    }
}
