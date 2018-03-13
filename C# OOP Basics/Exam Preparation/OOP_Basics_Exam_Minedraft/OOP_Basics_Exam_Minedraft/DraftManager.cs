using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;


    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;

    public DraftManager()
    {
        this.mode = "Full";
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
    }


    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = HarvesterFactory.GetHarvester(arguments);
            this.harvesters[harvester.Id] = harvester;

            return $"Successfully registered {arguments[0]} Harvester - {harvester.Id}";
        }
        catch(ArgumentException e)
        {
            return e.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = ProviderFactory.GetProvider(arguments);
            this.providers[provider.Id] = provider;

            return $"Successfully registered {arguments[0]} Provider - {provider.Id}";
        }
        catch(ArgumentException e)
        {
            return e.Message;
        }        
    }

    public string Day()
    {
        var energyProvided = providers.Values.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += energyProvided;

        var energyRequirement = CalculateEnergyRequirement();
        var oresMined = 0.0;

        if (energyRequirement <= this.totalStoredEnergy)
        {
            this.totalStoredEnergy -= energyRequirement;

            switch (mode)
            {
                case "Full":
                    oresMined = harvesters.Values.Sum(h => h.OreOutput);
                    break;

                case "Half":
                    oresMined = harvesters.Values.Sum(h => h.OreOutput) * 0.5;
                    break;
            }
        }

        this.totalMinedOre += oresMined;

        return $"A day has passed.{Environment.NewLine}" +
            $"Energy Provided: {energyProvided}{Environment.NewLine}" +
            $"Plumbus Ore Mined: {oresMined}";
    }


    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        if (harvesters.ContainsKey(id))
            return harvesters[id].ToString();

        if (providers.ContainsKey(id))
            return providers[id].ToString();

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var text =  $"System Shutdown{Environment.NewLine}" +
            $"Total Energy Stored: {this.totalStoredEnergy}{Environment.NewLine}" +
            $"Total Mined Plumbus Ore: {this.totalMinedOre}";

        return text;
    }

    private double CalculateEnergyRequirement()
    {
        switch (mode)
        {
            case "Full":
                return harvesters.Values.Sum(h => h.EnergyRequirement);

            case "Half":
                return harvesters.Values.Sum(h => h.EnergyRequirement) * 0.6;
        }

        return 0;
    }
}