namespace SIS.MvcFramework.Tests
{
    using System.Collections.Generic;

    public class TestViewModel
    {
        public int Year { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> Numbers { get; set; }
    }
}
