namespace CustomRandomList
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.Add("abc");
            randomList.Add("xyz");
            randomList.Add("qwerty");

            string randomString = randomList.RandomString();
            Console.WriteLine(randomString);
        }
    }
}
