using PacmanLibrary.Enums;

namespace PacmanLibrary.Interfaces
{
    public interface IBoard
    {
        ICell[,] Cells { get; }
        IPacman Pacman { get; }
        bool IsNextCellFood { get; }
        void Initialise();
        void PlacePacman(int row, int col); 
        void MovePacman();
        bool CanPacmanMoveThisDirection(Direction direction);
    }
}