using UnityEngine;

public class MineCart : MonoBehaviour
{
    public mod reso;
    void Start()
    {
        reso = GetComponent<mod>();
    }
    void Update()
    {
        reso.Parent.transform.position += new Vector3(0,0,20*Time.deltaTime);
    }
}
