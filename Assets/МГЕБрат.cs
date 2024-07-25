using UnityEngine;
using UnityEngine.SceneManagement;

public class МГЕБрат : MonoBehaviour
{
    mover m;
    // Start is called before the first frame update
    void Start()
    {
        Globalprefs.LoadTevroPrise(-10);
        m = mover.main();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(m.transform.position - transform.position, transform.up);
        transform.Translate(0, 0, 5f * Time.deltaTime);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Logic_tag_DamageObject>())
        {
            for (int i = 0; i < 20; i++) Instantiate(Resources.Load<GameObject>("items/FashistEnemye"), gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (col.gameObject.GetComponent<mover>())
        {
            SceneManager.LoadScene("МГЕ-ФАК");
        }
    }
}
