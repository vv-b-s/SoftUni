using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;
    private IHeroFactory heroFactory;
    private IItemFactory itemFactory;
    private IRecipeFactory recipeFactory;

    public HeroManager(IHeroFactory heroFactory, IItemFactory itemFactory, IRecipeFactory recipeFactory)
    {
        this.heroFactory = heroFactory;
        this.itemFactory = itemFactory;
        this.recipeFactory = recipeFactory;

        this.heroes = new Dictionary<string, IHero>();
    }

    public IReadOnlyDictionary<string, IHero> Heroes => this.heroes;

    public string AddHero(string heroName, string heroType)
    {
        var result = "";

        var hero = heroFactory.CreateHero(heroName, heroType);
        this.heroes[heroName] = hero;

        result = string.Format(Constants.HeroCreateMessage, heroType, heroName);

        return result;
    }

    public string AddItemToHero(string itemName, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus)
    {
        var hero = this.heroes[heroName];
        var item = itemFactory.CreateItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus);

        hero.AddItem(item);

        return string.Format(Constants.ItemCreateMessage, itemName, heroName);
    }

    public string AddRecipeToHero(string recipeName, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, IList<string> requiredItems)
    {
        var hero = this.heroes[heroName];
        var recipe = recipeFactory.CreateItem(recipeName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);

        hero.AddRecipe(recipe);

        return string.Format(Constants.RecipeCreatedMessage, recipeName, heroName);
    }

    public string Inspect(string heroName) => this.heroes[heroName].ToString();


    public string Quit()
    {
        var heroes = this.heroes.Values
            .OrderByDescending(h => h.Strength + h.Agility + h.Intelligence)
            .ThenByDescending(h => h.HitPoints + h.Damage)
            .ToArray();

        var sB = new StringBuilder();

        for(int i = 0;i<heroes.Length;i++)
        {
            var hero = heroes[i];

            sB.AppendLine($"{i + 1}. {hero.GetType().Name}: {hero.Name}")
                .AppendLine($"###HitPoints: {hero.HitPoints}")
                .AppendLine($"###Damage: {hero.Damage}")
                .AppendLine($"###Strength: {hero.Strength}")
                .AppendLine($"###Agility: {hero.Agility}")
                .AppendLine($"###Intelligence: {hero.Intelligence}")
                .Append($"###Items: ");

            if (!hero.Items.Any())
                sB.Append("None");
            else
                sB.AppendLine(string.Join(", ", hero.Items.Select(it => it.Name)));
        }

        return sB.ToString();
    }
}