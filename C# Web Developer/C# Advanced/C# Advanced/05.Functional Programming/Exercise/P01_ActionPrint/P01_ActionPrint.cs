namespace P01_ActionPrint
{
    using System;

    class P01_ActionPrint
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string[]> action = name => Console.WriteLine(String.Join(Environment.NewLine, name));
            action(names);

            //------------------- OR ALTERNATIVELY -------------------
            //Action<string> action = name => Console.WriteLine(name);
            //Console.ReadLine().Split()
            //                  .ToList()
            //                  .ForEach(action);
        }
    }
}
