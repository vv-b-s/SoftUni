using Google.PersonData;
using System;
using System.Collections.Generic;

namespace Google
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            var peopleData = new Dictionary<string, Person>();

            while((input=Console.ReadLine())!="End")
            {
                var data = input.Split();

                var name = data[0];
                var dataType = data[1];

                if (!peopleData.ContainsKey(name))
                    peopleData[name] = new Person(name);

                if (dataType == "company")
                    peopleData[name].SetCompany(name: data[2], department: data[3], salery: decimal.Parse(data[4]));

                else if (dataType == "car")
                    peopleData[name].SetCar(model: data[2], speed: double.Parse(data[3]));

                else if (dataType == "pokemon")
                    peopleData[name].Pokemons.Add(new Pokemon(name: data[2], type: data[3]));

                else if (dataType == "children")
                    peopleData[name].Children.Add(new Child(name: data[2], birthday: data[3]));

                else if (dataType == "parents")
                    peopleData[name].Parents.Add(new Parent(name: data[2], birthday: data[3]));
            }

            var searchedFor = Console.ReadLine();
            if (!peopleData.ContainsKey(searchedFor))
                peopleData[searchedFor] = new Person(searchedFor);

            Console.WriteLine(peopleData[searchedFor]);
        }
    }
}
