using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Rectangle_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            var numberOfRectangles = data[0];
            var numberOfComparisons = data[1];

            var rectangles = new Dictionary<string, Rectangle>();

            while (numberOfRectangles-- > 0)
            {

                var rectangleData = ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var id = rectangleData[0];
                var width = double.Parse(rectangleData[1]);
                var height = double.Parse(rectangleData[2]);
                var x = double.Parse(rectangleData[3]);
                var y = double.Parse(rectangleData[4]);

                rectangles[id] = new Rectangle(id, width, height, x, y);
            }

            while (numberOfComparisons-- > 0)
            {
                var ids = ReadLine().Split();

                var rect1 = rectangles[ids[0]];
                var rect2 = rectangles[ids[1]];
                WriteLine((rect1.Intersects(rect2)||rect2.Intersects(rect1)).ToString().ToLower());
            }
        }
    }
}
