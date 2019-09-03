//using System;
//using PacmanLibrary;
//using PacmanLibrary.BoardLogic;
//using PacmanLibrary.Enums;
//using PacmanLibrary.Interfaces;
//using Xunit;
//
//namespace PacmanTests
//{
//    public class BoardTests
//    {
//        public Board Board { get; }
//        public BoardTests()
//        {
//            var pacmanFacingDown = new Pacman(Direction.Down);
//            var fakeLevelCreator = new LevelCreator();
//            var fakeMover = new Mover(pacmanFacingDown);
//            Board = new Board(fakeLevelCreator, fakeMover);
//        }
//
//        [Fact]
//        public void When_pacman_is_placed_he_should_be_placed_at_row_col_in_cells_array()
//        {
//            // Arrange
//            var pacman = new Pacman(Direction.Up);
//            var board = new Board(pacman, 2, 2);
//            board.SetUpLevel(0);
//
//            // Act
//            board.PlacePacman(0, 0);
//
//            // Assert
//            Assert.Equal(State.Pacman, board.Cells[0, 0].State);
//        }
//
//        //Exception thrown when pacman is outside of the array
//        
//    }
//}