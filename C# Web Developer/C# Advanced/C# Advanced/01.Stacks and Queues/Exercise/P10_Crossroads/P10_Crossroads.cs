namespace P10_Crossroads
{
    using System;
    using System.Collections.Generic;

    class P10_Crossroads
    {
        static void Main(string[] args)
        {
            List<string> cars = new List<string>();
            Queue<string> queue = new Queue<string>();
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            int carsPassed = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
                    return;
                }

                if (command == "green")
                {
                    int seconds = greenLight;
                    while (seconds > 0 && queue.Count != 0)
                    {
                        string car = queue.Dequeue();
                        cars.Add(car);
                        seconds -= car.Length;
                    }

                    seconds = greenLight + freeWindow;
                    foreach (string car in cars)
                    {
                        for (int i = 0; i < car.Length; i++)
                        {
                            seconds--;
                            if (seconds < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[i]}.");
                                return;
                            }
                        }
                    }

                    carsPassed += cars.Count;
                    cars.Clear();
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
        }
    }
}
