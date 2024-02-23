using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ObjParser;
using Unity.Mathematics;

namespace dnSpyModer
{
    public class MainModData
    {
      

        public static void Main()
        {

        }
        public static void LoadScene()
        {

        }
        public static void UpadeteScene()
        {

        }




        GameObject g;
        Transform t;
        float2 f2;
        mover m;
        Text txt;
        Sprite s;
        HyperbolicCamera hc;
        void NoWorckCode()
        {

            SceneManager.GetActiveScene();
            Obj n = new Obj();
            n.LoadObj("res/cube.obj");

        }
    }
}