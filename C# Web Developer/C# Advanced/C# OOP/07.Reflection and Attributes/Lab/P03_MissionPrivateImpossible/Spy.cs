//namespace P03_MissionPrivateImpossible
//{
    using System;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        //------------- Constructors ---------------
        public Spy()
        {

        }

        //---------------- Methods -----------------
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            //Type classType = Type.GetType("P03_MissionPrivateImpossible." + className);

            Object instance = Activator.CreateInstance(classType);

            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance |
                                                               BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
//}
