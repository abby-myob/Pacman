using PacmanLibrary.Enums;

namespace PacmanLibrary.Interfaces
{
    public interface IBoard
    {
        ICell[,] Cells { get; } 
        void SetUpLevel(int level);
        void BoardTick(); 
        void SetPacmanDirection(Direction up);
        Direction GetPacmanDirection(); 
    }
}