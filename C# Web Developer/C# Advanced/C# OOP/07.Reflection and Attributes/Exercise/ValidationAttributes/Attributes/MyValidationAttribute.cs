namespace ValidationAttributes.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class MyValidationAttribute : Attribute
    {
        //------------------- Abstract Methods ---------------------
        public abstract bool IsValid(object obj);
    }
}
