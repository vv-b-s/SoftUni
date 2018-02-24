using Mordor_Cruel_Plan.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mordor_Cruel_Plan.Factory
{
    class FoodFactory : IFactory<Food>
    {
        public Food Manufacture(object type)
        {
            string foodType = type as string;

            switch(foodType.ToLower())
            {
                case "cram": return new Cram();
                case "lembas": return new Lembas();
                case "apple": return new Apple();
                case "melon": return new Melon();
                case "honeycake": return new HoneyCake();
                case "mushrooms": return new Mushrooms();
                default: return new Food();
            }
        }
    }
}
