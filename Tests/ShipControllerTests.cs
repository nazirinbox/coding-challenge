using NUnit.Framework;
using ShipController;

namespace ShipControllerTest
{
    public class Tests
    {
        public Grid GridUnit { get; set; }

        [SetUp]
        public void Setup()
        {
            GridUnit = new Grid(5, 3);
        }

        [Test]
        public void MoveForwardTowardsEastPositiveTest()
        {
            Point coordinates = new Point(1, 1);
            Ship ship1 = new Ship("Ship1", coordinates, Orientation.EAST, GridUnit);
            var shipController = new Controller(GridUnit);

            shipController.PlaceShip(ship1);
            var instructions = "RFRFRFRF";
            foreach (var command in instructions)
            {
                shipController.MoveShip((ControlCommands)command, ship1);
            }
            var currentCoordiantes = new Point(1, 1);
            Assert.True(ship1.Coordinates.X == currentCoordiantes.X && ship1.Coordinates.Y == currentCoordiantes.Y);
            Assert.True(ship1.Orientation == Orientation.EAST);
        }

        [Test]
        public void MoveShipWithWarningsLeftByLostShipTest()
        {
            // Place first ship and get it lost
            Point coordinates = new Point(3, 2);
            Ship ship1 = new Ship("Ship1", coordinates, Orientation.NORTH, GridUnit);
            var shipController = new Controller(GridUnit);

            shipController.PlaceShip(ship1);
            var instructions = "FRRFLLFFRRFLL";
            foreach (var command in instructions)
            {
                shipController.MoveShip((ControlCommands)command, ship1);
            }

            //Place another ship and send commands

            Point position = new Point(0, 3);
            Ship ship2 = new Ship("Ship2", position, Orientation.WEST, GridUnit);

            shipController.PlaceShip(ship2);
            var commands = "LLFFFLFLFL";
            foreach (var command in commands)
            {
                shipController.MoveShip((ControlCommands)command, ship2);
            }

            //Asert
            var expectedCoordiantes = new Point(2, 3);
            Assert.True(ship2.Coordinates.X == expectedCoordiantes.X && ship2.Coordinates.Y == expectedCoordiantes.Y);
            Assert.True(ship2.Orientation == Orientation.SOUTH);
        }
        [Test]
        public void MoveShipWithLostLocationTest()
        {
            
            Point coordinates = new Point(3, 2);
            Ship ship = new Ship("Ship2", coordinates, Orientation.NORTH, GridUnit);
            var shipController = new Controller(GridUnit);

            shipController.PlaceShip(ship);
            var instructions = "FRRFLLFFRRFLL";
            foreach (var command in instructions)
            {
                shipController.MoveShip((ControlCommands)command, ship);
            }
            var expectedCoordiantes = new Point(3, 3);
            Assert.True(ship.Coordinates.X == expectedCoordiantes.X && ship.Coordinates.Y == expectedCoordiantes.Y);
            Assert.True(ship.Orientation == Orientation.NORTH);
            Assert.True(ship.LocationStatus == LocationStatus.LOST);
        }
    }
}