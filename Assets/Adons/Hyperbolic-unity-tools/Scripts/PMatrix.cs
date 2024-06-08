#region Header

/*
 * Copyright (c) 2003-2004, University of Maryland
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided
 * that the following conditions are met:
 *
 *		Redistributions of source code must retain the above copyright notice, this list of conditions
 *		and the following disclaimer.
 *
 *		Redistributions in binary form must reproduce the above copyright notice, this list of conditions
 *		and the following disclaimer in the documentation and/or other materials provided with the
 *		distribution.
 *
 *		Neither the name of the University of Maryland nor the names of its contributors may be used to
 *		endorse or promote products derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 * PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR
 * TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 * Piccolo was written at the Human-Computer Interaction Laboratory www.cs.umd.edu/hcil by Jesse Grosjean
 * and ported to C# by Aaron Clamage under the supervision of Ben Bederson.  The Piccolo website is
 * www.cs.umd.edu/hcil/piccolo.
 */

#endregion Header

using System;
namespace un
{
    using System;
    using System.Drawing;

    /// <summary>
    /// <b>PMatrix</b> defines an affine transform.  The compact .NET framework does not provide
    /// a matrix class.  This class is implemented by storing the scale and offsets rather than
    /// the actual matrix values.  It does not currently support rotation.  And it does not
    /// currently support all of the methods provided by PMatrix in Piccolo.NET.
    /// </summary>
    public class PMatrix : ICloneable
    {
        #region Fields

        private double offsetX;
        private double offsetY;

        //private double scale;
        private double scaleX;
        private double scaleY;

        #endregion Fields

        #region Constructors

        public PMatrix()
        {
            //scale = 1;
            scaleX = 1;
            scaleY = 1;
            offsetX = 0;
            offsetY = 0;
        }

        #endregion Constructors

        #region Properties

        public bool IsInvertible
        {
            //TypeGenergy { return scale != 0; }
            get { return scaleX != 0 && scaleY != 0; }
        }

        public double OffsetX
        {
            get { return offsetX; }
            set { offsetX = value; }
        }

        public double OffsetY
        {
            get { return offsetY; }
            set { offsetY = value; }
        }

        public double Scale
        {
            //TypeGenergy { return scale; }
            //set { scale = value; }
            get
            {
                return scaleX;
                //PointF[] pts = {new PointF(0, 0), new PointF(1, 0)};
                //TransformPoints(pts);
                //return PUtil.DistanceBetweenPoints(pts[0], pts[1]);
            }
            set
            {
                scaleX = value;
                scaleY = value;
                //ScaleBy(value / Scale);
            }
        }

        #endregion Properties

        #region Methods

        public Object Clone()
        {
            PMatrix r = new PMatrix();
            r.Multiply(this);
            return r;
        }

        public override bool Equals(object obj)
        {
            PMatrix otherMatrix = (PMatrix)obj;
            return (offsetX == otherMatrix.offsetX &&
                offsetY == otherMatrix.offsetY &&
                //scale == otherMatrix.scale);
                scaleX == otherMatrix.scaleX &&
                scaleY == otherMatrix.scaleY);
        }

        public override int GetHashCode()
        {
            //return offsetX.GetHashCode() ^ offsetY.GetHashCode() ^ scale.GetHashCode();
            return offsetX.GetHashCode() ^ offsetY.GetHashCode() ^ scaleX.GetHashCode() ^ scaleY.GetHashCode();
        }

        public PointF InverseTransform(PointF point)
        {
            point.X = (float)((1 / scaleX) * (point.X - (float)(offsetX)));
            point.Y = (float)((1 / scaleY) * (point.Y - (float)offsetY));

            //point.X = (1/scale) * (point.X - offsetX);
            //point.Y = (1/scale) * (point.Y - offsetY);
            return point;
        }

        public SizeF InverseTransform(SizeF size)
        {
            size.Width = (1 / (float)scaleX) * size.Width;
            size.Height = (1 / (float)scaleY) * size.Height;

            //size.Width = (1/scale) * size.Width;
            //size.Height = (1/scale) * size.Height;
            return size;
        }

        public RectangleF InverseTransform(RectangleF rect)
        {
            rect.X = (1 / (float)scaleX) * (rect.X - (float)offsetX);
            rect.Y = (1 / (float)scaleY) * (rect.Y - (float)offsetY);
            rect.Width = (1 / (float)scaleX) * rect.Width;
            rect.Height = (1 / (float)scaleY) * rect.Height;

            //rect.X = (1/scale) * (rect.X - offsetX);
            //rect.Y = (1/scale) * (rect.Y - offsetY);
            //rect.Width = (1/scale) * rect.Width;
            //rect.Height = (1/scale) * rect.Height;
            return rect;
        }

        public void Invert()
        {
            if (IsInvertible)
            {
                //scale = 1 / scale;
                //offsetX = -offsetX * scale;
                //offsetY = -offsetY * scale;

                scaleX = 1 / scaleX;
                scaleY = 1 / scaleY;
                offsetX = -offsetX * scaleX;
                offsetY = -offsetY * scaleY;
            }
        }

        public void Multiply(PMatrix aTransform)
        {
            ScaleBy(aTransform.scaleX, aTransform.scaleY);
            offsetX = aTransform.scaleX * offsetX + aTransform.OffsetX;
            offsetY = aTransform.scaleY * offsetY + aTransform.OffsetY;

            //ScaleBy(aTransform.scale);
            //offsetX = aTransform.scale * offsetX + aTransform.OffsetX;
            //offsetY = aTransform.scale * offsetY + aTransform.OffsetY;
        }

        public void Reset()
        {
            scaleX = 1;
            scaleY = 1;
            //scale = 1;
            offsetX = 0;
            offsetY = 0;
        }

        public void ScaleBy(double scale)
        {
            //this.scale *= scale;
            ScaleBy(scale, scale);
        }

        public void ScaleBy(double scale, double x, double y)
        {
            TranslateBy(x, y);
            //this.scale *= scale;
            ScaleBy(scale);
            TranslateBy(-x, -y);
        }

        public PointF Transform(PointF point)
        {
            point.X = (float)scaleX * point.X + (float)offsetX;
            point.Y = (float)scaleY * point.Y + (float)offsetY;

            //point.X = scale * point.X + offsetX;
            //point.Y = scale * point.Y + offsetY;
            return point;
        }

        public SizeF Transform(SizeF size)
        {
            size.Width = (float)scaleX * size.Width;
            size.Height = (float)scaleY * size.Height;

            //size.Width = scale * size.Width;
            //size.Height = scale * size.Height;
            return size;
        }

        public RectangleF Transform(RectangleF rect)
        {
            rect.X = (float)scaleX * rect.X + (float)offsetX;
            rect.Y = (float)scaleY * rect.Y + (float)offsetY;
            rect.Width = (float)scaleX * rect.Width;
            rect.Height = (float)scaleY * rect.Height;

            //rect.X = scale * rect.X + offsetX;
            //rect.Y = scale * rect.Y + offsetY;
            //rect.Width = scale * rect.Width;
            //rect.Height = scale * rect.Height;
            return rect;
        }

        /// <summary>
        /// Applies the geometric transform represented by this <see cref="PMatrix"/> object to all
        /// of the points in the given array.
        /// <see cref="PMatrix"/>.
        /// </summary>
        /// <param name="pts">The array of points to transform.</param>
        public virtual void TransformPoints(PointF[] pts)
        {
            int count = pts.Length;
            for (int i = 0; i < count; i++)
            {
                pts[i] = this.Transform(pts[i]);
            }
        }

        public void TranslateBy(double dx, double dy)
        {
            offsetX += (scaleX * dx);
            offsetY += (scaleY * dy);

            //offsetX += (scale * dx);
            //offsetY += (scale * dy);
        }

        internal void ScaleBy(double scaleX, double scaleY)
        {
            this.scaleX *= scaleX;
            this.scaleY *= scaleY;
        }

        #endregion Methods
    }
}
