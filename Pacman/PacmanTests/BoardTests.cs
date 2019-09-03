using System.Runtime.CompilerServices;
using FluentAssertions.Common;
using Moq;
using PacmanLibrary.BoardLogic;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;
using Xunit;

namespace PacmanTests
{
    public class BoardTests
    {
        public Board Board { get; }

        public BoardTests()
        {
//            var pacmanFacingDown = new Pacman(Direction.Down);
//            var fakeLevelCreator = new LevelCreator();
//            var fakeMover = new Mover(pacmanFacingDown);
//            Board = new Board(fakeLevelCreator, fakeMover);
        }

        // Setup level test *************************************************************************
        [Fact]
        public void Should_set_pacman_location_correctly_when_setting_up_level_1()
        {
            // Arrange
            var pacman = new Pacman(Direction.Up);
            var mover = new Mover(pacman);
            var levelCreator = new LevelCreator();
            var board = new Board(levelCreator, mover); // Refactor out this code which is duplicate here. 

            // Act
            board.SetUpLevel(1);

            // Assert
            Assert.Equal(State.Pacman, board.Cells[pacman.Row, pacman.Column].State);
        }

        [Fact]
        public void Should_set_pacman_location_correctly_when_setting_up_level_2()
        {
            // Arrange
            var pacman = new Pacman(Direction.Up);
            var mover = new Mover(pacman);
            var levelCreator = new LevelCreator();
            var board = new Board(levelCreator, mover);

            // Act
            board.SetUpLevel(2);

            // Assert
            Assert.Equal(State.Pacman, board.Cells[pacman.Row, pacman.Column].State);
        }

        // setpacmanDirection test *************************************************************************
        [Theory]
        [InlineData(Direction.Up)]
        [InlineData(Direction.Down)]
        [InlineData(Direction.Right)]
        [InlineData(Direction.Left)]
        public void Should_call_setDirection_as_Direction_is_valid_in_cells_of_food(Direction direction)
        {
            // Arrange
            var pacman = new Pacman(Direction.Up);
            pacman.SetLocation(1,1);
            var mover = new Mock<IMover>();
            mover.Setup(m => m.Character.SetLocation(1, 1)).Verifiable();
            var levelCreator = new FakeLevelCreator();
            var board = new Board(levelCreator, mover.Object);

            // Act
            board.SetUpLevel(0);
            board.SetPacmanDirection(direction);

            // Assert
            mover.Verify(m => m.Character.SetDirection(It.IsAny<Direction>()), Times.Once);
        }

        [Theory]
        [InlineData(Direction.Up)]
        [InlineData(Direction.Down)]
        [InlineData(Direction.Right)]
        [InlineData(Direction.Left)]
        public void Should_call_setDirection_as_Direction_is_valid_in_cells_of_walls(Direction direction)
        {
            // Arrange
            var pacman = new Pacman(Direction.Up);
            pacman.SetLocation(1,1);
            var mover = new Mock<IMover>();
            mover.Setup(m => m.Character.SetLocation(1, 1)).Verifiable();
            var levelCreator = new FakeLevelCreator();
            var board = new Board(levelCreator, mover.Object);

            // Act
            board.SetUpLevel(1);
            board.SetPacmanDirection(direction);

            // Assert
            mover.Verify(m => m.Character.SetDirection(It.IsAny<Direction>()), Times.Never);
        }
    }

    public class FakeLevelCreator : ILevelCreator
    {
        public int PacmanRow => 1;
        public int PacmanCol => 1;

        public ICell[,] CreateLevel(int level)
        {
            switch (level)
            {
                case 0:
                    return new ICell[,]
                    {
                        {new Cell(State.Food), new Cell(State.Food), new Cell(State.Food)},
                        {new Cell(State.Food), new Cell(State.Pacman), new Cell(State.Food)},
                        {new Cell(State.Food), new Cell(State.Food), new Cell(State.Food)},
                    };
                case 1:
                    return new ICell[,]
                    {
                        {new Cell(State.Wall), new Cell(State.Wall), new Cell(State.Wall)},
                        {new Cell(State.Wall), new Cell(State.Pacman), new Cell(State.Wall)},
                        {new Cell(State.Wall), new Cell(State.Wall), new Cell(State.Wall)},
                    };
            }

            return null;
        }

        public ICell[,] GenerateCellsArrayForLevel(int[,] level)
        {
            throw new System.NotImplementedException();
        }
    }
}