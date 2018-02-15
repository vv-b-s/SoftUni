using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokemon_Trainer
{
    class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> PokemonCollection { get; set; }

        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            PokemonCollection = new List<Pokemon>();
        }

        /// <summary>
        /// Checks the pokemon collection if it contains a pokemon with the desired element. If not, it drops 10 HP from all pokemons and removes dead ones
        /// </summary>
        /// <param name="element"></param>
        public void CheckForPokemonWithElmemnt(string element)
        {
            if (PokemonCollection.Any(p => p.Element == element))
                NumberOfBadges++;
            else
            {
                var pokemonsToRemove = new Queue<Pokemon>();
                foreach(var pokemon in PokemonCollection)
                {
                    pokemon.Health -= 10;
                    if (pokemon.Health <= 0)
                        pokemonsToRemove.Enqueue(pokemon);
                }

                while (pokemonsToRemove.Count > 0)
                    PokemonCollection.Remove(pokemonsToRemove.Dequeue());
            }
        }

        public override string ToString() => $"{Name} {NumberOfBadges} {PokemonCollection.Count}";
    }
}
