using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int wordSize = int.Parse(ReadLine());
        var word = new StringBuilder();

        char[][] charGrid =
        {
            new char[]{' '},                             //0
            new char[]{ },                              //1
            new char[]{'a','b','c'},                   //2
            new char[]{ 'd','e','f'},                 //3
            new char[]{ 'g','h','i'},                //4
            new char[]{ 'j','k','l'},               //5
            new char[]{ 'm','n','o'},              //6
            new char[]{ 'p','q','r','s'},         //7
            new char[]{ 't','u','v'},            //8
            new char[]{ 'w','x','y','z'}        //9
        };

        for(int i=0;i<wordSize;i++)
        {
            string input = ReadLine();
            int timesPressed = -1;
            foreach (var a in input)
                timesPressed++;
            word.Append(charGrid[(int)char.GetNumericValue(input[0])][timesPressed]);
        }
        WriteLine(word.ToString());
    }
}
