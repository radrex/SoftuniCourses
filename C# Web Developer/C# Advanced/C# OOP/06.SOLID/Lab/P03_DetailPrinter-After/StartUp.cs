namespace P03_DetailPrinter_After
{
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IEmployee> employees = new List<IEmployee>();

            IEmployee employee = new Employee("Ivan");
            IEmployee manager = new Manager("Georgi", new string[] { "Document 1", "Document 2" });

            employees.Add(employee);
            employees.Add(manager);

            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}
