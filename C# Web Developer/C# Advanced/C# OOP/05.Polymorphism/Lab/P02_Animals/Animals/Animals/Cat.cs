namespace Animals
{
    using System;

    public class Cat : Animal
    {
        //------------------- Constructors ---------------------
        public Cat(string name, string favouriteFood)
            : base(name, favouriteFood) { }

        //--------------------- Methods ------------------------
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "MEEOW";
        }
    }
}
