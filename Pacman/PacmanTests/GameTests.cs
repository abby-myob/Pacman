using Moq;
using PacmanLibrary;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;
using Xunit;

namespace PacmanTests
{
    public class GameTests
    {
        [Fact]
        public void onSetUp_of_board_initialise_should_be_called_once()
        {
            // Arrange
            var boardMock = new Mock<IBoard>();
            var game = new Game(boardMock.Object);
            
            // Act
            game.Play();
            
            // Assert
            boardMock.Verify(b => b.Initialise(), Times.Once);
        }        
        
        [Fact]
        public void onSetUp_of_board_placePacman_should_be_called_once()
        {
            // Arrange
            var boardMock = new Mock<IBoard>();
            var game = new Game(boardMock.Object);
            
            // Act
            game.Play();
            
            // Assert
            boardMock.Verify(b => b.PlacePacman(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Fact]  
        public void is_Game_over_check()
        {
            // Arrange
            var pacman = new Pacman(Direction.Down);
            var board = new Board(pacman, 20,20);
            board.PlacePacman(2,2); 
            var game = new Game(board);

            // Act
            var isGameOver = game.IsGameOver();

            // Assert
            Assert.Equal(true, isGameOver);
        }
    }
}