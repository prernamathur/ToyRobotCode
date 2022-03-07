using System;
namespace ToyRobot
{
    public interface IToyRobotBoard
    {
        bool IsValidPosition(CommandMove position);
    }
}
