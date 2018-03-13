using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dog : Animal
{
    private int learnedCommands;

    public Dog(string name, int age, int learnedCommands, string adoptionCenter) : base(name, age, adoptionCenter)
    {
        this.LearnedCommands = learnedCommands;
    }

    public int LearnedCommands
    {
        get => this.learnedCommands;
        private set => this.learnedCommands = value;
    }
}