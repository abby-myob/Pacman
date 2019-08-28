using PacmanLibrary.Enums;

namespace PacmanLibrary.Interfaces
{
    public interface ICell
    {
        State State { get; }
        void SetState(State state);
    }
}