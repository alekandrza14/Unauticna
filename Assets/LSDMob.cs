using UnityEngine;

public class LSDMob : MonoBehaviour
{
    void Update()
    {
        transform.position += Global.math.randomCube(-1, 2)/10;
    }
}
