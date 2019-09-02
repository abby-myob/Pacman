using PacmanLibrary;
using PacmanLibrary.Enums;

namespace PacmanConsole
{
    internal static class Program
    {
        private static void Main()
        {
            var game = new Game(new Board(new Pacman(Direction.Up)));
            
            game.Play(new ConsoleResponseManager());
        }
    }
}