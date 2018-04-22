using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IRecipeFactory
{
    IRecipe CreateItem(string itemName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, IList<string> requiredItems);
}