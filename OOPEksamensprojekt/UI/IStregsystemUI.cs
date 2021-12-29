using System.Collections.Generic;
using OOPEksamensprojekt.Core;

namespace OOPEksamensprojekt.UI
{
    public interface IStregsystemUI
    {
        public delegate void StregsystemEvent(string command);
        void DisplayUserNotFound(string username);
        void DisplayProductNotFound(string product);
        void DisplayUserInfo(User user);
        void DisplayTooManyArgumentsError(string command);
        void DisplayAdminCommandNotFoundMessage(string adminCommand);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void Close();
        void DisplayInsufficientCash(User user, Product product);
        void DisplayGeneralError(string errorString);
        void Start();
        void DisplayTransactions(IEnumerable<Transaction> transactions);
        event StregsystemEvent CommandEntered;
    }
}