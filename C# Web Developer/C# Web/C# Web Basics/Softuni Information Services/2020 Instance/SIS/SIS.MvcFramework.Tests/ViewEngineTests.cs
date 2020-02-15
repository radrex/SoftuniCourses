namespace SIS.MvcFramework.Tests
{
    using Xunit;
    using System.IO;
    using System.Collections.Generic;

    public class ViewEngineTests
    {
        [Theory]
        [InlineData("OnlyHtmlView")]
        [InlineData("ForForeachIfView")]
        [InlineData("ViewModelView")]
        public void TestGetHtml(string testName)
        {
            TestViewModel viewModel = new TestViewModel()
            {
                Name = "Niki",
                Year = 2020,
                Numbers = new List<int> { 1, 10, 100, 1000, 10000 },
            };

            string viewContent = File.ReadAllText($"ViewTests/{testName}.html");
            string expectedResultContent = File.ReadAllText($"ViewTests/{testName}.Expected.html");

            IViewEngine viewEngine = new ViewEngine();
            string actualResult = viewEngine.GetHtml(viewContent, viewModel, "123");

            Assert.Equal(expectedResultContent, actualResult);

        }

        [Fact]
        public void TestGetHtmlWithTemplateModel()
        {
            List<int> viewModel = new List<int> { 1, 2, 3 };

            string viewContent = @"
@foreach (var num in Model)
{
<p>@num</p>
}";
            string expectedResultContent = @"
<p>1</p>
<p>2</p>
<p>3</p>
";
            IViewEngine viewEngine = new ViewEngine();
            string actualResult = viewEngine.GetHtml(viewContent, viewModel, null);

            Assert.Equal(expectedResultContent, actualResult);

        }
    }
}
