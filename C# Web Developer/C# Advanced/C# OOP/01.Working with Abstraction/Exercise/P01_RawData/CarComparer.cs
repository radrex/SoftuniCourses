namespace P01_RawData
{
    using System;
    using System.Collections.Generic;

    public class CarComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car x, Car y)
        {
            return x.Model.Equals(y.Model, StringComparison.InvariantCulture) &&
                   x.Engine.Power.Equals(y.Engine.Power) &&
                   x.Engine.Speed.Equals(y.Engine.Speed) &&
                   x.Cargo.Weight.Equals(y.Cargo.Weight) &&
                   x.Cargo.CargoType.Equals(y.Cargo.CargoType);
        }

        public int GetHashCode(Car obj)
        {
            return obj.Model.GetHashCode() ^ 
                   obj.Engine.Power.GetHashCode() ^ 
                   obj.Engine.Speed.GetHashCode() ^
                   obj.Cargo.Weight.GetHashCode() ^ 
                   obj.Cargo.CargoType.GetHashCode();
        }
    }
}
