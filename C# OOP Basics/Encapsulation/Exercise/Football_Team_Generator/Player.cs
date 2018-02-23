using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator
{
    public class Player
    {
        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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

        public double Endurance
        {
            get => endurance;
            private set
            {
                ValidateStats("Endurance", value);
                endurance = value;
            }
        }

        public double Sprint
        {
            get => sprint;
            private set
            {
                ValidateStats("Sprint", value);
                sprint = value;
            }
        }

        public double Dribble
        {
            get => dribble;
            set
            {
                ValidateStats("Dribble", value);
                dribble = value;
            }
        }

        public double Passing
        {
            get => passing;
            private set
            {
                ValidateStats("Passing", value);
                passing = value;
            }
        }

        public double Shooting
        {
            get => shooting;
            private set
            {
                ValidateStats("Shooting", value);
                shooting = value;
            }
        }

        public double AverageOverallSkill => (endurance + sprint + dribble + passing + shooting) / 5;

        private void ValidateStats(string statsName, double value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentException($"{statsName} should be between 0 and 100.");
        }
    }
}
