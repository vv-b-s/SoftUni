using System;
using System.Collections.Generic;
using System.Text;

namespace Point_In_Rectangle
{
    class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        /// <summary>
        /// Check if a certain point is in the range of the rectangle
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Contains(Point point) => (point.X >= TopLeft.X) && (point.X <= BottomRight.X) && (point.Y >= TopLeft.Y) && (point.Y <= BottomRight.Y);
    }
}
