using System;
using PacmanLibrary.Interfaces;
using System.Linq;

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
        }

        public bool IsGameOver()
        {
            //_board.Cells.Count(c => c.State ==);

            return true;
        }
    }
}