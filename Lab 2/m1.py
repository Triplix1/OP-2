from _typeshed import OpenBinaryModeReading, OpenBinaryModeWriting
import re
import os
import threading
import keyboard
from array import *


def InputText():
    result = []
    while True:        
        print("For stop inputting enter [Shift+Enter]")
        print("Enter Num:")
        train = []
        line = None
        while line == None or line == "":
            line = input()
            if keyboard.is_pressed('shift'):
                return result
        train.append(line)

        print("Enter way:")

        while True:
            line = input()
            if IsNormalWay(line):
                train.append(line)
                break
            print("Enter normal way!")

        print("Enter train departure time (dd:hh:mm):")

        while True:
            line = input()
            if IsNormalDate(line):
                train.append(line)
                break
            print("Enter normal departure time (dd:hh:mm)!")

        print("Enter train arrival time (dd:hh:mm):")

        while True:
            line = input()
            if IsNormalDate(line):
                train.append(line)
                break
            print("Enter normal arrival time (dd:hh:mm)!")
        result.append(train)
        train = []

def IsNormalWay(way):
    ways = {"north", "east", "northeast", "west", "northwest", "southwest", "southeast", "south"}
    return ways.__contains__(way)

def IsNormalDate(time):
    match = re.match(r'\b([0-2][0-9]|3[0-1]):([0-1][0-9]|2[0-3]):([0-5][0-9])\b',time)
    if match:
        return True
    return False

def OverwriteFile():
    overwrite = int(input("Do you want overwrite? 1 - yes, 2 - no\n"))
    while overwrite != 1 and overwrite != 2:
       overwrite = int(input("Do you want overwrite? 1 - yes, 2 - no\n"))
    return overwrite

def GetInputFile(path: str, append: bool):
    IsEmpty
    text = InputText()
    while text.count == 0:
        print("Add trains!!!")
        text = InputText()
    if append:
        os.remove(path)
    with open(path,"rb") as inputfile:
        inputfile.read()

        

#public static void GetInputFile(string path, bool append)
#        {
#            bool isEmpty;

#            List<string[]> text = InputText();

#            while (text.Count == 0) 
#            {
#                Console.WriteLine("Add trains!!!");
#                text = InputText();
#            }

#            using (BinaryReader file = new BinaryReader(File.Open(path, append ? FileMode.OpenOrCreate : FileMode.Create)))
#            {
#                isEmpty = (file.Read() == -1) ? true: false;
#            }
            
#            using (BinaryWriter file = new BinaryWriter(File.Open(path,FileMode.Append)))
#            {                
#                string line = null;                

#                for (int i = 0; i < text.Count; i++)
#                {
#                    if (line != null || !isEmpty )
#                    {
#                        line += "\n";
#                    }

#                    line +=  $"{text[i][0]}\t {text[i][1]}\t {text[i][2]}\t {text[i][3]}";
#                }
#                file.Write(line);
#            }
#        }