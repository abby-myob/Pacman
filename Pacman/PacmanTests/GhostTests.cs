using PacmanLibrary;
using PacmanLibrary.Enums;
using Xunit;

namespace PacmanTests
{
    public class GhostTests
    {
        [Theory]
        [InlineData(Direction.Up, Direction.Down)]
        [InlineData(Direction.Down, Direction.Down)]
        [InlineData(Direction.Up, Direction.Left)]
        [InlineData(Direction.Right, Direction.Right)]
        public void check_setDirection_updates_ghosts_direction_property(Direction init, Direction change)
        {
            // Arrange
            var ghost = new Ghost(init);

            // Act
            ghost.SetDirection(change);

            // Assert
            Assert.Equal(change, ghost.Direction);
        }

        [Theory]
        [InlineData(Direction.Up, Direction.Down, Direction.Right)]
        [InlineData(Direction.Left, Direction.Down, Direction.Right)]
        [InlineData(Direction.Up, Direction.Down, Direction.Down)]
        [InlineData(Direction.Up, Direction.Down, Direction.Up)]
        public void change_ghost_direction_twice(Direction init, Direction firstChange, Direction change)
        {
            // Arrange
            var ghost = new Ghost(init);
            ghost.SetDirection(firstChange);

            // Act
            ghost.SetDirection(change);

            // Assert
            Assert.Equal(change, ghost.Direction);
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(0,10)]
        [InlineData(20,15)]
        public void checking_setLocation_will_set_row_and_col_of_ghost_object(int row, int col)
        {
            // Arrange
            var ghost = new Ghost(Direction.Down);
            
            // Act 
            ghost.SetLocation(row, col);
            
            // Assert
            Assert.Equal(row, ghost.Row);
            Assert.Equal(col, ghost.Column);
        }
    }
}