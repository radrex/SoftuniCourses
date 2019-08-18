namespace P05_HTML
{
    using System;
    using System.Text;

    class P05_HTML
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string title = Console.ReadLine();
            string content = Console.ReadLine();

            sb.AppendLine("<h1>");
            sb.AppendLine($"    {title}");
            sb.AppendLine("</h1>");

            sb.AppendLine("<article>");
            sb.AppendLine($"    {content}");
            sb.AppendLine("</article>");

            while (true)
            {
                string comment = Console.ReadLine();
                if (comment == "end of comments")
                {
                    break;
                }

                sb.AppendLine("<div>");
                sb.AppendLine($"    {comment}");
                sb.AppendLine("</div>");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
