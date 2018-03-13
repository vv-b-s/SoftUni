using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Interpreter
{
    public void RegisterCenter(Type centerType, string centerName)
    {
        var center = Activator.CreateInstance(centerType, centerName) as Center;

        Center.RegisterCenter(center);
    }

    public void RegisterAnimal(Type animalType, params string[] arguments)
    {
        var name = arguments[0];
        var age = int.Parse(arguments[1]);
        var specialAbilityAmount = int.Parse(arguments[2]);
        var adoptionCenterName = arguments[3];

        var animal = Activator.CreateInstance(animalType, name, age, specialAbilityAmount, adoptionCenterName) as Animal;

        Center.GetCenter(adoptionCenterName).RegisterAnimal(animal);
    }

    public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
    {
        var adoptionCenter = Center.GetCenter(adoptionCenterName) as AdoptionCenter;

        adoptionCenter.SendForCleansing(cleansingCenterName);
    }

    public void Cleanse(string cleansingCenterName)
    {
        var cleansingCenter = Center.GetCenter(cleansingCenterName) as CleansingCenter;

        cleansingCenter.Cleanse();
    }

    public void Adopt(string adoptionCenterName)
    {
        var adoptionCenter = Center.GetCenter(adoptionCenterName) as AdoptionCenter;

        adoptionCenter.Adopt();
    }

    public void SendForCastration(string adoptionCenterName, string castrationCenterName)
    {
        var adoptionCenter = Center.GetCenter(adoptionCenterName) as AdoptionCenter;

        adoptionCenter.SendForCastration(castrationCenterName);
    }

    public void Castrate(string castrationCenterName)
    {
        var castrationCenter = Center.GetCenter(castrationCenterName) as CastrationCenter;

        castrationCenter.Castrate();
    }

    public string CastrationStatistics()
    {
        var output = new StringBuilder("Paw Inc. Regular Castration Statistics" + Environment.NewLine);

        var numberOfCastrationCenters = Center.RegisteredCenters.Where(c => c.Value is CastrationCenter).Count();
        var namesOfCastratedAnimals = string.Join(", ", CastrationCenter.CastratedAnimals.Select(ca => ca.Name).OrderBy(an => an));

        output.AppendLine($"Castration Centers: {numberOfCastrationCenters}");
        output.Append($"Castrated Animals: {(string.IsNullOrEmpty(namesOfCastratedAnimals) ? "None" : namesOfCastratedAnimals)}");

        return output.ToString();
    }

    public string PawPawPawah()
    {
        var adoptionCenters = Center.RegisteredCenters.Where(c => c.Value is AdoptionCenter).Select(c => c.Value as AdoptionCenter);
        var cleansingCenters = Center.RegisteredCenters.Where(c => c.Value is CleansingCenter).Select(c => c.Value as CleansingCenter);

        var output = new StringBuilder("Paw Incorporative Regular Statistics" +Environment.NewLine);
        output.AppendLine($"Adoption Centers: {adoptionCenters.Count()}");
        output.AppendLine($"Cleansing Centers: {cleansingCenters.Count()}");

        var adoptedAnimalsNames = string.Join(", ", AdoptionCenter.AdoptedAnimals.Select(aa => aa.Name).OrderBy(an => an));
        output.AppendLine($"Adopted Animals: {(string.IsNullOrEmpty(adoptedAnimalsNames) ? "None" : adoptedAnimalsNames)}");

        var cleansedAnimalsNames = string.Join(", ", CleansingCenter.CleansedAnimals.Select(ca => ca.Name).OrderBy(an => an));
        output.AppendLine($"Cleansed Animals: {(string.IsNullOrEmpty(cleansedAnimalsNames) ? "None" : cleansedAnimalsNames)}");

        output.AppendLine($"Animals Awaiting Adoption: {adoptionCenters.Sum(ac => ac.AnimalsAwaitingAdoption)}");
        output.Append($"Animals Awaiting Cleansing: {cleansingCenters.Sum(cc => cc.AnimalsAwaitingCleansing)}");

        return output.ToString();
    }
}
