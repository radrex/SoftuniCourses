namespace Chainblock.Tests
{
    using Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class TransactionTests
    {
        //-------------- Fields ---------------
        private ITransaction transaction;

        //-------------- Initialization ---------------
        [SetUp]
        public void Init()
        {
            this.transaction = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Stoyan", 250);
        }

        //----------------- Constructor Tests -----------------
        [Test]
        public void ConstructorShouldInitializePropertyIdCorrectly()
        {
            Assert.AreEqual(1, this.transaction.Id);
        }

        [Test]
        public void ConstructorShouldInitializePropertyStatusCorrectly()
        {
            Assert.AreEqual(TransactionStatus.Successfull, this.transaction.Status);
        }

        [Test]
        public void ConstructorShouldInitializePropertyFromCorrectly()
        {
            Assert.AreEqual("Ivan", this.transaction.From);
        }

        [Test]
        public void ConstructorShouldInitializePropertyToCorrectly()
        {
            Assert.AreEqual("Stoyan", this.transaction.To);
        }

        [Test]
        public void ConstructorShouldInitializePropertyAmountCorrectly()
        {
            Assert.AreEqual(250, this.transaction.Amount);
        }

        //----------------- Exception Tests -----------------
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-532512)]
        public void SettingPropertyIdToZeroOrLessShouldThrowArgumentException(int id)
        {
            Assert.That(() => this.transaction.Id = id, Throws.ArgumentException
                                                              .With.Message
                                                              .EqualTo("Can't set id value to 0 or less"));
        }

        [Test]
        public void SettingPropertyFromToNullShouldThrowArgumentNullException()
        {
            Assert.That(() => this.transaction.From = null, Throws.TypeOf<ArgumentNullException>()
                                                                  .With.Property("ParamName")
                                                                  .EqualTo("From value cannot be null!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("   ")]
        public void SettingPropertyFromToEmptyOrWhiteSpaceShoultThrowArgumentException(string from)
        {
            Assert.That(() => this.transaction.From = from, Throws.ArgumentException
                                                                  .With.Message
                                                                  .EqualTo("From value cannot be empty or whitespace!"));
        }

        [Test]
        public void SettingToPropertyToNullShouldThrowArgumentNullException()
        {
            Assert.That(() => this.transaction.To = null, Throws.TypeOf<ArgumentNullException>()
                                                                  .With.Property("ParamName")
                                                                  .EqualTo("To value cannot be null!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("   ")]
        public void SettingToPropertyToEmptyOrWhiteSpaceShoultThrowArgumentException(string to)
        {
            Assert.That(() => this.transaction.To = to, Throws.ArgumentException
                                                                .With.Message
                                                                .EqualTo("To value cannot be empty or whitespace!"));
        }

        [Test]
        [TestCase(0.0)]
        [TestCase(-10.0)]
        [TestCase(-5151.25)]
        public void SettingPropertyAmountToZeroOrLessShouldThrowArgumentException(double amount)
        {
            Assert.That(() => this.transaction.Amount = amount, Throws.ArgumentException
                                                                      .With.Message
                                                                      .EqualTo("Amount cannot be less than or equal to 0!"));
        }
    }
}
