using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Sharp
{
    public class Stroka
    {
        string text;
           
        public string Text
        { 
            get { return text; }
        }

        public Stroka(string line)
        {
            text = line;
        }

        public void AddRow(string str)
        {
            if (text != String.Empty)
            {
                text += "\n";
            }            
            text += str;
        }

        public void Remove(int startpos)
        {
            text = text.Remove(startpos);
        }

        public decimal GetPer()
        {
            decimal numofdigit = 0;
            string tmp = text.Replace("\n","");
            int length = tmp.Length;
            
            foreach (char ch in tmp)
            {
                if (Char.IsDigit(ch)) numofdigit++;
            }  

            if (numofdigit == 0)
            {
                return 0;
            }

            return numofdigit / length * 100m;
        }
            
    }
}
