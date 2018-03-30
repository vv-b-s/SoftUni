using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class Stack<T> : IStack<T>
    {
        private T[] elements;
        private int numberOfAddedElements;
        private int indexOfLastElement = -1;

        public Stack()
        {
            elements = new T[4];
        }

        public T Pop()
        {
            if (numberOfAddedElements == 0)
                throw new InvalidOperationException("No elements");

            var element = this.elements[indexOfLastElement];
            this.elements[indexOfLastElement] = default(T);
            indexOfLastElement--;
            numberOfAddedElements--;

            ResizeArray();
            return element;
        }

        public void Push(T item)
        {
            numberOfAddedElements++;
            indexOfLastElement++;

            this.elements[indexOfLastElement] = item;

            ResizeArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = indexOfLastElement; i >= 0; i--)
                yield return this.elements[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ResizeArray()
        {
            if (numberOfAddedElements == this.elements.Length - 2)
                Array.Resize(ref this.elements, this.elements.Length * 2);

            else if (numberOfAddedElements < this.elements.Length - 2 && numberOfAddedElements > 3)
                Array.Resize(ref this.elements, this.elements.Length / 2);
        }
    }
}
