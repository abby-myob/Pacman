using System;
using PacmanLibrary;

namespace PacmanConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new Board(new Pacman(Direction.Down), 40,40));
            
            game.Play();
        }
    }
}