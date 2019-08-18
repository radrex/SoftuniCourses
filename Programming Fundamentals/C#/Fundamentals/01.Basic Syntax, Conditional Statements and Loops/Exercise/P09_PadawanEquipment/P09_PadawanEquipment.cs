namespace P09_PadawanEquipment
{
    using System;

    class P09_PadawanEquipment
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            int freeBelts = students / 6;
            double expense = (Math.Ceiling(students * 1.1) * lightsaberPrice) + (students * robePrice) + ((students - freeBelts) * beltPrice);

            if (money >= expense)
            {
                Console.WriteLine($"The money is enough - it would cost {expense:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {expense - money:F2}lv more.");
            }
        }
    }
}