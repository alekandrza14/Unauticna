using UnityEngine;

public enum offsetpos
{
    centerworld,player,customcenterworld
}
public class SpawnButton : MonoBehaviour
{
    public Vector3 pos;
    public offsetpos off;
    public string resobj;
    public void Spawn()
    {
        if (off == offsetpos.centerworld)
        {
            Instantiate(Resources.Load<GameObject>(resobj), pos, Quaternion.identity);
        }
        if (off == offsetpos.player)
        {
            Instantiate(Resources.Load<GameObject>(resobj), pos + mover.main().transform.position, Quaternion.identity);
        }
        if (off == offsetpos.customcenterworld)
        {
            Instantiate(Resources.Load<GameObject>(resobj), pos + Globalprefs.customcenter, Quaternion.identity);
        }

    } 
}
