using System;
using System.Linq;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces; 
using System.Timers;
using Timer = System.Timers.Timer;

namespace PacmanLibrary
{
    public class Game
    {
        private readonly IBoard _board;
        private IPrinter _printer;

        public Game(IBoard board)
        {
            _board = board; 
        }

        public void Play(IPrinter printer)
        {
            _printer = printer;
            _board.Initialise();
            _board.PlacePacman(0,0);

            while(!IsGameOver())
            { 



                var aTimer = new Timer{Interval = 3000};
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;

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

                 
            }
            
            

        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _board.MovePacman();
            _printer.PrintBoard(_board.Cells, _board.Pacman);
        }

        public bool IsGameOver()
        { 
            return _board.Cells.Cast<ICell>().All(cell => cell.State != State.Food);
        }
    }
}