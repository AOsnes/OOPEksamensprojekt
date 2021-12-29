using System;

namespace OOPEksamensprojekt.Core.Exceptions
{
    public class InsufficientCreditsException : Exception
    {
        public User User;
        public Product Product;
        public InsufficientCreditsException(User user, Product product, string msg) : base(msg)
        {
            User = user;
            Product = product;
        }
    }
}