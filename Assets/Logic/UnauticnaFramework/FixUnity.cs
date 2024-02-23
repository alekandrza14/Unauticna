
using UnityEngine;


        public class sortmode
        {
            static public FindObjectsSortMode main = FindObjectsSortMode.None;
        }


namespace Global
{
    [System.Serializable]
    public class Negantropy
    {
        public double[] Order;
        public int curent;
        private int jugement;
        public Negantropy(double[] Order)
        {
            this.Order = Order;
        }
        public Negantropy(int count, double min, double max)
        {
            this.Order = presetFirstGen(count,min,max);
        }
        public double Next()
        {
            curent++; if (curent >= Order.Length) curent = 0;
            return Order[curent];
        }
        public double[] presetFirstGen(int count, double min, double max)
        {
            double[] time = new double[count];

            for (int i =0;i<time.Length;i++)
            {
                double t = Random.Range(1, 1000);
                t /= 1000;
                t *= max - min;
                t += min;
                if (t - min >= max-min/2)
                {
                    jugement++;

                }
                else
                {
                    jugement--;
                }
                if (jugement > 1)
                {
                    t += max - min / 2;
                    if(t>max)t= max;
                    jugement = 0;
                }
                else if(jugement < -1)
                {
                    t -= max - min / 2;
                    if (t < min) t = min;
                    jugement = 0;
                }
                time[i] = t;
            }
            return time;
        }
    }
    public class math
    {
        static public Vector3 randomCube(int min, int max)
        {
            return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
        }
    }
}