using Moq;
using PacmanLibrary;
using PacmanLibrary.BoardLogic;
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
            boardMock.Verify(b => b.SetUpLevel(It.IsAny<int>()), Times.Once);
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
            var board = new Board(pacman, 3, 3); 
            var game = new Game(board);
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    board.Cells[i,j].SetState(State.Wall); 
                }
            } 


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
            var board = new Board(pacman, 20, 20);
            board.PlacePacman(2, 2);
            board.SetUpLevel(0);
            var game = new Game(board);
            for (var i = 0; i < 20; i++)
            {
                for (var j = 0; j < 20; j++)
                {
                    if(j == 0) board.Cells[i,j].SetState(State.Wall);
                    if(j > 0) board.Cells[i,j].SetState(State.Food);
                }
            } 

            // Act
            var isGameOver = game.IsGameOver();

            // Assert
            Assert.False(isGameOver);
        }

//        [Theory] 
//        [InlineData(Direction.Up, 2, 2, Direction.Left)] 
//        [InlineData(Direction.Up, 5, 2, Direction.Left)] 
//        public void when_pacman_tries_to_turn_into_the_direction_of_a_wall_he_cant(Direction expected, int row, int col, Direction input)
//        {
//            // Arrange
//            var pacman = new Pacman(expected);
//            var board = new Board(pacman, row, col);
//
//            var responseMock = new Mock<IResponseManager>();
//            responseMock.Setup(c => c.GetDirection()).Returns(input);
//
//            var game = new Game(board);
//            for (var i = 0; i < row; i++)
//            {
//                for (var j = 0; j < col; j++)
//                {
//                    if(j == 0) board.Cells[i,j].SetState(State.Wall);
//                    if(j > 0) board.Cells[i,j].SetState(State.Food);
//                }
//            }
//
//            board.PlacePacman(0, 1);
//            game.Play(responseMock.Object);
//
//            // Act
//            var direction = game.Board.Pacman.Direction;
//
//            // Assert
//            Assert.Equal(expected, direction);
//        }
    }
}