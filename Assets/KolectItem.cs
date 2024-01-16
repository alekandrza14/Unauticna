using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class KolectItem : MonoBehaviour
{
    [SerializeField] string questItem;
    [SerializeField] short MaxquestItem;
    [SerializeField] GameObject prise;
    [SerializeField] int countPrise;
    void Update()
    {
        
        RaycastHit hit = MainRay.MainHit;
       if ( (VarSave.GetString("quest", SaveType.global) == questItem)) if (hit.collider != null) 
            if (hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Destroy(hit.collider.gameObject);
                Globalprefs.QuestItemKollect++;
                    if (MaxquestItem <= Globalprefs.QuestItemKollect)
                    {
                        Globalprefs.QuestItemKollect = 0;
                        for ( int i = 0 ; countPrise > i ; i++ ) 
                        {
                            GameObject obj = Instantiate(prise, mover.main().transform.position, Quaternion.identity);
                            obj.name = obj.name.Remove(obj.name.Length - 7);
                            VarSave.SetString("quest", "is done", SaveType.global);
                        }
                       
                    }
                VarSave.SetInt("QuestItemKollect", (int)Globalprefs.QuestItemKollect,SaveType.global);

            }
    }
}
