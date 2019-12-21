namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        //----------- Fields ------------
        private IProductStock productStock;
        private IProduct product;

        //----------- Initialization ------------
        [SetUp]
        public void Init()
        {
            productStock = new ProductStock();
            product = new Product("bira", 1.20M, 2);
        }

        //--------------------- Constructor Tests -----------------------
        [Test]
        public void ConstructorShouldInitializeCollectionCorrectly()
        {
            Assert.AreEqual(0, this.productStock.Count);
        }

        //--------------------- Property Tests -----------------------
        [Test]
        public void PropertyCountShouldReturnCorrectCollectionCount()
        {
            this.productStock.Add(new Product("bira", 1.20M, 2));
            Assert.AreEqual(1, this.productStock.Count);
        }

        [Test]
        public void IndexerShouldTakeItemOnIndex()
        {
            this.productStock.Add(this.product);
            IProduct extractedProduct = this.productStock[0];

            Assert.AreEqual(0, product.CompareTo(extractedProduct));
        }

        [Test]
        public void IndexerShouldSetItemOnIndex()
        {
            this.productStock.Add(this.product);

            IProduct newProduct = new Product("rakiya special edition", 15.50M, 5);
            this.productStock[0] = newProduct;

            Assert.AreEqual(0, newProduct.CompareTo(this.productStock[0]));
        }

        [Test]
        public void IndexerShouldThrowIndexOutOfRangeExceptionInAttemptToTakeProductOnInvalidIndex()
        {
            Assert.That(() => this.productStock[2], Throws.TypeOf<IndexOutOfRangeException>()
                                                          .With.Message
                                                          .EqualTo("Index was out of range!"));
        }

        //--------------------- Method Tests -----------------------
        //---- ADD METHOD ----
        [Test]
        public void AddMethodShouldAddNewProductInProductStock()
        {
            this.productStock.Add(this.product);
            Assert.AreEqual(1, this.productStock.Count);
        }

        [Test]
        public void AddMethodShouldThrowArgumentExceptionInAttemptToAddAlreadyExistingProduct()
        {
            this.productStock.Add(this.product);
            Assert.That(() => this.productStock.Add(this.product), Throws.ArgumentException
                                                                         .With.Message
                                                                         .EqualTo("Product already existing!"));
        }

        //---- REMOVE METHOD ----
        [Test]
        public void RemoveMethodShouldRemoveProductSuccessfully()
        {
            this.productStock.Add(this.product);
            this.productStock.Remove(this.product);

            Assert.AreEqual(0, this.productStock.Count);
        }

        [Test]
        public void RemoveMethodShouldReturnTrueWhenProductRemoved()
        {
            this.productStock.Add(this.product);

            Assert.AreEqual(true, this.productStock.Remove(this.product));
        }

        [Test]
        public void RemoveMethodShouldReturnFalseWhenProductIsntRemoved()
        {
            Assert.AreEqual(false, this.productStock.Remove(this.product));
        }

        //---- CONTAINS METHOD ----
        [Test]
        public void ContainsMethodShouldReturnTrueWhenSearchingForValidProduct()
        {
            this.productStock.Add(this.product);
            Assert.AreEqual(true, this.productStock.Contains(this.product));
        }

        [Test]
        public void ContainsMethodShouldReturnFalseWhenSearchingForInvalidProduct()
        {
            Assert.AreEqual(false, this.productStock.Contains(this.product));
        }

        //---- FIND METHOD ----
        [Test]
        public void FindMethodShouldReturnCorrectProduct()
        {
            this.productStock.Add(this.product);

            IProduct extractedProduct = this.productStock.Find(0);

            Assert.AreEqual(this.product.Label, extractedProduct.Label);
        }

        [Test]
        public void FindMethodShouldThrowIndexOutOfRangeExceptionInAttemptToGetItemAtInvalidIndex()
        {
            Assert.That(() => this.productStock.Find(0), Throws.TypeOf<IndexOutOfRangeException>()
                                                               .With.Message
                                                               .EqualTo("Index was out of range!"));
        }

        //---- FIND BY LABEL METHOD ----
        [Test]
        public void FindByLabelMethodShouldReturnCorrectProduct()
        {
            this.productStock.Add(this.product);

            IProduct extractedProduct = this.productStock.FindByLabel("bira");

            Assert.AreEqual(this.product.Label, extractedProduct.Label);
        }

        [Test]
        public void FindByLabelMethodShouldThrowArgumentException()
        {
            Assert.That(() => this.productStock.FindByLabel("bira"), Throws.ArgumentException
                                                                           .With.Message
                                                                           .EqualTo("No such product in stock!"));
        }

        //---- FIND ALL IN PRICE RANGE METHOD ----
        [Test]
        [TestCase(12, 45.0)]
        [TestCase(10.0, 60.0)]
        [TestCase(2.1, 299.99)]
        public void FindAllInRangeMethodShouldReturnCorrectRangeOfProducts(double low, double high)
        {
            IProduct ball = new Product("Ballin'", 2.0M, 10);
            IProduct shoes = new Product("LeatherShh", 12.0M, 3);
            IProduct jacket = new Product("Denim", 45.0M, 5);
            IProduct ski = new Product("Snow Floaters", 300.0M, 1);

            this.productStock.Add(ball);
            this.productStock.Add(shoes);
            this.productStock.Add(jacket);
            this.productStock.Add(ski);

            IEnumerable<IProduct> expected = new List<IProduct>() { jacket, shoes };
            IEnumerable<IProduct> actual = this.productStock.FindAllInRange(low, high);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(12, 45.0)]
        [TestCase(10.0, 60.0)]
        [TestCase(2.1, 299.99)]
        public void FindAllInRangeMethodShouldReturnEmptyCollection(double low, double high)
        {
            IEnumerable<IProduct> resultCollection = this.productStock.FindAllInRange(low, high).ToList();

            Assert.AreEqual(0, resultCollection.Count());
        }

        //---- FIND ALL BY PRICE METHOD ----
        [Test]
        public void FindAllByPriceMethodShouldReturnCorrectCollectionOfProductsWithPassedPrice()
        {
            IProduct ball = new Product("Ballin'", 2.0M, 10);
            IProduct ball2 = new Product("Ball", 2.0M, 10);
            IProduct ball3 = new Product("RoundedBall", 2.0M, 10);
            IProduct ball4 = new Product("OvalBall", 2.0M, 10);

            this.productStock.Add(ball);
            this.productStock.Add(ball2);
            this.productStock.Add(ball3);
            this.productStock.Add(ball4);

            IEnumerable<IProduct> expected = this.productStock.FindAllByPrice(2.0);

            Assert.AreEqual(4, expected.Count());
        }

        [Test]
        public void FindAllByPriceMethodShouldReturnEmptyCollectionOfProductsWithPassedPrice()
        {
            IEnumerable<IProduct> expected = this.productStock.FindAllByPrice(2.0);

            Assert.AreEqual(0, expected.Count());
        }

        //---- FIND MOST EXPENSIVE PRODUCTS METHOD ----
        [Test]
        public void FindMostExpensiveProductMethodShouldReturnMostExpensiveProduct()
        {
            IProduct ball = new Product("Ballin'", 2.0M, 10);
            IProduct ski = new Product("Snow Floaters", 300.0M, 1);
            this.productStock.Add(ball);
            this.productStock.Add(ski);

            IProduct mostExpensiveProduct = this.productStock.FindMostExpensiveProduct();

            Assert.AreEqual("Snow Floaters", mostExpensiveProduct.Label);
        }

        [Test]
        public void FindMostExpensiveProductMethodShouldReturnNull()
        {
            IProduct mostExpensiveProduct = this.productStock.FindMostExpensiveProduct();

            Assert.AreEqual(null, mostExpensiveProduct);
        }

        //---- FIND ALL BY QUANTITY METHOD ----
        [Test]
        public void FindAllByQuantityMethodShouldCorrectCollectionOfProductsWithPassedRemainingQuantity()
        {
            IProduct ball = new Product("Ballin'", 2.0M, 10);
            IProduct shoes = new Product("LeatherShh", 12.0M, 3);
            IProduct jacket = new Product("Denim", 45.0M, 3);
            IProduct ski = new Product("Snow Floaters", 300.0M, 1);

            this.productStock.Add(ball);
            this.productStock.Add(shoes);
            this.productStock.Add(jacket);
            this.productStock.Add(ski);

            IEnumerable<IProduct> expected = new List<IProduct>() { shoes, jacket };
            IEnumerable<IProduct> actual = this.productStock.FindAllByQuantity(3);

            Assert.AreEqual(expected.Count(), actual.Count());
        }

        [Test]
        public void FindAllByQuantityMethodShouldEmptyCollectionOfProductsWithPassedRemainingQuantity()
        {
            IEnumerable<IProduct> actual = this.productStock.FindAllByQuantity(3);

            Assert.AreEqual(0, actual.Count());
        }

        //---- GET ENUMERATOR<PRODUCT> METHOD ----
        [Test]
        public void GetEnumeratorProductShouldReturnAllProductsInStock()
        {
            IProduct ball = new Product("Ballin'", 2.0M, 10);
            IProduct shoes = new Product("LeatherShh", 12.0M, 3);
            IProduct jacket = new Product("Denim", 45.0M, 3);
            IProduct ski = new Product("Snow Floaters", 300.0M, 1);

            this.productStock.Add(ball);
            this.productStock.Add(shoes);
            this.productStock.Add(jacket);
            this.productStock.Add(ski);

            List<IProduct> products = new List<IProduct>() { ball, shoes, jacket, ski };

            IEnumerator<IProduct> enumerator = this.productStock.GetEnumerator();

            int index = 0;
            while (enumerator.MoveNext())
            {
                IProduct currentProduct = enumerator.Current;
                Assert.AreEqual(products[index++].Label, currentProduct.Label);
            }
        }
    }
}
