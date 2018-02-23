using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Box
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
            set
            {
                if (IsValid(value, nameof(Length)))
                    length = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (IsValid(value, nameof(Width)))
                    width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (IsValid(value, nameof(Height)))
                    height = value;
            }
        }

        /// <summary>
        /// Get the surface of the box
        /// </summary>
        /// <returns></returns>
        public double Surface() => 2 * length * width + 2 * length * height + 2 * width * height;

        /// <summary>
        /// Get the lateral surface area
        /// </summary>
        /// <returns></returns>
        public double LateralSurfaceArea() => 2 * length * height + 2 * width * height;

        /// <summary>
        /// Get the volume of the box
        /// </summary>
        /// <returns></returns>
        public double Volume() => length * width * height;

        public override string ToString()
        {
            return $"Surface Area - {Surface():F2}\n" +
                $"Lateral Surface Area - {LateralSurfaceArea():F2}\n" +
                $"Volume - {Volume():F2}";
        }

        /// <summary>
        /// Validate the given input
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsValid(double value, string type)
        {
            if (value > 0)
                return true;
            else throw new ArgumentException($"{type} cannot be zero or negative.");
        }
    }
}
