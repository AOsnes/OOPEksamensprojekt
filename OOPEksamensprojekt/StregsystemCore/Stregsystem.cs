using System;
using System.Collections.Generic;
namespace OOPEksamensprojekt.StregsystemCore
{
    public class Stregsystem : IStregsystem
    {
        public IEnumerable<Product> ActiveProducts { get; }

        private List<Product> _products;
        private List<User> _users;
        private List<Transaction> _transactions;

        public Stregsystem()
        {
            _products = CsvReader.GetProductsFromCsv();
            _users = CsvReader.GetUsersFromCsv();
            _transactions = new List<Transaction>();
            ActiveProducts = _products.FindAll(product => product.Active);
            

        }
        
        public InsertCashTransaction AddCreditsToAccount(User user, int amount)
        {
            InsertCashTransaction transaction = new InsertCashTransaction(user, amount);
            _transactions.Add(transaction);
            return transaction;
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            if (product.Active)
            {
                BuyTransaction transaction = new BuyTransaction(product, user);
                _transactions.Add(transaction);
                return transaction;
            }

            throw new ProductInactiveException(product);
        }

        public Product GetProductByID(int id)
        {
            if (_products.Exists(product => id == product.Id))
            {
                return _products.Find(product => id == product.Id);
            }

            throw new ProductDoesNotExistException(id);
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            List<Transaction> transactions = _transactions.FindAll(transaction => user.Equals(transaction.TransactionUser));
            transactions.Reverse();
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

        public event User.UserBalanceNotification UserBalanceWarning;
    }
}