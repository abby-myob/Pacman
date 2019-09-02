using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;

namespace PacmanLibrary
{
    public class Pacman : ICharacter
    {
        public Direction Direction { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }
        public State CurrentCellState { get; }

        public Pacman(Direction direction)
        {
            Direction = direction;
        }

        public void SetDirection(Direction newDirection)
        {
            Direction = newDirection;
        }

        public void SetLocation(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void SetCurrentCellState(State state)
        {
            throw new System.NotImplementedException();
        }
    }
}