using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            System.Console.WriteLine(shape.Draw());
        }
    }
}
