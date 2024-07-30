using UnityEngine;

public class LigtherMonolitLevel2 : MonoBehaviour
{
    public static LigtherMonolitLevel2 mon;
    public static bool Find()
    {
        if (!mon)
        {
            mon = FindAnyObjectByType<LigtherMonolitLevel2>();
            return mon != null;
        }
        return mon != null;
    }
}
public class lml2 : MonoBehaviour
{
    public static LigtherMonolitLevel2 mon;
    public static bool Find()
    {
        if (!mon)
        {
            mon = FindAnyObjectByType<LigtherMonolitLevel2>();
            return mon != null;
        }
        return mon != null;
    }
}

