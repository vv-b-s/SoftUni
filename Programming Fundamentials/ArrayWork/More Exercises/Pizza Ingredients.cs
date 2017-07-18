using System;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Numerics;
using static System.Console;

class Program
{
    static void Main()
    {
        string[] ingredients = ReadLine().Split(' ');
        int ingredientLength = (int)ReadNum();

        var addedIngredients = new StringBuilder();
        var addedIngredientsCount = 0;

        foreach(var ingredient in ingredients)
        {
            if(ingredient.Length==ingredientLength)
            {
                WriteLine($"Adding {ingredient}.");
                addedIngredients.Append(ingredient + " ");
                addedIngredientsCount++;
                if (addedIngredientsCount == 10)
                    break;
            }
        }
        ingredients = addedIngredients.ToString().Trim(' ').Split(' ');
        WriteLine($"Made pizza with total of {addedIngredientsCount} ingredients.\nThe ingredients are: {PrintArray(ingredients,", ")}.");
    }

    static string PrintArray<TVariable>(TVariable[] arr, string format)
    {
        var sB = new StringBuilder();
        for (int i = 0; i < arr.Length; i++)
            sB.Append(i < arr.Length - 1 ?
                $"{arr[i]}{format}" :
                $"{arr[i]}");

        return sB.ToString();
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
