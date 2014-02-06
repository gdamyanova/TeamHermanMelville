using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobyDick
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }
    }
}
