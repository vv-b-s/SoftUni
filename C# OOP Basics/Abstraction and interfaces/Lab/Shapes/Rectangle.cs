﻿using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle : IDrawable
{
    private int height;
    private int width;

    public Rectangle(int height, int width)
    {
        Height = height;
        Width = width;
    }

    public int Height
    {
        get => height;
        private set => height = value;
    }

    public int Width
    {
        get => width;
        private set => width = value;
    }

    public void Draw()
    {
        DrawLine(width, '*', '*');

        for (int i = 1; i < height - 1; i++)
            DrawLine(width, '*', ' ');

        DrawLine(width, '*', '*');
    }

    private void DrawLine(int width, char end, char mid)
    {
        Console.Write(end);
        for (int i = 1; i < width-1; i++)
            Console.Write(mid);

        Console.WriteLine(end);
    }
}
