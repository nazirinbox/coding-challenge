using System;
using System.Collections.Generic;

namespace ShipController
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            //Ask for Grid Dimensions
            var gridUnit = CreateGrid();
            var shipController = new Controller(gridUnit);
            List<Ship> ships = new List<Ship>();
            // Read ships data
            do
            {
                //Read Ships placement cordinates
                string shipPlacementString = Console.ReadLine();

                Ship ship = CreateShip(gridUnit, shipPlacementString);
                shipController.PlaceShip(ship);

                //Read Instructions
                var instructions = Console.ReadLine();

                if (instructions.Length > 100)
                {
                    Console.WriteLine("Maximum Instruction length is 100, press Escap Key to exit");
                    input = Console.ReadKey();
                }
                foreach (var command in instructions)
                {
                    shipController.MoveShip((ControlCommands)command, ship);
                }
                // Add ship into list so we can check status
                ships.Add(ship);
                Console.WriteLine("Press the Escape (Esc) key to display result or Enter Key  to start another ship info");
                input = Console.ReadKey();
            } while (input.Key != ConsoleKey.Escape);

            Console.WriteLine(" ---------------Output---------------------");
            // Print output
            foreach (var ship in ships)
            {
                Console.WriteLine(ship.ToString());
            }
            Console.ReadLine();
        }

        private static Grid CreateGrid(){
            ConsoleKeyInfo input;
           var gridDimentionString = Console.ReadLine();
            string[] commands = gridDimentionString.Trim().Split(' ');
            int width = Convert.ToInt32(commands[0]);
            int height = Convert.ToInt32(commands[1]);
            if (width > 50 || height > 50) {
                Console.WriteLine("Maximum coordinates for Grid is 50, plese ESC key to start again");
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.Escape) Environment.Exit(0);
            }
            return new Grid(width, height);
        }

        private static Ship CreateShip(Grid GridUnit, string shipPlacementString)
        {
            string[] placementValues = shipPlacementString.Trim().Split(' ');

            int x = Convert.ToInt32(placementValues[0]);
            int y = Convert.ToInt32(placementValues[1]);
            if (x > 50 || y > 50)
            {
                Console.WriteLine("Maximum value for coordinates is 50, please start again");
            }
            char direction = Convert.ToChar(placementValues[2]);
            var postiion = new Point(x, y);
            Ship ship = new Ship("ship1", postiion, (Orientation)direction, GridUnit);
            return ship;
        }

    }
}
