using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collection_Hierarchy
{
    public class MyList : AddRemoveCollection
    {
        public MyList() : base() { }

        /// <summary>
        /// Remove the first element of a collection
        /// </summary>
        /// <returns></returns>
        public override string Remove()
        {
            var firstElement = collection.First();
            collection.RemoveAt(0);

            return firstElement;
        }
    }
}
