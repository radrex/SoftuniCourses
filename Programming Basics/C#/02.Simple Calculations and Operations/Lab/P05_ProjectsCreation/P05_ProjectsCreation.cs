namespace P05_ProjectsCreation
{
    using System;

    class P05_ProjectsCreation
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projectsCount = int.Parse(Console.ReadLine());

            int hours = projectsCount * 3;

            Console.WriteLine($"The architect {name} will need {hours} hours to complete {projectsCount} project/s.");
        }
    }
}
