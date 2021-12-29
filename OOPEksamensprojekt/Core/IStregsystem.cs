using System;
using System.Collections.Generic;

namespace OOPEksamensprojekt.Core
{
    public interface IStregsystem
    {
        IEnumerable<Product> ActiveProducts { get; }
        InsertCashTransaction AddCreditsToAccount(User user, int amount);
        BuyTransaction BuyProduct(User user, Product product, int amount);
        Product GetProductByID(int id);
        IEnumerable<Transaction> GetTransactions(User user, int count);
        List<User> GetUsers(Func<User, bool> predicate);
        User GetUserByUsername(string username);
        delegate void BalanceWarning(User user, decimal balance);
        event BalanceWarning UserBalanceWarning;
    }
}