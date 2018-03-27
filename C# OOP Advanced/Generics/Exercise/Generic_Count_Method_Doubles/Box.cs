using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Box<TItemType> : IComparable<Box<TItemType>> where TItemType : IComparable<TItemType>
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

    public int CompareTo(Box<TItemType> other)
    {
        if (this > other)
            return 1;
        else if (this < other)
            return -1;
        else
            return 0;

    }

    public override bool Equals(object obj) => obj is Box<TItemType> box && box == this;

    public static bool operator >(Box<TItemType> box1, Box<TItemType> box2) => box1.item.CompareTo(box2.item) > 0;
    public static bool operator <(Box<TItemType> box1, Box<TItemType> box2) => box1.item.CompareTo(box2.item) < 0;
    public static bool operator ==(Box<TItemType> box1, Box<TItemType> box2) => box1.item.CompareTo(box2.item) == 0;
    public static bool operator !=(Box<TItemType> box1, Box<TItemType> box2) => !(box1 == box2);
}