public interface IHero
{
    long Agility { get; }
    long Damage { get; }
    long HitPoints { get; }
    long Intelligence { get; }
    System.Collections.Generic.IReadOnlyCollection<IItem> Items { get; }
    string Name { get; }
    long Strength { get; }

    void AddRecipe(IRecipe recipe);
    void AddItem(IItem item);
}