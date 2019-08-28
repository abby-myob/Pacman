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
        private readonly int _rows;
        private readonly int _cols;

        public Board(IPacman pacman, int rows, int cols)
        {
            _pacman = pacman;
            if (rows < 1 || cols < 1) throw new ArgumentException("Array size must be greater or equal to 1");
            _rows = rows;
            _cols = cols;
            Cells = new ICell[rows, cols];
            SetUpCells();
        }

        private void SetUpCells()
        {
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _cols; j++)
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

        public void PlacePacman(int row, int col)
        {
            Cells[row, col].SetState(State.Pacman);
        }

        public string BoardStateToString()
        {
            var stringBuilder = new StringBuilder();
            for (var row = 0; row < _rows; row++)
            {
                for (var col = 0; col < _cols; col++)
                {
                    var state = Cells[row, col].State;
                    switch (state)
                    {
                        case State.Empty:
                            stringBuilder.Append(" ");
                            break;
                        case State.Food:
                            stringBuilder.Append(".");
                            break;
                        case State.Pacman:
                            switch (_pacman.Direction)
                            {
                                case Direction.Up:
                                    stringBuilder.Append("v");
                                    break;
                                case Direction.Down:
                                    stringBuilder.Append("^");
                                    break;
                                case Direction.Left:
                                    stringBuilder.Append(">");
                                    break;
                                case Direction.Right:
                                    stringBuilder.Append("<");
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