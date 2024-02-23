using dnSpyModer;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Universe_poetry_seed : MonoBehaviour
{
    string dr = "\"®✉§©☯☭?$£¢⓿❶❷❸❹❺❻❼❽❾❿⓫⓬⓭⓮⓯⓰⓱⓲⓳⓴\\r\\n⑴⑵⑶⑷⑸⑹⑺⑻⑼⑽⑾⑿⒀⒁⒂⒃⒄⒅⒆⒇\\r\\n①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳\\r\\nⒶⒷⒸⒹⒺⒻⒼⒽⒾⒿⓀⓁⓂⓃⓄⓅⓆⓇⓈⓉⓊⓋⓌⓍⓎⓏ\\r\\n⒈⒉⒊⒋⒌⒍⒎⒏⒐⒑⒒⒓⒔⒕⒖⒗⒘⒙⒚⒛\\r\\nⓐⓑⓒⓓⓔⓕⓖⓗⓘⓙⓚⓛⓜⓝⓞⓟⓠⓡⓢⓣⓤⓥⓦⓧⓨⓩ⓪\\r\\n⒜⒝⒞⒟⒠⒡⒢⒣⒤⒥⒦⒧⒨⒩⒪⒫⒬⒭⒮⒯⒰⒱⒲⒳⒴⒵◜◝◞◟◠◡\\r\\n◰◱◲◳◴◵◶◷\\r\\n▖▗▘▙▚▛▜▝▞▟■\\r\\n◸◹◺◻◼◽◾◿\\r\\n►▻▼▽▾▿◀◁◂▻\\r\\n□▢▣▪▫▬▭▮▯▰▱▤▥▦▧▨▩\\r\\n▲△▴▵▶▷▸▹►▻\\r\\n◢◣◤◥\\r\\n◆◇◈◉◊○◌◍◎\\r\\n●◐◑◒◓◔◕\\r\\n◧◨◩◪◫\\r\\n◖◗◘◙◚◛\\r\\n◦◬◭◮◯▁▂▃▄▅▆▇█\\r\\n▌▍▎▏▐\\r\\n▀▉▊▋\\r\\n─━│┃\\r\\n└┕┖┗┘┙┚┛\\r\\n┄┅┆┇┈┉┊┋\\r\\n░▒▓▔▕\\r\\n┌┍┎┏┐┑┒┓\\r\\n╭╮╯╰╱╲╳\\r\\n├┝┞┟┠┡┢┣┤┥┦┧┨┩┪┫\\r\\n╴╵╶╷╸╹╺╻╼╽╾╿\\r\\n┴┵┶┷┸┹┺┻\\r\\n┬┭┮┯┰┱┲┳\\r\\n┼┽┾┿╀╁╂╃╄╅╆╇╈╉╊╋\\r\\n╤╥╦╧╨╩╪╫╬\\r\\n╘╙╚╛╜╝\\r\\n╌╍╎╏═\\r\\n║╞╟╠╡╢╣\\r\\n╒╓╔╕╖╗⟨⟩⟪⟫⟰⟱\\r\\n❍❏❐❑❒\\r\\n✔✕✖✗✘\\r\\n☀☁☂☃🤘☄★💪\\r\\n☢☣☯☮☣☬☪\\r\\n☆☇☈☉☊☋☌☍\\r\\n☡☢☣☤☥☧☨☩☪\\r\\n☎☏☐☑☒\\r\\n⟦⟧⟲⟳⟴⟵\\r\\n➘➙➚➛➜➝➞➟➠➡\\r\\n☓☔☕☖☗☘☙\\r\\n\\r\\n☚☛☜☝☞☟☠☫☬\\r\\n✆✇✈✉✌✍✎✏✐✑\\r\\n➲➳➴➵➶➷➸\\r\\n☰☱☲☳☴☵☶☷\\r\\n☭☮☯♮♯♰♱\\r\\n➱➢➣➤➥➦➧➨➩➪➫➬➭➮➯➔\\r\\n❁❂❃❄❅❆❇❈❉❊❋\\r\\n✁✂✃✄✒✓☦\\r\\n✫✬✭✮✯✰\\r\\n✝✞✟✠✡✢✣✤✥\\r\\n✡〄♨☸⌘\\r\\n✱✲✳✴✵✶✷✸✹✺✻✼✽❀\\r\\n✙✚✛✾✿✜✦✧✩✪\\r\\n➹➺➻➼➽➾\\r\\n❖❡❢❣❤❥❦❧❘❙❚❛❜❝❞👌➿⟠⟡ⅰⅱⅲⅳⅴⅵⅶⅷⅸⅹⅺⅻⅼⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩⅪⅫⅬ♕♖♗♘♙♚♛♜♝♞♟♠\\r\\n♩♪♫♬♭♮♯\\r\\n♡♢♣♤♥♦♧ℂ℃℄℅℆ℇ℈℉ℊℋℌℍℎℏℐℑℒℓ℔ℕ℗℘ℙℚℛℜℝ℞℟℠℡™℣ℤ℥Ω℧ℨ℩KÅ№ℬℭ℮ℯℰℱℲℳℴ⅓⅔⅕⅖⅗⅘⅙⅚⅛⅜⅝⅞⅟ℵℶℷℸℹ℺℻ℽℾℿ⅀⅁⅂⅃⅄ⅅⅆⅇⅈⅉ⅊⅋⅍ⅎⅭⅮⅯ∀∁∂∃∄∅∆∇∈∉∊∋∌∍∎∏∐∑−∓∔∕∖∗∘∙√∛∜∝∞∟∠∡∢∣∤∥∦∧∨∩∪∫∬∭∮∯∰∱∲∳∴∵∶∷∸∹∺∻∼∽∾∿≀≁≂≃≄≅≆≇≈≉≊≋≌≍≎≏≐≑≒≓≔≕≖≗≘≙≚≛≜≝≞≟≠≡≢≣≤≥≦≧≨≩≪≫≬≭≮≯≰≱≲≳≴≵≶≷≸≹≺≻≼≽≾≿⊀⊁⊂⊃⊄⊅⊆⊇⊈⊉⊊⊋⊌⊍⊎⋐⋑⋒⋓⋔⋕⋖⋗⋘⋙⋚⋛⋜⋝⋞⋟⋠⋡⋢⋣⋤⋥⋦⋧⋨⋩⋪⋫⋬⋭⋮⋯⋰⋱⋲⋳⋴⋵⋶⋷⋸⋹⋺⋻⋼⋽⋾⋿⌀ᴀᴁᴂᴃᴄᴅᴆᴇᴈᴉᴊᴋᴌᴍᴎᴏᴐᴑᴒᴓᴔᴕᴖᴗᴘᴙᴚᴛᴜᴝᴞᴟᴠᴡᴢᴣᴤᴥᴦᴧᴨᴩᴪᴫᴬᴭᴮᴯᴰᴱᴲᴳᴴᴵᴶᴷᴸᴹᴺᴻᴼᴽᴾᴿᵀᵁᵂᵃᵄᵅᵆᵇᵈᵉᵊᵋᵌᵍᵎᵏᵐᵑᵒᵓᵔᵕᵖᵗᵘᵙᵚᵛᵜᵝᵞᵟᵠᵡᵢᵣᵤᵥᵦᵧᵨᵩᵪᵫᵬᵭᵮᵯᵰᵱᵲᵳᵴᵵᵶᵷᵸᵹᵺᵻᵼᵽᵾᵿᶀᶁᶂᶃᶄᶅᶆᶇᶈᶉᶊᶋᶌᶍᶎᶏᶐᶑᶒᶓᶔᶕᶖᶗᶘᶙᶚᶛᶜᶝᶞᶟᶠᶡᶢᶣᶤᶥᶦᶧᶨᶩᶪᶫᶬᶭᶮᶯᶰᶱᶲᶳᶴᶵᶶᶷᶸᶹᶺᶻᶼᶽᶾᶿῲῳῴῶῷῸΌῺΏῼ⍳⍴⍵⍶⍷⍸⍹⍺←↑→↓↔↕↖↗↘↙↚↛↜↝↞↟↠↡↢↣↤↥↦↧↨↩↪↫↬↭↮↯↰↱↲↳↴↵↶↷↸↹↺↻↼↽↾↿⇀⇁⇂⇃⇄⇅⇆⇇⇈⇉⇊⇋⇌⇍⇎⇏⇐⇑⇒⇓⇔⇕⇖⇗⇘⇙⇚⇛⇜⇝⇞⇟⇠⇡⇢⇣⇤⇥⇦⇧⇨⇩⇪⇫⇬⇭⇮⇯⇰⇱⇲⇳⇴⇵⇶⇷⇸⇹⇺⇻⇼⇽⇾⇿⊲⊳⊴⊵⊶⊷⊸⊹⊺⊻⊼⊽⊾⊿⋀⋁⋂⋃⋄⋅⋆⋇⋈⋉⋊⋋⋌⋍⋎⋏⌁⌂⌃⌄⌅⌆⌇⌈⌉⌊⌋⌌⌍⌎⌏⌐⌑⌒⌓⌔⌕⌖⌗⌘⌙⌚⌛⌜⌝⌞⌟⌠⌡⌢⌣⌤⌥⌦⌧⏎⏏⟶⟷⟸⟹⟺⟻⟼⟽⟾⟿⤀⤁⤂⤃⤄⤅⤆⤇⤈⤉⤊⤋⤌⤍⤎⤏⤐⤑⤒⤓⤔⤕⤖⤗⤘⤙⤚⤛⤜⤝⤞⤟⤠⤡\"";
    static char[] c_gl = new char[]
     {
            'a',
            'o',
            'i',
            'y',
            'e',
            'u',
            's',
            '\'',
             'у',
             'е',
             'ъ',
             'ы',
             'а',
             'о',
             'э',
             'я',
             'ь',
             'ю',
             'и',
             'ё',
             'ṳ',
             'ѣ'
     };
    static char[] c_sgl = new char[]
     {
            'q',
            'w',
            't',
            'r',
            'y',
            'p',
            's',
             'd',
             'f',
             'g',
             'h',
             'j',
             'k',
             'l',
             'z',
             'x',
             'c',
             'v',
             'b',
             'n',
             'm',
             'й',
             'ц',
             'к',
             'н',
             'г',
             'ш',
             'щ',
             'з',
             'х',
             'ъ',
             'ф',
             'в',
             'п',
             'р',
             'л',
             'д',
             'ж',
             'ч',
             'с',
             'м',
             'т',
             'б',
             'ṳ'
     };
    public List<GameObject> fr = new List<GameObject>();
    List<GameObject> sfr = new List<GameObject>();
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<itemName>())
        {
            itemName item = collision.GetComponent<itemName>();
            if (item._Name == "Uoxil")
            {
                fr.Add(item.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponent<itemName>())
        {
            itemName item = collision.GetComponent<itemName>();
            if (item._Name == "Uoxil")
            {
                fr.Remove(item.gameObject);
            }
        }
    }
    string genName()
    {
        string s ="";
        System.Random rand = new System.Random();
        while (rand.Next(0,6538) > 2)
        {
            if(rand.Next(0,2) == 1)
            {
                s += c_sgl[rand.Next(0, c_sgl.Length)];
            }
            else
            {
                s += c_gl[rand.Next(0, c_gl.Length)];
            }
            if (rand.Next(0, 6) == 1)
            {
                s += " ";
            }
            

            if (rand.Next(0, 21) == 1)
            {
                s += "█";
            }
            if (rand.Next(0, 2) == 1)
            {
                s += dr[rand.Next(0, dr.Length)];
            }
        }
        return s;
    }
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider != null)
        {
            itemName item = hit.collider.GetComponent<itemName>();
            if (item._Name == "Anvil" && fr.Count >= 2)
            {
                
               

                    GameObject g = Instantiate(Resources.Load<GameObject>("items/script"), gameObject.transform.position, Quaternion.identity);
                g.GetComponent<itemName>().ItemData = genName();
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0) for (int i = 0; i < 2; i++)
                        {
                            sfr.Add(fr[i]);
                        }
                    if (j == 1) for (int i = 0; i < sfr.Count; i++)
                        {
                            fr.Remove(sfr[i]);
                            Destroy(sfr[i]);
                        }
                    if (j == 2) sfr.Clear();
                }
            }
        }
    }
}
