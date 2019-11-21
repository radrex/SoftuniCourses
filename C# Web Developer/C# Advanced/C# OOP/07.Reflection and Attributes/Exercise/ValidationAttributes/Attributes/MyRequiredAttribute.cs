namespace ValidationAttributes.Attributes 
{
    using System;

    public class MyRequiredAttribute : MyValidationAttribute
    {
        //------------------- Methods ---------------------
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}
