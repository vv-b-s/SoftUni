public class Program
{
    public static void Main(string[] args)
    {
        var energyRepository = new EnergyRepository();

        var harvesterController = new HarvesterController(energyRepository);
        var providerController = new ProviderController(energyRepository);


        var interpreter = new CommandInterpreter(harvesterController, providerController);
        var readerWriter = new IO();

        Engine engine = new Engine(interpreter,readerWriter);
        engine.Run();
    }
}