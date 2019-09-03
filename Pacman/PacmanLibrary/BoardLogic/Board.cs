using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;

namespace PacmanLibrary.BoardLogic
{
    public class Board : IBoard
    {  
        public ICell[,] Cells { get; private set; } 
        private readonly ILevelCreator _levelCreator;
        private readonly IMover _pacmanMovement;  

        public Board(ILevelCreator levelCreator, IMover pacmanMovement)
        {
            _levelCreator = levelCreator;
            _pacmanMovement = pacmanMovement; 
        }

        public void SetUpLevel(int level)
        {
            Cells = _levelCreator.CreateLevel(level);
            _pacmanMovement.Character.SetLocation(_levelCreator.PacmanRow, _levelCreator.PacmanCol);
        }

        public void BoardTick()
        {
            Cells = _pacmanMovement.MoveCharacter(Cells);
        }

        public void SetPacmanDirection(Direction direction)
        {
            if (_pacmanMovement.CanCharacterMoveHere(direction, Cells))
            {
                _pacmanMovement.Character.SetDirection(direction);
            }
        }
        
        public Direction GetPacmanDirection()
        {
            return _pacmanMovement.Character.Direction;
        }
    }
}