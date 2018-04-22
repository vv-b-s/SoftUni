using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RecipeItem : AbstractItem, IRecipe
{
    private List<string> requiredItems;

    public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, IEnumerable<string> requiredItems) : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.requiredItems = new List<string>(requiredItems);
    }

    IReadOnlyList<string> IRecipe.RequiredItems => this.requiredItems.AsReadOnly();
}
