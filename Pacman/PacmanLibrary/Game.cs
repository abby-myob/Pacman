using System;
using PacmanLibrary.Interfaces;

namespace PacmanLibrary
{
    public class Game
    {
        private readonly IBoard _board;

        public Game(IBoard board)
        {
            _board = board; 
        }

        public void Play()
        {
            _board.Initialise();
            _board.PlacePacman(0,0);

            Console.WriteLine(_board.BoardStateToString());

            _board.MovePacman();
            Console.WriteLine(_board.BoardStateToString());

        }
    }
}