//namespace P04_Collector
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
        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            //Type classType = Type.GetType("P04_Collector." + className);
            Object instance = Activator.CreateInstance(classType);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance |
                                                        BindingFlags.NonPublic |
                                                        BindingFlags.Public);

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
            {
                //ParameterInfo[] setParameters = method.GetParameters();
                //foreach (ParameterInfo parameter in setParameters)
                //{
                //    sb.AppendLine($"{method.Name} will set field of {parameter.ParameterType}");
                //}
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
//}
