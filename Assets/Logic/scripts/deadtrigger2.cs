using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadtrigger2 : MonoBehaviour
{
    public bool tesserakt;
    public bool zellotton;

  
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true); if (!tesserakt&&!zellotton)
            {


                VarSave.SetBool("��������� ����� � �� ������� � ��������", true);
            }

            if (tesserakt)
            {


                VarSave.SetBool("������� ����� � �������", true);
            }
            if (zellotton)
            {


                VarSave.SetBool("���� ���������", true);
            }

          


                GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);
          
        }
    }
}
