using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AruaMoment : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        if(VarSave.GetFloat("ChanceChaosCubeDeath" + "_gameSettings", SaveType.global)>50)  StartCoroutine(run());
    }


    IEnumerator run()
    {
        VarSave.SetMoney("tevro",0);
        Globalprefs.Infinitysteuvro = 0;
        VarSave.SetTrash("inftevro", Globalprefs.Infinitysteuvro);
        yield return new WaitForSeconds(1);
        VarSave.SetBool("cry", true);



        VarSave.SetBool("кража аруа урон", true);





        GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);
    }

}
