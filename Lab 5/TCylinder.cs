using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    internal class TCylinder : TFigure,ICloneable
    {
        double radius;
        public double Radius { get { return radius; } set { radius = value; } }
        public TCylinder(double height, double radius) : base(height)
        {
            this.radius = radius;
        }
        public override double GetS()
        {
            return GetSOS() * 2 + 2 * Math.PI * Radius * height;
        }

        public override double GetV()
        {
            return GetSOS() * height;
        }

        protected override double GetSOS()
        {
            return Radius * Radius * Math.PI;
        }

        public object Clone()
        {
            return new TCylinder(this.height,this.radius);
        }
    }
}
