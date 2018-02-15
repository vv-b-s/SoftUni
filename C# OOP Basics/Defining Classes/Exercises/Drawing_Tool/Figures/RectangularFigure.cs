using System;
using System.Collections.Generic;
using System.Text;

namespace Drawing_Tool.Figures
{
    public abstract class RectangularFigure
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public string Draw()
        {
            var sB = new StringBuilder();
            var firstAndLastLine = $"|{new string('-', Width)}|";
            var middleLines = $"|{new string(' ', Width)}|";

            for(int i = 0;i<Height;i++)
            {
                if (i == 0 || i == Height - 1)
                    sB.AppendLine(firstAndLastLine);
                else
                    sB.AppendLine(middleLines);
            }

            return sB.ToString();
        }
    }
}
