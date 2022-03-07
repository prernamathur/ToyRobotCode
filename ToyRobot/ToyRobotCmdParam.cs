using System;
using static ToyRobot.CommandMove;

namespace ToyRobot
{
    public class ToyRobotCmdParam
    {
        public CommandMove Position { get; set; }
        public Direction Direction { get; set; }

        public ToyRobotCmdParam(CommandMove position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
