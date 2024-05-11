using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum helpthTargets
{
    отлично,норм,ок,потчи,фаза_електричествизма
}

public class CBCharacter : MonoBehaviour
{
    public Text dist;
    public Text healpthTEXT;
    public Scrollbar helpthbar;
    public float healpth = 2800;
    public string healthname(float x)
    {
        helpthTargets ht = helpthTargets.отлично;
        if (x>=1)
        {
            ht = helpthTargets.отлично;
        }
        else if (x >= 0.9)
        {
            ht = helpthTargets.норм;
        }
        else if (x >= 0.5)
        {
            ht = helpthTargets.ок;
        }
        else if (x >= 0.2)
        {
            ht = helpthTargets.потчи;
        }
        else if (x < 0)
        {
            ht = helpthTargets.фаза_електричествизма;
        }
        return ht.ToString();
    }
    private void OnCollisionStay(Collision collision)
    {
        GetComponent<Rigidbody>().linearVelocity += Vector3.up;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Logic_tag_DamageObject>())
        {
            healpth -= 1;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(mover.main().transform.position-transform.position, Vector3.up);
        dist.text = "растояние : " + Vector3.Distance(transform.position, mover.main().transform.position) + "мн";
        healpthTEXT.text = "hp : "+healthname(healpth / 3000) +" / ██∞*Ω";
        transform.Translate(5*Time.deltaTime,0,5 * Time.deltaTime);
        helpthbar.size = healpth/3000;
    }
}
