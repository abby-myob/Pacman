using Xunit;

namespace PacmanTests
{
    public class PacmanTests
    {
        [Fact]
        public void initialise_pacman()
        {
            // Arrange
            var pacman = new Pacman(Direction.Up);
            
            // Act
            //pacman.SetDirecion(Direction.Down);

            // Assert
            Assert.Equal(Direction.Down, pacman.Direction);
        }
    }

    public class Pacman
    {
        public Direction Direction { get; private set; }

        public Pacman(Direction direction)
        {
            Direction = direction;
        }
        
    }

    public enum Direction
    {
        Up,
        Down,
        Left, 
        Right
    }
}