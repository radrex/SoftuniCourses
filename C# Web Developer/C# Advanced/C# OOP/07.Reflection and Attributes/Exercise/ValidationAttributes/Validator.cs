using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        //--------------------- Methods ------------------------
        public static bool IsValid(object obj)
        {
            PropertyInfo[] objProperties = obj.GetType().GetProperties();

            foreach (PropertyInfo objProperty in objProperties)
            {
                IEnumerable<MyValidationAttribute> propertyAttributes = objProperty.GetCustomAttributes()
                                                                                   .Where(a => a is MyValidationAttribute)
                                                                                   .Cast<MyValidationAttribute>();
                foreach (MyValidationAttribute propertyAttribute in propertyAttributes)
                {
                    bool result = propertyAttribute.IsValid(objProperty.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
