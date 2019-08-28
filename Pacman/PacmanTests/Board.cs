using PacmanLibrary;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;

namespace PacmanTests
{
    public class Board
    {
        private readonly IPacman _pacman;
        public ICell[,] Cells { get; }
        private readonly int _rows;
        private readonly int _cols; 

        public Board(IPacman pacman, int rows, int cols)
        {
            _pacman = pacman;
            
            _rows = rows;
            _cols = cols;  
            Cells = new ICell[rows,cols];
            SetUpCells(); 
        }

        private void SetUpCells()
        {
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _cols; j++)
                {
                    Cells[i,j] = new Cell(State.Empty);
                }
            }
        }

        public void Initialise()
        {
            foreach (var cell in Cells)
            {
                cell.SetState(State.Food);
            }
        }

        public void PlacePacman(int row, int col)
        {
            Cells[row,col].SetState(State.Pacman);
        }
    }
}