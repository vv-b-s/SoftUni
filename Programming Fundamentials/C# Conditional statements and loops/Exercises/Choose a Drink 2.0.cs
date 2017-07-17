using System;
using static System.Console;

class Program
{
    [Flags]
    enum Profession { Athlete, Businessman, Businesswoman = 1, SoftUni }
    enum Drink { Water, Coffee, Beer, Tea }
    static void Main()
    {
        Profession prof;
        string prof_in_string = ReadLine();
        bool check = Enum.TryParse(prof_in_string.Split()[0], out prof);
        prof = (check ? prof : (Profession)3);

        int amount = int.Parse(ReadLine());
        double[] drinkPrice = { 0.7, 1, 1.7, 1.2 };

        WriteLine($"The {prof_in_string} has to pay {drinkPrice[(int)prof] * amount:f2}.");
    }
}
