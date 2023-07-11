using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class editorsave
{
    public Hyperbolic2D pos;

}
[ExecuteAlways]
public class load : MonoBehaviour
{

}
[ExecuteAlways]
[AddComponentMenu("Hyperbolic space/Hyperbolic Player Controler")]
public class HyperbolicCamera : MonoBehaviour
{
   [HideInInspector] public Vector3 position;

    [HideInInspector] public Hyperbolic2D polarTransform = new Hyperbolic2D(0, 0.01f, 0f);
    public Hyperbolic2D HyperbolicTransform = new Hyperbolic2D(0, 0.01f, 0f);
    [HideInInspector] public bool px;[HideInInspector] public bool py;[HideInInspector] public bool mx;[HideInInspector] public bool my;
    [HideInInspector] public BoxCollider c;
    [HideInInspector] public float startscale;
    [HideInInspector] public Quaternion rotation;
    [Header("=============")]
    [Header("Physics")]
    public Rigidbody rb;
    public float radiuscolider;
    [Header("=============")]
    [Header("Lighting")]
    public Light light1;

    [HideInInspector] public float x;

    private void Start()
    {
       if(!Application.isPlaying) polarTransform = HyperbolicTransform.copy();
    }
    private void OnDestroy()
    {

    }
    private void OnApplicationQuit()
    {

    }

    void OnCollisionEnter(Collision c)
    {

        if (c.collider.tag == "deadpol")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

            
    }

        // Start is called before the first frame update
    
    public static HyperbolicCamera Main()
    {
        
        
        return FindFirstObjectByType<HyperbolicCamera>();
    }
    private void LateUpdate()
    {
        if (!Application.isPlaying) polarTransform = HyperbolicTransform.copy();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
       if (Input.GetAxis("Vertical") > 0)
        {
            Ray r = new Ray(transform.position, new Vector3(0, 0.5f, 1));

            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.distance <= radiuscolider)
                {
                    polarTransform.preApplyTranslationZ(Time.deltaTime);
                }
            }
        }
        if (Input.GetAxis("Vertical") < 0)
        {


            Ray r2 = new Ray(transform.position, new Vector3(0, 0.5f, -1));

            RaycastHit hit2;
            if (Physics.Raycast(r2, out hit2))
            {
                if (hit2.distance <= radiuscolider)
                {
                    polarTransform.preApplyTranslationZ(-Time.deltaTime);
                }
            }
        }



        Ray r3 = new Ray(transform.position, new Vector3(1, 0.5f, 0));


        RaycastHit hit3;
        if (Physics.Raycast(r3, out hit3))
        {
            if (hit3.distance <= radiuscolider)
            {
                polarTransform.preApplyTranslationY(Time.deltaTime);
            }
        }

        Ray r4 = new Ray(transform.position, new Vector3(-1, 0.5f, 0));

        RaycastHit hit4;
        if (Physics.Raycast(r4, out hit4))
        {
            if (hit4.distance <= radiuscolider)
            {
                polarTransform.preApplyTranslationY(-Time.deltaTime);
            }
        }
       

    }
    public void edit()
    {
        transform.rotation = Quaternion.identity; transform.Rotate(0, 0, 0);
        transform.position = Vector3.zero + Vector3.up * transform.position.y;
    }


        // Update is called once per frame
   public void Update()
    {
        edit();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        for (int i = 0; i < GameObject.FindObjectsByType<Sphere>(sortmode.main).Length; i++)
        {
            GameObject.FindObjectsByType<Sphere>(sortmode.main)[i].Update();
        }

        //Vertical
        if (mover.main().GetViewFace() != faceView.fourd)
        {
            Vector3 v = Vector3.MoveTowards(Vector3.zero, new Vector3(-Input.GetAxis("Vertical") * Time.deltaTime, -Input.GetAxis("Horizontal") * Time.deltaTime), 2);

            polarTransform.preApplyTranslationZ(v.x);
            polarTransform.preApplyTranslationY(v.y);


            if (Input.GetKey(KeyCode.Mouse1))
            {



                float r1 = Input.GetAxis("Mouse X") * Time.deltaTime * 1.5f;
                polarTransform.preApplyRotation(r1);



            }
        }
    }
}
