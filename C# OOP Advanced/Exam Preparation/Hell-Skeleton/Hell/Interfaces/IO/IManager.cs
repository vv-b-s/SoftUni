using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IManager
{
    string Quit();
    string AddHero(string heroName, string heroType);
    string AddItemToHero(string name, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus);
    string AddRecipeToHero(string itemName, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, IList<string> requiredItems);
    string Inspect(string heroName);
}
