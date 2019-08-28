namespace PacmanLibrary.Interfaces
{
    public interface IBoard
    {
        ICell[,] Cells { get; }
        IPacman Pacman { get; }
        void Initialise();
        void PlacePacman(int row, int col);
        string BoardStateToString();
        void MovePacman();
    }
}