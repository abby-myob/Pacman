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

        [Fact]
        public void When_initialisation_method_of_board_is_called_all_cells_should_have_food()
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
        public void When_pacman_is_placed_he_should_be_placed_at_row_col_in_cells_array()
        {
            // Arrange
            var pacman = new Pacman(Direction.Up);
            var board = new Board(pacman, 2, 2);
            board.Initialise();

            // Act
            board.PlacePacman(0, 0);

            // Assert
            Assert.Equal(State.Pacman, board.Cells[0, 0].State);
        }
    }
}