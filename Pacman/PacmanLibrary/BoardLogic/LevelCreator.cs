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
                case 1:
                    return CreateLevelOne();
                case 2:
                    return CreateLevelTwo();
                default:
                    return CreateLevelOne();
            } 
        }
        private ICell[,] CreateLevelOne()
        {
            var level = new[,]
            {
                {1, 0, 1, 1, 0, 1},
                {1, 0, 0, 0, 0, 1}, 
                {1, 0, 2, 0, 0, 1}, 
                {1, 0, 1, 1, 0, 1},  
            };

            return GenerateCellsArrayForLevel(level);
        }

        private ICell[,] CreateLevelTwo()
        {
            var level = new[,]
            {
                {1, 1, 0, 1, 1, 1},
                {1, 0, 0, 0, 0, 1}, 
                {1, 1, 2, 1, 0, 1}, 
                {1, 0, 0, 1, 0, 1}, 
                {1, 0, 1, 1, 0, 1}, 
                {1, 0, 0, 0, 0, 1}, 
                {1, 1, 0, 1, 1, 1}, 
            };

            return GenerateCellsArrayForLevel(level);
        }

        private ICell[,] GenerateCellsArrayForLevel(int[,] level)
        {
            var rows = level.GetLength(0);
            var cols = level.GetLength(1);
            var cells = new ICell[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    switch (level[i, j])
                    {
                        case 0:
                            cells[i, j] = new Cell(State.Food);
                            break;
                        case 1:
                            cells[i, j] = new Cell(State.Wall);
                            break;
                        case 2:
                            cells[i, j] = new Cell(State.Pacman);
                            PacmanCol = i;
                            PacmanRow = j;
                            break;
                    }
                }
            }

            return cells;
        } 
    }
}