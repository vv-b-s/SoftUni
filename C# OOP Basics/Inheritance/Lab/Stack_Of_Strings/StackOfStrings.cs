using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings() => data = new List<string>();

    public void Push(string item) => data.Add(item);

    public string Pop()
    {
        var value = data.Last();
        data.Remove(data.Last());

        return value;
    }

    public string Peek()
    {
        var value = Pop();
        data.Add(value);

        return value;
    }

    public bool IsEmpty() => data.Count == 0;
}