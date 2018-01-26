using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

class StringMatrixRotation
{
    public static void Main(string[] args)
    {
        var degr = int.Parse(Regex.Match(ReadLine(), @"\d+").Value);

        var words = new List<string>();
        string input;

        while ((input = ReadLine()) != "END")
            words.Add(input);

        var mh = new MatrixHolder(words);
        Write(mh.Rotate(degr));
    }
}

class MatrixHolder
{
    private List<string> arrays;
    private int width;
    private int height;

    internal MatrixHolder(List<string> words)
    {
        height = words.Count;
        words.ForEach(w=> { if (w.Length > width) width = w.Length; });
        arrays = words;
    }


    internal string Rotate(int degr)
    {
        degr %= 360;
        if (degr == 0)
            degr = 360;
        switch(degr)
        {
            case 90:
                return Rotate90();
            case 180:
                return Rotate180();
            case 270:
                return Rotate270();
        }

        return string.Join("\n",arrays)+"\n";
    }

    private string Rotate90()
    {
        var sB = new StringBuilder();

        for (int i = 0; i <width; i++) 
        {
            for (int j = height-1; j >= 0 ; j--)
            {
                if (arrays[j].Length > i)
                    sB.Append(arrays[j][i]);
                else
                    sB.Append(' ');
            }
            sB.AppendLine();
        }
        return sB.ToString();
    }

    private string Rotate180()
    {
        var sB = new StringBuilder();

        for(int i = height-1; i >=0 ; i--)
        {
            for(int j = width-1;j>=0;j--)
            {
                if (j >= arrays[i].Length)
                    sB.Append(' ');
                else
                    sB.Append(arrays[i][j]);
            }
            sB.AppendLine();
        }

        return sB.ToString();
    }

    private string Rotate270()
    {
        var sB = new StringBuilder();

        for (int i = width-1; i >= 0; i--)
        {
            for (int j = 0; j <height ; j++)
            {
                if (arrays[j].Length > i)
                    sB.Append(arrays[j][i]);
                else
                    sB.Append(' ');
            }
            sB.AppendLine();
        }
        return sB.ToString();
    }
}
