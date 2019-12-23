using Chainblock.Contracts;
using System;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        //------------------- Fields --------------------
        private int id;
        private TransactionStatus status;
        private string from;
        private string to;
        private double amount;

        //---------------- Constructors -----------------
        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        //----------------- Properties ------------------
        public int Id
        {
            get => this.id;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Can't set id value to 0 or less");
                }
                this.id = value;
            }
        }

        public TransactionStatus Status
        {
            get => this.status;
            set
            {
                this.status = value;
            }
        }

        public string From
        {
            get => this.from;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("From value cannot be null!");
                }

                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("From value cannot be empty or whitespace!");
                }
                this.from = value;
            }
        }

        public string To
        {
            get => this.to;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("To value cannot be null!");
                }

                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("To value cannot be empty or whitespace!");
                }

                this.to = value;
            }
        }

        public double Amount
        {
            get => this.amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount cannot be less than or equal to 0!");
                }
                this.amount = value;
            }
        }
    }
}
