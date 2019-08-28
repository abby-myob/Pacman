using System;
using System.Collections.Generic;
using System.Linq;
using PacmanLibrary.Enums;
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
        }

        public bool IsGameOver()
        { 
            return _board.Cells.Cast<ICell>().All(cell => cell.State != State.Food);
        }
    }
}