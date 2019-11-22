namespace P04_Recharge_After
{
    public abstract class Worker : IWorker
    {
        //----------- Fields ------------
        private string id;
        private int workingHours;

        //-------- Constructors ---------
        protected Worker(string id)
        {
            this.id = id;
        }

        //--------- Properties ----------
        public int WorkingHours
        {
            get => this.workingHours;
            protected set => this.workingHours = value;
        }
        public string Id => this.id;

        //---------- Methods ------------
        public virtual void Work(int hours)
        {
            this.WorkingHours += hours;
        }
    }
}
