namespace PacmanLibrary
{
    public class Pacman
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