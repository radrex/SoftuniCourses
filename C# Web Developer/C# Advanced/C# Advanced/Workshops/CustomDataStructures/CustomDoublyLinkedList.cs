namespace CustomDataStructures
{
    using System;

    public class CustomDoublyLinkedList<T>
    {
        //-------------- Private Class ---------------
        private class ListNode
        {
            //----------- Constructors ------------
            public ListNode(T value)
            {
                this.Value = value;
            }

            //------------ Propertirs -------------
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
            public T Value { get; set; }
        }

        //----------------- Fields -------------------
        private ListNode head;
        private ListNode tail;

        //--------------- Properties -----------------
        public int Count { get; private set; }

        //------------ Public Methods ----------------
        public void AddFirst(T element)
        {
            ListNode node = new ListNode(element);
            if (this.Count == 0)
            {
                this.head = this.tail = node;
            }
            else
            {
                node.NextNode = this.head;
                this.head.PreviousNode = node;
                this.head = node;
            }
            this.Count++;
        }

        public void AddLast(T element)
        {
            ListNode node = new ListNode(element);
            if (this.Count == 0)
            {
                this.head = this.tail = node;
            }
            else
            {
                node.PreviousNode = this.tail;
                this.tail.NextNode = node;
                this.tail = node;
            }
            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("DoublyLinkedList is empty!");
            }

            T removedElement = this.head.Value;
            ListNode node = this.head.NextNode;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                node.PreviousNode = null;
                this.head = node;
            }

            this.Count--;
            return removedElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("DoublyLinkedList is empty!");
            }

            T removedElement = this.tail.Value;
            ListNode node = this.tail.PreviousNode;
            if (this.Count == 1)
            {
                this.tail = this.head = null;
            }
            else
            {
                node.NextNode = null;
                this.tail = node;
            }

            this.Count--;
            return removedElement;
        }

        public void ForEach(Action<T> action, bool shouldStartFromHead)
        {
            ListNode node = this.head;
            if (!shouldStartFromHead)
            {
                node = this.tail;
            }

            while (node != null)
            {
                action(node.Value);
                if (!shouldStartFromHead)
                {
                    node = node.PreviousNode;
                }
                else
                {
                    node = node.NextNode;
                }
            }
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            ListNode node = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = node.Value;
                node = node.NextNode;
            }

            return array;
        }
    }
}
