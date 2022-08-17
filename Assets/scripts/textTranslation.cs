using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textTranslation : MonoBehaviour
{
    Text txt;
    public string translation_eng;
    public string translation_rus;
    public string translation_uné;
    public void trans()
    {
        switch (VarSave.GetString("lenguage_english"))
        {
            case "True":
                txt.text = translation_eng;
                break;
            case "False":
                txt.text = translation_rus;
                break;
            case "none":
                txt.text = translation_uné;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        trans();
    }

    // Update is called once per frame
    void Update()
    {
        trans();
    }
}
