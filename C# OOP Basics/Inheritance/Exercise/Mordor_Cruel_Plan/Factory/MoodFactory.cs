using Mordor_Cruel_Plan.Foods;
using Mordor_Cruel_Plan.Moods;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordor_Cruel_Plan.Factory
{
    class MoodFactory : IFactory<Mood>
    {
        private List<Food> foods;

        public Mood Manufacture(object type)
        {
            foods = type as List<Food>;
            var moodPoints = CalculateMood();

            if (moodPoints < -5)
                return new Angry();

            else if (moodPoints >= -5 && moodPoints <= 0)
                return new Sad();

            else if (moodPoints >= 1 & moodPoints <= 15)
                return new Happy();

            else return new JavaScript();
        }

        private int CalculateMood() => foods.Sum(f => f.MoodPoints);
    }
}
