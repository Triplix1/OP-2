import re
import os
import keyboard
from array import *
import pickle

class TrainTime:
    def __init__(self, hours, minutes):
        self.hours = hours
        self.minutes = minutes

class Train:
    def __init__(self, number: int, way: str, departure: TrainTime, arrival: TrainTime):
        self.number = number
        self.way = way
        self.departure = departure
        self.arrival = arrival
    
def AppendFile():
    append = int(input("Do you want append? 1 - yes, 2 - no\n"))
    while append != 1 and append != 2:
       append = int(input("Do you want append? 1 - yes, 2 - no\n"))
    if append == 1:
        return True
    return False

def tryParseInt(s):
    try:
        i = int(s)
        return True
    except ValueError:
        return False         

def InputText():
    result = []

    print("For stop inputting enter [Shift+Enter] after arrival time")

    while not keyboard.is_pressed('shift'):
        train = []
        while True:
            print("Enter num: ")
            num = input()
            if tryParseInt(num) and int(num) > 0:
                 train.append(int(num))
                 break

        print("Enter way:")
        while True:
            line = input().strip()
            if line != '' and not line is int:
                train.append(line.strip())
                break
            print("Enter normal way!")

        print("Enter train departure time (hh:mm):")
        while True:
            line = input()
            if IsNormalDate(line):
                train.append(line)
                break
            print("Enter normal departure time (hh:mm)!")

        print("Enter train arrival time (hh:mm):")
        while True:
            line = input()
            if IsNormalDate(line):
                train.append(line)
                break
            print("Enter normal arrival time (hh:mm)!")
        result.append(Train(train[0],train[1],TrainTime(int(train[2][:2]), int(train[2][3:])),TrainTime(int(train[3][:2]), int(train[3][3:]))))
        
    return result

def IsNormalDate(time):
    match = re.match(r'\b([0-1][0-9]|2[0-3]):([0-5][0-9])\b',time)
    if match:
        return True
    return False

def ClearFile(path: str):
    with open(path, "wb") as create:
        pass

def GetInput(path: str, trains: list[Train], append: bool):
    if not append:
        ClearFile(path)
    with open(path, "ab") as inputfile:
        for train in trains:
            pickle.dump(train, inputfile)

def ReadFile(path: str):
    trains = []
    with open(path, "rb") as readfile:
        while True:
            try:
                trains.append(pickle.load(readfile))
            except EOFError:
                break
    return trains

def IsWinter(trains: list[Train], ):
    normForWinter = []    
    for train in trains:
        trainminutes = train.departure.hours * 60 + train.departure.minutes
        if(trainminutes < 600 or trainminutes > 1080):
            normForWinter.append(train)
    return normForWinter

def GetOutput(inputpath: str, outputpath: str):
    trains = ReadFile(inputpath)
    winterTrains = IsWinter(trains)
    with open(outputpath, "wb") as inputfile:       
        for train in winterTrains:
            pickle.dump(train, inputfile)

def Output(path: str):
    trains = ReadFile(path)
    for train in trains:
        print('\nNumber:',train.number)
        print('Way:',train.way)
        print('Departure:',train.departure.hours,':',train.departure.minutes)
        print('Arrival:',train.arrival.hours,':',train.arrival.minutes)

