using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achievement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //"убит фанатиком"
        if (VarSave.GetBool("убит фанатиком"))
        {
            GetComponent<Text>().text = "вы сдохли от гота сатаниста фанатона";
            VarSave.SetBool("убит фанатиком", false);
        }
        if (VarSave.GetBool("oxygen"))
        {
            GetComponent<Text>().text = "вы захлебнулись";
            VarSave.SetBool("oxygen", false);
        }
        if (VarSave.GetBool("нравикс попал в ловушку"))
        {
            GetComponent<Text>().text = "вы были седены 4м измерением";
            VarSave.SetBool("нравикс попал в ловушку", false);
        }
        if (VarSave.GetBool("прникаснулт€ к 2006 елеменнту"))
        {
            GetComponent<Text>().text = "прникаснулт€ к 2006 елеменнту";
            VarSave.SetBool("прникаснулт€ к 2006 елеменнту", false);
        }
        if (VarSave.GetBool("терратскичикий корабль победил"))
        {
            GetComponent<Text>().text = "поздравл€ю вы сдохли от : терратскичик€€ корабл€(босс)";
            VarSave.SetBool("терратскичикий корабль победил", false);
        }
        if (VarSave.GetBool("умерли от ран"))
        {
            GetComponent<Text>().text = "умерли от ран мучительно";
            VarSave.SetBool("умерли от ран", false);
        }
        if (VarSave.GetBool("„≈–¬яЎ победил"))
        {
            GetComponent<Text>().text = "черв€ш круче теб€";
            VarSave.SetBool("„≈–¬яЎ победил", false);
        }
        if (VarSave.GetBool("обычный сельский бог гипер смерти урбил вас"))
        {
            GetComponent<Text>().text = "поздравл€ю вы сдохли от : djevil сельского бога гипер смерти";
            VarSave.SetBool("обычный сельский бог гипер смерти урбил вас", false);
        }
        if (VarSave.GetBool("призедент победил"))
        {
            GetComponent<Text>().text = "поздравл€ю вы сдохли от : призедента";
            VarSave.SetBool("призедент победил", false);
        }
        if (VarSave.GetBool("подездный маг победил"))
        {
            GetComponent<Text>().text = "поздравл€ю вы сдохли от : подездного мага";
            VarSave.SetBool("подездный маг победил", false);
        }
        if (VarSave.GetBool("отравлен и от правлен в больницу"))
        {
            GetComponent<Text>().text = "поздравл€ю вы сдохли от : дыма";
            VarSave.SetBool("отравлен и от правлен в больницу", false);
        }
        if (VarSave.GetBool("переломал кости и от правлен в больницу"))
        {
            GetComponent<Text>().text = "поздравл€ю вы сдохли от : подени€";
            VarSave.SetBool("переломал кости и от правлен в больницу", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
