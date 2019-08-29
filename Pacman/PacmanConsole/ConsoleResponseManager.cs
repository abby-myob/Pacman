using System;
using System.Text;
using PacmanLibrary;
using PacmanLibrary.Enums;
using PacmanLibrary.Interfaces;

namespace PacmanConsole
{
    public class ConsoleResponseManager : IResponseManager
    {

        public void PrintBoard(ICell[,] cells, IPacman pacman)
        {
            var stringBuilder = new StringBuilder();
            for (var row = 0; row < cells.GetLength(0); row++)
            {
                for (var col = 0; col < cells.GetLength(1); col++)
                {
                    var state = cells[row, col].State;
                    switch (state)
                    {
                        case State.Empty:
                            stringBuilder.Append("   ");
                            break;
                        case State.Food:
                            stringBuilder.Append(" . ");
                            break;
                        case State.Pacman:
                            switch (pacman.Direction)
                            {
                                case Direction.Up:
                                    stringBuilder.Append(" v ");
                                    break;
                                case Direction.Down:
                                    stringBuilder.Append(" ^ ");
                                    break;
                                case Direction.Left:
                                    stringBuilder.Append(" > ");
                                    break;
                                case Direction.Right:
                                    stringBuilder.Append(" < ");
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                stringBuilder.Append("\n");
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        public Direction GetDirection()
        {
            var key = Console.ReadKey(false).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return Direction.Up;
                case ConsoleKey.DownArrow:
                    return Direction.Down;
                case ConsoleKey.LeftArrow:
                    return Direction.Left;
                case ConsoleKey.RightArrow:
                    return Direction.Right;
                default:
                    return Direction.Null;
            } 
        }

        public void PrintScore(int score)
        {
            Console.WriteLine($"Score: {score}");
        }
    }
}