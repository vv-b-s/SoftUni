using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HarvesterController : IHarvesterController
{
    private Modes mode;

    private List<IHarvester> harvesters;
    private IHarvesterFactory factory;
    private IEnergyRepository energyRepository;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.factory = new HarvesterFactory();

        this.mode = Modes.Full;
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public enum Modes { Energy = 20, Half = 50, Full = 100 }

    public double OreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        Enum.TryParse(mode, out this.mode);

        var brokenHarvesters = new List<IHarvester>();

        this.harvesters.ForEach(h =>
        {
            try
            { h.Broke(); }
            catch (Exception) { brokenHarvesters.Add(h); }
        });

        this.harvesters = harvesters.Except(brokenHarvesters).ToList();

        return string.Format(Constants.ModeChange, mode);
    }

    public string Produce()
    {
        var energyReducePercent = (double)mode / 100;

        var totalEnergyConsumption = this.harvesters.Sum(h => h.EnergyRequirement * energyReducePercent);
        var currentOresProduced = 0.0;

        if (this.energyRepository.TakeEnergy(totalEnergyConsumption))
        {
            currentOresProduced = this.harvesters.Sum(h => h.OreOutput * energyReducePercent);
            this.OreProduced += currentOresProduced;
        }

        return string.Format(Constants.OreOutputToday, currentOresProduced);
    }

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }
}