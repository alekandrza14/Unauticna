using System;

namespace Unauticna.HyperbolicSpace
{
    /// <summary>Local transcendental functions in decimal. No conversion through binary floating point.</summary>
    public static class DecimalMath
    {
        public const decimal Ln2=0.6931471805599453094172321215m;
        private const decimal Epsilon=0.000000000000000000000000001m;
        public static decimal Length(decimal x,decimal y,decimal z)
        {
            decimal scale=Math.Max(Math.Abs(x),Math.Max(Math.Abs(y),Math.Abs(z)));
            if(scale==0)return 0;
            x/=scale;y/=scale;z/=scale;
            return scale*Sqrt(x*x+y*y+z*z);
        }
        public static decimal Pow2(int exponent)
        {
            decimal value=1;
            if(exponent>=0)for(int i=0;i<exponent;i++)value*=2;
            else for(int i=0;i>exponent;i--)value/=2;
            return value;
        }
        public static int FloorLog2(decimal value)
        {
            if(value<=0)throw new ArgumentOutOfRangeException(nameof(value));
            int exponent=0;
            while(value>=2) {value/=2;exponent++;}
            while(value<1) {value*=2;exponent--;}
            return exponent;
        }
        public static decimal Sqrt(decimal value)
        {
            if(value<0)throw new ArgumentOutOfRangeException(nameof(value));
            if(value==0)return 0;
            decimal scale=1;
            while(value>4) {value/=4;scale*=2;}
            while(value<1) {value*=4;scale/=2;}
            decimal x=(value+1)/2;
            for(int i=0;i<64;i++)
            {
                decimal next=(x+value/x)/2;
                if(Math.Abs(next-x)<=Epsilon)return next*scale;
                x=next;
            }
            return x*scale;
        }
        public static decimal Log(decimal value)
        {
            if(value<=0)throw new ArgumentOutOfRangeException(nameof(value));
            int exponent=0;
            while(value>=2) {value/=2;exponent++;}
            while(value<1) {value*=2;exponent--;}
            decimal z=(value-1)/(value+1),z2=z*z,term=z,sum=z;
            for(int n=3;n<255;n+=2)
            {
                term*=z2;decimal addition=term/n;sum+=addition;
                if(Math.Abs(addition)<Epsilon)break;
            }
            return 2*sum+exponent*Ln2;
        }
        public static decimal Exp(decimal value)
        {
            if(value>64||value< -60)throw new ArgumentOutOfRangeException(nameof(value),"Exp is for a bounded local chart; store global scale in MegaPoint.Level.");
            int exponent=(int)decimal.Round(value/Ln2,0);
            decimal r=value-exponent*Ln2,term=1,sum=1;
            for(int n=1;n<128;n++)
            {term=term*r/n;sum+=term;if(Math.Abs(term)<Epsilon)break;}
            return sum*Pow2(exponent);
        }
        public static void SinhCosh(decimal value,out decimal sinh,out decimal cosh)
        {
            decimal e=Exp(value),inverse=1/e;sinh=(e-inverse)/2;cosh=(e+inverse)/2;
        }
        public static decimal Sinh(decimal value) {SinhCosh(value,out decimal s,out _);return s;}
        public static decimal Cosh(decimal value) {SinhCosh(value,out _,out decimal c);return c;}
    }
}
