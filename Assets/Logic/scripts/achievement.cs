using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class achievement : MonoBehaviour
{
    IEnumerator Reincarnation()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameReink");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (VarSave.GetFloat(
         "�����" + "_gameSettings", SaveType.global) >= 0.2f)
        {
            VarSave.SetBool("lol you Banned", true);
            SceneManager.LoadSceneAsync("Banned forever");
        }
        if (GameEditor.Opened.startSurvival)
        {
            VarSave.SetString("GameActive", "");
            GameEditor.Opened = null;

            VarSave.SetInt("MapUse", 0);
            VarSave.SetString("CurrentSpace", "");
            SceneManager.LoadSceneAsync(1);
        }
        if (VarSave.GetFloat(
          "reynkarnatcia" + "_gameSettings", SaveType.global) >= .5f)
        {
            StartCoroutine(Reincarnation());
        }
        Globalprefs.LoadTevroPrise(-100);
        //������� ���� �������
        //"����� ���� ����"
        if (VarSave.GetBool("����� ���� ����"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "�� ������ �� ����� �� ��������� � ����� ��������";
            VarSave.SetBool("����� ���� ����", false);
        }
        if (VarSave.GetBool("���������� ���������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "�� ����� �� �� ������! ������� ������� ������!";
            VarSave.SetBool("���������� ���������", false);
        }
        if (VarSave.GetBool("������ �������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "������ ���� �� �������";
            VarSave.SetBool("������ �������", false);
        }
        //�����
        if (VarSave.GetBool("�����"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "�������(��) ����������";
            VarSave.SetBool("�����", false);
        }
        if (VarSave.GetBool("����� �������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "��� ��������� �������";
            VarSave.SetBool("����� �������", false);
        }
        if (VarSave.GetBool("������� ���� �������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "�������(��) ��� ������������ ���� ��������";
            VarSave.SetBool("������� ���� �������", false);
        }
        if (VarSave.GetBool("���� ���������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "�� ������ �� ���� ��������� �������� ��������";
            VarSave.SetBool("���� ���������", false);
        }
        if (VarSave.GetBool("�������� ���� �������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "���� ��� ������";
            VarSave.SetBool("�������� ���� �������", false);
        }
        if (VarSave.GetBool("oxygen"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "�� ������������";
            VarSave.SetBool("oxygen", false);
        }
        if (VarSave.GetBool("������� ����� � �������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "�� ���� ������ 4� ����������";
            VarSave.SetBool("������� ����� � �������", false);
        }
        if (VarSave.GetBool("������������ � 2006 ���������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "������������ � 2006 ���������";
            VarSave.SetBool("������������ � 2006 ���������", false);
        }
        if (VarSave.GetBool("�������������� ������� �������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "���������� �� ������ �� : �������������� �������(����)";
            VarSave.SetBool("�������������� ������� �������", false);
        }
        if (VarSave.GetBool("������ �� ���"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "������ �� ���������� �����";
            VarSave.SetBool("������ �� ���", false);
        }
        if (VarSave.GetBool("������ �������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "������ ����� ����";
            VarSave.SetBool("������ �������", false);
        }
        if (VarSave.GetBool("������� �������� ��� ����� ������ ����� ���"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "���������� �� ������ �� : djevil ��������� ���� ����� ������";
            VarSave.SetBool("������� �������� ��� ����� ������ ����� ���", false);
        }
        if (VarSave.GetBool("��������� �������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "���������� �� ������ �� : ����������";
            VarSave.SetBool("��������� �������", false);
        }
        if (VarSave.GetBool("���������� ��� �������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "���������� �� ������ �� : ���������� ����";
            VarSave.SetBool("��������� ��� �������", false);
        }
        if (VarSave.GetBool("�������� � �� ������� � ��������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "���������� �� ������ �������� � �������";
            VarSave.SetBool("�������� � �� ������� � ��������", false);
        }
        if (VarSave.GetBool("��������� ����� � �� ������� � ��������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "���������� �� ������ �� : �������";
            VarSave.SetBool("��������� ����� � �� ������� � ��������", false);
        }
        //�������� ���������� ������� �����
        if (VarSave.GetBool("�������� ���������� ������� �����"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "�������(��) ��� �������� ���������� ������� �����";
            VarSave.SetBool("�������� ���������� ������� �����", false);
        }
        //"����������� � ���� �������"
        if (VarSave.GetBool("����������� � ���� �������"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "�������(��) ��� ������������ ���� ��������";
            VarSave.SetBool("����������� � ���� �������", false);
        }
    }

}
