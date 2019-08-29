using System.Linq;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;
using System.Timers;

namespace PacmanLibrary
{
    public class Game
    {
        public IBoard Board; 
        private IResponseManager _responseManager;
        public int Score;

        public Game(IBoard board)
        {
            Board = board; 
            Score = 0;
            Board.Initialise();
            Board.PlacePacman(0, 0);
        }

        public void Play(IResponseManager responseManager)
        {
            _responseManager = responseManager;

            Loop();
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
                        Board.Pacman.SetDirection(Direction.Up);
                        break;
                    case Direction.Down:
                        Board.Pacman.SetDirection(Direction.Down);
                        break;
                    case Direction.Left:
                        Board.Pacman.SetDirection(Direction.Left);
                        break;
                    case Direction.Right:
                        Board.Pacman.SetDirection(Direction.Right);
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
            if (Board.IsNextCellFood) Score += 10;
            _responseManager.PrintScore(Score);
            _responseManager.PrintBoard(Board.Cells, Board.Pacman);
        }

        public bool IsGameOver()
        { 
            return Board.Cells.Cast<ICell>().All(cell => cell.State != State.Food);
        }
    }



}