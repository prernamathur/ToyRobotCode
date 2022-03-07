using System;
using static ToyRobot.CommandMove;

namespace ToyRobot
{
    public class ToyRobotMove
    {
        public ToyRobotMove()
        {
        }

        public IToyRobot ToyRobot { get; private set; }
        public IToyRobotBoard Simulator { get; private set; }
        public IInputValue InputValue { get; private set; }

        public ToyRobotMove(IToyRobot toyRobot, IToyRobotBoard simulator, IInputValue inputValue)
        {
            ToyRobot = toyRobot;
            Simulator = simulator;
            InputValue = inputValue;
        }

        public string ProcessCommand(string[] input)
        {
            var command = InputValue.ParseCommand(input);
            if (command != Command.Place && ToyRobot.Position == null) return string.Empty;

            switch (command)
            {
                case Command.Place:
                    var placeCommandParameter = InputValue.ParseCommandParameter(input);
                    if (Simulator.IsValidPosition(placeCommandParameter.Position))
                        ToyRobot.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                    break;
                case Command.Move:
                    var newPosition = ToyRobot.GetNextPosition();
                    if (Simulator.IsValidPosition(newPosition))
                        ToyRobot.Position = newPosition;
                    break;
                case Command.Left:
                    ToyRobot.RotateLeft();
                    break;
                case Command.Right:
                    ToyRobot.RotateRight();
                    break;
                case Command.Report:
                    return GetReport();
            }
            return string.Empty;
        }

        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", ToyRobot.Position.X,
                ToyRobot.Position.Y, ToyRobot.Direction.ToString().ToUpper());
        }
    }
}
