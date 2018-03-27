using System;

public class Scale<T> : IScale<T> where T : IComparable<T>
{
    private T item1;
    private T item2;

    public Scale(T item1, T item2)
    {
        this.item1 = item1;
        this.item2 = item2;
    }

    public T GetHeavier()
    {
        var result = item1.CompareTo(item2);

        if(result<0)
            return item2;
        
        else if(result>0)
            return item1;

        else
            return default(T);
    }
}