namespace P09_PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Tournament")
                {
                    break;
                }

                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainer = tokens[0];
                string pokemonName = tokens[1];
                string element = tokens[2];
                int health = int.Parse(tokens[3]);

                if (!trainers.ContainsKey(trainer))
                {
                    trainers[trainer] = new Trainer(trainer);
                }

                Pokemon pokemon = new Pokemon(pokemonName, element, health);
                trainers[trainer].Pokemons.Add(pokemon);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                foreach (Trainer trainer in trainers.Values)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.GiveBadge();
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.RemoveHealth());
                        List<Pokemon> deadPokemons = trainer.Pokemons.Where(p => p.Health <= 0).ToList();
                        foreach (Pokemon deadPokemon in deadPokemons)
                        {
                            trainer.Pokemons.Remove(deadPokemon);
                        }
                    }
                }
            }

            foreach (Trainer trainer in trainers.Values.OrderByDescending(b => b.Badges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
