using System;

namespace OOPEksamensprojekt.StregsystemCore
{
    public abstract class Transaction
    {
        public int Id { get; private set; }
        private int _idCount = 0;
        private User _transactionUser;
        public User TransactionUser
        {
            get
            {
                return _transactionUser;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("User cannot be null");
                }
            } 
        }

        public DateTime TransactionDate { get; private set; }
        public decimal Amount { get; protected set; }

        public Transaction(User transactionUser, decimal amount)
        {
            TransactionUser = transactionUser;
            Amount = amount;
            TransactionDate = DateTime.Now;
            Id = _idCount;
            _idCount++;
        }

        public override string ToString()
        {
            return $"Transaction ID: {Id} User: {TransactionUser} Amount: {Amount} Date: {TransactionDate.ToString()}";
        }

        public abstract void Execute();
    }
}