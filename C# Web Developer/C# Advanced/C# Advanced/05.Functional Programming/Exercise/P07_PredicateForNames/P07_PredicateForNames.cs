namespace P07_PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P07_PredicateForNames
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Func<string, bool> predicate = name => name.Length <= length;

            IEnumerable<string> names = Console.ReadLine()
                                               .Split()
                                               .Where(predicate);    
            
            Console.WriteLine(String.Join(Environment.NewLine, names));
        }
    }
}
