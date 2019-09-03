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
            if (CanCharacterMoveHere(Character.Direction, cells) == false)
            {
                return cells;
            }
            
            var newCoord = NextCellCoords(Character.Direction);

            var newPacmanRow = CheckInBounds(true, newCoord[0], cells);
            var newPacmanCol = CheckInBounds(false, newCoord[1], cells);
            

            switch (Character.CharacterState)
            { 
                case State.Pacman:
                    cells[Character.Row, Character.Column].SetState(State.Empty);
                    break;
                case State.Ghost:
                    cells[Character.Row, Character.Column].SetState(Character.CurrentCellState);
                    break;
            }
 
            cells = PlaceCharacter(newPacmanRow, newPacmanCol, cells); 
            
            return cells;
        }

        public bool CanCharacterMoveHere(Direction direction, ICell[,] cells)
        {
            var coord = NextCellCoords(direction);
            return cells[coord[0], coord[1]].State != State.Wall;
        } 

        private int[] NextCellCoords(Direction direction)
        {
            var newCharacterRow = Character.Row;
            var newCharacterColumn = Character.Column;

            switch (direction)
            {
                case Direction.Down:
                    newCharacterRow++;
                    break;
                case Direction.Up:
                    newCharacterRow--;
                    break;
                case Direction.Left:
                    newCharacterColumn--;
                    break;
                case Direction.Right:
                    newCharacterColumn++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new[] {newCharacterRow, newCharacterColumn};
        }
        
        private int CheckInBounds(bool isRow, int index, ICell[,] cells)
        {
            if (isRow)
            {
                if (index >= cells.GetLength(0)) return 0;
                if (index < 0) return cells.GetLength(1) - 1;
            }
            else
            {
                if (index >= cells.GetLength(0)) return 0;
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