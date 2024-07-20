using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UMUITank : MonoBehaviour
{
    public Transform cell;
    public Transform player;
    public float speed = 1f;
    public bool sitplayer;
    public Slider slider;
    public Canvas canvas;
    public Animator anim;
    string TakingSpace;
    private void Start()
    {

        TakingSpace = Map_saver.total_lif + SceneManager.GetActiveScene().buildIndex;
    }

    public Vector3 feixedVelosity(Vector3 velosity,float maxvelosity)
    {
        velosity.x = Mathf.Clamp(velosity.x, -1f, 1f);
        velosity.y = Mathf.Clamp(velosity.y, -1f, 1f);
        velosity.z = Mathf.Clamp(velosity.z, -1f, 1f);
        return velosity;
    }

    void Update()
    {
        if (canvas)
        {


            canvas.enabled = sitplayer;
            speed = (slider.value * 400) + 1;

        }
        if (sitplayer)
        {
            Globalprefs.sit_player = player.gameObject;
            GetComponent<Rigidbody>().linearVelocity = feixedVelosity(GetComponent<Rigidbody>().linearVelocity, 2f * speed);
            player.position = cell.position;
            player.rotation = cell.rotation;
            if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A))
            {
                anim.SetFloat("move", 1);
            }
            else
            {
                anim.SetFloat("move", 0);
            }
            if (Input.GetKey(KeyCode.W))
            {


                GetComponent<Rigidbody>().linearVelocity += transform.forward * 2f * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {


                GetComponent<Rigidbody>().linearVelocity += -transform.forward * 2f * speed;
            }
            if (Input.GetKey(KeyCode.Space))
            {


                GetComponent<Rigidbody>().linearVelocity += transform.up * 2f * speed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {


                GetComponent<Rigidbody>().linearVelocity += -transform.up * 2f * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {


                GetComponent<Rigidbody>().linearVelocity += transform.right * 2f * speed;
            }
            if (Input.GetKey(KeyCode.A))
            {


                GetComponent<Rigidbody>().linearVelocity += -transform.right * 2f * speed;
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {

                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 5, 0));

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                VarSave.SetFloat(TakingSpace + "TakingVin", 2);

                GameObject g = Resources.Load<GameObject>("Items/Знамя");
                Instantiate(g, mover.main().transform.position, Quaternion.identity);
            }
        }
    }
}
