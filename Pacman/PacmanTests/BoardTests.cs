using System.Collections.Generic;
using PacmanLibrary;
using Xunit;

namespace PacmanTests
{
    public class BoardTests
    {
        [Fact]
        public void SetUpBoard()
        {
            var pacman = new Pacman(Direction.Up);
            var board = new Board(pacman);

            board.Initialise();

            Assert.Equal(".", board.Cells);
        }
    }

    public class Board
    {
        private readonly IPacman _pacman;
        public List<char> Cells { get; private set; }

        public Board(IPacman pacman)
        {
            _pacman = pacman;
        }


        public void Initialise()
        {
            throw new System.NotImplementedException();
        }
    }
}