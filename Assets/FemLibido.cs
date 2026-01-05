using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FemLibido : MonoBehaviour
{
    public float minlibido;
    public float porogvozbujenia = 200;
    public float porogvozbujeniamin = 150;
    public float porogvozbujeniamax = 200;
    public Image Poze;
    public GameObject soundStones;
    public float alphaProze;
    public static Vector3 savepos = new Vector3(float.NegativeInfinity,0,0);
    void Start()
    {
        savepos = mover.main().transform.position;
        if (VarSave.LoadMoney("Либидо♀AAA", 0) > 0) if (savepos.x!= float.NegativeInfinity)
        {

                alphaProze = 0;
                mover.main().transform.position = savepos;
        }
        if (VarSave.LoadMoney("Либидо♀", 0) > (decimal)porogvozbujenia)
        {
            Poze.color = new Color(1, (float)(VarSave.LoadMoney("Либидо♀", 0) / (decimal)porogvozbujenia), (float)(VarSave.LoadMoney("Либидо♀", 0) / (decimal)porogvozbujenia), alphaProze + (float)(VarSave.LoadMoney("Либидо♀", 0) / (decimal)porogvozbujenia));
        }
        if (VarSave.LoadMoney("Либидо♀", 0) < (decimal)minlibido) VarSave.LoadMoney("Либидо♀", (decimal)minlibido);
        InvokeRepeating("LibidoUpdate", 2, 2);
    }
    public void LibidoUpdate()
    {
        if (VarSave.LoadMoney("Либидо♀", 0) > (decimal)porogvozbujenia)
        {
            Poze.color = new Color(1, (float)(VarSave.LoadMoney("Либидо♀", 0) / (decimal)porogvozbujenia), (float)(VarSave.LoadMoney("Либидо♀", 0) / (decimal)porogvozbujenia), alphaProze + (float)(VarSave.LoadMoney("Либидо♀", 0) / (decimal)porogvozbujenia));
        }
        if (VarSave.LoadMoney("Либидо♀AAA", 0) > 0) if (savepos.x != float.NegativeInfinity)
        {
                mover.main().transform.position = savepos;
                VarSave.LoadMoney("Либидо♀AAA", -1);

                alphaProze = -0.1f;
                drochit();
        }
        if (VarSave.LoadMoney("Либидо♀", 0) > 250)
        {
            VarSave.SetMoney("Либидо♀AAA", 20);
            VarSave.SetMoney("Либидо♀", 0);
            

        }
        else
        {
            savepos = mover.main().transform.position;
        }
        if (VarSave.LoadMoney("Либидо♀", 0) < (decimal)minlibido) VarSave.LoadMoney("Либидо♀", (decimal)minlibido);
        VarSave.LoadMoney("Либидо♀",1);
    }
    public void drochit()
    {

        if (VarSave.LoadMoney("Либидо♀AAA", 0) < 0) Poze.color = new Color(1, (float)(VarSave.LoadMoney("Либидо♀", 0) / (decimal)porogvozbujenia), (float)(VarSave.LoadMoney("Либидо♀", 0) / (decimal)porogvozbujenia), alphaProze + (float)(VarSave.LoadMoney("Либидо♀", 0) / (decimal)porogvozbujenia));
        if (VarSave.LoadMoney("Либидо♀AAA", 0) > 0) Poze.color = new Color(1, 1, 1 , 1 + alphaProze);
        alphaProze -= Time.deltaTime;
        if (alphaProze < 0)
        {
            if (VarSave.LoadMoney("Либидо♀", 0) > (decimal)porogvozbujenia)
            {
                porogvozbujenia = porogvozbujeniamin;
            }
            if (VarSave.LoadMoney("Либидо♀", 0) < (decimal)porogvozbujenia)
            {
                porogvozbujenia = porogvozbujeniamax;
            }

            VarSave.LoadMoney("Либидо♀", -1);
            Instantiate(soundStones);
            if (VarSave.LoadMoney("Либидо♀", 0) > (decimal)porogvozbujenia)
            {
                alphaProze = 0.3f;
            }
          
            if (VarSave.LoadMoney("Либидо♀", 0) < (decimal)porogvozbujenia)
            {
                alphaProze = 1f;
            }

        }
    }
}
