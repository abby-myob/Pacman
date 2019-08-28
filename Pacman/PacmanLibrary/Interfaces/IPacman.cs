namespace PacmanLibrary.Interfaces
{
    public interface IPacman
    {
        Direction Direction { get; }
        void SetDirection(Direction newDirection);
    }
}