namespace P03_DetailPrinter_Before
{
    using System;
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        //------------- Fields -------------
        private IList<Employee> employees;

        //---------- Constructors ----------
        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        //------------ Methods -------------
        public void PrintDetails()
        {
            foreach (Employee employee in this.employees)
            {
                if (employee is Manager)
                {
                    this.PrintManager((Manager)employee);
                }
                else
                {
                    this.PrintEmployee(employee);
                }
            }
        }

        private void PrintEmployee(Employee employee)
        {
            Console.WriteLine(employee.Name);
        }

        private void PrintManager(Manager manager)
        {
            Console.WriteLine(manager.Name);
            Console.WriteLine(string.Join(Environment.NewLine, manager.Documents));
        }
    }
}
