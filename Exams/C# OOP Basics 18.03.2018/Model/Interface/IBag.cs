using System;
using System.Collections.Generic;
using System.Text;

public interface IBag
{
    int Capacity { get; }
    int Load { get; }
    IReadOnlyCollection<Item> Items { get; }

    void AddItem(Item item);
    Item GetItem(string name);
}
