using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_Labs_new
{
    public static class Funcs
    {
        public static List<string> InputText()
        {
            Console.WriteLine("Press CTRL+S for stop entering:");
            List<string> text = new List<string>();

            string line = Console.ReadLine();
            int stopSimbol = 19;
            text.Add(line);
            while ((int)line[0] != stopSimbol)
            {
                line = Console.ReadLine();
                text.Add(line);
            }
            text.Remove(line);
            return text;
        }

        public static void WriteFile(string filename, List<string> text)
        {
            string[] strok = File.ReadAllLines(filename);
            using (StreamWriter sw = new StreamWriter(filename, true))
            {               

                if (strok.Length != 0 && text.Count != 0)
                {
                    sw.WriteLine();
                }
                
                for (int i = 0; i < text.Count; i++)
                {
                    sw.Write(text[i]);
                    if (i!= text.Count-1)
                    {
                        sw.Write("\n");
                    }
                }
            }            
        }

        public static void GetNewFile(string nameNewFile, string nameOldFile, string word)
        {
            List<string> text = new List<string>();
            using (StreamReader sr = new StreamReader(nameOldFile))
            {
                string line;   
                while (sr.Peek() != -1 )
                {
                    line = sr.ReadLine();
                    if (line.Contains( word ))
                    {
                        text.Add(line);
                    }                    
                    
                }
            }

            WriteFile(nameNewFile, text);
        }

        public static void OutputFile(string filename)
        {
            using(StreamReader sw = new StreamReader(filename, true))
            {                
                Console.WriteLine(sw.ReadToEnd());
            }
        }

        public static void ClearFile(string filename,int overwrite)
        {
            if (overwrite == 2)
            {
                using (StreamWriter sw = new StreamWriter(filename,false))
                {
                }
            }
        }
        public static void Overwrite(string inputfile, string outputfile)
        {
            Console.WriteLine("Do you want overwrite? 1 - yes, 2 - no");
            int overwrite = Convert.ToInt32(Console.ReadLine());
            while (overwrite != 1 && overwrite != 2)
            {
                Console.WriteLine("Do you want overwrite? 1 - yes, 2 - no");
                overwrite = Convert.ToInt32(Console.ReadLine());                
            }
            ClearFile(inputfile, overwrite);
            ClearFile(outputfile, 2); 
        }

        public static void GetInfo(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            Console.WriteLine("Ths size of file: {0} bytes",file.Length);
            Console.WriteLine("file created: {0}", File.GetCreationTime(fileName).ToString());
        }
    }
}
