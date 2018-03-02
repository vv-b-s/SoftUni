using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday_Celebrations
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var livingThings = new List<LivingEntity>();

            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                var data = input.Split();
                var creature = NameableEntityFactory.CreateEntity(data);

                if (creature is LivingEntity)
                    livingThings.Add(creature as LivingEntity);
            }

            var searchedBirthYear = int.Parse(Console.ReadLine());

            var listOfBirthdays = livingThings
                .Where(lt => lt.IsBornInYear(searchedBirthYear))
                .Select(lt=>lt.Birthdate)
                .DefaultIfEmpty(null);

            Console.WriteLine(string.Join(Environment.NewLine,listOfBirthdays));
        }
    }
}
