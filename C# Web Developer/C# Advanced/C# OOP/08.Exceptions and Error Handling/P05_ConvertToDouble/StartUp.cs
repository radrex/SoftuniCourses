using System;

namespace P05_ConvertToDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            try
            {
                double result = Convert.ToDouble(input);
                Console.WriteLine(result);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
