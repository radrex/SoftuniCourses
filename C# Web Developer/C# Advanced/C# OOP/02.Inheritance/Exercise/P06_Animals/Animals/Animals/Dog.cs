namespace Animals
{
    using System;

    public class Dog : Animal
    {
        //-------------------- Constructors ----------------------
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {

        }

        //---------------------- Methods -------------------------
        public override string ProduceSound()
        {
            return $"Woof!";
        }
    }
}
