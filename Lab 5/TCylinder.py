from TFigure import TFigure
import math

class TCylinder(TFigure):
    def __init__(self, height, radius):
        super().__init__(height)
        self.__radius = radius

    @property
    def radius(self):
        return self.__radius

    @radius.setter
    def radius(self, radius):
        self.__radius = radius

    def GetS(self)-> float:
        return self.GetSOs() * 2 + 2 * math.pi * self.__radius * self._height

    def GetSOs(self)-> float:
        return self.__radius * self.__radius

    def GetV(self)-> float:
        return self.GetSOs() * self._height


