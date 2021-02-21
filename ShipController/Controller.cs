using System;
using System.Collections.Generic;

namespace ShipController
{
    public class Controller
    {
        private readonly IList<Ship> ships;

        public Grid Grid { get; set; }

        public Controller(Grid gridUnit)
        {
            this.Grid = gridUnit;
            ships = new List<Ship>();
        }

        public void PlaceShip(Ship ship)
        {
            ships.Add(ship);
        }

        public void MoveShip(ControlCommands command, Ship ship)
        {
            var lastPoistion = new Point(ship.Coordinates.X, ship.Coordinates.Y);
            
            if(ship.LocationStatus != LocationStatus.LOST)
                ship.Move(command);

            // Check Ship location on Grid
            var locationSignal = ValidateShipLocation(ship);

            if (CheckWarnings(locationSignal))
            {
                ship.LocationStatus = LocationStatus.LOST;
                ship.Coordinates = lastPoistion;
                Grid.GridUnit[ship.Coordinates.X, ship.Coordinates.Y] = (int)locationSignal;
            }
        }
        private bool CheckWarnings(Warnigs warning) {

            return warning == Warnigs.LOST_TO_EAST || warning == Warnigs.LOST_TO_NORTH || warning == Warnigs.LOST_TO_SOUTH || warning == Warnigs.LOST_TO_WEST;
        }

        public Warnigs ValidateShipLocation(Ship ship)
        {
            if (ship.Coordinates.Y > Grid.Height - 1 || ship.Coordinates.X > Grid.Width - 1)
            {
                switch (ship.Orientation)
                {
                    case Orientation.NORTH:
                        return Warnigs.LOST_TO_NORTH;
                    case Orientation.EAST:
                        return Warnigs.LOST_TO_EAST;
                    case Orientation.SOUTH:
                        return Warnigs.LOST_TO_SOUTH;
                    case Orientation.WEST:
                        return Warnigs.LOST_TO_WEST;
                    default:
                        return Warnigs.NONE;
                }
            }
            else
            {
                return Warnigs.NONE;
            }
        }
    }
}