using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public static class AnimalFactory
    {
        public static Animal GenerateAnimal(string animalType, params string[] inputData)
        {
            try
            {
                animalType = animalType.ToLower();
                var animalName = inputData[0];
                var animalAge = int.Parse(inputData[1]);
                Enum.TryParse(inputData[2], out Animal.Gender animalGender);

                switch (animalType)
                {
                    case "dog": return new Dog(animalName, animalAge, animalGender);
                    case "cat": return new Cat(animalName, animalAge, animalGender);
                    case "frog": return new Frog(animalName, animalAge, animalGender);
                    case "kitten": return new Kitten(animalName, animalAge, animalGender);
                    case "tomcat": return new Tomcat(animalName, animalAge, animalGender);
                    default: throw new ArgumentException("Invalid input!");
                }
            }
            catch (FormatException ex) { throw new ArgumentException("Invalid input!"); }
        }
    }
}
