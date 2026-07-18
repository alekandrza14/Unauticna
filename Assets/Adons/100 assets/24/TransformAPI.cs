using UnityEngine;
public class TransformAPI
{
    public void Translate(Transform t, Vector3 delta)
    {
        t.position += delta;
    }

    public void Rotate(Transform t, Vector3 rot)
    {
        t.Rotate(rot);
    }

    public void SetPosition(Transform t, Vector3 pos)
    {
        t.position = pos;
    }
}