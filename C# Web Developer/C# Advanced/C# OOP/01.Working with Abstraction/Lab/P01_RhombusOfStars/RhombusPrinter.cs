namespace P01_RhombusOfStars
{
    using System;
    using System.Text;

    public class RhombusPrinter
    {
        //---------------- Fields ------------------
        private int size;

        //-------------- Constructors --------------
        public RhombusPrinter(int size)
        {
            this.Size = size;
        }
        //--------------- Properties ---------------
        public int Size
        {
            get { return this.size; }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Size cannot be negative!");
                    this.size = 0;
                }
                this.size = value;
            }
        }
        //------------- Public Methods -------------
        public string Print(int size)
        {
            StringBuilder sb = new StringBuilder();
            this.PrintTopPart(sb, size);
            this.PrintRow(sb, size);
            this.PrintBottomPart(sb, size);
            return sb.ToString();
        }
        //------------- Private Methods ------------
        private void PrintTopPart(StringBuilder sb, int size)
        {
            for (int i = 1; i < size; i++)
            {
                sb.Append(new string(' ', size - i));
                PrintRow(sb, i);
            }
        }

        private void PrintBottomPart(StringBuilder sb, int size)
        {
            for (int i = size - 1; i >= 1; i--)
            {
                sb.Append(new string(' ', size - i));
                PrintRow(sb, i);
            }
        }

        private void PrintRow(StringBuilder sb, int size)
        {
            for (int i = 0; i < size; i++)
            {
                sb.Append('*');
                if (i < size - 1)
                {
                    sb.Append(' ');
                }
            }
            sb.AppendLine();
        }
    }
}
