using System;

namespace ToyRobot
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            const string desc = @"Toy Robot Program Create a library that can read in commands of the following form:

PLACE X, Y, DIRECTION
MOVE
LEFT
RIGHT
REPORT
Solution Requirements
The library allows for a simulation of a toy robot moving on a 6 x 6 square tabletop.
There are no obstructions on the table surface.
The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in this must be prevented, however further valid movement commands must still be allowed.
PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
(0,0) can be considered as the SOUTH WEST corner and (5,5) as the NORTH EAST corner.
The first valid command to the robot is a PLACE command. After that, any sequence of commands may be issued, in any order, including another PLACE command. The library should discard all commands in the sequence until a valid PLACE command has been executed.
The PLACE command should be discarded if it places the robot outside of the table surface.
Once the robot is on the table, subsequent PLACE commands could leave out the direction and only provide the coordinates. When this happens, the robot moves to the new coordinates without changing the direction.
MOVE will move the toy robot one unit forward in the direction it is currently facing.
LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
REPORT will announce the X,Y and orientation of the robot.
A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.";

            IToyRobotBoard simulation = new ToyRobotBoard(5, 5);
            IInputValue input = new ToyRobotInput();
            IToyRobot robot = new ToyRobot();
            var simulator = new ToyRobotMove(robot, simulation, input);

            var Appexit = false;
            Console.WriteLine(desc);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Enter the Commands");
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.Equals("EXIT"))
                    Appexit = true;
                else
                {
                    try
                    {
                        var output = simulator.ProcessCommand(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!Appexit);
        }
    }
}
