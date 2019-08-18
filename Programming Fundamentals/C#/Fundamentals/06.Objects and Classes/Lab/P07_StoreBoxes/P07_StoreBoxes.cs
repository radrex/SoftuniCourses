namespace P07_StoreBoxes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P07_StoreBoxes
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                string serialNumber = command[0];
                string itemName = command[1];
                int itemQuantity = int.Parse(command[2]);
                decimal itemPrice = decimal.Parse(command[3]);

                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    Quantity = itemQuantity,
                    PriceBox = itemQuantity * itemPrice
                };

                box.Item = new Item()
                {
                    Name = itemName,
                    Price = itemPrice
                };

                boxes.Add(box);
                command = Console.ReadLine().Split();
            }

            foreach (Box box in boxes.OrderByDescending(b => b.PriceBox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceBox:F2}");
            }
        }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal PriceBox { get; set; }
    }

    class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}