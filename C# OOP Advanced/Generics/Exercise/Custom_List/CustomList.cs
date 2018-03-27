using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : ICustomList<T>, IEnumerable<T> where T : IComparable<T>
{
    private List<T> items;

    public CustomList(IEnumerable<T> items):this()
    {
        this.items = this.items.Concat(items).ToList();
    }
    public CustomList()
    {
        this.items = new List<T>();
    }

    public void Add(T element)
    {
        this.items.Add(element);
    }

    public bool Contains(T element)
    {
        return this.items.Contains(element);
    }

    public int CountGreaterThan(T element)
    {
        var count = this.items.Count(li => li.CompareTo(element) > 0);
        return count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach(var item in this.items)
            yield return item;
    }

    public T Max()
    {
        return this.items.Max();
    }

    public T Min()
    {
        return this.items.Min();
    }

    public T Remove(int index)
    {
        var item = this.items[index];
        this.items.Remove(item);

        return item;
    }

    public void Swap(int index1, int index2)
    {
        var tmp = this.items[index1];
        this.items[index1] = this.items[index2];
        this.items[index2] = tmp;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}