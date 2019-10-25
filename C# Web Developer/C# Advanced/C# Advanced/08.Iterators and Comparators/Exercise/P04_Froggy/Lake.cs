namespace P04_Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        //---------------- Fields ------------------
        private int[] stones;

        //------------- Constructors ---------------
        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        //--------------- Methods ------------------
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i += 2)
            {
                yield return stones[i];
            }

            int reversedIndex = stones.Length % 2 == 0 ? stones.Length - 1 : stones.Length - 2;
            for (int i = reversedIndex; i > 0; i -= 2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
