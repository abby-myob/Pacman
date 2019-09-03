using PacmanLibrary.Enums;

namespace PacmanLibrary.Interfaces
{
    public interface IMover
    {
        ICharacter Character { get; } 
        ICell[,] MoveCharacter(ICell[,] cells);
        bool CanCharacterMoveHere(Direction direction, ICell[,] cells); 
    }
}