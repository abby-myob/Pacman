using PacmanLibrary;
using PacmanLibrary.BoardLogic;
using PacmanLibrary.Enums;
using Xunit;

namespace PacmanTests
{
    public class PacmanTests
    {
        [Theory]
        [InlineData(Direction.Up, Direction.Down)]
        [InlineData(Direction.Down, Direction.Down)]
        [InlineData(Direction.Up, Direction.Left)]
        [InlineData(Direction.Right, Direction.Right)]
        public void check_setDirection_updates_pacman_direction_property(Direction init, Direction change)
        {
            // Arrange
            var pacman = new Pacman(init);

            // Act
            pacman.SetDirection(change);

            // Assert
            Assert.Equal(change, pacman.Direction);
        }

        [Theory]
        [InlineData(Direction.Up, Direction.Down, Direction.Right)]
        [InlineData(Direction.Left, Direction.Down, Direction.Right)]
        [InlineData(Direction.Up, Direction.Down, Direction.Down)]
        [InlineData(Direction.Up, Direction.Down, Direction.Up)]
        public void change_pacman_direction_twice(Direction init, Direction firstChange, Direction change)
        {
            // Arrange
            var pacman = new Pacman(init);
            pacman.SetDirection(firstChange);

            // Act
            pacman.SetDirection(change);

            // Assert
            Assert.Equal(change, pacman.Direction);
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(0,10)]
        [InlineData(20,15)]
        public void checking_setLocation_will_set_row_and_col_of_pacman_object(int row, int col)
        {
            // Arrange
            var pacman = new Pacman(Direction.Down);
            
            // Act 
            pacman.SetLocation(row, col);
            
            // Assert
            Assert.Equal(row, pacman.Row);
            Assert.Equal(col, pacman.Column);
        }
    }
}