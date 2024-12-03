using UnityEngine;
using UnityEngine.UI;

public class CazinoBilet : InventoryEvent
{ 
    public int Vigrish;
    public Text text;
    private void Start()
    {
    Vigrish = int.Parse(GetComponent<itemName>().ItemData);

        if (string.IsNullOrEmpty(Vigrish.ToString()))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                GetComponent<itemName>().ItemData = Vigrish.ToString();
            }
        }

    }
    public void Load1()
    {
    Vigrish = int.Parse(GetComponent<itemName>().ItemData);

        if (string.IsNullOrEmpty(Vigrish.ToString()))
        {

            // time = JsonUtility.ToJson(Random.ColorHSV());
            GetComponent<itemName>().ItemData = Vigrish.ToString();


        }
    }
    public void OnInteractive()
    {
        if (Vigrish == 0)
        {
            Vigrish -= 1;
            if (Random.Range(0, 3) > 1 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 100);
            }
            if (Random.Range(0, 5) > 4 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 500;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 50);
            }
            if (Random.Range(0, 32) > 31 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 1000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 10);
            }
            if (Random.Range(0, 301) > 300 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) * 100);
            }
            if (Random.Range(0, 3) > 1 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 100);
            }
            if (Random.Range(0, 5) > 4 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 500;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 50);
            }
            if (Random.Range(0, 32) > 31 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 1000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 10);
            }
            if (Random.Range(0, 301) > 300 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) * 100);
            }
            if (Random.Range(0, 3) > 1 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 100);
            }
            if (Random.Range(0, 5) > 4 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 500;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 50);
            }
            if (Random.Range(0, 32) > 31 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 1000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 10);
            }
            if (Random.Range(0, 301) > 300 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) * 100);
            }
            if (Random.Range(0, 3) > 1 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 100);
            }
            if (Random.Range(0, 5) > 4 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 500;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 50);
            }
            if (Random.Range(0, 32) > 31 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 1000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 10);
            }
            if (Random.Range(0, 301) > 300 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) * 100);
            }
            if (Random.Range(0, 3) > 1 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 100);
            }
            if (Random.Range(0, 5) > 4 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 500;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 50);
            }
            if (Random.Range(0, 32) > 31 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 1000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 10);
            }
            if (Random.Range(0, 301) > 300 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) * 100);
            }
            if (Random.Range(0, 3) > 1 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 100);
            }
            if (Random.Range(0, 5) > 4 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 500;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 50);
            }
            if (Random.Range(0, 32) > 31 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 1000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) / 10);
            }
            if (Random.Range(0, 301) > 300 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 100000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) * 100);
            }
            if (Random.Range(0, 3001) > 3000 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 10000000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) * 10000);
            }
            if (Random.Range(0, 3001) > 3000 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 10000000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) * 10000);
            }
            if (Random.Range(0, 3001) > 3000 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 10000000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) * 10000);
            }
            if (Random.Range(0, 3001) > 3000 - VarSave.LoadFloat("luck", 0))
            {
                Vigrish += 10000000;
                VarSave.LoadFloat("luck", VarSave.LoadFloat("luck", 0) * 10000);
            }
            if (VarSave.GetFloat("SevenSouls") > 0)
            {
                Vigrish += 1000000;
            }
            Globalprefs.LoadTevroPrise(Vigrish);
            GetComponent<itemName>().ItemData = Vigrish.ToString();
        }
    }
    private void Update()
    {
        text.text = "ֲûידנûר : " + (Vigrish==0?"??" : Vigrish);
    }
}
