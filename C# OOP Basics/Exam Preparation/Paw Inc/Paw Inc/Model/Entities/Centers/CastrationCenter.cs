using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CastrationCenter : Center
{
    private static List<Animal> castratedAnimals;
    public  CastrationCenter(string name) : base(name)
    {
        if (castratedAnimals is null)
            castratedAnimals = new List<Animal>();
    }

    public static IReadOnlyCollection<Animal> CastratedAnimals => castratedAnimals;

    public void Castrate()
    {
        foreach(var animal in this.StoredAnimals)
        {
            var adoptionCenter = Center.GetCenter(animal.AdoptionCenter) as AdoptionCenter;
            adoptionCenter.RegisterAnimal(animal);

            castratedAnimals.Add(animal);
        }

        this.StoredAnimals.Clear();
    }
}
