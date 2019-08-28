using PacmanLibrary;
using PacmanLibrary.Enums;
using Xunit;

namespace PacmanTests
{
    public class CellTests
    {
        [Theory]
        [InlineData(State.Food, State.Empty)]
        [InlineData(State.Empty, State.Empty)]
        [InlineData(State.Empty, State.Food)]
        [InlineData(State.Food, State.Food)]
        public void init_Cell(State init, State change)
        {
            // Arrange 
            var cell = new Cell(init);

            // Act
            cell.SetState(change);

            // Assert
            Assert.Equal(change, cell.State);
        }
    }
}