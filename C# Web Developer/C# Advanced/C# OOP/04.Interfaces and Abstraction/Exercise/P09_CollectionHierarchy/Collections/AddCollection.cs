namespace P09_CollectionHierarchy.Collections
{
    using Contracts;
    using System.Collections.Generic;

    public class AddCollection<T> : IAddable<T>
    {
        //--------------- Fields ------------------
        private IList<T> collection;

        //------------ Constructors ---------------
        public AddCollection()
        {
            this.collection = new List<T>();
        }

        //------------- Properties ----------------
        protected IList<T> Collection { get { return this.collection; } }

        //-------------- Methods ------------------
        public virtual int Add(T item)
        {
            this.collection.Add(item);
            return this.Collection.Count - 1;
        }
    }
}
