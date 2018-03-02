using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection_Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var itemsToAdd = new List<string>(Console.ReadLine().Split());
            var numberOfItemsToRemove = int.Parse(Console.ReadLine());

            var iAddables = new IAddable[] { addCollection, addRemoveCollection, myList };
            foreach(var addable in iAddables)
            {
                var indexes = new List<int>();

                foreach (var item in itemsToAdd)
                    indexes.Add(addable.Add(item));

                Console.WriteLine(string.Join(" ", indexes));
            }

            //Only the first item in iAddables does not implement IRemovable so it is excluded. All other items are converted to IRemovable so the Remove() method can be used
            var removables = iAddables.Skip(1).Select(addable => addable as IRemoveable).ToList();
            foreach(var removable in removables)
            {
                var removedItems = new List<string>();

                for (int i = 0; i < numberOfItemsToRemove; i++)
                    removedItems.Add(removable.Remove());

                Console.WriteLine(string.Join(" ",removedItems));
            }
        }
    }
}
