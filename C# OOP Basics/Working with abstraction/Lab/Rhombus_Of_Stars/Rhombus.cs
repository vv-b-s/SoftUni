using System;
using System.Collections.Generic;
using System.Text;

namespace Rhombus_Of_Stars
{
    class Rhombus
    {
        public int Size { get; set; }
        public string Shape
        {
            get
            {
                var sB = new StringBuilder();

                //Get the first half of the rhombus
                for (int stars = 1, spaces = Size - stars; stars <= Size; stars++, spaces--)
                    sB.AppendLine(PrintRow(spaces, stars));

                //Print the second half (inverted first half)
                for (int stars = Size - 1, spaces = 1; stars >= 1; stars--, spaces++)
                    sB.AppendLine(PrintRow(spaces, stars));

                return sB.ToString();
            }
        }

        public Rhombus(int size)
        {
            Size = size;
        }

        /// <summary>
        /// Print a line of the rhombus
        /// </summary>
        /// <param name="numberOfWhitespaces"></param>
        /// <param name="numberOfStars"></param>
        /// <returns></returns>
        private string PrintRow(int numberOfWhitespaces, int numberOfStars) => $"{new string(' ', numberOfWhitespaces)}{NewStringSequence("* ",numberOfStars)}";

        /// <summary>
        /// Prints a sequence of combined characters
        /// </summary>
        /// <param name="sequcence"></param>
        /// <param name="repeat"></param>
        /// <returns></returns>
        public string NewStringSequence(string sequcence, int repeat)
        {
            var output = new StringBuilder();
            for (int i = 0; i < repeat; i++)
                output.Append(sequcence);
            return output.ToString();
        }
    }
}
