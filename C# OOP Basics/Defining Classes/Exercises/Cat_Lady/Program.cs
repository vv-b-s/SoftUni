using Cat_Lady.Cats;
using System;
using System.Collections.Generic;

namespace Cat_Lady
{
    class Program
    {
        static void Main(string[] args)
        {
            var cats = new Dictionary<string, Cat>();

            var input = "";
            while((input=Console.ReadLine())!="End")
            {
                var data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var catType = data[0];
                var catName = data[1];

                if (catType == "Siamese")
                    cats[catName] = new SiameseCat(catName, earSize: long.Parse(data[2]));

                else if (catType == "Cymric")
                    cats[catName] = new CymricCat(catName, furLength: double.Parse(data[2]));

                else if (catType == "StreetExtraordinaire")
                    cats[catName] = new StreetExtraordinaireCat(catName, decibelsOfMeowing: long.Parse(data[2]));
            }

            var catToLookFor = Console.ReadLine();

            Console.WriteLine(cats[catToLookFor]);
        }
    }
}
