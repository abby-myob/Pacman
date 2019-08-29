using PacmanLibrary.Enums;

namespace PacmanLibrary.Interfaces
{
    public interface IPacman
    {
        Direction Direction { get; }
        int Row { get; }
        int Column { get; }
        void SetDirection(Direction newDirection);
        void SetLocation(int row, int column);
    }
}