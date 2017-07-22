using System;
using static System.Console;

class Program
{
    static void Main()
    {
        string ingredient = ReadLine();
        int ingredients = 0;
        while (ingredient != "Bake!")
        {
            ingredients++;
            WriteLine($"Adding ingredient {ingredient}.");
            ingredient = ReadLine();
        }
        WriteLine($"Preparing cake with {ingredients} ingredients.");
    }
}
