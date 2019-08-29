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
        public void initialize_cell_with_state_and_check_set_state_works(State init, State change)
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