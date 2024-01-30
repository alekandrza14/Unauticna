using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[AddComponentMenu("Physics S3D/Planet Physics Setup")]
public class PlanetGravity : MonoBehaviour
{
    public float gravity = -9;
    public bool inverse;
    public Transform body;
    private void Update()
    {
        Arract();
    }
    // Start is called before the first frame update
    public void Arract()
    {
        Vector3 gravityUp = (body.position - Vector3.zero).normalized;
        if (inverse) gravityUp *= -1;
        Vector3 bodyup = body.up;
        if (body.gameObject.GetComponent<mover>() && FindFirstObjectByType<PlayerRayMarchCollider>().GetCenterDist() < 0)
        {

            if (body.gameObject.GetComponent<mover>().IsGraund == true)
            {
                body.gameObject.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
            }
        }
        if (body.gameObject.GetComponent<mover>() && FindFirstObjectByType<PlayerRayMarchCollider>().GetCenterDist() > 0)
        {

            if (body.gameObject.GetComponent<mover>().IsGraund == true)
            {
                body.gameObject.GetComponent<Rigidbody>().drag = 20;
            }
        }
        Quaternion targetrotation = Quaternion.FromToRotation(bodyup,gravityUp)*body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetrotation,50 * Time.deltaTime);
    }
}
