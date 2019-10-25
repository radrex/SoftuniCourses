namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        //------------------- Fields ----------------------
        private SortedSet<Book> books;

        //----------------- Constructors ------------------
        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books, new BookComparator());
        }

        //------------------- Methods ---------------------
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        //----------------- Nested Class ------------------
        private class LibraryIterator : IEnumerator<Book>
        {
            //-------------- Fields ----------------
            private int currentIndex;
            private readonly List<Book> books;

            //----------- Constructors -------------
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            //------------ Properties --------------
            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            //------------- Methods ----------------
            public void Dispose() { }

            public bool MoveNext()
            {
                return ++this.currentIndex < this.books.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
