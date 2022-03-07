using System;
namespace ToyRobot
{
    public class CommandMove
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CommandMove(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // enum for command
        public enum Command
        {
            Place,
            Move,
            Left,
            Right,
            Report
        }

        // enum for direction
        public enum Direction
        {
            North,
            East,
            South,
            West
        }
    }
}
