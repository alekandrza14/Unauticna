using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ЛетунСкрыпт : MonoBehaviour
{
    public Collider c;
    Vector3 target;
    public float speed = 6;
    bool attack;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Logic_tag_DamageObject>())
        {
            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - 0.01m);
          //  Destroy(gameObject);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            cistalenemy.dies++;

            VarSave.SetInt("Agr", cistalenemy.dies);
        }
        if (collision.collider.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true);
            VarSave.SetBool("страшный паук победил", true);



            GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);

        }
    }
    MultyTransform instance;
    // Update is called once per frame
    void Update()
    {
        if (!instance)
        {
            instance = FindFirstObjectByType<MultyTransform>();

        }
        Ray r = new Ray(transform.position, new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)));
        Debug.DrawRay(transform.position, r.direction);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit) && !c)
        {
            if (hit.collider != null)
            {
                c = hit.collider;
                target = hit.point;
            }
        }
        transform.rotation = Quaternion.LookRotation(-(target - transform.position), transform.up);
        if (c) transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        MultyObject multyObject = GetComponent<MultyObject>();

        if (c == GameManager.GetPlayer().gameObject.GetComponent<Collider>())
        {
            multyObject.W_Position += multyObject.W_Position > instance.W_Position ? -0.5f : 0.5f;

            multyObject.H_Position += multyObject.H_Position > instance.H_Position ? -0.5f : 0.5f;
        }
        else
        {
            multyObject.W_Position += Random.Range(-0.02f, 0.02f);

            multyObject.H_Position += Random.Range(-0.02f, 0.02f);
        }

        transform.Translate(new Vector3(
            Random.Range(-0.02f, 0.02f),
        Random.Range(-0.02f, 0.02f),
            Random.Range(-0.02f, 0.02f)));
        GetComponent<MultyObject>().startPosition.x = transform.position.x;
        GetComponent<MultyObject>().startPosition.y = transform.position.y;
        GetComponent<MultyObject>().startPosition.z = transform.position.z;
        if (Vector3.Distance(target, transform.position) < 3 || Vector3.Distance(target, transform.position) > 3000)
        {

            if (Random.Range(1, 4) == 1)
            {
                c = GameManager.GetPlayer().gameObject.GetComponent<Collider>();
                target = GameManager.GetPlayer().transform.position;

            }
            else
            {


                c = null;
            }
        }
    }
}
