namespace PacmanLibrary.Interfaces
{
    public interface ILevelCreator
    {
        int PacmanRow { get; }
        int PacmanCol { get; }
        ICell[,] CreateLevel(int level);
        ICell[,] GenerateCellsArrayForLevel(int[,] level);
    }
}