using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarNameGenrator : MonoBehaviour
{
    [SerializeField] Text txt;
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
    // Start is called before the first frame update
    void Start()
    {
        txt.text = "|| Cистема ||\n|| " + Create_word(Globalprefs.GetIdPlanet()) + " ||";
    }

    public static string Create_word(decimal SpaceId)
    {
        Vector2 posPlanet = new Vector2(-(float)SpaceId + (300), (float)SpaceId * 9);
        float Hash = Globalprefs.Hash(posPlanet);
        Hash = (Hash + 1) / 2;
        Hash *= 26858;
        float Hashgl = Globalprefs.Hash(posPlanet);
        Hashgl = (Hashgl + 1) / 2;
        Hashgl *= c_gl.Length;
        string new_word = "";
        int time = (int)Hash;
        bool o = 1 == Globalprefs.Hash(posPlanet);
        for (int i = 0; i < 3; i++)
        {
            time++;
            if (o) new_word += c_gl[new System.Random(time).Next(0, c_gl.Length)];
            if (!o) new_word += c_sgl[new System.Random(-time).Next(0, c_sgl.Length)];
            if (1 == new System.Random(time).Next(0, 5))
            {
                i--;
            }

            if (1 == new System.Random(time).Next(0, 7)) new_word += c_sgl[new System.Random(-time).Next(0, c_sgl.Length)];

            if (1 == new System.Random(time).Next(0, 4)) new_word += c_gl[new System.Random(time).Next(0, c_gl.Length)];
            if (1 == new System.Random(-time).Next(0, 3))
            {
                time -= 3;
            }
            time++;
            o = !o;
        }
        return new_word;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
