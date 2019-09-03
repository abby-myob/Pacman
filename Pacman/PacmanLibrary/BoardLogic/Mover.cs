using System;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;

namespace PacmanLibrary.BoardLogic
{
    public class Mover : IMover
    {
        public ICharacter Character { get; }

        public Mover(ICharacter character)
        {
            Character = character;
        }

        public ICell[,] MoveCharacter(ICell[,] cells)
        {
            if (CanCharacterMoveHere(Character.Direction, cells) == false) return cells;
            
            var newCoord = NextCellCoords(Character.Direction, cells); 
             
            cells[Character.Row, Character.Column].SetState(Character.CurrentCellState);

            cells = PlaceCharacter(newCoord[0], newCoord[1], cells);

            return cells;
        }

        public bool CanCharacterMoveHere(Direction direction, ICell[,] cells)
        {
            var coord = NextCellCoords(direction, cells); 
            return cells[coord[0], coord[1]].State != State.Wall;
        }

        private int[] NextCellCoords(Direction direction, ICell[,] cells)
        {
            var row = Character.Row;
            var col = Character.Column;

            switch (direction)
            {
                case Direction.Down:
                    row++;
                    break;
                case Direction.Up:
                    row--;
                    break;
                case Direction.Left:
                    col--;
                    break;
                case Direction.Right:
                    col++;
                    break; 
            }

            var newRow = CheckInBounds(true, row, cells);
            var newCol = CheckInBounds(false, col, cells);

            return new[] {newRow, newCol};
        }

        private int CheckInBounds(bool isRow, int index, ICell[,] cells)
        {
            if (isRow)
            {
                if (index >= cells.GetLength(0)) return 0;
                if (index < 0) return cells.GetLength(0) - 1;
            }
            else
            {
                if (index >= cells.GetLength(1)) return 0;
                if (index < 0) return cells.GetLength(1) - 1;
            }

            return index;
        }

        private ICell[,] PlaceCharacter(int row, int column, ICell[,] cells)
        {
            if (row < 0 || row >= cells.GetLength(0) || column < 0 || column >= cells.GetLength(1))
                throw new ArgumentOutOfRangeException(Constants.Constants.ExceptionForPlacingPacmanOffTheBoard);

            Character.SetLocation(row, column);
            Character.SetCurrentCellState(cells[row, column].State);
            cells[row, column].SetState(Character.CharacterState);

            return cells;
        }
    }
}