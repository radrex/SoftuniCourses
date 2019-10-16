namespace P09_PokemonTrainer
{
    using System.Collections.Generic;

    public class Trainer
    {
        //-------------- Constructors --------------
        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        //--------------- Properties ---------------
        public string Name { get; private set; }

        public int Badges { get; private set; }

        public List<Pokemon> Pokemons { get; private set; }

        //---------------- Methods -----------------
        public void GiveBadge()
        {
            this.Badges++;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
        }
    }
}
