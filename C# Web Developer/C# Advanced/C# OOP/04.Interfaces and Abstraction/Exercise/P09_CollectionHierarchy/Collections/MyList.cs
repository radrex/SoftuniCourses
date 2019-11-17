namespace P09_CollectionHierarchy.Collections
{
    using Contracts;

    public class MyList<T> : AddRemoveCollection<T>, IUsable
    {
        //------------ Constructors ---------------
        public MyList()
            : base() { }

        //------------- Properties ----------------
        public int Used => this.Collection.Count;

        //-------------- Methods ------------------
        public override T Remove()
        {
            T removedItem = this.Collection[0];
            this.Collection.RemoveAt(0);
            return removedItem;
        }
    }
}
