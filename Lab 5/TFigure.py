from abc import ABC, abstractmethod
class TFigure(ABC):
    def __init__(self, height: float):
        self._height = height
    
    @property
    def height(self):
        return self._height

    @height.setter
    def height(self, height):
        self._height 

    @abstractmethod
    def GetS(self):
        pass
    
    @abstractmethod
    def GetV(self):
        pass
    
    @abstractmethod
    def GetSOs(self):
        pass


