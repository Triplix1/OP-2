using System;
using static Lab_3_Sharp.Funcs;
using static Lab_3_Sharp.Stroka;

namespace Lab_3_Sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var texts = CreateList();

            Console.Write("\nInput texts");

            Output(texts);

            AddTexts(texts);

            Console.WriteLine("\nInput texts");

            Output(texts);

            Console.WriteLine("\nMin percent:\n{0}", FindStr(texts));

        }
    }
}
