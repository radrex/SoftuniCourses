namespace SIS.HTTP.Logging
{
    using System.IO;

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllLines("log.txt", new[] { message });
        }
    }
}
