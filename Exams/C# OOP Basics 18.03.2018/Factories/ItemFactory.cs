using System;
using System.Collections.Generic;
using System.Text;

public class ItemFactory
{
    public static Item CreateItem(string itemName)
    {
        if (itemName != "PoisonPotion" && itemName != "HealthPotion" && itemName != "ArmorRepairKit")
            throw new ArgumentException($"Invalid item \"{itemName}\"!");

        var item = Activator.CreateInstance(Type.GetType(itemName)) as Item;

        return item;
    }
}
