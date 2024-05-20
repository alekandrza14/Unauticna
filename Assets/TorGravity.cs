using Unity.Mathematics;
using UnityEngine;

[AddComponentMenu("Physics S3D/Tonet Physics Setup")]
public class TorGravity : MonoBehaviour
{
    public Transform centerpoint;
    public Transform torpoint;
    public mover m;
    public float gravity = -9;
    public bool inverse;

    // Update is called once per frame
    void Update()
    {
        centerpoint.position = Vector3.zero;
        centerpoint.rotation = Quaternion.LookRotation(m.transform.position- centerpoint.position, Vector3.up);
        centerpoint.rotation = new Quaternion(0, centerpoint.rotation.y,0, centerpoint.rotation.w); Arract();
    }
    public static TorGravity Instance;
    public static TorGravity main()
    {
        if (Instance == null)
        {
            Instance = FindFirstObjectByType<TorGravity>();
        }
        return Instance;
    }
  
    // Start is called before the first frame update
    public void Arract()
    {
        Transform body = m.transform;
        Vector3 gravityUp = (body.position - torpoint.position).normalized;
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
                body.gameObject.GetComponent<Rigidbody>().linearDamping = 20;
            }
        }
        Quaternion targetrotation = Quaternion.FromToRotation(bodyup, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetrotation, 50 * Time.deltaTime);
    }
}
