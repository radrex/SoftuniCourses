namespace BlueOrigin.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {

        [Test]
        public void AstronautCtorTest()
        {
            Astronaut astro = new Astronaut("Ivan", 20.5);
            Assert.AreEqual("Ivan", astro.Name);
            Assert.AreEqual(20.5, astro.OxygenInPercentage);
        }

        [Test]
        public void SpaceShipCtorTest()
        {
            Spaceship spaceship = new Spaceship("C4", 5);
            List<Astronaut> astronauts = new List<Astronaut>();

            Assert.AreEqual("C4", spaceship.Name);
            Assert.AreEqual(5, spaceship.Capacity);
            Assert.AreEqual(astronauts.Count, spaceship.Count);
        }

        [Test]
        public void ExceptionTests()
        {
            Assert.That(() => new Spaceship("", 5), Throws.TypeOf<ArgumentNullException>()
                .With.Property("ParamName").EqualTo("value"));

            Assert.That(() => new Spaceship("C4", -1), Throws.ArgumentException
                .With.Message.EqualTo("Invalid capacity!"));

            //--------------------------------------------------- ADD
            Spaceship spaceship = new Spaceship("C4", 1);
            Astronaut astronaut = new Astronaut("Ivan", 20.5);
            spaceship.Add(new Astronaut("Ivan", 20.5));

            Assert.That(() => spaceship.Add(astronaut), Throws.InvalidOperationException
                .With.Message.EqualTo("Spaceship is full!"));

            //------------------------------------
            spaceship = new Spaceship("C4", 2);
            spaceship.Add(new Astronaut("Ivan", 20.5));
            spaceship.Add(new Astronaut("Georgi", 10));

            astronaut = new Astronaut("Russian Austronaut", 10000);

            Assert.That(() => spaceship.Add(astronaut), Throws.InvalidOperationException
                .With.Message.EqualTo("Spaceship is full!"));

            //------------------------------------
            spaceship = new Spaceship("C4", 2);
            spaceship.Add(new Astronaut("Ivan", 20.5));
            astronaut = new Astronaut("Ivan", 20.5);

            Assert.That(() => spaceship.Add(astronaut), Throws.InvalidOperationException
                .With.Message.EqualTo($"Astronaut {astronaut.Name} is already in!"));

            //------------------------------------
            spaceship = new Spaceship("C4", 2);
            astronaut = new Astronaut("Ivan", 20.5);

            spaceship.Add(astronaut);
            Assert.AreEqual(1, spaceship.Count);

            //------------------------------------ REMOVE
            Assert.AreEqual(spaceship.Remove("Ivan"), true);

            Assert.AreEqual(spaceship.Remove("Ivan"), false);
        }
    }
}