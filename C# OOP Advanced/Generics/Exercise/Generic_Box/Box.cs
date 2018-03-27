using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Box<TItemType>:IBox<TItemType>
{
    private List<TItemType> items;

    public Box()
    {
        this.items = new List<TItemType>();
    }

    public Box(params TItemType[] items) : this()
    {
        AddItems(items);
    }

    public void AddItems(params TItemType[] items)
    {
        this.items = this.items.Concat(items).ToList();
    }

    public override string ToString()
    {
        var output = string.Join(Environment.NewLine,this.items.Select(i=>$"{i.GetType().FullName}: {i}"));
        
        return output;
    }
}