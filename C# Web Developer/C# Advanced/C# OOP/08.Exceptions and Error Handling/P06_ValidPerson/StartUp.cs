namespace P06_ValidPerson
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person(string.Empty, "Goshev", 31);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception throw: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception throw: {ex.Message}");
            }

            try
            {
                Person person = new Person("Stoyan", "Kolev", -1);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception throw: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception throw: {ex.Message}");
            }
        }
    }
}
