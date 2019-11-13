namespace P01_Person
{
    using System;

    public class Child : Person
    {
        //---------------- Constructors ------------------
        public Child(string name, int age) : base(name, age)
        {
                
        }

        //----------------- Properties -------------------
        public override int Age
        {
            get { return base.Age; }
            protected set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Child age cannot be more than 15");
                }

                base.Age = value;
            }
        }
    }
}
