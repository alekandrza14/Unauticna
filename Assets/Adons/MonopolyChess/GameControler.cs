using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
   static public UltChess Curent;
    static public GameControler Instans;
    public Color current_color;
    public Color swap_color;
    public Color FirstCommandColor;
    public Color SecondCommandColor;
    public int MonetsWhite;
    public int MonetsDark;
    public Texture2D Cur1;
    public Texture2D Cur2;
    Color buffer_color;
    public Image color;
    public Text LabelWhite;
    public Text LabelBlack;
    void Start()
    {
        Instans = this;
        Cursor.SetCursor(Cur1, new Vector2(0, 0), CursorMode.Auto);
    }
    public void SetCursor(int a)
    {
        if (a == 1) Cursor.SetCursor(Cur1, new Vector2(0, 0), CursorMode.Auto);
        if (a == 2) Cursor.SetCursor(Cur2, new Vector2(0, 0), CursorMode.Auto);
    }
    // Update is called once per frame
    void Update()
    {
        LabelBlack.text = MonetsDark.ToString();
        LabelWhite.text = MonetsWhite.ToString();
        color.color = current_color;
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(r, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<UltChess>())
                {
                    if (hit.collider.GetComponent<UltChess>().color == current_color)
                    {

                        Curent = hit.collider.GetComponent<UltChess>();
                    }
                    if (hit.collider.GetComponent<UltChess>().OnlyBuyig)
                    {

                        Curent = hit.collider.GetComponent<UltChess>();
                    }
                }
            }
        }
       
    }
    public void swap()
    {
        buffer_color = current_color;
        current_color = swap_color;
        swap_color = buffer_color;
    }
    public void GiveMonet()
    {
        if (current_color == FirstCommandColor)
        {
            MonetsWhite += 1;
        }
        if (current_color == SecondCommandColor)
        {
            MonetsDark += 1;
        }
    }
    public int ComandMonet()
    {
        if (current_color == FirstCommandColor)
        {
            return 1;
        }
        if (current_color == SecondCommandColor)
        {
            return 2;
        }

        return 0;
    }

}
