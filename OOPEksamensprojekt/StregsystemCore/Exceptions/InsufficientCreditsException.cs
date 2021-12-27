using System;

namespace OOPEksamensprojekt.StregsystemCore
{
    public class InsufficientCreditsException : Exception
    {
        private User _user;
        private Product _product;
        public InsufficientCreditsException(User user, Product product, string msg) : base(msg)
        {
            _user = user;
            _product = product;
        }
    }
}