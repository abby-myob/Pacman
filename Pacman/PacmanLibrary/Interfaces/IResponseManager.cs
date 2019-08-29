using System;
using PacmanLibrary.Enums;

namespace PacmanLibrary.Interfaces
{
    public interface IResponseManager
    { 
        void PrintBoard(ICell[,] cells, IPacman pacman);
        Direction GetDirection();
    }
}