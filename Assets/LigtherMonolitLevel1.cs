using UnityEngine;

public class LigtherMonolitLevel1 : MonoBehaviour
{
    public static LigtherMonolitLevel1 mon;
    public static bool Find()
    {
        if (!mon)
        {
            mon = FindAnyObjectByType<LigtherMonolitLevel1>();
            return mon != null;
        }
        return mon != null;
    }
}
public class lml1 : MonoBehaviour
{
    public static LigtherMonolitLevel1 mon;
    public static bool Find()
    {
        if (!mon)
        {
            mon = FindAnyObjectByType<LigtherMonolitLevel1>();
            return mon != null;
        }
        return mon != null;
    }
}
