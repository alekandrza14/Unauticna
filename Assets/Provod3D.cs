using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Provod3D : MonoBehaviour
{
    public bool povered;
    public bool Unpovered;
    public bool upadted;
    public Transform Vec;
    public int times;
    public int predohtimes;
    public LightStick Light;


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Provod3D>())
        {

            if (!povered && other.GetComponent<Provod3D>().povered)
            {


                povered = true;
                //  Unpovered = false;
            }
            if (Unpovered)
            {
                times++;
                if (times > 3)
                {
                    Unpovered = false;
                    times = 0;
                }

                povered = false;

                if (other.GetComponent<Provod3D>().povered) other.GetComponent<Provod3D>().Unpovered = true;
                other.GetComponent<Provod3D>().povered = false;

            }

          /* */

           
        }
        if (povered) if (other.GetComponent<LightStick>())
            {
                Light = other.GetComponent<LightStick>();
                other.GetComponent<LightStick>().energyData.energy++;
            }
        if (povered) if (other.GetComponent<Predoh>())
            {
                predohtimes++;
                if (predohtimes>3)
                {
                    Unpovered = true;
                    predohtimes = 0;
                }
            }
        if (!povered) if (other.GetComponent<LightStick>())
            {
                Light = other.GetComponent<LightStick>();
                other.GetComponent<LightStick>().energyData.energy=0;
            }
        if (other.GetComponent<MonoBehaviour>())
        {
            if (!other.GetComponent<Provod3D>()) if (other.GetComponent<CustomSaveObject>()) foreach (MonoBehaviour item in other.GetComponents<MonoBehaviour>())
            {
                if (povered)
                {
                    item.Invoke("OnSignal", 0);
                }
            }
            
        }
    }
    public void OnInteractive()
    {
        if (povered)
        {
            Unpovered = true;
        }
        else
        {
            povered = true;
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Provod3D>())
        {
            Vec.rotation = Quaternion.LookRotation(other.transform.position - transform.position, Vector3.up);


        }
       
        if (other.GetComponent<LightStick>())
        {
          //  Light = other.GetComponent<LightStick>();
        }


    }
}
