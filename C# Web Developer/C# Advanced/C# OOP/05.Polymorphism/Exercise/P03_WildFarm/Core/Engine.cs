namespace P03_WildFarm.Core
{
    using Models.Animals;
    using Factories;
    using System;
    using System.Collections.Generic;
    using Models.Foods;

    public class Engine
    {
        //--------------Fields----------------
        private List<Animal> animals;
        private FoodFactory foodFactory;
        private AnimalFactory animalFactory;

        //-----------Constructors-------------
        public Engine()
        {
            this.animals = new List<Animal>();
            this.foodFactory = new FoodFactory();
            this.animalFactory = new AnimalFactory();
        }

        //-------------Methods----------------
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                try
                {
                    string[] animalData = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Animal animal = this.animalFactory.CreateAnimal(animalData[0], animalData);
                    animal.ProduceSound();
                    this.animals.Add(animal);

                    string[] foodData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Food food = this.foodFactory.CreateFood(foodData[0], foodData);
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
