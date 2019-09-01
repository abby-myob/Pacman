using System;
using PacmanLibrary;
using PacmanLibrary.Enums;
using Xunit;

namespace PacmanTests
{
    public class BoardTests
    {
        [Fact]
        public void When_creation_of_board_object_all_cells_should_be_empty()
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

        [Theory]
        [InlineData(2, 3)]
        [InlineData(10, 10)]
        [InlineData(200, 10)]
        public void Cells_array_should_have_correct_rows_and_cols_length_from_input(int rows, int cols)
        {
            // Arrange
            var pacman = new Pacman(Direction.Up);

            // Act
            var board = new Board(pacman, rows, cols);

            // Assert
            Assert.Equal(rows, board.Cells.GetLength(0));
            Assert.Equal(cols, board.Cells.GetLength(1));
        }

        [Theory]
        [InlineData(0, 4)]
        [InlineData(0, -10)]
        [InlineData(20, -10)]
        public void Cells_array_should_throw_exception_when_invalid_rows_and_cols_are_inputted(int rows, int cols)
        {
            // Arrange
            var pacman = new Pacman(Direction.Up);

            //act
            void Act() => new Board(pacman, rows, cols);
            //assert
            Assert.Throws<ArgumentException>(Act);
        }

        [Fact]
        public void When_pacman_is_placed_he_should_be_placed_at_row_col_in_cells_array()
        {
            // Arrange
            var pacman = new Pacman(Direction.Up);
            var board = new Board(pacman, 2, 2);
            board.Initialise(0);

            // Act
            board.PlacePacman(0, 0);

            // Assert
            Assert.Equal(State.Pacman, board.Cells[0, 0].State);
        }

        [Fact]  
        public void if_direction_of_pacman_is_null_then_return_exception_out_of_range()
        {
            // Arrange
            var pacman = new Pacman(Direction.Down);
            var board = new Board(pacman, 2, 2);
            board.Initialise(0);
            board.PlacePacman(1, 0);
            board.Pacman.SetDirection(Direction.Null);

            // Act
            void Act() => board.MovePacman();
            
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(Act);
        } 
        
        [Theory]  
        [InlineData(2, 2, Direction.Up, 0,0,1,0)]
        [InlineData(2, 2, Direction.Left, 0,0,0,1)]
//        [InlineData(2, 2, Direction.Down, 1,1,0,1)]
//        [InlineData(2, 2, Direction.Right, 1,1,1,0)]
        public void move_pacman_and_check_it_overlaps_the_board(int rows, int cols,
            Direction direction, int pacRow, int pacCol, int expectedRow, int expectedCol)
        {
            // Arrange
            var pacman = new Pacman(direction);
            var board = new Board(pacman, rows, cols);
            board.Initialise(0);
            foreach (var cell in board.Cells)
            {
                cell.SetState(State.Food);
            } 
            board.PlacePacman(pacRow, pacCol);

            // Act
            board.MovePacman();

            // Assert
            Assert.Equal(expectedRow, board.Pacman.Row);
            Assert.Equal(expectedCol, board.Pacman.Column);
        }
        
        [Theory]  
        [InlineData(2, 2, 2, 2)] 
        [InlineData(2, 10, 20, 2)] 
        public void if_you_place_pacman_outside_of_the_array_throw_exception(int rows, int cols, int pacRow, int pacCol)
        {
            // Arrange
            var pacman = new Pacman(Direction.Down);
            var board = new Board(pacman, rows, cols);
            board.Initialise(0);
            
            // Act
            void Act() => board.PlacePacman(pacRow, pacCol);  
            
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(Act);
        }  
        
        [Theory]  
        [InlineData(Direction.Up)] 
        [InlineData(Direction.Down)] 
        [InlineData(Direction.Left)] 
        [InlineData(Direction.Right)] 
        public void check_next_cell_is_wall_from_input_direction(Direction input)
        {
            // Arrange
            var pacman = new Pacman(Direction.Down);
            var board = new Board(pacman, 3, 3);
            board.Initialise(0);
            
            foreach (var cell in board.Cells)
            {
                cell.SetState(State.Wall);
            } 
            board.PlacePacman(1, 1);

            // Act
            bool check = board.CanPacmanMoveThisDirection(input);
            
            // Assert
            Assert.False(check);
        }
    }
}