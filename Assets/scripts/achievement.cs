using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achievement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //"���� ���������"
        if (VarSave.GetBool("���� ���������"))
        {
            GetComponent<Text>().text = "�� ������ �� ���� ��������� ��������";
            VarSave.SetBool("���� ���������", false);
        }
        if (VarSave.GetBool("oxygen"))
        {
            GetComponent<Text>().text = "�� ������������";
            VarSave.SetBool("oxygen", false);
        }
        if (VarSave.GetBool("������� ����� � �������"))
        {
            GetComponent<Text>().text = "�� ���� ������ 4� ����������";
            VarSave.SetBool("������� ����� � �������", false);
        }
        if (VarSave.GetBool("������������ � 2006 ���������"))
        {
            GetComponent<Text>().text = "������������ � 2006 ���������";
            VarSave.SetBool("������������ � 2006 ���������", false);
        }
        if (VarSave.GetBool("�������������� ������� �������"))
        {
            GetComponent<Text>().text = "���������� �� ������ �� : �������������� �������(����)";
            VarSave.SetBool("�������������� ������� �������", false);
        }
        if (VarSave.GetBool("������ �� ���"))
        {
            GetComponent<Text>().text = "������ �� ��� ����������";
            VarSave.SetBool("������ �� ���", false);
        }
        if (VarSave.GetBool("������ �������"))
        {
            GetComponent<Text>().text = "������ ����� ����";
            VarSave.SetBool("������ �������", false);
        }
        if (VarSave.GetBool("������� �������� ��� ����� ������ ����� ���"))
        {
            GetComponent<Text>().text = "���������� �� ������ �� : djevil ��������� ���� ����� ������";
            VarSave.SetBool("������� �������� ��� ����� ������ ����� ���", false);
        }
        if (VarSave.GetBool("��������� �������"))
        {
            GetComponent<Text>().text = "���������� �� ������ �� : ����������";
            VarSave.SetBool("��������� �������", false);
        }
        if (VarSave.GetBool("��������� ��� �������"))
        {
            GetComponent<Text>().text = "���������� �� ������ �� : ���������� ����";
            VarSave.SetBool("��������� ��� �������", false);
        }
        if (VarSave.GetBool("�������� � �� ������� � ��������"))
        {
            GetComponent<Text>().text = "���������� �� ������ �� : ����";
            VarSave.SetBool("�������� � �� ������� � ��������", false);
        }
        if (VarSave.GetBool("��������� ����� � �� ������� � ��������"))
        {
            GetComponent<Text>().text = "���������� �� ������ �� : �������";
            VarSave.SetBool("��������� ����� � �� ������� � ��������", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
