using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdoptionCenter : Center
{
    private static List<Animal> adoptedAnimals;

    public AdoptionCenter(string name) : base(name)
    {
        if (adoptedAnimals is null)
            adoptedAnimals = new List<Animal>();
    }

    public static IReadOnlyCollection<Animal> AdoptedAnimals => adoptedAnimals;

    public int AnimalsAwaitingAdoption => this.StoredAnimals.Where(a => a.CleansingStatus == CleansingStatus.Cleansed).Count();

    /// <summary>
    /// Removes the uncleacned animals from the center and sends them to a Cleancing Center
    /// </summary>
    /// <param name="cleansingCenterName"></param>
    public void SendForCleansing(string cleansingCenterName)
    {
        var cleansingCenter = Center.GetCenter(cleansingCenterName);

        if(cleansingCenter!=null)
        {
            var uncleansedPets = this.StoredAnimals.Where(a => a.CleansingStatus == CleansingStatus.Uncleansed);

            foreach (var animal in uncleansedPets)
                cleansingCenter.RegisterAnimal(animal);

            this.StoredAnimals = this.StoredAnimals.Except(uncleansedPets).ToList(); 
        }
    }

    /// <summary>
    /// Removes all cleanced animals from the center
    /// </summary>
    public void Adopt()
    {
        adoptedAnimals.AddRange(this.StoredAnimals.Where(a => a.CleansingStatus == CleansingStatus.Cleansed));
        this.StoredAnimals.RemoveAll(a => a.CleansingStatus == CleansingStatus.Cleansed);
    }

    /// <summary>
    /// Sends all the animals to a given castration center
    /// </summary>
    /// <param name="castrationCenterName"></param>
    public void SendForCastration(string castrationCenterName)
    {
        var castrationCenter = Center.GetCenter(castrationCenterName) as CastrationCenter;

        if (castrationCenter != null)
        {
            foreach (var animal in this.StoredAnimals)
                castrationCenter.RegisterAnimal(animal);

            this.StoredAnimals.Clear(); 
        }
    }
}