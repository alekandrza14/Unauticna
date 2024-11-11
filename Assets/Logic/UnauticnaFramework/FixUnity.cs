
using System;
using UnityEngine;


public class sortmode
{
    static public FindObjectsSortMode main = FindObjectsSortMode.None;
}
public class objFind : MonoBehaviour
{
    static public T[] ArrayByType<T>() where T : UnityEngine.Object
    {
        
       return FindObjectsByType<T>(sortmode.main);
    }
}


namespace Global
{
    public class Random
    {
        static System.Random random = new();

        public static float Range(float min, float max)
        {


            float z = 0;
            float mmin = min;
            float mmax = max; bool t = false;

            if (mmin > mmax)
            {
                float s = mmin;
                mmin = mmax;
                mmax = mmin;
                Nope(s);
                t = true;
            }
            else
            {
                t = true;
            }
            decimal x = (decimal)mmin*1000, y = (decimal)mmax *1000;
            if (t) z = (float)(random.Next((int)x, (int)y)) / 1000f;

         
                if (z > mmax)
                {
                    return mmax;
                }
                if (z < -mmax)
                {
                    return -mmax;
                }
          
         
            return z;

        }
        public static int Range(int min, int max)
        {
            
            int z = 0;
            int mmin = min;
            int mmax = max; bool t = false;

            if (mmin > mmax)
            {
                int s = mmin;
                mmin = mmax;
                mmax = mmin;
                Nope(s);
                t = true;
            }
            else
            {
                t = true;
            }
            int x = mmin, y = mmax;
            if (t) z = random.Next(x, y);

         
                if (z > mmax)
                {
                    return mmax;
                }
                if (z < -mmax)
                {
                    return -mmax;
                }
          
         
            return z;

        }
        static void Nope(object s)
        {

        }
      public  static bool determindAll;
        public static bool Chance(float komplex)
        {
            if (determindAll)
            {
                return true;
            }
            return (int)Range(0, komplex) == 0 || (int)Range(0, komplex) == 1;
        }
        public static bool Chance(int komplex)
        {
            if (determindAll)
            {
                return true;
            }
            return Range(0, komplex) == 0;
        }
        public static float Range(float min, float max, float potencial)
        {


            float z = 0;
            float mmin = min;
            float mmax = max; bool t = false;

            if (mmin > mmax)
            {
                float s = mmin;
                mmin = mmax;
                mmax = mmin;
                Nope(s);
                t = true;
            }
            else
            {
                t = true;
            }
            float x = mmin * potencial, y = mmax * potencial;
            if (t) z = (float)(random.Next((int)x, (int)y)) / potencial;


            if (z > mmax)
            {
                return mmax;
            }
            if (z < -mmax)
            {
                return -mmax;
            }


            return z;

        }
    }
    [System.Serializable]
    public class Nint
    {
        public byte[] bytes;
        public bool negative;
        public Nint Set(byte[] x)
        {
            Nint _new = new();
            _new.bytes = x;
            this.bytes = _new.bytes;
            return _new;
        }
        public string Str(Nint x)
        {
            return BitConverter.ToString(x.bytes)+"N"+negative.ToString();
        }
        public string StrDeco(Nint x)
        {
            if (negative)
            {
                return "-" + BitConverter.ToString(x.bytes).Replace("-", "");
            }
            return BitConverter.ToString(x.bytes).Replace("-", "");
        }
        public Nint Num(string x)
        {
            Nint _new = new();
            string[] bitsbools = x.Split("N");
            string[] y = bitsbools[0].Split("-");
            byte[] z = new byte[y.Length];
            for (int i=0; i<z.Length;i++)
            {
                z[i] = (byte)Convert.ToInt32(y[i],16);
            }
            _new.negative = bool.Parse(bitsbools[1]);
            _new.bytes = z;
            this.bytes = _new.bytes;
            return _new;
        }
        public Nint Move(Nint x, Nint y)
        {
            Nint _new = new();
            _new.negative = x.negative;
            if (x.negative)
            {
                if (!y.negative)
                {
                    _new = ASub(x, y);
                }
            }
            if (!x.negative)
            {
                if (y.negative)
                {
                    _new = ASub(x, y);
                }
            }
            if (!x.negative)
            {
                if (!y.negative)
                {
                    _new = AAdd(x, y);
                }
            }
            if (x.negative)
            {
                if (y.negative)
                {
                    _new = AAdd(x, y);
                }
            }
            this.bytes = _new.bytes;
            negative = _new.negative;
            return _new;
        }
        public Nint AAdd(Nint x, Nint y)
        {
            Nint _new = new();
            _new.negative = x.negative;
            negative = x.negative;
            int x2 = x.bytes.Length;
            int y2 = y.bytes.Length;
            int z2 = x.bytes[0] + y.bytes[0] != 0 ? 1 : 0;
            
            byte[] z = new byte[x2 > y2 ? x.bytes.Length + z2 : y.bytes.Length + z2];
            byte[] w = new byte[x2 > y2 ? x.bytes.Length + z2 : y.bytes.Length + z2];
            int raz = x.bytes.Length - y.bytes.Length;
            for (int i = z2; i < z.Length; i++)
            {
                z[i] = (byte)(x.bytes[i - z2]);
              

            }
            for (int i = z2 + raz; i < w.Length; i++)
            {
                w[i] = (byte)(y.bytes[(i - z2) - raz]);

            }
            for (int i = z2; i < z.Length; i++)
            {

                
                if (w[i] != 0)
                {
                   
                        if ((z[i] + w[i]) > 255)
                        {
                            bool off = false;
                            for (int i2 = 1; !off; i2++)
                            {
                                if (i - i2 < z.Length) if (i - i2 >= 0) z[i - i2] += 1;
                                if (i - i2 - 1 < z.Length)
                                {
                                    if (i - i2 - 1 > 0)
                                    {
                                        if (i - i2 - 1 >= 0)
                                        {
                                            if ((z[i - i2 - 1] + 1) <= 255)
                                            {
                                                off = true;
                                                if (i - i2 - 1 >= 0) z[i - i2 - 1] += 1;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        off = true;
                                    }
                                }
                                else
                                {
                                    off = true;
                                }
                            }

                            z[i] += (byte)(w[i]);
                        }
                        else
                        {
                            z[i] += (byte)(w[i]);

                        }
                   
                }
            }
            y.bytes = w;

            _new.bytes = z;
            this.bytes = _new.bytes;
            return _new;
        }
        public Nint Mult(Nint x, int y)
        {
            byte[] z = x.bytes;
            Nint _new = new();
            Nint _new2 = new();
            _new.bytes = z;

            if (y < 0)
            {
                x.negative = !x.negative;
                y *= -1;
            }
            
            for (int i = 0; i < y-1; i++)
            {
                _new2 = x.AAdd(x, _new);
            }
           
            return _new2;
        }
        public Nint ASub(Nint x, Nint y)
        {
            Nint _new = new();
            _new.negative = x.negative;
            int x2 = x.bytes.Length;
            int y2 = y.bytes.Length;
            int a = 0;
            foreach (byte b in x.bytes)
            {
                a += b;
            }
            if (a<=0)
            {
                _new.negative = !_new.negative;
                _new.bytes = x.bytes;
                return _new;
            }
            byte[] z = new byte[x2 > y2 ? x.bytes.Length : y.bytes.Length];
            byte[] w = new byte[x2 > y2 ? x.bytes.Length : y.bytes.Length];
            int raz = x.bytes.Length - y.bytes.Length;
            for (int i = 0; i < z.Length; i++)
            {
                z[i] = (byte)(x.bytes[i]);


            }
            for (int i = 0 + raz; i < w.Length; i++)
            {
                w[i] = (byte)(y.bytes[(i) - raz]);

            }
            for (int i = 0; i < z.Length; i++)
            {

                int s = 0;
                if (z[i] != 0)
                {
                    s = i;
                }
                if (w[i] != 0)
                {
                    if (z[i] != 0)
                    {
                        if ((z[i] - w[i]) < 0)
                        {
                            bool off = false;

                            for (int i2 = 1; !off; i2++)
                            {
                                if (i - i2 < z.Length) if (i - i2 >= s) if ((z[i - i2]) > 0) z[i - i2] -= 1;

                                if (i - i2 - 1 < z.Length)
                                {
                                    if (i - i2 - 1 >= s)
                                    {
                                        if ((z[i - i2 - 1] - 1) >= 0)
                                        {
                                            off = true;
                                            if (i - i2 - 1 >= s) z[i - i2 - 1] -= 1;
                                        }
                                    }
                                }
                               
                            }

                            z[i] -= (byte)(w[i]);
                        }
                        else
                        {
                            z[i] -= (byte)(w[i]);

                        }
                    }
                }
            }
            _new.bytes = z;
            this.negative = _new.negative;
            this.bytes = _new.bytes;
            return _new;
        }
    }
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
                double t = UnityEngine.Random.Range(1, 1000);
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
            return new Vector3(Global.Random.Range(min, max), Global.Random.Range(min, max), Global.Random.Range(min, max));
        }
    }
}