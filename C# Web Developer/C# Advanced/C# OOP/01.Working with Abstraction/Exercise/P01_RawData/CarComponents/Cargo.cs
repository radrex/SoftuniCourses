namespace P01_RawData.CarComponents
{
    using P01_RawData.CarComponents.Enums;

    public class Cargo
    {
        //-------------- Constructors ----------------
        public Cargo(int weight, CargoType cargoType)
        {
            this.Weight = weight;
            this.CargoType = cargoType;
        }

        //--------------- Properties -----------------
        public int Weight { get; private set; }
        public CargoType CargoType { get; private set; }
    }
}
