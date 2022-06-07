using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    internal static class Methods
    {
        static int GetNumber(string figure)
        {
            Console.WriteLine("Enter number {0}:",figure);
            string num = Console.ReadLine();
            int n;
            while (!(int.TryParse(num, out n) && n > 0))
            {
                Console.WriteLine("Enter normal nummber!");
                num = Console.ReadLine();
            }
            return n;
        }

        public static TPyramid[] GetPyramids()
        {
            int n = GetNumber("pyramids");
            TPyramid[] figures = new TPyramid[n];
            double height;
            double seclen;
            int faces;
            string tmp;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter height:");
                tmp = Console.ReadLine();
                while (!(double.TryParse(tmp, out height)&& height > 0))
                {
                    Console.WriteLine("Enter normal number: (>0)");
                    tmp = Console.ReadLine();
                }

                Console.WriteLine("Enter section length:");
                tmp = Console.ReadLine();
                while (!(double.TryParse(tmp, out seclen) && seclen > 0))
                {
                    Console.WriteLine("Enter normal number: (>0)");
                    tmp = Console.ReadLine();
                }

                Console.WriteLine("Enter number faces:");
                tmp = Console.ReadLine();
                while (!(int.TryParse(tmp, out faces) && faces > 2))
                {
                    Console.WriteLine("Enter normal number: (>2)");
                    tmp = Console.ReadLine();
                }
                figures[i] = new TPyramid(height, faces, seclen);
            }
            return figures;
        }

        public static TCylinder[] GetCylinders()
        {
            int m = GetNumber("cylindres");
            TCylinder[] cylinders = new TCylinder[m];
            double height;
            double radius;
            string tmp;
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine("Enter height:");
                tmp = Console.ReadLine();
                while (!(double.TryParse(tmp, out height) && height > 0))
                {
                    Console.WriteLine("Enter normal number:");
                    tmp = Console.ReadLine();
                }

                Console.WriteLine("Enter radius:");
                tmp = Console.ReadLine();
                while (!(double.TryParse(tmp, out radius) && radius > 0))
                {
                    Console.WriteLine("Enter normal number:");
                    tmp = Console.ReadLine();
                }              
                cylinders[i] = new TCylinder(height, radius);
            }
            return cylinders;
        }

        public static void Output(TPyramid[] pyr)
        {
            foreach (var item in pyr)
            {
                Output(item);
            }
        }

        public static void Output(TCylinder[] cyl)
        {
            foreach (var item in cyl)
            {
                Output(item);
            }
        }

        public static TCylinder FindCylMaxV(TCylinder[] cylinders)
        {
            int maxpos = 0;
            double v = cylinders[0].GetV();
            for (int i = 1; i < cylinders.Length; i++)
            {
                if (cylinders[i].GetV() > v)
                {
                    v = cylinders[i].GetV();
                    maxpos = i;
                }
            }
            return (TCylinder)cylinders[maxpos].Clone();
        }

        public static TPyramid FindPyrMinS(TPyramid[] pyramids)
        {
            int minpos = 0;
            double s = pyramids[0].GetS();
            for (int i = 1; i < pyramids.Length; i++)
            {
                if (pyramids[i].GetS() < s)
                {
                    s = pyramids[i].GetS();
                    minpos = i;
                }
            }
            return (TPyramid)pyramids[minpos].Clone();
        }
        public static void Output(TCylinder cyl)
        {
            Console.WriteLine("Height: {0:f2}", cyl.Height);
            Console.WriteLine("Radius: {0:f2}", cyl.Radius);
            Console.WriteLine("Square: {0:f2}", cyl.GetS());
            Console.WriteLine("Volume: {0:f2}", cyl.GetV());
            Console.WriteLine();
        }
        public static void Output(TPyramid pyramid)
        {
            Console.WriteLine("Height: {0:f2}", pyramid.Height);
            Console.WriteLine("Faces: {0}", pyramid.Faces);
            Console.WriteLine("Sections length: {0:f2}", pyramid.Seclen);
            Console.WriteLine("Square: {0:f2}", pyramid.GetS());
            Console.WriteLine("Volume: {0:f2}", pyramid.GetV());
            Console.WriteLine();
        }
    }
}
