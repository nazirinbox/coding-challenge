using System.Collections.Generic;

namespace ShipController
{
    public  class  Grid
    {
        public int Width { get; }
        public int Height { get; }
        public Grid(int width, int height)
        {
            Width = ++width;
            Height = ++height;
            GridUnit = new int[Width, Height]; // Since Grid start from 0,0 corodinates we need add width and height
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    GridUnit[x,y] = (int) Warnigs.NONE;
                }
            }
        }

        public int[,] GridUnit { get; set; }
    }
}