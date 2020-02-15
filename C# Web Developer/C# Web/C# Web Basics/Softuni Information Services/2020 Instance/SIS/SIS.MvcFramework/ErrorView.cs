namespace SIS.MvcFramework
{
    using System.Text;
    using System.Collections.Generic;

    public class ErrorView : IView
    {
        private readonly IEnumerable<string> errors;

        public ErrorView(IEnumerable<string> errors)
        {
            this.errors = errors;
        }

        public string GetHtml(object model, string user)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<h1>View compilation errors:</h1>");
            html.AppendLine("<ul>");
            foreach (string error in this.errors)
            {
                html.AppendLine($"<li>{error}</li>");
            }

            html.AppendLine("</ul>");
            return html.ToString();
        }
    }
}
