using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wild_Farm.Animals.Abstracts;
using Wild_Farm.Foods;

namespace Wild_Farm
{
    public static class Factory
    {
        public static Animal ManufactureAnimal(params string[] data)
        {
            var typeName = data[0];
            var nmspace = "Wild_Farm.Animals";

            var animalType = GetType(nmspace, typeName);

            var animalIteslf = Activator.CreateInstance(animalType, Objectify(data.Skip(1))) as Animal;
            return animalIteslf;
        }

        public static Food ManufactureFood(params string[] data)
        {
            var typeName = data[0];
            var nmspace = "Wild_Farm.Foods";

            var foodType = GetType(nmspace, typeName);

            var foodItself = Activator.CreateInstance(foodType, int.Parse(data[1])) as Food;
            return foodItself;
        }

        private static Type GetType(string typeNamespace, string typeName) => Type.GetType($"{typeNamespace}.{typeName}");

        private static object[] Objectify(IEnumerable<object> data) => data.ToArray();
    }
}
