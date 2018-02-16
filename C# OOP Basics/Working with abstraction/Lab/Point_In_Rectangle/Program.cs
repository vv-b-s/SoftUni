using System;
using System.Linq;

namespace Point_In_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialPoints = GetArray();

            var topLeftPoint = new Point(x: initialPoints[0], y: initialPoints[1]);
            var topRightPoint = new Point(x: initialPoints[2], y: initialPoints[3]);

            var rectangle = new Rectangle(topLeftPoint, topRightPoint);

            var checkPoint = new Point(0, 0);
            var numberOfPointsToCheck = int.Parse(Console.ReadLine());

            while(numberOfPointsToCheck-->0)
            {
                var coordinates = GetArray();
                checkPoint.X = coordinates[0];
                checkPoint.Y = coordinates[1];

                Console.WriteLine(rectangle.Contains(checkPoint));
            }

        }

        private static int[] GetArray() => Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
    }
}
