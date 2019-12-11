namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        //---------------- Fields ------------------
        private const int AxeAtack = 1;
        private const int AxeDurability = 1;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        private Axe axe;
        private Dummy dummy;

        //-------------- Initializer ---------------
        [SetUp]
        public void TestInit()
        {
            axe = new Axe(AxeAtack, AxeDurability);
            dummy = new Dummy(DummyHealth, DummyExperience);
        }

        //---------------- Tests -------------------
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            //Arrange

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.AreEqual(0, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
            //Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void BrokenAxeCantAttack()
        {
            //Arrange

            //Act
            axe.Attack(dummy);

            //Assert
            //Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
            //Assert.Throws(Is.TypeOf<InvalidOperationException>().And.Message.EqualTo("Axe is broken."), () => axe.Attack(dummy));
        }
    }
}
