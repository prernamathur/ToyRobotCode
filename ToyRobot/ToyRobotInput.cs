using System;
using static ToyRobot.CommandMove;

namespace ToyRobot
{
    public class ToyRobotInput: IInputValue
    {

        // this method takes a string array and compares the first element to the list of commands
        // if the command doesn't exist then an error is thrown, otherwise the command is returned
        public Command ParseCommand(string[] Input)
        {
            Command command;
            if (!Enum.TryParse(Input[0], true, out command))
                throw new ArgumentException("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");
            return command;
        }

        // Extracts the parameters from the user input and returns it       
        public ToyRobotCmdParam ParseCommandParameter(string[] input)
        {
            var thisPlaceCommandParameter = new ToyRobotCmdExecute();
            return thisPlaceCommandParameter.ParseParameters(input);
        }
    }
}
