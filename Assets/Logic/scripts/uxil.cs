using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uxil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision col)
    {

        bool e = !Input.GetKey(KeyCode.G) && !Input.GetKey(KeyCode.F);
        if (col.collider.tag == "Player" && e)
        {
            VarSave.SetBool("cry", true);
            VarSave.SetBool("������������ � 2006 ���������", true);
            Destroy(col.collider.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
