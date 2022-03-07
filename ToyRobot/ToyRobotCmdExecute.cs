﻿using System;
using static ToyRobot.CommandMove;

namespace ToyRobot
{
    public class ToyRobotCmdExecute
    {
        // Number of parameters provided for "PLACE" Command. (X,Y,F)
        private const int ParameterCount = 2;

        // Number of raw input items expected from user.
        private const int CommandInputCount = 2;

        // Checks the toy's initial position and the direction it is going to be facing.
        public ToyRobotCmdParam ParseParameters(string[] input)
        {
            Direction direction;
            CommandMove position = null;

            // Checks that Place command is followed by valid command parameters (X,Y and F toy's face direction).
            if (input.Length < CommandInputCount)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F or PLACE X,Y");

            // Checks that three command parameters are provided for the PLACE command.   
            var commandParams = input[1].Split(',');
            if (commandParams.Length < ParameterCount)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F or PLACE X,Y");

            // Checks the direction which the toy is going to be facing.
            if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");

            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            position = new CommandMove(x, y);

            return new ToyRobotCmdParam(position, direction);
        }
    }
}
