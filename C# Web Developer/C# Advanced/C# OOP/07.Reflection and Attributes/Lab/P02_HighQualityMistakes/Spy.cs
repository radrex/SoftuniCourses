//namespace P02_HighQualityMistakes
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
        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
             
            Type classType = Type.GetType(className);
            //Type classType = Type.GetType("P02_HighQualityMistakes." + className);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance |
                                                     BindingFlags.Static |
                                                     BindingFlags.Public);
            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance |
                                                                 BindingFlags.Static |
                                                                 BindingFlags.NonPublic);

            foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance |
                                                              BindingFlags.Static |
                                                              BindingFlags.Public);
            foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }


            return sb.ToString().TrimEnd();
        }
    }
//}
