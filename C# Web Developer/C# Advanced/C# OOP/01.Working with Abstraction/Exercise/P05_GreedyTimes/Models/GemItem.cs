namespace P05_GreedyTimes.Models
{
    public class GemItem
    {
        //-------------- Constructors ----------------
        public GemItem(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        //--------------- Properties -----------------
        public string Name { get; private set; }

        public long Quantity { get; private set; }

        //------------- Public Methods ---------------
        public void Add(long quantity)
        {
            this.Quantity += quantity;
        }

        public override string ToString()
        {
            return $"##{this.Name} - {this.Quantity}";
        }
    }
}
