using System.Configuration;
using PacmanLibrary;
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
        public void initialise_pacman(Direction init, Direction change)
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
        public void set_Location_of_pacman_check_it_works(int row, int col)
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