import keyboard
import os.path
import time

def InputText():
    print("Enter yout text (press Shift + Enter to save file):")
    text = []
    while not keyboard.is_pressed('shift'):
        line = input()
        text.append(line)
    return text

def WriteFile (name, text):
    files = open(name,"a")
        
    for x in range(0,len(text)):
        files.write(text[x])
        if x != len(text) - 1:
            files.write("\n")
    files.close()     

def GetNewFile(nameNewFile, nameOldFile, word):
    files = open(nameOldFile,"r")
    outputtxt = []
    text = files.readlines()

    for line in text:
        if line.__contains__(word):
            outputtxt.append(line[:-2])   
    files.close()
    WriteFile(nameNewFile,outputtxt)

def OutputFile(fileName):
    file = open(fileName, "r")
    while True:
        line = file.readline()
        if not line:
            break
        print(line.strip())
    file.close()

def ClearFile(fileName, overwrite):
    if overwrite == 2:
        f = open(fileName, 'w')       
        f.close()

def OverwriteFile(inputfile, outputfile):
    overwrite = int(input("Do you want overwrite? 1 - yes, 2 - no\n"))
    while overwrite != 1 and overwrite != 2:
       overwrite = int(input("Do you want overwrite? 1 - yes, 2 - no\n"))
    ClearFile(inputfile, overwrite)
    ClearFile(outputfile, 2)

def GetFileInfo(fileName):
    print("Size of ", fileName, ": ", os.path.getsize(fileName),"bytes" )
    print("Time of creating", fileName,": ", time.ctime(os.path.getctime(fileName)))
