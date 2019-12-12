namespace Tests
{
    using CarManager; // comment for judge
    using NUnit.Framework;

    [TestFixture]
    public class CarTests
    {
        //---------------- Fields ------------------
        private Car car;

        //------------- Initialization -------------
        [SetUp]
        public void Setup()
        {
            this.car = new Car("BMW", "M3", 6.5, 60);
        }

        //------------------ CONSTRUCTOR TESTS -------------------
        //--------- MAKE ----------
        [Test]
        [TestCase("BMW", "M3", 6.5, 60)]
        public void ConstructorShouldInitializeCarMakeCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(make, car.Make);
        }

        [Test]
        [TestCase("", "M3", 6.5, 60)]
        [TestCase(null, "M3", 6.5, 60)]
        public void ConstructorShouldThrowArgumentExceptionInAttemptToSetMakeValueToNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.That(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException
                                                                                                    .With.Message
                                                                                                    .EqualTo("Make cannot be null or empty!"));
        }

        //--------- MODEL ----------
        [Test]
        [TestCase("BMW", "M3", 6.5, 60)]
        public void ConstructorShouldInitializeCarModelCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(model, car.Model);
        }

        [Test]
        [TestCase("BMW", "", 6.5, 60)]
        [TestCase("BMW", null, 6.5, 60)]
        public void ConstructorShouldThrowArgumentExceptionInAttemptToSetModelValueToNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.That(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException
                                                                                                    .With.Message
                                                                                                    .EqualTo("Model cannot be null or empty!"));
        }

        //--------- FUEL CONSUMPTION ----------
        [Test]
        [TestCase("BMW", "M3", 6.5, 60)]
        public void ConstructorShouldInitializeCarFuelConsumptionCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
        }

        [Test]
        [TestCase("BMW", "M3", 0, 60)]
        [TestCase("BMW", "M3", -100, 60)]
        public void ConstructorShouldThrowArgumentExceptionInAttemptToSetFuelConsumptionValueZeroOrLess(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.That(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException
                                                                                                    .With.Message
                                                                                                    .EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        //--------- FUEL CAPACITY ----------
        [Test]
        [TestCase("BMW", "M3", 6.5, 60)]
        public void ConstructorShouldInitializeCarFuelFuelCapacityCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        [TestCase("BMW", "M3", 6.5, 0)]
        [TestCase("BMW", "M3", 6.5, -100)]
        public void ConstructorShouldThrowArgumentExceptionInAttemptToSetFuelCapacityToZeroOrLess(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.That(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException
                                                                                                    .With.Message
                                                                                                    .EqualTo("Fuel capacity cannot be zero or negative!"));
        }
        //-------------------- METHOD TESTS ----------------------
        //---------- REFUEL OPERATION TESTS ----------
        [Test]
        [TestCase(0)]
        [TestCase(-100.2)]
        public void RefuelOperationShouldThrowArgumentExceptionInAttemptToRefuelWithValueLessThanOrEqualToZero(double fuel)
        {
            Assert.That(() => this.car.Refuel(fuel), Throws.ArgumentException
                                                           .With.Message
                                                           .EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(59)]
        public void RefuelOperationShouldSetFuelAmountCorrectly(double fuel)
        {
            this.car.Refuel(fuel);
            Assert.AreEqual(fuel, this.car.FuelAmount);
        }

        [Test]
        [TestCase(60.1)]
        [TestCase(100)]
        public void RefuelOperationShouldSetFuelAmountCorrectlyWhenRefuelingOverflows(double fuel)
        {
            this.car.Refuel(fuel);
            double expectedFuelAmount = 60;

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        //---------- DRIVE OPERATION TESTS -----------
        [Test]
        [TestCase(6000)]
        public void DriveOperationShouldThrowInvalidOperationExceptionInAttemptToDriveABiggerDistanceWhenFuelIsNotEnough(double distance)
        {
            this.car.Refuel(60);

            Assert.That(() => this.car.Drive(distance), Throws.InvalidOperationException
                                                              .With.Message
                                                              .EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        [TestCase(10)]
        public void DriveOperationShouldDecrementFuelAmountCorrectly(double distance)
        {
            this.car.Refuel(60);
            this.car.Drive(distance);
            double expectedFuelAmount = 59.35;

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }
    }
}