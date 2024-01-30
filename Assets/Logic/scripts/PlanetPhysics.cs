using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[AddComponentMenu("Physics S3D/Planet Physics")]
public class PlanetPhysics : MonoBehaviour
{
    public float gravity;
    public Transform body;
    private void Start()
    {
        gravity = FindAnyObjectByType<PlanetGravity>().gravity;
        body = GetComponent<Transform>();
        if (GameObject.FindFirstObjectByType<PlanetGravity>() != null)
        {
            InvokeRepeating("Arract", 1, 0.02f+UnityEngine.Random.Range(0,0.01f));
 
             body.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);

          if (FindObjectsByType<HyperbolicCamera>(sortmode.main).Length == 0) body.gameObject.GetComponent<Rigidbody>().useGravity = true;
          body.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
    // Start is called before the first frame update
    public void Arract()
    {
        Vector3 gravityUp = (body.position - Vector3.zero).normalized;
        Vector3 bodyup = body.up;
        
                body.gameObject.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
           
            Quaternion targetrotation = Quaternion.FromToRotation(bodyup,gravityUp)*body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetrotation,50 * Time.deltaTime);
    }
    private void OnDisable()
    {
        enabled = !enabled;
    }
}
