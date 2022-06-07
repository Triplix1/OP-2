using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Lab_2_Sharp.Classes
{
    
    static class LabWork
    {
        public static List<string[]> InputText()
        {
            List<string[]> result = new List<string[]>();

            ConsoleKeyInfo key;
            do
            {
                string[] train = new string[4];
                Console.WriteLine("For stop inputting enter [%]");
                Console.WriteLine("Enter Name:");

                do
                {
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter && train[0] != null)
                    {
                        break;
                    }
                    if (key.Key == ConsoleKey.D5) return result;
                    if (key.Key != ConsoleKey.Enter) train[0] += key.KeyChar; ;



                } while (true);

                Console.WriteLine("\nEnter way:");

                do
                {
                    train[1] = Console.ReadLine();
                    if (IsNormalWay(train[1])) break;
                    Console.WriteLine("Enter normal way:");
                } while (true);

                Console.WriteLine("Enter train departure time (dd:hh:mm):");

                do
                {
                    train[2] = Console.ReadLine();
                    if (IsNormalDate(train[2])) break;
                    Console.WriteLine("Enter normal time:");
                } while (true);

                Console.WriteLine("Enter train arrival time (dd:hh:mm): ");

                do
                {
                    train[3] = Console.ReadLine();
                    if (IsNormalDate(train[3])) break;
                    Console.WriteLine("Enter normal time:");
                } while (true);

                result.Add(train);

            } while (true);

        }

        public static bool IsNormalDate(string date)
        {
            Regex regex = new Regex("^([0-2][0-9]|3[0-1]):([0-1][0-9]|2[0-3]):[0-5][0-9]$");

            return regex.IsMatch(date);

        }

        public static bool IsNormalWay(string way)
        {
            string[] ways = { "north", "east", "northeast", "west", "northwest", "southwest", "southeast", "south" };

            return ways.Contains(way.ToLower());
        }

        public static void GetInputFile(string path, bool append)
        {
            bool isEmpty;

            List<string[]> text = InputText();

            while (text.Count == 0)
            {
                Console.WriteLine("Add trains!!!");
                text = InputText();
            }

            using (BinaryReader file = new BinaryReader(File.Open(path, append ? FileMode.OpenOrCreate : FileMode.Create)))
            {
                isEmpty = (file.Read() == -1) ? true : false;
            }

            using (BinaryWriter file = new BinaryWriter(File.Open(path, FileMode.Append)))
            {
                string line = null;

                for (int i = 0; i < text.Count; i++)
                {
                    if (line != null || !isEmpty)
                    {
                        line += "\n";
                    }

                    line += $"{text[i][0]}\t {text[i][1]}\t {text[i][2]}\t {text[i][3]}";
                }
                file.Write(line);
            }
        }

        public static bool Overwrite()
        {
            Console.WriteLine("Do you want overwrite? 1 - yes, 2 - no");
            int overwrite = Convert.ToInt32(Console.ReadLine());
            while (overwrite != 1 && overwrite != 2)
            {
                Console.WriteLine("Do you want overwrite? 1 - yes, 2 - no");
                overwrite = Convert.ToInt32(Console.ReadLine());
            }
            return (overwrite == 1) ? true : false;
        }

        public static bool[] GetWinterTrains(List<string> trains, string ftime, string stime)
        {
            bool[] winter = new bool[trains.Count];

            int fminutes = (Convert.ToInt32(ftime[0].ToString()) * 10 + Convert.ToInt32(ftime[1].ToString())) * 60 + Convert.ToInt32(ftime[3].ToString()) * 10 + Convert.ToInt32(ftime[4].ToString());

            int sminutes = (Convert.ToInt32(stime[0].ToString()) * 10 + Convert.ToInt32(stime[1].ToString())) * 60 + Convert.ToInt32(stime[3].ToString()) * 10 + Convert.ToInt32(stime[4].ToString());

            for (int i = 0; i < trains.Count; i++)
            {
                int trainMin = (Convert.ToInt32(trains[i][3].ToString()) * 10 + Convert.ToInt32(trains[i][4].ToString())) * 60 + Convert.ToInt32(trains[i][6].ToString()) * 10 + Convert.ToInt32(trains[i][7].ToString());

                winter[i] = false;

                if (trainMin < fminutes || trainMin > sminutes)
                {
                    winter[i] = true;
                }
            }
            return winter;
        }
        public static void CreateOutput(string result, string outputpath)
        {
            using (BinaryWriter text = new BinaryWriter(File.Open(outputpath, FileMode.Create)))
            {
                text.Write(result);
            }
        }

        public static void GetOutput(string outputpath, string inputpath)
        {
            string line = null;
            List<string> time = new List<string>();
            string[] lines;
            string result = null;
            using (BinaryReader text = new BinaryReader(File.OpenRead(inputpath)))
            {
                text.BaseStream.Position = 0;
                while (text.BaseStream.Position != text.BaseStream.Length)
                {
                    line += text.ReadString();
                }
                string[] words = line.Split();

                int countWords = line.Split().Length;

                for (int i = 4; i < countWords; i = i + 7)
                {
                    time.Add(words[i]);
                }

                bool[] normforwinter = GetWinterTrains(time, "10:00", "18:00");

                lines = line.Split("\n");

                for (int i = 0; i < normforwinter.Length; i++)
                {
                    if (normforwinter[i])
                    {
                        if (result != null)
                        {
                            result += "\n";
                        }
                        result += lines[i];
                    }
                }
            }
            CreateOutput(result, outputpath);
        }

        public static void Output(string path)
        {
            using (BinaryReader file = new BinaryReader(File.OpenRead(path)))
            {
                file.BaseStream.Position = 0;
                while (file.BaseStream.Position != file.BaseStream.Length)
                {
                    Console.WriteLine(file.ReadString());
                }
            }
        }

    }
}
