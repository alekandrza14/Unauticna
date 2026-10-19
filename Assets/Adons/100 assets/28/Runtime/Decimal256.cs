using System;
using System.Globalization;
using System.Runtime.InteropServices;
using BigInteger = System.Numerics.BigInteger;

namespace Unauticna.HyperbolicSpace
{
    /// <summary>Signed 256-bit fixed-point decimal. Exactly 28 fractional decimal places.
    /// BigInteger is used only for intermediate arithmetic; the stored payload is four ulongs.</summary>
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Decimal256 : IEquatable<Decimal256>, IComparable<Decimal256>
    {
        public ulong Limb0, Limb1, Limb2, Limb3;
        private static readonly BigInteger Scale=BigInteger.Pow(10,28);
        private static readonly BigInteger Limit=BigInteger.One<<255;
        private static readonly BigInteger Mask=(BigInteger.One<<64)-1;
        private const decimal DecimalScale=10000000000000000000000000000m;

        private BigInteger Raw
        {
            get
            {
                BigInteger bits=(BigInteger)Limb0+((BigInteger)Limb1<<64)+((BigInteger)Limb2<<128)+((BigInteger)Limb3<<192);
                return (Limb3&0x8000000000000000UL)!=0?bits-(BigInteger.One<<256):bits;
            }
        }
        private static Decimal256 FromRaw(BigInteger raw)
        {
            if(raw < -Limit || raw>=Limit)throw new OverflowException("Decimal256 overflow; carry into a mega-sector instead of wrapping.");
            if(raw.Sign<0)raw+=BigInteger.One<<256;
            return new Decimal256 { Limb0=(ulong)(raw&Mask),Limb1=(ulong)((raw>>64)&Mask),
                Limb2=(ulong)((raw>>128)&Mask),Limb3=(ulong)((raw>>192)&Mask) };
        }
        public static Decimal256 FromDecimal(decimal value)
        {
            // Canonical mega offsets/heights are in [0,2]. Their scaled 96-bit
            // coefficient fits decimal exactly: no BigInteger temporaries or GetBits array.
            if(value>=0 && value<=2)
            {
                const decimal two64=18446744073709551616m;
                decimal scaled=value*DecimalScale;
                ulong low=(ulong)(scaled%two64);
                return new Decimal256 {Limb0=low,Limb1=(ulong)((scaled-low)/two64)};
            }
            int[] bits=decimal.GetBits(value);
            BigInteger coefficient=(uint)bits[0]+((BigInteger)(uint)bits[1]<<32)+((BigInteger)(uint)bits[2]<<64);
            coefficient*=BigInteger.Pow(10,28-((bits[3]>>16)&255));
            return FromRaw(bits[3]<0?-coefficient:coefficient);
        }
        public decimal ToDecimal()
        {
            // Fast exact path for the nonnegative fractions used in MegaPoint.
            if(Limb3==0 && Limb2==0 && (Limb1>>32)==0)
                return new decimal(unchecked((int)Limb0),unchecked((int)(Limb0>>32)),unchecked((int)Limb1),false,28);
            BigInteger whole=BigInteger.DivRem(Raw,Scale,out BigInteger fraction);
            return (decimal)whole+(decimal)fraction/DecimalScale;
        }
        public static Decimal256 Parse(string text)
        {
            Split(text,out BigInteger integer,out decimal fraction);
            return FromRaw(integer*Scale+FromDecimal(fraction).Raw);
        }
        internal static void Split(string text,out BigInteger integer,out decimal fraction)
        {
            if(text==null)throw new ArgumentNullException(nameof(text));
            text=text.Trim();bool negative=text.StartsWith("-",StringComparison.Ordinal);
            if(text.StartsWith("-",StringComparison.Ordinal)||text.StartsWith("+",StringComparison.Ordinal))text=text.Substring(1);
            string[] parts=text.Split('.');
            if(parts.Length>2||parts[0].Length==0)throw new FormatException("Use an invariant decimal such as -123.45.");
            foreach(char c in text)if((c<'0'||c>'9')&&c!='.')throw new FormatException("Use decimal digits and a dot; no exponent or thousands separator.");
            string tail=parts.Length==2?parts[1]:"";
            if(tail.Length>28)throw new FormatException("At most 28 fractional decimal places are supported.");
            integer=BigInteger.Parse(parts[0],CultureInfo.InvariantCulture);
            fraction=tail.Length==0?0:decimal.Parse("0."+tail,CultureInfo.InvariantCulture);
            if(negative) {integer=-integer;fraction=-fraction;}
        }
        public override string ToString()
        {
            // JSON writes almost exclusively canonical offsets/heights. Format their
            // exact 96-bit decimal coefficient directly, avoiding BigInteger temporaries.
            if(Limb3==0 && Limb2==0 && (Limb1>>32)==0)
                return ToDecimal().ToString("0.############################",CultureInfo.InvariantCulture);
            BigInteger raw=Raw;bool negative=raw.Sign<0;
            string digits=BigInteger.Abs(raw).ToString(CultureInfo.InvariantCulture).PadLeft(29,'0');
            string text=digits.Substring(0,digits.Length-28)+"."+digits.Substring(digits.Length-28);
            return (negative?"-":"")+text.TrimEnd('0').TrimEnd('.');
        }
        private static BigInteger RoundDivide(BigInteger a,BigInteger b)
        {
            if(b.IsZero)throw new DivideByZeroException();
            BigInteger q=BigInteger.DivRem(a,b,out BigInteger r);
            int comparison=(BigInteger.Abs(r)*2).CompareTo(BigInteger.Abs(b));
            if(comparison>0 || (comparison==0&&!q.IsEven))q+=a.Sign*b.Sign;
            return q;
        }
        public static Decimal256 operator +(Decimal256 a,Decimal256 b)=>FromRaw(a.Raw+b.Raw);
        public static Decimal256 operator -(Decimal256 a,Decimal256 b)=>FromRaw(a.Raw-b.Raw);
        public static Decimal256 operator *(Decimal256 a,Decimal256 b)=>FromRaw(RoundDivide(a.Raw*b.Raw,Scale));
        public static Decimal256 operator /(Decimal256 a,Decimal256 b)=>FromRaw(RoundDivide(a.Raw*Scale,b.Raw));
        public static implicit operator Decimal256(decimal value)=>FromDecimal(value);
        public static explicit operator decimal(Decimal256 value)=>value.ToDecimal();
        public bool Equals(Decimal256 b)=>Limb0==b.Limb0&&Limb1==b.Limb1&&Limb2==b.Limb2&&Limb3==b.Limb3;
        public override bool Equals(object obj)=>obj is Decimal256 b&&Equals(b);
        public override int GetHashCode()=>unchecked((int)(Limb0^Limb1^Limb2^Limb3));
        public int CompareTo(Decimal256 b)=>Raw.CompareTo(b.Raw);
    }
}
