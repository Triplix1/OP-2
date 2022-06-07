using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Sharp
{
    public static class Funcs
    {
        
        public static List<Stroka> CreateList()
        {
            int num = 0;
            List<Stroka> str = new List<Stroka>();            
            while (true)
            {
                num++;
                Console.WriteLine("Enter text {0} (For stop inputting current text enter '@@'), for return enter '@@@'", num);
                str.Add(new Stroka(string.Empty));
                while (str[num - 1].Text.Length < 2 || str[num - 1].Text.Substring(str[num - 1].Text.Length - 2) != "@@")
                {
                    str[num - 1].AddRow(Console.ReadLine());
                }
                str[num - 1].Remove(str[num - 1].Text.Length - 2);
                if (str[num - 1].Text.Length > 0 && str[num - 1].Text.Substring(str[num - 1].Text.Length - 1) == "@")
                {
                    str[num - 1].Remove(str[num - 1].Text.Length - 1);
                    return str;
                }
            }
            
        }
        
        public static void AddTexts(List<Stroka> texts)
        {
            Console.WriteLine();
            while (true)
            {
                int number;                
                Console.WriteLine("Enter number text to witch you want to add(If you want stop Enter %)");
                string num = Console.ReadLine();
                if (num.Contains("%"))
                {                         
                    return;
                }
                if (int.TryParse(num, out number) == true && number > 0 && number <= texts.Count)
                {
                    Console.WriteLine("Enter row:");
                    string text = Console.ReadLine();
                    texts[number - 1].AddRow(text);
                }
                else
                {
                    Console.WriteLine("Number mist be > 0 and < number texts!!!");
                }
                
            }
        }
        public static string FindStr(List<Stroka> texts)
        {
            int mintext = 0;
            decimal minper = texts[0].GetPer();
            for (int i = 1; i < texts.Count; i++)
            {
                if (texts[i].GetPer() < minper)
                {
                    minper = texts[i].GetPer();
                    mintext = i;
                }
            }

            return String.Format("{0} ({1:f2}%)",texts[mintext].Text, minper);
        }

        public static void Output(List<Stroka> texts)
        {
            Console.WriteLine();
            foreach (Stroka text in texts)
            {
                Console.WriteLine();
                Console.WriteLine("{0} ({1:f2}%)",text.Text,text.GetPer());
            }
        }
    }
}
