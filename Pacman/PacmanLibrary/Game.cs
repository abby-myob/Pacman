using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;
using System.Timers;

namespace PacmanLibrary
{
    public class Game
    {
        private readonly IBoard _board;
        private IResponseManager _responseManager;
        private int _score;
        private int _level;

        public Game(IBoard board)
        {
            _board = board;
            _score = 0;
        }

        public void Play(IResponseManager responseManager)
        {
            _responseManager = responseManager;

            for (var level = 1; level <= 2; level++)
            {
                _level = level;
                _board.SetUpLevel(level);
                Loop();
            }
        }

        private void Loop()
        {
            var aTimer = new Timer {Interval = 500};
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            while (true)
            {
                UpdatePacmanDirection();
            }

            aTimer.Stop();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        { 
            _board.BoardTick();
            //TODO UpdateScore();
            _responseManager.PrintBoard(_board.Cells, _board.GetPacmanDirection(), _level);
            _responseManager.PrintScore(_score);
        }

        private void UpdatePacmanDirection()
        {
            var direction = _responseManager.GetDirection();
            switch (direction)
            {
                case Direction.Up:
                    _board.SetPacmanDirection(Direction.Up);
                    break;
                case Direction.Down:
                    _board.SetPacmanDirection(Direction.Down);
                    break;
                case Direction.Left:
                    _board.SetPacmanDirection(Direction.Left);
                    break;
                case Direction.Right:
                    _board.SetPacmanDirection(Direction.Right);
                    break;
                case Direction.Null:
                    break;
            }
        }
    }
}