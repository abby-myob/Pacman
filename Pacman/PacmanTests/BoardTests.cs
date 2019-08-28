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
        public void SetUpBoardWithEmpty()
        {
            // Arrange
            var pacman = new Pacman(Direction.Up); 
            
            // Act
            var board = new Board(pacman, 2, 2);
            
            // Assert
            foreach (var cell in board.Cells)
            {
                Assert.Equal(State.Empty, cell.State);
            }
        }          
        
        [Fact]
        public void SetUpBoard()
        {
            // Arrange
            var pacman = new Pacman(Direction.Up); 

            var board = new Board(pacman, 2, 2);
 
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
            var board = new Board(pacman, 2, 2);
            board.Initialise();
 
            // Act
            board.PlacePacman(0,0);
             
            // Assert
            Assert.Equal(State.Pacman, board.Cells[0,0].State);
        }
    }
}