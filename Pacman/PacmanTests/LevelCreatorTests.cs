using PacmanLibrary.BoardLogic;
using PacmanLibrary.Enums;
using Xunit;

namespace PacmanTests
{
    public class LevelCreatorTests
    {
        private LevelCreator LevelCreator { get; }

        public LevelCreatorTests()
        {
            LevelCreator = new LevelCreator();
        }

        [Fact]
        public void method_GenerateCellsArray_creates_expected_cell_array()
        {
            // Arrange 
            var expected = new[,]
            {
                {new Cell(State.Food), new Cell(State.Food), new Cell(State.Wall)},
                {new Cell(State.Food), new Cell(State.Pacman), new Cell(State.Wall)},
            };
            var intArray = new[,]
            {
                {0, 0, 1},
                {0, 2, 1}
            };

            // Act    
            var cells = LevelCreator.GenerateCellsArrayForLevel(intArray);

            // Assert
            for (var i = 0; i < intArray.GetLength(0); i++)
            {
                for (var j = 0; j < intArray.GetLength(1); j++)
                {
                    Assert.Equal(expected[i, j].State, cells[i, j].State);
                }
            }
        }
    }
}