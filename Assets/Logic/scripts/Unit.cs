using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameunitselect
{
    public static GameObject _this;
}

public class Unit : MonoBehaviour
{
    public GameObject metka;
    Transform taktikpoint1;
    Transform taktikpoint2()
    {
        if (taktikpoint1 == null) taktikpoint1 = FindFirstObjectByType<taktikpoint>().transform;
        return taktikpoint1;
    }
    public void onSelect()
    {
        gameunitselect._this = gameObject;
    }
    private void FixedUpdate()
    {
        if (taktikpoint2()) { Transform igrok = taktikpoint2();
            if (gameunitselect._this == gameObject) metka.SetActive(true); else { metka.SetActive(false); }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameunitselect._this = null;
            }
            if (gameunitselect._this == gameObject && Vector3.Distance(igrok.position, transform.position) > 3)
            {

                Vector3 Rotation = igrok.position - transform.position;
                transform.rotation = Quaternion.LookRotation(Rotation, transform.up);
                transform.position += transform.forward * (6f * Time.deltaTime);
                transform.Rotate(0, -90, 0);
                transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                //  transform.transform.localPosition = new Vector3(transform.position.x, 0.5f, transform.position.z);
            }
        }
    }
}
