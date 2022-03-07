using System;
using static ToyRobot.CommandMove;

namespace ToyRobot
{
    public interface IToyRobot
    {

        Direction Direction { get; set; }
        CommandMove Position { get; set; }

        // To set the toy position and direction.
        void Place(CommandMove position, Direction direction);

        // Checks the next position of the toy based on the direction it's currently facing.
        CommandMove GetNextPosition();

        // Rotates the direction of the toy left.
        void RotateLeft();

        // Rotates the direction of the toy right.
        void RotateRight();

        // Checks the new direction of the toy. The new direction is based on current direction and the rotation command (LEFT - Right)
        // identifies the side which the toy should be rotated on Left is -1 Right is 1      
        void Rotate(int rotationNumber);
    }
}
