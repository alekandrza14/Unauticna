using UnityEngine;
public enum ProceAnim
{
    Fead,Lah
}

public class ProcedurAnimation : MonoBehaviour
{

    
    public GameObject DebugPoint;
    public GameObject ColLeg;
    public GameObject LahLeg;
    public GameObject RayPoint;
    public GameObject FeetLeg;
    public Vector3 Gravity;
    public Vector3[] Shag;
    public AnimationCurve Liner;
    public ProceAnim TypeAnim;
    public Nerv nerv;
    public float distLeg;
    public float speed;
    float timer;
    static int t;
    int cur;
    private void Start()
    {
        
    }

    void Update()
    {
        if (TypeAnim == ProceAnim.Fead)
        {


            timer += Time.deltaTime*speed;
            
            if (timer > 1)
            {
                cur++; 
               // cur %= Shag.Length;
                timer = 0;
            }
            FeetLeg.transform.position = DebugPoint.transform.position + (nerv.Brain.transform.right * Vector3.Slerp(Shag[cur % (Shag.Length)], Shag[(cur + 1) % (Shag.Length)], Liner.Evaluate(timer)).x) + (nerv.Brain.transform.up * Vector3.Slerp(Shag[cur % (Shag.Length)], Shag[(cur + 1) % (Shag.Length)], Liner.Evaluate(timer)).y) + (nerv.Brain.transform.forward * Vector3.Slerp(Shag[cur % (Shag.Length)], Shag[(cur + 1) % (Shag.Length)], Liner.Evaluate(timer)).z);
            Ray ray = new Ray(RayPoint.transform.position, Gravity);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.distance < distLeg)
                {
                    DebugPoint.transform.position = hit.point;
                }
                else
                {
                    DebugPoint.transform.position = RayPoint.transform.position + (Gravity * distLeg);
                }
            }
        }
        if (TypeAnim == ProceAnim.Lah)
        {
            LahLeg.transform.rotation = Quaternion.LookRotation(LahLeg.transform.position - ColLeg.transform.position,Vector3.up);
            LahLeg.transform.localScale = new Vector3(LahLeg.transform.localScale.x, LahLeg.transform.localScale.y, Vector3.Distance(LahLeg.transform.position, ColLeg.transform.position)*2);
            LahLeg.transform.position = Vector3.Lerp(ColLeg.transform.position, transform.position,0.5f);

        }

    }
}
