using System;
using System.Diagnostics;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;

namespace PacmanLibrary
{
    public class Board : IBoard
    {
        public IPacman Pacman { get; }
        public IPacman Ghost { get; }
        public ICell[,] Cells { get; private set; }
        private int _totalRows;
        private int _totalCols;
        public bool IsNextCellFood { get; private set; }

        public Board(IPacman pacman, int totalRows, int totalCols)
        {
            Pacman = pacman;
            Ghost = new Ghost(Direction.Up);
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

        public void Initialise(int level)
        {
            switch (level)
            {
                case 0:
                    break;
                case 1:
                    LevelOne();
                    break;
                case 2:
                    LevelTwo();
                    break;
                default:
                    LevelOne();
                    break;
            }
        }

        private void LevelOne()
        {
            _totalRows = 6;
            _totalCols = 6;
            Cells = new ICell[_totalRows, _totalCols];
            SetUpCells();

            for (var i = 0; i < _totalRows; i++)
            {
                for (var j = 0; j < _totalCols; j++)
                {
                    if (i == 0 || i == _totalRows - 1)
                    {
                        Cells[i, j] = new Cell(State.Wall);
                    }
                    else if (j == 0 || j == _totalCols - 1)
                    {
                        Cells[i, j] = new Cell(State.Wall);
                    }
                    else
                    {
                        Cells[i, j] = new Cell(State.Food);
                    }
                }
            }

            PlacePacman(4, 4);
            PlaceGhost(2,2);
        }

        private void LevelTwo()
        {
            _totalRows = 5;
            _totalCols = 7;
            Cells = new ICell[_totalRows, _totalCols];
            SetUpCells();

            for (var i = 0; i < _totalRows; i++)
            {
                for (var j = 0; j < _totalCols; j++)
                {
                    switch (i)
                    {
                        case 0:
                        case 4:
                            Cells[i, j] = new Cell(State.Wall);
                            break;
                        case 1:
                        case 3:
                        {
                            if (j == 0 || j == 6)
                            {
                                Cells[i, j] = new Cell(State.Wall);
                            }
                            else
                            {
                                Cells[i, j] = new Cell(State.Food);
                            }

                            break;
                        }

                        case 2 when (j > 1 && j < 5):
                            Cells[i, j] = new Cell(State.Wall);
                            break;
                        default:
                            Cells[i, j] = new Cell(State.Food);
                            break;
                    }
                }
            }

            PlacePacman(1, 1);
        }

        public void PlacePacman(int row, int column)
        {
            if (row < 0 || row >= _totalRows || column < 0 || column >= _totalCols)
                throw new ArgumentOutOfRangeException(Constants.Constants.ExceptionForPlacingPacmanOffTheBoard);
            Pacman.SetLocation(row, column);
            Cells[row, column].SetState(State.Pacman);
        }

        public void MovePacman()
        {
            var newCoord = NextCellCoords(Pacman.Direction, Pacman);

            var newPacmanRow = CheckInBounds(true, newCoord[0]);
            var newPacmanCol = CheckInBounds(false, newCoord[1]);


            IsNextCellFood = Cells[newPacmanRow, newPacmanCol].State == State.Food;

            if (Cells[newPacmanRow, newPacmanCol].State == State.Wall) return;

            Cells[Pacman.Row, Pacman.Column].SetState(State.Empty);

            PlacePacman(newPacmanRow, newPacmanCol);
        }

        private int[] NextCellCoords(Direction direction, IPacman being)
        {
            var newPacmanRow = being.Row;
            var newPacmanCol = being.Column;

            switch (direction)
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

            return new[] {newPacmanRow, newPacmanCol};
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

        public bool CanTheyMoveThisDirection(Direction direction, IPacman being)
        {
            var coord = NextCellCoords(direction, being);

            return Cells[coord[0], coord[1]].State != State.Wall;
        }
        
        

        public void MoveGhost()
        {
            var random = new Random();
            var isNextCellAWall = true;
            while (isNextCellAWall)
            {
                switch (random.Next(1,5))
                {
                    case 1:
                        if (CanTheyMoveThisDirection(Direction.Down, Ghost))
                        {
                            Ghost.SetDirection(Direction.Down);
                            isNextCellAWall = false;
                        }
                        
                        break;
                    case 2:
                        if (CanTheyMoveThisDirection(Direction.Up, Ghost))
                        {
                            Ghost.SetDirection(Direction.Up);
                            isNextCellAWall = false;
                        }
                        break;
                    case 3:
                        if (CanTheyMoveThisDirection(Direction.Right, Ghost))
                        {
                            Ghost.SetDirection(Direction.Right);
                            isNextCellAWall = false;
                        }
                        break;
                    case 4:
                        if (CanTheyMoveThisDirection(Direction.Left, Ghost))
                        {
                            Ghost.SetDirection(Direction.Left);
                            isNextCellAWall = false;
                        }
                        break;
                }
            }


            var newCoord = NextCellCoords(Ghost.Direction, Ghost);

            var newGhostRow = CheckInBounds(true, newCoord[0]);
            var newGhostCol = CheckInBounds(false, newCoord[1]);

            if (Cells[newGhostRow, newGhostCol].State == State.Wall) return;

            Cells[Ghost.Row, Ghost.Column].SetState(Ghost.CurrentCellState);
            Ghost.SetCurrentCellState(Cells[newGhostRow, newGhostCol].State);
            

            PlaceGhost(newGhostRow, newGhostCol);
        }
        
        private void PlaceGhost(int row, int column)
        {
            if (row < 0 || row >= _totalRows || column < 0 || column >= _totalCols)
                throw new ArgumentOutOfRangeException(Constants.Constants.ExceptionForPlacingGhostOffTheBoard);
            Ghost.SetLocation(row, column);
            Cells[row, column].SetState(State.Ghost);
        }
    }
}