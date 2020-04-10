namespace ForumSystem.Services.Tests
{
    using ForumSystem.Web;

    using Microsoft.AspNetCore.Mvc.Testing;

    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Xunit;
    using Xunit.Abstractions;

    public class HomePageTests
    {
        private readonly ITestOutputHelper output;

        public HomePageTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async Task HomePageShouldHaveH1Title()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var client = serverFactory.CreateClient();
            await client.GetAsync("/");

            Stopwatch sw = Stopwatch.StartNew();
            var response = await client.GetAsync("/");
            var responseAsString = await response.Content.ReadAsStringAsync();
            output.WriteLine(sw.Elapsed.ToString());
            if (sw.Elapsed > new TimeSpan(0, 0, 1))
            {
                throw new Exception("Too long wait...");
            }

            Assert.Contains("<h1", responseAsString);
        }
    }
}
