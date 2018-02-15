using Drawing_Tool.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drawing_Tool
{
    public static class DrawingTool
    {
        public static void DrawShape(RectangularFigure figure) => Console.WriteLine(figure.Draw()); 
    }
}
