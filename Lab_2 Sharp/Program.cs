using System;
using System.Collections.Generic;
using static Lab_2_Sharp.Classes.LabWork;

namespace Lab_2_Sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool overwrite = Overwrite();

            string input = "Input.dat";

            string output = "Output.dat";

            GetInputFile(input, overwrite);

            Console.WriteLine("\nInputFile:");

            Output(input);

            GetOutput(output, input);

            Console.WriteLine("\nOutputFile:");

            Output(output);
            
        }
    }
}
