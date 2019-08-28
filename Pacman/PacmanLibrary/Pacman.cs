using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;

namespace PacmanLibrary
{
    public class Pacman : IPacman
    {
        public Direction Direction { get; private set; }

        public Pacman(Direction direction)
        {
            Direction = direction;
        }

        public void SetDirection(Direction newDirection)
        {
            Direction = newDirection;
        }
    }
}