using Google.PersonData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Person
    {
        public string Name { get; private set; }
        public Company Company { get; private set; }
        public Car Car { get; private set; }
        public List<Parent> Parents { get; set; }
        public List<Child> Children { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Person(string name)
        {
            Name = name;

            Parents = new List<Parent>();
            Children = new List<Child>();
            Pokemons = new List<Pokemon>();
        }

        /// <summary>
        /// Set/change the value of a company
        /// </summary>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="salery"></param>
        public void SetCompany(string name, string department, decimal salery)
        {
            if (Company is null)
                Company = new Company(name, department, salery);
            else
            {
                Company.Name = name;
                Company.Department = department;
                Company.Salery = salery;
            }
        }

        /// <summary>
        /// Set the car or change its value
        /// </summary>
        /// <param name="model"></param>
        /// <param name="speed"></param>
        public void SetCar(string model, double speed)
        {
            if (Car is null)
                Car = new Car(model, speed);
            else
            {
                Car.Model = model;
                Car.Speed = speed;
            }
        }

        public override string ToString()
        {
            var sB = new StringBuilder();
            sB.Append($"{Name}\n");

            sB.Append("Company:\n");
            if (Company != null)
                sB.Append($"{Company}\n");

            sB.Append("Car:\n");
            if (Car != null)
                sB.Append($"{Car}\n");

            sB.Append("Pokemon:\n");
            if (Pokemons.Count > 0)
                sB.Append($"{string.Join("\n", Pokemons)}\n");

            sB.Append("Parents:\n");
            if (Parents.Count > 0)
                sB.Append($"{ string.Join("\n", Parents)}\n");

            sB.Append("Children:\n");
            if (Children.Count > 0)
                sB.Append($"{string.Join("\n", Children)}\n");

            return sB.ToString();
        }
    }
}
