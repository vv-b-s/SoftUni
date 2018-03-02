using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy
{
    public interface IAddable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The index of the element in the collection</returns>
        int Add(string item);
    }
}
