using System;
using BigInteger = System.Numerics.BigInteger;

namespace Unauticna.HyperbolicSpace
{
    /// <summary>Canonical tangent bearing to the fixed global origin (0,1,0).
    /// No floating-origin state, double conversion or evaluation of huge powers.</summary>
    public static class HyperbolicOriginMath
    {
        public static DVec3 Bearing(MegaPoint camera, out decimal distance, out bool distanceKnown)
        {
            if(!camera.IsValid)throw new ArgumentException("Invalid camera position.",nameof(camera));
            distance=0;
            distanceKnown=MegaPoint.Origin.TryToLocal(camera,out H3Point target);
            if(distanceKnown)return H3Math.LogDirection(H3Point.Origin,target,out distance);

            // Origin in the camera chart: x=-(CellX+OffsetX)/Height,
            // z=-(CellZ+OffsetZ)/Height, y=2^(-Level)/Height.
            // For a huge horizontal cell or target height the geodesic initially
            // points up. This approximation has < 8e-12 direction error here.
            const long limit=1000000000000L;
            if(BigInteger.Abs(camera.CellX)>limit || BigInteger.Abs(camera.CellZ)>limit || camera.Level< -40)
                return new DVec3(0,1,0);
            decimal h=camera.Height.ToDecimal();
            decimal x=-((decimal)camera.CellX+camera.OffsetX.ToDecimal())/h;
            decimal z=-((decimal)camera.CellZ+camera.OffsetZ.ToDecimal())/h;
            // A vanishing target height is safe in the bearing formula (no log/division by y).
            decimal y=camera.Level>80?0:DecimalMath.Pow2(-(int)camera.Level)/h;
            decimal scale=Math.Max(1,Math.Max(Math.Abs(x),Math.Max(Math.Abs(z),y)));
            decimal inverse=1/scale;
            x*=inverse;y*=inverse;z*=inverse;
            return new DVec3(2*x*inverse,x*x+y*y+z*z-inverse*inverse,2*z*inverse).Normalized;
        }

        /// <summary>Point on one of three geodesics through the global origin.
        /// signedLength is in curvature radii, in [-1,1].</summary>
        public static MegaPoint AxisPoint(int axis,decimal signedLength)
        {
            if(axis<0||axis>2)throw new ArgumentOutOfRangeException(nameof(axis));
            if(Math.Abs(signedLength)>1)throw new ArgumentOutOfRangeException(nameof(signedLength));
            var displacement=new DVec3(axis==0?signedLength:0,axis==1?signedLength:0,axis==2?signedLength:0);
            var forward=new DVec3(0,0,1);var up=new DVec3(0,1,0);
            return MegaPoint.FromLocal(H3Math.Step(H3Point.Origin,displacement,1,ref forward,ref up));
        }
    }
}
