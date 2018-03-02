using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy
{
    public class AddCollection:IAddable
    {
        private List<string> collection;

        public AddCollection()
        {
            collection = new List<string>();
        }

        /// <summary>
        /// Add item at the end of the collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Add(string item)
        {
            collection.Add(item);

            return collection.Count - 1;
        }
    }
}
