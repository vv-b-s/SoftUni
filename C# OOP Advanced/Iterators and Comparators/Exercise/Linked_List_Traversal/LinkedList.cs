using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linked_List_Traversal
{
    public class LinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        private T[] elements;
        private int numberOfAddedElements;
        private int indexOfLastElement = -1;

        public LinkedList()
        {
            this.elements = new T[4];
        }

        public int Count => numberOfAddedElements;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            numberOfAddedElements++;
            indexOfLastElement++;

            this.elements[indexOfLastElement] = item;

            ResizeArray();
        }

        public void Clear()
        {
            this.elements = new T[4];
            GC.Collect();
        }

        public bool Contains(T item)
        {
            foreach (var element in this)
            {
                if (element.Equals(item))
                    return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < numberOfAddedElements; i++)
                yield return this.elements[i];
        }

        public bool Remove(T item)
        {
            if (numberOfAddedElements == 0)
                return false;

            else
            {
                var elementRemoved = false;

                for(int i = 0;i<numberOfAddedElements;i++)
                {
                    if(this.elements[i].Equals(item))
                    {
                        elements[i] = default(T);
                        elementRemoved = true;
                        break;
                    }
                }

                if (elementRemoved)
                {
                    ShiftElements();

                    indexOfLastElement--;
                    numberOfAddedElements--;

                    ResizeArray(); 
                }

                return elementRemoved;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ResizeArray()
        {
            if (numberOfAddedElements == this.elements.Length - 2)
                Array.Resize(ref this.elements, this.elements.Length * 2);
        }

        /// <summary>
        /// Moves the elements to the left so there are no empty holes
        /// </summary>
        private void ShiftElements()
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                //If the element is empty
                if (this.elements[i].Equals(default(T)))
                {
                    //Look for non-empty elements
                    for (int j = i + 1; j < this.elements.Length; j++)
                    {
                        //and swap their value
                        if (!this.elements[j].Equals(default(T)))
                        {
                            var tmp = this.elements[j];
                            this.elements[j] = default(T);
                            this.elements[i] = tmp;
                            break;
                        }
                    }
                }
            }
        }
    }
}
