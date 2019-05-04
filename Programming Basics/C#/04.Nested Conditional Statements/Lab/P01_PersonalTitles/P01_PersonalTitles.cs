namespace P01_PersonalTitles
{
    using System;

    class P01_PersonalTitles
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            string title = string.Empty;

            switch (gender)
            {
                case 'm':
                    if (age >= 16)
                    {
                        title = "Mr.";
                    }
                    else
                    {
                        title = "Master";
                    }
                    break;

                case 'f':
                    if (age >= 16)
                    {
                        title = "Ms.";
                    }
                    else
                    {
                        title = "Miss";
                    }
                    break;
            }

            Console.WriteLine(title);
        }
    }
}
