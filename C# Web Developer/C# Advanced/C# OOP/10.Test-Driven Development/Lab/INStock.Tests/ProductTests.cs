namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        //----------- Fields ------------
        private IProduct product;

        [SetUp]
        public void Init()
        {
            product = new Product("bira", 1.20M, 2);
        }

        //--------------------- Constructor Tests -----------------------
        [Test]
        public void ConstructorShouldInitializeLabelCorrectly()
        {
            Assert.AreEqual("bira", this.product.Label);
        }

        [Test]
        public void ConstructorShouldInitializePriceCorrectly()
        {
            Assert.AreEqual(1.20M, this.product.Price);
        }

        [Test]
        public void ConstructorShouldInitializeQuantityCorrectly()
        {
            Assert.AreEqual(2, this.product.Quantity);
        }

        //------------------------ Exception Tests -------------------------
        //-------- LABEL --------
        [Test]
        public void LabelPropertySetterShouldThrowArgumentNullExceptionWhenPassedNullValue()
        {

            Assert.That(() => new Product(null, 1.20M, 2), Throws.TypeOf<ArgumentNullException>()
                                                                 .With.Property("ParamName")
                                                                 .EqualTo("Label parameter is null!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("   ")]
        public void LabelPropertyShouldThrowArgumentExceptionWhenPassedEmptyOrWhitespaceValue(string label)
        {
            Assert.That(() => new Product(label, 1.20M, 2), Throws.ArgumentException
                                                                  .With.Message
                                                                  .EqualTo("Label cannot be empty or whitespace!"));
        }

        //-------- PRICE --------
        [Test]
        [TestCase(0.0)]
        [TestCase(-1.0)]
        public void PricePropertyShouldThrowArgumentExceptionInAttemptToSetValueToZeroOrLess(decimal price)
        {
            Assert.That(() => new Product("bira", price, 2), Throws.ArgumentException
                                                                   .With.Message
                                                                   .EqualTo("Price cannot be zero or less!"));
        }

        //-------- QUANTITY --------
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void QuantityPropertyShouldThrowArgumentExceptionInAttemptToSetValueToZeroOrLess(int quantity)
        {
            Assert.That(() => new Product("bira", 1.20M, quantity), Throws.ArgumentException
                                                                          .With.Message
                                                                          .EqualTo("Quantity cannot be zero or less!"));
        }

        //------------------------ Method Tests -------------------------
        //-------- CompareTo --------
        [Test]
        public void CompareToMethodShouldCompare2ProductsByLabelAndReturn0()
        {
            IProduct other = new Product("bira", 1.20M, 2);
            Assert.AreEqual(0, this.product.CompareTo(other));
        }

        [Test]
        public void CompareToMethodShouldCompare2ProductsByLabelAndReturn1()
        {
            IProduct other = new Product("cola", 1.20M, 2);
            Assert.AreEqual(1, this.product.CompareTo(other));
        }
    }
}