using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocaleGravity : MonoBehaviour
{
    public float speedgravity;
    public AnimationCurve gravityAreaCurve;
    public float gravitydistoffset;
    public float obgectMass;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.localScale.x +
            other.transform.localScale.y +
            other.transform.localScale.z < obgectMass && other.gameObject != gameObject
            )
        {
            Vector3 v3 = other.transform.position;
            float dist = Vector3.Distance(v3, transform.position);
            Vector3 MoveVec = v3 - transform.position;
            MoveVec /= dist;
            MoveVec *= speedgravity;
            MoveVec *= gravityAreaCurve.Evaluate(gravitydistoffset - dist) * Time.deltaTime;
            other.transform.position -= MoveVec;

            
        }
    }
}
