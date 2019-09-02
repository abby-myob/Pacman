using PacmanLibrary.Enums;

namespace PacmanLibrary.Interfaces
{
    public interface IResponseManager
    { 
        void PrintBoard(ICell[,] cells, ICharacter character, int level);
        Direction GetDirection();
        void PrintScore(int score);
    }
}