namespace P01_HospitalDatabase
{
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using var context = new HospitalContext();
            context.Database.Migrate();
        }
    }
}
