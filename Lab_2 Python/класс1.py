import keyboard

def InputText():
    result = []
    while true:
        train = []
        print("For stop inputting enter [%]")
        print("Enter Num:")
        while key
            line = input()
            if True:
                
    

#static class LabWork
#    {
#        public static List<string[]> InputText() 
#        {
#            List<string[]> result = new List<string[]>();

#            ConsoleKeyInfo key;
#            do
#            {
#                string[] train = new string[4];
#                Console.WriteLine("For stop inputting enter [%]");
#                Console.WriteLine("Enter number:");
                
#                do
#                {
#                    key = Console.ReadKey();
#                    if (key.Key == ConsoleKey.Enter && train[0] != null)
#                    {
#                        break;
#                    }
#                    if (key.Key == ConsoleKey.D5) return result;
#                    if (key.Key != ConsoleKey.Enter) train[0] += key.KeyChar; ;

                    

#                } while (true);

#                Console.WriteLine("\nEnter way:");

#                do
#                {
#                    train[1] = Console.ReadLine();
#                    if (IsNormalWay(train[1])) break;
#                    Console.WriteLine("Enter normal way:");
#                } while (true);

#                Console.WriteLine("Enter train departure time (dd:hh:mm):");

#                do
#                {
#                    train[2] = Console.ReadLine();
#                    if (IsNormalDate(train[2])) break;
#                    Console.WriteLine("Enter normal time:");
#                } while (true);

#                Console.WriteLine("Enter train arrival time (dd:hh:mm): ");

#                do
#                {
#                    train[3] = Console.ReadLine();
#                    if (IsNormalDate(train[3])) break;
#                    Console.WriteLine("Enter normal time:");
#                } while (true);

#                result.Add(train);

#            } while (true);

#        }

