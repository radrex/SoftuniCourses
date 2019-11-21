namespace ValidationAttributes.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        //--------------------- Fields -------------------------
        private int minValue;
        private int maxValue;

        //------------------- Constructors ---------------------
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        //--------------------- Methods ------------------------
        public override bool IsValid(object obj)
        {
            if (obj is int valueAsInt)
            {
                if (valueAsInt >= minValue && valueAsInt <= maxValue)
                {
                    return true;
                }

                return false;
            }

            throw new ArgumentException("Invalid type!");
        }
    }
}
