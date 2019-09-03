using PacmanLibrary;
using PacmanLibrary.BoardLogic;
using PacmanLibrary.Enums;

namespace PacmanConsole
{
    internal static class Program
    {
        private static void Main()
        {
            var game = new Game(new Board(new LevelCreator(), new Mover(new Pacman(Direction.Down))));
            
            game.Play(new ConsoleResponseManager());
        }
    }
}