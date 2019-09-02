using PacmanLibrary.Enums;

namespace PacmanLibrary.Interfaces
{
    public interface IBoard
    {
        ICell[,] Cells { get; }
        ICharacter Pacman { get; }
        bool IsNextCellFood { get; }
        bool IsPacmanInGhostCell();
        void Initialise(int level);
        void PlacePacman(int row, int col); 
        void MovePacman();
        bool CanTheyMoveThisDirection(Direction direction, ICharacter being);
        void MoveGhost();
    }
}