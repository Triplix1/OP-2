from Stroka import Stroka
import keyboard

def GetNum():
    while True:
        print("Enter num of texts: ")
        num = input()
        if tryParseInt(num) and int(num) > 0:
            return int(num)

def tryParseInt(s):
    try:
        i = int(s)
        return True
    except ValueError:
        return False
    
def CreateArr():
    number = GetNum()
    texts = []
    text = ''
    for i in range(0,number):
        print('Enter text numer ',i+1)
        while True:
            line = input()
            text += line
            if keyboard.is_pressed('shift'):
                break
        texts.append(Stroka(text))
    return texts

def AddTexts(texts: list[Stroka]):
    while True:
        while True:
            print('\nEnter number text to witch you want to add(If you want stop press Shift+Enter)')
            number = input()
            if keyboard.is_pressed('shift'):
                return texts
            if tryParseInt(number) and int(number)>0 and int(number) <= texts.__len__():
                break
        texts[int(number) - 1].AddRow()

def FindStr(texts: list[Stroka]):
    percents = list[Stroka]
    for i in range(texts.len()):
        percents[i] = texts[i].GetPer()
    maximum = 0
    for i in range(texts.len()):
        if percents[i] > percents[maximum]:
            maximum = i
            d = texts[maximum].text + "%.2f",texts[maximum].GetPer()
        return d

def OutPut(texts: list[Stroka]):
    print()
    for text in texts:
        print(text.text+"%.2f",text.GetPer())


#        public static void AddTexts(Stroka[] texts)
#        {
#            while (true)
#            {
#                int number;
#                while (true)
#                {
#                    Console.WriteLine("\nEnter number text to witch you want to add(If you want stop press %");
#                    string num = Console.ReadLine();
#                    if (num.Contains("%"))
#                    {
#                        return;
#                    }
#                    if (int.TryParse(num, out number) == true && number > 0 && number <= texts.Length)
#                    {
#                        break;
#                    }
#                }
#                texts[number-1].AddRow();
#            }
#        }
#        public static string FindStr(Stroka[] texts)
#        {
#            decimal[] percents = new decimal[texts.Length];
#            for (int i = 0; i < texts.Length; i++)
#            {
#                percents[i] = texts[i].GetPer();
#            }

#            int max = 0;

#            for (int i = 1; i < texts.Length; ++i)
#            {
#                max = percents[i]>percents[max]?i:max;
#            }
#            return String.Format("{0} ({1:f2}%)",texts[max].Text, texts[max].GetPer());
#        }

#        public static void Output(Stroka[] texts)
#        {
#            Console.WriteLine();
#            foreach (Stroka text in texts)
#            {
#                Console.WriteLine("{0} ({1:f2}%)",text.Text,text.GetPer());
#            }
#        }
