using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var pokePower = long.Parse(ReadLine());
        var distanceBetwPokeTargets = long.Parse(ReadLine());
        var exhaustionFactor = int.Parse(ReadLine());

        var targetsReached = 0;
        var decreasedPokePower = pokePower;
        while (distanceBetwPokeTargets <= decreasedPokePower)
        {
            decreasedPokePower -= distanceBetwPokeTargets;
            targetsReached++;
            var pokePowerPercent = decreasedPokePower / (decimal)pokePower * 100m;
            if (pokePowerPercent == 50 && decreasedPokePower >= exhaustionFactor && exhaustionFactor != 0)

                decreasedPokePower /= exhaustionFactor;
        }

        WriteLine(decreasedPokePower + "\n" + targetsReached);
    }
}
