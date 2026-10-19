using System;
using System.Globalization;
using BigInteger = System.Numerics.BigInteger;

namespace Unauticna.HyperbolicSpace
{
    [Serializable]
    public sealed class MegaPositionData
    {
        public string level="0",cellX="0",cellZ="0",offsetX="0",height="1",offsetZ="0";
    }

    /// <summary>Global H³ point: (2^Level*(CellX+OffsetX), 2^Level*Height, 2^Level*(CellZ+OffsetZ)).
    /// The huge power is never evaluated. Cell addresses and Level have no fixed-width wrap.
    /// Offsets use Decimal256; local geometry is evaluated with decimal.</summary>
    public readonly struct MegaPoint : IEquatable<MegaPoint>
    {
        public readonly BigInteger Level,CellX,CellZ;
        public readonly Decimal256 OffsetX,Height,OffsetZ;
        public static MegaPoint Origin=>FromLocal(H3Point.Origin);
        public bool IsValid=>Height.ToDecimal()>=1 && Height.ToDecimal()<2;
        private MegaPoint(BigInteger level,BigInteger x,BigInteger z,decimal fx,decimal y,decimal fz)
        {Level=level;CellX=x;CellZ=z;OffsetX=fx;Height=y;OffsetZ=fz;}

        public static MegaPoint FromLocal(H3Point p)=>FromChart(BigInteger.Zero,BigInteger.Zero,BigInteger.Zero,p.X,p.Y,p.Z);
        public static MegaPoint FromCoordinates(string x,string y,string z,string scalePower="0")
        {
            Decimal256.Split(x,out BigInteger ix,out decimal fx);
            Decimal256.Split(z,out BigInteger iz,out decimal fz);
            return FromChart(BigInteger.Parse(scalePower,CultureInfo.InvariantCulture),ix,iz,fx,
                decimal.Parse(y,CultureInfo.InvariantCulture),fz);
        }
        public static MegaPoint FromChart(BigInteger level,BigInteger x,BigInteger z,decimal fx,decimal y,decimal fz)
        {
            if(y<=0)throw new ArgumentOutOfRangeException(nameof(y),"H³ height must be positive.");
            Carry(ref x,ref fx);Carry(ref z,ref fz);
            while(y>=2)
            {
                x=FloorDiv(x,2,out BigInteger rx);z=FloorDiv(z,2,out BigInteger rz);
                fx=((decimal)rx+fx)/2;fz=((decimal)rz+fz)/2;y/=2;level++;
            }
            while(y<1)
            {x*=2;z*=2;fx*=2;fz*=2;y*=2;level--;Carry(ref x,ref fx);Carry(ref z,ref fz);}
            // Rounding at an exact cell edge can produce a fractional value of 1.
            Carry(ref x,ref fx);Carry(ref z,ref fz);
            return new MegaPoint(level,x,z,fx,y,fz);
        }
        private static void Carry(ref BigInteger cell,ref decimal fraction)
        {decimal whole=decimal.Floor(fraction);cell+=(BigInteger)whole;fraction-=whole;}
        private static BigInteger FloorDiv(BigInteger a,BigInteger divisor,out BigInteger remainder)
        {
            BigInteger quotient=BigInteger.DivRem(a,divisor,out remainder);
            if(remainder.Sign<0) {quotient--;remainder+=divisor;}
            return quotient;
        }
        public MegaPoint Compose(H3Point local)
        {
            decimal y=Height.ToDecimal();
            return FromChart(Level,CellX,CellZ,OffsetX.ToDecimal()+y*local.X,y*local.Y,OffsetZ.ToDecimal()+y*local.Z);
        }

        // Returns this camera's coordinate in cells at Level + relativeLevel, without a huge float.
        public void CellAt(int relativeLevel,out BigInteger x,out decimal fx,out BigInteger z,out decimal fz)
        {
            if(relativeLevel< -64||relativeLevel>64)throw new ArgumentOutOfRangeException(nameof(relativeLevel),"CellAt operates on neighbouring layers.");
            AxisAt(CellX,OffsetX.ToDecimal(),relativeLevel,out x,out fx);
            AxisAt(CellZ,OffsetZ.ToDecimal(),relativeLevel,out z,out fz);
        }
        private static void AxisAt(BigInteger cell,decimal fraction,int shift,out BigInteger result,out decimal rest)
        {
            if(shift>=0)
            {
                BigInteger divisor=BigInteger.One<<shift;
                result=FloorDiv(cell,divisor,out BigInteger remainder);
                // Divide separately to avoid destroying fractional precision in a large intermediate.
                decimal scale=DecimalMath.Pow2(shift);
                rest=(decimal)remainder/scale+fraction/scale;
            }
            else
            {result=cell<<(-shift);rest=fraction*DecimalMath.Pow2(-shift);}
            Carry(ref result,ref rest);
        }
        public bool TryToLocal(MegaPoint reference,out H3Point local)
        {
            local=default;
            BigInteger difference=Level-reference.Level;
            // This rejects only nonlocal comparisons, never camera movement or global coordinates.
            if(difference< -32||difference>32||!IsValid||!reference.IsValid)return false;
            int shift=(int)difference;
            reference.CellAt(shift,out BigInteger rx,out decimal fx,out BigInteger rz,out decimal fz);
            BigInteger dx=CellX-rx,dz=CellZ-rz;
            if(BigInteger.Abs(dx)>1000000000000L||BigInteger.Abs(dz)>1000000000000L)return false;
            decimal scale=DecimalMath.Pow2(shift)/reference.Height.ToDecimal();
            local=new H3Point(((decimal)dx+OffsetX.ToDecimal()-fx)*scale,Height.ToDecimal()*scale,
                ((decimal)dz+OffsetZ.ToDecimal()-fz)*scale);
            return local.Y>=.00000001m&&local.Y<=100000000m&&Math.Abs(local.X)<=1000000m&&Math.Abs(local.Z)<=1000000m;
        }
        public MegaPositionData ToData()=>new MegaPositionData {
            level=Level.ToString(CultureInfo.InvariantCulture),cellX=CellX.ToString(CultureInfo.InvariantCulture),
            cellZ=CellZ.ToString(CultureInfo.InvariantCulture),offsetX=OffsetX.ToString(),height=Height.ToString(),offsetZ=OffsetZ.ToString() };
        public static MegaPoint FromData(MegaPositionData d)
        {
            if(d==null)throw new ArgumentNullException(nameof(d));
            return FromChart(BigInteger.Parse(d.level,CultureInfo.InvariantCulture),BigInteger.Parse(d.cellX,CultureInfo.InvariantCulture),
                BigInteger.Parse(d.cellZ,CultureInfo.InvariantCulture),Decimal256.Parse(d.offsetX).ToDecimal(),
                Decimal256.Parse(d.height).ToDecimal(),Decimal256.Parse(d.offsetZ).ToDecimal());
        }
        public bool Equals(MegaPoint b)=>Level==b.Level&&CellX==b.CellX&&CellZ==b.CellZ&&OffsetX.Equals(b.OffsetX)&&Height.Equals(b.Height)&&OffsetZ.Equals(b.OffsetZ);
        public override bool Equals(object obj)=>obj is MegaPoint b&&Equals(b);
        public override int GetHashCode()=>Level.GetHashCode()^CellX.GetHashCode()^CellZ.GetHashCode()^OffsetX.GetHashCode()^Height.GetHashCode()^OffsetZ.GetHashCode();
        public override string ToString()=>"2^("+Level+") * ("+CellX+" + "+OffsetX+", "+Height+", "+CellZ+" + "+OffsetZ+")";
    }

    /// <summary>Floating hyperbolic origin. Pure data: independently testable without Unity.</summary>
    public sealed class HyperbolicNavigator
    {
        public MegaPoint Origin { get; private set; }=MegaPoint.Origin;
        public MegaPoint Position { get; private set; }=MegaPoint.Origin;
        public H3Point LocalPosition { get; private set; }=H3Point.Origin;
        public BigInteger RebaseCount { get; private set; }
        public void SetPosition(MegaPoint p)
        {
            if(!p.IsValid)throw new ArgumentException("Invalid mega position.");
            Position=p;Origin=p;LocalPosition=H3Point.Origin;
        }
        public void MoveCanonical(DVec3 displacement,decimal radius,ref DVec3 forward,ref DVec3 up)
        {
            H3Point next=H3Math.Step(LocalPosition,displacement,radius,ref forward,ref up);
            MegaPoint global=Origin.Compose(next);
            LocalPosition=next;Position=global;
            if(Math.Abs(next.X)>.35m||Math.Abs(next.Z)>.35m||next.Y<.7m||next.Y>1.4m)RebaseNow();
        }
        public void RebaseNow()
        {
            Origin=Position;LocalPosition=H3Point.Origin;RebaseCount++;
        }
    }
}
