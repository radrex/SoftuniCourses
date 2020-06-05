namespace P01_EncryptSortAndPrintArray
{
    using System;
    using System.Linq;

    class P01_EncryptSortAndPrintArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sums = new int[n];

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                int sum = 0;

                char[] vowels = new char[] { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
                foreach (char symbol in name)
                {
                    if (vowels.Contains(symbol))
                    {
                        sum += symbol * name.Length;
                    }
                    else
                    {
                        sum += symbol / name.Length;
                    }
                }

                sums[i] = sum;
            }

            //------------- BUBBLE SORT -------------
            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 1; i < sums.Length; i++)
                {
                    int leftElement = sums[i - 1];
                    int rightElement = sums[i];
                    if (leftElement > rightElement)
                    {
                        sums[i - 1] = rightElement;
                        sums[i] = leftElement;
                        swapped = true;
                    }
                }
            } while (swapped);
            //---------------------------------------

            Console.WriteLine(String.Join(Environment.NewLine, sums));
        }
    }
}