using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class matr : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource source;
    [SerializeField] string function;
    [SerializeField] bool selfActivation;
    [SerializeField] float time = 1f;

    private void Start()
    {
        if (selfActivation)
        {
            source.clip = clip;
            source.Play();
            Invoke(function, 2.5f);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            source.clip = clip;
            source.Play();
            Invoke(function,2.5f);
        }
        
    }
    IEnumerator end()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    public void ���()
    {
        RaycastHit hit = MainRay.MainHit; if (hit.collider != null)
        {
            MonoBehaviour[] mb = hit.collider.gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour item in mb)
            {
                item.enabled = false;
            }

            Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
            cistalenemy.dies += 1;
            if (true) StartCoroutine(end());
        }
    }
    public void ��()
    {
       
            if (true) StartCoroutine(end());
      
    }
    public void fash()
    {

        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {
            if (Random.Range(0, 4) == 1)
            {
                GameObject select = hit.collider.gameObject;
                if (select.GetComponent<itemName>().ItemDangerLiberty != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty2 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty2, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty3 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty3, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty4 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty4, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty5 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty5, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty6 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty6, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty7 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty7, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty8 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty8, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty9 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty9, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty2 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty2, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty3 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty3, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty4 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty4, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty5 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty5, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty6 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty6, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty7 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty7, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty8 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty8, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty9 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty9, 1);

                }
                Destroy(hit.collider.gameObject);
               
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                if (true) StartCoroutine(end());
            }
        }
    }
    public void ���()
    {

        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {
            hit.collider.gameObject.AddComponent<cfc>().cursevelosity = mover.main().PlayerCamera.transform.forward;
            if (true) StartCoroutine(end());

        }
    }
    //poverfull
    public void poverfull()
    {

        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {

            Instantiate(Resources.Load<GameObject>("items/�������_��_�������������"), hit.point, Quaternion.identity);

            if (true) StartCoroutine(end());

        }
    }
    public void ������()
    {

        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {
            GameObject select = hit.collider.gameObject;
            if (select.GetComponent<itemName>().ItemDangerLiberty != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty2 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty2, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty3 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty3, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty4 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty4, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty5 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty5, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty6 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty6, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty7 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty7, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty8 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty8, 1);

            }
            if (select.GetComponent<itemName>().ItemDangerLiberty9 != "")
            {
                VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty9, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty2 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty2, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty3 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty3, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty4 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty4, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty5 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty5, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty6 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty6, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty7 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty7, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty8 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty8, 1);

            }
            if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty9 != "")
            {
                VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty9, 1);

            }
            hit.collider.gameObject.AddComponent<MeshDestroy>().CutCascades = 12;
            hit.collider.gameObject.GetComponent<MeshDestroy>().ExplodeForce = 500;
            hit.collider.gameObject.GetComponent<MeshDestroy>().Invoke("DestroyMesh", 0);

            if (true) StartCoroutine(end());

        }
    }
    public void more()
    {

        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {
            GameObject obj = Instantiate(hit.collider.gameObject, hit.point, Quaternion.identity);
            obj.name = obj.name.Remove(obj.name.Length - 7);

            if (true) StartCoroutine(end());

        }
    }
    public void ����()
    {

        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {

            if (hit.collider != null)
            {
                MonoBehaviour[] mb = hit.collider.gameObject.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour item in mb)
                {
                    item.enabled = false;
                }
                if (true) StartCoroutine(end());
            }

        }
    }
    public void ����()
    {

        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {

            if (hit.collider != null)
            {
                MonoBehaviour[] mb = hit.collider.gameObject.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour item in mb)
                {
                    item.enabled = false;
                }
                Globalprefs.LoadTevroPrise(5);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                if (true) StartCoroutine(end());
            }

        }
    }
    public void ��()
    {

        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {

            if (hit.collider != null)
            {
                MonoBehaviour[] mb = hit.collider.gameObject.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour item in mb)
                {
                    item.enabled = false;
                }
                GameObject select = hit.collider.gameObject;
                if (select.GetComponent<itemName>().ItemDangerLiberty != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty2 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty2, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty3 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty3, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty4 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty4, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty5 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty5, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty6 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty6, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty7 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty7, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty8 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty8, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty9 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty9, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty2 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty2, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty3 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty3, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty4 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty4, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty5 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty5, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty6 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty6, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty7 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty7, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty8 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty8, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty9 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty9, 1);

                }
                Instantiate(Resources.Load<GameObject>("items/water"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/water"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/water"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/water"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/water"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/water"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/water"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/water"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/water"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/water"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/water"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), hit.point, Quaternion.identity);
                if (true) StartCoroutine(end());
            }

        }
    }
    ItemDemake Demake = new ItemDemake();
    public void ��()
    {

        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {

            //  Destroy(hitupdown.collider.gameObject);
            GameObject select = hit.collider.gameObject;
            if (select.GetComponent<itemName>())
            {

                if (select.GetComponent<itemName>().Unprohibiteble)
                {
                    return;
                }
                if (select.GetComponent<itemName>().ItemDangerLiberty != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty2 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty2, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty3 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty3, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty4 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty4, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty5 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty5, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty6 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty6, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty7 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty7, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty8 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty8, 1);

                }
                if (select.GetComponent<itemName>().ItemDangerLiberty9 != "")
                {
                    VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty9, 1);

                }
            }
            if (select.GetComponent<CustomObject>())
            {
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty2 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty2, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty3 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty3, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty4 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty4, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty5 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty5, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty6 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty6, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty7 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty7, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty8 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty8, 1);

                }
                if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty9 != "")
                {
                    VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty9, 1);

                }
            }
            if (VarSave.GetString("Demake" + Globalprefs.Reality) != "") Demake = JsonUtility.FromJson<ItemDemake>(VarSave.GetString("Demake" + Globalprefs.Reality));
            if (hit.collider.GetComponent<itemName>()) 
                if (hit.collider.GetComponent<itemName>()._Name != "�������") 
                {
                    Demake.item.Add(hit.collider.GetComponents<itemName>()[0]._Name); 
                }
            if (hit.collider.GetComponent<CustomObject>()) Demake.co.Add(hit.collider.GetComponent<CustomObject>().s);
            VarSave.SetString("Demake" + Globalprefs.Reality, JsonUtility.ToJson(Demake));

           if(true)  StartCoroutine(end());
        }
    }
    public void ��()
    {

       

            //  Destroy(hitupdown.collider.gameObject);
            
            VarSave.DeleteKey("Demake" + Globalprefs.Reality);

        if (VarSave.GetString("Demake" + Globalprefs.Reality) == "") StartCoroutine(end());
    }
    public void ������()
    {
       
        Globalprefs.LoadTevroPrise(-1000); 
        StartCoroutine(end());
    }
    public void evr()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<Rigidbody>())
            {
                if (Random.Range(0, 4) == 1)
                {
                    Globalprefs.LoadTevroPrise(5);
                    if (true) StartCoroutine(end());
                }
            }
            if (hit.collider.GetComponent<CharacterName>())
            {
                if (Random.Range(0, 4) == 1)
                {
                    Globalprefs.LoadTevroPrise(5);
                    if (true) StartCoroutine(end());
                }
            }
            if (hit.collider.GetComponent<itemName>())
            {
                if (hit.collider.GetComponent<itemName>().isLife)
                {
                    if (Random.Range(0, 4) == 1)
                    {
                        Globalprefs.LoadTevroPrise(5);
                        if (true) StartCoroutine(end());
                    }
                }
            }
        }
    }
}
