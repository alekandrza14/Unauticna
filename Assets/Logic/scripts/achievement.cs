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
        if (VarSave.GetBool("‘ашист победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "—ловил пулю от фашиста";
            VarSave.SetBool("‘ашист победил", false);
        }
        if (VarSave.GetBool("убит фанатиком"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "вы сдохли от гота сатаниста фанатона";
            VarSave.SetBool("убит фанатиком", false);
        }
        if (VarSave.GetBool("страшный паук победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поук вас поучил";
            VarSave.SetBool("страшный паук победил", false);
        }
        if (VarSave.GetBool("oxygen"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "вы захлебнулись";
            VarSave.SetBool("oxygen", false);
        }
        if (VarSave.GetBool("нравикс попал в ловушку"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "вы были седены 4м измерением";
            VarSave.SetBool("нравикс попал в ловушку", false);
        }
        if (VarSave.GetBool("прникаснулт€ к 2006 елеменнту"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "прникаснулт€ к 2006 елеменнту";
            VarSave.SetBool("прникаснулт€ к 2006 елеменнту", false);
        }
        if (VarSave.GetBool("терратскичикий корабль победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравл€ю вы сдохли от : терратскичик€€ корабл€(босс)";
            VarSave.SetBool("терратскичикий корабль победил", false);
        }
        if (VarSave.GetBool("умерли от ран"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "умерли от ран мучительно";
            VarSave.SetBool("умерли от ран", false);
        }
        if (VarSave.GetBool("„≈–¬яЎ победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "черв€ш круче теб€";
            VarSave.SetBool("„≈–¬яЎ победил", false);
        }
        if (VarSave.GetBool("обычный сельский бог гипер смерти урбил вас"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравл€ю вы сдохли от : djevil сельского бога гипер смерти";
            VarSave.SetBool("обычный сельский бог гипер смерти урбил вас", false);
        }
        if (VarSave.GetBool("призедент победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравл€ю вы сдохли от : призедента";
            VarSave.SetBool("призедент победил", false);
        }
        if (VarSave.GetBool("подъездный маг победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравл€ю вы сдохли от : подездного мага";
            VarSave.SetBool("подездный маг победил", false);
        }
        if (VarSave.GetBool("отравлен и от правлен в больницу"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравл€ю вы сдохли наход€сь в космосе";
            VarSave.SetBool("отравлен и от правлен в больницу", false);
        }
        if (VarSave.GetBool("переломал кости и от правлен в больницу"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравл€ю вы сдохли от : подени€";
            VarSave.SetBool("переломал кости и от правлен в больницу", false);
        }
        //"прикоснулс€ к анти материи"
        if (VarSave.GetBool("прикоснулс€ к анти материи"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "нравикс был анигилирован";
            VarSave.SetBool("прикоснулс€ к анти материи", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
