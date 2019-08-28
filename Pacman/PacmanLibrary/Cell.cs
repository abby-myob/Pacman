using PacmanLibrary.Enums;

namespace PacmanLibrary
{
    public class Cell
    {
        public CellState CellState { get; private set; }

        public Cell(CellState cellState)
        {
            CellState = cellState;
        }

        public void SetState(CellState cellState)
        {
            CellState = cellState;
        }
    }
}