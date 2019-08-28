using PacmanLibrary;
using PacmanLibrary.Enums;
using Xunit;

namespace PacmanTests
{
    public class CellTests
    {
        [Theory]
        [InlineData(CellState.Food, CellState.Empty)]
        [InlineData(CellState.Empty, CellState.Empty)]
        [InlineData(CellState.Empty, CellState.Food)]
        [InlineData(CellState.Food, CellState.Food)]
        public void init_Cell(CellState init, CellState change)
        {
            // Arrange 
            var cell = new Cell(init);

            // Act
            cell.SetState(change);

            // Assert
            Assert.Equal(change, cell.CellState);
        }
    }
}