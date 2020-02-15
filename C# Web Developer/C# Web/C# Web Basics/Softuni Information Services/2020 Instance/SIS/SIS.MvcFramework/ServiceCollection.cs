namespace SIS.MvcFramework
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Reflection;
    using System.Linq;

    public class ServiceCollection : IServiceCollection
    {
        private IDictionary<Type, Type> dependencyContainer = new ConcurrentDictionary<Type, Type>();

        public void Add<TSource, TDestination>()
            where TDestination : TSource    // always TDestination to be a derivative of TSource
        {
            dependencyContainer[typeof(TSource)] = typeof(TDestination);
        }

        public object CreateInstance(Type type)
        {
            if (dependencyContainer.ContainsKey(type))
            {
                type = dependencyContainer[type];
            }

            ConstructorInfo constructor = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                                              .OrderBy(x => x.GetParameters().Count())
                                              .FirstOrDefault();

            var parameterValues = new List<object>();
            foreach (ParameterInfo parameter in constructor.GetParameters())
            {
                var instance = CreateInstance(parameter.ParameterType);
                parameterValues.Add(instance);
            }

            return constructor.Invoke(parameterValues.ToArray());
        }

        public T CreateInstance<T>() => (T)this.CreateInstance(typeof(T));
    }
}
