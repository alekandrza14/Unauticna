using UnityEngine;

public class PhysicsAPI
{
    public bool Raycast(Vector3 pos,
                        Vector3 dir,
                        float dist)
    {
        return Physics.Raycast(pos,dir,dist);
    }
}