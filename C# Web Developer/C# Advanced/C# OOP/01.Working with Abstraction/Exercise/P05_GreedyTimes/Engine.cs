namespace P05_GreedyTimes
{
    using Models;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Engine
    {
        //---------------- Fields --------------------
        private Bag bag;

        //-------------- Constructors ----------------
        public Engine() { }

        //------------- Public Methods ---------------
        public void Run()
        {
            this.bag = new Bag(long.Parse(Console.ReadLine()));
            string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            string goldPattern = @"\b(?i)gold\b";
            string gemPattern = @"\b(?i)[a-z0-9]{1,}gem\b";
            string cashPatern = @"\b(?i)[a-z]{3}\b";

            for (int i = 0; i < tokens.Length; i += 2)
            {
                string item = tokens[i];
                long quantity = long.Parse(tokens[i + 1]);

                Match goldMatch = Regex.Match(item, goldPattern);
                Match gemMatch = Regex.Match(item, gemPattern);
                Match cashMatch = Regex.Match(item, cashPatern);

                if (goldMatch.Success)
                {
                    GoldItem goldItem = new GoldItem(goldMatch.Value, quantity);
                    this.bag.AddGoldItem(goldItem);
                }
                else if (gemMatch.Success)
                {
                    GemItem gemItem = new GemItem(gemMatch.Value, quantity);
                    this.bag.AddGemItem(gemItem);

                }
                else if (cashMatch.Success)
                {
                    CashItem cashItem = new CashItem(cashMatch.Value, quantity);
                    this.bag.AddCashItem(cashItem);
                }
            }

            if (!String.IsNullOrEmpty(this.bag.ToString()))
            {
                Console.WriteLine(this.bag);
            }
        }
    }
}
