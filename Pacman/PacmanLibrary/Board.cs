using System;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;

namespace PacmanLibrary
{
    public class Board : IBoard
    {
        public IPacman Pacman { get; }
        public ICell[,] Cells { get; }
        private readonly int _totalRows;
        private readonly int _totalCols;
        public bool IsNextCellFood { get; private set; }

        public Board(IPacman pacman, int totalRows, int totalCols)
        {
            Pacman = pacman;
            if (totalRows < 1 || totalCols < 1)
                throw new ArgumentException(Constants.Constants.ExceptionForRowsAndCols);
            _totalRows = totalRows;
            _totalCols = totalCols;
            Cells = new ICell[totalRows, totalCols];
            SetUpCells();
        }

        private void SetUpCells()
        {
            for (var i = 0; i < _totalRows; i++)
            {
                for (var j = 0; j < _totalCols; j++)
                {
                    Cells[i, j] = new Cell(State.Empty);
                }
            }
        }

        public void Initialise()
        {
//            foreach (var cell in Cells)
//            {
//                cell.SetState(State.Food);
//            }

            for (var i = 0; i < _totalRows; i++)
            {
                for (var j = 0; j < _totalCols; j++)
                {
                    if (i == 0 || i == _totalRows - 1)
                    {
                        Cells[i, j] = new Cell(State.Wall);
                    }
                    else
                    {
                        Cells[i, j] = new Cell(State.Food);
                    }
                }
            }
        }

        public void PlacePacman(int row, int column)
        {
            Pacman.SetLocation(row, column);
            Cells[row, column].SetState(State.Pacman);
        }

        public void MovePacman()
        {
            var newPacmanRow = Pacman.Row;
            var newPacmanCol = Pacman.Column;

            switch (Pacman.Direction)
            {
                case Direction.Down:
                    newPacmanRow++;
                    break;
                case Direction.Up:
                    newPacmanRow--;
                    break;
                case Direction.Left:
                    newPacmanCol--;
                    break;
                case Direction.Right:
                    newPacmanCol++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            newPacmanRow = CheckInBounds(true, newPacmanRow);
            newPacmanCol = CheckInBounds(false, newPacmanCol);

            
            IsNextCellFood = Cells[newPacmanRow, newPacmanCol].State == State.Food;

            if (Cells[newPacmanRow, newPacmanCol].State == State.Wall) return;

            Cells[Pacman.Row, Pacman.Column].SetState(State.Empty); 
            PlacePacman(newPacmanRow, newPacmanCol);
        }

        private int CheckInBounds(bool isRow, int index)
        {
            if (isRow)
            {
                if (index >= _totalRows) return 0;
                if (index < 0) return _totalRows - 1;
            }
            else
            {
                if (index >= _totalCols) return 0;
                if (index < 0) return _totalCols - 1;
            }

            return index;
        }
    }
}