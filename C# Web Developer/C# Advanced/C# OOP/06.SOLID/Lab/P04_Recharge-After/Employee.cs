namespace P04_Recharge_After
{
    using System;

    public class Employee : Worker, ISleeper
    {
        //-------- Constructors ---------
        public Employee(string id) 
            : base(id)
        {

        }

        //---------- Methods ------------
        public void Sleep()
        {
            Console.WriteLine("Employee Sleeping...");
        }
    }
}
