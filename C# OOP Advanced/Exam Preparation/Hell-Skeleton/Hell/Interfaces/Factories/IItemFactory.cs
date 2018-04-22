using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IItemFactory
{
    IItem CreateItem(string itemName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus);
}
