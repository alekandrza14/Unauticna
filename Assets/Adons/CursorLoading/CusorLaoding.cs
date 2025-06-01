using UnityEngine;

public class CusorLaoding : MonoBehaviour
{
    public Texture2D leftlidertatian;
    public Texture2D leftdemocratian;
    public Texture2D leftavtoriarian;
    public Texture2D leftnonpositionalian;
    public Texture2D mindlidertatian;
    public Texture2D minddemocratian;
    public Texture2D mindavtoriarian;
    public Texture2D mindnonpositionalian;
    public Texture2D rightlidertatian;
    public Texture2D rightdemocratian;
    public Texture2D rightavtoriarian;
    public Texture2D rightnonpositionalian;
    public Texture2D biopylidertatian;
    public Texture2D biopydemocratian;
    public Texture2D biopyavtoriarian;
    public Texture2D biopynonpositionalian;
    void Start()
    {
        if (PolitDate.IsVersionF() == politicfreedom.avtoritatian)
        {
            if (PolitDate.IsVersionE() == politiceconomic.right)
            {
                Cursor.SetCursor(rightavtoriarian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.mind)
            {
                Cursor.SetCursor(mindavtoriarian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.left)
            {
                Cursor.SetCursor(leftavtoriarian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.bipoly)
            {
                Cursor.SetCursor(biopyavtoriarian, new Vector2(1, 1), CursorMode.Auto);
            }
        }
        if (PolitDate.IsVersionF() == politicfreedom.democratian)
        {
            if (PolitDate.IsVersionE() == politiceconomic.right)
            {
                Cursor.SetCursor(rightdemocratian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.mind)
            {
                Cursor.SetCursor(minddemocratian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.left)
            {
                Cursor.SetCursor(leftdemocratian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.bipoly)
            {
                Cursor.SetCursor(biopydemocratian, new Vector2(1, 1), CursorMode.Auto);
            }
        }
        if (PolitDate.IsVersionF() == politicfreedom.lidertatian)
        {
            if (PolitDate.IsVersionE() == politiceconomic.right)
            {
                Cursor.SetCursor(rightlidertatian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.mind)
            {
                Cursor.SetCursor(mindlidertatian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.left)
            {
                Cursor.SetCursor(leftlidertatian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.bipoly)
            {
                Cursor.SetCursor(biopylidertatian, new Vector2(1, 1), CursorMode.Auto);
            }
        }
        if (PolitDate.IsVersionF() == politicfreedom.NonPositionalian)
        {
            if (PolitDate.IsVersionE() == politiceconomic.right)
            {
                Cursor.SetCursor(rightnonpositionalian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.mind)
            {
                Cursor.SetCursor(mindnonpositionalian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.left)
            {
                Cursor.SetCursor(leftnonpositionalian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.bipoly)
            {
                Cursor.SetCursor(biopynonpositionalian, new Vector2(1, 1), CursorMode.Auto);
            }
        }
    }
}
