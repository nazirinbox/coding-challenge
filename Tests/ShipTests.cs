using NUnit.Framework;
using ShipController;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipControllerTest
{
    class ShipTests
    {
        public Grid GridUnit { get; set; }

        [SetUp]
        public void Setup()
        {
            GridUnit = new Grid(5, 3);
        }

        [Test]
        public void MoveShipForward()
        {
            Point coordinates = new Point(1, 1);
            Ship ship = new Ship("Ship1", coordinates, Orientation.EAST, GridUnit);
            ship.Move(ControlCommands.Forward);
            Assert.True(ship.Coordinates.X == 2);
        }
        [Test]
        public void MoveShipLeft()
        {
            Point coordinates = new Point(1, 1);
            Ship ship = new Ship("Ship1", coordinates, Orientation.EAST, GridUnit);
            ship.Move(ControlCommands.LEFT);
            Assert.True(ship.Orientation == Orientation.NORTH);
        }
        [Test]
        public void MoveShipRight()
        {
            //Act
            Point coordinates = new Point(1, 1);
            Ship ship = new Ship("Ship1", coordinates, Orientation.SOUTH, GridUnit);
            
            //Action
            ship.Move(ControlCommands.RIGHT);

            //Assert
            Assert.True(ship.Orientation == Orientation.WEST);
        }
    }
}
