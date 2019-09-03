using PacmanLibrary.Enums;

namespace PacmanLibrary.Interfaces
{
    public interface ICharacter
    {
        Direction Direction { get; }
        int Row { get; }
        int Column { get; }
        State CurrentCellState { get; }
        State CharacterState { get; }
        void SetDirection(Direction newDirection);
        void SetLocation(int row, int column);
        void SetCurrentCellState(State state);
    }
}