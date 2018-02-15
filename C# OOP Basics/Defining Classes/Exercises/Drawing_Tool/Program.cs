using Drawing_Tool.Figures;
using System;

namespace Drawing_Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            var figureType = Console.ReadLine();

            if (figureType == "Square")
                DrawingTool.DrawShape(new Square(int.Parse(Console.ReadLine())));
            if (figureType == "Rectangle")
                DrawingTool.DrawShape(new Rectangle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        }
    }
}
