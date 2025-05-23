using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Move4DAxis : MonoBehaviour
{
    GameObject select;
   public static GameObject GetSelect;
    [SerializeField] GameObject[] axis;
    int curaxis = 3;

    // Update is called once per frame
    void Update()
    {
        if (select != null)
        {
            if (select.GetComponent<MultyObject>())
            {
                transform.position = select.transform.position + (new Vector3(1, 0, -1) * (select.GetComponent<MultyObject>().W_Position - mover.main().W_position));
                transform.position += (new Vector3(1, 1, 1) * (select.GetComponent<MultyObject>().H_Position - mover.main().H_position));
            }
            else transform.position = select.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            
                if (MainRay.MainHit.collider != null)
                {
                    if (MainRay.MainHit.collider.gameObject.layer != LayerMask.NameToLayer("Interface"))
                    {
                        select = MainRay.MainHit.collider.gameObject;
                    }
                }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            
                if (MainRay.MainHit.collider != null)
                {
                    if (MainRay.MainHit.collider.gameObject.layer == LayerMask.NameToLayer("Interface"))
                    {
                        if (axis[0] == MainRay.MainHit.collider.gameObject)
                        {
                            curaxis = 0;
                        }
                        if (axis[1] == MainRay.MainHit.collider.gameObject)
                        {
                            curaxis = 1;
                        }
                        if (axis[2] == MainRay.MainHit.collider.gameObject)
                        {
                            curaxis = 2;
                        }
                    if (axis[3] == MainRay.MainHit.collider.gameObject)
                    {
                        curaxis = 4;
                    }
                    if (axis[4] == MainRay.MainHit.collider.gameObject)
                    {
                        curaxis = 5;
                    }
                }
                }

            
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            curaxis = 3;
        }
        if (select && !Input.GetKey(KeyCode.LeftControl))
        {
            if (curaxis == 0)
            {
                if (select.GetComponent<MultyObject>())
                {
                    select.GetComponent<MultyObject>().startPosition.x += Input.GetAxis("Mouse X");
                }
                else
                    select.transform.position += (Vector3.right * Input.GetAxis("Mouse X"));
                if (select.GetComponent<HyperbolicPoint>())
                {
                    select.GetComponent<HyperbolicPoint>().HyperboilcPoistion.applyTranslationY(Input.GetAxis("Mouse X")/20);
                }
            }
            if (curaxis == 1)
            {
                if (select.GetComponent<MultyObject>())
                {
                    select.GetComponent<MultyObject>().startPosition.y += Input.GetAxis("Mouse X");
                }
                else
                    select.transform.position += (Vector3.up * Input.GetAxis("Mouse X"));
               
            }
            if (curaxis == 2)
            {
                if (select.GetComponent<MultyObject>())
                {
                    select.GetComponent<MultyObject>().startPosition.z += Input.GetAxis("Mouse X");
                }else
                    select.transform.position += (Vector3.forward * Input.GetAxis("Mouse X")); 
                if (select.GetComponent<HyperbolicPoint>())
                {
                    select.GetComponent<HyperbolicPoint>().HyperboilcPoistion.applyTranslationZ(Input.GetAxis("Mouse X") / 20);
                }
            }
            if (curaxis == 4)
            {
                if (select.GetComponent<MultyObject>())
                    select.GetComponent<MultyObject>().W_Position += Input.GetAxis("Mouse X");
            }
            if (curaxis == 5)
            {
                if (select.GetComponent<MultyObject>())
                    select.GetComponent<MultyObject>().H_Position += Input.GetAxis("Mouse X");
            }
        }
        if (select && Input.GetKey(KeyCode.LeftControl))
        {
            if (curaxis == 1)
            {
                select.transform.localScale += (Vector3.one * (Input.GetAxis("Mouse X")));
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            if (select.GetComponent<SocialObject>())
            {
                Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                VarSave.SetInt("Agr", cistalenemy.dies);
            }
            if (select.GetComponent<CharacterName>())
            {
                Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                VarSave.SetInt("Agr", cistalenemy.dies);
            }
            if (select.GetComponent<CharacterStats>())
            {
                Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                VarSave.SetInt("Agr", cistalenemy.dies);
            }
            if (select.GetComponent<itemName>())
            {

                if (select.GetComponent<itemName>().isLife)
                {
                    Globalprefs.LoadTevroPrise(-100); cistalenemy.dies++;

                    VarSave.SetInt("Agr", cistalenemy.dies);
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
                if (!select.GetComponent<itemName>().Undeleteble)
                {
                    VarSave.LoadMoney("Karma", -1);
                    Destroy(select);
                }

            }
            else if (select.GetComponent<CustomObject>())
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
                VarSave.LoadMoney("Karma", -1);
                Destroy(select);
            }
            else
            {
                VarSave.LoadMoney("Karma", -1);
                Destroy(select);
            }
        }
    }
}
