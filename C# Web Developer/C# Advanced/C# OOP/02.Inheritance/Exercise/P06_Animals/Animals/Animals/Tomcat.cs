namespace Animals
{
    using System;

    public class Tomcat : Cat
    {
        //--------------------- Constants ------------------------
        private const string TomcatGender = "Male";

        //-------------------- Constructors ----------------------
        public Tomcat(string name, int age) : base(name, age, TomcatGender)
        {

        }

        //---------------------- Methods -------------------------
        public override string ProduceSound()
        {
            return $"MEOW";
        }
    }
}
