using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal
{
    public Animal(string name, string favoriteFood)
    {
        this.Name = name;
        this.FavoriteFood = favoriteFood;
    }

    public string Name { get; set; }
    public string FavoriteFood { get; set; }

    public virtual string ExplainSelf() => $"I am {this.Name} and my favorite food is {this.FavoriteFood}\n";
}