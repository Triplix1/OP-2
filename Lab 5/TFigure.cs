using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    internal abstract class TFigure
    {
        protected double height;
        public double Height { get { return height; } set { height = value; } }

        protected TFigure(double height)
        {
            this.height = height;
        }
        abstract public double GetS();
        abstract public double GetV();
        abstract protected double GetSOS();
    }
}
