namespace SIS.MvcFramework
{
    using System;

    public interface IServiceCollection
    {
        void Add<TSource, TDestination>()
            where TDestination : TSource;
        object CreateInstance(Type type);
        T CreateInstance<T>();
    }
}
