using Moq;
using PacmanConsole;
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

            // Act
            var game = new Game(boardMock.Object);
            
            // Assert
            boardMock.Verify(b => b.Initialise(), Times.Once);
        }        
        
        [Fact]
        public void onSetUp_of_board_placePacman_should_be_called_once()
        {
            // Arrange
            var boardMock = new Mock<IBoard>();
            
            // Act
            var game = new Game(boardMock.Object);

            
            // Assert
            boardMock.Verify(b => b.PlacePacman(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Fact]  
        public void isGameOver_check_should_return_true_as_all_cells_are_empty()
        {
            // Arrange
            var pacman = new Pacman(Direction.Down);
            var board = new Board(pacman, 1,1);
            board.PlacePacman(0,0); 
            var game = new Game(board); 
            
            // Act
            var isGameOver = game.IsGameOver();

            // Assert
            Assert.True(isGameOver);
        }
        
        [Fact]  
        public void is_Game_over_check_should_return_false_as_just_initialised()
        {
            // Arrange
            var pacman = new Pacman(Direction.Down);
            var board = new Board(pacman, 20,20);
            board.PlacePacman(2,2);
            board.Initialise();
            var game = new Game(board);

            // Act
            var isGameOver = game.IsGameOver();

            // Assert
            Assert.False(isGameOver);
        }
        
                
        [Fact]  
        public void check_That_Scoring_is_set_at_0()
        {
            // Arrange
            var pacman = new Pacman(Direction.Down);
            var board = new Board(pacman, 20,20); 
            var game = new Game(board);

            // Act
            var score = game.Score;

            // Assert
            Assert.Equal(0, score);
        }
    }
}