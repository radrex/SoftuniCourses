namespace BoxOfT
{
    using System;
    using System.Collections.Generic;

    public class Box<T>
    {
        //------------------- Fields ---------------------
        private List<T> list;

        //---------------- Constructors ------------------
        public Box()
        {
            this.list = new List<T>();
        }

        //----------------- Properties -------------------
        public int Count => this.list.Count;

        //------------------ Methods ---------------------
        public void Add(T element)
        {
            this.list.Add(element);
        }

        public T Remove()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove element from an empty box.");
            }

            T element = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);

            return element;
        }
    }
}
