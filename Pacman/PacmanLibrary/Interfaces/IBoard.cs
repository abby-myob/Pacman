namespace PacmanLibrary.Interfaces
{
    public interface IBoard
    {
        ICell[,] Cells { get; }
        void Initialise();
        void PlacePacman(int row, int col);
        string BoardStateToString();
        void MovePacman();
    }
}