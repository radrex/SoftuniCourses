namespace Animals
{
    using System;

    public class Cat : Animal
    {
        //-------------------- Constructors ----------------------
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {

        }

        //---------------------- Methods -------------------------
        public override string ProduceSound()
        {
            return $"Meow meow";
        }
    }
}
