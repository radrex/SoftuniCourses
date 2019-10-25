namespace P07_CustomLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomLinkedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private class Node
        {
            //------------- Constructors ---------------
            public Node(T value)
            {
                this.Value = value;
            }

            //-------------- Properties ----------------
            public T Value { get; set; }
            public Node Next { get; set; }
        }

        //-------------- Properties ----------------
        private Node Head { get; set; }
        private Node Tail { get; set; }
        public int Count { get; set; }

        //--------------- Methods ------------------
        public void Add(T item)
        {
            if (Count == 0)
            {
                this.Head = this.Tail = new Node(item);
            }
            else
            {
                Node oldTail = this.Tail;
                oldTail.Next = this.Tail = new Node(item);
            }

            this.Count++;
        }

        public void Remove(T item)
        {
            if (this.Count == 0)
            {
                return;
            }

            if (this.Head.Value.CompareTo(item) == 0)
            {
                this.Head = this.Head.Next;
                this.Count--;
                return;
            }

            Node previous = this.Head;
            Node current = this.Head.Next;

            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    previous.Next = current.Next;
                    this.Count--;
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
