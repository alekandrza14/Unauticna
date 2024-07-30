using UnityEngine;

public class KillerEnemye : MonoBehaviour
{
    float timer;
    public GameObject target;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.GetComponent<itemName>().gameObject == target)
        {
          
            Destroy(target);
        }
    }
    void Update()
    {
        if (!lml1.Find())
        {
            Instantiate(Resources.Load("SEffect/Snayp"));
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        if (timer > 20)
        {
            if (Global.Random.Chance(2))
            {
                target = FindAnyObjectByType<itemName>().gameObject;
            }
            else
            {
                target = mover.main().gameObject;
            }
            timer = 0;
        }
        if (target)
        {
            transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
            transform.Translate(0, 0, 20 * Time.deltaTime);
        }
    }
}
