using System;
namespace ToyRobot
{
    public class ToyRobotBoard :IToyRobotBoard
    {
        public ToyRobotBoard()
        {
        }

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public ToyRobotBoard(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        // Check whether the position specified is inside the boundaries of the square board.
        public bool IsValidPosition(CommandMove position)
        {
            return position.X < Columns && position.X >= 0 &&
                   position.Y < Rows && position.Y >= 0;
        }

    }
}
