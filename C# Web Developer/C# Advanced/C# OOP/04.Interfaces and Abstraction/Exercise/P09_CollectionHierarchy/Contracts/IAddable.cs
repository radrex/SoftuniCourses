namespace P09_CollectionHierarchy.Contracts
{
    public interface IAddable<T>
    {
        //--------- Methods ---------
        int Add(T item);
    }
}
