using System.Reflection;
using PacmanLibrary.Interfaces;

namespace PacmanLibrary
{
    public class Pacman : IPacman
    {
        public Direction Direction { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }

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
    }
}