using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bubble_Sort_Test.App
{
    public class Bubble
    {
        public static IEnumerable<T> Sort<T>(IEnumerable<T> items) where T : IComparable<T>
        {
            var array = items.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (array[i].CompareTo(array[j]) == 1)
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }

            return array;
        }
    }
}
