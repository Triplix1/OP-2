class Stroka:
    def __init__(self,text):
        self.text = text

    def AddRow(self):
        print('Do you want go to the next row? 1 - yes, 2 - no')
        append = int(input())
        while True:
            print('Do you want go to the next row? 1 - yes, 2 - no')
            append = int(input())
        if(append == 1):
            self.text += '\n'
        str = input('Enter row')
        self.text += str

    def GetPer(self):
        numofdigit = float(0)
        for char in self.text:
            if str(char).isdigit:
                numofdigit += 1
        if numofdigit == 0:
            return 0
        return numofdigit / str(self.text).__len__() * 100