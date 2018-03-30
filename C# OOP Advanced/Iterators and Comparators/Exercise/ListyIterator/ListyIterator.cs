using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<TItem> : IIterator<TItem>, IEnumerable<TItem>
    {
        private IList<TItem> collection;
        private int index = 0;

        public ListyIterator(IList<TItem> collection)
        {
            this.collection = collection;
        }

        public bool HasNext => index + 1 < this.collection.Count;

        public IEnumerator<TItem> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
                yield return collection[i];
        }

        public bool Move()
        {
            if (this.HasNext)
            {
                index++;
                return true;
            }

            else return false;
        }

        public TItem Print()
        {
            if (this.collection.Count == 0)
                throw new InvalidOperationException("Invalid peration!");

            else return this.collection[index];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
