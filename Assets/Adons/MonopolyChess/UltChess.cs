using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public enum ChessType
{
    Pepole,
    Knight,
    Priest,
    Ferz,
    Konservacioner,
    Mognat_aka_dominator,
    Quen,
    Prinse,
    King

}

public class UltChess : MonoBehaviour
{
    public ChessType type;
    public Color color;
    public Transform[] postRayCast;
    public int Prise;
    public bool OnlyBuyig;
    Vector3 NextPosition;
    Vector3 BackPosition;
    float lerp;
    UltChess jertva;
    [SerializeField] MeshRenderer meshRenderer;
    void OnTriggerEnter(Collider Other)
    {
        if (Other.GetComponent<UltChess>())
        {
            jertva = Other.GetComponent<UltChess>();
        }
    }
    void Start()
    {
        if (!OnlyBuyig)
        {
            meshRenderer.material.color = color;
        }
        else
        {

            meshRenderer.material.color = Color.yellow;
        }
        NextPosition = transform.position;
        BackPosition = transform.position;
    }
    void Update()
    {
        if (this == GameControler.Curent && OnlyBuyig)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (GameControler.Instans.ComandMonet() == 1)
                {
                    if (GameControler.Instans.MonetsWhite >= Prise)
                    {
                        color = GameControler.Instans.FirstCommandColor;
                        meshRenderer.material.color = color;
                        OnlyBuyig = false;
                        GameControler.Instans.MonetsWhite -= Prise;
                    }
                }
                if (GameControler.Instans.ComandMonet() == 2)
                {
                    if (GameControler.Instans.MonetsDark >= Prise)
                    {
                        color = GameControler.Instans.SecondCommandColor;
                        meshRenderer.material.color = color;
                        OnlyBuyig = false;
                        GameControler.Instans.MonetsDark -= Prise;
                    }
                }
            }
        }
        if (this == GameControler.Curent && !OnlyBuyig)
        {
          if(Vector3.Distance( BackPosition, NextPosition) > 0.1)  lerp += Time.deltaTime;
            transform.position = Vector3.Lerp(BackPosition, NextPosition, lerp);
            if (lerp > 1)
            {
                if (jertva) {
                    if (jertva.color == new Color(1,0,1,1))
                    {
                        GameControler.Instans.GiveMonet();
                       Destroy(jertva.gameObject);
                    }
                    else if (jertva.OnlyBuyig)
                    {

                    }
                    else if (jertva.color != color)
                    {
                        Destroy(jertva.gameObject);
                    }
                }
                NextPosition = transform.position;
                BackPosition = transform.position;
                GameControler.Instans.swap();
                GameControler.Curent = null;
                lerp = 0;
            }
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (type == ChessType.Mognat_aka_dominator)
            {
                GameControler.Instans.SetCursor(1);
                if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.GetComponent<UltChess>())
                        {
                            if (hit.collider.GetComponent<UltChess>().color != color)
                            {
                                lerp = 0;
                                BackPosition = transform.position;
                                NextPosition = hit.collider.transform.position;
                            }
                        }
                        else
                        {
                            lerp = 0;
                            BackPosition = transform.position;
                            NextPosition = hit.collider.transform.position;
                        }
                    }
                }
            }
            if (type != ChessType.Mognat_aka_dominator)
            {
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        bool its = false;
                        foreach (Transform item in postRayCast)
                        {
                            if ((int)hit.collider.transform.position.x == (int)item.position.x)
                            {
                                if ((int)hit.collider.transform.position.y == (int)item.position.y)
                                {
                                    if ((int)hit.collider.transform.position.z == (int)item.position.z)
                                    {
                                        if (Input.GetKeyDown(KeyCode.Mouse0))
                                        {

                                            if (hit.collider.GetComponent<UltChess>())
                                            {
                                                if (hit.collider.GetComponent<UltChess>().color != color)
                                                {
                                                    lerp = 0;
                                                    BackPosition = transform.position;
                                                    NextPosition = hit.collider.transform.position;
                                                }
                                            }
                                            else
                                            {
                                                lerp = 0;
                                                BackPosition = transform.position;
                                                NextPosition = hit.collider.transform.position;
                                            }
                                        }
                                        its = true;
                                    }
                                   
                                }
                               
                            }
                           
                        }
                        if (!its)
                        {

                            GameControler.Instans.SetCursor(2);
                        }
                        else
                        {
                            GameControler.Instans.SetCursor(1);
                        }
                    }
                }
            }
        }
    }
}
