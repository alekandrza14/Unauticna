using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camera4D : MonoBehaviour
{
    
    public RawImage ri;
    public transform4d target;
    
     public int speed;
     public GameObject pref4d;
     public GameObject pref4d1;
     public GameObject pref4d2;
    public GameObject pref4d3;
    public GameObject loadpref1;
    public GameObject r;
     public GameObject r1;
    GameObject[] g;
     List<float> debugp4 = new List<float>();
    // Start is called before the first frame update

    private void Awake()
    {
        target.t = transform;
        g = new GameObject[5]{
pref4d.gameObject,
pref4d1.gameObject,
pref4d2.gameObject,
pref4d3.gameObject,
loadpref1.gameObject};
        Uxill_Engine.Load(target, g, true);
    }


    void Start()
    {
        target.t = transform;
        g = new GameObject[5]{
pref4d.gameObject,
pref4d1.gameObject,
pref4d2.gameObject,
pref4d3.gameObject,
loadpref1.gameObject};
        
        Uxill_Engine.Start(target, g);
        
        
    }
    
   
    
    
    // Update is called once per frame
    void Update()
    {
        
        g = new GameObject[5]{
pref4d.gameObject,
pref4d1.gameObject,
pref4d2.gameObject,
pref4d3.gameObject,
loadpref1.gameObject}; 
            Uxill_Engine.Load(target, g, false);
        
            Uxill_Engine.Update(target, g);
            debugp4 = Uxill_Engine.render(target, ri);


            r.transform.rotation = target.i;
            transform.position = new Vector3(0, 0, target.posistion.w);
            float i = speed * Time.deltaTime;
        
            if (Input.GetKey(KeyCode.W))
            {
                Uxill_Engine.Transform4Dforward(target, new Vector4(0, 0, i, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                Uxill_Engine.Transform4Dforward(target, new Vector4(0, 0, -i, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                Uxill_Engine.Transform4Dforward(target, new Vector4(i, 0, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                Uxill_Engine.Transform4Dforward(target, new Vector4(-i, 0, 0, 0));
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Uxill_Engine.Transform4Dforward(target, new Vector4(0, -i, 0, 0));
            }
            if (Input.GetKey(KeyCode.Space))
            {
            target.posistion.y = musave.isplayer().position.y;
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                Uxill_Engine.Transform4Dforward(target, new Vector4(0, 0, 0, -i));
            }
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                Uxill_Engine.Transform4Dforward(target, new Vector4(0, 0, 0, i));
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Uxill_Engine.Transform4DRotate(target, Vector3.zero, new Vector3(0, Input.GetAxis("Mouse X"), 0) * 1.5f);
                Uxill_Engine.Transform4DRotate(target, Vector3.zero, new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * 1.5f);
            }
            else if (!Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse0))
            {
                Cursor.lockState = CursorLockMode.None;
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Uxill_Engine.Transform4DRotate(target, new Vector3(0, Input.GetAxis("Mouse X"), 0) * 1.5f, Vector3.zero);
                Uxill_Engine.Transform4DRotate(target, new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * 1.5f, Vector3.zero);
            }
            else if (!Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse0))
            {
                Cursor.lockState = CursorLockMode.None;
            }

            transform.position = new Vector3(0, 0, target.posistion.w);
        
    }
}
