import array
from math import factorial
from TCylinder import TCylinder
from TPyramid import TPyramid

def TryParseInt(s):
    try:
        int(s)
        return True
    except ValueError:
        return False 

def TryParseFloat(s):
    try:
        float(s)
        return True
    except ValueError:
        return False 

def GetNumber(figure: str):
    print("Enter number ",figure,":")
    num = input()    
    while True:
        if TryParseInt(num):            
            if int(num) > 0:
                break
        print("Enter normal number ",figure,":")
        num = input()        
    return int(num)
    
def GetPyramids():
    pyramids = []
    n = GetNumber("pyramids")
    for i in range(n):

        param = []

        print("Enter height:")
        param.append(input())
        while True:
            if TryParseFloat(param[0]):
                if float(param[0]) > 0:
                    break
            print("Enter normal height: (>0)")
            param[0] = input()

        print("Enter section length:")
        param.append(input())
        while True:
            if TryParseFloat(param[1]):
                if float(param[1]) > 0:
                    break
            print("Enter normal section length: (>0)")
            param[1] = input()

        print("Enter number faces:")
        param.append(input())
        while True:
            if TryParseInt(param[2]):
                if int(param[2]) > 2:
                    break
            print("Enter normal section length: (>2)")
            param[2] = input()

        pyramids.append(TPyramid(float(param[0]),float(param[1]),int(param[2])))

    return pyramids

def GetCylinders():
    cylinders = []
    n = GetNumber("cylinders")
    for i in range(n):

        param = []

        print("Enter height:")
        param.append(input())
        while True:
            if TryParseFloat(param[0]):
                if float(param[0]) > 0:
                    break
            print("Enter normal height: (>0)")
            param[0] = input()

        print("Enter radius:")
        param.append(input())
        while True:
            if TryParseFloat(param[1]):
                if float(param[1]) > 0:
                    break
            print("Enter normal radius: (>0)")
            param[1] = input()

        cylinders.append(TCylinder(float(param[0]),float(param[1])))

    return cylinders

def FindCylMaxV(cylinders: list[TCylinder]):
    maxpos = 0
    v = cylinders[0].GetV()
    for i in range(1,cylinders.__len__()):
        if cylinders[i].GetV() > v:
            v = cylinders[i].GetV()
            maxpos = i
    print("Cylinder with max volume:")
    OutputCylinder(cylinders[maxpos])

def FindPyrMinS(pyramids: list[TPyramid]):
    minpos = 0
    s = pyramids[0].GetV()
    for i in range(1,pyramids.__len__()):
        if pyramids[i].GetS() < s:
            s = pyramids[i].GetV()
            minpos = i
    print("Pyramid with min square:")
    OutputPyramid(pyramids[minpos])

def OutputPyramid(pyramid: TPyramid):
    print('Height: %.2f' % pyramid.height)
    print('Faces: ', pyramid.faces)
    print('Sections length: %.2f' % pyramid.seclen)
    print('Square: %.2f' % pyramid.GetS())
    print('Volume: %.2f' % pyramid.GetV())
    print()

def OutputCylinder(cyl: TCylinder):
    print('Height: %.2f' % cyl.height)
    print('Radius: %.2f' % cyl.radius)
    print('Square: %.2f' % cyl.GetS())
    print('Volume: %.2f' % cyl.GetV())
    print()

def OutputPyramids(pyramids: list[TPyramid]):
    for pyramid in pyramids:
        OutputPyramid(pyramid)


def OutputCylinders(cylinders: list[TCylinder]):
    for cylinder in cylinders:
        OutputCylinder(cylinder)        