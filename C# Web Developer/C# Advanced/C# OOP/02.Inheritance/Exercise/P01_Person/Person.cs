namespace P01_Person
{
    using System;
    using System.Text;

    public class Person
    {
        //------------------- Fields ---------------------
        private string name;
        private int age;

        //---------------- Constructors ------------------
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        //----------------- Properties -------------------
        public virtual string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name's length shouldn't be less than 3 symbols!");
                }

                this.name = value;
            }
        }

        public virtual int Age
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative");
                }

                this.age = value;
            }
        }

        //------------------ Methods ---------------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));
            return sb.ToString();
        }
    }
}
