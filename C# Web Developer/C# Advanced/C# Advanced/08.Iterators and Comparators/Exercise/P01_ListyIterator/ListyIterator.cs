namespace P01_ListyIterator
{
    using System;
    using System.Collections.Generic;

    public class ListyIterator<T>
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
    }
}
