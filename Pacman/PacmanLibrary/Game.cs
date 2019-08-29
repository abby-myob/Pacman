using System.Linq;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;
using System.Timers;
using System.Xml.Schema;

namespace PacmanLibrary
{
    public class Game
    {
        private readonly IBoard _board;
        private IResponseManager _responseManager;
        public int Score;

        public Game(IBoard board)
        {
            _board = board;
            Score = 0;
            _board.Initialise();
            _board.PlacePacman(0, 0);
        }

        public void Play(IResponseManager responseManager)
        { 
            _responseManager = responseManager;
            
            var aTimer = new Timer {Interval = 500};
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            
            while (!IsGameOver())
            {
                var direction = _responseManager.GetDirection();
                switch (direction)
                {
                    case Direction.Up:
                        _board.Pacman.SetDirection(Direction.Up);
                        break;
                    case Direction.Down:
                        _board.Pacman.SetDirection(Direction.Down);
                        break;
                    case Direction.Left:
                        _board.Pacman.SetDirection(Direction.Left);
                        break;
                    case Direction.Right:
                        _board.Pacman.SetDirection(Direction.Right);
                        break;
                    case Direction.Null:
                        break;
                }
            }
            
            aTimer.Stop();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _board.MovePacman();
            _responseManager.PrintBoard(_board.Cells, _board.Pacman);
        }

        public bool IsGameOver()
        {
            return _board.Cells.Cast<ICell>().All(cell => cell.State != State.Food);
        }
    }
}