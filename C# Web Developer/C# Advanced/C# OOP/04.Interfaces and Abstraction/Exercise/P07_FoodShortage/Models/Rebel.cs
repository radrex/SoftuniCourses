namespace P07_FoodShortage.Models
{
    using P07_FoodShortage.Interfaces;

    public class Rebel : IBuyer
    {
        //------------------ Constructors --------------------
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        //------------------- Properties ---------------------
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; private set; }

        //-------------------- Methods -----------------------
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
