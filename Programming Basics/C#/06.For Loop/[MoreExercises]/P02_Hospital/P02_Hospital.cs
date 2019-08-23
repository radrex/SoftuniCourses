namespace P02_Hospital
{
    using System;

    class P02_Hospital
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int doctors = 7;
            int treatedPatients = 0;
            int untreatedPatients = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0 && untreatedPatients > treatedPatients)
                {
                    doctors++;
                }

                int patients = int.Parse(Console.ReadLine());
                if (patients < doctors)
                {
                    treatedPatients += patients;
                }
                else
                {
                    treatedPatients += doctors;
                }

                if (patients - doctors > 0)
                {
                    untreatedPatients += patients - doctors;
                }
            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}
