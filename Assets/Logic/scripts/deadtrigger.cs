using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadtrigger : MonoBehaviour
{
    public bool chervyash;
    public bool terratist;
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true); if (!chervyash && !terratist)
            {


                VarSave.SetBool("��������� ����� � �� ������� � ��������", true);
            }
            if (chervyash)
            {


                VarSave.SetBool("������ �������", true);
            }
            if (terratist)
            {


                VarSave.SetBool("�������������� ������� �������", true);
            }

          


                GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}
