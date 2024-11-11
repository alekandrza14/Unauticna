using UnityEngine;

public class TestingCompleteingQuest : MonoBehaviour
{
    public GameObject salut;
    public void OnInteractive()
    {
        EnemyeFashist[] fashists = objFind.ArrayByType<EnemyeFashist>();
        if (fashists.Length == 0)
        {
            salut.SetActive(true);
            VarSave.SetInt("Служба выполнена!",1);
        }
    }
}
