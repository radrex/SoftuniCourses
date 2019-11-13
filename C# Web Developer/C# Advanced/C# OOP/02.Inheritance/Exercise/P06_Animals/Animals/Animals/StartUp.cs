namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string animalCommand = Console.ReadLine();
                if (animalCommand == "Beast!")
                {
                    break;
                }

                string[] animalData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = animalData[0];
                int age = int.Parse(animalData[1]);
                string gender = animalData[2];

                Animal animal;
                switch (animalCommand)
                {
                    case "Dog":
                        try
                        {
                            animal = new Dog(name, age, gender);
                            animals.Add(animal);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Cat":
                        try
                        {
                            animal = new Cat(name, age, gender);
                            animals.Add(animal);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Frog":
                        try
                        {
                            animal = new Frog(name, age, gender);
                            animals.Add(animal);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Kitten":
                        try
                        {
                            animal = new Kitten(name, age);
                            animals.Add(animal);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Tomcat":
                        try
                        {
                            animal = new Tomcat(name, age);
                            animals.Add(animal);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        continue;
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
