using System;

namespace P07_CustomException
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Gin4o", "aasfasf@gmail.com");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Student student = new Student("Ivan", "@---ivan@gmail.com");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
