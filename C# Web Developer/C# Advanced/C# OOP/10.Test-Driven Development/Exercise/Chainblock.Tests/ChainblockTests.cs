namespace Chainblock.Tests
{
    using Contracts;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ChainblockTests
    {
        //-------------- Fields ---------------
        private IChainblock chainblock;
        private ITransaction transaction;

        //-------------- Initialization ---------------
        [SetUp]
        public void Init()
        {
            this.chainblock = new Chainblock();
            this.transaction = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Stoyan", 250.20);
        }

        //----------------- Constructor Tests -----------------
        [Test]
        public void ConstructorShouldInitializeCollectionCorrectly()
        {
            Assert.AreEqual(0, this.chainblock.Count);
        }

        //----------------- Method Tests -----------------
        //---- CONTAINS METHODS ----
        [Test]
        public void ContainsMethodShouldReturnTrueWhenTransactionByIdFound()
        {
            this.chainblock.Add(this.transaction);
            Assert.AreEqual(true, this.chainblock.Contains(1));
        }

        [Test]
        public void ContainsMethodShouldReturnFalseWhenTransactionByIdNotFound()
        {
            Assert.AreEqual(false, this.chainblock.Contains(999));
        }

        [Test]
        public void ContainsMethodShouldReturnTrueWhenTransactionFound()
        {
            this.chainblock.Add(this.transaction);
            Assert.AreEqual(true, this.chainblock.Contains(this.transaction));
        }

        [Test]
        public void ContainsMethodShouldReturnFalseWhenTransactionNotFound()
        {
            ITransaction transaction = new Transaction(999, TransactionStatus.Aborted, "Gosho", "Pesho", 234.02);
            Assert.AreEqual(false, this.chainblock.Contains(transaction));
        }

        //---- ADD METHOD ----
        [Test]
        public void AddMethodShouldAddTransactionToChainblockCorrectly()
        {
            this.chainblock.Add(this.transaction);
            Assert.AreEqual(1, this.chainblock.Count);
        }

        [Test]
        public void AddMethodShouldThrowArgumentExceptionInAttemptToAddAlreadyExistingTransactionInChainblock()
        {
            this.chainblock.Add(this.transaction);
            Assert.That(() => this.chainblock.Add(this.transaction), Throws.ArgumentException
                                                                           .With.Message
                                                                           .EqualTo("Transaction already exists!"));
        }

        //---- CHANGE TRANSACTION STATUS METHOD ----
        [Test]
        public void ChangeTransactionStatusMethodShouldChangeTransactionStatusCorrectly()
        {
            this.chainblock.Add(this.transaction);
            this.chainblock.ChangeTransactionStatus(1, TransactionStatus.Unauthorized);

            Assert.That(() => this.transaction.Status == TransactionStatus.Unauthorized);
        }

        [Test]
        [TestCase(1)]
        public void ChangeTransactionStatusMethodShouldThrowArgumentExceptionInAttemptToChangeTransactionStatusToInvalidTransaction(int id)
        {
            Assert.That(() => this.chainblock.ChangeTransactionStatus(id, TransactionStatus.Unauthorized), Throws.ArgumentException
                                                                                                                 .With.Message
                                                                                                                 .EqualTo($"Transaction with id - {id} doesn't exist!"));
        }

        //---- REMOVE TRANSACTION BY ID METHOD ----
        [Test]
        public void RemoveTransactionByIdShouldRemoveTransactionFromChainblockCorrectly()
        {
            this.chainblock.Add(this.transaction);
            this.chainblock.RemoveTransactionById(1);

            Assert.AreEqual(0, this.chainblock.Count);
        }

        [Test]
        [TestCase(999)]
        public void RemoveTransactionByIdShouldThrowInvalidOperationExceptionInAttemptToRemoveInvalidTransaction(int id)
        {
            Assert.That(() => this.chainblock.RemoveTransactionById(id), Throws.InvalidOperationException
                                                                               .With.Message
                                                                               .EqualTo($"Transaction with id - {id} doesn't exist!"));
        }

        //---- GET BY ID METHOD ----
        [Test]
        [TestCase(1)]
        public void GetByIdMethodShouldReturnCorrectTransaction(int id)
        {
            this.chainblock.Add(this.transaction);

            ITransaction transaction = this.chainblock.GetById(id);

            Assert.AreEqual(this.transaction.Id, transaction.Id);
        }

        [Test]
        [TestCase(999)]
        public void GetByIdMethodShouldThrowInvalidOperationExceptionInAttemptToGetInvalidTransaction(int id)
        {
            Assert.That(() => this.chainblock.GetById(id), Throws.InvalidOperationException
                                                                 .With.Message
                                                                 .EqualTo($"Transaction with id - {id} doesn't exist!"));
        }

        //---- GET BY TRANSACTION STATUS METHOD ----
        [Test]
        public void GetByTransactionStatusShouldReturnTransactionsWithPassedStatusOrderedByAmountDescending()
        {
            this.chainblock.Add(new Transaction(1, TransactionStatus.Failed, "Ivan", "Georgi", 200.0));
            this.chainblock.Add(new Transaction(2, TransactionStatus.Failed, "Stoyan", "Georgi", 100.0));
            this.chainblock.Add(new Transaction(3, TransactionStatus.Failed, "Petar", "Georgi", 50.0));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Failed, "Mark", "Georgi", 150.0));
            ITransaction[] transactions = this.chainblock.GetByTransactionStatus(TransactionStatus.Failed).ToArray();

            ITransaction[] dummyTransactions = new Transaction[]
            {
                new Transaction(1, TransactionStatus.Failed, "Ivan", "Georgi", 200.0),
                new Transaction(2, TransactionStatus.Failed, "Stoyan", "Georgi", 100.0),
                new Transaction(3, TransactionStatus.Failed, "Petar", "Georgi", 50.0),
                new Transaction(4, TransactionStatus.Failed, "Mark", "Georgi", 150.0)
            }
            .OrderByDescending(tr => tr.Amount)
            .ToArray();

            for (int i = 0; i < transactions.Length; i++)
            {
                Assert.AreEqual(transactions[i].Id, dummyTransactions[i].Id);
            }
        }

        [Test]
        public void GetByTransactionStatusShouldThrowInvalidOperationExceptionInAttemptToGetTransactionsWithInvalidStatus() 
        {
            Assert.That(() => this.chainblock.GetByTransactionStatus(TransactionStatus.Failed), Throws.InvalidOperationException
                                                                                                      .With.Message
                                                                                                      .EqualTo("No such transactions!"));
        }

        //---- GET ALL SENDERS WITH TRANSACTION STATUS METHOD ----
        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnAllSendersWithPassedStatusOrderedByTransactionAmount()
        {
            this.chainblock.Add(new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0));
            this.chainblock.Add(new Transaction(2, TransactionStatus.Successfull, "Stoyan", "Georgi", 100.0));
            this.chainblock.Add(new Transaction(3, TransactionStatus.Successfull, "Petar", "Georgi", 50.0));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Failed, "Mark", "Georgi", 150.0));
            string[] senders = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull).ToArray();

            Assert.AreEqual(3, senders.Length);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowInvalidOperationExceptionIfNoSuchTransactionsExist()
        {
            Assert.That(() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed), Throws.InvalidOperationException
                                                                                                                  .With.Message
                                                                                                                  .EqualTo("No such senders!"));
        }

        //---- GET ALL RECEIVERS WITH TRANSACTION STATUS METHOD ----
        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnAllSendersWithPassedStatusOrderedByTransactionAmount()
        {
            this.chainblock.Add(new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0));
            this.chainblock.Add(new Transaction(2, TransactionStatus.Successfull, "Stoyan", "Georgi", 100.0));
            this.chainblock.Add(new Transaction(3, TransactionStatus.Successfull, "Petar", "Georgi", 50.0));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Failed, "Mark", "Georgi", 150.0));
            string[] receivers = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull).ToArray();

            Assert.AreEqual(3, receivers.Length);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrowInvalidOperationExceptionIfNoSuchTransactionsExist()
        {
            Assert.That(() => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed), Throws.InvalidOperationException
                                                                                                                    .With.Message
                                                                                                                    .EqualTo("No such receivers!"));
        }

        //---- GET ALL ORDERED BY AMOUNT DESCENDING THEN BY ID METHOD ----
        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdMethodShouldReturnCorrectAmountOfTransactions()
        {
            this.chainblock.Add(new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0));
            this.chainblock.Add(new Transaction(2, TransactionStatus.Successfull, "Stoyan", "Georgi", 100.0));
            this.chainblock.Add(new Transaction(3, TransactionStatus.Successfull, "Petar", "Georgi", 50.0));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Failed, "Mark", "Georgi", 150.0));

            ITransaction[] transactions = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToArray();

            Assert.AreEqual(4, transactions.Length);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdMethodShouldReturnCorrectTransactions()
        {
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Stoyan", "Georgi", 100.0);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Petar", "Georgi", 50.0);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Failed, "Mark", "Georgi", 150.0);

            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);

            List<ITransaction> expected = new List<ITransaction>() { transaction1, transaction2, transaction3, transaction4 };
            expected = expected.OrderByDescending(tr => tr.Amount).ThenBy(tr => tr.Id).ToList();

            List<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        //---- GET BY SENDER ORDERED BY AMOuNT DESCENDING METHOD ----
        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodShouldReturnCorrectAmountOfTransactions()
        {
            this.chainblock.Add(new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0));
            this.chainblock.Add(new Transaction(2, TransactionStatus.Successfull, "Ivan", "Nikolay", 100.0));
            this.chainblock.Add(new Transaction(3, TransactionStatus.Successfull, "Petar", "Georgi", 50.0));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Failed, "Ivan", "Pesho", 150.0));

            ITransaction[] transactions = this.chainblock.GetBySenderOrderedByAmountDescending("Ivan").ToArray();
            Assert.AreEqual(3, transactions.Length);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodShouldReturnCorrectTransactions()
        {
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Ivan", "Nikolay", 100.0);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Petar", "Georgi", 50.0);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Failed, "Ivan", "Pesho", 150.0);

            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);

            List<ITransaction> expected = new List<ITransaction>() { transaction1, transaction2, transaction4 };
            expected = expected.OrderByDescending(tr => tr.Amount).ToList();

            List<ITransaction> actual = this.chainblock.GetBySenderOrderedByAmountDescending("Ivan").ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodShouldThrowInvalidOperationExceptionIfNoSuchTransactions()
        {
            Assert.That(() => this.chainblock.GetBySenderOrderedByAmountDescending("Ivan"), Throws.InvalidOperationException
                                                                                                  .With.Message
                                                                                                  .EqualTo("No such transactions!"));
        }

        //---- GET BY RECEIVER ORDERED BY AMOUNT THEN BY ID METHOD ----
        [Test]
        public void GetByReceiverOrderedByAmountThenByIdMethodShouldReturnCorrectAmountOfTransactions()
        {
            this.chainblock.Add(new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0));
            this.chainblock.Add(new Transaction(2, TransactionStatus.Successfull, "Ivan", "Nikolay", 100.0));
            this.chainblock.Add(new Transaction(3, TransactionStatus.Successfull, "Petar", "Georgi", 50.0));
            this.chainblock.Add(new Transaction(4, TransactionStatus.Failed, "Ivan", "Pesho", 150.0));

            ITransaction[] transactions = this.chainblock.GetByReceiverOrderedByAmountThenById("Georgi").ToArray();

            Assert.AreEqual(2, transactions.Length);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdMethodShouldReturnCorrectTransactions()
        {
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Ivan", "Nikolay", 100.0);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Petar", "Georgi", 50.0);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Failed, "Ivan", "Pesho", 150.0);

            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);

            List<ITransaction> expected = new List<ITransaction>() { transaction1, transaction3 };
            expected = expected.OrderByDescending(tr => tr.Amount).ThenBy(tr => tr.Id).ToList();

            List<ITransaction> actual = this.chainblock.GetByReceiverOrderedByAmountThenById("Georgi").ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdMethodShouldThrowInvalidOperationExceptionIfNoSuchTransactions()
        {
            Assert.That(() => this.chainblock.GetByReceiverOrderedByAmountThenById("Georgi"), Throws.InvalidOperationException
                                                                                                    .With.Message
                                                                                                    .EqualTo("No such transactions!"));
        }

        //---- GET BY TRANSACTION STATUS AND MAXIMUM AMOUNT METHOD ----
        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnCorrectAmountOfTransactions()
        {
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Ivan", "Nikolay", 100.0);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Petar", "Georgi", 50.0);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Failed, "Ivan", "Pesho", 150.0);

            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);

            List<ITransaction> expected = new List<ITransaction>() { transaction2, transaction3 };
            expected = expected.OrderByDescending(tr => tr.Amount).ToList();

            List<ITransaction> actual = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 100).ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollection()
        {
            Assert.AreEqual(0, this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 100).Count());
        }

        //---- GET BY SENDER AND MINIMUM DESCENDING METHOD ----
        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnCorrectAmountOfTransactions()
        {
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Ivan", "Georgi", 100.0);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Ivan", "Georgi", 50.0);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Failed, "Ivan", "Georgi", 150.0);

            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);

            Assert.AreEqual(2, this.chainblock.GetBySenderAndMinimumAmountDescending("Ivan", 100).Count());
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnCorrectTransactions()
        {
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Ivan", "Georgi", 100.0);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Ivan", "Georgi", 50.0);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Failed, "Ivan", "Georgi", 150.0);

            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);

            List<ITransaction> expected = new List<ITransaction>() { transaction1, transaction4 };
            expected = expected.OrderByDescending(tr => tr.Amount).ToList();

            List<ITransaction> actual = this.chainblock.GetBySenderAndMinimumAmountDescending("Ivan", 100).ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldThrowInvalidOperationExceptionIfNoSuchTransactionsFound()
        {
            Assert.That(() => this.chainblock.GetBySenderAndMinimumAmountDescending("Ivan", 100), Throws.InvalidOperationException
                                                                                                        .With.Message
                                                                                                        .EqualTo("No such transactions!"));
        }

        //---- GET BY RECEIVER AND AMOUNT RANGE METHOD ----
        [Test]
        public void GetByReceiverAndAmountRangeMethodShouldReturnCorrectAmountOfTransactions()
        {
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Ivan", "Georgi", 100.0);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Ivan", "Georgi", 50.0);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Failed, "Ivan", "Georgi", 150.0);

            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);

            Assert.AreEqual(2, this.chainblock.GetByReceiverAndAmountRange("Ivan", 0, 150).Count());
        }

        [Test]
        public void GetByReceiverAndAmountRangeMethodShouldReturnCorrectTransactions()
        {
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Ivan", "Georgi", 100.0);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Ivan", "Georgi", 50.0);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Failed, "Ivan", "Georgi", 150.0);

            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);

            List<ITransaction> expected = new List<ITransaction>() { transaction2, transaction3 };
            expected = expected.OrderByDescending(tr => tr.Amount).ThenBy(tr => tr.Id).ToList();

            List<ITransaction> actual = this.chainblock.GetByReceiverAndAmountRange("Ivan", 0, 150).ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }

        [Test]
        public void GetByReceiverAndAmountRangeMethodShouldThrowInvalidOperationExceptionIfNoSuchTransactionsExist()
        {
            Assert.That(() => this.chainblock.GetByReceiverAndAmountRange("Ivan", 0, 100), Throws.InvalidOperationException
                                                                                                 .With.Message
                                                                                                 .EqualTo("No such transactions!"));
        }

        //---- GET ALL IN AMOUNT RANGE METHOD ----
        [Test]
        public void GetAllInAmountRangeShouldReturnCorrectCollection()
        {
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Ivan", "Georgi", 100.0);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Ivan", "Georgi", 50.0);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Failed, "Ivan", "Georgi", 150.0);

            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);

            List<ITransaction> expected = new List<ITransaction>() { transaction2, transaction3, transaction4 };
            List<ITransaction> actual = this.chainblock.GetAllInAmountRange(0, 150).ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }

        [Test]
        public void GetAllInAmountRangeShouldReturnEmptyCollection()
        {
            Assert.AreEqual(0, this.chainblock.GetAllInAmountRange(0, 150).Count());
        }

        //---- GET ENUMERATOR<PRODUCT> METHOD ----
        [Test]
        public void GetEnumeratorTransactionShouldReturnAllTransactions()
        {
            ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Georgi", 200.0);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Ivan", "Georgi", 100.0);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Ivan", "Georgi", 50.0);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Failed, "Ivan", "Georgi", 150.0);

            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);

            List<ITransaction> transactions = new List<ITransaction>() { transaction1, transaction2, transaction3, transaction4 };

            IEnumerator<ITransaction> enumerator = this.chainblock.GetEnumerator();

            int index = 0;
            while (enumerator.MoveNext())
            {
                ITransaction currentTransaction = enumerator.Current;
                Assert.AreEqual(transactions[index++].Id, currentTransaction.Id);
            }
        }
    }
}
