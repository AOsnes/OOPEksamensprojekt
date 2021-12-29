using System;

namespace OOPEksamensprojekt.Core
{
    public abstract class Transaction
    {
        public int Id { get; private set; }
        private static int _idCount = 0;
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

                _transactionUser = value;
            } 
        }

        public DateTime TransactionDate { get; private set; }
        public decimal Value { get; protected set; }

        public Transaction(User transactionUser, decimal value)
        {
            TransactionUser = transactionUser;
            Value = value;
            TransactionDate = DateTime.Now;
            Id = _idCount;
            _idCount++;
        }

        public override string ToString()
        {
            return $"Transaction ID: {Id} User: {TransactionUser.Username} Amount: {Value} Date: {TransactionDate.ToString()}";
        }

        public abstract void Execute();
    }
}