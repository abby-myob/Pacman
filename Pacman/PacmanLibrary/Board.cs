using System;
using System.Text;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;

namespace PacmanLibrary
{
    public class Board : IBoard
    {
        private readonly IPacman _pacman;
        public ICell[,] Cells { get; }
        private readonly int _totalRows;
        private readonly int _totalCols;

        public Board(IPacman pacman, int totalRows, int totalCols)
        {
            _pacman = pacman;
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
            _pacman.SetLocation(row, column);
            Cells[row, column].SetState(State.Pacman);
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
                            switch (_pacman.Direction)
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

        public void MovePacman()
        {
            Cells[_pacman.Row, _pacman.Column].SetState(State.Empty);

            int newPacmanRow = _pacman.Row, newPacmanCol = _pacman.Column;

            switch (_pacman.Direction)
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
             
            PlacePacman(newPacmanRow, newPacmanCol); 
        }
    }
}