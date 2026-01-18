using UnityEngine;
using UnityEngine.UI;

public class EvoCards : MonoBehaviour
{
    public Texture[] CardTexture;
    public RawImage CardImage;
    public string Var = "≈‰‡";
    void Start()
    {
        if (VarSave.GetInt(Var) == 0)
        {
            CardImage.texture = CardTexture[4];
        }
        if (VarSave.GetInt(Var) == 1)
        {
            CardImage.texture = CardTexture[0];
        }
        if (VarSave.GetInt(Var) == 2)
        {
            CardImage.texture = CardTexture[1];
        }
        if (VarSave.GetInt(Var) == 3)
        {
            CardImage.texture = CardTexture[2];
        }
    }
}
