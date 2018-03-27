using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Box<TItemType>
{
    private TItemType item;

    public Box(TItemType item)
    {
        this.item = item;
    }

    public override string ToString()
    {
        var output = $"{typeof(TItemType)}: {item}";
        
        return output;
    }
}