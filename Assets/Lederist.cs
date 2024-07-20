using UnityEngine;

public class Lederist : MonoBehaviour
{
    void Start()
    {
        Globalprefs.LoadTevroPrise(-10);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Logic_tag_DamageObject>())
        {
          for(int i =0;i<20;i++)  Instantiate(Resources.Load<GameObject>("items/FashistEnemye"), gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
}
