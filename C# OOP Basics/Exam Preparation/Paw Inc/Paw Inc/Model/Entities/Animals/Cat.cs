using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cat : Animal
{
    private int intelligenceCoefficient;

    public Cat(string name, int age, int intelligenceCoefficient, string adoptionCenter) : base(name, age, adoptionCenter)
    {
        this.IntelligenceCoefficient = intelligenceCoefficient;
    }

    public int IntelligenceCoefficient
    {
        get => this.intelligenceCoefficient;
        private set => this.intelligenceCoefficient = value;
    }
}
