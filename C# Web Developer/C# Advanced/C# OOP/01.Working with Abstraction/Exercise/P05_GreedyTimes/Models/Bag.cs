namespace P05_GreedyTimes.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        //---------------- Fields --------------------
        private List<GoldItem> gold;
        private List<GemItem> gems;
        private List<CashItem> cash;

        //-------------- Constructors ----------------
        public Bag(long capacity)
        {
            this.Capacity = capacity;
            this.gold = new List<GoldItem>();
            this.gems = new List<GemItem>();
            this.cash = new List<CashItem>();
        }

        //--------------- Properties -----------------
        public long Capacity { get; private set; }

        public IReadOnlyCollection<GoldItem> Gold => this.gold.AsReadOnly();
        public long GoldAmount => this.gold.Sum(g => g.Quantity);

        public IReadOnlyCollection<GemItem> Gems => this.gems.AsReadOnly();
        public long GemsAmount => this.gems.Sum(g => g.Quantity);

        public IReadOnlyCollection<CashItem> Cash => this.cash.AsReadOnly();
        public long CashAmount => this.cash.Sum(c => c.Quantity);

        //------------- Public Methods ---------------
        public void AddGoldItem(GoldItem goldItem)
        {
            GoldItem goldy = this.gold.FirstOrDefault(gi => gi.Name == goldItem.Name);
            if (goldy == null && goldItem.Quantity + this.GoldAmount <= this.Capacity)
            {
                this.gold.Add(goldItem);
            }
            else if (goldItem.Quantity + this.GoldAmount <= this.Capacity)
            {
                goldy.Add(goldItem.Quantity);
            }
        }

        public void AddGemItem(GemItem gemItem)
        {
            GemItem gemy = this.gems.FirstOrDefault(gi => gi.Name == gemItem.Name);
            if (gemy == null && gemItem.Quantity + this.GemsAmount <= this.Capacity)
            {
                if (this.GoldAmount >= this.GemsAmount + gemItem.Quantity)
                {
                    this.gems.Add(gemItem);
                }
            }
            else if (gemItem.Quantity + this.GemsAmount <= this.Capacity)
            {
                if (this.GoldAmount >= this.GemsAmount + gemItem.Quantity)
                {
                    gemy.Add(gemItem.Quantity);
                }
            }
        }

        public void AddCashItem(CashItem cashItem)
        {
            CashItem cashy = this.cash.FirstOrDefault(ci => ci.Name == cashItem.Name);
            if (cashy == null && cashItem.Quantity + this.CashAmount <= this.Capacity)
            {
                if (this.GemsAmount >= this.CashAmount + cashItem.Quantity)
                {
                    this.cash.Add(cashItem);
                }
            }
            else if (cashItem.Quantity + this.CashAmount <= this.Capacity)
            {
                if (this.GemsAmount >= this.CashAmount + cashItem.Quantity)
                {
                    cashy.Add(cashItem.Quantity);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.Gold.Count != 0)
            {
                sb.AppendLine($"<Gold> ${this.GoldAmount}");
                foreach (GoldItem goldItem in this.Gold.OrderByDescending(i => i.Name).ThenBy(i => i.Quantity))
                {
                    sb.AppendLine(goldItem.ToString());
                }
            }

            if (this.Gems.Count != 0)
            {
                sb.AppendLine($"<Gem> ${this.GemsAmount}");
                foreach (GemItem gemItem in this.Gems.OrderByDescending(i => i.Name).ThenBy(i => i.Quantity))
                {
                    sb.AppendLine(gemItem.ToString());
                }
            }

            if (this.Cash.Count != 0)
            {
                sb.AppendLine($"<Cash> ${this.CashAmount}");
                foreach (CashItem cashItem in this.Cash.OrderByDescending(i => i.Name).ThenBy(i => i.Quantity))
                {
                    sb.AppendLine(cashItem.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
