using PacmanLibrary.Enums;

namespace PacmanLibrary.Interfaces
{
    public interface IPacman
    {
        Direction Direction { get; }
        int Row { get; }
        int Column { get; }
        State CurrentCellState { get; }
        void SetDirection(Direction newDirection);
        void SetLocation(int row, int column);
        void SetCurrentCellState(State state);
    }
}