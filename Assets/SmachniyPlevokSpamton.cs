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
            Instantiate(Resources.Load<GameObject>("events/��������������"));
            VarSave.SetInt("eventPlevraSpamtona", 1, SaveType.global);
        }
        //��������������
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && FindObjectsByType<���������������������>(sortmode.main).Length > 0)
        {
            itemName[] items = FindObjectsByType<itemName>(sortmode.main);
            ���������������������[] ��� = FindObjectsByType<���������������������>(sortmode.main);

            foreach (��������������������� �� in ���)
            {
                
                   ��.gameObject.AddComponent<DELETE>();
             
            }
            foreach (itemName item in items)
            {
                if (item._Name == "�������_������_��������")
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
