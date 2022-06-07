using System;
using static Lab_6.Funcs;

namespace Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree tree = GenerateTree();

            Console.WriteLine("Your tree:");
            Output(tree.Root);

            Console.WriteLine("Average:");
            Console.WriteLine(GetAverage(tree));
        }
    }
}
