using PacmanLibrary.Enums;

namespace PacmanLibrary
{
    public interface ICell
    {
        State State { get; }
        void SetState(State state);
    }
}