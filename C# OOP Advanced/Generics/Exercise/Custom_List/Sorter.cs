using System;
using System.Linq;

public class Sorter
{
    public static TList Sort<TList, TComparableType>(TList list) where TList : class, ICustomList<TComparableType> where TComparableType : IComparable<TComparableType>
    {
        var sortedList = list.OrderBy(li => li);
        return new CustomList<TComparableType>(sortedList) as TList;
    }
}