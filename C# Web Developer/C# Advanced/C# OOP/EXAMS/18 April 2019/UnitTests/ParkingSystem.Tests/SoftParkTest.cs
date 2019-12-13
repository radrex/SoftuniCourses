namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Collections.Immutable;

    public class SoftParkTest
    {
        //---------------- Fields ------------------
        private Car car;
        private SoftPark softPark;

        //------------- Initialization -------------
        [SetUp]
        public void Setup()
        {
            this.car = new Car("BMW", "CA1424EP");
            this.softPark = new SoftPark();
        }

        //------------------ CONSTRUCTOR TESTS -------------------
        //---- CAR ----
        [Test]
        [TestCase("BMW")]
        public void ConstructorShouldInitializeCarMakeCorrectly(string make)
        {
            Assert.AreEqual(this.car.Make, make);
        }

        [Test]
        [TestCase("CA1424EP")]
        public void ConstructorShouldInitializeCarRegistrationNumberCorrectly(string registrationNumber)
        {
            Assert.AreEqual(this.car.RegistrationNumber, registrationNumber);
        }

        //---- SOFT PARK ----
        [Test]
        public void ConstructorShouldInitializeDictionaryCorrectly()
        {
            var softParkDict = new Dictionary<string, Car>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            CollectionAssert.AreEqual(softParkDict, this.softPark.Parking);
        }

        [Test]
        public void ParkingPropertyShouldReturnCorrectResult()
        {
            var softParkDict = new Dictionary<string, Car>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            }
            .ToImmutableDictionary();

            CollectionAssert.AreEqual(softParkDict, this.softPark.Parking);
        }

        //-------------------- METHOD TESTS ----------------------
        //---- PARK CAR ----
        [Test]
        [TestCase("")]
        [TestCase("A5")]
        public void ParkCarOperationShouldThrowArgumentExceptionInAttemptToParkCarOnInvalidParkSpot(string parkSpot)
        {
            Assert.That(() => this.softPark.ParkCar(parkSpot, this.car), Throws.ArgumentException
                                                                               .With.Message
                                                                               .EqualTo("Parking spot doesn't exists!"));
        }

        [Test]
        public void ParkCarOperationShouldThrowArgumentExceptionInAttemptToParkCarToTakenParkSpot()
        {
            this.softPark.ParkCar("A1", this.car);
            Assert.That(() => this.softPark.ParkCar("A1", new Car("Opel", "CA1021EP")), Throws.ArgumentException
                                                                                              .With.Message
                                                                                              .EqualTo("Parking spot is already taken!"));
        }

        [Test]
        public void ParkCarOperationShouldThrowInvalidOperationExceptionInAttemptToParkAlreadyParkedCar()
        {
            this.softPark.ParkCar("A1", this.car);
            Assert.That(() => this.softPark.ParkCar("A2", this.car), Throws.InvalidOperationException
                                                                           .With.Message
                                                                           .EqualTo("Car is already parked!"));
        }

        [Test]
        public void ParkCarOperationShouldParkTheCar()
        {
            this.softPark.ParkCar("A1", this.car);
            Car actualCar = this.softPark.Parking["A1"];

            Assert.AreEqual(this.car.RegistrationNumber, actualCar.RegistrationNumber);
        }

        [Test]
        public void ParkCarOperationShouldReturnCorrectMessage()
        {
            string expectedResult = $"Car:{this.car.RegistrationNumber} parked successfully!";
            string actualResult = this.softPark.ParkCar("A1", this.car);

            Assert.AreEqual(expectedResult, actualResult);
        }

        //---- REMOVE CAR ----
        [Test]
        public void RemoveCarOperationShouldThrowArgumentExceptionInAttemptToRemoveACarFromInvalidParkSpot()
        {
            Assert.That(() => this.softPark.RemoveCar("A5", this.car), Throws.ArgumentException
                                                                             .With.Message
                                                                             .EqualTo("Parking spot doesn't exists!"));
        }

        [Test]
        public void RemoveCarOperationShouldThrowArgumentExceptionInAttemptToRemoveAnInvalidCar()
        {
            Assert.That(() => this.softPark.RemoveCar("A1", this.car), Throws.ArgumentException
                                                                             .With.Message
                                                                             .EqualTo("Car for that spot doesn't exists!"));
        }

        [Test]
        public void RemoveCarOperationShouldRemoveCarCorrectly()
        {
            this.softPark.ParkCar("A1", this.car);
            this.softPark.RemoveCar("A1", this.car);

            Assert.AreEqual(null, this.softPark.Parking["A1"]);
        }

        [Test]
        public void RemoveCarOperationShouldReturnCorrectMessage()
        {
            this.softPark.ParkCar("A1", this.car);

            string expectedResult = $"Remove car:{this.car.RegistrationNumber} successfully!";
            string actualResult = this.softPark.RemoveCar("A1", this.car);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}