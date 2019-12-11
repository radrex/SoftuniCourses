namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        //---------------- Fields ------------------
        private const int health = 2;
        private const int experience = 5;
        private const int attackPoints = 2;

        private Dummy dummy;

        //-------------- Initializer ---------------
        [SetUp]
        public void TestInit()
        {
            dummy = new Dummy(health, experience);
        }

        //---------------- Tests -------------------
        [Test]
        public void DummyLosesHeathWhenAttacked()
        {
            //Arrange

            //Act
            dummy.TakeAttack(attackPoints);

            //Assert
            Assert.IsTrue(dummy.Health < health, "Dummy HP doesn't change after attack.");
        }

        [Test]
        public void DeadDummyCantBeAttacked()
        {
            //Arrange

            //Act
            dummy.TakeAttack(attackPoints);

            //Assert
            //Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
            //Assert.Throws(Is.TypeOf<InvalidOperationException>().And.Message.EqualTo("Dummy is dead."), () => dummy.TakeAttack(attackPoints));
            //Assert.That(() => dummy.TakeAttack(attackPoints), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DummyGivesExperienceWhenDestroyed()
        {
            //Arrange

            //Act
            dummy.TakeAttack(attackPoints); // destroying the dummy

            //Assert
            Assert.AreEqual(dummy.GiveExperience(), experience, "Dead dummy doesn't give expected XP.");
        }

        [Test]
        public void AliveDummyDoesntGiveExperience() 
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
