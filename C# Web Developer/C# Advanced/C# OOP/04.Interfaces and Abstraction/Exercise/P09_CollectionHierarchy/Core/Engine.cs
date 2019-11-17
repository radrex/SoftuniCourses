namespace P09_CollectionHierarchy.Core
{
    using Collections;
    using System;

    public class Engine
    {
        //------------ Constructors ---------------
        public Engine()
        {

        }

        //-------------- Methods ------------------
        public void Run()
        {
            AddCollection<string> addCollection = new AddCollection<string>();
            AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            MyList<string> myList = new MyList<string>();

            string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[,] indexMatrix = new int[3, data.Length];

            for (int col = 0; col < indexMatrix.GetLength(1); col++)
            {
                indexMatrix[0, col] = addCollection.Add(data[col]);
                indexMatrix[1, col] = addRemoveCollection.Add(data[col]);
                indexMatrix[2, col] = myList.Add(data[col]);
            }

            int removeOperations = int.Parse(Console.ReadLine());
            string[,] stringMatrix = new string[2, removeOperations];

            for (int col = 0; col < stringMatrix.GetLength(1); col++)
            {
                stringMatrix[0, col] = addRemoveCollection.Remove();
                stringMatrix[1, col] = myList.Remove();
            }

            //----------------------- PRINTING -------------------------
            for (int row = 0; row < indexMatrix.GetLength(0); row++)
            {
                string result = String.Empty;
                for (int i = 0; i < indexMatrix.GetLength(1); i++)
                {
                    result += indexMatrix[row, i] + " ";
                }
                Console.WriteLine(result.TrimEnd());
            }

            for (int row = 0; row < stringMatrix.GetLength(0); row++)
            {
                string result = String.Empty;
                for (int i = 0; i < stringMatrix.GetLength(1); i++)
                {
                    result += stringMatrix[row, i] + " ";
                }
                Console.WriteLine(result.TrimEnd());
            }
        }
    }
}
