using UnityEngine;

public class COModule : MonoBehaviour
{
    public WorldSide[] sides;
    public Texture2D[] tex;
    public void sesStart()
    {
        for (int i = 0; i < sides.Length; i++)
        {
            WorldSide side = sides[i];
            Texture2D text = tex[i];
            side.sprite = text;
        }
    }
}
