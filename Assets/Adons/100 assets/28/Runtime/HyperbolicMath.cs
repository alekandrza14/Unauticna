using System;
using BigInteger = System.Numerics.BigInteger;

namespace Unauticna.HyperbolicSpace
{
    // A bounded local coordinate chart. Global positions use MegaPoint.
    public struct H3Point
    {
        public decimal X,Y,Z;
        public H3Point(decimal x,decimal y,decimal z) {X=x;Y=y;Z=z;}
        public static H3Point Origin=>new H3Point(0,1,0);
        public bool IsValid=>Y>0;
    }

    public struct DVec3
    {
        public decimal X,Y,Z;
        public DVec3(decimal x,decimal y,decimal z) {X=x;Y=y;Z=z;}
        public decimal Length=>DecimalMath.Length(X,Y,Z);
        public DVec3 Normalized {get {decimal length=Length;return length>0?this/length:new DVec3();}}
        public static decimal Dot(DVec3 a,DVec3 b)=>a.X*b.X+a.Y*b.Y+a.Z*b.Z;
        public static DVec3 operator +(DVec3 a,DVec3 b)=>new DVec3(a.X+b.X,a.Y+b.Y,a.Z+b.Z);
        public static DVec3 operator -(DVec3 a,DVec3 b)=>new DVec3(a.X-b.X,a.Y-b.Y,a.Z-b.Z);
        public static DVec3 operator *(DVec3 a,decimal b)=>new DVec3(a.X*b,a.Y*b,a.Z*b);
        public static DVec3 operator /(DVec3 a,decimal b)=>new DVec3(a.X/b,a.Y/b,a.Z/b);
    }

    public static class H3Math
    {
        public static bool Finite(float x)=>!float.IsNaN(x)&&!float.IsInfinity(x);
        public static decimal Distance(H3Point a,H3Point b)
        {
            decimal x=(b.X-a.X)/a.Y,y=b.Y/a.Y,z=(b.Z-a.Z)/a.Y;
            decimal q=DecimalMath.Length(x,y-1,z)/(2*DecimalMath.Sqrt(y));
            if(q<.000001m)return 2*q*(1-q*q/6);
            return 2*DecimalMath.Log(q+DecimalMath.Sqrt(1+q*q));
        }
        public static DVec3 LogDirection(H3Point camera,H3Point point,out decimal distance)
        {
            decimal x=(point.X-camera.X)/camera.Y,y=point.Y/camera.Y,z=(point.Z-camera.Z)/camera.Y;
            distance=Distance(camera,point);
            return new DVec3(x,(x*x+(y-1)*(y+1)+z*z)/2,z).Normalized;
        }
        public static decimal ApparentRadius(decimal distance,decimal radius,decimal curvatureRadius)
        {
            decimal d=distance/curvatureRadius;
            decimal ratio=d<.000001m?1-d*d/6:d/DecimalMath.Sinh(d);
            return curvatureRadius*ratio*DecimalMath.Sinh(radius/curvatureRadius);
        }
        // cosh(distance)-1 is monotone. Use it for bounded-chart culling/ranking
        // instead of evaluating a logarithm for every candidate.
        internal static decimal DistanceRank(H3Point p)
        {
            decimal dy=p.Y-1;
            return (p.X*p.X+dy*dy+p.Z*p.Z)/(2*p.Y);
        }
        internal static ProjectedStar Project(H3Point camera,H3Point point,decimal curvatureRadius,
            decimal visibleRadius,decimal visibleRank,decimal radiusFactor)
        {
            decimal x=(point.X-camera.X)/camera.Y,y=point.Y/camera.Y,z=(point.Z-camera.Z)/camera.Y;
            decimal dy=y-1,rank=(x*x+dy*dy+z*z)/(2*y);
            if(rank>=visibleRank)return default;
            decimal vy=(x*x+dy*(y+1)+z*z)/2;
            decimal sinh,ratio,d;
            if(rank<.000000000001m)
            {
                // Scaled length preserves tiny displacements whose square underflows decimal.
                sinh=DecimalMath.Length(x,vy,z)/y;
                decimal s2=sinh*sinh;
                ratio=1-s2/6+3*s2*s2/40;
                d=sinh*ratio;
            }
            else
            {
                sinh=DecimalMath.Sqrt(rank*(rank+2));
                d=DecimalMath.Log(1+rank+sinh);
                ratio=d/sinh;
            }
            if(d>=visibleRadius)return default;
            decimal factor=curvatureRadius*ratio/y;
            return new ProjectedStar {X=(float)(x*factor),Y=(float)(vy*factor),Z=(float)(z*factor),
                Distance=(float)(d*curvatureRadius),Radius=(float)(radiusFactor*ratio),
                Visibility=(float)Math.Max(0,Math.Min(1,(visibleRadius-d)/.18m))};
        }
        public static H3Point Step(H3Point p,DVec3 displacement,decimal curvatureRadius,ref DVec3 forward,ref DVec3 up)
        {
            if(!p.IsValid||curvatureRadius<=0)throw new ArgumentException("Invalid local H3 point or curvature radius.");
            decimal length=displacement.Length;
            if(length==0)return p;
            decimal t=length/curvatureRadius;
            if(t>1)throw new ArgumentException("Split movement into steps no longer than R.");
            DVec3 direction=displacement/length;
            DecimalMath.SinhCosh(t,out decimal sh,out decimal ch);
            DVec3 h=direction*sh;
            decimal denominator=ch-h.Y;
            H3Point next=new H3Point(p.X+p.Y*h.X/denominator,p.Y/denominator,p.Z+p.Y*h.Z/denominator);
            forward=Transport(forward,direction,h,ch,sh,denominator).Normalized;
            up=Transport(up,direction,h,ch,sh,denominator).Normalized;
            return next;
        }
        private static DVec3 Transport(DVec3 a,DVec3 direction,DVec3 h,decimal ch,decimal sh,decimal denominator)
        {
            decimal dot=DVec3.Dot(a,direction);
            DVec3 spatial=a+direction*((ch-1)*dot);
            decimal dDenominator=sh*dot-spatial.Y;
            return new DVec3(spatial.X-h.X*dDenominator/denominator,-dDenominator/denominator,spatial.Z-h.Z*dDenominator/denominator);
        }
    }

    public readonly struct StarKey : IEquatable<StarKey>,IComparable<StarKey>
    {
        public readonly BigInteger Level,X,Z;
        private readonly ulong hash;
        internal StarKey(BigInteger level,BigInteger x,BigInteger z,ulong knownHash)
        {Level=level;X=x;Z=z;hash=knownHash;}
        public StarKey(BigInteger level,BigInteger x,BigInteger z)
        {
            Level=level;X=x;Z=z;
            hash=CalculateHash(level,x,z);
        }
        private static ulong CalculateHash(BigInteger level,BigInteger x,BigInteger z)
            =>CombineHash(CoordinateRandom.IntegerHash(level),CoordinateRandom.IntegerHash(x),CoordinateRandom.IntegerHash(z));
        internal static ulong CombineHash(ulong level,ulong x,ulong z)
        {
            unchecked {
                return CoordinateRandom.Mix(x^
                    CoordinateRandom.Mix(z+0x9E3779B97F4A7C15UL)^
                    CoordinateRandom.Mix(level+0xD1B54A32D192ED03UL));
            }
        }
        public bool Equals(StarKey b)=>Hash==b.Hash&&Level==b.Level&&X==b.X&&Z==b.Z;
        public override bool Equals(object obj)=>obj is StarKey b&&Equals(b);
        public override int GetHashCode()=>unchecked((int)Hash);
        public int CompareTo(StarKey b)
        {int c=Level.CompareTo(b.Level);if(c!=0)return c;c=X.CompareTo(b.X);return c!=0?c:Z.CompareTo(b.Z);}
        public ulong Hash=>hash!=0?hash:CalculateHash(Level,X,Z);
        public override string ToString()=>Level+":"+X+":"+Z;
    }

    public static class CoordinateRandom
    {
        public static ulong Mix(ulong x)
        {unchecked {x=(x^(x>>30))*0xBF58476D1CE4E5B9UL;x=(x^(x>>27))*0x94D049BB133111EBUL;return x^(x>>31);}}
        internal static ulong IntegerHash(BigInteger value)
        {
            // Preserve the previous seeds for addresses that fit in Int64.
            if(value>=long.MinValue&&value<=long.MaxValue)return unchecked((ulong)(long)value);
            ulong result=0x8EBC6AF09C88C6E3UL;
            byte[] bytes=value.ToByteArray();
            foreach(byte b in bytes)result=Mix(result^b);
            return Mix(result^(ulong)bytes.Length);
        }
        public static decimal Unit(ulong hash,ulong channel)=>
            (Mix(unchecked(hash+channel*0x9E3779B97F4A7C15UL))>>11)/9007199254740992m;
        public static int ModelIndex(StarKey key,int count)=>count<=0?0:(int)(Mix(key.Hash^0xA0761D6478BD642FUL)%(ulong)count);
    }
}
