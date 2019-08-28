using System;
using System.Text;
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

        public Board(IPacman pacman, int totalRows, int totalCols)
        {
            Pacman = pacman;
            if (totalRows < 1 || totalCols < 1) throw new ArgumentException("Array size must be greater or equal to 1");
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
            foreach (var cell in Cells)
            {
                cell.SetState(State.Food);
            }
        }

        public void PlacePacman(int row, int column)
        {
            Pacman.SetLocation(row, column);
            Cells[row, column].SetState(State.Pacman);
        }

        public void MovePacman()
        {
            Cells[Pacman.Row, Pacman.Column].SetState(State.Empty);

            int newPacmanRow = Pacman.Row, newPacmanCol = Pacman.Column;

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

        public string BoardStateToString()
        {
            var stringBuilder = new StringBuilder();
            for (var row = 0; row < _totalRows; row++)
            {
                for (var col = 0; col < _totalCols; col++)
                {
                    var state = Cells[row, col].State;
                    switch (state)
                    {
                        case State.Empty:
                            stringBuilder.Append("   ");
                            break;
                        case State.Food:
                            stringBuilder.Append(" . ");
                            break;
                        case State.Pacman:
                            switch (Pacman.Direction)
                            {
                                case Direction.Up:
                                    stringBuilder.Append(" v ");
                                    break;
                                case Direction.Down:
                                    stringBuilder.Append(" ^ ");
                                    break;
                                case Direction.Left:
                                    stringBuilder.Append(" > ");
                                    break;
                                case Direction.Right:
                                    stringBuilder.Append(" < ");
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}