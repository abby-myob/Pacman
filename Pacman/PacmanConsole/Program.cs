using PacmanLibrary;
using PacmanLibrary.Enums;

namespace PacmanConsole
{
    internal static class Program
    {
        private static void Main()
        {
            var game = new Game(new Board(new Pacman(Direction.Down), 10,10));
            
            game.Play(new ConsoleResponseManager());
        }
    }
}