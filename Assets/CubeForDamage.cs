using UnityEngine;

public class CubeForDamage : MonoBehaviour
{
    int hp = 3;

    private void OnCollisionStay(Collision c)
    {
        if (c.collider.GetComponent<Logic_tag_DamageObject>())
        {
            hp--;
            if (hp < 0)
            {
                Globalprefs.LoadTevroPrise(-100);
                Destroy(gameObject);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
