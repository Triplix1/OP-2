using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Lab_2._2_Sharp
{
    internal static class Class1
    {
        public static bool Append()
        {
            Console.WriteLine("Do you want append? 1 - yes, 2 - no");
            int append = Convert.ToInt32(Console.ReadLine());
            while (append != 1 && append != 2)
            {
                Console.WriteLine("Do you want append? 1 - yes, 2 - no");
                append = Convert.ToInt32(Console.ReadLine());
            }
            return (append == 1) ? true : false;
        }
        public static List<Train> InputTrains()
        {
            List<Train> result = new List<Train>();

            ConsoleKeyInfo key;
            do
            {
                Train train = new Train();               
                
                while (true)
                {
                    Console.WriteLine("\nEnter number:");
                    string num = Console.ReadLine();                    
                    if (int.TryParse(num, out int number) == true && number > 0)
                    {
                        train.Number = number;
                        break;
                    }
                }

                
                while (train.Way == "" || train.Way == null)
                {
                    Console.WriteLine("Enter way:");
                    train.Way = Console.ReadLine();                    
                }
                

                Console.WriteLine("Enter train departure time (hh:mm):");
                string time;
                do
                {
                    time = Console.ReadLine();
                    if (IsNormalDate(time)) break;
                    Console.WriteLine("Enter normal time:");
                } while (true);
                train.Departuretime = new TrainTime(Convert.ToInt32(time.Substring(0, 2)), Convert.ToInt32(time.Substring(3,2)));
                Console.WriteLine("Enter train arrival time (hh:mm): ");

                do
                {
                    time = Console.ReadLine();
                    if (IsNormalDate(time)) break;
                    Console.WriteLine("Enter normal time:");
                } while (true);
                train.Arrivaltime = new TrainTime(Convert.ToInt32(time.Substring(0, 2)), Convert.ToInt32(time.Substring(3, 2)));
                result.Add(train);
                Console.WriteLine("For stop inputting enter [%]");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.D5) return result;
            } while (true);
        }

        public static bool IsNormalDate(string date)
        {
            Regex regex = new Regex("^(([0-1][0-9]|2[0-3]):[0-5][0-9])$");

            return regex.IsMatch(date);
        }

        public static void ClearFile(string path) 
        {
            using (var file = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
            }
        }

        public static void GetInputFile(List<Train> trains, string path, bool append)
        {
            if (!append)
            {
                ClearFile(path);
            }

            var formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach (Train train in trains)
                {
                    formatter.Serialize(stream, train);
                }
            }
        }

        #region Output
        public static void GetOutput(string input, string output) 
        {
            var trains = ReadFile(input);
            var wintertrains = GetWinterTrains(trains);
            var formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(output, FileMode.Create))
            {
                foreach (Train train in wintertrains)
                {
                    formatter.Serialize(stream, train);
                }
            }
        }

        public static List<Train> ReadFile(string path)
        {
            var formatter = new BinaryFormatter();
            List<Train> trains = new List<Train>();
            FileStream s = new FileStream(path, FileMode.Open);
            s.Position = 0;
            while (s.Position != s.Length)
            {
                Train t = (Train)formatter.Deserialize(s);
                trains.Add(t);
            }
            s.Close();

            return trains;
        }

        public static List<Train> GetWinterTrains(List<Train> trains) 
        {
            var wintertrains = new List<Train>();
            foreach (Train train in trains) 
            {
                if (train.Departuretime.Hours < 10 || train.Departuretime.Hours > 18)
                {
                    wintertrains.Add(train);
                }
            }
            return wintertrains;
        }
        #endregion 
        public static void Output(string path)
        {
            var trains = ReadFile(path);

            foreach (var train in trains)
            {
                Console.WriteLine("\nTrain number: {0}",train.Number);
                Console.WriteLine("Train way: {0}",train.Way);
                Console.WriteLine("Train departure time: {0}:{1}",train.Departuretime.Hours,train.Departuretime.Minutes);
                Console.WriteLine("Train arrival time: {0}:{1}",train.Arrivaltime.Hours,train.Arrivaltime.Minutes);
            }
        }
    }
}
