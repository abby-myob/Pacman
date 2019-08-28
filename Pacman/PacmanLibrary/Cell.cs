using PacmanLibrary.Enums;

namespace PacmanLibrary
{
    public class Cell : ICell
    {
        public State State { get; private set; }

        public Cell(State state)
        {
            State = state;
        }

        public void SetState(State state)
        {
            State = state;
        }
    }
}