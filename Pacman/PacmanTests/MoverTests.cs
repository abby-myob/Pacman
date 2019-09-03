using PacmanLibrary.BoardLogic;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;
using Xunit;

namespace PacmanTests
{
    public class MoverTests
    {
        private Mover Mover { get; }

        public MoverTests()
        {
            var pacman = new Pacman(Direction.Down);
            Mover = new Mover(pacman);
        }

        [Theory]
        [InlineData(Direction.Up, true)]
        [InlineData(Direction.Right, false)]
        [InlineData(Direction.Down, false)]
        [InlineData(Direction.Left, true)]
        public void Correct_bool_from_CanCharacterMoveHere_with_pacmans_possible_direction_queried(Direction direction,
            bool expected)
        {
            // Arrange  
            Mover.Character.SetLocation(1, 1);
            var cells = new ICell[,]
            {
                {new Cell(State.Food), new Cell(State.Food), new Cell(State.Wall)},
                {new Cell(State.Food), new Cell(State.Pacman), new Cell(State.Wall)},
                {new Cell(State.Food), new Cell(State.Wall), new Cell(State.Wall)},
            };

            // Act
            var response = Mover.CanCharacterMoveHere(direction, cells);

            // Assert
            Assert.Equal(expected, response);
        }

        private static ICell[,] CreateBasicCells()
        {
            return new ICell[,]
            {
                {new Cell(State.Food), new Cell(State.Food), new Cell(State.Food)},
                {new Cell(State.Food), new Cell(State.Pacman), new Cell(State.Food)},
                {new Cell(State.Food), new Cell(State.Food), new Cell(State.Food)},
            };
        }

        private static ICell[,] CreateDownAndRightOverLapCells()
        {
            return new ICell[,]
            {
                {new Cell(State.Food), new Cell(State.Food)},
                {new Cell(State.Food), new Cell(State.Pacman)}
            };
        }

        private static ICell[,] CreateLeftAndUpOverLapCells()
        {
            return new ICell[,]
            {
                {new Cell(State.Pacman), new Cell(State.Food)},
                {new Cell(State.Food), new Cell(State.Food)}
            };
        }

        private static void AssertTwoCellArrays(ICell[,] expected, ICell[,] cells)
        {
            for (var i = 0; i < expected.GetLength(0); i++)
            {
                for (var j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.Equal(expected[i, j].State, cells[i, j].State);
                }
            }
        }


        // Basic Testing for Pacman movement *****************************************************
        [Fact]
        public void MoveCharacter_tests_for_correct_location_of_pacman_when_in_down_direction()
        {
            // Arrange  
            Mover.Character.SetLocation(1, 1);
            Mover.Character.SetDirection(Direction.Down);
            var cells = CreateBasicCells();
            var expected = new ICell[,]
            {
                {new Cell(State.Food), new Cell(State.Food), new Cell(State.Food)},
                {new Cell(State.Food), new Cell(State.Empty), new Cell(State.Food)},
                {new Cell(State.Food), new Cell(State.Pacman), new Cell(State.Food)},
            };

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }

        [Fact]
        public void MoveCharacter_tests_for_correct_location_of_pacman_when_in_Up_direction()
        {
            // Arrange  
            Mover.Character.SetLocation(1, 1);
            Mover.Character.SetDirection(Direction.Up);
            var cells = CreateBasicCells();
            var expected = new ICell[,]
            {
                {new Cell(State.Food), new Cell(State.Pacman), new Cell(State.Food)},
                {new Cell(State.Food), new Cell(State.Empty), new Cell(State.Food)},
                {new Cell(State.Food), new Cell(State.Food), new Cell(State.Food)},
            };

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }

        [Fact]
        public void MoveCharacter_tests_for_correct_location_of_pacman_when_in_Right_direction()
        {
            // Arrange  
            Mover.Character.SetLocation(1, 1);
            Mover.Character.SetDirection(Direction.Right);
            var cells = CreateBasicCells();
            var expected = new ICell[,]
            {
                {new Cell(State.Food), new Cell(State.Food), new Cell(State.Food)},
                {new Cell(State.Food), new Cell(State.Empty), new Cell(State.Pacman)},
                {new Cell(State.Food), new Cell(State.Food), new Cell(State.Food)},
            };

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }

        [Fact]
        public void MoveCharacter_tests_for_correct_location_of_pacman_when_in_Left_direction()
        {
            // Arrange  
            Mover.Character.SetLocation(1, 1);
            Mover.Character.SetDirection(Direction.Left);
            var cells = CreateBasicCells();
            var expected = new ICell[,]
            {
                {new Cell(State.Food), new Cell(State.Food), new Cell(State.Food)},
                {new Cell(State.Pacman), new Cell(State.Empty), new Cell(State.Food)},
                {new Cell(State.Food), new Cell(State.Food), new Cell(State.Food)},
            };

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }


        // Check Overlapping on Pacman Movement *****************************************************
        [Fact]
        public void MoveCharacter_tests_for_correct_location_of_pacman_when_in_Left_direction_and_overlaps()
        {
            // Arrange  
            Mover.Character.SetLocation(0, 0);
            Mover.Character.SetDirection(Direction.Left);
            var cells = CreateLeftAndUpOverLapCells();
            var expected = new ICell[,]
            {
                {new Cell(State.Empty), new Cell(State.Pacman)},
                {new Cell(State.Food), new Cell(State.Food)}
            };

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }

        [Fact]
        public void MoveCharacter_tests_for_correct_location_of_pacman_when_in_Up_direction_and_overlaps()
        {
            // Arrange  
            Mover.Character.SetLocation(0, 0);
            Mover.Character.SetDirection(Direction.Up);
            var cells = CreateLeftAndUpOverLapCells();
            var expected = new ICell[,]
            {
                {new Cell(State.Empty), new Cell(State.Food)},
                {new Cell(State.Pacman), new Cell(State.Food)}
            };

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }

        [Fact]
        public void MoveCharacter_tests_for_correct_location_of_pacman_when_in_Down_direction_and_overlaps()
        {
            // Arrange  
            Mover.Character.SetLocation(1, 1);
            Mover.Character.SetDirection(Direction.Down);
            var cells = CreateDownAndRightOverLapCells();
            var expected = new ICell[,]
            {
                {new Cell(State.Food), new Cell(State.Pacman)},
                {new Cell(State.Food), new Cell(State.Empty)}
            };

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }

        [Fact]
        public void MoveCharacter_tests_for_correct_location_of_pacman_when_in_Right_direction_and_overlaps()
        {
            // Arrange  
            Mover.Character.SetLocation(1, 1);
            Mover.Character.SetDirection(Direction.Right);
            var cells = CreateDownAndRightOverLapCells();
            var expected = new ICell[,]
            {
                {new Cell(State.Food), new Cell(State.Food)},
                {new Cell(State.Pacman), new Cell(State.Empty)}
            };

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }

        // Check Pacman Movement with walls *****************************************************
        [Theory]
        [InlineData(Direction.Up)]
        [InlineData(Direction.Down)]
        [InlineData(Direction.Right)]
        [InlineData(Direction.Left)]
        public void MoveCharacter_tests_for_correct_location_of_pacman_when_any_direction_with_walls(
            Direction direction)
        {
            // Arrange  
            Mover.Character.SetLocation(1, 1);
            Mover.Character.SetDirection(direction);
            var cells = new ICell[,]
            {
                {new Cell(State.Wall), new Cell(State.Wall), new Cell(State.Wall)},
                {new Cell(State.Wall), new Cell(State.Pacman), new Cell(State.Wall)},
                {new Cell(State.Wall), new Cell(State.Wall), new Cell(State.Wall)},
            };
            var expected = new ICell[,]
            {
                {new Cell(State.Wall), new Cell(State.Wall), new Cell(State.Wall)},
                {new Cell(State.Wall), new Cell(State.Pacman), new Cell(State.Wall)},
                {new Cell(State.Wall), new Cell(State.Wall), new Cell(State.Wall)},
            };

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }

        // Check Pacman Movement with walls overlapping *******************************************
        [Theory]
        [InlineData(Direction.Up)]
        [InlineData(Direction.Down)]
        [InlineData(Direction.Right)]
        [InlineData(Direction.Left)]
        public void
            MoveCharacter_tests_for_correct_location_of_pacman_when_rightAndDown_direction_with_walls_with_overlapping(
                Direction direction)
        {
            // Arrange  
            Mover.Character.SetLocation(1, 1);
            Mover.Character.SetDirection(direction);
            var cells = new ICell[,]
            {
                {new Cell(State.Wall), new Cell(State.Wall)},
                {new Cell(State.Wall), new Cell(State.Pacman)},
            };
            var expected = new ICell[,]
            {
                {new Cell(State.Wall), new Cell(State.Wall)},
                {new Cell(State.Wall), new Cell(State.Pacman)},
            };

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }

        [Theory]
        [InlineData(Direction.Up)]
        [InlineData(Direction.Down)]
        [InlineData(Direction.Right)]
        [InlineData(Direction.Left)]
        public void
            MoveCharacter_tests_for_correct_location_of_pacman_when_leftAndUp_direction_with_walls_with_overlapping(
                Direction direction)
        {
            // Arrange  
            Mover.Character.SetLocation(0, 0);
            Mover.Character.SetDirection(direction);
            var cells = new ICell[,]
            {
                {new Cell(State.Pacman), new Cell(State.Wall)},
                {new Cell(State.Wall), new Cell(State.Wall)},
            };
            var expected = new ICell[,]
            {
                {new Cell(State.Pacman), new Cell(State.Wall)},
                {new Cell(State.Wall), new Cell(State.Wall)},
            };

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }

        // Check Pacman Movement with One Cell *******************************************
        [Theory]
        [InlineData(Direction.Up)]
        [InlineData(Direction.Down)]
        [InlineData(Direction.Right)]
        [InlineData(Direction.Left)]
        public void MoveCharacter_with_level_of_one_cell(Direction direction)
        {
            // Arrange  
            Mover.Character.SetLocation(0, 0);
            Mover.Character.SetDirection(direction);
            var cells = new ICell[,] {{new Cell(State.Pacman)}};
            var expected = new ICell[,] {{new Cell(State.Pacman)}};

            // Act 
            Mover.MoveCharacter(cells);

            // Assert
            AssertTwoCellArrays(expected, cells);
        }
    }
}