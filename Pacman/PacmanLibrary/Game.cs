using System.Linq;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;
using System.Timers;

namespace PacmanLibrary
{
    public class Game
    {
        public readonly IBoard Board; 
        private IResponseManager _responseManager;
        private int _score;
        private int _level;

        public Game(IBoard board)
        {
            Board = board; 
            _score = 0;
            Board.Initialise(0);
            Board.PlacePacman(1, 1);
        }

        public void Play(IResponseManager responseManager)
        {
            _responseManager = responseManager;

            for (var level = 1; level <= 2; level++)
            {
                _level = level;
                Board.Initialise(level);
                Loop();
            }
            
        }

        private void Loop()
        { 
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
                        if(Board.CanPacmanMoveThisDirection(Direction.Up)) Board.Pacman.SetDirection(Direction.Up);
                        break;
                    case Direction.Down:
                        if(Board.CanPacmanMoveThisDirection(Direction.Down)) Board.Pacman.SetDirection(Direction.Down);
                        break;
                    case Direction.Left:
                        if(Board.CanPacmanMoveThisDirection(Direction.Left)) Board.Pacman.SetDirection(Direction.Left);
                        break;
                    case Direction.Right:
                        if(Board.CanPacmanMoveThisDirection(Direction.Right)) Board.Pacman.SetDirection(Direction.Right);
                        break;
                    case Direction.Null:
                        break;
                }
            }

            aTimer.Stop(); 
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Board.MovePacman();
            if (Board.IsNextCellFood) _score += 10;
            _responseManager.PrintBoard(Board.Cells, Board.Pacman, _level);
            _responseManager.PrintScore(_score);
        }

        public bool IsGameOver()
        { 
            return Board.Cells.Cast<ICell>().All(cell => cell.State != State.Food);
        }
    } 
}