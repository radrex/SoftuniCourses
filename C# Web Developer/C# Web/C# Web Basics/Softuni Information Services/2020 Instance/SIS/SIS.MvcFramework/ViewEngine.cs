namespace SIS.MvcFramework
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Emit;
    using Microsoft.CodeAnalysis.CSharp;

    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class ViewEngine : IViewEngine
    {
        public string GetHtml(string templateHtml, object model)
        {
            string methodCode = PrepareCSharpCode(templateHtml);
            string typeName = model.GetType().FullName;
            if (model.GetType().IsGenericType)
            {
                typeName = model.GetType().Name.Replace("`1", string.Empty) + "<" + model.GetType().GenericTypeArguments.First().Name + ">";
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
        public string GetHtml(object model)
        {{
            var Model = model as {typeName};
            var html = new StringBuilder();

{methodCode}

            return html.ToString();
        }}
    }}
}}";

            IView view = GetInstanceFromCode(code, model);
            string html = view.GetHtml(model);
            return html;
        }

        private IView GetInstanceFromCode(string code, object model)
        {
            CSharpCompilation compilation = CSharpCompilation.Create("AppViewAssembly")
                                                             .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                                                             .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location))
                                                             .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                                                             .AddReferences(MetadataReference.CreateFromFile(model.GetType().Assembly.Location));

            AssemblyName[] libraries = Assembly.Load(new AssemblyName("netstandard")).GetReferencedAssemblies();
            foreach (AssemblyName library in libraries)
            {
                compilation = compilation.AddReferences(MetadataReference.CreateFromFile(Assembly.Load(library).Location));
            }

            compilation = compilation.AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(code));

            using MemoryStream memoryStream = new MemoryStream();

            EmitResult compilationResult = compilation.Emit(memoryStream);
            if (!compilationResult.Success)
            {
                return new ErrorView(compilationResult.Diagnostics.Where(x => x.Severity == DiagnosticSeverity.Error)
                                                                  .Select(x => x.GetMessage()));

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
            Regex cSharpExpressionRegex = new Regex(@"[^\<\""\s]+", RegexOptions.Compiled);
            string[] supportedOperators = new[] { "if", "for", "foreach", "else" };

            StringBuilder cSharpCode = new StringBuilder();
            StringReader reader = new StringReader(templateHtml);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.TrimStart().StartsWith("{") || line.TrimStart().StartsWith("}"))
                {
                    cSharpCode.AppendLine(line);
                }
                else if (supportedOperators.Any(x => line.TrimStart().StartsWith("@" + x)))
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

                    currentCSharpLine.AppendLine(line.Replace("\"", "\"\"") + "\");");
                    cSharpCode.AppendLine(currentCSharpLine.ToString());
                }
            }

            return cSharpCode.ToString();
        }
    }
}
