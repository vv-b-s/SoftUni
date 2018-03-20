using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Bag : IBag
{
    private int capacity = 100;
    private List<Item> items;

    protected Bag(int capacity)
    {
        this.Capacity = capacity;
        this.items = new List<Item>();
    }

    public int Capacity
    {
        get => this.capacity;
        protected set => this.capacity = value;
    }

    public int Load => this.Items.Sum(i => i.Weight);

    public IReadOnlyCollection<Item> Items => this.items;

    public void AddItem(Item item)
    {
        var load = this.Load;
        if (item.Weight + load <= this.Capacity)
            this.items.Add(item);

        else throw new InvalidOperationException("Bag is full!");
    }

    public Item GetItem(string name)
    {
        if (this.Items.Count == 0)
            throw new InvalidOperationException("Bag is empty!");

        var item = this.Items.FirstOrDefault(i => i.GetType().Name == name);

        if (item is null)
            throw new ArgumentException($"No item with name {name} in bag!");

        else
        {
            this.items.Remove(item);
            return item;
        }
    }
}