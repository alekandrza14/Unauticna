using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PepoleTerritory : MonoBehaviour
{
    public int pepole;
    public List<GameObject> homes = new List<GameObject>();
    public List<GameObject> names = new List<GameObject>();
    public MultyObject selfWPosition;
    float timer;
    bool detecting;
    bool detected;
    public bool IsTaking;
    string TakingSpace;
    public AnimationCurve detect4D;
    private void Start()
    {
        TakingSpace = Map_saver.total_lif + SceneManager.GetActiveScene().buildIndex;
        IsTaking = VarSave.GetFloat(TakingSpace + "TakingVin") == 2;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Logic_tag_home>())
        {
            if (!homes.Contains(other.gameObject)) homes.Add(other.gameObject);
        }
        if (other.GetComponent<CharacterName>())
        {
            if (!names.Contains(other.gameObject)) names.Add(other.gameObject);
        }
    }
    private void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if(hit.collider.gameObject == gameObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                detecting = true;
            }
        }
        if (detecting)
        {
            timer += Time.deltaTime/2;
            mover.main().W_position = selfWPosition.W_Position + detect4D.Evaluate(timer);
            if (timer >= 6)
            {
                timer = 0; detecting = false;
                detected = true;
               
            }
        }
        if (detected)
        {
            int lifepepole = names.Count;
            if (names.Count>homes.Count)
            {
                lifepepole = homes.Count;
            }
            pepole = lifepepole;
            if (IsTaking)
            {
                int workDetails = 0;

                VarSave.LoadInt("pepole", pepole- VarSave.GetInt("homes" + transform.position.x + transform.position.y + transform.position.z + workDetails + TakingSpace));
                VarSave.SetInt("homes" + transform.position.x + transform.position.y + transform.position.z + workDetails + TakingSpace, pepole);
                detected = false;
            }
        }
    }
}
