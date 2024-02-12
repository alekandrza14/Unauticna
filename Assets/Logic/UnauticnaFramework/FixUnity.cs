
using UnityEngine;


        public class sortmode
        {
            static public FindObjectsSortMode main = FindObjectsSortMode.None;
        }


namespace Global
{
    public class math
    {
        static public Vector3 randomCube(int min, int max)
        {
            return new Vector3(Random.Range(-min, max), Random.Range(-min, max), Random.Range(-min, max));
        }
    }
}