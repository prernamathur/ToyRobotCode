using System;
using static ToyRobot.CommandMove;

namespace ToyRobot
{
    public interface IInputValue
    {

        // Interface to process the input from the user.
        Command ParseCommand(string[] Input);

        // to get the parameters from the user's input.        
        ToyRobotCmdParam ParseCommandParameter(string[] input);
    }
}
