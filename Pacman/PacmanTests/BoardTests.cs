using System.Collections.Generic;
using PacmanLibrary;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;
using Xunit;

namespace PacmanTests
{
    public class BoardTests
    {
        [Fact]
        public void SetUpBoard()
        {
            // Arrange
            var pacman = new Pacman(Direction.Up);
            var cells = new ICell[,]
                {
                    {new Cell(State.Empty), new Cell(State.Empty)},
                    {new Cell(State.Empty), new Cell(State.Empty)}
                };

            var board = new Board(pacman, cells, 2, 2);
 
            // Act
            board.Initialise();

            // Assert
            foreach (var cell in board.Cells)
            {
                Assert.Equal(State.Food, cell.State);
            }
        }        
        
        [Fact]
        public void SetUpPacman()
        {
            // Arrange
            var pacman = new Pacman(Direction.Up);
            var cells = new ICell[,]
            {
                {new Cell(State.Empty), new Cell(State.Empty)},
                {new Cell(State.Empty), new Cell(State.Empty)}
            };
            var board = new Board(pacman, cells, 2, 2);
            board.Initialise();
 
            // Act
            board.PlacePacman(0,0);
             
            // Assert
            Assert.Equal(State.Pacman, board.Cells[0,0].State);
        }
    }

    public class Board
    {
        private readonly IPacman _pacman;
        public readonly ICell[,] Cells;
        private readonly int _rows;
        private readonly int _cols; 

        public Board(IPacman pacman, ICell[,] cells, int rows, int cols)
        {
            _pacman = pacman;
            Cells = cells;
            _rows = rows;
            _cols = cols;
        } 
        
        public void Initialise()
        {
            foreach (var cell in Cells)
            {
                cell.SetState(State.Food);
            }
        }

        public void PlacePacman(int row, int col)
        {
           Cells[row,col].SetState(State.Pacman);
        }
    }
}