using System;

namespace ShipController
{
    /// <summary>
    /// Ship class contains all 
    /// </summary>
    public class Ship
    {
        public Point Coordinates { get; set; }
        public Orientation Orientation { get; set; }
        public Grid Grid { get; }
        public LocationStatus LocationStatus { get; set; } = LocationStatus.LOCATED;
        public string Id { get; }

        public Ship(string id, Point coordinates, Orientation north, Grid gridUnit)
        {
            Id = id;
            Coordinates = coordinates;
            Orientation = north;
            Grid = gridUnit;
        }

        public void Move(ControlCommands command)
        {
            switch (command)
            {
                case ControlCommands.Forward:
                    MoveForward();
                    return;
                case ControlCommands.LEFT:
                    MoveLeft();
                    return;
                case ControlCommands.RIGHT:
                    MoveRigth();
                    return;
                default:
                    return;
            }
        }

        private bool IsThereAnyWarnigns(Warnigs signal)
        {
            return Grid.GridUnit[Coordinates.X, Coordinates.Y] == (int)signal;
        }

        private void MoveForward()
        {
            switch (Orientation)
            {
                case Orientation.NORTH:
                    if (!IsThereAnyWarnigns(Warnigs.LOST_TO_NORTH))
                    {
                        Coordinates.Y += 1;
                    }
                    return;
                case Orientation.EAST:
                    if (!IsThereAnyWarnigns(Warnigs.LOST_TO_EAST))
                    {
                        Coordinates.X += 1;
                    }
                    return;
                case Orientation.SOUTH:
                    if (!IsThereAnyWarnigns(Warnigs.LOST_TO_SOUTH))
                    {
                        Coordinates.Y -= 1;
                    }
                    return;
                case Orientation.WEST:
                    if (!IsThereAnyWarnigns(Warnigs.LOST_TO_WEST))
                    {
                        Coordinates.X -= 1;
                    }
                    return;
                default:
                    return;
            }

        }
        private void MoveLeft()
        {

            switch (Orientation)
            {
                case Orientation.NORTH:
                    Orientation = Orientation.WEST;
                    return;
                case Orientation.EAST:
                    Orientation = Orientation.NORTH;
                    return;
                case Orientation.SOUTH:
                    Orientation = Orientation.EAST;
                    return;
                case Orientation.WEST:
                    Orientation = Orientation.SOUTH;
                    return;
                default:
                    return;
            }

        }
        private void MoveRigth()
        {
            switch (Orientation)
            {
                case Orientation.NORTH:
                    Orientation = Orientation.EAST;
                    return;
                case Orientation.EAST:
                    Orientation = Orientation.SOUTH;
                    return;
                case Orientation.SOUTH:
                    Orientation = Orientation.WEST;
                    return;
                case Orientation.WEST:
                    Orientation = Orientation.NORTH;
                    return;
                default:
                    return;
            }
        }
    }
}