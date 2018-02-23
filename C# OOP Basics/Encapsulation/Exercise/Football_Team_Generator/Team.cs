using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            Name = name;

            players = new Dictionary<string, Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"A name should not be empty.");
                else name = value;
            }
        }

        public int Rating => players.Count > 0 ? (int)Math.Round(players.Values.Average(p => p.AverageOverallSkill), 0) : 0;
        public int NumberOfPlayers => players.Count;

        public void AddPlayer(Player player) => players[player.Name] = player;

        public void RemovePlayer(string playerName)
        {
            if (players.ContainsKey(playerName))
                players.Remove(playerName);
            else throw new ArgumentException($"Player {playerName} is not in {Name} team.");
        }
    }
}
