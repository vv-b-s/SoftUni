using System;

class Program
{
    static void Main(string[] args)
    {
        var nameAddressTown = Console.ReadLine();
        var nameBeerLitersDrunk = Console.ReadLine();
        var bankdata = Console.ReadLine();

        var nameAddressTownTuple = GetNameAddressTown(nameAddressTown.Split());
        var nameBeerLitersTupleDrunk = GetNameBeerLitersDrunk(nameBeerLitersDrunk.Split());
        var bankdataTuple = GetBankDataTuple(bankdata.Split());

        System.Console.WriteLine(nameAddressTownTuple);
        System.Console.WriteLine(nameBeerLitersTupleDrunk);
        System.Console.WriteLine(bankdataTuple);
    }

    private static Threeuple<string, double, string> GetBankDataTuple(string[] data)
    {
        var name = data[0];
        var money = double.Parse(data[1]);
        var document = data[2];

        return new Threeuple<string, double, string>(name, money, document);
    }

    private static Threeuple<string, double, bool> GetNameBeerLitersDrunk(string[] data)
    {
        var name = data[0];
        var liters = double.Parse(data[1]);
        var isDrunk = data[2] == "drunk";
        return new Threeuple<string, double, bool>(name, liters, isDrunk);
    }

    private static Threeuple<string, string, string> GetNameAddressTown(string[] data)
    {
        var name = $"{data[0]} {data[1]}";
        var address = data[2];
        var town = data[3];

        return new Threeuple<string, string, string>(name, address, town);
    }
}