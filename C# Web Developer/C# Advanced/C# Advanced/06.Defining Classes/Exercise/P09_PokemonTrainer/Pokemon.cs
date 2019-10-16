namespace P09_PokemonTrainer
{
    public class Pokemon
    {
        //-------------- Constructors --------------
        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        //--------------- Properties ---------------
        public string Name { get; private set; }

        public string Element { get; private set; }

        public int Health { get; private set; }

        //---------------- Methods -----------------
        public void RemoveHealth()
        {
            this.Health -= 10;
        }
    }
}
