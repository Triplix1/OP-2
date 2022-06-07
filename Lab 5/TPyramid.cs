using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    internal class TPyramid : TFigure,ICloneable
    {
        int faces;
        double seclen;
        public TPyramid(double height ,int faces, double seclen):base(height)
        { 
            this.faces = faces;
            this.seclen = seclen;            
        }
        public int Faces { get { return faces; } set { faces = value; } }
        public double Seclen { get { return seclen; } set { seclen = value; } }
        public override double GetS()
        {
            return GetApof()*GetPerimetrOs()/2*faces + GetSOS();
        }

        public override double GetV()
        {
            return GetSOS()*height/3;
        }

        protected override double GetSOS()
        {
            return (GetOsApof() * GetPerimetrOs())/2;
        }

        double GetOsApof()
        {
            return seclen / (2*Math.Tan(Math.PI/faces));
        }

        double GetPerimetrOs()
        {
            return faces * seclen;
        }

        double GetApof()
        {
            return Math.Sqrt(Math.Pow(GetOsApof(), 2)+height*height);
        }

        public object Clone()
        {
            return new TPyramid(this.height,this.faces, this.seclen);
        }
    }
}
