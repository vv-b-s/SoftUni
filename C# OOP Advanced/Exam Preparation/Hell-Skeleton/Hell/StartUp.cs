public class StartUp
{
    public static void Main()
    {
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();

        var heroFactory = new HeroFactory();
        var itemFactory = new ItemFactory();
        var recipeFactory = new RecipeFactory();

        IManager manager = new HeroManager(heroFactory,itemFactory,recipeFactory);

        Engine engine = new Engine(reader, writer, manager);
        engine.Run();
    }
}