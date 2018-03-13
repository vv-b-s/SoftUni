using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Center : ICenter
{
    private static Dictionary<string, Center> registeredCenters;

    private string name;
    private List<Animal> storedAnimals;

    protected Center(string name)
    {
        this.Name = name;
        this.StoredAnimals = new List<Animal>();

        if (registeredCenters is null)
            registeredCenters = new Dictionary<string, Center>();
    }

    public static IReadOnlyDictionary<string, Center> RegisteredCenters => registeredCenters;

    public string Name
    {
        get => this.name;
        protected set => this.name = value;
    }

    protected List<Animal> StoredAnimals
    {
        get => this.storedAnimals;
        set => this.storedAnimals = value;
    }

    /// <summary>
    /// Registers an animal to the center
    /// </summary>
    /// <param name="animal"></param>
    public void RegisterAnimal(Animal animal)
    {
        this.StoredAnimals.Add(animal);
    }

    /// <summary>
    /// Registers a center.
    /// </summary>
    /// <param name="center"></param>
    public static void RegisterCenter(Center center)
    {
        registeredCenters[center.Name] = center;
    }

    public static Center GetCenter(string centerName)
    {
        if (registeredCenters.ContainsKey(centerName))
            return registeredCenters[centerName];

        else return null;
    }
}