using System;
using OOPEksamensprojekt.Core;
using OOPEksamensprojekt.Core.Exceptions;
using OOPEksamensprojekt.UI;

namespace OOPEksamensprojekt.Controller
{
    public class AdminCommands
    {
        private IStregsystem _stregsystem;
        private IStregsystemUI _ui;
        
        public AdminCommands(IStregsystem stregsystem, IStregsystemUI ui)
        {
            _stregsystem = stregsystem;
            _ui = ui;
        }

        public void Quit(string[] args)
        {
            _ui.Close();
        }

        public void ActivateProduct(string[] args)
        {
            try
            {
                _stregsystem.GetProductByID(Convert.ToInt32(args[1])).Activate();
            }
            catch (ProductDoesNotExistException e)
            {
                _ui.DisplayProductNotFound(e.Id.ToString());
                return;
            }
            catch (IndexOutOfRangeException)
            {
                _ui.DisplayGeneralError("Please enter a product");
                return;
            }
        }

        public void DeactivateProduct(string[] args)
        {
            try
            {
                _stregsystem.GetProductByID(Convert.ToInt32(args[1])).Deactivate();
            }
            catch (ProductDoesNotExistException e)
            {
                _ui.DisplayProductNotFound(e.Id.ToString());
                return;
            }
            catch (IndexOutOfRangeException)
            {
                _ui.DisplayGeneralError("Please enter a product");
                return;
            }
        }

        public void EnableBuyOnCredit(string[] args)
        {
            try
            {
                _stregsystem.GetProductByID(Convert.ToInt32(args[1])).EnableBuyOnCredit();
            }
            catch (ProductDoesNotExistException e)
            {
                _ui.DisplayProductNotFound(e.Id.ToString());
                return;
            }
            catch (IndexOutOfRangeException)
            {
                _ui.DisplayGeneralError("Please enter a product");
                return;
            }
        }

        public void DisableBuyOnCredit(string[] args)
        {
            try
            {
                _stregsystem.GetProductByID(Convert.ToInt32(args[1])).DisableBuyOnCredit();
            }
            catch (ProductDoesNotExistException e)
            {
                _ui.DisplayProductNotFound(e.Id.ToString());
                return;
            }
            catch (IndexOutOfRangeException)
            {
                _ui.DisplayGeneralError("Please enter a product");
                return;
            }
        }

        public void AddCredits(string[] args)
        {
            try
            {
                User user = _stregsystem.GetUserByUsername(args[1]);
                InsertCashTransaction transaction = _stregsystem.AddCreditsToAccount(user, Convert.ToInt32(args[2]));
                transaction.Execute();
            }
            catch (UserDoesNotExistException e)
            {
                _ui.DisplayUserNotFound(e.Username);
            }
            catch (IndexOutOfRangeException)
            {
                _ui.DisplayGeneralError("Please enter a user and an amount");
            }
            catch (Exception e)
            {
                _ui.DisplayGeneralError(e.Message);
            }
        }
    }
}