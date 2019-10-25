namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        //----------------- Constructors ------------------
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        //------------------ Properties -------------------
        public List<Book> Books { get; private set; }

        //------------------- Methods ---------------------
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //----------------- Nested Class ------------------
        private class LibraryIterator : IEnumerator<Book>
        {
            //-------------- Fields ----------------
            private int currentIndex = -1;
            private readonly List<Book> books;

            //----------- Constructors -------------
            public LibraryIterator(List<Book> books)
            {
                this.books = books;
            }

            //------------ Properties --------------
            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            //------------- Methods ----------------
            public void Dispose() { }

            public bool MoveNext()
            {
                this.currentIndex++;
                if (this.currentIndex >= this.books.Count)
                {
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
