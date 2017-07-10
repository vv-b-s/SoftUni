using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Pokemon
{
    public string Name { set; get; }
    public Dictionary<long, List<string>> Evolutions = new Dictionary<long, List<string>>();

    public List<string>[] RawEvolutionsList = new List<string>[] {new List<string>(),new List<string>() };

    public Pokemon(string name, string evType, long evIndex)
    {
        Name = name;
        AddEvolution(evIndex, evType);
    }

    public void AddEvolution(long evIndex, string evType)
    {
        RawEvolutionsList[0].Add(evIndex.ToString());
        RawEvolutionsList[1].Add(evType);
        if (Evolutions.ContainsKey(evIndex))
            Evolutions[evIndex].Add(evType);
        else
            Evolutions[evIndex] = new List<string> { evType };
    }

    public void OrderEvolutionsByIndex() =>
        Evolutions = Evolutions
        .OrderByDescending(e => e.Key)
        .ToDictionary(k => k.Key, v => v.Value);

}

class Program
{
    static void Main()
    {
        var PokemonProperties = new Dictionary<string, Pokemon>();

        string input;
        while ((input = ReadLine()) != "wubbalubbadubdub")
        {
            var temp = input.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length==3)
            {
                var pokemonName = temp[0];
                var evolutionType = temp[1];
                var evolutionIndex = long.Parse(temp[2]);

                if (PokemonProperties.ContainsKey(pokemonName))
                    PokemonProperties[pokemonName].AddEvolution(evolutionIndex, evolutionType);
                else
                    PokemonProperties[pokemonName] = new Pokemon(pokemonName, evolutionType, evolutionIndex);
            }
            if (temp.Length==1)
            {
                var pokemonName = temp[0];
                if (PokemonProperties.ContainsKey(pokemonName))
                {
                    WriteLine($"# {pokemonName}");
                    for(int i=0;i<PokemonProperties[pokemonName].RawEvolutionsList[0].Count;i++)
                        WriteLine(PokemonProperties[pokemonName].RawEvolutionsList[1][i] + " <-> " + PokemonProperties[pokemonName].RawEvolutionsList[0][i]);
                }
            }
        }

        foreach (var pokeon in PokemonProperties)
        {
            pokeon.Value.OrderEvolutionsByIndex();
            WriteLine($"# {pokeon.Key}");
            foreach (var evolutionType in pokeon.Value.Evolutions)
                foreach (var evolution in evolutionType.Value)
                    WriteLine(evolution + " <-> " + evolutionType.Key);
        }
    }
}
