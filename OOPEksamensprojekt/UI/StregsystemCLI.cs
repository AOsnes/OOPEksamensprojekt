using System;
using System.Collections.Generic;
using OOPEksamensprojekt.Core;

namespace OOPEksamensprojekt.UI
{
    public class StregsystemCLI : IStregsystemUI
    {
        public IStregsystem Stregsystem { get; private set; }
        private bool _running;
        
        public StregsystemCLI(IStregsystem stregsystem)
        {
            Stregsystem = stregsystem;
            stregsystem.UserBalanceWarning += DisplayLowBalance;
        }
        
        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"{username} is not found in users");
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine($"{product} is not found in available products");
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user.ToString());
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine($"{command} contains too many arguments");
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"{adminCommand} is not found");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.ToString());
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine($"{transaction} is bought {count} time(s)");
        }

        public void Close()
        {
            Console.WriteLine("Program closing, bye!");
            _running = false;
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine($"{user.Username} has insufficient funds to buy {product}");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine($"An error has occured with message: {errorString}");
        }

        public void Start()
        {
            _running = true;
            DisplayProducts();
            string userInput;
            
            while (_running)
            {
                Console.WriteLine("Please enter your command");
                userInput = Console.ReadLine();
                
                CommandEntered?.Invoke(userInput);
            }
            
        }

        public void DisplayLowBalance(User user, decimal balance)
        {
            Console.WriteLine($"Warning! {user.Username} has a low balance of {balance}");
        }
        
        public void DisplayProducts()
        {
            foreach (Product product in Stregsystem.ActiveProducts)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
        }

        public void DisplayTransactions(IEnumerable<Transaction> transactions)
        {
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        public event IStregsystemUI.StregsystemEvent CommandEntered;
    }
}