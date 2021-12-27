using System;

namespace OOPEksamensprojekt.StregsystemCore
{
    public class ProductInactiveException : Exception
    {
        public Product InactiveProduct { get; private set; }
        public ProductInactiveException(Product product) : base($"{product} is inactive and cannot be bought")
        {
            InactiveProduct = product;
        }
    }
}