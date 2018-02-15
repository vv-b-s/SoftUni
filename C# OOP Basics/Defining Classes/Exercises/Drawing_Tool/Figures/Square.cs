using System;
using System.Collections.Generic;
using System.Text;

namespace Drawing_Tool.Figures
{
    public class Square:RectangularFigure
    {
        public Square(int size)
        {
            Height = Width = size;
        }
    }
}
