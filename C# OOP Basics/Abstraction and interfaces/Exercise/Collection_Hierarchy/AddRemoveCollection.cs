using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collection_Hierarchy
{
    public class AddRemoveCollection : IAddable, IRemoveable
    {
        protected List<string> collection;

        public AddRemoveCollection()
        {
            collection = new List<string>();
        }

        /// <summary>
        /// Add item at the start of the collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Add(string item)
        {
            collection = new List<string> { item }.Concat(collection).ToList();

            return 0;
        }

        /// <summary>
        /// Remove item at the end of the collection
        /// </summary>
        /// <returns></returns>
        public virtual string Remove()
        {
            var lastElement = collection.Last();
            collection.RemoveAt(collection.Count-1);

            return lastElement;
        }
    }
}
