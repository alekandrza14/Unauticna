using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGNHitCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Logic_tag_DamageObject>())
        {
            SGNCharacter.Instance.hp -= 1;
        }
    }
}
