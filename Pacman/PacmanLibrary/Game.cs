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
                _board.Initialise(level);
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
            _board.MoveGhost();
            _board.MovePacman(); 
            UpdateScore();
            _responseManager.PrintBoard(_board.Cells, _board.Pacman, _level);
            _responseManager.PrintScore(_score);
        }

        private void UpdateScore()
        {
            if (_board.IsNextCellFood) _score += 10;
        }

        private void UpdatePacmanDirection()
        {
            var direction = _responseManager.GetDirection();
            switch (direction)
            {
                case Direction.Up:
                    if (_board.CanTheyMoveThisDirection(Direction.Up, _board.Pacman)) _board.Pacman.SetDirection(Direction.Up);
                    break;
                case Direction.Down:
                    if (_board.CanTheyMoveThisDirection(Direction.Down, _board.Pacman))
                        _board.Pacman.SetDirection(Direction.Down);
                    break;
                case Direction.Left:
                    if (_board.CanTheyMoveThisDirection(Direction.Left, _board.Pacman))
                        _board.Pacman.SetDirection(Direction.Left);
                    break;
                case Direction.Right:
                    if (_board.CanTheyMoveThisDirection(Direction.Right, _board.Pacman))
                        _board.Pacman.SetDirection(Direction.Right);
                    break;
                case Direction.Null:
                    break;
            }
        } 
    } 
}