namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public List<Book> Books { get; private set; }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.Books.Count; i++)
            {
                yield return this.Books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
