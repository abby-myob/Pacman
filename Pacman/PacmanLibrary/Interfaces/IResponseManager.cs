using PacmanLibrary.Enums;

namespace PacmanLibrary.Interfaces
{
    public interface IResponseManager
    { 
        void PrintBoard(ICell[,] cells, Direction pacmanDirection, int level);
        Direction GetDirection();
        void PrintScore(int score);
    }
}