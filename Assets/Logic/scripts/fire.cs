using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public static GameObject o;
    float timer;
    int i;
  public static bool Init()
    {

        if (!o) o = Resources.Load<GameObject>("items/Fire");
        return true;
    }
    private void Start()
    {
       if(!o) o = Resources.Load<GameObject>("items/Fire");
        if (GameObject.FindFirstObjectByType<PlanetGravity>() != null)
        {
            Transform body;
            body = transform;
            Vector3 gravityUp = (body.position - Vector3.zero).normalized;
            Vector3 bodyup = body.up;
            Quaternion targetrotation = Quaternion.FromToRotation(bodyup, gravityUp) * body.rotation;
            body.rotation = Quaternion.Slerp(body.rotation, targetrotation, 5000000 * Time.deltaTime);
        }
        if (VarSave.GetInt("UST") == 1)
        {
            i += 2;
        }
        i += Globalprefs.Chanse_fire;
    }
    private void OnCollisionEnter(Collision collision)
    {
        timer = 0;
        GetComponent<Rigidbody>().AddForce(transform.up * 5f, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(new Vector3(Global.Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))*2, ForceMode.Impulse);
        if (((int)Random.Range(0f,1f+1+i))>=1&&FindObjectsByType<fire>(sortmode.main).Length < 30)
        {
            if (o)
            {

                Spawn();
            }
        }
        else
        {
            Destroy(gameObject);
            
        }
    }
    private void Update()
    {
        if (!lml2.Find())
        {
            Instantiate(Resources.Load("SEffect/Snayp"));
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }
    void Spawn()
    {
        Globalprefs.LoadTevroPrise(-15);
        mover.main().Spawninitfire(transform.position);
    }
    private void OnDisable()
    {
        enabled = !enabled;
    }
}
