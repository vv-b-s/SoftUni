using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Animal : IAnimal
{
    private CleansingStatus cleansingStatus;
    private string name;
    private int age;
    private string adoptionCenter;

    protected Animal(string name, int age, string adoptionCenter)
    {
        this.Name = name;
        this.Age = age;
        this.AdoptionCenter = adoptionCenter;

        this.CleansingStatus = CleansingStatus.Uncleansed;
    }

    public string Name
    {
        get => this.name;
        protected set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        protected set => this.age = value;
    }

    public CleansingStatus CleansingStatus
    {
        get => this.cleansingStatus;
        set => this.cleansingStatus = value;
    }

    public string AdoptionCenter
    {
        get => this.adoptionCenter;
        protected set => this.adoptionCenter = value;
    }

}