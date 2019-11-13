namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        //------------------ Fields ----------------------
        private Random rnd;

        //---------------- Constructors ------------------
        public RandomList()
        {
            this.rnd = new Random();
        }

        //------------------ Methods ---------------------
        public string RandomString()
        {
            int index = rnd.Next(0, this.Count);
            string str = this[index];
            this.RemoveAt(index);
            return str;
        }
    }
}
