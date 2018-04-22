using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ItemCommand : Command
{
    public ItemCommand(IList<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        var itemName = Arguments[0];
        var heroName = Arguments[1];
        var strengthBonus = long.Parse(Arguments[2]);
        var agilityBonus = long.Parse(Arguments[3]);
        var intelligenceBonus = long.Parse(Arguments[4]);
        var hitPointsBonus = long.Parse(Arguments[5]);
        var damageBonus = long.Parse(Arguments[6]);

        var result = Manager.AddItemToHero(itemName, heroName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);

        return result;
    }
}