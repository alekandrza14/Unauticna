using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinContoler : MonoBehaviour
{
    [SerializeField] GameObject[] PlayersModelObjObjects;
    [SerializeField] GameObject PlayerModelObject;
    [SerializeField] GameObject[] PlayerModelObjects;
    [SerializeField] int[] PlayerModelTags;
    [SerializeField] Animator[] SkinedAnimators;
    public string id;
    mover m2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SkinUpdate", 0f, 8);
        if (!VarSave.ExistenceVar("Controler")) VarSave.SetString("Controler","0");
       
    }
    private void SkinOff()
    {
        bool e = playerdata.Geteffect("KsenoMorfin") != null;
        Logic_tag_Skin[] ls = FindObjectsByType<Logic_tag_Skin>(sortmode.main);
        foreach (Logic_tag_Skin i in ls)
        {
            if (!e)
            {
                i.gameObject.SetActive(true);
            }
            if (e)
            {
                i.gameObject.SetActive(false);
            }
            i.gameObject.layer = 8;
        }
        if (mover.DopPlayerModel)
        {
            Renderer[] renderers = mover.DopPlayerModel.GetComponentsInChildren<Renderer>();
            foreach (Renderer i in renderers)
            {
                i.gameObject.layer = 8;
            }
        }
        if (VarSave.GetString("Controler") == id){
            SkinedAnimators[0].enabled = true;
            m2.animator = SkinedAnimators[0];
        }
        for (int i = 0; i < PlayerModelObjects.Length; i++)
        {

            if (VarSave.ExistenceVar("Controler"))
            {
                if (PlayerModelObjects[i].GetComponent<Logic_tag_Skin>().id == (VarSave.GetString("Controler")))
                {

                    PlayerModelObjects[i].SetActive(true);
                  
                }
                else
                {
                    PlayerModelObjects[i].SetActive(false);
                }
            }
            else if (!e)
            {
                if (PlayerModelObjects[i].GetComponent<Logic_tag_Skin>().id == "0")
                {

                    PlayerModelObjects[i].SetActive(true);

                }
                else
                {

                    PlayerModelObjects[i].SetActive(false);

                }
            }
            else if (e)
            {
                

                    PlayerModelObjects[i].SetActive(false);

                
               
            }
        }
    }

    private void SkinManager()
    {
        if (mover.DopPlayerModel)
        {
            Renderer[] renderers = mover.DopPlayerModel.GetComponentsInChildren<Renderer>();
            foreach (Renderer i in renderers)
            {
                i.gameObject.layer = 0;
            }
        }
         Logic_tag_Skin[] ls = FindObjectsByType<Logic_tag_Skin>(sortmode.main);
        foreach (Logic_tag_Skin i in ls)
        {
            if (playerdata.Geteffect("KsenoMorfin") != null)
            {
                i.gameObject.SetActive(false);
            }
            if (playerdata.Geteffect("KsenoMorfin") == null)
            {
                i.gameObject.SetActive(true);
            }
            if (playerdata.Geteffect("KsenoMorfin") == null)
            {
                i.gameObject.layer = 0;
            }
            if (playerdata.Geteffect("KsenoMorfin") != null)
            {
                i.gameObject.layer = 8;
            }
        }
        if(VarSave.GetString("Controler") == id)
        {
            SkinedAnimators[0].enabled = true;
            m2.animator = SkinedAnimators[0];
        }
        for (int i = 0; i < PlayerModelObjects.Length; i++)
        {

            if (VarSave.ExistenceVar("Controler"))
            {
                if (PlayerModelObjects[i].GetComponent<Logic_tag_Skin>().id == (VarSave.GetString("Controler")))
                {

                    PlayerModelObjects[i].SetActive(true);
                   
                }
                else
                {

                    PlayerModelObjects[i].SetActive(false);
                   
                }
            }
            else
            {
                if (PlayerModelObjects[i].GetComponent<Logic_tag_Skin>().id == "0")
                {

                    PlayerModelObjects[i].SetActive(true);
                 
                }
                else
                {

                    PlayerModelObjects[i].SetActive(false);
                    
                }
            }
        }
    }
    // Update is called once per frame
   public void SkinUpdate()
    {
        m2 = mover.main();
        if (m2.faceViewi == faceView.first)
        {
            SkinOff();
        }
        if (m2.faceViewi == faceView.trid)
        {
            SkinManager();
        }
        if (m2.faceViewi == faceView.fourd)
        {
            SkinManager();
        }
        if (playerdata.Geteffect("invisible") == null)
        {

            m2.invisibeobject = 0;
            for (int i = 0; i < PlayersModelObjObjects.Length; i++)
            {

                if (PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>())
                {
                    Material m3 = Resources.Load<Material>("pm/playermat");
                    if (m2.c1.r + m2.c1.g + m2.c1.b != 0) m3.color = m2.c1;
                    List<Material> m = new List<Material>();
                    foreach (Material m2 in PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>().materials)
                    {
                        m.Add(m2);
                    }
                  if(PlayerModelTags[i]!=-1)  m[PlayerModelTags[i]] = m3;
                    PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>().SetMaterials(m);
                }
                if (PlayersModelObjObjects[i].GetComponent<MeshRenderer>())
                {

                    Material m3 = Resources.Load<Material>("pm/playermat");
                    if (m2.c1.r + m2.c1.g + m2.c1.b != 0) m3.color = m2.c1;
                    List<Material> m = new List<Material>();
                    foreach (Material m2 in PlayersModelObjObjects[i].GetComponent<MeshRenderer>().materials)
                    {
                        m.Add(m2);
                    }
                    if (PlayerModelTags[i] != -1) m[PlayerModelTags[i]] = m3;
                    PlayersModelObjObjects[i].GetComponent<MeshRenderer>().SetMaterials(m);
                }
            }
            //playermat
        }
        if (playerdata.Geteffect("invisible") != null)
        {

            m2.invisibeobject = 10;
            for (int i = 0; i < PlayersModelObjObjects.Length; i++)
            {

                if (PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>())
                {
                    Material m3 = Resources.Load<Material>("pm/playermatinvisible");
                    if (m2.c1.r + m2.c1.g + m2.c1.b != 0) m3.color = new Color(0, 0, 0, 0) + (m2.c1 * 0.1f);
                    List<Material> m = new List<Material>();
                    foreach (Material m2 in PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>().materials)
                    {
                        m.Add(m2);
                    }
                    if (PlayerModelTags[i] != -1) m[PlayerModelTags[i]] = m3;
                    PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>().SetMaterials(m);
                }
                if (PlayersModelObjObjects[i].GetComponent<MeshRenderer>())
                {

                    Material m3 = Resources.Load<Material>("pm/playermatinvisible");
                    if (m2.c1.r + m2.c1.g + m2.c1.b != 0) m3.color = new Color(0, 0, 0, 0) + (m2.c1 * 0.1f);
                    List<Material> m = new List<Material>();
                    foreach (Material m2 in PlayersModelObjObjects[i].GetComponent<MeshRenderer>().materials)
                    {
                        m.Add(m2);
                    }
                    if (PlayerModelTags[i] != -1) m[PlayerModelTags[i]] = m3;
                    PlayersModelObjObjects[i].GetComponent<MeshRenderer>().SetMaterials(m);
                }
            }
            //playermat
        }
        //
    }
}
