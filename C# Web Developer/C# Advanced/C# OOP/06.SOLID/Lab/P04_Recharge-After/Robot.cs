namespace P04_Recharge_After
{
    public class Robot : Worker, IRechargeable
    {
        //----------- Fields ------------
        private int capacity;

        //-------- Constructors ---------
        public Robot(string id, int capacity) 
            : base(id)
        {
            this.capacity = capacity;
        }

        //--------- Properties ----------
        public int Capacity
        {
            get => this.capacity;
            private set => this.capacity = value;
        }

        public int CurrentPower { get; private set; }

        //---------- Methods ------------
        public void Recharge()
        {
            this.CurrentPower = this.capacity;
        }

        public override void Work(int hours)
        {
            if (hours > this.CurrentPower)
            {
                hours = CurrentPower;
            }

            base.Work(hours);
            this.CurrentPower -= hours;
        }
    }
}
