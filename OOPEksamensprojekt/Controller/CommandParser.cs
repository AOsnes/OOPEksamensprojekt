using System;
using System.Collections.Generic;
using OOPEksamensprojekt.Core;
using OOPEksamensprojekt.Core.Exceptions;
using OOPEksamensprojekt.UI;

namespace OOPEksamensprojekt.Controller
{
    public class CommandParser
    {
        private IStregsystem _stregsystem;
        private IStregsystemUI _ui;
        private Dictionary<string, Action<string[]>> _adminCommandsDictionary;

        public CommandParser(IStregsystem stregsystem, IStregsystemUI ui)
        {
            _stregsystem = stregsystem;
            _ui = ui;

            AdminCommands adminCommands = new AdminCommands(_stregsystem, _ui);
            _adminCommandsDictionary = new Dictionary<string, Action<string[]>>()
            {
                {":q", adminCommands.Quit},
                {":quit", adminCommands.Quit},
                {":activate", adminCommands.ActivateProduct},
                {":deactivate", adminCommands.DeactivateProduct},
                {":crediton", adminCommands.EnableBuyOnCredit},
                {":creditoff", adminCommands.DisableBuyOnCredit},
                {":addcredits", adminCommands.AddCredits}
            };

        }
        
        public void ParseInput(string command)
        {
            if (command.StartsWith(':'))
            {
                ParseAdminCommand(command);
            }
            else
            {
                ParseCommand(command);
            }
        }

        private void ParseAdminCommand(string command)
        {
            string[] commands = command.Split(" ");
            try
            {
                _adminCommandsDictionary[commands[0]](commands);
            }
            catch (KeyNotFoundException)
            {
                _ui.DisplayAdminCommandNotFoundMessage(commands[0]);
            }

        }

        private void ParseCommand(string command)
        {
            string[] commandArray = command.Split(" ");
            User user;
            
            try
            {
                user = _stregsystem.GetUserByUsername(commandArray[0]);
            }
            catch (UserDoesNotExistException e)
            {
                _ui.DisplayUserNotFound(e.Username);   
                return;
            }

            switch (commandArray.Length)
            {
                case 1:
                    //Display user info
                    UserInfoCommand(user);
                    break;
                case 2:
                    //Buy one item
                    UserBuysProductCommand(user, Convert.ToInt32(commandArray[1]), 1);
                    break;
                case 3:
                    //buy multiple items
                    UserBuysProductCommand(user, Convert.ToInt32(commandArray[1]), Convert.ToInt32(commandArray[2]));
                    break;
                default:
                    _ui.DisplayGeneralError("Too many arguments in command. Please retry.");
                    break;
            }
        }

        private void UserInfoCommand(User user)
        {
            IEnumerable<Transaction> transactions = _stregsystem.GetTransactions(user, 10);
            _ui.DisplayUserInfo(user);
            _ui.DisplayTransactions(transactions);
        }

        private void UserBuysProductCommand(User user, int id, int amount)
        {
            Product product;
            BuyTransaction transaction;
            try
            {
                product = _stregsystem.GetProductByID(id);
                transaction = _stregsystem.BuyProduct(user, product, amount);
                transaction.Execute();
                if (amount == 1)
                {
                    _ui.DisplayUserBuysProduct(transaction);
                }
                else
                {
                    _ui.DisplayUserBuysProduct(amount, transaction);
                }
            }
            catch (ProductDoesNotExistException e)
            {
                _ui.DisplayProductNotFound(e.Id.ToString());
            }
            catch (ProductInactiveException e)
            {
                _ui.DisplayGeneralError(e.Message);
            }
            catch (InsufficientCreditsException e)
            {
                _ui.DisplayInsufficientCash(e.User, e.Product);
            }
            catch (Exception e)
            {
                _ui.DisplayGeneralError(e.Message);
            }
        }
        
    }
}