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
         "Конец" + "_gameSettings", SaveType.global) >= 0.2f)
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
        //Касание анти материи
        //"кража аруа урон"
        if (VarSave.GetBool("кража аруа урон"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "Вы мертвы от урона от воровства с вашей карточки";
            VarSave.SetBool("кража аруа урон", false);
        }
        if (VarSave.GetBool("Пристрелен Спамтоном"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "Вы сдоли вы не крутой! Снайпер спамтон крутой!";
            VarSave.SetBool("Пристрелен Спамтоном", false);
        }
        if (VarSave.GetBool("Фашист победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "Словил пулю от фашиста";
            VarSave.SetBool("Фашист победил", false);
        }
        //Взрыв
        if (VarSave.GetBool("Взрыв"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "Нравикс(вы) подорвался";
            VarSave.SetBool("Взрыв", false);
        }
        if (VarSave.GetBool("Пират победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "Был обокраден пиратом";
            VarSave.SetBool("Пират победил", false);
        }
        if (VarSave.GetBool("Касание анти материи"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "нравикс(вы) был анигилирован анти материей";
            VarSave.SetBool("Касание анти материи", false);
        }
        if (VarSave.GetBool("убит фанатиком"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "вы сдохли от гота сатаниста фанатика фанатона";
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
        if (VarSave.GetBool("прникаснултя к 2006 елеменнту"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "прникаснултя к 2006 елеменнту";
            VarSave.SetBool("прникаснултя к 2006 елеменнту", false);
        }
        if (VarSave.GetBool("терратскичикий корабль победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравляю вы сдохли от : терратскичикяя корабля(босс)";
            VarSave.SetBool("терратскичикий корабль победил", false);
        }
        if (VarSave.GetBool("умерли от ран"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "умерли от переибытка урона";
            VarSave.SetBool("умерли от ран", false);
        }
        if (VarSave.GetBool("ЧЕРВЯШ победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "червяш круче тебя";
            VarSave.SetBool("ЧЕРВЯШ победил", false);
        }
        if (VarSave.GetBool("обычный сельский бог гипер смерти урбил вас"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравляю вы сдохли от : djevil сельского бога гипер смерти";
            VarSave.SetBool("обычный сельский бог гипер смерти урбил вас", false);
        }
        if (VarSave.GetBool("призедент победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравляю вы сдохли от : призедента";
            VarSave.SetBool("призедент победил", false);
        }
        if (VarSave.GetBool("подъездный маг победил"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравляю вы сдохли от : подездного мага";
            VarSave.SetBool("подездный маг победил", false);
        }
        if (VarSave.GetBool("отравлен и от правлен в больницу"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравляю вы сдохли находясь в космосе";
            VarSave.SetBool("отравлен и от правлен в больницу", false);
        }
        if (VarSave.GetBool("переломал кости и от правлен в больницу"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "поздравляю вы сдохли от : подения";
            VarSave.SetBool("переломал кости и от правлен в больницу", false);
        }
        //подавлен запрещёным уровнем удачи
        if (VarSave.GetBool("подавлен запрещёным уровнем удачи"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "нравикс(вы) был подавлен запрещёным уровнем удачи";
            VarSave.SetBool("подавлен запрещёным уровнем удачи", false);
        }
        //"прикоснулся к анти материи"
        if (VarSave.GetBool("прикоснулся к анти материи"))
        {
            hello.windowmesenge.Dialog_die();
            GetComponent<Text>().text = "нравикс(вы) был анигилирован анти материей";
            VarSave.SetBool("прикоснулся к анти материи", false);
        }
    }

}
