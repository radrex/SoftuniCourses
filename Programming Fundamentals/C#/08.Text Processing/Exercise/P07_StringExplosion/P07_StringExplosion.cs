namespace P07_StringExplosion
{
    using System;

    class P07_StringExplosion
    {
        static void Main(string[] args)
        {
            string bombSequence = Console.ReadLine();
            int bombPower = 0;

            for (int i = 0; i < bombSequence.Length - 1; i++)
            {
                if (bombSequence[i] == '>')
                {
                    bombPower += bombSequence[i + 1] - '0';
                    while (i + 1 < bombSequence.Length && bombSequence[i + 1] != '>' && bombPower > 0)
                    {
                        bombSequence = bombSequence.Remove(i + 1, 1);
                        bombPower--;
                    }
                }
            }

            Console.WriteLine(bombSequence);
        }
    }
}