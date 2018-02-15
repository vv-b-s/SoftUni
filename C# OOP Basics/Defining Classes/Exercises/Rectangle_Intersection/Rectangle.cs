using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rectangle_Intersection
{
    class Rectangle
    {
        public string Id { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public double X { get; private set; }
        public double Y { get; private set; }

        public double Area => Height * Width;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            Id = id;
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }

        /// <summary>
        /// Check if this rectangle doubleersects with another rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public bool Intersects(Rectangle rectangle)
        {
            double[][] coordinates = new double[][]
            {
                new double[] {rectangle.X,rectangle.Y},
                new double[] {rectangle.X+rectangle.Width, rectangle.Y+rectangle.Height},
                new double[] {rectangle.X+rectangle.Width, rectangle.Y},
                new double[] { rectangle.X,rectangle.Y+rectangle.Height}
            };

            return coordinates.Any(c => c[0] >= this.X && c[0] <= this.X + Width && c[1] >= this.Y && c[1] <= this.Y + Height);
        }
    }
}
