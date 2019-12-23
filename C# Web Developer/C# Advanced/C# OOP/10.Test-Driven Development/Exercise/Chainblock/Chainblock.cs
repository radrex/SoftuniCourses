namespace Chainblock
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Chainblock : IChainblock
    {
        //------------- Fields --------------
        private readonly Dictionary<int, ITransaction> transactions;

        //---------- Constructors -----------
        public Chainblock()
        {
            this.transactions = new Dictionary<int, ITransaction>();
        }

        //----------- Properties ------------
        public int Count => this.transactions.Count;

        //------------ Methods --------------
        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new ArgumentException("Transaction already exists!");
            }

            this.transactions.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException($"Transaction with id - {id} doesn't exist!");
            }

            this.transactions[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return this.transactions.ContainsKey(tx.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.transactions.Values.Where(tr => tr.Amount >= lo && tr.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions.Values.OrderByDescending(tr => tr.Amount).ThenBy(tr => tr.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            string[] receivers = this.transactions.Values.Where(tr => tr.Status == status)
                                                         .ToArray()
                                                         .OrderBy(tr => tr.Amount)
                                                         .Select(s => s.To)
                                                         .ToArray();
            if (receivers.Length == 0)
            {
                throw new InvalidOperationException("No such receivers!");
            }

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            string[] senders = this.transactions.Values.Where(tr => tr.Status == status)
                                                       .ToArray()
                                                       .OrderBy(tr => tr.Amount)
                                                       .Select(s => s.From)
                                                       .ToArray();
            if (senders.Length == 0)
            {
                throw new InvalidOperationException("No such senders!");
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with id - {id} doesn't exist!");
            }

            return this.transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var transactions = this.transactions.Values.Where(tr => tr.From == receiver && tr.Amount >= lo && tr.Amount < hi)
                                                       .OrderByDescending(tr => tr.Amount)
                                                       .ThenBy(tr => tr.Id);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("No such transactions!");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var transactions = this.transactions.Values.Where(tr => tr.To == receiver)
                                                       .OrderByDescending(tr => tr.Amount)
                                                       .ThenBy(tr => tr.Id);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("No such transactions!");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var transactions = this.transactions.Values.Where(tr => tr.From == sender && tr.Amount > amount)
                                                       .OrderByDescending(tr => tr.Amount);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("No such transactions!");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var transacions = this.transactions.Values.Where(tr => tr.From == sender).OrderByDescending(tr => tr.Amount);

            if (transacions.Count() == 0)
            {
                throw new InvalidOperationException("No such transactions!");
            }

            return transacions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            ITransaction[] transactions = this.transactions.Values.Where(tr => tr.Status == status)
                                                                  .OrderByDescending(tr => tr.Amount)
                                                                  .ToArray();
            if (transactions.Length == 0)
            {
                throw new InvalidOperationException("No such transactions!");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.transactions.Values.Where(tr => tr.Status == status && tr.Amount <= amount)
                                           .OrderByDescending(tr => tr.Amount);
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with id - {id} doesn't exist!");
            }

            this.transactions.Remove(id);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            for (int i = 0; i < this.transactions.Count; i++)
            {
                yield return this.transactions[i + 1]; // Hacked... How to return key value pair for GetEnumerator ?
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
