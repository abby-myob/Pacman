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

        public void Play()
        {
            _board.Initialise();
            _board.PlacePacman(0,0);

            for (int i = 0; i < 80; i++)
            {
                Console.WriteLine(_board.BoardStateToString());
                _board.MovePacman();
                
//                var fade1 = 1000;
//                while (fade1 != -1)
//                {
//                    await Task.Delay(30);
//                    fade1--;
//                }
                
                var ch = Console.ReadKey(false).Key;
                switch(ch)
                {
                    case ConsoleKey.UpArrow:
                        _board.Pacman.SetDirection(Direction.Up);
                        Console.WriteLine(_board.BoardStateToString());
                        break;
                    case ConsoleKey.DownArrow:
                        _board.Pacman.SetDirection(Direction.Down);
                        Console.WriteLine(_board.BoardStateToString());
                        break;
                    case ConsoleKey.LeftArrow:
                        _board.Pacman.SetDirection(Direction.Left);
                        Console.WriteLine(_board.BoardStateToString());
                        break;
                    case ConsoleKey.RightArrow:
                        _board.Pacman.SetDirection(Direction.Right);
                        Console.WriteLine(_board.BoardStateToString());
                        break;
                }
            }
        }

        public bool IsGameOver()
        { 
            return _board.Cells.Cast<ICell>().All(cell => cell.State != State.Food);
        }
    }
}