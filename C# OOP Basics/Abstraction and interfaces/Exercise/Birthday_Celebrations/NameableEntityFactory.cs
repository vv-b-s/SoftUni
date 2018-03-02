using Birthday_Celebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Birthday_Celebrations
{
    public static class NameableEntityFactory
    {
        public static INameable CreateEntity(string[] data)
        {
            var dataType = data[0];
            var arguments = data.Skip(1).ToArray();

            switch (dataType.ToLower())
            {
                case "citizen": return new Citizen(alias: arguments[0], age: int.Parse(arguments[1]), id: arguments[2], birthDate: arguments[3]);
                case "robot": return new Robot(alias: arguments[0], id: arguments[1]);
                case "pet": return new Pet(alias: arguments[0], birthdate: arguments[1]);
                default: return null;
            }

        }
    }
}
