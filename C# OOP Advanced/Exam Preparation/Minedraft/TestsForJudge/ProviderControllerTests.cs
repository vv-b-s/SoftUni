using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

[TestFixture]
public class ProviderControllerTests
{
    private int numberOfProviderArgs;

    private IEnergyRepository energyRepository;
    private ProviderController providerController;

    [SetUp]
    public void Init()
    {
        this.energyRepository = new EnergyRepository();
        providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void ProviderControllerEntityRepositoryIncreasesTheValueOfEnergyWhenProducing()
    {
        FillProviderControllerWithEntities();

        var expectedEnergyYield = this.providerController.Entities.Sum(e => ((IProvider)e).EnergyOutput);

        this.providerController.Produce();

        Assert.That(energyRepository.EnergyStored, Is.EqualTo(expectedEnergyYield));
    }

    [Test]
    public void ProviderControllerBrokenEntitiesGetRemoved()
    {
        FillProviderControllerWithEntities();

        var initialCountOfEntities = this.providerController.Entities.Count;

        for (int i = 0; i < 100; i++)
        {
            this.providerController.Produce();
            var currentCountOfProviders = this.providerController.Entities.Count;

            if (currentCountOfProviders < initialCountOfEntities)
                break;
        }

        Assert.That(this.providerController.Entities.Count, Is.LessThan(initialCountOfEntities));
    }

    private List<List<string>> GenerateArgs()
    {
        var providerTypes = GetAllProviders()
            .Select(p => p.Name)
            .Select(p => p.Substring(0, p.IndexOf("Provider")))
            .ToArray();

        var args = new List<List<string>>();

        for (int i = 0; i < providerTypes.Length; i++)
        {
            var argumentLine = new List<string> { providerTypes[i], $"{i}", $"{i * 100}" };
            args.Add(argumentLine);
        }

        this.numberOfProviderArgs = args.Count;
        return args;
    }

    private Type[] GetAllProviders() => typeof(IProvider)
            .Assembly
            .GetTypes()
            .Where(t => t.Name.EndsWith("Provider") && !t.IsAbstract && !t.IsInterface).ToArray();

    private void FillProviderControllerWithEntities()
    {
        var arguments = GenerateArgs();

        foreach (var argument in arguments)
            this.providerController.Register(argument);
    }
}