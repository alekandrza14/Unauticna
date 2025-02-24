using UnityEngine;

public class PayKarmas : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {



            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {

                    if (Globalprefs.LoadTevroPrise(0) >= 100)
                    {
                        
                        VarSave.LoadMoney("Karma", 1);
                        Globalprefs.LoadTevroPrise(-100);

                    }


                }
            }

        }
    }
}
