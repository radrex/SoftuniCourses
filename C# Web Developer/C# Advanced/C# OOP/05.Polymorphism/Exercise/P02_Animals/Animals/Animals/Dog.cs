namespace Animals
{
    using System;

    public class Dog : Animal
    {
        //------------------- Constructors ---------------------
        public Dog(string name, string favouriteFood) 
            : base(name, favouriteFood) { }

        //--------------------- Methods ------------------------
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "DJAAF";
        }
    }
}
