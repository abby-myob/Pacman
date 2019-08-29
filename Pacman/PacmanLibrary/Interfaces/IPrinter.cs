namespace PacmanLibrary.Interfaces
{
    public interface IPrinter
    { 
        void PrintBoard(ICell[,] cells, IPacman pacman);
    }
}