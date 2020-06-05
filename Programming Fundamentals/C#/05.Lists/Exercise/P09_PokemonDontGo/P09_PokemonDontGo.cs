namespace P09_PokemonDontGo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P09_PokemonDontGo
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToList();
            int sum = 0;

            while (pokemons.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int removed = pokemons[0];
                    pokemons.RemoveAt(0);
                    sum += removed;
                    pokemons.Insert(0, pokemons.Last());
                    IncreaseOrDecreaseElements(pokemons, removed);
                }
                else if (index > pokemons.Count - 1)
                {
                    int removed = pokemons[pokemons.Count - 1];
                    pokemons.RemoveAt(pokemons.Count - 1);
                    sum += removed;
                    pokemons.Add(pokemons.First());
                    IncreaseOrDecreaseElements(pokemons, removed);
                }
                else
                {
                    int removed = pokemons[index];
                    pokemons.RemoveAt(index);
                    sum += removed;
                    IncreaseOrDecreaseElements(pokemons, removed);
                }
            }

            Console.WriteLine(sum);
        }

        public static void IncreaseOrDecreaseElements(List<int> pokemons, int removed)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (pokemons[i] <= removed)
                {
                    pokemons[i] += removed;
                }
                else
                {
                    pokemons[i] -= removed;
                }
            }
        }
    }
}