using System;
using System.Linq;
using System.Threading.Tasks;
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

        public void Play(IPrinter printer)
        {
            _board.Initialise();
            _board.PlacePacman(0,0);

            while(!IsGameOver())
            {
                printer.PrintBoard(_board.Cells, _board.Pacman);


//                var ch = Console.ReadKey(false).Key;
//                switch(ch)
//                {
//                    case ConsoleKey.UpArrow:
//                        _board.Pacman.SetDirection(Direction.Up); 
//                        break;
//                    case ConsoleKey.DownArrow:
//                        _board.Pacman.SetDirection(Direction.Down); 
//                        break;
//                    case ConsoleKey.LeftArrow:
//                        _board.Pacman.SetDirection(Direction.Left); 
//                        break;
//                    case ConsoleKey.RightArrow:
//                        _board.Pacman.SetDirection(Direction.Right); 
//                        break;
//                }
                
                _board.MovePacman();
            }
            
            printer.PrintBoard(_board.Cells, _board.Pacman);

        }

        public bool IsGameOver()
        { 
            return _board.Cells.Cast<ICell>().All(cell => cell.State != State.Food);
        }
    }
}