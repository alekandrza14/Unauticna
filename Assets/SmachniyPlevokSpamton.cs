using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmachniyPlevokSpamton : MonoBehaviour
{
    Vector3 v3;
    mover m;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        m = mover.main();
        if (!PolitDate.IsGood(politicfreedom.avtoritatian))
        {
            Instantiate(Resources.Load<GameObject>("events/ѕлевок—памтона"));
            VarSave.SetInt("eventPlevraSpamtona", 1, SaveType.global);
        }
        //ѕлевок—памтона
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && FindObjectsByType<—мачныйѕлевок—памтона>(sortmode.main).Length > 0)
        {
            itemName[] items = FindObjectsByType<itemName>(sortmode.main);
            —мачныйѕлевок—памтона[] спс = FindObjectsByType<—мачныйѕлевок—памтона>(sortmode.main);

            foreach (—мачныйѕлевок—памтона пс in спс)
            {
                
                   пс.gameObject.AddComponent<DELETE>();
             
            }
            foreach (itemName item in items)
            {
                if (item._Name == "—мачный_плевок_—памтона")
                {
                    item.gameObject.AddComponent<DELETE>();
                }
            }
            VarSave.DeleteKey("eventPlevraSpamtona", SaveType.global);
        }
    }

    // Update is called once per frame
    void Update()
    {
        v3 = transform.position - m.transform.position;
        transform.position += -v3 / (1f/ speed);
    }
}
