using PacmanLibrary;
using Xunit;

namespace PacmanTests
{
    public class BoardTests
    {
        [Fact]
        public void SetUpBoard()
        {
            var pacman = new Pacman(Direction.Down);
        }
    }
}