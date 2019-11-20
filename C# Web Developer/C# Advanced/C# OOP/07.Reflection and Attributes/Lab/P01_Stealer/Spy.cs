//namespace P01_Stealer
//{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        //------------- Constructors ---------------
        public Spy()
        {

        }

        //---------------- Methods -----------------
        public string StealFieldInfo(string className, params string[] requestedFields)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            //Type classType = Type.GetType("P01_Stealer." + className);
            //Type classType = typeof(Hacker);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | 
                                                     BindingFlags.Static |
                                                     BindingFlags.NonPublic |
                                                     BindingFlags.Public);

            Object instance = Activator.CreateInstance(classType);
            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in fields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
//}
