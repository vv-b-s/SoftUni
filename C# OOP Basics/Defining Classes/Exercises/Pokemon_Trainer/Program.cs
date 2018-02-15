using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();

            var input = "";
            while((input = Console.ReadLine())!="Tournament")
            {
                var data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var trainerName = data[0];
                var pokemonName = data[1];
                var element = data[2];
                var health = double.Parse(data[3]);

                if(!trainers.ContainsKey(trainerName))
                    trainers[trainerName] = new Trainer(trainerName);

                trainers[trainerName].PokemonCollection.Add(new Pokemon(pokemonName, element, health));
            }

            while((input = Console.ReadLine())!="End")
            {
                foreach (var trainer in trainers)
                    trainer.Value.CheckForPokemonWithElmemnt(input);
            }

            Console.WriteLine(string.Join("\n", trainers.Values.OrderByDescending(t=>t.NumberOfBadges)));
        }
    }
}
