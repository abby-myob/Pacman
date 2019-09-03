using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;

namespace PacmanLibrary.BoardLogic
{
    public class LevelCreator : ILevelCreator
    {
        public int PacmanRow { get; private set; }
        public int PacmanCol { get; private set; }
        public ICell[,] CreateLevel(int level)
        {
            switch (level)
            {
                case 0:
                    break;
                case 1:
                    return CreateLevelOne();
                case 2:
                    return CreateLevelTwo();
                default:
                    return CreateLevelOne();
            }

            return CreateLevelOne();
        }

        private ICell[,] CreateLevelTwo()
        {
            var rows = 5;
            var cols = 7;
            var cells = new ICell[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    switch (i)
                    {
                        case 0:
                        case 4:
                            cells[i, j] = new Cell(State.Wall);
                            break;
                        case 1:
                        case 3:
                        {
                            if (j == 0 || j == 6)
                            {
                                cells[i, j] = new Cell(State.Wall);
                            }
                            else
                            {
                                cells[i, j] = new Cell(State.Food);
                            }

                            break;
                        }

                        case 2 when (j > 1 && j < 5):
                            cells[i, j] = new Cell(State.Wall);
                            break;
                        default:
                            cells[i, j] = new Cell(State.Food);
                            break;
                    }
                }
            }
            PacmanCol = 1;
            PacmanRow = 1;
            cells[PacmanRow,PacmanCol].SetState(State.Pacman);


            return cells;
        }

        private ICell[,] CreateLevelOne()
        {
            var rows = 5;
            var cols = 5;
            var cells = new ICell[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (i == 0 || i == rows - 1)
                    {
                        cells[i, j] = new Cell(State.Wall);
                    }
                    else if (j == 0 || j == cols - 1)
                    {
                        cells[i, j] = new Cell(State.Wall);
                    }
                    else
                    {
                        cells[i, j] = new Cell(State.Food);
                    }
                }
            } 
            PacmanCol = 1;
            PacmanRow = 1;
            cells[PacmanRow,PacmanCol].SetState(State.Pacman);

            return cells;
        }
    }
}