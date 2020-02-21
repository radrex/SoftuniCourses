namespace IRunes
{
    using SIS.MvcFramework;
    using System.Threading.Tasks;

    public class Program
    {
        static async Task Main(string[] args)
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
