using System;
using System.Collections.Generic;
using System.Text;

public class RandomList : List<string>
{
    public string RandomString()
    {
        var randomIndex = new Random().Next(Count);

        var str = this[randomIndex];
        RemoveAt(randomIndex);

        return str;
    }
}
