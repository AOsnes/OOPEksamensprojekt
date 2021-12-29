using System;
using System.Collections.Generic;
using OOPEksamensprojekt.Core.Exceptions;

namespace OOPEksamensprojekt.Core
{
    public class Stregsystem : IStregsystem
    {
        public IEnumerable<Product> ActiveProducts { get; }

        private List<Product> _products;
        private List<User> _users;
        private List<Transaction> _transactions;
        
        public event IStregsystem.BalanceWarning UserBalanceWarning;

        public Stregsystem()
        {
            _products = CsvReader.GetProductsFromCsv();
            _users = CsvReader.GetUsersFromCsv();
            _transactions = new List<Transaction>();
            ActiveProducts = _products.FindAll(product => product.Active);

            foreach (User user in _users)
            {
                user.BalanceChange += UserOnBalanceChange;
            }

        }

        private void UserOnBalanceChange(User user, decimal balance)
        {
            if (user.Balance < 50)
            {
                UserBalanceWarning?.Invoke(user, balance);
            }
        }

        public InsertCashTransaction AddCreditsToAccount(User user, int amount)
        {
            InsertCashTransaction transaction = new InsertCashTransaction(user, amount);
            _transactions.Add(transaction);
            return transaction;
        }

        public BuyTransaction BuyProduct(User user, Product product, int amount)
        {
            if (product.Active)
            {
                BuyTransaction transaction = new BuyTransaction(product, user, amount);
                _transactions.Add(transaction);
                return transaction;
            }

            throw new ProductInactiveException(product);
        }

        public Product GetProductByID(int id)
        {
            if (_products.Exists(product => id == product.Id))
            {
                Product result = _products.Find(product => id == product.Id);
                return result;
            }

            throw new ProductDoesNotExistException(id);
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            List<Transaction> transactions = _transactions.FindAll(transaction => user.Equals(transaction.TransactionUser));
            transactions.Reverse();
            if (transactions.Count < 10)
            {
                return transactions.GetRange(0, transactions.Count);
            }
            return transactions.GetRange(0, count);
        }

        public List<User> GetUsers(Func<User, bool> predicate)
        {
            List<User> result = new List<User>();

            foreach (User user in _users)
            {
                if (predicate(user))
                {
                    result.Add(user);
                }
            }

            return result;
        }

        public User GetUserByUsername(string username)
        {
            return _users.Find(user => user.Username.Equals(username)) ?? throw new UserDoesNotExistException(username);
        }

    }
}