using System;
using static Lab_5.Methods;

namespace Lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pyramids = GetPyramids();
            Console.WriteLine("Pyramids:\n");
            Output(pyramids);
            var cylinders = GetCylinders();
            Console.WriteLine("Cylinders:\n");
            Output(cylinders);
            var cylinder = FindCylMaxV(cylinders);
            Console.WriteLine("Cylinder with max volume:\n");
            Output(cylinder);
            var pyramid = FindPyrMinS(pyramids);
            Console.WriteLine("Pyramid with min square:\n");
            Output(pyramid);
        }
    }
}
