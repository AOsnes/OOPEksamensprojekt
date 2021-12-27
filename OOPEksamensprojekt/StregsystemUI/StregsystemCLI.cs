using System;
using OOPEksamensprojekt.StregsystemCore;

namespace OOPEksamensprojekt.StregsystemUI
{
    public class StregsystemCLI : IStregsystemUI
    {
        public IStregsystem Stregsystem { get; private set; }
        private bool _running;
        
        public StregsystemCLI(IStregsystem stregsystem)
        {
            Stregsystem = stregsystem;
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

                userInput = Console.ReadLine();

            }
            
        }

        public void DisplayProducts()
        {
            foreach (Product product in Stregsystem.ActiveProducts)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
        }

        public void DisplayTransactions()
        {
            
        }

        public event IStregsystemUI.StregsystemEvent CommandEntered;
    }
}