using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

[TestFixture]
public class HeroInventoryTests
{
    private HeroInventory heroInventory;

    private Dictionary<string, IItem> commonItems;
    private Dictionary<string, IRecipe> recipeItems;

    [SetUp]
    public void Init()
    {
        this.heroInventory = new HeroInventory();

        this.commonItems = heroInventory.GetType().GetField("commonItems", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this.heroInventory) as Dictionary<string, IItem>;
        this.recipeItems = heroInventory.GetType().GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this.heroInventory) as Dictionary<string, IRecipe>;
    }

    [Test]
    public void HeroInventoryAddCommonItemShouldAddItemToItems()
    {
        var item = new CommonItem("Pike", 100, 100, 100, 100, 100);
        heroInventory.AddCommonItem(item);

        Assert.That(this.commonItems.First().Value, Is.EqualTo(item));
    }

    [Test]
    public void HeroInventoryAddRecipeItemShouldWork()
    {
        var recipe = new RecipeItem("Banana", 100, 100, 100, 100, 100, new string[] { "Banana seeds" });

        this.heroInventory.AddRecipeItem(recipe);

        Assert.That(this.recipeItems.First().Value, Is.EqualTo(recipe));
    }

    [Test]
    public void HeroInventoryCheckRecipeShouldBeCalledWhenAddingRequiredItem()
    {
        var recipe = new RecipeItem("Banana", 100, 100, 100, 100, 100, new string[] { "Banana seeds" });
        var item = new CommonItem("Banana seeds", 100, 100, 100, 100, 100);

        this.heroInventory.AddRecipeItem(recipe);
        this.heroInventory.AddCommonItem(item);

        Assert.That(this.commonItems.First().Key, Is.EqualTo("Banana"));
    }

    [Test]
    public void HeroInventoryCheckRecipeShouldBeCalledWhenAddingNewRecipe()
    {
        var item = new CommonItem("Banana seeds", 100, 100, 100, 100, 100);
        var recipe = new RecipeItem("Banana", 100, 100, 100, 100, 100, new string[] { "Banana seeds" });

        this.heroInventory.AddRecipeItem(recipe);
        this.heroInventory.AddCommonItem(item);

        Assert.That(this.commonItems.First().Key, Is.EqualTo("Banana"));
    }

}