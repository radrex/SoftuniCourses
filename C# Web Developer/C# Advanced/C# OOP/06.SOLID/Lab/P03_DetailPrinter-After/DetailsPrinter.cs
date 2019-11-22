namespace P03_DetailPrinter_After
{
    using System;
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        //------------- Fields -------------
        private IList<IEmployee> employees;

        //---------- Constructors ----------
        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        //------------ Methods -------------
        public void PrintDetails()
        {
            foreach (IEmployee employee in this.employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}
