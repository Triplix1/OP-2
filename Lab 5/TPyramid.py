
from TFigure import TFigure
import math

class TPyramid(TFigure):
    def __init__(self, height, seclen, faces):
        super().__init__(height)
        self.__faces = faces
        self.__seclen = seclen

    @property
    def faces(self):
        return self.__faces

    @faces.setter
    def faces(self, faces):
        self.__faces = faces

    @property
    def seclen(self):
        return self.__seclen

    @seclen.setter
    def seclen(self, seclen):
        self.__seclen = seclen

    def GetV(self) ->float:
        return self.GetSOs()*self._height/3
    
    def GetS(self) -> float:
        return self.GetApof() * self.GetPerimetrOs() / 2 * self.__faces + self.GetSOs()

    def GetSOs(self)-> float:
        return self.GetOsApof() * self.GetPerimetrOs() / 2

    def GetOsApof(self)-> float:
        return self.__seclen / (2 * math.tan(math.pi / self.__faces))

    def GetPerimetrOs(self)-> float:
        return self.__faces * self.__seclen

    def GetApof(self)-> float:
        return math.sqrt(self.GetOsApof() ** 2 + self._height ** 2)