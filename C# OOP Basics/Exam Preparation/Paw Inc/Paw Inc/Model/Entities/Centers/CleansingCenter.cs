using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CleansingCenter : Center
{
    private static List<Animal> cleansedAnimals;

    public CleansingCenter(string name) : base(name)
    {        
        if(cleansedAnimals is null)
            cleansedAnimals = new List<Animal>();
    }

    public static IReadOnlyCollection<Animal> CleansedAnimals => cleansedAnimals;

    public int AnimalsAwaitingCleansing => this.StoredAnimals.Count;

    /// <summary>
    /// Cleanses all animals from the given Cleansing center and returns them to their corresponding Adoption centers.
    /// </summary>
    public void Cleanse()
    {
        foreach(var animal in this.StoredAnimals)
        {
            animal.CleansingStatus = CleansingStatus.Cleansed;

            var belongingAdoptionCenter = Center.GetCenter(animal.AdoptionCenter);

            if (belongingAdoptionCenter != null)
                belongingAdoptionCenter.RegisterAnimal(animal);

            cleansedAnimals.Add(animal);
        }

        this.StoredAnimals.Clear();
    }
}
