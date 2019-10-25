namespace P03_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomStack<T> : IEnumerable<T>
    {
        //---------------- Fields ------------------
        private List<T> elements;
        private int currentIndex = -1;

        //------------- Constructors ---------------
        public CustomStack()
        {
            this.elements = new List<T>();
        }

        //--------------- Methods ------------------
        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                elements.Insert(++currentIndex, item);
            }
        }

        public void Pop()
        {
            if (currentIndex < 0)
            {
                throw new InvalidOperationException("No elements");
            }

            currentIndex--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = currentIndex; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
