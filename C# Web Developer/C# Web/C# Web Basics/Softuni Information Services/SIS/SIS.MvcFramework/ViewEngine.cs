namespace SIS.MvcFramework
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class ViewEngine : IViewEngine
    {
        public string GetHtml(string templateHtml, object model, string user)
        {
            string methodCode = PrepareCSharpCode(templateHtml);

            var modelType = model?.GetType() ?? typeof(object);
            string typeName = modelType.FullName;

            if (modelType.IsGenericType)
            {
                typeName = GetGenericTypeFullName(modelType);
            }

            string code = @$"using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using SIS.MvcFramework;
namespace AppViewNamespace
{{
    public class AppViewCode : IView
    {{
        public string GetHtml(object model, string user)
        {{
            var Model = model as {typeName};
            var User = user;
            var html = new StringBuilder();

{methodCode}

            return html.ToString();
        }}
    }}
}}";

            IView view = GetInstanceFromCode(code, model);
            string html = view.GetHtml(model, user);
            return html;
        }

        private string GetGenericTypeFullName(Type modelType)
        {
            int argumentCountBeginning = modelType.Name.LastIndexOf('`');
            string genericModelTypeName = modelType.Name.Substring(0, argumentCountBeginning);
            string genericTypeFullName = $"{modelType.Namespace}.{genericModelTypeName}";
            var genericTypeArguments = modelType.GenericTypeArguments.Select(GetGenericTypeArgumentFullName);
            string modelTypeName = $"{genericTypeFullName}<{string.Join(", ", genericTypeArguments)}>";
            return modelTypeName;
        }

        private string GetGenericTypeArgumentFullName(Type genericTypeArgument)
        {
            if (genericTypeArgument.IsGenericType)
            {
                return GetGenericTypeFullName(genericTypeArgument);
            }

            return genericTypeArgument.FullName;
        }

        private IView GetInstanceFromCode(string code, object model)
        {
            CSharpCompilation compilation = CSharpCompilation.Create("AppViewAssembly")
                                                             .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                                                             .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location))
                                                             .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));
            if (model != null)
            {
                compilation = compilation.AddReferences(MetadataReference.CreateFromFile(model.GetType().Assembly.Location));
            }

            AssemblyName[] libraries = Assembly.Load(new AssemblyName("netstandard")).GetReferencedAssemblies();
            foreach (var library in libraries)
            {
                compilation = compilation.AddReferences(MetadataReference.CreateFromFile(Assembly.Load(library).Location));
            }

            compilation = compilation.AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(code));

            using MemoryStream memoryStream = new MemoryStream();

            var compilationResult = compilation.Emit(memoryStream);
            if (!compilationResult.Success)
            {
                return new ErrorView(compilationResult.Diagnostics.Where(x => x.Severity == DiagnosticSeverity.Error).Select(x => x.GetMessage()));
            }

            memoryStream.Seek(0, SeekOrigin.Begin);
            byte[] assemblyByteArray = memoryStream.ToArray();
            Assembly assembly = Assembly.Load(assemblyByteArray);
            Type type = assembly.GetType("AppViewNamespace.AppViewCode");
            IView instance = Activator.CreateInstance(type) as IView;
            return instance;
        }

        private string PrepareCSharpCode(string templateHtml)
        {
            Regex cSharpExpressionRegex = new Regex(@"[^\<\""\s&]+", RegexOptions.Compiled);
            string[] supportedOpperators = new[] { "if", "for", "foreach", "else" };
            StringBuilder cSharpCode = new StringBuilder();
            StringReader reader = new StringReader(templateHtml);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.TrimStart().StartsWith("{") || line.TrimStart().StartsWith("}"))
                {
                    cSharpCode.AppendLine(line);
                }
                else if (supportedOpperators.Any(x => line.TrimStart().StartsWith("@" + x)))
                {
                    int indexOfAt = line.IndexOf("@");
                    line = line.Remove(indexOfAt, 1);
                    cSharpCode.AppendLine(line);
                }
                else
                {
                    StringBuilder currentCSharpLine = new StringBuilder("html.AppendLine(@\"");
                    while (line.Contains("@"))
                    {
                        int atSignLocation = line.IndexOf("@");
                        string before = line.Substring(0, atSignLocation);
                        currentCSharpLine.Append(before.Replace("\"", "\"\"") + "\" + ");
                        string cSharpAndEndOfLine = line.Substring(atSignLocation + 1);
                        Match cSharpExpression = cSharpExpressionRegex.Match(cSharpAndEndOfLine);
                        currentCSharpLine.Append(cSharpExpression.Value + " + @\"");
                        string after = cSharpAndEndOfLine.Substring(cSharpExpression.Length);
                        line = after;
                    }

                    currentCSharpLine.Append(line.Replace("\"", "\"\"") + "\");");
                    cSharpCode.AppendLine(currentCSharpLine.ToString());
                }
            }

            return cSharpCode.ToString();
        }
    }
}