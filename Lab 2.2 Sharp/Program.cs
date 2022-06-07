using System;
using static Lab_2._2_Sharp.Class1;

namespace Lab_2._2_Sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputpath = "Input.dat";
            string outputpath = "Output.dat";

            bool append = Append(); 

            var trains = InputTrains();            

            GetInputFile(trains, inputpath, append);

            Console.WriteLine("\nInput file:");

            Output(inputpath);

            GetOutput(inputpath, outputpath);

            Console.WriteLine("\nOutput file:");

            Output(outputpath);
        }
    }
}
