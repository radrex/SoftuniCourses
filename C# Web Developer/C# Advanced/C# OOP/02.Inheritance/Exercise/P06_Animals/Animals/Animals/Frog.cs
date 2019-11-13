namespace Animals
{
    using System;

    public class Frog : Animal
    {
        //-------------------- Constructors ----------------------
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {

        }

        //---------------------- Methods -------------------------
        public override string ProduceSound()
        {
            return $"Ribbit";
        }
    }
}
