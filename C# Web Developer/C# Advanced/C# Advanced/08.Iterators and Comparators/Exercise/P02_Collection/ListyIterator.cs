namespace P02_Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        //---------------- Fields ------------------
        private List<T> collection;
        private int currentIndex;

        //------------- Constructors ---------------
        public ListyIterator(params T[] collection)
        {
            this.collection = new List<T>(collection);
        }

        //--------------- Methods ------------------
        public bool Move()
        {
            if (this.collection.Count - 1 > currentIndex)
            {
                currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return currentIndex + 1 < collection.Count;
        }

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.collection[currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
