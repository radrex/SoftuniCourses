namespace Animals
{
    using System;

    public class Kitten : Cat
    {
        //--------------------- Constants ------------------------
        private const string KittenGender = "Female";

        //-------------------- Constructors ----------------------
        public Kitten(string name, int age) : base(name, age, KittenGender)
        {

        }

        //---------------------- Methods -------------------------
        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}
