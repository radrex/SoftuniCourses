namespace CarManufacturer
{
    internal class Car
    {
        //----------------- FIELDS -----------------
        private string make;
        private string model;
        private int year;

        //--------------- PROPERTIES ---------------
        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
    }
}
