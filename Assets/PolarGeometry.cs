using UnityEngine;
[ExecuteAlways]
public class PolarGeometry : MonoBehaviour
{
    
    public Vector2 polarPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        polarPosition.x += Input.GetAxis("Horizontal") * 0.1f;
        polarPosition.y += Input.GetAxis("Vertical");
        mover.main().transform.position = new Vector3(Mathf.Sin(polarPosition.x) * polarPosition.y, mover.main().transform.position.y, Mathf.Cos(polarPosition.x) * polarPosition.y);
    }
}
